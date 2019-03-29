using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PlayNGoCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecipeIngredientsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: api/RecipeIngredients
        [HttpGet]
        public IEnumerable<RecipeIngredientDataModel> Get()
        {
            var recipeIngredients = _context.RecipeIngredients.Include(s => s.Ingredient).Include(a => a.Recipe);
            return recipeIngredients;
        }

        // GET: api/RecipeIngredients/5
        [HttpGet("{id}", Name = "GetRecipeIngredient")]
        public IEnumerable<RecipeIngredientDataModel> Get(int id)
        {
            var recipeIngredients = _context.RecipeIngredients.Include(a => a.Recipe).Include(s => s.Ingredient).Where(x => x.RecipeId == id);
            
            return recipeIngredients;
        }

        // POST: api/RecipeIngredients
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/RecipeIngredients/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] IEnumerable<StockDataModel> value)
        {
            return true;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
