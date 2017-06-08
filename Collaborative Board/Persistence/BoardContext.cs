using Domain;
using System.Data.Entity;

namespace Persistence
{
    public class BoardContext : DbContext
    {
        public DbSet<UserDataEntityFramework> Users { get; set; }
        /*public DbSet<Team> Teams { get; set; }
        public DbSet<Whiteboard> Whiteboards { get; set; }
        public DbSet<ElementWhiteboard> Elements { get; set; }*/

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
            modelBuilder.Entity<UserDataEntityFramework>().HasKey(u => u.Email);
        }
    }
}