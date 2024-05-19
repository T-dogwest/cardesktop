using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace cardesktop
{
   
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Contains("--stat")){
                new Statisztika();
            }
            else
            {
                var app = new Application();
                app.Run(new MainWindow());
            }
        }
    }
}
