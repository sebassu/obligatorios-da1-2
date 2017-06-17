using Domain;
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
            SetUsersConfiguration(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void SetUsersConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasKey(t => t.Name);
            modelBuilder.Entity<ElementWhiteboard>().Ignore(e => e.Position);
            modelBuilder.Entity<ElementWhiteboard>().Ignore(e => e.Dimensions);
            modelBuilder.Entity<ImageWhiteboard>().Ignore(i => i.ActualImage);
            modelBuilder.Entity<TextBoxWhiteboard>().Ignore(t => t.TextFont);
        }

        internal void DeleteAllData()
        {
            Database.ExecuteSqlCommand("delete from whiteboards");
            Database.ExecuteSqlCommand("delete from teams");
            Database.ExecuteSqlCommand("delete from users");
        }

        internal void RemoveAllUsers()
        {
            Database.ExecuteSqlCommand("delete from Users");
        }

        internal void RemoveAllTeams()
        {
            Database.ExecuteSqlCommand("delete from Teams");
        }

        internal void RemoveAllWhiteboards()
        {
            Database.ExecuteSqlCommand("delete from Whiteboards");
        }
    }
}