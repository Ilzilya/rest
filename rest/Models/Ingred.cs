using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest.Models
{
    public class Ingred
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int Kkal { get; set; }
        public virtual List<IngredOnDish> Dishes { get; set; }
    }
}
