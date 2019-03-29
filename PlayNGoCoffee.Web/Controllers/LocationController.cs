﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PlayNGoCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LocationController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: api/Location
        [HttpGet]
        public IEnumerable<LocationDataModel> Get()
        {
            return _context.Locations;
        }

        // GET: api/Location/5
        [HttpGet("{id}", Name = "GetStock")]
        public IEnumerable<StockDataModel> Get(int id)
        {
            var stocks = _context.Stocks.Include(s => s.Ingredient).Where(a => a.LocationId == id);

            return stocks;
        }

        // POST: api/Location
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Location/5
        [HttpPut("{id}")]
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
