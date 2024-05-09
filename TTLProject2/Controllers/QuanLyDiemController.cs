using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
using TTLProject2.Bussiness;
using TTLProject2.Entities;
using TTLProject2.Models;

namespace TTLProject2.Controllers
{
    public class QuanLyDiemController : Controller
    {
		private readonly IReadataRepository _readataRepository;
		private readonly IWriteDataRepository _writeDataRepository;
		private readonly IWebHostEnvironment _hostingEnvironment;

		public QuanLyDiemController(IReadataRepository readataRepository, IWriteDataRepository writeDataRepository, IWebHostEnvironment hostingEnvironment)
		{
			_readataRepository = readataRepository;
			_writeDataRepository = writeDataRepository;

			_hostingEnvironment = hostingEnvironment;
		}
		public IActionResult DanhSachDiemHocSinh()
        {
            return View();
        }

        //lớp 10A1
        [HttpGet]
        public async Task<IActionResult> DanhSachDiemLop10A1()
        {
            DiemThiModel model = new DiemThiModel();

			return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DanhSachDiemLop10A1MonToan()
        {
			DiemThiModel model = new DiemThiModel();

			var hocSinh = new List<HocSinh>();
			hocSinh.AddRange(await _readataRepository.GetHocSinh10a1());
			model.DanhSachHocSinh = new SelectList(hocSinh, "MaHocSinh", "HoTen");

			var monHoc = new List<MonHoc>();
			monHoc.AddRange(await _readataRepository.GetMonToan());
			model.DanhSachMonHoc = new SelectList(monHoc, "MaMonHoc", "TenMonHoc");


			var hocki = new List<HocKiNamHoc>();
			hocki.AddRange(await _readataRepository.GetHocKiNamHoc());
			model.DanhSachHocKiNamHoc = new SelectList(hocki, "MaHocKiNamHoc", "TenHocKiNamHoc");
			return View(model);
        }

		[HttpGet]
		public async Task<IActionResult> DanhSachDiemLop10A1MonNguVan()
		{
			DiemThiModel model = new DiemThiModel();

			var hocSinh = new List<HocSinh>();
			hocSinh.AddRange(await _readataRepository.GetHocSinh10a1());
			model.DanhSachHocSinh = new SelectList(hocSinh, "MaHocSinh", "HoTen");

			var monHoc = new List<MonHoc>();
			monHoc.AddRange(await _readataRepository.GetMonNGuVan());
			model.DanhSachMonHoc = new SelectList(monHoc, "MaMonHoc", "TenMonHoc");

			var hocki = new List<HocKiNamHoc>();
			hocki.AddRange(await _readataRepository.GetHocKiNamHoc());
			model.DanhSachHocKiNamHoc = new SelectList(hocki, "MaHocKiNamHoc", "TenHocKiNamHoc");
			return View(model);
		}


		[HttpPost]
        public async Task<IActionResult> InsertDiemHocSinh(DiemThiModel model)
        {
            try
            {
				Diem diem = new Diem();
                diem.MaHocSinh = model.MaHocSinh;
                diem.MaHocKiNamHoc = model.MaHocKiNamHoc;
                diem.MaMonHoc = model.MaMonHoc;
                diem.DiemKiemTraMieng = model.DiemKiemTraMieng;
                diem.Diem15PhutLan1 = model.Diem15PhutLan1;
                diem.Diem15PhutLan2 = model.Diem15PhutLan2;
                diem.DiemKT1Tiet = model.DiemKT1Tiet;
                diem.DiemGk = model.DiemGk;
                diem.DiemCk = model.DiemCk;
				model.DiemTbHk = model.DiemTbHk;

                try
                {
                    bool result;
                    string errorMessage = "";
                    string successMessage = "";

                    result = await _writeDataRepository.InsertDiemThiSinh(model);
                    if(result )
                    {
						successMessage = "Nhập thành công";
                        ViewBag.success = successMessage;
                    }
                    else
                    {
                        errorMessage = "Đã xãy ra lỗi trong quá trình thêm ";
                        ViewBag.error = errorMessage;
                    }    
                }catch (Exception ex)
                {
                    ViewBag.error = ex;
                }
			}
            catch(Exception ex) 
            {
                ViewBag.error = ex;
            } 
            return Json(new {Success = ViewBag.success , Error = ViewBag.error});
        }

        [HttpGet]
        public async Task<IActionResult> DiemLop10A1GetList()
        {
            return Json(new { data = await _readataRepository.GetHocSinh10a1MonToan()});
        }

		[HttpGet]
		public async Task<IActionResult> DiemLop10A1MonTiengAnhGetList()
		{
			return Json(new { data = await _readataRepository.GetHocSinh10a1MonNgoaiNgu() });
		}

		[HttpGet]
		public async Task<IActionResult> DiemLop10A1MonNguVanGetList()
		{
			return Json(new { data = await _readataRepository.GetHocSinh10a1MonNguVan() });
		}

		[HttpGet]
		public async Task<IActionResult> DiemLop10A1MonSinhHocGetList()
		{
			return Json(new { data = await _readataRepository.GetHocSinh10a1MonSinhHoc() });
		}


		[HttpGet]
		public async Task<IActionResult> DiemLop10A1MonHoaHocGetList()
		{
			return Json(new { data = await _readataRepository.GetHocSinh10a1MonHoaHoc() });
		}

		[HttpGet]
		public async Task<IActionResult> DiemLop10A1MonVatLyGetList()
		{
			return Json(new { data = await _readataRepository.GetHocSinh10a1MonVayLy() });
		}
	}
}
