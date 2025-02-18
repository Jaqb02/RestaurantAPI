﻿using System;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        private const string ConnectionString =
            "Server=(localdb)\\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=True";

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired().HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();

            modelBuilder.Entity<Dish>()
                .Property(d => d.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

        }
    }
}