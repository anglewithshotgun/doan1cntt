using System;
using System.Collections.Generic;

namespace QLchSach.Models
{
    public partial class Tacgia
    {
        public Tacgia()
        {
            Sach = new HashSet<Sach>();
        }

        public string MaTg { get; set; }
        public string TenTg { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}
