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
using SphereStudio.DockPanes;

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
            PluginManager.Register(null, _buildView, "Build Log");
        }

        /// <summary>
        /// 'true' if the current engine supports single-step debugging.
        /// </summary>
        public static bool CanDebug
        {
            get { return Core.Project != null && PluginManager.Get<IDebugStarter>(Core.Project.Engine) != null; }
        }

        /// <summary>
        /// 'true' if the current compiler supports packaging.
        /// </summary>
        public static bool CanPackage
        {
            get { return Core.Project != null && PluginManager.Get<IPackager>(Core.Project.Compiler) != null; }
        }

        /// <summary>
        /// Gets the SaveFileDialog filter for the current packaging compiler. Throws an
        /// exception if the compiler doesn't support packages.
        /// </summary>
        public static string SaveFileFilters
        {
            get
            {
                if (!CanPackage)
                    throw new NotSupportedException("The active compiler doesn't support packaging.");
                var packager = PluginManager.Get<IPackager>(Core.Project.Compiler);
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
            PluginManager.Core.Docking.Show(_buildView);
            _buildView.Print(string.Format("------------------- Build started: {0} -------------------\n", project.Name));
            var compiler = PluginManager.Get<ICompiler>(Core.Project.Compiler);
            string outPath = Path.Combine(project.RootPath, project.BuildPath);
            bool isOK = false;
            if (compiler != null)
                isOK = await compiler.Build(project, outPath, _buildView);
            else
            {
                _buildView.Print("ERROR: Compiler missing. Open Configuration Manager and check your plugins.\n\n");
                _buildView.Print(string.Format("(Toolchain: {0}/{1})\n", Core.Project.Engine, Core.Project.Compiler));
            }
            if (isOK)
            {
                _buildView.Print(string.Format("================= Successfully built: {0} ================\n", project.Name));
                if (Core.Settings.AutoHideBuild && !forceVisible)
                    PluginManager.Core.Docking.Hide(_buildView);
                return outPath;
            }
            else
            {
                _buildView.Print(string.Format("================== Failed to build: {0} ==================\n", project.Name));
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
            PluginManager.Core.Docking.Show(_buildView);
            _buildView.Print(string.Format("----------------- Packaging started: {0} -----------------\n", project.Name));
            var packager = PluginManager.Get<IPackager>(Core.Project.Compiler);
            bool isOK = await packager.Package(project, fileName, _buildView);
            if (isOK)
                _buildView.Print(string.Format("=============== Successfully packaged: {0} ===============\n", project.Name));
            else
            {
                _buildView.Print(string.Format("================= Failed to package: {0} =================\n", project.Name));
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

            var starter = PluginManager.Get<IDebugStarter>(Core.Project.Engine);
            string outPath = await Build(project);
            if (outPath != null)
                return starter.Debug(outPath, false, project);
            else
                return null;
        }

        /// <summary>
        /// Tests the game with the current engine.
        /// </summary>
        /// <param name="project">The project to test.</param>
        public static async Task Test(IProject project)
        {
            var starter = PluginManager.Get<IStarter>(Core.Project.Engine);
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
                    string.Format("Unable to test project.\n\nA required toolchain plugin is missing.  You may not have the necessary toolchain installed, or the plugin may be disabled.  Open Configuration Manager and check your plugins.\n\nProject: {0}\n\nToolchain:\n{1}/{2}", Core.Project.Name, Core.Project.Engine, Core.Project.Compiler),
                    "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}
