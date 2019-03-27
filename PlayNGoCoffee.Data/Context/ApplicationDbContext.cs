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

            #region Data Seeding
            modelBuilder.Entity<CoffeeDataModel>().HasData(
                new CoffeeDataModel { Id = 1, CoffeeName = "Double Americano", Description = "Dark af" },
                new CoffeeDataModel { Id = 2, CoffeeName = "Sweet Latte", Description = "Diabetes" },
                new CoffeeDataModel { Id = 3, CoffeeName = "Flat White", Description = "Milky" });

            modelBuilder.Entity<IngredientDataModel>().HasData(
                new IngredientDataModel { Id = 1, IngredientName = "CoffeeBeans", Stock = 15, LocationId = 1 },
                new IngredientDataModel { Id = 2, IngredientName = "Sugar", Stock = 15, LocationId = 1 },
                new IngredientDataModel { Id = 3, IngredientName = "Milk", Stock = 15, LocationId = 1 });

            modelBuilder.Entity<LocationDataModel>().HasData(
            new LocationDataModel { Id = 1, LocationName = "Pantry 1", Description = "First Location" });
            
            modelBuilder.Entity<RecipeDataModel>().HasData(
               new RecipeDataModel { Id = 1, CoffeeId = 1, IngredientId = 1, Amount = 3 },
               new RecipeDataModel { Id = 2, CoffeeId = 1, IngredientId = 2, Amount = 0 },
               new RecipeDataModel { Id = 3, CoffeeId = 1, IngredientId = 3, Amount = 0 },
               new RecipeDataModel { Id = 4, CoffeeId = 2, IngredientId = 1, Amount = 2 },
               new RecipeDataModel { Id = 5, CoffeeId = 2, IngredientId = 2, Amount = 5 },
               new RecipeDataModel { Id = 6, CoffeeId = 2, IngredientId = 3, Amount = 3 },
               new RecipeDataModel { Id = 7, CoffeeId = 3, IngredientId = 1, Amount = 2 },
               new RecipeDataModel { Id = 8, CoffeeId = 3, IngredientId = 2, Amount = 1 },
               new RecipeDataModel { Id = 9, CoffeeId = 3, IngredientId = 3, Amount = 4 });

            #endregion
        }
    }
}
