﻿using Domain;
using System.Data.Entity;

namespace Persistence
{
    public class BoardContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Whiteboard> Whiteboards { get; set; }
        public DbSet<ElementWhiteboard> Elements { get; set; }

        public BoardContext() : base()
        {
            var defaultInitializer = new DropCreateDatabaseIfModelChanges<BoardContext>();
            Database.SetInitializer(defaultInitializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SetUsersConfiguration(modelBuilder);
        }

        private static void SetUsersConfiguration(DbModelBuilder modelBuilder)
        {
            IgnoresForEntities(modelBuilder);
            modelBuilder.Entity<Team>().HasMany(t => t.Members).WithMany(u => u.AssociatedTeams);
            modelBuilder.Entity<Whiteboard>().HasRequired(w => w.OwnerTeam).WithMany(t => t.CreatedWhiteboards);
            modelBuilder.Entity<Whiteboard>().HasOptional(w => w.Creator);
            modelBuilder.Entity<Whiteboard>().HasMany(w => w.Contents).WithRequired(e => e.Container);
            modelBuilder.Entity<Comment>().HasRequired(c => c.Creator).WithMany(u => u.CommentsCreated);
            modelBuilder.Entity<Comment>().HasOptional(c => c.Resolver).WithMany(u => u.CommentsResolved);
            modelBuilder.Entity<Comment>().HasRequired(c => c.AssociatedElement).WithMany(e => e.Comments);
        }

        private static void IgnoresForEntities(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElementWhiteboard>().Ignore(e => e.Position);
            modelBuilder.Entity<ElementWhiteboard>().Ignore(e => e.Dimensions);
            modelBuilder.Entity<ImageWhiteboard>().Ignore(i => i.ActualImage);
            modelBuilder.Entity<TextBoxWhiteboard>().Ignore(t => t.TextFont);
            modelBuilder.Entity<Comment>().Ignore(c => c.AssociatedWhiteboard);
        }

        internal void DeleteAllData()
        {
            Database.ExecuteSqlCommand("delete from whiteboards");
            Database.ExecuteSqlCommand("delete from teams");
            Database.ExecuteSqlCommand("delete from users");
        }
    }
}