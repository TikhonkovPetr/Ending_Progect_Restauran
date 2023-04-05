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
    /// Логика взаимодействия для DellBludo.xaml
    /// </summary>
    public partial class DellBludo : Window
    {
        ApplicationContext db = new ApplicationContext();
        public DellBludo()
        {
            InitializeComponent();
            db.Tables.Load();
            db.ListDish.Load();
            for (int i = 0; i <= 1; i++)
            {
                CreateTable(i);
            }
            WpfLibrary1.Model.Table table= db.Tables.Find(RedZakaz1.reserw);
            //if (table.Order != null)
            //{
            //    for (int i = 0; i < table.Order.Count(); i++)
            //    {
            //        Data_Blud_Table.Items.Add(table.Order[i]);
            //    }
            //    Data_Blud_Table.ItemsSource = table.Order;
            //}(List<WpfLibrary1.Model.LiDish>)db.ListDish.Where(i => i.ID_Table == RedZakaz1.reserw);
            List<WpfLibrary1.Model.LiDish> liDishes = db.ListDish.ToList();
            if (liDishes.Count() > 0)
            {
                foreach (WpfLibrary1.Model.LiDish d in liDishes)
                {
                    if(d.ID_Table==RedZakaz1.reserw)
                    {
                        WpfLibrary1.Model.Dish liD= db.Dishes.Find(d.ID_Dish);
                        Data_Blud_Table.Items.Add(liD);
                    }
                }
                //for (int i = 0; i < liDishes.Count(); i++)
                //{
                //    int o = liDishes[i].ID_Table;
                //    WpfLibrary1.Model.Dish di = db.Dishes.Where(i => i.Id == o).FirstOrDefault();
                //    Data_Blud_Table.Items.Add(di);
                //}
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
                    Data_Blud_Table.Columns.Add(column);
                    break;
                case 1:
                    column.Header = "Стоимость";
                    column.Binding = new Binding("Cost");
                    Data_Blud_Table.Columns.Add(column);
                    break;
            }
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            RedZakaz1 redZakaz = new RedZakaz1();
            redZakaz.Show();
            this.Close();
        }

        private void Button_Click_Dell(object sender, RoutedEventArgs e)
        {
            if (Data_Blud_Table.SelectedItem != null)
            {
                //WpfLibrary1.Model.Table table = db.Tables.Find(RedZakaz1.reserw);
                //table.Order.Remove((WpfLibrary1.Model.Dish)Data_Blud_Table.SelectedItem);
                WpfLibrary1.Model.Dish di = (WpfLibrary1.Model.Dish)Data_Blud_Table.SelectedItem;
                //List<WpfLibrary1.Model.LiDish> liDishes = (List<WpfLibrary1.Model.LiDish>)db.ListDish.Where(i => i.ID_Table == RedZakaz1.reserw);
                List<WpfLibrary1.Model.LiDish> liDish = db.ListDish.ToList();
                foreach (WpfLibrary1.Model.LiDish d in liDish)
                {
                    if (d.ID_Table == RedZakaz1.reserw && d.ID_Dish==di.Id)
                    {
                        db.ListDish.Remove(d);
                        break;
                    }
                }
                WpfLibrary1.Model.Table table = db.Tables.Find(RedZakaz1.reserw);
                //table = db.Tables.FirstOrDefault(u=>u.Id == RedZakaz1.reserw);
                //table.Order.Add(dish);
                table.Total_cost -= di.Cost;
                //for (int i= 0;i< liDishes.Count(); i++)
                //{
                //    if (liDishes[i].ID_Dish== di.Id)
                //    {
                //        db.ListDish.Remove(liDishes[i]);
                //        i += liDishes.Count();
                //    }
                //}
                db.SaveChanges();
                //MenuZal1.tables[RedZakaz1.reserw].Order.Remove((WpfLibrary1.Model.Dish)Data_Blud_Table.SelectedItem);
                RedZakaz1 redZakaz = new RedZakaz1();
                redZakaz.Show();
                this.Close();
            }
        }
    }
}
