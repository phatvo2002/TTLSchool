using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;


namespace TTLProject2.Models
{
    public class DangKiViewModel
    {

        public int MaThiSinh { get; set; }

        [Required(ErrorMessage ="bạn Vui lòng chọn niên khóa")]
        public int MaNienKhoa { get; set; }
        [Required(ErrorMessage = "bạn Vui lòng chọn giới tính ")]
        public int MaGioiTinh { get; set; }
        [Required(ErrorMessage = "bạn Vui lòng chọn dân tộc")]
        public int MaDanToc { get; set; }
        [Required(ErrorMessage = "bạn Vui lòng chọn tôn giáo")]
        public int MaTonGiao { get; set; }

        [Required(ErrorMessage = "bạn Vui lòng nhập họ tên ")]
        public string? HoTen {  get; set; }

        public string? Ho {  get; set; }

        public string? TenDem { get; set; }

        public string? Ten {  get; set; }

        [Required(ErrorMessage = "bạn Vui lòng nhập ngày sinh ")]
        public string? NgaySinh { get; set; }
        [Required(ErrorMessage = "bạn Vui lòng nhập nơi sinh ")]
        public string? NoiSinh { get; set; }
        [Required(ErrorMessage = "bạn Vui lòng nhập trường trung học cơ sở  ")]
        public string? TruongThcs { get; set; }

        public string? DiaChiThuongTru { get; set; }

        public string? DiaChiHienTai { get; set; }

        public string? NamTotNghiep { get; set; }

        public string? XepLoaiTotNghiep { get; set; }

        public string? SoDienThoai { get; set; }

        public string? HoTenBo {  get; set; }

        public string? NgheNghiepBo { get; set; }

        public string? SoDienThoaiBo { get; set; }

        public string? HoTenMe {  get; set; }

        public string? NgheNghiepMe { get; set; }

        public string? SoDienThoaiMe { get; set; }

        public float? DiemTb6 { get; set; }

        public string? HanhKiem6 { get; set; }

        public string? HocLuc6 {  get; set; }

        public float? DiemTb7 { get; set; }

        public string? HanhKiem7 { get; set; }

        public string? HocLuc7 { get; set; }

        public float? DiemTb8 { get; set; }

        public string? HanhKiem8 { get; set; }

        public string? HocLuc8 { get; set; }

        public float? DiemTb9 { get; set; }

        public string? HanhKiem9 { get; set; }

        public string? HocLuc9 { get; set; }

        public float? DiemThiTsToan { get; set; }

        public float? DiemThiTsNguVan { get; set; }

        public float? DiemThiTsTiengAnh { get; set; }

        public float? TongDiem { get; set; }


        public string? DiaChiNhan { get; set; }

        public IFormFile? HinhAnh { get; set; }

        public SelectList? DanhSachNienKhoa { get; set; }

        public SelectList? DanhSachGioiTinh { get; set; }

        public SelectList? DanhSachDanToc { get; set; }

        public SelectList? DanhSachTonGiao { get; set; }
    }
}
