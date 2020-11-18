using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
    public partial class frmMember : Form
    {
        public frmMember()
        {
            InitializeComponent();
        }
        public void loadMember()
        {
            var context = new Dtb_NhaSachContext();
            var member = context.Thanhvien
                .Where(m => m.MaTv == m.MaTv)
                .ToList();
            this.dgvMember.DataSource = member;

            this.dgvMember.Columns["MaTv"].HeaderText = "Mã thành viên";
            this.dgvMember.Columns["TenTv"].HeaderText = "Tên";
            this.dgvMember.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            this.dgvMember.Columns["Sdt"].HeaderText = "Số điện thoại";
            this.dgvMember.Columns["DiaChi"].HeaderText = "Địa chỉ";
            this.dgvMember.Columns["DiemTichLuy"].HeaderText = "Điểm tích lũy";
        }

        private void frmMember_Load(object sender, EventArgs e)
        {
            loadMember();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var context = new Dtb_NhaSachContext();
            var tv = new Thanhvien()
            {
                MaTv = context.Thanhvien.Count() + 1,
                TenTv = this.txtTentv.Text.Trim(),
                Sdt = this.txtSdt.Text.Trim(),
                NgaySinh = this.dtpNgaySinh.Value,
                DiaChi = this.txtDiaChi.Text.Trim(),
                DiemTichLuy = int.Parse(this.txtDiem.Text.Trim()),
            };
            context.Thanhvien.Add(tv);
            context.SaveChanges();
            refreshControl();
            loadMember();
        }
        private void refreshControl()
        {
            this.txtMtv.Text = null;
            this.txtSdt.Text = null;
            this.txtDiem.Text = null;
            this.txtTentv.Text = null;
            this.txtDiaChi.Text = null;
            this.dtpNgaySinh.Value = DateTime.Now;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void dgvMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtMtv.Text = this.dgvMember.CurrentRow.Cells[0].Value.ToString();
            this.txtTentv.Text = this.dgvMember.CurrentRow.Cells[1].Value.ToString();
            //this.dtpNgaySinh.Value = DateTime.Parse(this.dgvMember.CurrentRow.Cells[2].Value);
            this.txtSdt.Text = this.dgvMember.CurrentRow.Cells[3].Value.ToString();
            this.txtDiaChi.Text = this.dgvMember.CurrentRow.Cells[4].Value.ToString();           
            this.txtDiem.Text = this.dgvMember.CurrentRow.Cells[5].Value.ToString();

        }
    }
}
