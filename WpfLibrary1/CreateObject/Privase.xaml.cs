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

namespace WpfLibrary1.CreateObject
{
    /// <summary>
    /// Логика взаимодействия для Privase.xaml
    /// </summary>
    public partial class Privase : Window
    {
        ApplicationContext db = new ApplicationContext();
        public Privase()
        {
            InitializeComponent();
        }

        private void Button_No(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Yes(object sender, RoutedEventArgs e)
        {
            db.Dishes.Remove(MenuBlud1.ItemDish);
            db.SaveChanges();
            this.Close();
        }
    }
}
