using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
using TTLProject2.Bussiness;
using TTLProject2.Entities;
using TTLProject2.Models;

namespace TTLProject2.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> DanhSachDiemLop10A1(string maLopHoc)
        {
            DiemThiModel model = new DiemThiModel();
            model.MaLop = maLopHoc;
			return View(model);
        }

		[HttpGet]
		public async Task<IActionResult> DanhSachDiemTheoMonHoc(int maMonHoc,string maLop)
		{
			DiemThiModel model = new DiemThiModel();
            model.MaLop = model.MaLop;
			var hocSinh = new List<HocSinh>();
			hocSinh.AddRange(await _readataRepository.GetHocSinhByMaLop(maLop));
			model.DanhSachHocSinh = new SelectList(hocSinh, "MaHocSinh", "HoTen");

			var monHoc = new List<MonHoc>();
			monHoc.AddRange(await _readataRepository.GetMonHocByMaMonHoc(maMonHoc));
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
                    if(result)
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

   

		public async Task<IActionResult> GetListDiemHocSinh(int id)
		{
			return Json(new { data = await _readataRepository.GetDiemHocSinh10a1ByMaMonHoc(id) });
		}

		public async Task<IActionResult> GetListDiemHocSinhByMaLop(int id , string maLop)
		{
			return Json(new { data = await _readataRepository.GetDiemHocSinhByMaMonHocAndMaLop(id, maLop) });
		}


	}
}
