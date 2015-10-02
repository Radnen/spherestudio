using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using SphereStudio.UI;

namespace SphereStudio.IDE
{
    /// <summary>
    /// Exposes the build engine, which manages compilation and debugging.
    /// </summary>
    static class BuildEngine
    {
        private static BuildConsole buildView;

        /// <summary>
        /// Initializes the build system.
        /// </summary>
        public static void Initialize()
        {
            buildView = new BuildConsole();
        }

        /// <summary>
        /// 'true' if the current engine supports single-step debugging.
        /// </summary>
        public static bool CanDebug
        {
            get { return PluginManager.GetPlugin<IDebugStarter>(Global.Settings.Engine) != null; }
        }

        /// <summary>
        /// 'true' if the current compiler supports packaging.
        /// </summary>
        public static bool CanPackage
        {
            get { return PluginManager.GetPlugin<IPackager>(Global.Settings.Compiler) != null; }
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
                var packager = PluginManager.GetPlugin<IPackager>(Global.Settings.Compiler);
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
            buildView.Clear();
            buildView.DockPane.Show();
            buildView.Print(string.Format("------------------- Build started: {0} -------------------\n\n", project.Name));
            var compiler = PluginManager.GetPlugin<ICompiler>(Global.Settings.Compiler);
            string outPath = Path.Combine(project.RootPath, project.BuildPath);
            bool isOK = false;
            if (compiler != null)
                isOK = await compiler.Build(project, outPath, buildView);
            else
            {
                buildView.Print("[error] no compiler available to build project\n\n");
                buildView.Print("Please open Configuration Manager to select a compiler.\n");
            }
            if (isOK)
            {
                buildView.Print(string.Format("\n================= Successfully built: {0} ================\n", project.Name));
                if (Global.Settings.AutoHideBuild && !forceVisible)
                    buildView.DockPane.Hide();
                return outPath;
            }
            else
            {
                buildView.Print(string.Format("\n================== Failed to build: {0} ==================\n", project.Name));
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

            buildView.Clear();
            buildView.DockPane.Show();
            buildView.Print(string.Format("------------------ Package started: {0} ------------------\n\n", project.Name));
            var packager = PluginManager.GetPlugin<IPackager>(Global.Settings.Compiler);
            bool isOK = await packager.Package(project, fileName, buildView);
            if (isOK)
                buildView.Print(string.Format("\n=============== Successfully packaged: {0} ===============\n", project.Name));
            else
            {
                buildView.Print(string.Format("\n================= Failed to package: {0} =================\n", project.Name));
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

            var starter = PluginManager.GetPlugin<IDebugStarter>(Global.Settings.Engine);
            string outPath = await Build(project);
            return starter.Debug(outPath, false, project);
        }

        /// <summary>
        /// Tests the game with the current engine.
        /// </summary>
        /// <param name="project">The project to test.</param>
        public static async Task Test(IProject project)
        {
            var starter = PluginManager.GetPlugin<IStarter>(Global.Settings.Engine);
            string outPath = await Build(project);
            if (outPath != null)
            {
                starter.Start(outPath, false);
            }
        }
    }
}
