using TTLProject2.Entities;
using TTLProject2.Models;

namespace TTLProject2.Bussiness
{
    public interface IReadataRepository
    {
        Task<IEnumerable<DanToc>> GetDanToc();

        Task<IEnumerable<GioiTinh>> GetGioiTinh();

        Task<IEnumerable<Khoi>> GetKhois();

        Task<IEnumerable<TonGiao>> GetTonGiao();

        Task<IEnumerable<QuocTich>> GetQuocTich();

        Task<IEnumerable<MonHoc>> GetMonHoc();

        Task<IEnumerable<TrangThai>> GetTrangThai();

        Task<IEnumerable<NienKhoa>> GetNienKhoa();

        Task<IEnumerable<HocKiNamHoc>> GetHocKiNamHoc();
        
        Task<IEnumerable<GiaoVien>> GetGiaoViens();

		Task<IEnumerable<GiaoVien>> GetGiaoVienById(string maGiaoVien);

        Task<IEnumerable<HocSinh>> GetHocSinh();

        Task<IEnumerable<LopHoc>> GetLopHoc();

        Task<IEnumerable<Role>> GetAllRole();

        Task<IEnumerable<User>> GetAllUser();

        Task<bool> CheckLopHocExist(string maLop, string tenLop);

        Task<bool> CheckLopHoExistByMagiaovien (string magiaovien);
             
        Task<bool> CheckHocSinhExistByMahocsinh(string maHocSinh);

        Task<bool> CheckHocSinhExistByTenhocsinh(string tenHocSinh);

        Task<bool> CheckGiaoVienExistByMagiaovien(string magiaovien);

        Task<bool> CheckGiaoVienExistbyTenGiaoVien(string tengiaovien);

        Task<bool> CheckGiaoVienExistInLop(string magiaovien);

        Task<bool> CheckUserExistById(string id);

        Task<HocSinhModel> GetHocSinhByID(string id);
	}
}

