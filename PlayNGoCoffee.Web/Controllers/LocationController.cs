using Microsoft.AspNetCore.Mvc;
using PlayNGoCoffee.Business.ServiceContract;
using System.Collections.Generic;

namespace PlayNGoCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICoffeeService _service;

        public LocationController(ApplicationDbContext context)
        {
            this._context = context;
            this._service = new CoffeeService(context);
        }

        // GET: api/Location
        [HttpGet]
        public IEnumerable<LocationDataModel> Get()
        {
            return _service.GetLocations();
        }

        // GET: api/Location/5
        [HttpGet("{id}", Name = "GetStock")]
        public IEnumerable<StockDataModel> Get(int id)
        {
            var stocks = _service.GetStockByLocationId(id);

            return stocks;
        }

        // POST: api/Location
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Location/5
        [HttpPut("{id}", Name="put1")]
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
