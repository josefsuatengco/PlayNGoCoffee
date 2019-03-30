using Microsoft.EntityFrameworkCore;
using PlayNGoCoffee.Business.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayNGoCoffee
{
    public class CoffeeService : ICoffeeService
    {
        #region Protected Members
        /// <summary>
        /// Scoped application context
        /// </summary>
        protected ApplicationDbContext context;
        #endregion

        public CoffeeService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<RecipeIngredientDataModel> GetAllIngredients()
        {
            return context.RecipeIngredients.Include(s => s.Ingredient).Include(a => a.Recipe);
        }

        public IEnumerable<RecipeIngredientDataModel> GetIngredientsByRecipeId(int recipeId)
        {
            return context.RecipeIngredients.Include(a => a.Recipe).Include(s => s.Ingredient).Where(x => x.RecipeId == recipeId);
        }

        public IEnumerable<RecipeDataModel> GetRecipes()
        {
            return context.Recipes;
        }

        public IEnumerable<LocationDataModel> GetLocations()
        {
            return context.Locations;
        }

        public IEnumerable<StockDataModel> GetStockByLocationId(int locationId)
        {
            return context.Stocks.Include(s => s.Ingredient).Where(a => a.LocationId == locationId);
        }

        public IEnumerable<OrderHistoryDataModel> GetHistory()
        {
            return context.OrderHistories.Include(s => s.Recipe);
        }

        public void UpdateStock(IEnumerable<StockDataModel> updatedStocks, int recipeId)
        {
            int locationId = updatedStocks.FirstOrDefault().LocationId;
            var originalStock = context.Stocks.Where(a => a.LocationId == locationId);
            OrderHistoryDataModel history = new OrderHistoryDataModel();

            if (originalStock != null && updatedStocks != null)
            {
                foreach (var updatedStock in updatedStocks)
                {
                    originalStock.Where(x => x.IngredientId == updatedStock.IngredientId).FirstOrDefault().Unit = updatedStock.Unit;
                }

                history.DateOrdered = DateTime.Now;
                history.Quantity = 1;
                history.RecipeId = recipeId;

                AddHistory(history);
                context.SaveChanges();
            }
        }

        private void AddHistory(OrderHistoryDataModel history)
        {
            if (history != null)
            {
                context.OrderHistories.Add(history);
            }
        }
    }
}