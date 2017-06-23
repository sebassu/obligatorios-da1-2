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
        public DbSet<ScoringManager> GlobalScores { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MemberScoring> Scores { get; set; }
        public DbSet<Connection> Connections { get; set; }

        public BoardContext() : base()
        {
            var defaultInitializer = new DropCreateDatabaseIfModelChanges<BoardContext>();
            Database.SetInitializer(defaultInitializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Configuration.LazyLoadingEnabled = false;
            SetUsersConfiguration(modelBuilder);
        }

        private static void SetUsersConfiguration(DbModelBuilder modelBuilder)
        {
            IgnoresForEntities(modelBuilder);
            modelBuilder.Entity<Team>().HasMany(t => t.Members).WithMany(u => u.AssociatedTeams);
            modelBuilder.Entity<Whiteboard>().HasRequired(w => w.OwnerTeam).WithMany(t => t.CreatedWhiteboards);
            modelBuilder.Entity<Whiteboard>().HasMany(w => w.Contents).WithRequired(e => e.Container);
            modelBuilder.Entity<Comment>().HasRequired(c => c.AssociatedElement).WithMany(e => e.Comments);
           /* modelBuilder.Entity<Connection>().HasRequired(c => c.Origin);
            modelBuilder.Entity<Connection>().HasRequired(c => c.Destination);*/
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
            Database.ExecuteSqlCommand("delete from memberscorings");
            Database.ExecuteSqlCommand("delete from comments");
            Database.ExecuteSqlCommand("delete from elementwhiteboards");
            Database.ExecuteSqlCommand("delete from whiteboards");
            Database.ExecuteSqlCommand("delete from teams");
            Database.ExecuteSqlCommand("delete from users");
        }
    }
}