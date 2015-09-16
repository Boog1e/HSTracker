using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                string path = @"D:\Program Files (x86)\Battle.net\Hearthstone\Hearthstone_Data";
                var watch = new FileSystemWatcher();
                watch.Path = path;
                watch.Filter = "output_log.txt";
                watch.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite;
                watch.Changed += new FileSystemEventHandler(OnChanged);
                watch.EnableRaisingEvents = true;
            }
            catch
            { }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            try
            {
                string path = @"D:\Program Files (x86)\Battle.net\Hearthstone\Hearthstone_Data\output_log.txt";
                if (e.FullPath == path)
                {
                    string read = File.ReadAllLines(path).Last();
                    if (read.Contains("name="))
                    {
                        string pattern = @"\[name=(?<NameGroup>(.*))\s*id";
                        foreach (Match match in Regex.Matches(read, pattern))
                        {
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Mathias Sørensen\Desktop\hstracker.txt"))
                            {
                                file.WriteLine(match.Groups[1].Value);
                            }
                        }
                    }
                }
            }
            catch
            { }
        }
    }
}
