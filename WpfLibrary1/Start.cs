using Microsoft.VisualBasic.ApplicationServices;
using Restauran_Manager_WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary1
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            MainWindow1 mainWindow1 = new MainWindow1();
            mainWindow1.ShowDialog();    
        }
        
    }
}
