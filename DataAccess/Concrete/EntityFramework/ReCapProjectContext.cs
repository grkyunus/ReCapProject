using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-T6AMAA9\SQLEXPRESS;Database=ReCapProject;Trusted_Connection=true");
        }

        public DbSet<Brand> Rcp_Brand { get; set; }
        public DbSet<Color> Rcp_Color { get; set; }
        public DbSet<Car> Rcp_Car { get; set; }


    }
}
