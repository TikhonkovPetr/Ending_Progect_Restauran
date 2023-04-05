using Restauran_Manager_WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary1.Model
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
    }
    public class Table
    {
        public int Id { get; set; }
        public int Places { get; set; }
        public int Total_cost { get; set; }//??
        //public List<Dish>? Order { get; set; }
        public bool Busy { get; set; }
        //public Waiter? waiter { get; set; }
        public int? ID_Waiter { get; set; }
    }
    public class LiDish
    {
        public int Id { get; set; }
        public int ID_Table { get; set; }
        public int ID_Dish { get; set; }
    }
    public class Waiter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Salary_per_day { get; set; }
        public DateTime Device_date { get; set; }
        public int Worked_days { get; set; }
    }
}