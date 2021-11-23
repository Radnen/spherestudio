﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using SphereStudio.Base;

namespace SphereStudio.Plugins.Components
{
    class CellCompiler : IPackager
    {
        private PluginMain m_main;

        public CellCompiler(PluginMain main)
        {
            m_main = main;
        }

        public string SaveFileFilters
        {
            get { return "Sphere Game Package|*.spk"; }
        }

        public bool Prep(IProject project, IConsole con)
        {
            con.Print("Installing project template... ");
            CopyDirectory(Path.Combine(m_main.Conf.EnginePath, "system", "template"), project.RootPath);
            con.Print("OK.\n");

            var cellTemplatePath = Path.Combine(project.RootPath, "Cellscript.js.tmpl");
            var scriptTemplatePath = Path.Combine(project.RootPath, "scripts\\main.js.tmpl");
            try
            {
                con.Print("Generating Cellscript... ");
                var cellscriptPath = Path.Combine(project.RootPath, "Cellscript.js");
                var mainScriptPath = Path.Combine(project.RootPath, "scripts\\main.js");
                var template = File.ReadAllText(cellTemplatePath);
                var script = string.Format(template,
                    JSifyString(project.Name, '"'), JSifyString(project.Author, '"'),
                    JSifyString(project.Summary, '"'),
                    $"{project.ScreenWidth}x{project.ScreenHeight}");
                File.WriteAllText(cellscriptPath, script);
                File.Delete(cellTemplatePath);
                con.Print("OK.\n");
                con.Print("Generating main module... ");
                template = File.ReadAllText(scriptTemplatePath);
                script = string.Format(template,
                    JSifyString(project.Name, '"'), JSifyString(project.Author, '"'),
                    JSifyString(project.Summary, '"'),
                    $"{project.ScreenWidth}x{project.ScreenHeight}");
                File.WriteAllText(mainScriptPath, script);
                File.Delete(scriptTemplatePath);
                con.Print("OK.\n");
            }
            catch (Exception exc)
            {
                con.Print(string.Format("\n[error] {0}\n", exc.Message));
                return false;
            }

            con.Print("Success!\n");
            return true;
        }

        public async Task<bool> Build(IProject project, string outPath, bool debuggable, IConsole con)
        {
            string cellOptions = string.Format(@"--in-dir ""{0}"" --out-dir ""{1}"" {2}",
                project.RootPath.Replace(Path.DirectorySeparatorChar, '/'),
                outPath.Replace(Path.DirectorySeparatorChar, '/'),
                debuggable ? "--debug" : "--release");
            return await RunCell(cellOptions, con);
        }

        public async Task<bool> Package(IProject project, string fileName, bool debuggable, IConsole con)
        {
            var stagingPath = Path.Combine(project.RootPath, project.BuildPath);
            string cellOptions = string.Format(@"pack --in-dir ""{0}"" --out-dir ""{1}"" {2} ""{3}""",
                project.RootPath.Replace(Path.DirectorySeparatorChar, '/'),
                stagingPath,
                m_main.Conf.MakeDebugPackages ? "--debug" : "--release",
                fileName.Replace(Path.DirectorySeparatorChar, '/'));
            return await RunCell(cellOptions, con);
        }

        private void CopyDirectory(string sourcePath, string destPath)
        {
            var source = new DirectoryInfo(sourcePath);
            var target = new DirectoryInfo(destPath);
            target.Create();
            foreach (var fileInfo in source.GetFiles())
            {
                var destFileName = Path.Combine(target.FullName, fileInfo.Name);
                File.Copy(fileInfo.FullName, destFileName, true);
            }
            foreach (var dirInfo in source.GetDirectories())
            {
                var destFileName = Path.Combine(target.FullName, dirInfo.Name);
                CopyDirectory(dirInfo.FullName, destFileName);
            }
        }

        private string JSifyString(string str, char quoteChar)
        {
            str = str
                .Replace("\n", @"\n").Replace("\r", @"\r")
                .Replace(@"\", @"\\");
            if (quoteChar == '"')
                return str.Replace(@"""", @"\""");
            else if (quoteChar == '\'')
                return str.Replace("'", @"\'");
            else
                return str;
        }

        private async Task<bool> RunCell(string options, IConsole con)
        {
            string cellPath = Path.Combine(m_main.Conf.EnginePath, "cell.exe");
            if (!File.Exists(cellPath))
            {
                con.Print("ERROR: no 'cell' executable was found, did Gohan kill Cell already?\n");
                con.Print("       (Please check your GDK path in Settings Center.)\n");
                return false;
            }

            ProcessStartInfo psi = new ProcessStartInfo(cellPath, options);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            Process proc = Process.Start(psi);
            var lineCount = 0;
            proc.OutputDataReceived += (sender, e) =>
            {
                var head = lineCount > 0 ? "\r\n" : "";
                con.Print(head + (e.Data ?? ""));
                ++lineCount;
            };
            proc.BeginOutputReadLine();
            await proc.WaitForExitAsync();
            return proc.ExitCode == 0;
        }
    }
}
