using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayNGoCoffee.Business.ServiceContract;
using System.Collections.Generic;
using System.Linq;

namespace PlayNGoCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICoffeeService _service;

        public RecipeIngredientsController(ApplicationDbContext context)
        {
            this._context = context;
            this._service = new CoffeeService(context);
        }

        // GET: api/RecipeIngredients
        [HttpGet]
        public IEnumerable<RecipeIngredientDataModel> Get()
        {
            var recipeIngredients = _service.GetAllIngredients();
            return recipeIngredients;
        }

        // GET: api/RecipeIngredients/5
        [HttpGet("{id}", Name = "GetRecipeIngredient")]
        public IEnumerable<RecipeIngredientDataModel> Get(int id)
        {
            var recipeIngredients = this._service.GetIngredientsByRecipeId(id);            
            return recipeIngredients;
        }

        // POST: api/RecipeIngredients
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/RecipeIngredients/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] IEnumerable<StockDataModel> updatedStocks)
        {
            this._service.UpdateStock(updatedStocks, id);            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
