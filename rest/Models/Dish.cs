using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Kkal { get; set; }
        public string Cook_tech { get; set; }
        public double Price { get; set; }
        public bool Menu { get; set; }
        public string Img { get; set; }
        public string Portion { get; set; }
        public double Weight { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual List<IngredOnDish> Ingreds { get; set; }
        public virtual List<DishesOnOrder> Orders { get; set; }
        public Dish() { }
    }
}
