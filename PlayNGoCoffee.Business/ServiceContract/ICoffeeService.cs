using System;
using System.Collections.Generic;
using System.Text;

namespace PlayNGoCoffee.Business.ServiceContract
{
    public interface ICoffeeService
    {
        IEnumerable<CoffeeDataModel> GetCoffees();

        IEnumerable<RecipeDataModel> GetCoffeeRecipeById(int coffeeId);

        IEnumerable<LocationDataModel> GetLocations();

        IEnumerable<IngredientDataModel> GetStockByLocationId(int locationId);
    }
}
