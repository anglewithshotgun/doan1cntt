namespace QLchSach
{
    partial class frmBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbnxb = new System.Windows.Forms.ComboBox();
            this.cbbMtl = new System.Windows.Forms.ComboBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.cbbMtg = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dgvBook = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.cbbMs = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(356, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH MỤC SÁCH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(84, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã sách:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(84, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nhà xuất bản:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(84, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Thể loại:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(84, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tên sách:";
            // 
            // cbbnxb
            // 
            this.cbbnxb.FormattingEnabled = true;
            this.cbbnxb.Items.AddRange(new object[] {
            "Nhà Xuất Bản Cengage",
            "Nhà Xuất Bản Chính Trị Quốc Gia Sự Thật",
            "Nhà Xuất Bản Đại Học Quốc Gia Hà Nội",
            "Nhà Xuất Bản Dân Trí",
            "Nhà Xuất Bản Giáo Dục Việt Nam",
            "Nhà Xuất Bản Hồng Đức",
            "Nhà Xuất Bản Hà Nội",
            "Nhà Xuất Bản Hội Nhà Văn",
            "Nhà Xuất Bản Kim Đồng",
            "Nhà Xuất Bản Khoa Học Xã Hội",
            "Nhà Xuất Bản Kinh Tế HCM",
            "Nhà Xuất Bản Lao động",
            "Nhà Xuất Bản Phụ Nữ",
            "Nhà Xuất Bản Trẻ",
            "Nhà Xuất Bản Thế Giới",
            "Nhà Xuất Bản Tổng Hợp TP.HCM",
            "Nhà Xuất Bản Thanh Niên",
            "Nhà Xuất Bản Tri Thức"});
            this.cbbnxb.Location = new System.Drawing.Point(183, 180);
            this.cbbnxb.Name = "cbbnxb";
            this.cbbnxb.Size = new System.Drawing.Size(230, 23);
            this.cbbnxb.TabIndex = 2;
            // 
            // cbbMtl
            // 
            this.cbbMtl.FormattingEnabled = true;
            this.cbbMtl.Items.AddRange(new object[] {
            "Chính trị",
            "Hồi ký",
            "Kinh tế",
            "Nghệ thuật - Giải trí",
            "Phát triển trí tuệ",
            "Sách giáo khoa",
            "Sách ngoại ngữ",
            "Từ điển",
            "Tin học",
            "Tâm lý - Kỹ năng sống",
            "Thiếu Nhi",
            "Truyện tranh",
            "Tiểu thuyết",
            "Văn học"});
            this.cbbMtl.Location = new System.Drawing.Point(183, 137);
            this.cbbMtl.Name = "cbbMtl";
            this.cbbMtl.Size = new System.Drawing.Size(230, 23);
            this.cbbMtl.TabIndex = 2;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(183, 98);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(230, 23);
            this.txtTenSach.TabIndex = 3;
            // 
            // cbbMtg
            // 
            this.cbbMtg.FormattingEnabled = true;
            this.cbbMtg.Items.AddRange(new object[] {
            "Alain de Botton",
            "Barbara Coloroso",
            "Bộ Giáo dục và Đào tạo",
            "Bích Hằng",
            "Bodo Schafer",
            "Chuyện",
            "Carl Gustav Jung",
            "Eriko Sato",
            "GS. Hoàng Phê",
            "GS Makoto Shichida",
            "Haruki Murakami",
            "Johan Cruyff",
            "Jamey Stegmaier",
            "Kito Aya",
            "Lý Dịch Phong",
            "Lê Huy Khoa",
            "Li Ya Bin",
            "Michelle Obama",
            "Markus Rach",
            "Michael Schulman",
            "Nguyễn Đức Dũng",
            "NGregory Mankiw",
            "Nguyên Thảo",
            "Nia Maerani",
            "Nguyễn Khắc Phi",
            "Niccolo Machiavelli",
            "Nikola Tesla",
            "Nguyễn Thu Hương",
            "Patricia Campbell",
            "Paul Kalanithi",
            "Quốc Hội",
            "Sơn Tùng M-TP",
            "TS Sally Ward",
            "Trương Văn Giới",
            "The Windy",
            "Viện Ngôn Ngữ Hackers"});
            this.cbbMtg.Location = new System.Drawing.Point(630, 76);
            this.cbbMtg.Name = "cbbMtg";
            this.cbbMtg.Size = new System.Drawing.Size(214, 23);
            this.cbbMtg.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(531, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "Giá bán:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(531, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "Số lượng tồn:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(531, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 19);
            this.label9.TabIndex = 1;
            this.label9.Text = "Tác giả:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(630, 154);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(214, 23);
            this.txtSoLuong.TabIndex = 3;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(630, 115);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(214, 23);
            this.txtGiaBan.TabIndex = 3;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(54, 226);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 32);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(637, 226);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 32);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(794, 226);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(90, 32);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Tra cứu";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(246, 226);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 32);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dgvBook
            // 
            this.dgvBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBook.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvBook.Location = new System.Drawing.Point(0, 275);
            this.dgvBook.Name = "dgvBook";
            this.dgvBook.Size = new System.Drawing.Size(981, 307);
            this.dgvBook.TabIndex = 4;
            this.dgvBook.Text = "dataGridView1";
            this.dgvBook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBook_CellClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(454, 226);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 32);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // cbbMs
            // 
            this.cbbMs.FormattingEnabled = true;
            this.cbbMs.Items.AddRange(new object[] {
            "1987R17   ",
            "301CDTTH33",
            "BACNP22   ",
            "BCCM02    ",
            "BIL35     ",
            "BLTTHS06  ",
            "BMOCBBN23 ",
            "CCHN21    ",
            "CDKLCN05  ",
            "CDTDTC13  ",
            "CLDR25    ",
            "CLGVCD14  ",
            "CN29      ",
            "CNBCT19   ",
            "CTGM16    ",
            "DL30      ",
            "HIR31     ",
            "HPVNQCTK10",
            "iKVTBTC20 ",
            "KHTHTK01  ",
            "KTHVM11   ",
            "KTTH4.012 ",
            "MLNM04    ",
            "MSNHKN18  ",
            "NPTHHD34  ",
            "NPTNCB32  ",
            "NV926     ",
            "QVTCT09   ",
            "SAUCTH08  ",
            "SH27      ",
            "TDCXCB24  ",
            "TDHV39    ",
            "TDOA36    ",
            "TDTL38    ",
            "TDTT07    ",
            "TDTV37    ",
            "TĐV40     ",
            "TH28      ",
            "TNGKNVCB03",
            "TTM15     "});
            this.cbbMs.Location = new System.Drawing.Point(183, 59);
            this.cbbMs.Name = "cbbMs";
            this.cbbMs.Size = new System.Drawing.Size(230, 23);
            this.cbbMs.TabIndex = 2;
            // 
            // frmBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 582);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvBook);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbbMtg);
            this.Controls.Add(this.txtTenSach);
            this.Controls.Add(this.cbbMtl);
            this.Controls.Add(this.cbbnxb);
            this.Controls.Add(this.cbbMs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmBook";
            this.Text = "Books";
            this.Load += new System.EventHandler(this.frmBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbnxb;
        private System.Windows.Forms.ComboBox cbbMtl;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.ComboBox cbbMtg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView dgvBook;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ComboBox cbbMs;
    }
}