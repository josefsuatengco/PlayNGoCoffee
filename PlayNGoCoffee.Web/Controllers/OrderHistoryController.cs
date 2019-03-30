using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayNGoCoffee.Business.ServiceContract;

namespace PlayNGoCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICoffeeService _service;

        public OrderHistoryController(ApplicationDbContext context)
        {
            this._context = context;
            this._service = new CoffeeService(context);
        }

        // GET: api/OrderHistory
        [HttpGet]
        public IEnumerable<OrderHistoryDataModel> Get()
        {
            return _service.GetHistory();
        }

        // GET: api/OrderHistory/5
        [HttpGet("{id}", Name = "Get2")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OrderHistory
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/OrderHistory/5
        [HttpPut("{id}", Name = "put2")]
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
