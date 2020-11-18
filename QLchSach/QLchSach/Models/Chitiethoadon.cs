using System;
using System.Collections.Generic;

namespace QLchSach.Models
{
    public partial class Chitiethoadon
    {
        public string MaSach { get; set; }
        public int SoHd { get; set; }
        public int? SoLuongBan { get; set; }
        public double? Gia { get; set; }

        public virtual Hoadon SoHdNavigation { get; set; }
    }
}
