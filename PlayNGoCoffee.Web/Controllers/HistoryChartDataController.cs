using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayNGoCoffee.Business.ServiceContract;
using PlayNGoCoffee.Web.Models;

namespace PlayNGoCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryChartDataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICoffeeService _service;

        public HistoryChartDataController(ApplicationDbContext context)
        {
            this._context = context;
            this._service = new CoffeeService(context);
        }

        // GET: api/ChartData
        [HttpGet]
        public IEnumerable<OrderHistoryGraphModel> Get()
        {
            var orderHistories = _service.GetHistory();
            IEnumerable<OrderHistoryGraphModel> chartData = new List<OrderHistoryGraphModel>();

             chartData = orderHistories
                            .GroupBy(l => l.RecipeId)
                            .Select(cl => new OrderHistoryGraphModel
                            {
                                Name = cl.First().Recipe.Name,
                                Quantity = cl.Sum(c => c.Quantity)
                            }).ToList();

            return chartData;
        }

        // GET: api/HistoryChartData/5
        [HttpGet("{id}", Name = "Get7")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HistoryChartData
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/HistoryChartData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/HistoryChartData/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
