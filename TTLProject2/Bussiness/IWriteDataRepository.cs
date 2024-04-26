using Microsoft.AspNetCore.Mvc;
using TTLProject2.Entities;
using TTLProject2.Models;

namespace TTLProject2.Bussiness
{
    public interface IWriteDataRepository
    {
       
        Task<bool> InsertGiaoVien(GiaoVien giaoVien);

        Task<bool> DeleteGiaoVien(string id);

        Task<bool> InsertHocSinh(HocSinhModel hocSinhModel);

        Task<bool> InsertLopHoc(LopHocViewModel lopHocModel);

        Task<IEnumerable<LopHoc>> DeleteLopHoc(string maLop);

		Task<IEnumerable<HocSinh>> DeleteHocSinh(string maHocSinh);



	}
}
