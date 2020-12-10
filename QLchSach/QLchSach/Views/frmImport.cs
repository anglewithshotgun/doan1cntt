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
    public partial class frmImport : Form
    {
        Dtb_NhaSachContext context = new Dtb_NhaSachContext();
        public frmImport()
        {
            InitializeComponent();
        }

        private void frmImport_Load(object sender, EventArgs e)
        {
            loadImport();
        }
        private void loadImport()
        {
            //var import = this.context.Phieunhap
            //    .Where(p => p.SoPn == p.SoPn)
            //    .Select(p => new
            //    {
            //        p.SoPn,
            //        p.NgayNhap,
            //        p.MaNxb,
            //        p.MaNv,
            //        p.ThanhTien
            //    }).ToList();
            //this.dgvImport.DataSource = import;

            //this.dgvImport.Columns["SoPn"].HeaderText = "Mã hóa đơn";
            //this.dgvImport.Columns["NgayNhap"].HeaderText = "Ngày nhập";
            //this.dgvImport.Columns["MaNxb"].HeaderText = "Mã nhà xuất bản";
            //this.dgvImport.Columns["MaNv"].HeaderText = "Mã nhân viên";
            //this.dgvImport.Columns["ThanhTien"].HeaderText = "Thành tiền";
        }   
    }
}
