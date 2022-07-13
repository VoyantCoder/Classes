
// Author: Dashie


using System.IO;
using System.Diagnostics;
using System.Windows.Forms;


// Summary: This class deals with the opening of URLs.

namespace URLOpener
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0 && File.Exists(args[0]))
            {
                if (args[0].ToLower().EndsWith(".txt"))
                {
                    var response = MessageBox.Show("You are about to open URLs. Are you sure?", "URL Opener", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (response != DialogResult.Yes)
                    {
                        return;
                    }

                    foreach (string line in File.ReadLines(args[0]))
                    {
                        Process.Start(line);
                    }
                }
            }
        }
    }
}
