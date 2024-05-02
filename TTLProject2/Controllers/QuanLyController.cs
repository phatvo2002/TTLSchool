using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;
using TTLProject2.Bussines;
using TTLProject2.Bussiness;
using TTLProject2.Entities;
using TTLProject2.Models;

namespace TTLProject2.Controllers
{
    [Authorize(Roles = "Quản Trị")]
    public class QuanLyController : Controller
    {
		private readonly IReadataRepository _readataRepository;
		private readonly IWriteDataRepository _writeDataRepository;
		private readonly IWebHostEnvironment _hostingEnvironment;
       
        public QuanLyController(IReadataRepository readataRepository, IWriteDataRepository writeDataRepository, IWebHostEnvironment hostingEnvironment )
		{
			_readataRepository = readataRepository;
			_writeDataRepository = writeDataRepository;
			
			_hostingEnvironment = hostingEnvironment;
		}

		[HttpGet]
		public async Task<IActionResult> QuanLyHocSinh()
        {
            ViewData["Tab"] = "QuanTri";
			HocSinhModel model = new HocSinhModel();
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

        [HttpPost]
        public async Task<IActionResult> SaveHocSinh(HocSinhModel model)
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
				model.SoDienThoaiBo = model.SoDienThoaiBo;
				model.HoTenMe = model.HoTenMe;
				model.NgheNghiep2 = model.NgheNghiep2;
				model.SoDienThoaiMe = model.SoDienThoaiMe;
				model.TruongHoc1 = model.TruongHoc1;
				model.TruongHoc2 = model.TruongHoc2;

				try
				{
					bool result;
					string errorMessage = "";
					string sucessMessage = "";
                    if(await _readataRepository.CheckHocSinhExistByMahocsinh(model.MaHocSinh))
                    {
						errorMessage = "Mã Học Sinh Đã Tồn Tại Trong Hệ Thống ";
						result = false;
						ViewBag.Error = errorMessage;
					}else if (await _readataRepository.CheckHocSinhExistByTenhocsinh(model.HoTen))
                    {
						errorMessage = "Tên Học Sinh Đã Tồn Tại Trong hệ thống ";
						result = false;
						ViewBag.Error = errorMessage;
					}
                    else
                    {
						result = await _writeDataRepository.InsertHocSinh(model);
						errorMessage = "Thêm dữ liệu thất bại";
						sucessMessage = "Thêm học sinh thành công";
						if (result)
						{
							ViewBag.Success = sucessMessage;
						}
						else
						{
							ViewBag.Error = errorMessage;
						}
					}    
					
				}
				catch (Exception ex)
				{
					ViewBag.Error = ex.Message;
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
			}

			return Json(new {success = ViewBag.Success , error = ViewBag.Error});
        }

        [HttpGet]
        public async Task<IActionResult> GetListHocSinh()
        {
			ViewData["Tab"] = "QuanTri";
			return Json(new { data = await _readataRepository.GetHocSinh() });
        }

		[HttpPost]
		public async Task<IActionResult> DeleteHocSinh(string mahocsinh)
		{
			
				var result = await _writeDataRepository.DeleteHs(mahocsinh);
				if (result)
				{
					ViewBag.Success = "Xóa Thành Công";
				}
				else
				{
					ViewBag.Error = "Xóa Thất bại";
				}
			
			
			return Json(new { success = ViewBag.Success, failed = ViewBag.Error });


		}

		


		// ------------------------Quản Lý Lớp học ------------------------------ 
		public async Task<IActionResult> QuanLyLopHoc()
		{
            ViewData["Tab"] = "QuanTri";
			LopHocViewModel model = new LopHocViewModel();
            var nienKhoa = new List<NienKhoa>();
            nienKhoa.AddRange(await _readataRepository.GetNienKhoa());
            model.DanhSachNienKhoa = new SelectList(nienKhoa, "MaNienKhoa", "TenNienKhoa");

            var khoi = new List<Khoi>();
            khoi.AddRange(await _readataRepository.GetKhois());
            model.DanhSachKhoi = new SelectList(khoi, "MaKhoi", "TenKhoi");

            var giaoVien = new List<GiaoVien>();
            giaoVien.AddRange(await _readataRepository.GetGiaoViens());
            model.DanhSachGiaoVien = new SelectList(giaoVien, "MaGiaoVien", "HoTen");
            return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> ThemMoiLopHoc(LopHocViewModel model)
		{
            try
            {
                   ViewData["Tab"] = "QuanTri";
                   ViewBag.isvalid = true;
                    //var lopHoc = _mapper.Map<LopHoc>(model);
                    model.MaLopHoc = model.MaLopHoc;
                    model.TenLopHoc = model.TenLopHoc;
                    model.MaKhoi = model.MaKhoi;
                    model.SiSo = model.SiSo;
                    model.HocNgoaiNgu = model.HocNgoaiNgu;
                    model.MaNienKhoa = model.MaNienKhoa;
                    model.MaGiaoVien = model.MaGiaoVien;

                   
                    try
                    {
                    bool result;
                    string errorMessage = "";
                    string sucessMessage = "";
                    if (await _readataRepository.CheckLopHocExist(model.MaLopHoc, model.TenLopHoc) )
                    {
                        errorMessage = "Lớp Học đã tồn tại , vui lòng kiểm tra lại thông tin vừa nhập ";
                        result = false;
                        ViewBag.Error = errorMessage;
                    }
                    else if (await _readataRepository.CheckLopHoExistByMagiaovien(model.MaGiaoVien))
                    {
						errorMessage = "Giáo viên này đã có lớp xin vui lòng chọn giáo viên khác ";
						result = false; 
						ViewBag.Error = errorMessage;
					}    
                    else
                    {

                        result = await _writeDataRepository.InsertLopHoc(model);
                        sucessMessage = "Thêm Lớp Học Thành Công";
                        errorMessage = "Thêm Thất Bại";
                        if(result)
                        {
                            ViewBag.Success = sucessMessage;
                        }else
                        {
                            ViewBag.Error = errorMessage;
                        }    
                     
                    }
                    }
                    catch(Exception ex)
                     {
                        ViewBag.Error = ex.Message;
                     }
                
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
         
            var nienKhoa = new List<NienKhoa>();
            nienKhoa.AddRange(await _readataRepository.GetNienKhoa());
            model.DanhSachNienKhoa = new SelectList(nienKhoa, "MaNienKhoa", "TenNienKhoa");

            var khoi = new List<Khoi>();
            khoi.AddRange(await _readataRepository.GetKhois());
            model.DanhSachKhoi = new SelectList(khoi, "MaKhoi", "TenKhoi");

            var giaoVien = new List<GiaoVien>();
            giaoVien.AddRange(await _readataRepository.GetGiaoViens());
            model.DanhSachGiaoVien = new SelectList(giaoVien, "MaGiaoVien", "HoTen");
            return Json(new {success = ViewBag.Success , error = ViewBag.Error }) ;
		}

        [HttpGet]
        public async Task<IActionResult> getAllLopHoc()
        {
            return Json(new { data = await _readataRepository.GetLopHoc() });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLop(string id)
        {
            var result = await _writeDataRepository.DeleteLopHoc(id);
            if (result != null)
            {
                return Json(new { success = true, message = "delete successfully" });
            }
            else
            {
                return Json(new { success = false, message = "delete failed" });
            }
        }


        //-------------------Quản Lý Giáo Viên--------
        [HttpGet]
        public  async Task<IActionResult> GiaoVien()
        {
            GiaoVienViewModel model = new GiaoVienViewModel();
            var gioiTinh = new List<GioiTinh>();
            gioiTinh.AddRange(await _readataRepository.GetGioiTinh());
			model.DanhSachGioiTinh = new SelectList(gioiTinh, "MaGioiTinh", "TenGioiTinh");

            var tonGiao = new List<TonGiao>();
            tonGiao.AddRange(await _readataRepository.GetTonGiao());
            model.DanhSachTonGiao = new SelectList(tonGiao, "MaTonGiao", "TenTonGiao");

			var dantoc = new List<DanToc>();
			dantoc.AddRange(await _readataRepository.GetDanToc());
			model.DanhSachDanToc = new SelectList(dantoc, "MaDanToc", "TenDanToc");


			var trangThai = new List<TrangThai>();
			trangThai.AddRange(await _readataRepository.GetTrangThai());
			model.DanhSachTrangThai = new SelectList(trangThai, "MaTrangThai", "TenTrangThai");

			var monhoc = new List<MonHoc>();
			monhoc.AddRange(await _readataRepository.GetMonHoc());
			model.DanhSachMonHoc = new SelectList(monhoc, "MaMonHoc", "TenMonHoc");

			return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetGiaoVienList()
        {
            return Json(new {data = await _readataRepository.GetGiaoViens()});
        }

		[HttpPost]
		public async Task<IActionResult> InsertGiaoVien(GiaoVienViewModel model)
		{
			try
			{
				
					ViewBag.isvalid = true;
			     	GiaoVien giaoVien = new GiaoVien();
				     giaoVien.MaGiaoVien = model.MaGiaoVien;
				    giaoVien.MaGioiTinh = model.MaGioiTinh;
				    giaoVien.MaDanToc = model.MaDanToc;
				    giaoVien.MaTonGiao = model.MaTonGiao;
			    	giaoVien.MaMonHoc = model.MaMonHoc;
				    giaoVien.MaTrangThai = model.MaTrangThai;
				    giaoVien.HoTen = model.HoTen;
				    giaoVien.NgaySinh = model.NgaySinh;
			    	giaoVien.Email = model.Email;
				    giaoVien.DienThoai = model.DienThoai;
			    	giaoVien.QueQuan = model.QueQuan;
					giaoVien.SoBaoHiemXaHoi = model.SoBaoHiemXaHoi;
				    giaoVien.CCCD = model.CCCD;
			     	giaoVien.Password = model.Password;
					var path = $"{_hostingEnvironment.WebRootPath}\\files\\{DateTime.Now.Year}";
			   	   giaoVien.HinhAnh= await Apphelper.SaveFile($"{path}\\images", model.HinhAnh.FileName, model.HinhAnh.OpenReadStream());

					bool result;
					string errorMessage = "";
					string sucessMessage = "";
				try {
					if(await _readataRepository.CheckGiaoVienExistByMagiaovien(model.MaGiaoVien))
					{
						errorMessage = "Mã giáo viên đã tồn tại !";
						result = false;
						ViewBag.Error = errorMessage;
					}
					else if(await _readataRepository.CheckGiaoVienExistbyTenGiaoVien(model.HoTen))
					{
						errorMessage = "Tên đã tồn tại trong hệ thống !";
						result = false;
						ViewBag.Error =errorMessage;
					}
					else
					{
						result = await _writeDataRepository.InsertGiaoVien(giaoVien);
						sucessMessage = "Thêm Giáo Viên Thành Công";
						errorMessage = "Đã xảy ra lỗi trong quá trình thêm ";

						if (result)
						{
							ViewBag.Success = sucessMessage;
						}
						else
						{
							ViewBag.Error = errorMessage;
						}
					}	
					
				}
				catch(Exception ex)
				{
					 ViewBag.Error = ex.Message;
				}

					
					

			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
			}
			return Json(new { success = ViewBag.Success, failed = ViewBag.Error });
		}

		[HttpPost]
		public async Task<IActionResult> DeleteGv( GiaoVienViewModel giaoVien)
		{
			try
			{
				var result = await _writeDataRepository!.DeleteGv(giaoVien.MaGiaoVien);
				if (result)
				{
					ViewBag.Success = "Xóa Thành Công";
				}else
				{
					ViewBag.Error = "Xóa Thất bại";
				}	
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
			}
			return Json(new { success = ViewBag.Success, failed = ViewBag.Error });
			

		}
	}

}
