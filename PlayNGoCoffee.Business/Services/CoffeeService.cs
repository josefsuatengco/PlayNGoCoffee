using Microsoft.EntityFrameworkCore;
using PlayNGoCoffee.Business.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        
        public IEnumerable<RecipeIngredientDataModel> GetIngredientsByRecipeId(int recipeId)
        {
            return context.RecipeIngredients.Where(x => x.RecipeId == recipeId);
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
            return context.Stocks.Where(x => x.LocationId == locationId);
        }

        public void AddHistory(OrderHistoryDataModel history)
        {
            if (history != null)
            {
                context.OrderHistories.Add(history);
                context.SaveChanges();
            }
        }

        public void UseIngredients(StockDataModel ingredients)
        {
            var origEntity = context.Stocks.FirstOrDefault(x => x.LocationId == ingredients.LocationId);

            if (origEntity != null)
            {
                context.Entry(origEntity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IEnumerable<OrderHistoryDataModel> GetHistory()
        {
            return context.OrderHistories;
        }
    }
}