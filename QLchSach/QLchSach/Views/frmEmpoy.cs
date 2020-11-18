using QLchSach.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLchSach
{
    public partial class frmEmpoy : Form
    {
        Dtb_NhaSachContext context = new Dtb_NhaSachContext();
        public frmEmpoy()
        {
            InitializeComponent();
        }

        private void frmEmpoy_Load(object sender, EventArgs e)
        {
            loadEmploy();
        }
        private void loadEmploy()
        {
            var employ = this.context.Nhanvien
                    .Where(n => n.MaNv == n.MaNv)
                    .Select(n => new
                    {
                        n.MaNv,n.TenNv,n.NgSinh,n.DiaChi,n.Sdt,n.Luong
                    })
                    .ToList();
            this.dgvEmploy.DataSource = employ;

            this.dgvEmploy.Columns["MaNv"].HeaderText = "Mã nhân viên";
            this.dgvEmploy.Columns["TenNv"].HeaderText = "Tên";
            this.dgvEmploy.Columns["NgSinh"].HeaderText = "Ngày sinh";
            this.dgvEmploy.Columns["DiaChi"].HeaderText = "Địa chỉ";
            this.dgvEmploy.Columns["Sdt"].HeaderText = "Số điện thoại";
            this.dgvEmploy.Columns["Luong"].HeaderText = "Lương";
        }
    }
}
