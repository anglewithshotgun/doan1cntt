using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLchSach.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace QLchSach
{
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            refreshGroupB1();
            refreshGroupB2();
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnThemSach.Enabled = true;
            this.btnXoa.Enabled = false;
            this.groupBox1.Enabled = true;
            this.groupBox2.Enabled = true;
            this.panel1.Enabled = false;
            this.btnThemHoaDon.Enabled = false;          
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            if (cbbTimKiemCthd.Text.Trim() != "")
            {
                this.dgv1.Rows.Clear();
                loadThongTinChung();
                loadTtBanHang();
                var context = new Dtb_NhaSachContext();
                this.cbbTenSach.DataSource = context.Saches.Select(s => s.TenSach.Trim()).ToList();
                this.cbbTenSach.Text = null;
                string cbb = this.cbbTimKiemCthd.Text.Trim();
                this.cbbTimKiemCthd.DataSource = context.Hoadons.Select(s => s.SoHd).ToList();
                this.cbbTimKiemCthd.Text = cbb;
                cbb = this.cbbTenNv.Text.Trim();
                this.cbbTenNv.DataSource = context.Nhanviens.Select(s => s.TenNv.Trim()).ToList();
                this.cbbTenNv.Text = cbb;
                this.groupBox1.Enabled = true;
            }
            else loadcbb();
        }
        public void loadcbb()
        {
            var context = new Dtb_NhaSachContext();
            this.cbbTenSach.DataSource = context.Saches.Select(s => s.TenSach.Trim()).ToList();
            this.cbbTenSach.Text = null;
            this.cbbTimKiemCthd.DataSource = context.Hoadons.Select(s => s.SoHd).ToList();
            this.cbbTimKiemCthd.Text = null;
            this.cbbTenNv.DataSource = context.Nhanviens.Select(s => s.TenNv.Trim()).ToList();
            this.cbbTenNv.Text = null;
        }
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            trungSach();
            refreshGroupB1();
            tinhTien();
        }
        public void addRow()
        {
            var context = new Dtb_NhaSachContext();

            int stt = this.dgv1.Rows.Count;

            string tenSach = this.cbbTenSach.Text.Trim();

            int soLuong = int.Parse(this.txtSoLuong.Text.Trim());

            double donGia = context.Saches.Where(s => s.TenSach.Trim() == this.cbbTenSach.Text.Trim())
                                .Select(s => s.GiaBan).FirstOrDefault();

            double giamGia = double.Parse(this.txtGiamGia.Text.Trim());

            double thanhTien = donGia * soLuong;

            double giaSaugiam = thanhTien - thanhTien * giamGia / 100;

            this.dgv1.Rows.Add(stt, tenSach, soLuong, donGia, giamGia, thanhTien, giaSaugiam);
        }
        public void refreshGroupB1()
        {
            this.cbbTenSach.Text = null;
            this.txtSoLuong.Text = null;
            this.txtGiamGia.Text = null;
            this.txtTongCong.Text = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.btnHuy.Enabled = false;
            this.btnLuu.Enabled = false;
            this.btnThemSach.Enabled = false;
            this.btnXoa.Enabled = true;
            this.panel1.Enabled = true;
            this.groupBox1.Enabled = false;
            this.groupBox2.Enabled = false;
            this.btnThemHoaDon.Enabled = true;
            refreshGroupB1();
            refreshGroupB2();
            this.dgv1.Rows.Clear();
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            this.dgv1.Rows.RemoveAt(this.dgv1.CurrentRow.Index);
            for (int i = 0; i < this.dgv1.Rows.Count - 1; i++)
            {
                this.dgv1.Rows[i].Cells[0].Value = i + 1;
            }
            this.btnXoaSach.Enabled = false;
            this.btnSuaThongTin.Enabled = false;
            this.btnThemSach.Enabled = true;
            refreshGroupB1();
            tinhTien();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.cbbTenSach.Text = this.dgv1.CurrentRow.Cells[1].Value.ToString().Trim();
            this.txtSoLuong.Text = this.dgv1.CurrentRow.Cells[2].Value.ToString().Trim();
            this.txtGiamGia.Text = this.dgv1.CurrentRow.Cells[4].Value.ToString().Trim();
            this.btnXoaSach.Enabled = true;
            this.btnSuaThongTin.Enabled = true;
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            var context = new Dtb_NhaSachContext();

            this.dgv1.CurrentRow.Cells[1].Value = this.cbbTenSach.Text.Trim();
            this.dgv1.CurrentRow.Cells[2].Value = this.txtSoLuong.Text.Trim();

            double donGia = context.Saches.Where(s => s.TenSach.Trim() == this.cbbTenSach.Text.Trim())
                                .Select(s => s.GiaBan).FirstOrDefault();
            this.dgv1.CurrentRow.Cells[3].Value = donGia;

            this.dgv1.CurrentRow.Cells[4].Value = this.txtGiamGia.Text.Trim();

            double giamGia = double.Parse(this.txtGiamGia.Text.Trim());

            double thanhTien = donGia * int.Parse(this.txtSoLuong.Text.Trim());

            double giaSaugiam = thanhTien - thanhTien * giamGia / 100;

            this.dgv1.CurrentRow.Cells[5].Value = thanhTien;
            this.dgv1.CurrentRow.Cells[6].Value = giaSaugiam;

            this.btnXoaSach.Enabled = false;
            this.btnSuaThongTin.Enabled = false;
            this.btnThemSach.Enabled = true;
            refreshGroupB1();
            tinhTien();
        }
        public void tinhTien()
        {
            int tongTien = 0;
            for (int i = 0; i < this.dgv1.Rows.Count - 1; i++)
            {
                tongTien = tongTien + int.Parse(this.dgv1.Rows[i].Cells[6].Value.ToString().Trim());
            }
            this.txtTongCong.Text = tongTien.ToString().Trim();
        }
        public void trungSach()
        {
            if (this.dgv1.Rows.Count > 1)
            {
                for (int i = 0; i < this.dgv1.Rows.Count - 1; i++)
                {
                    if (this.cbbTenSach.Text.Trim() == this.dgv1.Rows[i].Cells[1].Value.ToString().Trim())
                    {
                        DialogResult congDon = MessageBox.Show("Sách đã có trong hóa đơn bạn có muốn thay thế?", "Chú ý"
                            , MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (congDon == DialogResult.Yes)
                        {
                            var context = new Dtb_NhaSachContext();
                            double donGia = context.Saches.Where(s => s.TenSach.Trim() == this.cbbTenSach.Text.Trim())
                                    .Select(s => s.GiaBan).FirstOrDefault();
                            double giamGia = double.Parse(this.txtGiamGia.Text.Trim());

                            double thanhTien = donGia * int.Parse(this.txtSoLuong.Text.Trim());

                            double giaSaugiam = thanhTien - thanhTien * giamGia / 100;
                            this.dgv1.Rows[i].Cells[2].Value = this.txtSoLuong.Text.Trim();
                            this.dgv1.Rows[i].Cells[4].Value = this.txtGiamGia.Text.Trim();
                            this.dgv1.Rows[i].Cells[5].Value = thanhTien;
                            this.dgv1.Rows[i].Cells[6].Value = giaSaugiam;
                            return;
                        }                       
                    }
                }
                addRow();
            }
            else addRow();           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (this.dgv1.Rows.Count > 1)
            {
                addTblHD();
                addTblCthd();
                refreshSach();
                MessageBox.Show("Thêm thành công");
                refreshGroupB1();
                refreshGroupB2();
                this.dgv1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Thêm sách vào hóa đơn");
            }           
        }
        public void addTblHD()
        {
            var context = new Dtb_NhaSachContext();

            var maNv = context.Nhanviens.Where(s => s.TenNv.Trim() == this.cbbTenNv.Text.Trim())
                            .Select(s => new { s.MaNv }).FirstOrDefault().MaNv.Trim();
            var getSohd = context.Hoadons.Select(s => s.SoHd).Max();


            var getMatv = context.Thanhviens.Where(s => s.TenTv.Trim() == this.txtTenKh.Text.Trim())
                        .Select(s => s.MaTv).FirstOrDefault();

            var addHd = new Hoadon()
            {
                SoHd = getSohd + 1,
                MaNv = maNv,
                NgayBan = DateTime.Now,
                TenKh = this.txtTenKh.Text.Trim(),
                MaTv = getMatv,
                TongTien = double.Parse(this.txtTongCong.Text.Trim()),              
            };
            context.Hoadons.Add(addHd);
            context.SaveChanges();
            
        }
        public void refreshGroupB2()
        {
            this.txtMahd.Text = null;
            this.dateTimePicker1.Value = DateTime.Now;
            this.cbbTenNv.Text = null;
            this.txtTenKh.Text = null;
        }
        public void addTblCthd()
        {
            var context = new Dtb_NhaSachContext();

            for (int i = 0; i < this.dgv1.Rows.Count - 1; i++)
            {
                var maSach = context.Saches.Where(s => s.TenSach.Trim() == this.dgv1.Rows[i].Cells[1].Value.ToString().Trim())
                                .Select(s => s.MaSach).FirstOrDefault();

                var getSohd = context.Hoadons.Select(s => s.SoHd).Max();

                var cthd = new Chitiethoadon()
                {
                    MaSach = maSach.Trim(),
                    SoHd = getSohd,
                    SoLuongBan = int.Parse(this.dgv1.Rows[i].Cells[2].Value.ToString().Trim()),
                    ThanhTien = double.Parse(this.dgv1.Rows[i].Cells[5].Value.ToString().Trim()),
                    GiamGia = double.Parse(this.dgv1.Rows[i].Cells[4].Value.ToString().Trim()),
                    GiaSauGiam = double.Parse(this.dgv1.Rows[i].Cells[6].Value.ToString().Trim()),
                    DonGia = double.Parse(this.dgv1.Rows[i].Cells[3].Value.ToString().Trim()),
                };
                context.Chitiethoadons.Add(cthd);
                context.SaveChanges();
            }
        }
        public void refreshSach()
        {
            var context = new Dtb_NhaSachContext();

            for (int i = 0; i < this.dgv1.Rows.Count - 1; i++)
            {
                var MaSach = context.Saches.Where(s => s.TenSach.Trim() == this.dgv1.Rows[i].Cells[1].Value.ToString().Trim())
                                .Select(s => s.MaSach).FirstOrDefault();
                var stt = context.Saches.Where(s => s.TenSach.Trim() == this.dgv1.Rows[i].Cells[1].Value.ToString().Trim())
                                .Select(s => s.Stt).FirstOrDefault();
                var sl = context.Saches.Where(s => s.TenSach.Trim() == this.dgv1.Rows[i].Cells[1].Value.ToString().Trim())
                                .Select(s => s.SoLuong).FirstOrDefault();
                var tenS = context.Saches.Where(s => s.TenSach.Trim() == this.dgv1.Rows[i].Cells[1].Value.ToString().Trim())
                                .Select(s => s.TenSach).FirstOrDefault();
                var nxb = context.Saches.Where(s => s.TenSach.Trim() == this.dgv1.Rows[i].Cells[1].Value.ToString().Trim())
                                .Select(s => s.MaNxb).FirstOrDefault();
                var tl = context.Saches.Where(s => s.TenSach.Trim() == this.dgv1.Rows[i].Cells[1].Value.ToString().Trim())
                                .Select(s => s.MaTl).FirstOrDefault();
                var tg = context.Saches.Where(s => s.TenSach.Trim() == this.dgv1.Rows[i].Cells[1].Value.ToString().Trim())
                                .Select(s => s.MaTg).FirstOrDefault();
                var gia = context.Saches.Where(s => s.TenSach.Trim() == this.dgv1.Rows[i].Cells[1].Value.ToString().Trim())
                                .Select(s => s.GiaBan).FirstOrDefault();

                var refresh = new Sach()
                {
                    MaSach = MaSach,
                };
                refresh.Stt = stt;
                refresh.SoLuong = sl - int.Parse(this.dgv1.Rows[i].Cells[2].Value.ToString().Trim());
                refresh.TenSach = tenS;
                refresh.MaNxb = nxb;
                refresh.MaTg = tg;
                refresh.MaTl = tl;
                refresh.GiaBan = gia;
                context.Saches.Update(refresh);
                context.SaveChanges();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {           
            delCthd();
            delHd();
            loadcbb();
            refreshGroupB1();
            refreshGroupB2();
            this.dgv1.Rows.Clear();
            this.btnXoa.Enabled = false;
            MessageBox.Show("Đã xóa");
        }
        public void delHd()
        {
            var context = new Dtb_NhaSachContext();
            var hd = new Hoadon()
            {
                SoHd = int.Parse(this.txtMahd.Text.Trim()),
            };
            context.Remove<Hoadon>(hd);
            context.SaveChanges();
        }
        public void delCthd()
        {
            var context = new Dtb_NhaSachContext();
            var list = context.Chitiethoadons.Where(s => s.SoHd == int.Parse(this.txtMahd.Text.Trim())).ToList();
            foreach (var item in list)
            {
                context.Remove<Chitiethoadon>(item);
                context.SaveChanges();
            }
            
        }
        private void btnTimKiemCthd_Click(object sender, EventArgs e)
        {          
            loadThongTinChung();
            loadTtBanHang();
            this.btnXoa.Enabled = true;
        }
        public void loadThongTinChung()
        {
            var context = new Dtb_NhaSachContext();

            var hd = context.Hoadons.Where(s => s.SoHd == int.Parse(this.cbbTimKiemCthd.Text.Trim())).FirstOrDefault();
            this.txtMahd.Text = this.cbbTimKiemCthd.Text.Trim();
            this.dateTimePicker1.Value = DateTime.Parse(hd.NgayBan.ToString().Trim());
            this.txtTenKh.Text = hd.TenKh.Trim();
            this.cbbTenNv.Text = context.Nhanviens.Where(s => s.MaNv.Trim() == hd.MaNv.Trim())
                                    .Select(s => s.TenNv).FirstOrDefault().ToString().Trim();
        }
        public void loadTtBanHang()
        {
            var context = new Dtb_NhaSachContext();

            var cthd = context.Chitiethoadons.Where(s => s.SoHd == int.Parse(this.cbbTimKiemCthd.Text.Trim()))
                                    .OrderBy(s=>s.MaSach).ToList();
            int stt = 1;
            foreach (var item in cthd)
            {
                string tenSach = context.Saches.Where(s => s.MaSach.Trim() == item.MaSach.Trim())
                            .Select(s=>s.TenSach).FirstOrDefault().ToString();
                string soLuong = item.SoLuongBan.ToString().Trim();
                string donGia = item.DonGia.ToString().Trim();
                string giamGia = item.GiamGia.ToString().Trim();
                string thanhTien = item.ThanhTien.ToString().Trim();
                string giaSauGiam = item.GiaSauGiam.ToString().Trim();

                string[] row = new string[] { stt.ToString().Trim(), tenSach, soLuong, donGia, giamGia, thanhTien, giaSauGiam };
                dgv1.Rows.Add(row);
                stt++;
            }
        }
    }
}
