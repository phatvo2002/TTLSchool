using Microsoft.AspNetCore.Mvc;

namespace TTLProject2.Controllers
{
	public class DangKyController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
