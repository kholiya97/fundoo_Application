using CommonLayer;
using CommonLayer.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    
   public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany(m => m.Notes)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Users> Users { get; set; }

        public DbSet<Note> Notes { get; set; }
    }
}

