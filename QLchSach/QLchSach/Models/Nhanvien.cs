using System;
using System.Collections.Generic;

#nullable disable

namespace QLchSach.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public string MaNv { get; set; }
        public string TenNv { get; set; }
        public DateTime? NgSinh { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public double? Luong { get; set; }

        public virtual Taikhoan Taikhoan { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
