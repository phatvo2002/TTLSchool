using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TTLProject2.Bussiness;
using TTLProject2.Models;

namespace TTLProject2.Controllers
{
	[Authorize]
	public class TraCuuController : Controller
	{
		private readonly IReadataRepository _readataRepository;
		private readonly IWriteDataRepository _writeDataRepository;
		private readonly IWebHostEnvironment _hostingEnvironment;

		public TraCuuController(IReadataRepository readataRepository, IWriteDataRepository writeDataRepository, IWebHostEnvironment hostingEnvironment)
		{
			_readataRepository = readataRepository;
			_writeDataRepository = writeDataRepository;

			_hostingEnvironment = hostingEnvironment;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> TraCuuDiemThi(string maHocSinh)
		{
			
			var result = await _readataRepository.GetDiemThiByMaHocSinh(maHocSinh);

			return Json(new { data = result });
		}
	}
}
