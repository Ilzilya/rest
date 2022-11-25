using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Ingred> Ingred { get; set; }
        public Unit() { 
        Ingred= new List<Ingred>();
        }
    }
}
