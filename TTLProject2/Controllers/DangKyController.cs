using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TTLProject2.Bussiness;
using TTLProject2.Entities;
using TTLProject2.Models;

namespace TTLProject2.Controllers
{
	public class DangKyController : Controller
	{
        private readonly IReadataRepository _readataRepository;
        private readonly IWriteDataRepository _writeDataRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public DangKyController(IReadataRepository readataRepository, IWriteDataRepository writeDataRepository, IWebHostEnvironment hostingEnvironment)
        {
            _readataRepository = readataRepository;
            _writeDataRepository = writeDataRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
		public async Task<IActionResult> Index()
		{
            DangKiViewModel model = new DangKiViewModel();
            ThiSinh thiSinh = new ThiSinh();
            model.MaNienKhoa = thiSinh.MaNienKhoa;
            model.MaGioiTinh = thiSinh.MaGioiTinh;
            model.MaDanToc = thiSinh.MaDanToc;
            model.MaTonGiao = thiSinh.MaTonGiao;
            model.HoTen = thiSinh.HoTen;
            model.NgaySinh = thiSinh.NgaySinh;
            model.NoiSinh =thiSinh.NoiSinh;
            model.TruongThcs = thiSinh.TruongThcs;
            model.XepLoaiTotNghiep = thiSinh.XepLoaiTotNghiep;
            model.NamTotNghiep = thiSinh.NamTotNghiep;
            model.SoDienThoai = thiSinh.SoDienThoai;
            model.HoTenBo = thiSinh.HoTenBo;
            model.SoDienThoaiBo = thiSinh.SoDienThoaiBo;
            model.NgheNghiepBo = thiSinh.NgheNghiepBo;
            model.HoTenMe = thiSinh.HotTenMe;
            model.NgheNghiepMe = thiSinh.NgheNghiepMe;
            model.SoDienThoaiMe = thiSinh.SoDienThoaiMe;
            model.DiemTb6 = thiSinh.DiemTb6;
            model.HocLuc6 = thiSinh.HocLuc6;
            model.HanhKiem6 = thiSinh.HanhKiem6;
            model.DiemTb7 = thiSinh.DiemTb7;
            model.HocLuc7 = thiSinh.HocLuc7;
            model.HanhKiem7 = thiSinh.HanhKiem7;
			model.DiemTb8 = thiSinh.DiemTb8;
			model.HocLuc8 = thiSinh.HocLuc8;
			model.HanhKiem8 = thiSinh.HanhKiem8;
			model.DiemTb9 = thiSinh.DiemTb9;
			model.HocLuc9 = thiSinh.HocLuc9;
			model.HanhKiem9 = thiSinh.HanhKiem9;
            model.DiemThiTsToan = thiSinh.DiemThiTsToan;
            model.DiemThiTsNguVan = thiSinh.DiemThiTsNguVan;
            model.DiemThiTsTiengAnh = thiSinh.DiemThiTsTiengAnh;
            model.TongDiem = thiSinh.TongDiem;
            model.DiaChiNhan = thiSinh.DiaChiNhan;
			var nienKhoa = new List<NienKhoa>();
            nienKhoa.AddRange(await _readataRepository.GetNienKhoa());
            model.DanhSachNienKhoa = new SelectList(nienKhoa, "MaNienKhoa", "TenNienKhoa");
            var gioiTinh = new List<GioiTinh>();
            gioiTinh.AddRange(await _readataRepository.GetGioiTinh());
            model.DanhSachGioiTinh = new SelectList(gioiTinh, "MaGioiTinh", "TenGioiTinh");
            var danToc = new List<DanToc>();
            danToc.AddRange(await _readataRepository.GetDanToc());
            model.DanhSachDanToc = new SelectList(danToc, "MaDanToc", "TenDanToc");
            var tonGiao = new List<TonGiao>();
            tonGiao.AddRange(await _readataRepository.GetTonGiao());
            model.DanhSachTonGiao = new SelectList(tonGiao, "MaTonGiao", "TenTonGiao");

            return View(model);
		}
     //   [HttpPost]
     //   public async Task<IActionResult> Index(DangKiViewModel model)
     //   {
           
     //           ViewBag.Isvalid = true;
     //           ThiSinh thiSinh = new ThiSinh();
     //           thiSinh.MaNienKhoa = model.MaNienKhoa;
     //           thiSinh.MaGioiTinh = model.MaGioiTinh;
     //           thiSinh.MaDanToc = model.MaDanToc;
     //           thiSinh.MaTonGiao = model.MaTonGiao;
     //           thiSinh.HoTen = model.HoTen;
               
     //           thiSinh.NgaySinh = model.NgaySinh;
     //           thiSinh.NoiSinh = model.NoiSinh;
     //           thiSinh.TruongThcs = model.TruongThcs;
     //           thiSinh.XepLoaiTotNghiep = model.XepLoaiTotNghiep;
     //           thiSinh.NamTotNghiep = model.NamTotNghiep;
     //           thiSinh.SoDienThoai = model.SoDienThoai;
     //           thiSinh.DiemTb6 = model.DiemTb6;
     //           thiSinh.HanhKiem6 = model.HanhKiem6;
     //           thiSinh.HocLuc6 = model.HocLuc6;
     //           thiSinh.DiemTb7 = model.DiemTb7;
     //           thiSinh.HanhKiem7 = model.HanhKiem7;
     //           thiSinh.HocLuc7 = model.HocLuc7;
     //           thiSinh.DiemTb8 = model.DiemTb8;
     //           thiSinh.HanhKiem8 = model.HanhKiem8;
     //           thiSinh.HocLuc8 = model.HocLuc8;
     //           thiSinh.DiemTb9 = model.DiemTb9;
     //           thiSinh.HanhKiem9 = model.HanhKiem9;
     //           thiSinh.HocLuc9 = model.HocLuc9;
     //           thiSinh.HoTenBo = model.HoTenBo;
     //           thiSinh.NgheNghiepBo = model.NgheNghiepBo;
     //           thiSinh.SoDienThoaiBo = model.SoDienThoaiBo;
     //           thiSinh.HotTenMe = model.HoTenMe;
     //           thiSinh.NgheNghiepMe = model.NgheNghiepMe;
     //           thiSinh.SoDienThoaiMe = model.SoDienThoaiMe;
     //           thiSinh.DiemThiTsToan = model.DiemThiTsToan;
     //           thiSinh.DiemThiTsNguVan = model.DiemThiTsNguVan;
     //           thiSinh.DiemThiTsTiengAnh = model.DiemThiTsTiengAnh;
     //           thiSinh.TongDiem = model.TongDiem;
     //           thiSinh.DiaChiNhan = model.DiaChiNhan;

     //           var path = $"{this._hostingEnvironment.WebRootPath}\\files\\{DateTime.Now.Year}";

     //           thiSinh.HinhAnh = await AppHelper.SaveFile($"{path}\\images", model.HinhAnh.FileName, model.HinhAnh.OpenReadStream());

     //           bool result;
     //           string errorMessage = "";
     //           string sucessMessage = "";


     //           try
     //           {
     //               result = await _writeDataRepository.InsertThiSinh(model);
     //               if (result)
     //               {
					//	sucessMessage = "Đăng kí thành công ";
     //                   ViewBag.success = sucessMessage;
					//}
     //               else
     //               {
     //                   errorMessage = "Đăng ký thất bại ";
     //                   ViewBag.error = errorMessage;
     //               }    
     //           }catch (Exception ex)
     //           {
     //               return Json(new { error = ex.ToString() });
     //           }
            
          
     //       return View(model);
     //   }
	}
}
