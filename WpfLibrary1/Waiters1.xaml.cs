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

namespace WpfLibrary1
{
    /// <summary>
    /// Логика взаимодействия для Waiters1.xaml
    /// </summary>
    public partial class Waiters1 : Window
    {
        ApplicationContext db= new ApplicationContext();
        public static WpfLibrary1.Model.Waiter ItemWaiter;
        public static List<Waiter> waiters = new List<Waiter> { new WpfLibrary1.Model.Waiter { Id = 1, Name = "Tom", Salary_per_day = 37000, Device_date = new DateTime(2021, 12, 20), Worked_days = 487 }, new WpfLibrary1.Model.Waiter { Id = 2, Name = "Gary", Salary_per_day = 30000, Device_date = new DateTime(2022, 1, 12), Worked_days = 120 }, new WpfLibrary1.Model.Waiter { Id = 3, Name = "Clam", Salary_per_day = 28000, Device_date = new DateTime(2022, 8, 11), Worked_days = 23 } };
        public Waiters1()
        {
            InitializeComponent();
            Data_Waiter.Width = 600;
            Data_Waiter.Height = 400;
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Waiters.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Waiters.Local.ToObservableCollection();
            Data_Waiter.DataContext = db.Waiters.Local.ToObservableCollection();
            //Data_Dish.DataContext = db.Dishes.Local.ToObservableCollection();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            //MainWindow1 window = new MainWindow1();
            //window.Show();
            this.Close();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            WpfLibrary1.CreateObject.CreateWaiter createWaiter = new WpfLibrary1.CreateObject.CreateWaiter();
            createWaiter.ShowDialog();
            this.Close();
        }

        private void Button_Click_Dell(object sender, RoutedEventArgs e)
        {
            if (Data_Waiter.SelectedItem != null)
            {
                ItemWaiter = Data_Waiter.SelectedItem as WpfLibrary1.Model.Waiter;
                WpfLibrary1.RedZakaz_Bluda.DellWaiter privase = new WpfLibrary1.RedZakaz_Bluda.DellWaiter();
                privase.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Элемент для удаления не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
