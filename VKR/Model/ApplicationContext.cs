using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKR.ViewModel;

namespace VKR.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<insurance> insurances { get; set; }
        public DbSet<InsuranceCase> insuranceCases { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=VKR.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
