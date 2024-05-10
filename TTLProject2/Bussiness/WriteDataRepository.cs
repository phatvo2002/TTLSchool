using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using TTLProject2.Bussiness;
using TTLProject2.Entities;
using TlSchoolProject.Models;
using static Dapper.SqlMapper;
using TTLProject2.Models;

namespace TTLProject2.Bussiness
{
    public class WriteDataRepository : IWriteDataRepository
    {
        private readonly string? _connectionString;
        public WriteDataRepository(IOptions<AppSetting> setting)
        {
            _connectionString = setting.Value.ConnectionString;
        }

       
        public Task<IEnumerable<HocSinh>> DeleteHocSinh(string maHocSinh)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LopHoc>> DeleteLopHoc(string maLop)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                
                return await db.QueryAsync<LopHoc>("delete_lophoc_by_maLopHoc", new {Malop = maLop }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> InsertGiaoVien(GiaoVien giaoVien)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                DynamicParameters _params = new DynamicParameters();
                _params.Add("@maGiaoVien", giaoVien.MaGiaoVien);
                _params.Add("@hoTen", giaoVien.HoTen);
                _params.Add("@ngaySinh", giaoVien.NgaySinh);
                _params.Add("@CCCD", giaoVien.CCCD);
                _params.Add("@email", giaoVien.Email);
                _params.Add("@dienThoai", giaoVien.DienThoai);
                _params.Add("@queQuan", giaoVien.QueQuan);
                _params.Add("@soBaoHiemXaHoi", giaoVien.SoBaoHiemXaHoi);
                _params.Add("@password", giaoVien.Password);
                _params.Add("@maGioiTinh", giaoVien.MaGioiTinh);
                _params.Add("@maTongiao", giaoVien.MaTonGiao);
                _params.Add("@maDanToc", giaoVien.MaDanToc);
                _params.Add("@maTrangThai", giaoVien.MaTrangThai);
                _params.Add("@maMonHoc", giaoVien.MaMonHoc);
                _params.Add("@hinhAnh", giaoVien.HinhAnh);
                var result = await db.ExecuteAsync("Create_GiaoVien", _params, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> InsertHocSinh(HocSinhModel hocSinhModel)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                DynamicParameters _params = new DynamicParameters();
                _params.Add("@maHocSinh", hocSinhModel.MaHocSinh);
                _params.Add("@hoTen", hocSinhModel.HoTen);
                _params.Add("@ngaySinh", hocSinhModel.NgaySinh);
                _params.Add("@diaChiNha", hocSinhModel.DiaChiNha);
                _params.Add("@soDienThoai", hocSinhModel.SoDienThoai);
                _params.Add("@hoTenBo", hocSinhModel.HoTenBo);
                _params.Add("@ngheNghiep1", hocSinhModel.NgheNghiep1);
                _params.Add("@soDienThoaiBa", hocSinhModel.SoDienThoaiBa);
                _params.Add("@hoTenMe", hocSinhModel.HoTenMe);
                _params.Add("@ngheNghiep2", hocSinhModel.NgheNghiep2);
                _params.Add("@soDienThoaiMe", hocSinhModel.SoDienThoaiMe);
                _params.Add("@truongHoc1", hocSinhModel.TruongHoc1);
                _params.Add("@truongHoc2", hocSinhModel.TruongHoc2);
                _params.Add("@maDanToc", hocSinhModel.MaDanToc);
                _params.Add("@maGioiTinh", hocSinhModel.MaTrangThai);
                _params.Add("@maTrangThai", hocSinhModel.MaTrangThai);
                _params.Add("@maQuocTich", hocSinhModel.MaQuocTich);
                _params.Add("@maLop", hocSinhModel.MaLop);
                var result = await db.ExecuteAsync("Create_hocSinh", _params, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> InsertLopHoc(LopHocViewModel lopHocModel)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                DynamicParameters _params = new DynamicParameters();
                _params.Add("@maLop", lopHocModel.MaLopHoc);
                _params.Add("@tenLop", lopHocModel.TenLopHoc);
                _params.Add("@siSo", lopHocModel.SiSo);
                _params.Add("@hocNgoaiNgu", lopHocModel.HocNgoaiNgu);
                _params.Add("@maNienKhoa", lopHocModel.MaNienKhoa);
                _params.Add("@maKhoi", lopHocModel.MaKhoi);
                _params.Add("@maGiaoVien", lopHocModel.MaGiaoVien);
                var result = await db.ExecuteAsync("Create_lop", _params, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

       public async  Task<IEnumerable<GiaoVien>> DeleteGiaoVien(string maGiaoVien)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                DynamicParameters _params = new DynamicParameters();
                _params.Add("@magiaoVien", maGiaoVien);
                return await db.QueryAsync<GiaoVien>("delete_giaoVien", _params, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> DeleteGv(string magv)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {  
              return await db.ExecuteAsync("delete_giaoVien", new { MaGiaoVien = magv }, commandType: CommandType.StoredProcedure) > 0;
				
			}
            
        }

		public async Task<bool> DeleteHs(string mahs)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				return await db.ExecuteAsync("delete_hocsinh", new { maHocSinh = mahs }, commandType: CommandType.StoredProcedure) > 0;

			}
		}

		public async Task<bool> InsertUserRole(UserRoleModel userRoleModel)
		{

			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				DynamicParameters _params = new DynamicParameters();
                _params.Add("@idUser", userRoleModel.UserId);
                _params.Add("@idRole", userRoleModel.RoleId);
				var result = await db.ExecuteAsync("regist_phanquyen", _params, commandType: CommandType.StoredProcedure);
				return result > 0;
			}
		}

		public async Task<bool> DeleteUser(string id)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				return await db.ExecuteAsync("delete_user_by_id", new { userId = id }, commandType: CommandType.StoredProcedure) > 0;

			}
		}

        public async Task<bool> InsertThiSinh(DangKiViewModel dangkiModel)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                DynamicParameters _params = new DynamicParameters();
                _params.Add("@maNienKhoa", dangkiModel.MaNienKhoa);
                _params.Add("@maGioiTinh", dangkiModel.MaGioiTinh);
                _params.Add("@maDanToc", dangkiModel.MaDanToc);
                _params.Add("@maTonGiao", dangkiModel.MaTonGiao);
                _params.Add("@hoten", dangkiModel.HoTen);
                _params.Add("@ho", dangkiModel.Ho);
                _params.Add("@tenDem", dangkiModel.TenDem);
                _params.Add("@ten", dangkiModel.Ten);
                _params.Add("@ngaySinh", dangkiModel.NgaySinh);
                _params.Add("@noiSinh", dangkiModel.NoiSinh);
                _params.Add("@truongThcs", dangkiModel.TruongThcs);
                _params.Add("@namTotNghiep", dangkiModel.NamTotNghiep);
                _params.Add("@soDienThoai", dangkiModel.SoDienThoai);
                _params.Add("@diemTbm6", dangkiModel.DiemTb6);
                _params.Add("@hanhKiem6", dangkiModel.HanhKiem6);
                _params.Add("@hocLuc6", dangkiModel.HocLuc6);
                _params.Add("@diemTbm7", dangkiModel.DiemTb7);
                _params.Add("@hanhKiem7", dangkiModel.HanhKiem7);
                _params.Add("@hocLuc7", dangkiModel.HocLuc7);
                _params.Add("@diemTbm8", dangkiModel.DiemTb8);
                _params.Add("@hanhKiem8", dangkiModel.HanhKiem8);
                _params.Add("@hocLuc8", dangkiModel.HocLuc8);
                _params.Add("@diemTbm9", dangkiModel.DiemTb9);
                _params.Add("@hanhKiem9", dangkiModel.HanhKiem9);
                _params.Add("@hocLuc9", dangkiModel.HocLuc9);
                _params.Add("@hoTenBo", dangkiModel.HoTenBo);
                _params.Add("@ngheNghiepBo", dangkiModel.NgheNghiepBo);
                _params.Add("@soDienThoaiBo", dangkiModel.SoDienThoaiBo);
                _params.Add("@hoTenMe", dangkiModel.HoTenMe);
                _params.Add("@ngheNghiepMe", dangkiModel.NgheNghiepMe);
                _params.Add("@soDienThoaiMe", dangkiModel.SoDienThoaiMe);
                _params.Add("@diaChiThuongTru", dangkiModel.DiaChiThuongTru);
                _params.Add("@diaChiHienTai", dangkiModel.DiaChiHienTai);
                _params.Add("@diemThiTsToan", dangkiModel.DiemThiTsToan);
                _params.Add("@diemThiTsNguVan", dangkiModel.DiemThiTsNguVan);
                _params.Add("@diemThiTsTiengAnh", dangkiModel.DiemThiTsTiengAnh);
                _params.Add("@tongDiem", dangkiModel.TongDiem);
                _params.Add("@diaChiNhan", dangkiModel.DiaChiNhan);
                _params.Add("@hinhAnh", dangkiModel.HinhAnh);
                var result = await db.ExecuteAsync("regist_ThiSinh", _params, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

		public async Task<bool> InsertDiemThiSinh(DiemThiModel diem)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				DynamicParameters _params = new DynamicParameters();
                _params.Add("@maHocSinh", diem.MaHocSinh);
				_params.Add("@maHocKiNamHoc", diem.MaHocKiNamHoc);
				_params.Add("@maMonHoc", diem.MaMonHoc);
				_params.Add("@diemKiemTraMieng", diem.DiemKiemTraMieng);
				_params.Add("@diemKiemtra15l1", diem.Diem15PhutLan1);
				_params.Add("@diemKiemtra15l2", diem.Diem15PhutLan2);
				_params.Add("@diemkt1Tiet", diem.DiemKT1Tiet);
				_params.Add("@diemGk", diem.DiemGk);
				_params.Add("@diemCk", diem.DiemCk);
				_params.Add("@diemTbhk", diem.DiemTbHk);
				var result = await db.ExecuteAsync("regist_diem_hocsinh", _params, commandType: CommandType.StoredProcedure);
				return result > 0;
			}
		}

		public async Task<bool> UpdateHocSinh(HocSinhModel hocSinhModel)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				DynamicParameters _params = new DynamicParameters();
				_params.Add("@maHocSinh", hocSinhModel.MaHocSinh);
				_params.Add("@hoTen", hocSinhModel.HoTen);
				_params.Add("@ngaySinh", hocSinhModel.NgaySinh);
				_params.Add("@diaChiNha", hocSinhModel.DiaChiNha);
				_params.Add("@soDienThoai", hocSinhModel.SoDienThoai);
				_params.Add("@hoTenBo", hocSinhModel.HoTenBo);
				_params.Add("@ngheNghiep1", hocSinhModel.NgheNghiep1);
				_params.Add("@soDienThoaiBa", hocSinhModel.SoDienThoaiBa);
				_params.Add("@hoTenMe", hocSinhModel.HoTenMe);
				_params.Add("@ngheNghiep2", hocSinhModel.NgheNghiep2);
				_params.Add("@soDienThoaiMe", hocSinhModel.SoDienThoaiMe);
				_params.Add("@truongHoc1", hocSinhModel.TruongHoc1);
				_params.Add("@truongHoc2", hocSinhModel.TruongHoc2);
				_params.Add("@maDanToc", hocSinhModel.MaDanToc);
				_params.Add("@maGioiTinh", hocSinhModel.MaTrangThai);
				_params.Add("@maTrangThai", hocSinhModel.MaTrangThai);
				_params.Add("@maQuocTich", hocSinhModel.MaQuocTich);
				_params.Add("@maLop", hocSinhModel.MaLop);
				var result = await db.ExecuteAsync("update_thongtin_hocsinh", _params, commandType: CommandType.StoredProcedure);
				return result > 0;
			}
		}
	}
}
 