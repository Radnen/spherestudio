using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Core;
using Sphere.Core.Settings;
using zlib;

namespace Sphere.Plugins
{
    internal struct SPKIndexEntry
    {
        public string Filename;
        public uint   FileSize;
        public uint   PackSize;
        public uint   Offset;
    }

    public partial class MakePackageForm : Form
    {
        private readonly string[] extensions = {
            ".sgm", ".rmp", ".rss", ".rts", ".rfn", ".rws",
            ".js", ".coffee", ".glsl",
            ".png", ".jpg", ".bmp", ".pcx",
            ".mp3", ".ogg", ".mid", ".wav", ".flac", ".it", ".s3m", ".mod",
        };

        private ISettings _conf = new INISettings("SPK.ini");
        private string _projectPath;

        public MakePackageForm(string path)
        {
            InitializeComponent();

            _projectPath = Path.GetFullPath(path);
        }

        private void MakePackageForm_Load(object sender, EventArgs e)
        {
            headerLabel.Text += string.Format(" for \"{0}\"", PluginManager.IDE.CurrentGame.Name);

            deflateLvLabel.Text = string.Format("Compression Lv. {0}", deflateLevel.Value);
            percentLabel.Text = "";

            var mainDir = new DirectoryInfo(_projectPath);
            var dirStack = new Stack<DirectoryInfo>();
            dirStack.Push(mainDir);
            while (dirStack.Count > 0)
            {
                var thisDir = dirStack.Pop();
                var fileInfos = from FileInfo file in thisDir.GetFiles()
                                orderby file.Name
                                select file;
                foreach (FileInfo file in fileInfos)
                {
                    if (file.Attributes.HasFlag(FileAttributes.Hidden))
                        continue;  // skip hidden files
                    string relativePath = file.FullName.Substring(_projectPath.Length + 1).Replace('\\', '/');
                    ListViewItem item = fileList.Items.Add(relativePath);
                    item.ImageIndex = 0;
                    item.SubItems.Add(String.Format("{0} kB", Math.Ceiling((double)file.Length / 1024)));
                    if (extensions.Contains(Path.GetExtension(file.FullName)))
                        item.Checked = true;
                }
                var dirInfos = from DirectoryInfo dir in thisDir.GetDirectories()
                               orderby dir.Name descending
                               select dir;
                foreach (var dir in dirInfos)
                {
                    if (dir.Attributes.HasFlag(FileAttributes.Hidden))
                        continue;  // skip hidden directories
                    dirStack.Push(dir);
                }
            }

            var deflate = _conf.GetInteger("deflateLevel", 5);
            deflateLevel.Value = deflate < 0 ? 0 : deflate > 9 ? 9 : deflate;
            deflateLvLabel.Text = String.Format("Compression Lv. {0}", deflateLevel.Value);
        }

        private void deflateLevel_Scroll(object sender, EventArgs e)
        {
            deflateLvLabel.Text = String.Format("Compression Lv. {0}", deflateLevel.Value);
        }

        private void makePackageButton_Click(object sender, EventArgs e)
        {
            const int bufferSize = 1048576;

            var packageDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Sphere Studio\Packages");
            Directory.CreateDirectory(packageDir);
            BinaryWriter spkWriter = null;
            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Save Game Package";
                dialog.Filter = "Sphere Package (.spk)|*.spk";
                dialog.AddExtension = true;
                dialog.DefaultExt = "spk";
                dialog.InitialDirectory = packageDir;
                dialog.OverwritePrompt = true;
                dialog.AutoUpgradeEnabled = true;
                dialog.FileName = Path.GetFileName(_projectPath);
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    spkWriter = new BinaryWriter(File.Create(dialog.FileName), Encoding.GetEncoding(1252));
                    testButton.Tag = dialog.FileName;
                }
            }
            if (spkWriter == null)
                return;
            testButton.Enabled = false;
            makePackageButton.Enabled = false;
            cancelButton.Enabled = false;
            deflateLevel.Enabled = false;
            fileList.Enabled = false;
            makePackageButton.Text = "Packaging...";
            packProgress.Minimum = 0;
            packProgress.Maximum = fileList.Items.Count;
            packProgress.Value = 0;
            percentLabel.Text = "0%";
            int counter = 0;
            using (spkWriter)
            {
                // reserve 16 bytes for SPK header
                spkWriter.Write(new byte[16]);

                // compress files using zlib and write them to package file
                var index = new List<SPKIndexEntry>();
                var filesToPack = from ListViewItem item in fileList.Items
                                    where item.Checked == true
                                    select item.Text;
                byte[] packBuffer = new byte[bufferSize];
                foreach (string filename in filesToPack)
                {
                    statusLabel.Text = String.Format("Deflating '{0}'...", filename);
                    var filePath = Path.Combine(_projectPath, filename);
                    using (FileStream file = File.OpenRead(filePath))
                    {
                        byte[] unpacked = new byte[file.Length];
                        var indexEntry = new SPKIndexEntry();
                        indexEntry.Offset = (uint)spkWriter.BaseStream.Position;
                        indexEntry.Filename = filename;
                        indexEntry.FileSize = (uint)file.Length;
                        indexEntry.PackSize = 0;
                        file.Read(unpacked, 0, (int)file.Length);
                        var z = new ZStream();
                        z.deflateInit(deflateLevel.Value);
                        z.next_in = unpacked;
                        z.next_in_index = 0;
                        z.avail_in = (int)file.Length;
                        int result;
                        int flushMode = zlibConst.Z_NO_FLUSH;
                        do
                        {
                            z.next_out = packBuffer;
                            z.next_out_index = 0;
                            z.avail_out = bufferSize;
                            result = z.deflate(flushMode);
                            if (z.avail_out > 0)
                                flushMode = zlibConst.Z_FINISH;
                            indexEntry.PackSize += bufferSize - (uint)z.avail_out;
                            spkWriter.Write(packBuffer, 0, bufferSize - z.avail_out);
                            Application.DoEvents();
                        } while (result != zlibConst.Z_STREAM_END);
                        z.deflateEnd();
                        index.Add(indexEntry);
                    }
                    ++counter;
                    packProgress.Value = counter;
                    percentLabel.Text = String.Format("{0}%", 100 * packProgress.Value / packProgress.Maximum);
                }

                // write package index
                statusLabel.Text = "Writing SPK index...";
                uint indexOffset = (uint)spkWriter.BaseStream.Position;
                foreach (SPKIndexEntry entry in index)
                {
                    spkWriter.Write((ushort)(1));  // SPK version 1
                    spkWriter.Write((ushort)entry.Filename.Length);
                    spkWriter.Write(entry.Offset);
                    spkWriter.Write(entry.FileSize);
                    spkWriter.Write(entry.PackSize);
                    spkWriter.Write(entry.Filename.ToCharArray());
                }

                // write SPK header
                spkWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                spkWriter.Write(".spk".ToCharArray());
                spkWriter.Write((ushort)(1));  // SPK version 1
                spkWriter.Write(filesToPack.Count());
                spkWriter.Write(indexOffset);
                spkWriter.Write(new byte[2]);
            }
            packProgress.Value = packProgress.Maximum;
            percentLabel.Text = "100%";
            statusLabel.Text = "Finished!";
            makePackageButton.Enabled = true;
            cancelButton.Enabled = true;
            fileList.Enabled = true;
            deflateLevel.Enabled = true;
            testButton.Enabled = true;
            makePackageButton.Text = "Make &Package!";
            cancelButton.Text = "&Close";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _conf.SetValue("deflateLevel", deflateLevel.Value);
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            SphereSettings settings = PluginManager.IDE.EditorSettings;
            string enginePath = System.Environment.Is64BitOperatingSystem && !string.IsNullOrWhiteSpace(settings.Sphere64Path)
                ? settings.Sphere64Path : settings.SpherePath;
            string args = string.Format("-package \"{0}\"", testButton.Tag);
            Process.Start(enginePath, args);
        }
    }
}
