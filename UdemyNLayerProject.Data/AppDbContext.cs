using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Entities;
using UdemyNLayerProject.Data.Configurations;

namespace UdemyNLayerProject.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
        {
        }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Burayı temiz tutmak adına configuration'lar ayrı dosyada tutuldu 
            //örn: modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
