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
                new RecipeDataModel { Id = 1, Name = "Double Americano", Description = "Will use 3 Coffee Beans" },
                new RecipeDataModel { Id = 2, Name = "Sweet Latte", Description = "Will use 2 Coffee Beans, 5 Sugar and 3 Milk" },
                new RecipeDataModel { Id = 3, Name = "Flat White", Description = "Will use 2 Coffee Beans, 1 Sugar and 4 Milk" });

            modelBuilder.Entity<IngredientDataModel>().HasData(
                new IngredientDataModel { Id = 1, IngredientName = "Coffee Bean" },
                new IngredientDataModel { Id = 2, IngredientName = "Sugar" },
                new IngredientDataModel { Id = 3, IngredientName = "Milk" });

            modelBuilder.Entity<StockDataModel>().HasData(
                new StockDataModel { Id = 1, IngredientId = 1, Unit = 45, LocationId = 1 },
                new StockDataModel { Id = 2, IngredientId = 2, Unit = 45, LocationId = 1 },
                new StockDataModel { Id = 3, IngredientId = 3, Unit = 45, LocationId = 1 },
                new StockDataModel { Id = 4, IngredientId = 1, Unit = 0, LocationId = 2 },
                new StockDataModel { Id = 5, IngredientId = 2, Unit = 0, LocationId = 2 },
                new StockDataModel { Id = 6, IngredientId = 3, Unit = 0, LocationId = 2 });

            modelBuilder.Entity<LocationDataModel>().HasData(
            new LocationDataModel { Id = 1, LocationName = "Pantry 1", Description = "First Location" },
            new LocationDataModel { Id = 2, LocationName = "Pantry 2", Description = "Second Location" });

            modelBuilder.Entity<RecipeIngredientDataModel>().HasData(
              new RecipeIngredientDataModel { RecipeId = 1, IngredientId = 1, Unit = 3 },

              new RecipeIngredientDataModel { RecipeId = 2, IngredientId = 1, Unit = 2 },
              new RecipeIngredientDataModel { RecipeId = 2, IngredientId = 2, Unit = 5 },
              new RecipeIngredientDataModel { RecipeId = 2, IngredientId = 3, Unit = 3 },

              new RecipeIngredientDataModel { RecipeId = 3, IngredientId = 1, Unit = 2 },
              new RecipeIngredientDataModel { RecipeId = 3, IngredientId = 2, Unit = 1 },
              new RecipeIngredientDataModel { RecipeId = 3, IngredientId = 3, Unit = 4 });

            modelBuilder.Entity<OrderHistoryDataModel>().HasData(
            new OrderHistoryDataModel { Id = 1, RecipeId = 1, DateOrdered = DateTime.Now, Quantity = 1 },
            new OrderHistoryDataModel { Id = 2, RecipeId = 3, DateOrdered = DateTime.Now, Quantity = 1 });
            #endregion
        }
    }
}
