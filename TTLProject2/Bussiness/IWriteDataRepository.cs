using Microsoft.AspNetCore.Mvc;
using TTLProject2.Entities;
using TTLProject2.Models;

namespace TTLProject2.Bussiness
{
    public interface IWriteDataRepository
    {
       
        Task<bool> InsertGiaoVien(GiaoVien giaoVien);
        Task<bool> InsertHocSinh(HocSinhModel hocSinhModel);

        Task<bool> InsertUserRole(UserRoleModel userRoleModel);

        Task<bool> UpdateHocSinh(HocSinhModel hocSinhModel);

        Task<bool> InsertLopHoc(LopHoc lopHocModel);

        Task<bool> InsertThiSinh(ThiSinh dangkiModel);

        Task<bool> InsertDiemThiSinh(DiemThiModel diem );

        Task<IEnumerable<LopHoc>> DeleteLopHoc(string maLop);

		Task<IEnumerable<HocSinh>> DeleteHocSinh(string maHocSinh);

        Task<IEnumerable<GiaoVien>> DeleteGiaoVien(string maGiaoVien);


        Task<bool> DeleteGv(string magv);

        Task<bool> DeleteHs(string mahs);

        Task<bool> DeleteUser(string id);
	}
}
