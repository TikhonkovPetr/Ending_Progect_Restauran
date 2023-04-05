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
using WpfLibrary1.Model;

namespace WpfLibrary1.RedZakaz_Bluda
{
    /// <summary>
    /// Логика взаимодействия для DellWaiter.xaml
    /// </summary>
    public partial class DellWaiter : Window
    {
        ApplicationContext db=new ApplicationContext();
        public DellWaiter()
        {
            InitializeComponent();
        }

        private void Button_No(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Yes(object sender, RoutedEventArgs e)
        {
            //for (int i = 0; i < MenuZal1.tables.Count; i++)
            //{
            //    if (MenuZal1.tables[i].waiter == Waiters1.waiters[Waiters1.index_waiter])
            //    {
            //        MenuZal1.tables[i].waiter = new WpfLibrary1.Model.Waiter();
            //    }
            //}
            db.Waiters.Remove(WpfLibrary1.Waiters1.ItemWaiter);
            db.SaveChanges();
            //for (int i = 1; i <= Waiters1.waiters.Count; i++)
            //{
            //    Waiters1.waiters[i - 1].Id = i;
            //}
            this.Close();
        }
    }
}
