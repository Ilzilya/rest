using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest.Models
{
    public class Reserv
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int CountPerson { get; set; }
        public string Notes { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public Orders Orders { get; set; }
    }
}
