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
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace WpfLibrary1
{
    /// <summary>
    /// Логика взаимодействия для MenuBlud1.xaml
    /// </summary>
    public partial class MenuBlud1 : Window
    {
        public static WpfLibrary1.Model.Dish ItemDish;
        ApplicationContext db = new ApplicationContext();
        public static List<WpfLibrary1.Model.Dish> Dishes = null;
        public MenuBlud1()
        {
            InitializeComponent();
            // гарантируем, что база данных создана
            //db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Dishes.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Dishes.Local.ToObservableCollection();
            //Data_Dish.DataContext = db.Dishes.Local.ToObservableCollection();
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            WpfLibrary1.CreateObject.CreateBludo createBludo = new WpfLibrary1.CreateObject.CreateBludo();
            createBludo.ShowDialog();
            this.Close();
        }

        private void Button_Click_Dell(object sender, RoutedEventArgs e)
        {
            if (Data_Dish.SelectedItem != null)
            {
                ItemDish = Data_Dish.SelectedItem as WpfLibrary1.Model.Dish;
                WpfLibrary1.CreateObject.Privase privase = new WpfLibrary1.CreateObject.Privase();
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
