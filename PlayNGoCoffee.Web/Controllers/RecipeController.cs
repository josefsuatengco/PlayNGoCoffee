using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayNGoCoffee.Business.ServiceContract;

namespace PlayNGoCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICoffeeService _service;

        public RecipeController(ApplicationDbContext context)
        {
            this._context = context;
            this._service = new CoffeeService(context);
        }

        // GET: api/RecipeIngredient
        [HttpGet]
        public IEnumerable<RecipeDataModel> Get()
        {
            return _service.GetRecipes();
        }

        // GET: api/RecipeIngredient/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RecipeIngredient
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/RecipeIngredient/5
        [HttpPut("{id}", Name ="put3")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
