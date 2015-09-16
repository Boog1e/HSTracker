using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HearthstoneTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //string path = @"D:\Program Files (x86)\Battle.net\Hearthstone\Hearthstone_Data";
                string path = @"C:\Users\Mathias Sørensen\Desktop";
                var watch = new FileSystemWatcher();
                watch.Path = path;
                //watch.Filter = "output_log.txt";
                watch.Filter = "hstracker.txt";
                watch.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite;
                watch.Changed += new FileSystemEventHandler(OnChanged);
                watch.EnableRaisingEvents = true;
            }
            catch
            {}
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            try
            {
                string path = @"C:\Users\Mathias Sørensen\Desktop\hstracker.txt";
                //@"D:\Program Files (x86)\Battle.net\Hearthstone\Hearthstone_Data\output_log.txt"
                if (e.FullPath == path)
                {
                    string read = File.ReadAllLines(path).Last();
                    if (read.Contains("OPPOSING"))
                    {
                        
                    }
                }
            }
            catch
            {}
        }
    }
}
