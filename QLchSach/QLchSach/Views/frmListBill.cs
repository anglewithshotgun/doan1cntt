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
            var context = new Dtb_NhaSachContext();
            var showData = context.Hoadons
                            .Where(h => h.SoHd == h.SoHd)
                            .Select(h => new
                            {
                                h.SoHd, h.MaNv, h.NgayBan,h.TenKh,h.MaTv,h.TongTien
                            })
                            .ToList();          
            this.dgvListBill.DataSource = showData;

            //Chỉnh tên cột
            this.dgvListBill.Columns["SoHd"].HeaderText = "Mã hóa đơn";
            this.dgvListBill.Columns["Manv"].HeaderText = "Mã nhân viên";
            this.dgvListBill.Columns["NgayBan"].HeaderText = "Ngày bán";
            this.dgvListBill.Columns["TenKh"].HeaderText = "Tên khách hàng";
            this.dgvListBill.Columns["MaTv"].HeaderText = "Mã thành viên";  
            this.dgvListBill.Columns["TongTien"].HeaderText = "Tổng tiền";
        }

        private void dgvListBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            refresh();
            this.txtMahd.Text = this.dgvListBill.CurrentRow.Cells[0].Value.ToString().Trim();
            this.txtManv.Text = this.dgvListBill.CurrentRow.Cells[1].Value.ToString().Trim();
            this.dtpNgayBan.Value = DateTime.Parse(this.dgvListBill.CurrentRow.Cells[2].Value.ToString().Trim());
            this.txtKhachHang.Text = this.dgvListBill.CurrentRow.Cells[3].Value.ToString().Trim();
            this.txtThanhTien.Text = this.dgvListBill.CurrentRow.Cells[5].Value.ToString().Trim();
        }
        public void refresh()
        {
            this.txtMahd.Text = null;
            this.txtThanhTien.Text = null;
            this.txtKhachHang.Text = null;
            this.txtManv.Text = null;
            this.dtpNgayBan.Value = DateTime.Now;
        }
        private void dgvListBill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmBill newform = new frmBill();
            newform.cbbTimKiemCthd.Text = this.dgvListBill.CurrentRow.Cells[0].Value.ToString().Trim();
            newform.ShowDialog();
            
        }
    }
}
