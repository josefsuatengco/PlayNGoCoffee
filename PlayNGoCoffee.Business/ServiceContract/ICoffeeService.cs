using System;
using System.Collections.Generic;
using System.Text;

namespace PlayNGoCoffee.Business.ServiceContract
{
    public interface ICoffeeService
    {

        IEnumerable<RecipeIngredientDataModel> GetIngredientsByRecipeId(int recipeId);

        IEnumerable<RecipeDataModel> GetRecipes();

        IEnumerable<LocationDataModel> GetLocations();

        IEnumerable<StockDataModel> GetStockByLocationId(int locationId);

        void AddHistory(OrderHistoryDataModel history);

        void UseIngredients(StockDataModel ingredients);

        IEnumerable<OrderHistoryDataModel> GetHistory();
    }
}
