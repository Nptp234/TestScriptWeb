using System;
using System.Collections.Generic;
using System.Text;

namespace TestScriptWeb.Models
{
    class LoaiPhim
    {
        public string TenLP { get; set; }
        public string MoTaLP { get; set; }

        public LoaiPhim(string ten, string mota)
        {
            TenLP = ten;
            MoTaLP = mota;
        }
    }
}
