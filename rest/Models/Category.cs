using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Dish> Dish { get; set; }
        public Category() { Dish = new List<Dish>(); }

    }
}
