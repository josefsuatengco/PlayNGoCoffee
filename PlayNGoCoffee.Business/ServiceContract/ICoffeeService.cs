using System;
using System.Collections.Generic;
using System.Text;

namespace PlayNGoCoffee.Business.ServiceContract
{
    public interface ICoffeeService
    {

        IEnumerable<RecipeIngredientDataModel> GetIngredientsByRecipeId(int recipeId);

        IEnumerable<RecipeIngredientDataModel> GetAllIngredients();

        IEnumerable<RecipeDataModel> GetRecipes();

        IEnumerable<LocationDataModel> GetLocations();

        IEnumerable<StockDataModel> GetStockByLocationId(int locationId);

        void UpdateStock(IEnumerable<StockDataModel> updatedStocks, int recipeId);

        IEnumerable<OrderHistoryDataModel> GetHistory();
    }
}
