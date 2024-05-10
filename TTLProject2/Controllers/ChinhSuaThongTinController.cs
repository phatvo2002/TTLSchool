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

            var gt = new List<GioiTinh>();
            gt.AddRange(await _readataRepository.GetGioiTinh());
            model.DanhSachGioiTinh = new SelectList(gt, "MaGioiTinh", "TenGioiTinh");

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

		[HttpPost]
		public async Task<IActionResult> UpdateHocSinh(HocSinhModel model)
		{
			try
			{
				ViewBag.Isvalid = true;
				model.MaHocSinh = model.MaHocSinh;
				model.HoTen = model.HoTen;
				model.MaGioiTinh = model.MaGioiTinh;
				model.MaLop = model.MaLop;
				model.MaTrangThai = model.MaTrangThai;
				model.MaQuocTich = model.MaQuocTich;
				model.NgaySinh = model.NgaySinh;
				model.MaDanToc = model.MaDanToc;
				model.DiaChiNha = model.DiaChiNha;
				model.SoDienThoai = model.SoDienThoai;
				model.HoTenBo = model.HoTenBo;
				model.NgheNghiep1 = model.NgheNghiep1;
				model.SoDienThoaiBa = model.SoDienThoaiBa;
				model.HoTenMe = model.HoTenMe;
				model.NgheNghiep2 = model.NgheNghiep2;
				model.SoDienThoaiMe = model.SoDienThoaiMe;
				model.TruongHoc1 = model.TruongHoc1;
				model.TruongHoc2 = model.TruongHoc2;

				bool result;
				string errorMessage = "";
				string successMessage = "";

				try
				{
					result = await _writeDataRepository.UpdateHocSinh(model);
					{
						if (result)
						{
							successMessage = "Chỉnh sửa hồ sơ thành công";
							ViewBag.success = successMessage;
						}
						else
						{
							errorMessage = "Đã xảy ra lỗi trong quá trình thêm ";
							ViewBag.error = errorMessage;
						}
					}
				}
				catch (Exception ex)
				{
					ViewBag.error = ex;
				}

			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
			}
			return Json(new { Success = ViewBag.success, Error = ViewBag.error });


		}

	

	}
}
