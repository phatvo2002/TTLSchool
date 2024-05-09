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

        Task<IEnumerable<Diem>> GetHocSinhLop10A1();

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

        Task<IEnumerable<HocSinh>> GetHocSinh10a1();

        Task<IEnumerable<Diem>> GetHocSinh10a1MonToan();

		Task<IEnumerable<Diem>> GetHocSinh10a1MonNguVan();

		Task<IEnumerable<Diem>> GetHocSinh10a1MonNgoaiNgu();

		Task<IEnumerable<Diem>> GetHocSinh10a1MonSinhHoc();

		Task<IEnumerable<Diem>> GetHocSinh10a1MonHoaHoc();

		Task<IEnumerable<Diem>> GetHocSinh10a1MonVayLy();

		Task<IEnumerable<Diem>> GetHocSinh10a1LichSu();

		Task<IEnumerable<Diem>> GetHocSinh10a1MonDiaLy();

		Task<IEnumerable<Diem>> GetHocSinh10a1MonGDCD();

		Task<IEnumerable<MonHoc>> GetMonToan();


		Task<IEnumerable<MonHoc>> GetMonNGuVan();

		Task<IEnumerable<MonHoc>> GetMonTiengAnh();

		Task<IEnumerable<MonHoc>> GetMonHoaHoc();

		Task<IEnumerable<MonHoc>> GetMonVatLy();

		Task<IEnumerable<MonHoc>> GetMonSinhHoc();

		Task<IEnumerable<MonHoc>> GetMonDiaLy();

		Task<IEnumerable<MonHoc>> GetMonLichSu();

		Task<IEnumerable<MonHoc>> GetMonGDCD();
	}
}

