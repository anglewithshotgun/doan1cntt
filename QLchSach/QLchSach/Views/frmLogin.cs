using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLchSach.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QLchSach
{
    public partial class frmLogin : Form
    {
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //this.txtTaiKhoan.Focus();
            this.ActiveControl = this.txtTaiKhoan;
            this.helpProvider1.SetShowHelp(this.txtTaiKhoan, true);
            this.helpProvider1.SetHelpString(this.txtTaiKhoan, "Nhập tài khoản");
            this.helpProvider1.SetShowHelp(this.txtMatKhau, true);
            this.helpProvider1.SetHelpString(this.txtMatKhau, "Nhập mật khẩu");
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (errorP() == 1)
            {
                return;
            }
            login();
        }
        private void login()
        {
            var context = new Dtb_NhaSachContext();
            var taikhoan = new SqlParameter("@p0", this.txtTaiKhoan.Text);
            var matkhau = new SqlParameter("@p1", this.txtMatKhau.Text);
            var dangNhap = context.Taikhoan.FromSqlRaw("dangnhap @p0,@p1", taikhoan, matkhau).ToList();
            if (dangNhap.Count == 1)
            {
                this.Hide();
                frmMain formMain = new frmMain();
                formMain.ShowDialog();              
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
            }
        }
        private int errorP()
        {
            if (this.txtTaiKhoan.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtTaiKhoan, "Nhập tài khoản");
                return 1;
            }
            else this.errorProvider1.SetError(this.txtTaiKhoan, null);

            if (this.txtMatKhau.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtMatKhau, "Nhập mật khẩu");
                return 1;
            }
            else this.errorProvider1.SetError(this.txtMatKhau, null);
            return 0;
        }
    }
}
