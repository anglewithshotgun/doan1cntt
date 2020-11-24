using System;
using System.Collections.Generic;

#nullable disable

namespace QLchSach.Models
{
    public partial class Nxb
    {
        public Nxb()
        {
            Saches = new HashSet<Sach>();
        }

        public string MaNxb { get; set; }
        public string TenNxb { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
