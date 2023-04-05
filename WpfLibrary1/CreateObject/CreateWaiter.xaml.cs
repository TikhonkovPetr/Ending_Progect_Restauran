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

namespace WpfLibrary1.CreateObject
{
    /// <summary>
    /// Логика взаимодействия для CreateWaiter.xaml
    /// </summary>
    public partial class CreateWaiter : Window
    {
        ApplicationContext db=new ApplicationContext();
        public static Waiter ww;
        public CreateWaiter()
        {
            InitializeComponent();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if (TextName.Text != "" && Convert.ToInt32(TextSalary.Text) > 0 && Picker != null)
            {
                WpfLibrary1.Model.Waiter waiter = new WpfLibrary1.Model.Waiter { Salary_per_day = Convert.ToInt32(TextSalary.Text), Name = TextName.Text, Worked_days = 0, Device_date = (DateTime)Picker.SelectedDate };
                ww = waiter;
                db.Waiters.Add(waiter);
                db.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Не все данные указаны", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
