using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            ".sgm", ".rmp", ".rss", ".rts", ".rfn", ".js",
            ".png", ".jpg", ".bmp", ".pcx",
            ".mp3", ".ogg", ".mid", ".wav", ".flac"
        };

        private string projectPath;

        public MakePackageForm(string path)
        {
            InitializeComponent();

            projectPath = Path.GetFullPath(path);
        }

        private void MakePackageForm_Load(object sender, EventArgs e)
        {
            deflateLvLabel.Text = String.Format("Compression Lv. {0}", deflateLevel.Value);
            percentLabel.Text = "";

            var mainDir = new DirectoryInfo(projectPath);
            var dirQueue = new Queue<DirectoryInfo>();
            dirQueue.Enqueue(mainDir);
            while (dirQueue.Count > 0)
            {
                var thisDir = dirQueue.Dequeue();
                foreach (FileInfo file in thisDir.GetFiles())
                {
                    if (file.Attributes.HasFlag(FileAttributes.Hidden))
                        continue;  // skip hidden files
                    string relativePath = file.FullName.Substring(projectPath.Length + 1).Replace('\\', '/');
                    ListViewItem item = fileList.Items.Add(relativePath);
                    item.ImageIndex = 0;
                    item.SubItems.Add(String.Format("{0} kB", Math.Ceiling((double)file.Length / 1024)));
                    if (extensions.Contains(Path.GetExtension(file.FullName)))
                        item.Checked = true;
                }
                foreach (DirectoryInfo dir in thisDir.GetDirectories())
                {
                    if (dir.Attributes.HasFlag(FileAttributes.Hidden))
                        continue;  // skip hidden directories
                    dirQueue.Enqueue(dir);
                }
            }
        }

        private void deflateLevel_Scroll(object sender, EventArgs e)
        {
            deflateLvLabel.Text = String.Format("Compression Lv. {0}", deflateLevel.Value);
        }

        private void makePackageButton_Click(object sender, EventArgs e)
        {
            const int bufferSize = 1048576;

            BinaryWriter spkWriter = null;
            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Save Game Package";
                dialog.Filter = "Sphere Package (.spk)|*.spk";
                dialog.AddExtension = true;
                dialog.DefaultExt = "spk";
                dialog.InitialDirectory = projectPath;
                dialog.OverwritePrompt = true;
                dialog.AutoUpgradeEnabled = true;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                    spkWriter = new BinaryWriter(File.Create(dialog.FileName), Encoding.GetEncoding(1252));
            }
            if (spkWriter == null)
                return;
            makePackageButton.Enabled = false;
            cancelButton.Enabled = false;
            deflateLevel.Enabled = false;
            makePackageButton.Text = "Packaging...";
            packProgress.Minimum = 0;
            packProgress.Maximum = fileList.Items.Count;
            packProgress.Value = 0;
            percentLabel.Text = "0%";
            int counter = 0;
            spkWriter.Write(new byte[16]);  // reserve 16 bytes for SPK header
            var index = new List<SPKIndexEntry>();
            var filesToPack = from ListViewItem item in fileList.Items
                              where item.Checked == true
                              select item.Text;
            byte[] packBuffer = new byte[bufferSize];
            foreach (string filename in filesToPack)
            {
                statusLabel.Text = String.Format("Deflating '{0}'...", filename);
                var filePath = Path.Combine(projectPath, filename);
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
            statusLabel.Text = "Writing SPK index...";
            uint indexOffset = (uint)spkWriter.BaseStream.Position;
            foreach (SPKIndexEntry entry in index)
            {
                spkWriter.Write((short)(1));
                spkWriter.Write((short)entry.Filename.Length);
                spkWriter.Write(entry.Offset);
                spkWriter.Write(entry.FileSize);
                spkWriter.Write(entry.PackSize);
                spkWriter.Write(entry.Filename.ToCharArray());
            }
            spkWriter.BaseStream.Seek(0, SeekOrigin.Begin);
            spkWriter.Write(".spk".ToCharArray());
            spkWriter.Write((short)(1));  // SPK version 1
            spkWriter.Write(filesToPack.Count());
            spkWriter.Write(indexOffset);
            spkWriter.Write(new byte[2]);
            spkWriter.Dispose();
            packProgress.Value = packProgress.Maximum;
            percentLabel.Text = "100%";
            statusLabel.Text = "Finished!";
            makePackageButton.Text = "Make &Package";
            makePackageButton.Enabled = true;
            cancelButton.Enabled = true;
            deflateLevel.Enabled = true;
            cancelButton.Text = "&Close";
        }
    }
}
