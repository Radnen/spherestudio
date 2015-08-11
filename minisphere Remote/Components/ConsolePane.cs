using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minisphere.Remote.Components
{
    public partial class ConsolePane : UserControl
    {
        public ConsolePane()
        {
            InitializeComponent();

            Print("minisphere Remote 1.7.0");
            Print("");
        }

        public void Print(string text)
        {
            textOutput.Text += text + "\r\n";
        }
    }
}
