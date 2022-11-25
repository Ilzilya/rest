using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rest.Models;

namespace rest.Data
{
    public class restContext : DbContext
    {
        public restContext (DbContextOptions<restContext> options)
            : base(options)
        {
        }
        public DbSet<rest.Models.Dish> Dishes { get; set; }
        public DbSet<rest.Models.Category> Categories { get; set; }
        public DbSet<rest.Models.Guest> Guests { get; set; }
        public DbSet<rest.Models.Ingred> Ingreds { get; set; }
        public DbSet<rest.Models.Orders> Orders { get; set; }
        public DbSet<rest.Models.Reserv> Reservs { get; set; }
        public DbSet<rest.Models.Status> Statuses { get; set; }
        public DbSet<rest.Models.Table> Tables { get; set; }
        public DbSet<rest.Models.Unit> Units { get; set; } 
        public DbSet<rest.Models.DishesOnOrder> DishesOnOrder { get; set; }
        public DbSet<rest.Models.IngredOnDish> IngredOnDish { get; set; }
    }
}
