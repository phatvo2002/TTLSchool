using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TTLProject2.Models
{
	public class DiemThiModel
	{
		[Required(ErrorMessage ="Bạn Chưa Chọn Học Sinh  ")]
		public string? MaHocSinh { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Chọn Học Kì ")]
		public string? MaHocKiNamHoc { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Chọn Môn Học  ")]
		[Display(Name = "MaMonHoc")]
		public int MaMonHoc { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Nhập điêm Kiểm tra miệng ")]
		[Display(Name = "DiemKiemTraMieng")]
		public float DiemKiemTraMieng { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Nhập điêm Kiểm tra 15 phút ")]
		[Display(Name = "DiemKiemTraMieng")]
		public float Diem15PhutLan1 { get; set; }

		public float Diem15PhutLan2 { get; set; }

		public float DiemKT1Tiet { get; set; }

		public float DiemGk { get; set; }

		public float DiemCk { get; set; }

		public string? MaLop {  get; set; }

		public float DiemTbHk
		{
		   get; set;
		}

		public SelectList? DanhSachMonHoc { get; set; }

		public SelectList? DanhSachHocSinh { get;set; }

		public SelectList? DanhSachHocKiNamHoc { get; set; }
	}
}
