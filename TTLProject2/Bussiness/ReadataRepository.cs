﻿using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using TlSchoolProject.Models;
using TTLProject2.Bussiness;
using TTLProject2.Entities;
using TTLProject2.Models;

namespace TTLProject2.Bussiness
{
    public class ReadataRepository : IReadataRepository
    {
        private readonly string? _connectionString;

        public ReadataRepository(IOptions<AppSetting> setting)
        {
            _connectionString = setting.Value.ConnectionString;
        }

		public async Task<bool> CheckGiaoVienExistByMagiaovien(string magiaovien)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				int result;
				var _params = new DynamicParameters();
				_params.Add("@maGiaoVien", magiaovien);
				_params.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
				var RS = await db.ExecuteAsync("check_giaoVien_exist_by_maGiaoVien ", _params, commandType: CommandType.StoredProcedure);
				result = _params.Get<Int32>("@Result");
				return result == 1 ? true : false;
			}
		}

		public async Task<bool> CheckGiaoVienExistbyTenGiaoVien(string tengiaovien)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				int result;
				var _params = new DynamicParameters();
				_params.Add("@tenGiaoVien", tengiaovien);
				_params.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
				var RS = await db.ExecuteAsync("check_giaoVien_exist_by_tenGiaoVien ", _params, commandType: CommandType.StoredProcedure);
				result = _params.Get<Int32>("@Result");
				return result == 1 ? true : false;
			}
		}

		public async Task<bool> CheckGiaoVienExistInLop(string magiaovien)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				int result;
				var _params = new DynamicParameters();
				_params.Add("@maGiaoVien", magiaovien);
				_params.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
				var RS = await db.ExecuteAsync("check_giaovien_exist_in_lophoc ", _params, commandType: CommandType.StoredProcedure);
				result = _params.Get<Int32>("@Result");
				return result == 1 ? true : false;
			}
		}

		public async Task<bool> CheckHocSinhExistByMahocsinh(string maHocSinh)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
				int result;
				var _params = new DynamicParameters();
				_params.Add("@maHocSinh", maHocSinh);
				_params.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
				var RS = await db.ExecuteAsync("check_hocsinh_exist_by_mahocsinh ", _params, commandType: CommandType.StoredProcedure);
				result = _params.Get<Int32>("@Result");
				return result == 1 ? true : false;
			}
        }

		public async Task<bool> CheckHocSinhExistByTenhocsinh(string tenHocSinh)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				int result;
				var _params = new DynamicParameters();
				_params.Add("@hoTen", tenHocSinh);
				_params.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
				var RS = await db.ExecuteAsync("check_hocsinh_exist_by_tenhocsinh ", _params, commandType: CommandType.StoredProcedure);
				result = _params.Get<Int32>("@Result");
				return result == 1 ? true : false;
			}
		}

		public async Task<bool> CheckLopHocExist(string? maLop, string? tenLop)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result;
                var _params = new DynamicParameters();
                _params.Add("@maLop", maLop);
                _params.Add("@tenlop", tenLop);
                _params.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                var RS = await db.ExecuteAsync("check_lophoc_exist ", _params, commandType: CommandType.StoredProcedure);
                result = _params.Get<Int32>("@Result");
                return result == 1 ? true : false;
            }
        }

		public async Task<bool> CheckLopHoExistByMagiaovien(string magiaovien)
		{
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
				int result;
				var _params = new DynamicParameters();
				_params.Add("@maGiaoVien", magiaovien);
				_params.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
				var RS = await db.ExecuteAsync("check_lophoc_by_giaovien ", _params, commandType: CommandType.StoredProcedure);
				result = _params.Get<Int32>("@Result");
				return result == 1 ? true : false;
			}
				
		}

		public async Task<bool> CheckUserExistById(string id)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				int result;
				var _params = new DynamicParameters();
				_params.Add("@userId", id);
				_params.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
				var RS = await db.ExecuteAsync("check_role_exist_by_userid ", _params, commandType: CommandType.StoredProcedure);
				result = _params.Get<Int32>("@Result");
				return result == 1 ? true : false;
			}
		}

		public async Task<IEnumerable<Role>> GetAllRole()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
               
                    return await db.QueryAsync<Role>("getall_Roles", commandType: CommandType.StoredProcedure);
                
            }
        }
        public async Task<IEnumerable<User>> GetAllUser()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                return await db.QueryAsync<User>("getall_user", commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<IEnumerable<DanToc>> GetDanToc()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<DanToc>("getall_danToc", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<GiaoVien>> GetGiaoVienById(string id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
               return await db.QueryAsync<GiaoVien>("getGiaoVien_byMaGiaoVien",new { maGiaoVien = id}, commandType: CommandType.StoredProcedure);
            }    
        }

        public async Task<IEnumerable<GiaoVien>> GetGiaoViens()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<GiaoVien>("getall_giaoVienv2", commandType: CommandType.StoredProcedure);
            }
        }



        public async Task<IEnumerable<GioiTinh>> GetGioiTinh()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<GioiTinh>("getall_gioiTinh", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<HocKiNamHoc>> GetHocKiNamHoc()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<HocKiNamHoc>("getall_hocKiNamHoc", commandType: CommandType.StoredProcedure);
            }
        }

		public async Task<IEnumerable<HocSinh>> GetHocSinh()
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				return await db.QueryAsync<HocSinh>("getall_hocSinh", commandType: CommandType.StoredProcedure);
			}
		}

		public async Task<HocSinhModel> GetHocSinhByID(string id)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
                var _params = new DynamicParameters();
                _params.Add("@maHocSinh", id);
                return await db.QuerySingleOrDefaultAsync<HocSinhModel>("gethocsinh_by_maHocSinh", _params, commandType: CommandType.StoredProcedure);
			}
		}

		public async Task<IEnumerable<Khoi>> GetKhois()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<Khoi>("getall_khoi", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<LopHoc>> GetLopHoc()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<LopHoc>("getall_lop", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<MonHoc>> GetMonHoc()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<MonHoc>("getall_monHoc", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<NienKhoa>> GetNienKhoa()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<NienKhoa>("getall_nienKhoa", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<QuocTich>> GetQuocTich()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<QuocTich>("getall_quocTich", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TonGiao>> GetTonGiao()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<TonGiao>("getall_tonGiao", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TrangThai>> GetTrangThai()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<TrangThai>("getall_trangThai", commandType: CommandType.StoredProcedure);
            }
        }
    }
}