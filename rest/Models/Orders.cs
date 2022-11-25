using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int ReservId { get; set; }
        public Reserv Reserv { get; set; }
        public virtual List<DishesOnOrder> Dishes { get; set; }
        public bool Payment { get; set; }
        public double Price { get; set; }
        public int Time { get; set; }
    }
}
