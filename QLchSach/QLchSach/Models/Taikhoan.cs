using System;
using System.Collections.Generic;

namespace QLchSach.Models
{
    public partial class Taikhoan
    {
        public string TaiKhoan1 { get; set; }
        public string MatKhau { get; set; }

        public virtual Nhanvien TaiKhoan1Navigation { get; set; }
    }
}
