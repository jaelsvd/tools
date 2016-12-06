using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mappings
{
    /// <summary>
    /// Class to make mapping about benefits table at database
    /// </summary>
    internal class BenefitMapping
    {
        #region variables
        /// <summary>
        /// Instance Members
        /// </summary>
        DbModelBuilder modelBuilder;
        #endregion

        #region constructor
        /// <summary>
        /// constructor that assigns the value to modelBuilder instance to make mapping 
        /// </summary>
        public BenefitMapping(DbModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
            this.modelBuilder.Entity<Benefit>()
            .Property(x => x.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
        #endregion

    }
}
