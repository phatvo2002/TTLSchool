using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TTLProject2.Models
{
    public class GiaoVienViewModel
    {
		[Required(ErrorMessage = "Bạn chưa nhập mã giáo viên")]
		[RegularExpression(@"^(GV)+([A-Z].{2,})$", ErrorMessage = "2 kí tự đầu bắt buộc phải bắt đầu bằng GV và phải 3 kí tự trở lên   ")]
		[Display(Name = "MaGiaoVien")]
		public string? MaGiaoVien { get; set; }

		[Required(ErrorMessage = "Bạn chưa chọn giới tính")]
		[Display(Name = "MaGioiTinh")]
		public int MaGioiTinh { get; set; }

        public int MaTonGiao { get; set; }

        public int MaDanToc { get; set; }

        public int MaTrangThai { get; set; }

        public int MaMonHoc { get; set; }

        [Required(ErrorMessage ="Bạn Chưa Nhập đầy đủ họ tên")]
		[Display(Name = "HoTen")]
		public string? HoTen { get; set; }

        [Required(ErrorMessage = "Bạn Chưa Chọn ngày sinh")]
        public string? NgaySinh { get; set; }

        [Required(ErrorMessage ="Bạn Chưa nhập số căn cước công dân ")]
		[RegularExpression(@"^\d{12}$|^\d{9}$", ErrorMessage = "Số căn cước công dân phải là số và chỉ chấp nhận dải 12 số (CCCD) hoặc 9 số (CMTND)")]
		[Display(Name = "CCCD")]
		public string? CCCD { get; set; }

        [Required(ErrorMessage ="Bạn Chua nhập Email ")]
		[Display(Name = "Email")]
		public string? Email { get; set; }

        [Required(ErrorMessage ="Bạn Chưa nhập số điện thoại ")]
		[RegularExpression(@"^(84|0[09]|0[07]|0[05])+([0-9]{8})\b$", ErrorMessage = "Số điện thoại phải đúng định dạng với 2 số đầu [09],[07],[05] và tối đa 10 số ")]
		[Display(Name = "Email")]
		public string? DienThoai { get; set; }

        [Required(ErrorMessage ="Bạn Chưa Chọn Hình ảnh")]
		[Display(Name = "HinhAnh")]
		public IFormFile? HinhAnh { get; set; }

        [Required(ErrorMessage ="Bạn Chưa Chọn quê quán ")]
		[Display(Name = "QueQuan")]
		public string? QueQuan { get; set; }

        [Required(ErrorMessage ="Bạn Chưa nhập bảo hiểm xã hội ")]
		[RegularExpression(@"^\d{10}$", ErrorMessage = "Số bảo hiểm xã hội phải tối đa 10 kí tự  ")]
		public string? SoBaoHiemXaHoi { get; set; }

        public string? Password { get; set; }


        public SelectList? DanhSachGioiTinh { get; set; }

        public SelectList? DanhSachTonGiao { get; set; }

        public SelectList? DanhSachDanToc { get; set; }

        public SelectList? DanhSachTrangThai { get; set; }

        public SelectList? DanhSachMonHoc { get; set; }


        

    }
}
