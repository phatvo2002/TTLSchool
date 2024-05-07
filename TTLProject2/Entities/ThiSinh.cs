using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace TTLProject2.Entities
{
	public class ThiSinh
	{
		public int  MaThiSinh { get; set; }
		public  int  MaNienKhoa { get; set; }

		 public int MaGioiTinh {  get; set; }
		
		public int MaDanToc {  get; set; }

		public int MaTonGiao { get; set; }

		public string? HoTen {  get; set; }

		public string? Ho {  get; set; }

		public string? TenDem { get; set; }

		public string? Ten {  get; set; }

		public string? NgaySinh { get; set; }

		public string? NoiSinh { get; set; }

		public string? TruongThcs {  get; set; }

	    public string? DiaChiThuongTru { get; set; }

		public string? DiaChiHienTai { get; set; }

		public string? NamTotNghiep {  get; set; }

		public string? XepLoaiTotNghiep { get; set; }

		public string? SoDienThoai { get; set; }

		public string? HoTenBo {  get; set; }

		public string? NgheNghiepBo { get; set; }

		public string? SoDienThoaiBo { get; set; }

		public string? HotTenMe { get; set; }

		public string? NgheNghiepMe { get; set; }

		public string? SoDienThoaiMe { get; set; }

		public float? DiemTb6 {  get; set; }

		public string? HanhKiem6 { get; set; }

		public string? HocLuc6 { get; set; }

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

		public float? DiemThiTsNguVan {  get; set; }

		public float? DiemThiTsTiengAnh { get; set; }

		public float? TongDiem { get
			{
				float? tongdiem = 0;
				tongdiem = (DiemThiTsToan * 2) + (DiemThiTsNguVan * 2) + DiemThiTsTiengAnh; 
				return tongdiem;
             }
			set { TongDiem = value; }
		}

		public string? DiaChiNhan { get; set; }

		public string? HinhAnh { get; set; }


	}
}
