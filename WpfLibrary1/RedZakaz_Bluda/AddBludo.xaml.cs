using Microsoft.EntityFrameworkCore;
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

namespace WpfLibrary1.RedZakaz_Bluda
{
    /// <summary>
    /// Логика взаимодействия для AddBludo.xaml
    /// </summary>
    public partial class AddBludo : Window
    {
        ApplicationContext db = new ApplicationContext();
        public AddBludo()
        {
            InitializeComponent();
            db.Tables.Load();
            db.Dishes.Load();
            db.ListDish.Load();
            DataContext = db.Dishes.Local.ToObservableCollection();
            ComBox_Dish.DisplayMemberPath = "Name";
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            RedZakaz1 redZakaz = new RedZakaz1();
            redZakaz.Show();
            this.Close();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if (ComBox_Dish.SelectedItem != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    WpfLibrary1.Model.Dish dish = (WpfLibrary1.Model.Dish)ComBox_Dish.SelectedItem as WpfLibrary1.Model.Dish;
                    WpfLibrary1.Model.Table table = db.Tables.Find(RedZakaz1.reserw);
                    //table = db.Tables.FirstOrDefault(u=>u.Id == RedZakaz1.reserw);
                    //table.Order.Add(dish);
                    db.ListDish.Add(new WpfLibrary1.Model.LiDish {ID_Table= RedZakaz1.reserw, ID_Dish=dish.Id });
                    table.Total_cost +=dish.Cost;
                    table.Busy = true;
                    db.SaveChanges();
                    this.Close();
                }
            }
        }
    }
}
