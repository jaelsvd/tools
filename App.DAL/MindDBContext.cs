using App.Entities;
using System.Data.Entity;

namespace App.DAL
{
    /// <summary>
    /// This class definds the DataBase
    /// </summary>
    public class MindDBContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public MindDBContext() : base("MindDbConnName")
        {

        }
        /// <summary>
        /// Benefits table definition in DB
        /// </summary>
        public DbSet<Benefit> Benefits { get; set; }
        /// <summary>
        /// News table definition in DB
        /// </summary>
        public DbSet<News> News { get; set; }
        /// <summary>
        /// Links table definition in DB
        /// </summary>
        public DbSet<Link> Links { get; set; }
        /// <summary>
        /// Policy table definition in DB
        /// </summary>
        public DbSet<Policy> Policy { get; set; }
        /// <summary>
        /// Event Category table definition in DB
        /// </summary>
        public DbSet<EventCategory> EventCategories { get; set; }
        /// <summary>
        /// Events table definition in DB
        /// </summary>
        public DbSet<Event> Events { get; set; }
    }
}