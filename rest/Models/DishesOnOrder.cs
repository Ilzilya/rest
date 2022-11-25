using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest.Models
{
    public class DishesOnOrder
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int Count { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int OrderId { get; set; }
        public Orders Orders { get; set; }
    }
}
