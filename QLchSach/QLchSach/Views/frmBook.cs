using Microsoft.EntityFrameworkCore.Storage;
using QLchSach.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace QLchSach
{
    public partial class frmBook : Form
   {

        //Dtb_NhaSachContext context = new Dtb_NhaSachContext();
        public frmBook()
        {
            InitializeComponent();
        }
        private void frmBook_Load(object sender, EventArgs e)
        {
            loadCbb();
            loadDgvBook();
        }
        private void loadDgvBook()
        {
            var context = new Dtb_NhaSachContext();           
            #region load ds bằng linq
            var book = context.Saches
                            .Join(context.Nxbs,
                                s => s.MaNxb.Trim(),
                                n => n.MaNxb.Trim(),
                                (s, n) =>
                                new
                                {
                                    Stt = s.Stt,
                                    MaSach = s.MaSach,
                                    TenSach = s.TenSach,
                                    TenNxb = n.TenNxb,
                                    MaTl = s.MaTl,
                                    MaTg = s.MaTg,
                                    SoLuong = s.SoLuong,
                                    GiaBan = s.GiaBan
                                })
                            .Join(context.Theloais,
                            s => s.MaTl.Trim(),
                            t => t.MaTl.Trim(),
                            (s, t) =>
                            new
                            {
                                Stt = s.Stt,
                                MaSach = s.MaSach,
                                TenSach = s.TenSach,
                                TenTl = t.TenTl,
                                TenNxb = s.TenNxb,
                                MaTg = s.MaTg,
                                SoLuong = s.SoLuong,
                                GiaBan = s.GiaBan
                            })
                            .Join(context.Tacgia,
                            s => s.MaTg.Trim(),
                            tg => tg.MaTg.Trim(),
                            (s, tg) =>
                            new
                            {
                                Stt = s.Stt,
                                MaSach = s.MaSach,
                                TenSach = s.TenSach,
                                TenTl = s.TenTl,
                                TenNxb = s.TenNxb,
                                TenTg = tg.TenTg,
                                SoLuong = s.SoLuong,
                                GiaBan = s.GiaBan
                            }).OrderBy(s => s.Stt).ToList();
            this.dgvBook.DataSource = null;
            this.dgvBook.DataSource = book;
            
            #endregion
            customDgv();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            var context = new Dtb_NhaSachContext();

            var ms = new SqlParameter("@masach", this.cbbMs.Text.ToLower().Trim());
            var ts = new SqlParameter("@tensach", this.txtTenSach.Text.ToLower().Trim());
            var tl = new SqlParameter("@tentl", this.cbbMtl.Text.ToLower().Trim());
            var n = new SqlParameter("@tennxb", this.cbbnxb.Text.ToLower().Trim());
            var tg = new SqlParameter("@tentg", this.cbbMtg.Text.ToLower().Trim());
            var resultRaw = context.Saches.FromSqlRaw("timkiemSach @masach, @tensach, @tentl, @tennxb, @tentg", ms, ts, tl, n, tg).ToList();

            #region linq
            var result = resultRaw.Join(context.Tacgia,
                            s => s.MaTg.Trim(),
                            tg => tg.MaTg.Trim(),
                            (s, tg) =>
                            new
                            {
                                Stt = s.Stt,
                                MaSach = s.MaSach,
                                TenSach = s.TenSach,
                                MaTl = s.MaTl,
                                MaNxb = s.MaNxb,
                                TenTg = tg.TenTg,
                                SoLuong = s.SoLuong,
                                GiaBan = s.GiaBan
                            }).Join(context.Theloais,
                            s => s.MaTl.Trim(),
                            t => t.MaTl.Trim(),
                            (s, t) =>
                            new
                            {
                                Stt = s.Stt,
                                MaSach = s.MaSach,
                                TenSach = s.TenSach,
                                TenTl = t.TenTl,
                                MaNxb = s.MaNxb,
                                TenTg = s.TenTg,
                                SoLuong = s.SoLuong,
                                GiaBan = s.GiaBan
                            }).Join(context.Nxbs,
                                f => f.MaNxb.Trim(),
                                n => n.MaNxb.Trim(),
                                (s, n) =>
                                new
                                {
                                    Stt = s.Stt,
                                    MaSach = s.MaSach,
                                    TenSach = s.TenSach,
                                    TenTl = s.TenTl,
                                    TenNxb = n.TenNxb,                                  
                                    TenTg = s.TenTg,
                                    SoLuong = s.SoLuong,
                                    GiaBan = s.GiaBan
                                })
                .OrderBy(s => s.Stt).ToList();
            #endregion

            this.dgvBook.DataSource = null;
            this.dgvBook.DataSource = result;
            customDgv();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (loiNhap())
            {
                return;
            }
            // nếu trùng khóa chính
            var context = new Dtb_NhaSachContext();
            var cSach = context.Saches
                    .Where(s => s.MaSach.Trim() == this.cbbMs.Text.Trim())
                    .Select(s => s.MaSach).ToList();
            if (cSach.Count > 0)
            {
                DialogResult hoi =  MessageBox.Show("Sách đã có trong dữ liệu cửa hàng. Bạn có muốn cộng thêm vào không?", "Chú ý"
                    ,MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (hoi == DialogResult.Yes)
                {
                    try
                    {
                        var edit = new Sach()
                        {
                            MaSach = this.dgvBook.CurrentRow.Cells[1].Value.ToString().Trim(),
                        };
                        var tg = context.Tacgia
                                    .Where(t => t.TenTg == this.cbbMtg.Text.Trim())
                                    .Select(t => new
                                    {
                                        t.MaTg,
                                    }).FirstOrDefault().MaTg.Trim();
                        var nxb = context.Nxbs
                                    .Where(n => n.TenNxb == this.cbbnxb.Text.Trim())
                                    .Select(n => new
                                    {
                                        n.MaNxb,
                                    }).FirstOrDefault().MaNxb.Trim();
                        var tl = context.Theloais
                                .Where(t => t.TenTl == this.cbbMtl.Text.Trim())
                                .Select(t => new
                                {
                                    t.MaTl,
                                }).FirstOrDefault().MaTl.Trim();
                        var sl = context.Saches.Where(s => s.MaSach.Trim() == this.cbbMs.Text.Trim())
                                                .Select(s => s.SoLuong).FirstOrDefault();
                        edit.Stt = int.Parse(this.dgvBook.CurrentRow.Cells[0].Value.ToString().Trim());
                        edit.TenSach = this.txtTenSach.Text.Trim();
                        edit.SoLuong = int.Parse(this.txtSoLuong.Text.Trim()) + sl;
                        edit.MaTl = tl;
                        edit.MaTg = tg;
                        edit.MaNxb = nxb;
                        edit.GiaBan = int.Parse(this.txtGiaBan.Text.Trim());
                        context.Update<Sach>(edit);
                        context.SaveChanges();
                        refreshControl();
                        loadDgvBook();
                        MessageBox.Show("Thêm thành công!!!!");
                    }
                    catch
                    {
                        MessageBox.Show("Đã xảy ra lỗi. Vui lòng thử lại!");
                        return;
                    }
                    return;
                }
                else return;
            }

            try
            {
                    var tg = context.Tacgia
                                .Where(t => t.TenTg == this.cbbMtg.Text.Trim())
                                .Select(t => new
                                {
                                    t.MaTg,
                                }).FirstOrDefault().MaTg.Trim();
                    var nxb = context.Nxbs
                                .Where(n => n.TenNxb == this.cbbnxb.Text.Trim())
                                .Select(n => new
                                {
                                    n.MaNxb,
                                }).FirstOrDefault().MaNxb.Trim();
                    var tl = context.Theloais
                            .Where(t => t.TenTl == this.cbbMtl.Text.Trim())
                            .Select(t => new
                            {
                                t.MaTl,
                            }).FirstOrDefault().MaTl.Trim();
                    var addBook = new Sach()
                    {
                        Stt = context.Saches.Count() + 1,
                        MaSach = this.cbbMs.Text.Trim(),
                        TenSach = this.txtTenSach.Text.Trim(),
                        SoLuong = int.Parse(this.txtSoLuong.Text.Trim()),
                        MaTl = tl,
                        MaTg = tg,
                        MaNxb = nxb,
                        GiaBan = int.Parse(this.txtGiaBan.Text.Trim()),
                    };
                    context.Saches.Add(addBook);
                    context.SaveChanges();
                    MessageBox.Show("Thêm thành công!!!");
                    refreshControl();
                    loadDgvBook();
                }
                catch
                {
                    MessageBox.Show("Đã xảy ra lỗi. Vui lòng thử lại!");
                    return;
                }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (loiNhap())
            {
                return;
            }
            #region nếu trùng khóa chính khác
            var context = new Dtb_NhaSachContext();
            if (this.cbbMs.Text.Trim() != this.dgvBook.CurrentRow.Cells[1].Value.ToString().Trim())
            {
                var cSach = context.Saches
                    .Where(s => s.MaSach.Trim() == this.cbbMs.Text.Trim())
                    .Select(s => s.MaSach).ToList();
                if (cSach.Count > 0)
                {
                    this.errorProvider1.SetError(this.cbbMs, "Mã sách không được trùng");
                    return;
                }
                else this.errorProvider1.SetError(this.cbbMs, null);
            }
            #endregion
            try
            {
                var edit = new Sach()
                {
                    //Stt = int.Parse(this.dgvBook.CurrentRow.Cells[0].Value.ToString().Trim()),
                    MaSach = this.dgvBook.CurrentRow.Cells[1].Value.ToString().Trim(),
                };
                var tg = context.Tacgia
                            .Where(t => t.TenTg == this.cbbMtg.Text.Trim())
                            .Select(t => new
                            {
                                t.MaTg,
                            }).FirstOrDefault().MaTg.Trim();
                var nxb = context.Nxbs
                            .Where(n => n.TenNxb == this.cbbnxb.Text.Trim())
                            .Select(n => new
                            {
                                n.MaNxb,
                            }).FirstOrDefault().MaNxb.Trim();
                var tl = context.Theloais
                        .Where(t => t.TenTl == this.cbbMtl.Text.Trim())
                        .Select(t => new
                        {
                            t.MaTl,
                        }).FirstOrDefault().MaTl.Trim();
                edit.Stt = int.Parse(this.dgvBook.CurrentRow.Cells[0].Value.ToString().Trim());
                edit.TenSach = this.txtTenSach.Text.Trim();
                edit.SoLuong = int.Parse(this.txtSoLuong.Text.Trim());
                edit.MaTl = tl;
                edit.MaTg = tg;
                edit.MaNxb = nxb;
                edit.GiaBan = int.Parse(this.txtGiaBan.Text.Trim());
                context.Update<Sach>(edit);
                context.SaveChanges();
                refreshControl();
                loadDgvBook();
                MessageBox.Show("Sửa thành công!!!!");
            }
            catch 
            {
                MessageBox.Show("Đã xảy ra lỗi. Vui lòng thử lại!");
                return;
            }
        }       
        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            refreshControl();
            this.cbbMs.Text = this.dgvBook.CurrentRow.Cells[1].Value.ToString().Trim();
            this.txtTenSach.Text = this.dgvBook.CurrentRow.Cells[2].Value.ToString().Trim();
            this.cbbMtg.Text = this.dgvBook.CurrentRow.Cells[5].Value.ToString().Trim();
            this.cbbMtl.Text = this.dgvBook.CurrentRow.Cells[3].Value.ToString().Trim();
            this.cbbnxb.Text = this.dgvBook.CurrentRow.Cells[4].Value.ToString().Trim();
            this.txtSoLuong.Text = this.dgvBook.CurrentRow.Cells[6].Value.ToString().Trim();
            this.txtGiaBan.Text = this.dgvBook.CurrentRow.Cells[7].Value.ToString().Trim();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult xoa = MessageBox.Show("Đồng ý xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (xoa == DialogResult.Yes )
            {
                try
                {
                    var context = new Dtb_NhaSachContext();
                    var delete = new Sach()
                    {
                        //Stt = int.Parse(this.dgvBook.CurrentRow.Cells[0].Value.ToString().Trim()),
                        MaSach = this.dgvBook.CurrentRow.Cells[1].Value.ToString().Trim(),
                    };
                    context.Remove<Sach>(delete);
                    context.SaveChanges();

                    refreshControl();
                    sapXep();
                    loadDgvBook();
                    MessageBox.Show("Xóa thành công!!!!");
                }
                catch
                {
                    MessageBox.Show("đã xảy ra lỗi. vui lòng thử lại!");
                    return;
                }
            } 
        }
        private void refreshControl()
        {
            this.cbbMs.Text = null;
            this.txtTenSach.Text = null;
            this.cbbMtg.Text = null;
            this.cbbMtl.Text = null;
            this.cbbnxb.Text = null; 
            this.txtGiaBan.Text = null;           
            this.txtSoLuong.Text = null;
            this.errorProvider1.SetError(this.cbbMs, null);
            this.errorProvider1.SetError(this.txtTenSach, null);
            this.errorProvider1.SetError(this.txtSoLuong, null);
            this.errorProvider1.SetError(this.txtGiaBan, null);
            this.errorProvider1.SetError(this.cbbMtg, null);
            this.errorProvider1.SetError(this.cbbnxb, null);
            this.errorProvider1.SetError(this.cbbMtl, null);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshControl();
            loadDgvBook();
        }
        public void sapXep()
        {
            var context = new Dtb_NhaSachContext();
            
            var sxSach = context.Saches.ToList();
            int i = 1;
            foreach (var s in sxSach)
            {
                s.MaSach = s.MaSach;
                s.Stt = i;
                s.TenSach = s.TenSach;
                s.MaTg = s.MaTg;
                s.MaNxb = s.MaNxb;
                s.MaTl = s.MaTl;
                s.SoLuong = s.SoLuong;
                s.GiaBan = s.GiaBan;
                context.Update<Sach>(s);
                context.SaveChanges();
                i++;
            }

        }
        public bool loiNhap()
        {
            #region nếu trường nhập null
            if (this.cbbMs.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.cbbMs, "Nhập mã sách");
                return true;
            }
            else this.errorProvider1.SetError(this.cbbMs, null);

            if (this.txtTenSach.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtTenSach, "Nhập tên sách");
                return true;
            }
            else this.errorProvider1.SetError(this.txtTenSach, null);

            if (this.txtGiaBan.Text.Trim().Length <=0)
            {
                this.errorProvider1.SetError(this.txtGiaBan, "Nhập giá bán");
                return true;
            }
            else this.errorProvider1.SetError(this.txtGiaBan, null);

            if (this.txtSoLuong.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtSoLuong, "Nhập số lượng");
                return true;
            }
            else this.errorProvider1.SetError(this.txtSoLuong, null);          

            if (this.cbbMtg.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.cbbMtg, "Chọn tác giả");
                return true;
            }
            else this.errorProvider1.SetError(this.cbbMtg, null);           

            if (this.cbbMtl.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.cbbMtl, "Chọn thể loại");
                return true;
            }
            else this.errorProvider1.SetError(this.cbbMtl, null);

            if (this.cbbnxb.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.cbbnxb, "Chọn nhà xuất bản");
                return true;
            }
            else this.errorProvider1.SetError(this.cbbnxb, null);
            #endregion
            return false;
        }
        public void customDgv()
        {
            this.dgvBook.Columns["Stt"].HeaderText = "STT";
            this.dgvBook.Columns["MaSach"].HeaderText = "Mã sách";
            this.dgvBook.Columns["TenSach"].HeaderText = "Tên sách";
            this.dgvBook.Columns["TenTl"].HeaderText = "Thể loại";
            this.dgvBook.Columns["TenNxb"].HeaderText = "Nhà xuất bản";
            this.dgvBook.Columns["TenTg"].HeaderText = "Tác giả";
            this.dgvBook.Columns["SoLuong"].HeaderText = "Số lượng tồn";
            this.dgvBook.Columns["GiaBan"].HeaderText = "Giá bán";

            DataGridViewColumn column0 = this.dgvBook.Columns[0];
            column0.Width = 30;
            DataGridViewColumn column2 = this.dgvBook.Columns[2];
            column2.Width = 150;
            DataGridViewColumn column5 = this.dgvBook.Columns[5];
            column5.Width = 120;
            DataGridViewColumn column4 = this.dgvBook.Columns[4];
            column4.Width = 240;
            DataGridViewColumn column7 = this.dgvBook.Columns[7];
            column7.Width = 80;
        }
        public void loadCbb()
        {
            var context = new Dtb_NhaSachContext();

            this.cbbMs.DataSource = context.Saches.Select(s=>s.MaSach.Trim()).ToList();
            this.cbbMs.Text = null;
            this.cbbMtg.DataSource = context.Tacgia.Select(t=>t.TenTg.Trim()).ToList();
            this.cbbMtg.Text = null;
            this.cbbMtl.DataSource = context.Theloais.Select(t => t.TenTl.Trim()).ToList();
            this.cbbMtl.Text = null;
            this.cbbnxb.DataSource = context.Nxbs.Select(n => n.TenNxb.Trim()).ToList();
            this.cbbnxb.Text = null;
        }
    }
}
