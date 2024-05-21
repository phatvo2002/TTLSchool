using Microsoft.AspNetCore.Mvc;

namespace TTLProject2.Controllers
{
    public class DictionaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TraCuuTuVung()
        {
            return View();
        }
    }
}
