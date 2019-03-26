using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlayNGoCoffee.Models;

namespace PlayNGoCoffee.Controllers
{
    public class HomeController : Controller
    {
        #region Protected Members
        /// <summary>
        /// Scoped application context
        /// </summary>
        protected ApplicationDbContext mContext;
        #endregion
        #region Constructor
        public HomeController(ApplicationDbContext context)
        {
            mContext = context;
        }
        #endregion

        public IActionResult Index()
        {
            //Makes sure we have a db
            mContext.Database.EnsureCreated();

            //if (!mContext.Coffee.Any())
            //{

            //}

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
