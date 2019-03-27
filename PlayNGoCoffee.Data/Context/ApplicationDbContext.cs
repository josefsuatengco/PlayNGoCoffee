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
        public DbSet<OrderHistoryDataModel> OrderHistory { get; set; }
        #endregion

        #region Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Data Seeding
            modelBuilder.Entity<CoffeeDataModel>().HasData(
                new CoffeeDataModel { Id = 1, CoffeeName = "Double Americano", Description = "Dark af" },
                new CoffeeDataModel { Id = 2, CoffeeName = "Sweet Latte", Description = "Diabetes" },
                new CoffeeDataModel { Id = 3, CoffeeName = "Flat White", Description = "Milky" });

            modelBuilder.Entity<IngredientDataModel>().HasData(
                new IngredientDataModel { Id = 1, CoffeeBeanStock = 45, MilkStock = 45, SugarStock = 45, LocationId = 1 });

            modelBuilder.Entity<LocationDataModel>().HasData(
            new LocationDataModel { Id = 1, LocationName = "Pantry 1", Description = "First Location" });

            modelBuilder.Entity<RecipeDataModel>().HasData(
               new RecipeDataModel { Id = 1, CoffeeId = 1, CoffeeBeanAmount = 3, SugarAmount = 0, MilkAmount = 0 },
               new RecipeDataModel { Id = 2, CoffeeId = 2, CoffeeBeanAmount = 2, SugarAmount = 5, MilkAmount = 3 },
               new RecipeDataModel { Id = 3, CoffeeId = 3, CoffeeBeanAmount = 2, SugarAmount = 1, MilkAmount = 4 });

            #endregion
        }
    }
}
