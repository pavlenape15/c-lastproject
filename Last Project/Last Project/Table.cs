using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Project
{
    public class Table
    {
        public int TableId { get; set; }
        public string placed { get; set; }
        public bool freeTable { get; set; }
        public List<Food> orderedFood = new List<Food>();
    }
}
