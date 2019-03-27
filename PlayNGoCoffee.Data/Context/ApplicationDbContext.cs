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
        public DbSet<StockDataModel> Stocks { get; set; }
        public DbSet<RecipeIngredientDataModel> RecipeIngredients { get; set; }
        public DbSet<RecipeDataModel> Recipes { get; set; }
        public DbSet<OrderHistoryDataModel> OrderHistories { get; set; }
        #endregion

        #region Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecipeIngredientDataModel>()
                .HasKey(o => new { o.IngredientId, o.RecipeId });

            #region Data Seeding
            modelBuilder.Entity<RecipeDataModel>().HasData(
                new RecipeDataModel { Id = 1, Name = "Double Americano", Description = "Dark af" },
                new RecipeDataModel { Id = 2, Name = "Sweet Latte", Description = "Diabetes" },
                new RecipeDataModel { Id = 3, Name = "Flat White", Description = "Milky" });

            modelBuilder.Entity<IngredientDataModel>().HasData(
                new IngredientDataModel { Id = 1, IngredientName = "Coffee Bean" },
                new IngredientDataModel { Id = 2, IngredientName = "Sugar" },
                new IngredientDataModel { Id = 3, IngredientName = "Milk" });

            modelBuilder.Entity<StockDataModel>().HasData(
                new StockDataModel { Id = 1, IngredientId = 1, Quantity = 45, LocationId = 1 },
                new StockDataModel { Id = 2, IngredientId = 2, Quantity = 45, LocationId = 1 },
                new StockDataModel { Id = 3, IngredientId = 3, Quantity = 45, LocationId = 1 });

            modelBuilder.Entity<LocationDataModel>().HasData(
            new LocationDataModel { Id = 1, LocationName = "Pantry 1", Description = "First Location" });

            modelBuilder.Entity<RecipeIngredientDataModel>().HasData(
              new RecipeIngredientDataModel {  RecipeId = 1, IngredientId = 1, Unit = 3 },

              new RecipeIngredientDataModel {  RecipeId = 2, IngredientId = 1, Unit = 2 },
              new RecipeIngredientDataModel {  RecipeId = 2, IngredientId = 2, Unit = 5 },
              new RecipeIngredientDataModel {  RecipeId = 2, IngredientId = 3, Unit = 3 },

              new RecipeIngredientDataModel {  RecipeId = 3, IngredientId = 1, Unit = 2 },
              new RecipeIngredientDataModel {  RecipeId = 3, IngredientId = 2, Unit = 1 },
              new RecipeIngredientDataModel {  RecipeId = 3, IngredientId = 3, Unit = 4 });
            #endregion
        }
    }
}
