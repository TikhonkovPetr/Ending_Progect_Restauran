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
    /// Логика взаимодействия для ClearTable.xaml
    /// </summary>
    public partial class ClearTable : Window
    {
        ApplicationContext db = new ApplicationContext();
        public ClearTable()
        {
            InitializeComponent();
            db.ListDish.Load();
            db.Tables.Load();
        }

        private void Button_Yes(object sender, RoutedEventArgs e)
        {
            //MenuZal1.tables[RedZakaz1.reserw].Order = new List<WpfLibrary1.Model.Dish>();
            //MenuZal1.tables[RedZakaz1.reserw].Busy = false;
            WpfLibrary1.Model.Table table= db.Tables.Find(RedZakaz1.reserw);//(List<WpfLibrary1.Model.LiDish>)db.ListDish.Where(i=>i.ID_Table==RedZakaz1.reserw);
            List<WpfLibrary1.Model.LiDish> liDish = db.ListDish.ToList();
            foreach (WpfLibrary1.Model.LiDish d in liDish)
            {
                if(d.ID_Table==RedZakaz1.reserw)
                {
                    db.ListDish.Remove(d);
                }
            }
            table.ID_Waiter = null;
            table.Busy = false;
            table.Total_cost = 0;
            db.SaveChanges();
            this.Close();
        }

        private void Button_No(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
