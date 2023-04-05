using Microsoft.EntityFrameworkCore;
using Restauran_Manager_WPF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfLibrary1.Model;

namespace WpfLibrary1
{
    /// <summary>
    /// Логика взаимодействия для MenuZal1.xaml
    /// </summary>
    public partial class MenuZal1 : Window
    {
        ApplicationContext db = new ApplicationContext();
        public static WpfLibrary1.Model.Table ItemTable;
        public static List<WpfLibrary1.Model.Table> tables = null;
        public MenuZal1()
        {
            InitializeComponent();
            // гарантируем, что база данных создана
            //db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Tables.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Tables.Local.ToObservableCollection();
            Data_Table.DataContext = db.Tables.Local.ToObservableCollection();
            //Открытие файла с сохранением столов
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_AddTable(object sender, RoutedEventArgs e)
        {
            WpfLibrary1.CreateObject.CreateTable window = new WpfLibrary1.CreateObject.CreateTable();
            window.ShowDialog();
            this.Close();
        }

        private void Button_Click_Dell(object sender, RoutedEventArgs e)
        {
            if (Data_Table.SelectedItem != null)
            {
                ItemTable = Data_Table.SelectedItem as WpfLibrary1.Model.Table;
                WpfLibrary1.CreateObject.DellTable privase = new WpfLibrary1.CreateObject.DellTable();
                privase.ShowDialog();
                this.Close();
            }
            else
            {
                //MessageBox.Show("Элемент для удаления не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
