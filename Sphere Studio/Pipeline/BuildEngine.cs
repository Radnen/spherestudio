using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Jurassic;

using Sphere.Plugins;
using SphereStudio.Components;
using SphereStudio.IDE;

namespace SphereStudio.Pipeline
{
    /// <summary>
    /// Manages the build process for a project.
    /// </summary>
    class BuildEngine : IDisposable
    {
        private Project _project;
        private List<string> _require_list = new List<string>();
        private BuildStatusView _view = new BuildStatusView();

        public BuildEngine(Project project)
        {
            _project = project;
        }

        public void Dispose()
        {
            _view.Dispose();
        }

        /// <summary>
        /// Gets the Jurassic context used to run scripts for this
        /// build engine.
        /// </summary>
        public ScriptEngine JS { get; private set; }

        /// <summary>
        /// Prepares a newly created project.
        /// </summary>
        /// <param name="project"></param>
        public void Prep()
        {
            _view.Clear();
            _view.Pane.Show();
            try
            {
                Print(string.Format("----------- Prepping Sphere project: {0} -----------", _project.Name));
                SpinUp();
                var source = new Source(this, _project);
                JS.CallGlobalFunction("prep", source);
                Print(string.Format("============ Successfully prepped: {0} =============", _project.Name));
            }
            catch (JavaScriptException exc)
            {
                // JS runtime error (abort build)
                Print(string.Format("[{0}:{1}] {2}",
                    Path.GetFileName(exc.SourcePath), exc.LineNumber,
                    exc.Message));
                Print(string.Format("=============== Failed to prep: {0} ================", _project.Name));
                SystemSounds.Hand.Play();
                throw new OperationCanceledException();
            }
        }

        /// <summary>
        /// Builds a game distribution from a Sphere Studio project. The build is run
        /// on a separate thread.
        /// </summary>
        /// <param name="project">The project to be built.</param>
        /// <returns>The full directory path of the final distribution.</returns>
        public async Task<string> Build()
        {
            _view.Clear();
            _view.Pane.Show();
            return await Task.Run(() =>
            {
                // run the build script
                try
                {
                    Print(string.Format("----------- Building Sphere project: {0} -----------", _project.Name));
                    SpinUp();
                    var source = new Source(this, _project);
                    var target = new Target(this,
                        Path.Combine(_project.RootPath, _project.BuildPath.Replace('/', Path.DirectorySeparatorChar)));
                    JS.CallGlobalFunction("build", source, target);

                    // return Sphere game dist directory. currently this is the project
                    // directory, but in the future we will create a 'dist' subdirectory
                    // for the final game.
                    var distPath = Path.GetDirectoryName(target.RootPath);
                    Print(string.Format("Distribution: {0}", distPath));
                    Print(string.Format("============= Successfully built: {0} ==============", _project.Name));
                    return distPath;
                }
                catch (JavaScriptException exc)
                {
                    // JS runtime error (abort build)
                    Print(string.Format("[{0}:{1}] {2}",
                        Path.GetFileName(exc.SourcePath), exc.LineNumber,
                        exc.Message));
                    Print(string.Format("=============== Failed to build: {0} ===============", _project.Name));
                    SystemSounds.Hand.Play();
                    throw new OperationCanceledException();
                }
            });
        }

        public async Task Clean()
        {
            _view.Clear();
            _view.Pane.Show();
            await Task.Run(() =>
            {
                // run the clean script
                try
                {
                    Print(string.Format("----------- Cleaning Sphere target: {0} ------------", _project.Name));
                    SpinUp();
                    var target = new Target(this,
                        Path.Combine(_project.RootPath, _project.BuildPath.Replace('/', Path.DirectorySeparatorChar)));
                    JS.CallGlobalFunction("clean", target);
                    Print(string.Format("============ Successfully cleaned: {0} =============", _project.Name));
                }
                catch (JavaScriptException exc)
                {
                    // JS runtime error (abort build)
                    Print(string.Format("[{0}:{1}] {2}",
                        Path.GetFileName(exc.SourcePath), exc.LineNumber,
                        exc.Message));
                    Print(string.Format("=============== Failed to clean: {0} ===============", _project.Name));
                    SystemSounds.Hand.Play();
                    throw new OperationCanceledException();
                }
            });
        }

        public void Print(string text)
        {
            PluginManager.IDE.Invoke(new Action(() =>
            {
                _view.Print(text);
            }), null);
        }

        private void js_RequireScript(string filename)
        {
            if (!_require_list.Contains(filename, StringComparer.CurrentCultureIgnoreCase))
            {
                _require_list.Add(filename);
                var path = Path.Combine(Application.StartupPath, "Scripts", filename);
                JS.ExecuteFile(path, Encoding.UTF8);
            }
        }

        private void SpinUp()
        {
            Print("Evaluating build script");

            JS = new ScriptEngine();
            JS.SetGlobalValue("FileWriter", new FileWriterConstructor(JS));
            JS.SetGlobalFunction("RequireScript", new Action<string>(js_RequireScript));
            JS.SetGlobalFunction("Print", new Action<string>(Print));
            _require_list.Clear();

            string scriptPath = File.Exists(Path.Combine(_project.RootPath, "build.js"))
                ? Path.Combine(_project.RootPath, "build.js")
                : Path.Combine(Application.StartupPath, "BuildScripts", "Sphere.js");
            JS.ExecuteFile(scriptPath, Encoding.UTF8);
        }
    }
}
