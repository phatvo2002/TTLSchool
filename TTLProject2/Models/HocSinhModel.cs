using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TTLProject2.Models
{
	public class HocSinhModel
	{
		[Required(ErrorMessage = "Bạn Chưa Nhập Mã Học Sinh")]
		[RegularExpression(@"^([A-Z]{2})+([0-9]{6})\b$", ErrorMessage = "2 kí tự đầu bắt buộc phải in hoa và tối đa 8 kí tự  ")]
		[Display(Name = "MaHocSinh")]
		public string? MaHocSinh { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Chọn Giới Tính")]
		public int MaGioiTinh { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Chọn Dân Tộc")]
		public int MaDanToc { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Chọn Trạng Thái")]
		public int MaTrangThai { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Chọn Quốc Tịch ")]
		public int MaQuocTich { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Chọn Mã Lớp")]
		public string? MaLop { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Nhập Họ Tên")]
		[Display(Name = "HoTen")]
		public string? HoTen { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Chọn Ngày Sinh")]
		[Display(Name = "NgaySinh")]
		public string? NgaySinh { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Nhập Địa Chỉ Nhà")]
		[Display(Name = "DiaChiNha")]
		public string? DiaChiNha { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Nhập Số Điện Thoại")]
		[RegularExpression(@"^(84|0[09]|0[07]|0[05])+([0-9]{8})\b$", ErrorMessage = "Số điện thoại phải đúng định dạng với 2 số đầu [09],[07],[05] và tối đa 10 số ")]
		[Display(Name = "SoDienThoai")]
		public string? SoDienThoai { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Nhập Họ Tên Bố ")]
		[Display(Name = "HoTenBo")]
		public string? HoTenBo { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Nhập Nghề Nghiệp  ")]
		[Display(Name = "NgheNghiep1")]
		public string? NgheNghiep1 { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Nhập Số Điện Thoại Bố")]
		[RegularExpression(@"^(84|0[09]|0[07]|0[05])+([0-9]{8})\b$", ErrorMessage = "Số điện thoại phải đúng định dạng với 2 số đầu [09],[07],[05] và tối đa 10 số ")]
		[Display(Name = "SoDienThoaiBo")]
		public string? SoDienThoaiBa { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Nhập Họ Tên Mẹ ")]
		[Display(Name = "HoTenMe")]
		public string? HoTenMe { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Nhập Nghề Nghiệp ")]
		[Display(Name = "NgheNghiep2")]
		public string? NgheNghiep2 { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Nhập Số Điện Thoại Mẹ")]
		[RegularExpression(@"^(84|0[09]|0[07]|0[05])+([0-9]{8})\b$", ErrorMessage = "Số điện thoại phải đúng định dạng với 2 số đầu [09],[07],[05] và tối đa 10 số ")]
		[Display(Name = "SoDienThoaiBo")]
		public string? SoDienThoaiMe { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Nhập Trường Tiểu Học ")]
		[Display(Name = "TruongHoc1")]
		public string? TruongHoc1 { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Nhập Trường THCS ")]
		[Display(Name = "TruongHoc2")]
		public string? TruongHoc2 { get; set; }

		public SelectList? DanhsachLopHoc { get; set; }

		public SelectList? DanhSachDanToc { get; set; }

		public SelectList? DanhSachQuocTich{ get; set; }

		public SelectList? DanhSachTrangThai { get; set; }

		public SelectList? DanhSachGioiTinh { get; set; }
	}
}
