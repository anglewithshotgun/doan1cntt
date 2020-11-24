using System;
using System.Collections.Generic;

#nullable disable

namespace QLchSach.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiethoadons = new HashSet<Chitiethoadon>();
        }

        public int SoHd { get; set; }
        public string MaNv { get; set; }
        public DateTime? NgayBan { get; set; }
        public string TenKh { get; set; }
        public int? MaTv { get; set; }
        public double? ThanhTien { get; set; }

        public virtual Nhanvien MaNvNavigation { get; set; }
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
    }
}
