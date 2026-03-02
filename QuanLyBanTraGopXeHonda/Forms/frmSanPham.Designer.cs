namespace QuanLyBanTraGopXeHonda.Forms
{
    partial class frmSanPham
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
            cboPhanLoai = new ComboBox();
            cboHangXe = new ComboBox();
            btnXoa = new Button();
            btnThem = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            txtTenXe = new TextBox();
            txtMoTa = new TextBox();
            btnDoiAnh = new Button();
            picHinhAnh = new PictureBox();
            numDonGia = new NumericUpDown();
            numSoLuong = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            btnTimKiem = new Button();
            btnThoat = new Button();
            btnXuat = new Button();
            btnNhap = new Button();
            btnLuu = new Button();
            btnHuyBo = new Button();
            btnSua = new Button();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            TenLoai = new DataGridViewTextBoxColumn();
            TenHangXe = new DataGridViewTextBoxColumn();
            TenSanPham = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            HinhAnh = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // cboPhanLoai
            // 
            cboPhanLoai.FormattingEnabled = true;
            cboPhanLoai.Location = new Point(141, 37);
            cboPhanLoai.Name = "cboPhanLoai";
            cboPhanLoai.Size = new Size(151, 28);
            cboPhanLoai.TabIndex = 0;
            // 
            // cboHangXe
            // 
            cboHangXe.FormattingEnabled = true;
            cboHangXe.Location = new Point(141, 75);
            cboHangXe.Name = "cboHangXe";
            cboHangXe.Size = new Size(151, 28);
            cboHangXe.TabIndex = 1;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(170, 211);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(84, 29);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += BtnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(62, 211);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(102, 29);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 40);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 4;
            label1.Text = "Phân loại:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 75);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 5;
            label2.Text = "Hãng xe:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 166);
            label3.Name = "label3";
            label3.Size = new Size(119, 20);
            label3.TabIndex = 6;
            label3.Text = "Mô tả sản phẩm:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 122);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 7;
            label4.Text = "Tên sản phẩm:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtTenXe);
            groupBox1.Controls.Add(txtMoTa);
            groupBox1.Controls.Add(btnDoiAnh);
            groupBox1.Controls.Add(picHinhAnh);
            groupBox1.Controls.Add(numDonGia);
            groupBox1.Controls.Add(numSoLuong);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnXuat);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(btnNhap);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnHuyBo);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Location = new Point(3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1085, 264);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // txtTenXe
            // 
            txtTenXe.Location = new Point(138, 115);
            txtTenXe.Name = "txtTenXe";
            txtTenXe.Size = new Size(656, 27);
            txtTenXe.TabIndex = 16;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(138, 160);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(656, 27);
            txtMoTa.TabIndex = 11;
            // 
            // btnDoiAnh
            // 
            btnDoiAnh.Location = new Point(800, 17);
            btnDoiAnh.Name = "btnDoiAnh";
            btnDoiAnh.Size = new Size(102, 29);
            btnDoiAnh.TabIndex = 11;
            btnDoiAnh.Text = "Đổi Ảnh";
            btnDoiAnh.UseVisualStyleBackColor = true;
            btnDoiAnh.Click += btnDoiAnh_Click;
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(596, 14);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(198, 95);
            picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            picHinhAnh.TabIndex = 15;
            picHinhAnh.TabStop = false;
            // 
            // numDonGia
            // 
            numDonGia.Location = new Point(428, 77);
            numDonGia.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(150, 27);
            numDonGia.TabIndex = 14;
            numDonGia.ThousandsSeparator = true;
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(428, 39);
            numSoLuong.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(150, 27);
            numSoLuong.TabIndex = 13;
            numSoLuong.ThousandsSeparator = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(347, 79);
            label6.Name = "label6";
            label6.Size = new Size(66, 20);
            label6.TabIndex = 12;
            label6.Text = "Đơn Giá:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(347, 41);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 11;
            label5.Text = "Số Lượng:";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(692, 211);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(102, 29);
            btnTimKiem.TabIndex = 8;
            btnTimKiem.Text = "Tìm Kiếm ";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.ForeColor = Color.Blue;
            btnThoat.Location = new Point(584, 211);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(102, 29);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(908, 211);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(102, 29);
            btnXuat.TabIndex = 11;
            btnXuat.Text = "Xuất";
            btnXuat.UseVisualStyleBackColor = true;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(800, 211);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(102, 29);
            btnNhap.TabIndex = 9;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(368, 211);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(102, 29);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Location = new Point(476, 211);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(102, 29);
            btnHuyBo.TabIndex = 6;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(260, 211);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(102, 29);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa ";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(3, 274);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1085, 214);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách Sản Phẩm";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, TenLoai, TenHangXe, TenSanPham, SoLuong, DonGia, HinhAnh });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 23);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1079, 188);
            dataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // TenLoai
            // 
            TenLoai.DataPropertyName = "TenLoai";
            TenLoai.HeaderText = "Phân Loại";
            TenLoai.MinimumWidth = 6;
            TenLoai.Name = "TenLoai";
            // 
            // TenHangXe
            // 
            TenHangXe.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TenHangXe.DataPropertyName = "TenHangXe";
            TenHangXe.HeaderText = "Hãng Xe";
            TenHangXe.MinimumWidth = 6;
            TenHangXe.Name = "TenHangXe";
            TenHangXe.Width = 140;
            // 
            // TenSanPham
            // 
            TenSanPham.DataPropertyName = "TenSanPham";
            TenSanPham.HeaderText = "Tên Sản Phẩm";
            TenSanPham.MinimumWidth = 6;
            TenSanPham.Name = "TenSanPham";
            // 
            // SoLuong
            // 
            SoLuong.HeaderText = "Số Lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            // 
            // DonGia
            // 
            DonGia.DataPropertyName = "DonGia";
            DonGia.HeaderText = "Đơn Giá ";
            DonGia.MinimumWidth = 6;
            DonGia.Name = "DonGia";
            // 
            // HinhAnh
            // 
            HinhAnh.DataPropertyName = "HinhAnh";
            HinhAnh.HeaderText = "Hình Ảnh";
            HinhAnh.MinimumWidth = 6;
            HinhAnh.Name = "HinhAnh";
            // 
            // frmSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 500);
            Controls.Add(groupBox2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboHangXe);
            Controls.Add(cboPhanLoai);
            Controls.Add(groupBox1);
            Name = "frmSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SanPham";
            Activated += frmSanPham_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboPhanLoai;
        private ComboBox cboHangXe;
        private Button btnXoa;
        private Button btnThem;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private Button btnSua;
        private Button btnLuu;
        private Label label6;
        private Label label5;
        private Button btnTimKiem;
        private Button btnThoat;
        private Button btnXuat;
        private Button btnNhap;
        private Button btnHuyBo;
        private NumericUpDown numDonGia;
        private NumericUpDown numSoLuong;
        private TextBox textBox2;
        private TextBox txtMoTa;
        private Button btnDoiAnh;
        private PictureBox picHinhAnh;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn TenLoai;
        private DataGridViewTextBoxColumn TenHangXe;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn HinhAnh;
        private TextBox txtTenXe;
    }
}