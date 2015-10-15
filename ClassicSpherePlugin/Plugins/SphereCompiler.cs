using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins.Interfaces;

namespace SphereStudio.Vanilla.Plugins
{
    class SphereCompiler : ICompiler
    {
        private readonly string[] fileFilters =
        {
            "*.rmp", "*.rss", "*.rts", "*.rfn", "*.rws",
            "*.js", "*.coffee", "*.glsl",
            "*.mp3", "*.ogg", "*.mid", "*.wav", "*.flac", "*.it", "*.s3m", "*.mod",
            "*.png", "*.jpg", "*.bmp", "*.pcx", "*.mng",
        };

        public async Task<bool> Build(IProject project, string outPath, IConsole con)
        {
            con.Print("Compiling project for Sphere 1.x or compatible engine.\n");

            Directory.CreateDirectory(outPath);

            // if source and destination directories are the same, we can skip the copy step and
            // just generate game.sgm in-place.
            if (Path.GetFullPath(project.RootPath) != Path.GetFullPath(outPath))
            {
                con.Print("Installing assets... ");
                int installCount = 0;
                await Task.Run(() =>
                {
                    DirectoryInfo inDir = new DirectoryInfo(project.RootPath);
                    DirectoryInfo outDir = new DirectoryInfo(outPath);
                    foreach (string filter in fileFilters)
                    {
                        var fileInfos = from info in inDir.GetFiles(filter, SearchOption.AllDirectories)
                                        where !info.FullName.StartsWith(outDir.FullName)  // ignore build directory
                                        select info;
                        foreach (FileInfo info in fileInfos)
                        {
                            string relFilePath = info.FullName.Substring(inDir.FullName.Length + 1);
                            string destFilePath = Path.Combine(outDir.FullName, relFilePath);

                            // copy file only if destination doesn't exist or is older than source
                            Directory.CreateDirectory(Path.GetDirectoryName(destFilePath));
                            if (!File.Exists(destFilePath) || File.GetLastWriteTimeUtc(destFilePath) < info.LastWriteTimeUtc)
                            {
                                if (installCount == 0) con.Print("\n");
                                con.Print("  " + relFilePath + "\n");
                                File.Copy(info.FullName, destFilePath, true);
                                ++installCount;
                            }
                        }
                    }
                });
                if (installCount > 0)
                    con.Print(string.Format("  {0} asset(s) installed\n", installCount));
                else con.Print("Up to date.\n");
            }

            con.Print("Writing game manifest... ");
            string sgmPath = Path.Combine(outPath, "game.sgm");
            using (StreamWriter sw = new StreamWriter(sgmPath)) {
                sw.WriteLine(string.Format("name={0}", project.Name));
                sw.WriteLine(string.Format("author={0}", project.Author));
                sw.WriteLine(string.Format("description={0}", project.Description));
                sw.WriteLine(string.Format("screen_width={0}", project.ScreenWidth));
                sw.WriteLine(string.Format("screen_height={0}", project.ScreenHeight));
                sw.WriteLine(string.Format("script={0}", project.MainScript));
            }
            con.Print("OK.\n");

            con.Print("Success!\n");
            return true;
        }
    }
}
