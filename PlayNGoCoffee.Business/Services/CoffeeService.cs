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
        
        public IEnumerable<RecipeDataModel> GetCoffeeRecipeById(int coffeeId)
        {
            return context.Recipes.Where(x => x.CoffeeId == coffeeId);
        }

        public IEnumerable<CoffeeDataModel> GetCoffees()
        {
            return context.Coffee;
        }

        public IEnumerable<LocationDataModel> GetLocations()
        {
            return context.Locations;
        }

        public IEnumerable<IngredientDataModel> GetStockByLocationId(int locationId)
        {
            return context.Ingredients.Where(x => x.LocationId == locationId);
        }
    }
}
