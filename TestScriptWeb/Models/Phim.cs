using System;
using System.Collections.Generic;
using System.Text;

namespace TestScriptWeb.Models
{
    class Phim
    {
        public string MaPhim { get; set; }
        public string TenPhim { get; set; }
        public string TomTatP { get; set; }
        public string NgayCongChieu { get; set; }
        public string ThoiLuongP { get; set; }
        public string HinhAnh { get; set; }
        public string Trailer { get; set; }
        public string GiaPhim { get; set; }
        public string MaGHT { get; set; }
        public string TenGHT { get; set; }

        public Phim() { }

        public Phim(string tenPhim, string tomTatP, string ngayCongChieu, string thoiLuongP, string hinhAnh, string trailer, string giaPhim, string maGHT)
        {
            TenPhim = tenPhim;
            TomTatP = tomTatP;
            NgayCongChieu = ngayCongChieu;
            ThoiLuongP = thoiLuongP;
            HinhAnh = hinhAnh;
            Trailer = trailer;
            GiaPhim = giaPhim;
            MaGHT = maGHT;
        }

        public Phim(string tenPhim, string tomTatP, string ngayCongChieu, string thoiLuongP, string hinhAnh, string trailer, string giaPhim, string maGHT, string tenGHT)
        {
            TenPhim = tenPhim;
            TomTatP = tomTatP;
            NgayCongChieu = ngayCongChieu;
            ThoiLuongP = thoiLuongP;
            HinhAnh = hinhAnh;
            Trailer = trailer;
            GiaPhim = giaPhim;
            MaGHT = maGHT;
            TenGHT = tenGHT;
        }
    }
}
