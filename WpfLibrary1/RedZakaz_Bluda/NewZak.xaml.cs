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
using WpfLibrary1.Model;

namespace WpfLibrary1.RedZakaz_Bluda
{
    /// <summary>
    /// Логика взаимодействия для NewZak.xaml
    /// </summary>
    public partial class NewZak : Window
    {
        List<WpfLibrary1.Model.Dish> dish = new List<WpfLibrary1.Model.Dish>();
        ApplicationContext db = new ApplicationContext();
        int i=0;
        public NewZak()
        {
            InitializeComponent();
            db.Waiters.Load();
            db.Dishes.Load();
            db.ListDish.Load();
            ComBox_Waiters.ItemsSource = db.Waiters.Local.ToBindingList();
            ComBox_Waiters.DisplayMemberPath = "Name";
            ComBox_Dish.ItemsSource = db.Dishes.Local.ToBindingList();
            ComBox_Dish.DisplayMemberPath = "Name";
            for (int i = 0; i <= 1; i++)
            {
                CreateTable(i);
            }
        }
        public void CreateTable(int i)
        {
            var column = new DataGridTextColumn();
            switch (i)
            {
                case 0:
                    column.Header = "Название";
                    column.Binding = new Binding("Name");
                    Data_Zakaz.Columns.Add(column);
                    break;
                case 1:
                    column.Header = "Стоимость";
                    column.Binding = new Binding("Cost");
                    Data_Zakaz.Columns.Add(column);
                    break;
            }
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            RedZakaz1 window = new RedZakaz1();
            window.Show();
            this.Close();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if (ComBox_Dish.SelectedItem != null)
            {
                Data_Zakaz.Items.Add(ComBox_Dish.SelectedItem);
                dish.Add((WpfLibrary1.Model.Dish)ComBox_Dish.SelectedItem);
                ComBox_Dish.SelectedItem = null;
            }
        }

        private void Button_Click_Dell(object sender, RoutedEventArgs e)
        {
            if (Data_Zakaz.SelectedItem != null)
            {
                Data_Zakaz.Items.Remove(Data_Zakaz.SelectedItem);
                dish.Remove((WpfLibrary1.Model.Dish)ComBox_Dish.SelectedItem);
                Data_Zakaz.SelectedItem = null;
            }
        }

        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            if (ComBox_Waiters.SelectedItem != null && Data_Zakaz.Items.Count > 0)
            {
                WpfLibrary1.Model.Table table = db.Tables.Find(RedZakaz1.index);
                WpfLibrary1.Model.Waiter waitRe = ComBox_Waiters.SelectedItem as WpfLibrary1.Model.Waiter;
                WpfLibrary1.Model.Waiter wait = db.Waiters.Find(waitRe.Id);
                table.Busy = true;
                //table.Order = dish;
                for(int i=0;i<dish.Count() ; i++)
                {
                    WpfLibrary1.Model.LiDish liDish = new LiDish {ID_Table = RedZakaz1.index, ID_Dish = dish[i].Id };
                    db.ListDish.Add(liDish);
                    WpfLibrary1.Model.Dish dd= db.Dishes.Find(liDish.ID_Dish);
                    table.Total_cost +=dd.Cost;
                }
                WpfLibrary1.Model.Waiter ww = (WpfLibrary1.Model.Waiter)ComBox_Waiters.SelectedItem;
                table.ID_Waiter = ww.Id;
                wait.Worked_days += 1;
                db.SaveChanges();
                this.Close();
            }
        }
    }
}
