using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mappings
{
    public class NewsMapping
    {
        DbModelBuilder modelBuilder;
        public NewsMapping(DbModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
            this.modelBuilder.Entity<News>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
