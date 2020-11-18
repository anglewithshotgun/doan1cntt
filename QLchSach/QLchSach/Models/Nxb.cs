using System;
using System.Collections.Generic;

namespace QLchSach.Models
{
    public partial class Nxb
    {
        public Nxb()
        {
            Sach = new HashSet<Sach>();
        }

        public string MaNxb { get; set; }
        public string TenNxb { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}
