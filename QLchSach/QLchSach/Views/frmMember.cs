using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using QLchSach.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            var member = context.Thanhviens
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
            if (loiNhap())
            {
                return;
            }

            var context = new Dtb_NhaSachContext();
            int i = this.dgvMember.Rows.Count;
            var tv = new Thanhvien()
            {
                MaTv = int.Parse(this.dgvMember.Rows[i-1].Cells[0].Value.ToString().Trim()) + 1,
                TenTv = this.txtTentv.Text.Trim(),
                Sdt = this.txtSdt.Text.Trim(),
                NgaySinh = this.dtpNgaySinh.Value,
                DiaChi = this.txtDiaChi.Text.Trim(),
                DiemTichLuy = int.Parse(this.txtDiem.Text.Trim()),
            };
            context.Thanhviens.Add(tv);
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
            this.errThanhvien.SetError(this.txtTentv, null);
            this.errThanhvien.SetError(this.dtpNgaySinh, null);
            this.errThanhvien.SetError(this.txtDiaChi, null);
            this.errThanhvien.SetError(this.txtSdt, null);
            this.errThanhvien.SetError(this.txtDiem, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult xoa = MessageBox.Show("Đồng ý xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (xoa == DialogResult.Yes)
            {
                var context = new Dtb_NhaSachContext();
                var delete = new Thanhvien()
                {
                    MaTv = int.Parse(this.dgvMember.CurrentRow.Cells[0].Value.ToString().Trim()),
                };
                context.Remove<Thanhvien>(delete);
                context.SaveChanges();
                refreshControl();
                loadMember();
            }
        }
        private void dgvMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            refreshControl();
            this.txtMtv.Text = this.dgvMember.CurrentRow.Cells[0].Value.ToString().Trim();
            this.txtTentv.Text = this.dgvMember.CurrentRow.Cells[1].Value.ToString().Trim();
            this.dtpNgaySinh.Value = DateTime.Parse(this.dgvMember.CurrentRow.Cells[2].Value.ToString().Trim());
            this.txtSdt.Text = this.dgvMember.CurrentRow.Cells[3].Value.ToString().Trim();
            this.txtDiaChi.Text = this.dgvMember.CurrentRow.Cells[4].Value.ToString().Trim();           
            this.txtDiem.Text = this.dgvMember.CurrentRow.Cells[5].Value.ToString().Trim();

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (loiNhap())
            {
                return;
            }
            var context = new Dtb_NhaSachContext();
            var edit = new Thanhvien()
            {
                MaTv = int.Parse(this.dgvMember.CurrentRow.Cells[0].Value.ToString().Trim()),               
            };
            edit.TenTv = this.txtTentv.Text.Trim();
            edit.NgaySinh = this.dtpNgaySinh.Value;
            edit.DiaChi = this.txtDiaChi.Text.Trim();
            edit.DiemTichLuy = int.Parse(this.txtDiem.Text.Trim());
            edit.Sdt = this.txtSdt.Text.Trim();
            context.Update<Thanhvien>(edit);
            context.SaveChanges();
            refreshControl();
            loadMember();
        }
        public bool loiNhap()
        {
            if (this.txtTentv.Text.Trim().Length <= 0)
            {
                this.errThanhvien.SetError(this.txtTentv, "Nhập tên thành viên");
                return true;
            }
            else this.errThanhvien.SetError(this.txtTentv, null);


            //if (this.dtpNgaySinh.Text.Trim().Length <= 0)
            //{
            //    this.errThanhvien.SetError(this.dtpNgaySinh, "Nhập ngày sinh");
            //    return true;
            //}
            //else this.errThanhvien.SetError(this.dtpNgaySinh, null);


            if (this.txtDiaChi.Text.Trim().Length <= 0)
            {
                this.errThanhvien.SetError(this.txtDiaChi, "Nhập địa chỉ");
                return true;
            }
            else this.errThanhvien.SetError(this.txtDiaChi, null);


            if (this.txtSdt.Text.Trim().Length <= 0)
            {
                this.errThanhvien.SetError(this.txtSdt, "Nhập số điện thoại");
                return true;
            }
            else this.errThanhvien.SetError(this.txtSdt, null);


            if (this.txtDiem.Text.Trim().Length <= 0)
            {
                this.errThanhvien.SetError(this.txtDiem, "Nhập điểm tích lũy");
                return true;
            }
            else this.errThanhvien.SetError(this.txtDiem, null);           

            return false;
        }
    }
}
