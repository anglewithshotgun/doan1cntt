using System;
using System.Collections.Generic;

#nullable disable

namespace QLchSach.Models
{
    public partial class Tacgium
    {
        public Tacgium()
        {
            Saches = new HashSet<Sach>();
        }

        public string MaTg { get; set; }
        public string TenTg { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
