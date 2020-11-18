using System;
using System.Collections.Generic;

namespace QLchSach.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiethoadon = new HashSet<Chitiethoadon>();
        }

        public int SoHd { get; set; }
        public string MaNv { get; set; }
        public DateTime? NgayBan { get; set; }
        public string TenKh { get; set; }
        public int? MaTv { get; set; }
        public double? ThanhTien { get; set; }

        public virtual Nhanvien MaNvNavigation { get; set; }
        public virtual ICollection<Chitiethoadon> Chitiethoadon { get; set; }
    }
}
