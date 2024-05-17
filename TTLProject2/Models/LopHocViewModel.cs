using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TTLProject2.Models
{
    public class LopHocViewModel
    {

        [Required(ErrorMessage = "Vui lòng nhập mã lớp học")]
        [RegularExpression(@"^[a-zA-Z0-9]{5}$", ErrorMessage = "Mã Lớp học phải đúng 5 kí tự ")]
        [Display(Name = "MaLopHoc")]
        public string? MaLop { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn niên khóa")]
        [Display(Name = "MaNienKhoa")]
        public int MaNienKhoa { get; set; }

        [Required(ErrorMessage = "Bạn chưa chọn khối lớp")]
        [Display(Name = "MaKhoi")]
        public int MaKhoi { get; set; }

        public string? MaGiaoVien { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn tên lớp học")]
        [Display(Name = "TenLopHoc")]
        public string? TenLop { get; set; }

        public string? GhiChu { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập sĩ số")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Vui lòng nhập số")]
        [Display(Name = "SiSo")]
        public int SiSo { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên ngoại ngữ")]
        [Display(Name = "HocNgoaiNgu")]
        public string? HocNgoaiNgu { get; set; }

        public IFormFile? ThoiKhoaBieu { get; set; }

        public SelectList? DanhSachLopHoc { get; set; }

        public SelectList? DanhSachNienKhoa { get; set; }

        public SelectList? DanhSachKhoi { get; set; }

        public SelectList? DanhSachGiaoVien { get; set; }



    }
}
