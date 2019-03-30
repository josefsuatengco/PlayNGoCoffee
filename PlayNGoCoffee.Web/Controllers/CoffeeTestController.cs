using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayNGoCoffee.Business.ServiceContract;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlayNGoCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    public class CoffeeTestController : Controller
    {
        private readonly ICoffeeService coffeeService;
        #region Protected Members
        /// <summary>
        /// Scoped application context
        /// </summary>
        protected ApplicationDbContext mContext;
        #endregion

        #region Constructor
        public CoffeeTestController(ApplicationDbContext context)
        {
            mContext = context;
            this.coffeeService = new CoffeeService(mContext);
        }
        #endregion

        [HttpGet("[action]")]
        public IEnumerable<LocationDataModel> Initialize()
        {
            var locations = coffeeService.GetLocations();

            return locations;
        }
        
        [HttpGet("[action]/{locationId}")]
        public IEnumerable<StockDataModel> Stock(int locationId)
        {
            var stock = coffeeService.GetStockByLocationId(locationId);

            return stock;
        }
        
        [HttpGet("[action]")]
        public IEnumerable<OrderHistoryDataModel> GetHistory()
        {
            var history = coffeeService.GetHistory();

            return history;
        }
    }
}
