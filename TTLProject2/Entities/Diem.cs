using NuGet.Versioning;
using System.ComponentModel.DataAnnotations;

namespace TTLProject2.Entities
{
    public class Diem
    {
        public string? MaHocSinh { get; set; }

        public string? MaHocKiNamHoc { get; set; }

        public int MaMonHoc { get; set; }

        public float DiemKiemTraMieng { get; set; }

        public float Diem15PhutLan1 { get; set; }

        public float Diem15PhutLan2 { get; set; }

        public float DiemKiemTra1Tiet {  get; set; }

        public float DiemGk {  get; set; }

        public float DiemCk { get; set; }

        public float DiemTbHk { get {
                var diemKtMieng  = DiemKiemTraMieng;
                var diemKt15Phut1 = Diem15PhutLan1;
                var diemKt15Phut2 = Diem15PhutLan2;
                var diemKt1Tiet = DiemKiemTra1Tiet;
                var diemGk = DiemGk;
                var diemCk = DiemCk;
                var total = ((diemKtMieng + diemKt15Phut1 + diemKt15Phut2 + diemKt1Tiet) + (diemGk * 2) + (diemCk * 3)) / (4+5);
                return total;
            } }

    }
}
