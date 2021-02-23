using Microsoft.EntityFrameworkCore;
using Natro_Backend.Entity.Entities;
using Natro_Backend.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Entity.Context
{
    public class MssqlContext : DbContext
    {
        public MssqlContext(DbContextOptions<MssqlContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserFavoriteEntity> UserFavorites { get; set; }
        public DbSet<UserFavoriteNotificationEntity> UserFavoriteNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityMap());
            modelBuilder.ApplyConfiguration(new UserFavoriteEntityMap());
            modelBuilder.ApplyConfiguration(new UserFavoriteNotificationEntityMap());
        }

    }
}
