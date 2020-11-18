using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLchSach.Models;

namespace QLchSach
{
    public partial class frmMain : Form
    {
        
        public frmMain()
        {
           InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tsFile.Click += TsFile_Click;
            tsThoat.Click += TsThoat_Click;
            tsThanhVien.Click += TsKhachHang_Click;
            tsNhanVien.Click += TsNhanVien_Click;
            tsSach.Click += TsSach_Click;
            tsPhieuNhap.Click += TsPhieuNhap_Click;
            tsTroGiup.Click += TsTroGiup_Click;
            tsHoaDon.Click += TsHoaDon_Click;
        }

        private void TsHoaDon_Click(object sender, EventArgs e)
        {
            //if (this.formListBill is null || this.formListBill.IsDisposed)
            //{
            //    this.formListBill = new frmListBill();
            //    this.formListBill.MdiParent = this;
            //    this.formListBill.Show();
            //}
            //else
            //{
            //    this.formListBill.Select();
            //}
            frmListBill formBill = new frmListBill();
            formBill.ShowDialog();
        }

        private void TsTroGiup_Click(object sender, EventArgs e)
        {
            
        }

        private void TsPhieuNhap_Click(object sender, EventArgs e)
        {
            frmImport formImport = new frmImport();
            formImport.ShowDialog();
        }

        private void TsSach_Click(object sender, EventArgs e)
        {
            //if (this.formBook is null || this.formBook.IsDisposed)
            //{
            //    this.formBook = new frmBook();
            //    this.formBook.MdiParent = this;
            //    this.formBook.Show();
            //}
            //else
            //{
            //    this.formBook.Select();
            //}
            frmBook formBook = new frmBook();
            formBook.ShowDialog();
        }

        private void TsNhanVien_Click(object sender, EventArgs e)
        {
            frmEmpoy formEmploy = new frmEmpoy();
            formEmploy.ShowDialog();
        }

        private void TsKhachHang_Click(object sender, EventArgs e)
        {
            //if (this.Member is null || this.Member.IsDisposed)
            //{
            //    this.Member = new frmMember();
            //    this.Member.MdiParent = this;
            //    this.Member.Show();
            //}
            //else
            //{
            //    this.Member.Select();
            //}
            frmMember formMember = new frmMember();
            formMember.ShowDialog();
        }

        private void TsThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TsFile_Click(object sender, EventArgs e)
        {
            
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            //if (this.ActiveMdiChild == null)
            //{
            //    return;
            //}
            //this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
            //if (this.ActiveMdiChild.Tag == null)
            //{
            //    TabPage tp = new TabPage(this.ActiveMdiChild.Text);
            //    tp.Tag = this.ActiveMdiChild;
            //    tp.Parent = this.tabControl1;
            //    this.tabControl1.SelectedTab = tp;
            //    this.ActiveMdiChild.Tag = tp;
            //    this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;
            //}
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            //((sender as Form).Tag as TabPage).Dispose();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.tabControl1.SelectedTab != null && this.tabControl1.SelectedTab.Tag != null)
            //{
            //    (this.tabControl1.SelectedTab.Tag as Form).Select();
            //}
        }
    }
}
