using Microsoft.EntityFrameworkCore;
using System;

namespace PlayNGoCoffee
{
    /// <summary>
    /// Db representation model
    /// </summary>
    public class ApplicationDbContext : DbContext
    { 
        #region Public Properties        
        /// <summary>
        /// Setup table models
        /// </summary>
        public DbSet<LocationDataModel> Locations { get; set; }
        public DbSet<IngredientDataModel> Ingredients { get; set; }
        public DbSet<RecipeDataModel> Recipes { get; set; }
        public DbSet<CoffeeDataModel> Coffee { get; set; }
        #endregion

        #region Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CoffeeDataModel>().HasIndex(a => a.CoffeeName);
            modelBuilder.Entity<IngredientDataModel>().HasIndex(a => a.IngredientName);
        }
    }
}
