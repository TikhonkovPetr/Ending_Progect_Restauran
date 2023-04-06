using Microsoft.EntityFrameworkCore;
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

namespace WpfLibrary1
{
    /// <summary>
    /// Логика взаимодействия для RedZakaz1.xaml
    /// </summary>
    public partial class RedZakaz1 : Window
    {
        ApplicationContext db = new ApplicationContext();
        public static int reserw;
        public static bool prow = false;
        public static int index;
        public static WpfLibrary1.Model.Table tb;
        public RedZakaz1()
        {
            InitializeComponent();
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Tables.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Tables.Local.ToObservableCollection();
            List_Table.DataContext = db.Tables.Local.ToObservableCollection();
            //List_Table.ItemsSource = MenuZal1.tables;
            //List_Table.DisplayMemberPath = "Id";
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
            //MainWindow1 window = new MainWindow1();
            //window.Show();
            this.Close();
        }
        private void Select_Table(object sender, SelectionChangedEventArgs e)
        {
            Data_Zakaz.Items.Clear();
            //MenuZal1.tables[List_Table.SelectedIndex].Order.Count()
            using (ApplicationContext db = new ApplicationContext())
            {
                tb = List_Table.SelectedItem as WpfLibrary1.Model.Table;
                reserw = tb.Id;
                WpfLibrary1.Model.Table tables = db.Tables.Find(reserw);
                //db.ListDish.Where(i=>i.ID_Table==reserw);
                List<WpfLibrary1.Model.LiDish> liDishes = db.ListDish.ToList();
                if (liDishes.Count()>0)
                {
                    foreach (WpfLibrary1.Model.LiDish d in liDishes)
                    {
                        if(d.ID_Table==reserw)
                        {
                            //int o = liDishes[i].ID_Table;
                            //WpfLibrary1.Model.Dish di = db.Dishes.Where(i => i.Id == o).FirstOrDefault();
                            WpfLibrary1.Model.Dish liD = db.Dishes.Find(d.ID_Dish);
                            Data_Zakaz.Items.Add(liD);
                        }
                    }
                }
            }
            //for (int i = 0; i < db.Tables.; i++)
            //{
            //    Data_Zakaz.Items.Add(MenuZal1.tables[List_Table.SelectedIndex].Order[i]);
            //    summ += MenuZal1.tables[List_Table.SelectedIndex].Order[i].Cost;
            //}
            //if (MenuZal1.tables[List_Table.SelectedIndex].Order.Count() != 0)
            //{
            //    MenuZal1.tables[List_Table.SelectedIndex].Busy = true;
            //}
            //Table.Content = "Заказ столика " + (List_Table.SelectedIndex + 1).ToString();
            WpfLibrary1.Model.Table t = db.Tables.Find(reserw);
            Rub.Content = t.Total_cost.ToString() + " рублей";
            //MenuZal1.tables[List_Table.SelectedIndex].Total_cost = summ;
            prow = true;
        }
        private void Button_Click_Dell(object sender, RoutedEventArgs e)
        {
            if (prow)
            {
                WpfLibrary1.RedZakaz_Bluda.DellBludo window = new WpfLibrary1.RedZakaz_Bluda.DellBludo();
                window.Show();
                this.Close();
            }
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if (prow) //&& db.Tables.Find(reserw).Busy
            {
                WpfLibrary1.RedZakaz_Bluda.AddBludo window = new WpfLibrary1.RedZakaz_Bluda.AddBludo();
                window.Show();
                this.Close();
            }
        }

        private void Button_Click_Creal(object sender, RoutedEventArgs e)
        {
            if (prow)
            {
                Data_Zakaz.Items.Clear();
                prow = false;
                WpfLibrary1.RedZakaz_Bluda.ClearTable clearTable = new WpfLibrary1.RedZakaz_Bluda.ClearTable();
                clearTable.ShowDialog();
            }
            this.Close();
        }

        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            if (prow)
            {
                WpfLibrary1.Model.Table tables = db.Tables.Find(tb.Id);
                if (!tables.Busy)
                {
                    WpfLibrary1.RedZakaz_Bluda.NewZak newZak = new WpfLibrary1.RedZakaz_Bluda.NewZak();
                    index = tables.Id;
                    newZak.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Столик занят", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Столик не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
