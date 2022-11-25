using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<DishesOnOrder> DishOnOrders { get; set; }
    }
}
