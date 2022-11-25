using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int Сapacity { get; set; }
        public virtual List<Reserv> Reserv { get; set; }
    }
}
