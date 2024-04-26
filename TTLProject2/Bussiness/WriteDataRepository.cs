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

        public async Task<bool> DeleteGiaoVien(string id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                DynamicParameters _params = new DynamicParameters();
                _params.Add("@maLop", id);
                return await db.ExecuteAsync("delete_lophoc_by_maLopHoc", _params, commandType: CommandType.StoredProcedure) > 0;
            }
        }

		public Task<IEnumerable<HocSinh>> DeleteHocSinh(string maHocSinh)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<LopHoc>> DeleteLopHoc(string maLop)
        {
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
                DynamicParameters _params = new DynamicParameters();
                _params.Add("@maLopHoc", maLop);
                return await db.QueryAsync<LopHoc>("delete_lophoc_by_maLopHoc", _params, commandType: CommandType.StoredProcedure) ;
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
                _params.Add("@soDienThoaiBa", hocSinhModel.SoDienThoaiBo);
                _params.Add("@hoTenMe", hocSinhModel.HoTenMe);
                _params.Add("@ngheNghiep2", hocSinhModel.NgheNghiep2);
                _params.Add("@soDienThoaiMe", hocSinhModel.SoDienThoaiMe);
                _params.Add("@truongHoc1", hocSinhModel.TruongHoc1);
                _params.Add("@truongHoc2", hocSinhModel.MaGioiTinh);
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
    }
}
