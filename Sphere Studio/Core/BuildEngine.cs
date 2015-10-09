using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using SphereStudio.UI;

namespace SphereStudio
{
    /// <summary>
    /// Exposes the build engine, which manages compilation and debugging.
    /// </summary>
    static class BuildEngine
    {
        private static BuildConsole _buildView;

        /// <summary>
        /// Initializes the build system.
        /// </summary>
        public static void Initialize()
        {
            _buildView = new BuildConsole();
            Sphere.Plugins.PluginManager.Register(null, _buildView, "Build Log");
        }

        /// <summary>
        /// 'true' if the current engine supports single-step debugging.
        /// </summary>
        public static bool CanDebug
        {
            get { return Sphere.Plugins.PluginManager.Get<IDebugStarter>(Core.Settings.Engine) != null; }
        }

        /// <summary>
        /// 'true' if the current compiler supports packaging.
        /// </summary>
        public static bool CanPackage
        {
            get { return Sphere.Plugins.PluginManager.Get<IPackager>(Core.Settings.Compiler) != null; }
        }

        /// <summary>
        /// Gets the SaveFileDialog filter for the current packaging compiler. Throws an
        /// exception if the compiler doesn't support packages.
        /// </summary>
        public static string SavePackageFilters
        {
            get
            {
                if (!CanPackage)
                    throw new NotSupportedException("The current compiler doesn't support packaging.");
                var packager = Sphere.Plugins.PluginManager.Get<IPackager>(Core.Settings.Compiler);
                return packager.SaveFileFilters;
            }
        }

        /// <summary>
        /// Builds a game distribution from a project using the current compiler.
        /// </summary>
        /// <param name="project">The project to build.</param>
        /// <returns>The full path of the compiled distribution.</returns>
        public static async Task<string> Build(IProject project, bool forceVisible = false)
        {
            _buildView.Clear();
            Sphere.Plugins.PluginManager.IDE.Docking.Show(_buildView);
            _buildView.Print(string.Format("------------------- Build started: {0} -------------------\n\n", project.Name));
            var compiler = Sphere.Plugins.PluginManager.Get<ICompiler>(Core.Settings.Compiler);
            string outPath = Path.Combine(project.RootPath, project.BuildPath);
            bool isOK = false;
            if (compiler != null)
                isOK = await compiler.Build(project, outPath, _buildView);
            else
            {
                _buildView.Print("[error] no compiler available to build project\n\n");
                _buildView.Print("Please open Configuration Manager to select a compiler.\n");
            }
            if (isOK)
            {
                _buildView.Print(string.Format("\n================= Successfully built: {0} ================\n", project.Name));
                if (Core.Settings.AutoHideBuild && !forceVisible)
                    Sphere.Plugins.PluginManager.IDE.Docking.Hide(_buildView);
                return outPath;
            }
            else
            {
                _buildView.Print(string.Format("\n================== Failed to build: {0} ==================\n", project.Name));
                SystemSounds.Exclamation.Play();
                return null;
            }
        }

        /// <summary>
        /// Builds a game package from a project using the current compiler.
        /// </summary>
        /// <param name="project">The project to build.</param>
        /// <param name="fileName">The full path of the package to build. If the file exists, it will be overwritten.</param>
        /// <returns>'true' if packaging succeeded, false if not.</returns>
        public static async Task<bool> Package(IProject project, string fileName)
        {
            if (!CanPackage)
                throw new NotSupportedException("The current compiler doesn't support packaging.");

            _buildView.Clear();
            Sphere.Plugins.PluginManager.IDE.Docking.Show(_buildView);
            _buildView.Print(string.Format("----------------- Packaging started: {0} -----------------\n\n", project.Name));
            var packager = Sphere.Plugins.PluginManager.Get<IPackager>(Core.Settings.Compiler);
            bool isOK = await packager.Package(project, fileName, _buildView);
            if (isOK)
                _buildView.Print(string.Format("\n=============== Successfully packaged: {0} ===============\n", project.Name));
            else
            {
                _buildView.Print(string.Format("\n================= Failed to package: {0} =================\n", project.Name));
                SystemSounds.Exclamation.Play();
            }
            return isOK;
        }

        /// <summary>
        /// Starts single-step debugging a project using the current engine.
        /// </summary>
        /// <param name="project">The project to debug.</param>
        /// <returns>An IDebugger used to manage the debugging session.</returns>
        public static async Task<IDebugger> Debug(IProject project)
        {
            if (!CanDebug)
                throw new NotSupportedException("The current engine starter doesn't support debugging.");

            var starter = Sphere.Plugins.PluginManager.Get<IDebugStarter>(Core.Settings.Engine);
            string outPath = await Build(project);
            return starter.Debug(outPath, false, project);
        }

        /// <summary>
        /// Tests the game with the current engine.
        /// </summary>
        /// <param name="project">The project to test.</param>
        public static async Task Test(IProject project)
        {
            var starter = Sphere.Plugins.PluginManager.Get<IStarter>(Core.Settings.Engine);
            if (starter != null)
            {
                string outPath = await Build(project);
                if (outPath != null)
                {
                    starter.Start(outPath, false);
                }
            }
            else
            {
                MessageBox.Show(
                    "No engine is available to test play this project. Open Configuration Manager and select an engine, then try again.",
                    "Unable to Test Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}
