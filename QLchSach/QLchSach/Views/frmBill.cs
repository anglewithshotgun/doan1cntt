using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLchSach.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace QLchSach
{
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
        }

        private void btnThemHoaDoncthd_Click(object sender, EventArgs e)
        {
            try
            {
                var context = new Dtb_NhaSachContext();

            }
            catch 
            {

                return;
            }
        }
    }
}
