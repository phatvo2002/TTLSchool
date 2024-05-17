using Microsoft.AspNetCore.Mvc;

namespace TTLProject2.Controllers
{
    public class QuanLyTinTucController : Controller
    {

        public IActionResult QuanLyTinTucNhaTruong()
        {
            return View();
        }

        public IActionResult TinTucNhaTruong()
        {
            return View();
        }

        public IActionResult ThongBao()
        {
            return View();
        }
    }
}
