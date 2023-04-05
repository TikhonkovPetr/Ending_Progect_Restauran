using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfLibrary1.CreateObject
{
    /// <summary>
    /// Логика взаимодействия для DellTable.xaml
    /// </summary>
    public partial class DellTable : Window
    {
        ApplicationContext db=new ApplicationContext();
        public DellTable()
        {
            InitializeComponent();
        }

        private void Button_Yes(object sender, RoutedEventArgs e)
        {
            db.Tables.Remove(WpfLibrary1.MenuZal1.ItemTable);
            db.SaveChanges();
            this.Close();
        }

        private void Button_No(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
