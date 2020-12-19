using System;
using System.Collections.Generic;

#nullable disable

namespace QLchSach.Models
{
    public partial class Theloai
    {
        public Theloai()
        {
            Saches = new HashSet<Sach>();
        }

        public string MaTl { get; set; }
        public string TenTl { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
