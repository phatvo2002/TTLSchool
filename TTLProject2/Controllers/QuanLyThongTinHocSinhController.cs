using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TTLProject2.Bussiness;
using TTLProject2.Entities;
using TTLProject2.Models;

namespace TTLProject2.Controllers
{
	[Authorize]
    public class QuanLyThongTinHocSinhController : Controller
    {
		private readonly IReadataRepository _readataRepository;
		private readonly IWriteDataRepository _writeDataRepository;
		private readonly IWebHostEnvironment _hostingEnvironment;
		
		public QuanLyThongTinHocSinhController(IReadataRepository readataRepository, IWriteDataRepository writeDataRepository, IWebHostEnvironment hostingEnvironment)
		{
			_readataRepository = readataRepository;
			_writeDataRepository = writeDataRepository;
			_hostingEnvironment = hostingEnvironment;
		}

		[HttpGet]
		public  async Task<IActionResult> Index(string email)
        {
			HocSinhModel model = new HocSinhModel();

			model = await _readataRepository.GetHocSinhByEmail(email);
			
            return View(model);
        }

		public async Task<IActionResult> KetQuaHocTap()
		{
		    return View();
        }

		[HttpGet]
		public async Task<IActionResult> GetListDiemHocSinh(string MaHocSinh)
		{
			var result = await _readataRepository.GetDiemThiByMaHocSinh(MaHocSinh);
			return Json(new {data = result});
		}

		public async Task<IActionResult> ChiTietHocSinh(string MaHocSinh)
		{
            HocSinhModel model = new HocSinhModel();
            model = await _readataRepository.GetHocSinhAllThongtinByID(MaHocSinh);
            return View(model);
		}

    }
}
