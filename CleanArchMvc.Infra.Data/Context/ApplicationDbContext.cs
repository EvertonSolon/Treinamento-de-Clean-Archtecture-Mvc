using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Infra.Data.EntitiesConfiguration;
using CleanArchMvc.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //Para configuração do Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //A linha abaixo é uma configuração para evitar declarações das confiurações 
            //das entidades uma a uma.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            //Ex: 
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}


