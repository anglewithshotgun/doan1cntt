using System;
using System.Collections.Generic;

#nullable disable

namespace QLchSach.Models
{
    public partial class Thanhvien
    {
        public int MaTv { get; set; }
        public string TenTv { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public int DiemTichLuy { get; set; }
    }
}
