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
            
            loadDgvBook();
        }
        private void loadDgvBook()
        {
            var context = new Dtb_NhaSachContext();
            //Linq
            #region
            var book = context.Sach
                            .Join(context.Nxb,
                                s => s.MaNxb,
                                n => n.MaNxb,
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
                            .Join(context.Theloai,
                            s => s.MaTl,
                            t => t.MaTl,
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
                            s => s.MaTg,
                            tg => tg.MaTg,
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
            #endregion
            //var book = context.Sach
            //    .Where(s => s.MaSach == s.MaSach)
            //    .Select(s => new
            //    {
            //        s.Stt,
            //        s.MaSach,
            //        s.TenSach,
            //        s.MaTg,
            //        s.MaTl,
            //        s.MaNxb,
            //        s.SoLuong
            //    }).ToList();
            //var book = this.context.Sach.FromSqlRaw("LOADFRMBOOK").ToList();
            this.dgvBook.DataSource = book;
            this.dgvBook.Columns["Stt"].HeaderText = "STT";
            this.dgvBook.Columns["MaSach"].HeaderText = "Mã sách";
            this.dgvBook.Columns["TenSach"].HeaderText = "Tên sách";
            this.dgvBook.Columns["TenTl"].HeaderText = "Thể loại";
            this.dgvBook.Columns["TenTg"].HeaderText = "Tác giả";
            this.dgvBook.Columns["TenNxb"].HeaderText = "Nhà xuất bản";
            this.dgvBook.Columns["GiaBan"].HeaderText = "Giá bán";
            this.dgvBook.Columns["SoLuong"].HeaderText = "Số lượng tồn";

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

        private void btnFind_Click(object sender, EventArgs e)
        {
            //var context = new Dtb_NhaSachContext();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var context = new Dtb_NhaSachContext();
                var tg = context.Tacgia
                            .Where(t => t.TenTg == this.cbbMtg.Text.Trim())
                            .Select(t => new
                            {
                                t.MaTg,
                            }).FirstOrDefault().MaTg.Trim();
                var nxb = context.Nxb
                            .Where(n => n.TenNxb == this.cbbnxb.Text.Trim())
                            .Select(n => new
                            {
                                n.MaNxb,
                            }).FirstOrDefault().MaNxb.Trim();
                var tl = context.Theloai
                        .Where(t => t.TenTl == this.cbbMtl.Text.Trim())
                        .Select(t => new
                        {
                            t.MaTl,
                        }).FirstOrDefault().MaTl.Trim();
                var addBook = new Sach()
                {
                    Stt = context.Sach.Count() + 1,
                    MaSach = this.cbbMs.Text.Trim(),
                    TenSach = this.txtTenSach.Text.Trim(),
                    SoLuong = int.Parse(this.txtSoLuong.Text.Trim()),
                    MaTl = tl,
                    MaTg = tg,
                    MaNxb = nxb,
                    GiaBan = int.Parse(this.txtGiaBan.Text.Trim()),
                };
                context.Sach.Add(addBook);
                context.SaveChanges();
                MessageBox.Show("Thêm thành công!!!");
                refreshControl();
                loadDgvBook();
                sapXep();
            }
            catch
            {
                MessageBox.Show("Lỗi");
                return;
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var context = new Dtb_NhaSachContext();
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
                var nxb = context.Nxb
                            .Where(n => n.TenNxb == this.cbbnxb.Text.Trim())
                            .Select(n => new
                            {
                                n.MaNxb,
                            }).FirstOrDefault().MaNxb.Trim();
                var tl = context.Theloai
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
                
                return;
            }
        }
        

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
                loadDgvBook();
                sapXep();
                MessageBox.Show("Xóa thành công!!!!");
            }
            catch
            {

                return;
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
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshControl();
            loadDgvBook();
        }
        public void sapXep()
        {
            for (int i = 0; i < this.dgvBook.Rows.Count; i++)
            {
                var context = new Dtb_NhaSachContext();
                var tg = context.Tacgia
                            .Where(t => t.TenTg == this.dgvBook.Rows[i].Cells[5].Value.ToString().Trim())
                            .Select(t => new
                            {
                                t.MaTg,
                            }).FirstOrDefault().MaTg.Trim();
                var nxb = context.Nxb
                            .Where(n => n.TenNxb == this.dgvBook.Rows[i].Cells[4].Value.ToString().Trim())
                            .Select(n => new
                            {
                                n.MaNxb,
                            }).FirstOrDefault().MaNxb.Trim();
                var tl = context.Theloai
                        .Where(t => t.TenTl == this.dgvBook.Rows[i].Cells[3].Value.ToString().Trim())
                        .Select(t => new
                        {
                            t.MaTl,
                        }).FirstOrDefault().MaTl.Trim();               
                var arrange = new Sach()
                {
                    //Stt = int.Parse(this.dgvBook.Rows[i].Cells[0].Value.ToString().Trim()),
                    MaSach = this.dgvBook.Rows[i].Cells[1].Value.ToString().Trim(),
                };
                arrange.Stt = i + 1;
                arrange.TenSach = this.dgvBook.Rows[i].Cells[2].Value.ToString().Trim();
                arrange.MaTg = tg;
                arrange.MaTl = tl;
                arrange.MaNxb = nxb;
                arrange.SoLuong = int.Parse(this.dgvBook.Rows[i].Cells[6].Value.ToString().Trim());
                arrange.GiaBan = int.Parse(this.dgvBook.Rows[i].Cells[7].Value.ToString().Trim());
                context.Update<Sach>(arrange);
                context.SaveChanges();
                loadDgvBook();
            }
        }
    }
}
