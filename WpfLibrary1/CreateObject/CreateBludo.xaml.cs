using Microsoft.VisualBasic.ApplicationServices;
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
    /// Логика взаимодействия для CreateBludo.xaml
    /// </summary>
    public partial class CreateBludo : Window
    {
        ApplicationContext db = new ApplicationContext();
        public CreateBludo()
        {
            InitializeComponent();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MenuBlud1 menuBlud = new MenuBlud1();
            menuBlud.Show();
            this.Close();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if (TextName.Text != "" && Convert.ToInt32(TextNum.Text) > 0)
            {
                WpfLibrary1.Model.Dish dish = new WpfLibrary1.Model.Dish { Id = db.Dishes.Count() + 1, Name = TextName.Text.ToString(), Cost = Convert.ToInt32(TextNum.Text) };
                db.Dishes.Add(dish);
                db.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Имя или стоимость не указанна", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
