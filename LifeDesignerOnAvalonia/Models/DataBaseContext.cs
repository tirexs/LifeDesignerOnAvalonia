﻿using Microsoft.EntityFrameworkCore;


namespace LifeDesignerOnAvalonia.Models
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=life_designer;Username=postgres;Password=22848");
        }



        public DbSet<Category> Categorys { get; set; }
        public DbSet<Data> datas { get; set; }
        public DbSet<UserLogin> userLogins { get; set; }

        

    }
}
