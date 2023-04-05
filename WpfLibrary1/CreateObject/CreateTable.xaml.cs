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

namespace WpfLibrary1.CreateObject
{
    /// <summary>
    /// Логика взаимодействия для CreateTable.xaml
    /// </summary>
    public partial class CreateTable : Window
    {
            ApplicationContext db = new ApplicationContext();
            int number = 0;
            public CreateTable()
            {
                InitializeComponent();
                db.Tables.Load();
            }

            private void Button_Click_Back(object sender, RoutedEventArgs e)
            {
                MenuZal1 menuZal = new MenuZal1();
                menuZal.Show();
                this.Close();
            }
            private void Button_Click_Create(object sender, RoutedEventArgs e)
            {
                if (number > 0)
                {
                    //CreateWaiter createWaiter = new CreateWaiter();
                    //createWaiter.ShowDialog();
                    WpfLibrary1.Model.Table table = new WpfLibrary1.Model.Table { Places = number, Total_cost = 0, Busy = false};
                    db.Tables.Add(table);
                    db.SaveChanges();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Недопустимое количество мест", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            private void Button_Click_Plus(object sender, RoutedEventArgs e)
            {
                number += 1;
                LabelNum.Content = number.ToString();
            }
            private void Button_Click_Minus(object sender, RoutedEventArgs e)
            {
                if (number > 0)
                {
                    number -= 1;
                    LabelNum.Content = number.ToString();
                }
            }
        }
}
