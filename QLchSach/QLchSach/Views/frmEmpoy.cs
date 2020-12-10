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
        //Dtb_NhaSachContext context = new Dtb_NhaSachContext();
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
            var context = new Dtb_NhaSachContext();
            var employ = context.Nhanviens
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (loiNhap() == true)
            {
                return;
            }
            var context = new Dtb_NhaSachContext();
            var cEmploy = context.Nhanviens
                    .Where(s => s.MaNv.Trim() == this.txtManv.Text.Trim())
                    .Select(s => s.MaNv).ToList();
            if (cEmploy.Count > 0)
            {
                this.errEmploy.SetError(this.txtManv, "Mã nhân viên không được trùng");
                return;
            }
            else this.errEmploy.SetError(this.txtManv, null);

            try
            {
                int i = this.dgvEmploy.Rows.Count;
                var nv = new Nhanvien()
                {
                    MaNv = this.txtManv.Text.Trim(),
                    TenNv = this.txtTenNv.Text.Trim(),
                    Sdt = this.txtSdt.Text.Trim(),
                    NgSinh = this.dtpNgaySinh.Value,
                    DiaChi = this.txtDiaChi.Text.Trim(),
                    Luong = int.Parse(this.txtLuong.Text.Trim()),
                };
                context.Nhanviens.Add(nv);
                context.SaveChanges();
                refreshControl();
                loadEmploy();
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi. Vui lòng thử lại!");
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (loiNhap() == true)
            {
                return;
            }

            var context = new Dtb_NhaSachContext();
            if (this.txtManv.Text.Trim() != this.dgvEmploy.CurrentRow.Cells[0].Value.ToString().Trim())
            {
                var cEmploy = context.Nhanviens
                    .Where(s => s.MaNv.Trim() == this.txtManv.Text.Trim())
                    .Select(s => s.MaNv).ToList();
                if (cEmploy.Count > 0)
                {
                    this.errEmploy.SetError(this.txtManv, "Mã nhân viên không được trùng");
                    return;
                }
                else this.errEmploy.SetError(this.txtManv, null);
            }
            
            try
            {
                var edit = new Nhanvien()
                {
                    MaNv = this.txtManv.Text.Trim(),
                };
                edit.TenNv = this.txtTenNv.Text.Trim();
                edit.NgSinh = this.dtpNgaySinh.Value;
                edit.DiaChi = this.txtDiaChi.Text.Trim();
                edit.Luong = int.Parse(this.txtLuong.Text.Trim());
                edit.Sdt = this.txtSdt.Text.Trim();
                context.Update<Nhanvien>(edit);
                context.SaveChanges();
                refreshControl();
                loadEmploy();
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi. Vui lòng thử lại!");
                return;
            }
        }

        private void dgvEmploy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            refreshControl();
            this.txtManv.Text = this.dgvEmploy.CurrentRow.Cells[0].Value.ToString().Trim();
            this.txtTenNv.Text = this.dgvEmploy.CurrentRow.Cells[1].Value.ToString().Trim();
            this.dtpNgaySinh.Value = DateTime.Parse(this.dgvEmploy.CurrentRow.Cells[2].Value.ToString().Trim());
            this.txtSdt.Text = this.dgvEmploy.CurrentRow.Cells[4].Value.ToString().Trim();
            this.txtDiaChi.Text = this.dgvEmploy.CurrentRow.Cells[3].Value.ToString().Trim();
            this.txtLuong.Text = this.dgvEmploy.CurrentRow.Cells[5].Value.ToString().Trim();
        }
        public bool loiNhap()
        {
            if (this.txtManv.Text.Trim().Length <= 0)
            {
                this.errEmploy.SetError(this.txtManv, "Nhập tên nhân viên");
                return true;
            }
            else this.errEmploy.SetError(this.txtManv, null);

            if (this.txtTenNv.Text.Trim().Length <= 0)
            {
                this.errEmploy.SetError(this.txtTenNv, "Nhập tên nhân viên");
                return true;
            }
            else this.errEmploy.SetError(this.txtTenNv, null);


            //if (this.dtpNgaySinh.Text.Trim().Length <= 0)
            //{
            //    this.errEmploy.SetError(this.dtpNgaySinh, "Nhập ngày sinh");
            //    return true;
            //}
            //else this.errEmploy.SetError(this.dtpNgaySinh, null);


            if (this.txtDiaChi.Text.Trim().Length <= 0)
            {
                this.errEmploy.SetError(this.txtDiaChi, "Nhập địa chỉ");
                return true;
            }
            else this.errEmploy.SetError(this.txtDiaChi, null);


            if (this.txtSdt.Text.Trim().Length <= 0)
            {
                this.errEmploy.SetError(this.txtSdt, "Nhập số điện thoại");
                return true;
            }
            else this.errEmploy.SetError(this.txtSdt, null);


            if (this.txtLuong.Text.Trim().Length <= 0)
            {
                this.errEmploy.SetError(this.txtLuong, "Nhập lương");
                return true;
            }
            else this.errEmploy.SetError(this.txtLuong, null);            

            return false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult xoa = MessageBox.Show("Đồng ý xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (xoa == DialogResult.Yes)
            {
                var context = new Dtb_NhaSachContext();
                var delete = new Nhanvien()
                {
                    MaNv = this.dgvEmploy.CurrentRow.Cells[0].Value.ToString(),
                };
                context.Remove<Nhanvien>(delete);
                context.SaveChanges();
                refreshControl();
                loadEmploy();
            }
        }
        private void refreshControl()
        {
            this.txtManv.Text = null;
            this.txtSdt.Text = null;
            this.txtLuong.Text = null;
            this.txtTenNv.Text = null;
            this.txtDiaChi.Text = null;
            this.dtpNgaySinh.Value = DateTime.Now;
            this.errEmploy.SetError(this.txtManv, null);
            this.errEmploy.SetError(this.txtDiaChi, null);
            this.errEmploy.SetError(this.txtManv, null);
            this.errEmploy.SetError(this.txtLuong, null);
            this.errEmploy.SetError(this.txtSdt, null);
        }
    }
}
