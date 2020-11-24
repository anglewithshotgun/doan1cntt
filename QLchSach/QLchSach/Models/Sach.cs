using System;
using System.Collections.Generic;

#nullable disable

namespace QLchSach.Models
{
    public partial class Sach
    {
        public int Stt { get; set; }
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public string MaTl { get; set; }
        public string MaNxb { get; set; }
        public string MaTg { get; set; }
        public int GiaBan { get; set; }

        public virtual Nxb MaNxbNavigation { get; set; }
        public virtual Tacgium MaTgNavigation { get; set; }
    }
}
