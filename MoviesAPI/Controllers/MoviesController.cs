using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Filters;

namespace MoviesAPI.Controllers
{
    public class MoviesController : Controller
    {
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public IActionResult Index()
        {
            return View();
        }


    }
}
