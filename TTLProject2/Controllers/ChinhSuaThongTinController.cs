using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TTLProject2.Bussiness;
using TTLProject2.Entities;
using TTLProject2.Models;

namespace TTLProject2.Controllers
{
	public class ChinhSuaThongTinController : Controller
	{
		private readonly IReadataRepository _readataRepository;
		private readonly IWriteDataRepository _writeDataRepository;
		private readonly IWebHostEnvironment _hostingEnvironment;

		public ChinhSuaThongTinController(IReadataRepository readataRepository, IWriteDataRepository writeDataRepository, IWebHostEnvironment hostingEnvironment)
		{
			_readataRepository = readataRepository;
			_writeDataRepository = writeDataRepository;
			_hostingEnvironment = hostingEnvironment;
		}
		[HttpGet]
		public async Task<IActionResult> Index(string id )
		{
			HocSinhModel model = new HocSinhModel();
			model = await _readataRepository.GetHocSinhByID(id);

            var gioiTinh = new List<GioiTinh>();
            gioiTinh.AddRange(await _readataRepository.GetGioiTinh());
            model.DanhSachGioiTinh = new SelectList(gioiTinh, "MaGioiTinh", "TenGioiTinh");

            var trangThai = new List<TrangThai>();
            trangThai.AddRange(await _readataRepository.GetTrangThai());
            model.DanhSachTrangThai = new SelectList(trangThai, "MaTrangThai", "TenTrangThai");

            var danToc = new List<DanToc>();
            danToc.AddRange(await _readataRepository.GetDanToc());
            model.DanhSachDanToc = new SelectList(danToc, "MaDanToc", "TenDanToc");

            var lopHoc = new List<LopHoc>();
            lopHoc.AddRange(await _readataRepository.GetLopHoc());
            model.DanhsachLopHoc = new SelectList(lopHoc, "MaLop", "TenLop");

            var quocTich = new List<QuocTich>();
            quocTich.AddRange(await _readataRepository.GetQuocTich());
            model.DanhSachQuocTich = new SelectList(quocTich, "MaQuocTich", "TenQuocTich");

            return View(model);
		}
	}
}
