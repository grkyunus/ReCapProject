using Core.Entities.Concrete;
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
            optionsBuilder.UseSqlServer(@"Server=COMPUTER1\SQLEXPRESS;Database=ReCapProject;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<Brand> Rcp_Brand { get; set; }
        public DbSet<Color> Rcp_Color { get; set; }
        public DbSet<Car> Rcp_Car { get; set; }
        public DbSet<User> Rcp_Users { get; set; }
        public DbSet<Customer> Rcp_Customers { get; set; }
        public DbSet<Rental> Rcp_Rentals { get; set; }
        public DbSet<Image> Rcp_Images { get; set; }
        public DbSet<OperationClaim> Rcp_OperationClaims { get; set; }
        public DbSet<UserOperationClaim> Rcp_UserOperationClaims { get; set; }


    }
}
