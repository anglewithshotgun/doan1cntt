using Microsoft.EntityFrameworkCore;
using QLchSach.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLchSach
{
    
    public partial class frmListBill : Form
    {
        
        public frmListBill()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmBill formBill = new frmBill();
            formBill.ShowDialog();
        }
        private void frmListBill_Load(object sender, EventArgs e)
        {
            
            LoadDtgv();
        }
        private void LoadDtgv()
        {
            //var hd = con.Hoadon.AsNoTracking().ToList();
            //dgvListBill.DataSource = hd;
            var context = new Dtb_NhaSachContext();
            var showData = context.Hoadon
                            .Where(h => h.SoHd == h.SoHd)
                            .Select(h => new
                            {
                                h.SoHd, h.MaNv, h.NgayBan,h.TenKh,h.MaTv,h.ThanhTien
                            })
                            .ToList();          
            this.dgvListBill.DataSource = showData;

            //Chỉnh tên cột
            this.dgvListBill.Columns["SoHd"].HeaderText = "Mã hóa đơn";
            this.dgvListBill.Columns["Manv"].HeaderText = "Mã nhân viên";
            this.dgvListBill.Columns["NgayBan"].HeaderText = "Ngày bán";
            this.dgvListBill.Columns["TenKh"].HeaderText = "Tên khách hàng";
            this.dgvListBill.Columns["MaTv"].HeaderText = "Mã thành viên";  
            this.dgvListBill.Columns["ThanhTien"].HeaderText = "Thành tiền";

        }
    }
}
