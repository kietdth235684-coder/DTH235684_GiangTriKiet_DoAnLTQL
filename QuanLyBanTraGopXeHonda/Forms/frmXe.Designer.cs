namespace QuanLyBanTraGopXeHonda.Forms
{
    partial class frmXe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            numGiaBan = new NumericUpDown();
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
            TenXe = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            GiaBan = new DataGridViewTextBoxColumn();
            HinhAnh = new DataGridViewImageColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGiaBan).BeginInit();
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
            cboHangXe.Location = new Point(141, 72);
            cboHangXe.Name = "cboHangXe";
            cboHangXe.Size = new Size(151, 28);
            cboHangXe.TabIndex = 1;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(129, 211);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(84, 29);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(6, 211);
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
            label1.Size = new Size(93, 20);
            label1.TabIndex = 4;
            label1.Text = "Phân loại (*):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 75);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 5;
            label2.Text = "Hãng xe (*):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 166);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 6;
            label3.Text = "Mô tả xe:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 122);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 7;
            label4.Text = "Tên xe (*):";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtTenXe);
            groupBox1.Controls.Add(txtMoTa);
            groupBox1.Controls.Add(btnDoiAnh);
            groupBox1.Controls.Add(picHinhAnh);
            groupBox1.Controls.Add(numGiaBan);
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
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cboPhanLoai);
            groupBox1.Controls.Add(cboHangXe);
            groupBox1.Location = new Point(3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1085, 264);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin xe";
            // 
            // txtTenXe
            // 
            txtTenXe.Location = new Point(138, 115);
            txtTenXe.Name = "txtTenXe";
            txtTenXe.Size = new Size(705, 27);
            txtTenXe.TabIndex = 16;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(138, 160);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(705, 27);
            txtMoTa.TabIndex = 11;
            // 
            // btnDoiAnh
            // 
            btnDoiAnh.Location = new Point(849, 14);
            btnDoiAnh.Name = "btnDoiAnh";
            btnDoiAnh.Size = new Size(102, 29);
            btnDoiAnh.TabIndex = 11;
            btnDoiAnh.Text = "Đổi ảnh...";
            btnDoiAnh.UseVisualStyleBackColor = true;
            btnDoiAnh.Click += btnDoiAnh_Click;
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(619, 14);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(224, 90);
            picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            picHinhAnh.TabIndex = 15;
            picHinhAnh.TabStop = false;
            // 
            // numGiaBan
            // 
            numGiaBan.Location = new Point(445, 73);
            numGiaBan.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numGiaBan.Name = "numGiaBan";
            numGiaBan.Size = new Size(151, 27);
            numGiaBan.TabIndex = 14;
            numGiaBan.ThousandsSeparator = true;
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(445, 38);
            numSoLuong.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(151, 27);
            numSoLuong.TabIndex = 13;
            numSoLuong.ThousandsSeparator = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(347, 75);
            label6.Name = "label6";
            label6.Size = new Size(83, 20);
            label6.TabIndex = 12;
            label6.Text = "Giá bán (*):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(347, 40);
            label5.Name = "label5";
            label5.Size = new Size(92, 20);
            label5.TabIndex = 11;
            label5.Text = "Số lượng (*):";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(726, 211);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(102, 29);
            btnTimKiem.TabIndex = 8;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnThoat
            // 
            btnThoat.ForeColor = Color.Blue;
            btnThoat.Location = new Point(603, 211);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(102, 29);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(972, 211);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(102, 29);
            btnXuat.TabIndex = 11;
            btnXuat.Text = "Xuất...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(849, 211);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(102, 29);
            btnNhap.TabIndex = 9;
            btnNhap.Text = "Nhập...";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(357, 211);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(102, 29);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Location = new Point(480, 211);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(102, 29);
            btnHuyBo.TabIndex = 6;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(234, 211);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(102, 29);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(3, 274);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1085, 250);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách xe";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, TenLoai, TenHangXe, TenXe, SoLuong, GiaBan, HinhAnh });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 23);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1079, 224);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // TenLoai
            // 
            TenLoai.DataPropertyName = "TenLX";
            TenLoai.HeaderText = "Phân Loại";
            TenLoai.MinimumWidth = 6;
            TenLoai.Name = "TenLoai";
            TenLoai.ReadOnly = true;
            // 
            // TenHangXe
            // 
            TenHangXe.DataPropertyName = "TenHX";
            TenHangXe.HeaderText = "Hãng Xe";
            TenHangXe.MinimumWidth = 6;
            TenHangXe.Name = "TenHangXe";
            TenHangXe.ReadOnly = true;
            // 
            // TenXe
            // 
            TenXe.DataPropertyName = "TenXe";
            TenXe.HeaderText = "Tên Xe";
            TenXe.MinimumWidth = 6;
            TenXe.Name = "TenXe";
            TenXe.ReadOnly = true;
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            SoLuong.DefaultCellStyle = dataGridViewCellStyle1;
            SoLuong.HeaderText = "Số Lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            // 
            // GiaBan
            // 
            GiaBan.DataPropertyName = "GiaBan";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            GiaBan.DefaultCellStyle = dataGridViewCellStyle2;
            GiaBan.HeaderText = "Giá Bán";
            GiaBan.MinimumWidth = 6;
            GiaBan.Name = "GiaBan";
            GiaBan.ReadOnly = true;
            // 
            // HinhAnh
            // 
            HinhAnh.DataPropertyName = "HinhAnh";
            HinhAnh.HeaderText = "Hình Ảnh";
            HinhAnh.ImageLayout = DataGridViewImageCellLayout.Stretch;
            HinhAnh.MinimumWidth = 6;
            HinhAnh.Name = "HinhAnh";
            HinhAnh.ReadOnly = true;
            // 
            // frmXe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 540);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmXe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xe";
            Load += frmXe_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGiaBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
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
        private NumericUpDown numGiaBan;
        private NumericUpDown numSoLuong;
        private TextBox txtMoTa;
        private Button btnDoiAnh;
        private PictureBox picHinhAnh;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private TextBox txtTenXe;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn TenLoai;
        private DataGridViewTextBoxColumn TenHangXe;
        private DataGridViewTextBoxColumn TenXe;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn GiaBan;
        private DataGridViewImageColumn HinhAnh;
    }
}
