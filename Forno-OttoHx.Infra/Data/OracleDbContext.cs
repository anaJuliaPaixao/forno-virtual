using Forno_OttoHx.Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Forno_OttoHx.Infra.Data
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Forno> Forno { get; set; }

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

    }
}
