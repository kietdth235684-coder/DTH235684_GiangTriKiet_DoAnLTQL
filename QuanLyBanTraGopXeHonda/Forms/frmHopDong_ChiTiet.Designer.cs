namespace QuanLyBanTraGopXeHonda.Forms
{
    partial class frmHopDong_ChiTiet
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            grpThongTinHopDong = new GroupBox();
            label1 = new Label();
            cboNhanVien = new ComboBox();
            label2 = new Label();
            cboKhachHang = new ComboBox();
            label3 = new Label();
            cboXe = new ComboBox();
            label4 = new Label();
            dtpNgayLap = new DateTimePicker();
            grpThongTinChiTiet = new GroupBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            dtpNgayThanhToan = new DateTimePicker();
            numSoThang = new NumericUpDown();
            numSoTien = new NumericUpDown();
            btnXacNhanThanhToan = new Button();
            btnXoa = new Button();
            dataGridView = new DataGridView();
            panelBottom = new Panel();
            btnLuuHopDong = new Button();
            btnInHopDong = new Button();
            btnThoat = new Button();
            XeID = new DataGridViewTextBoxColumn();
            TenXe = new DataGridViewTextBoxColumn();
            NgayThanhToan = new DataGridViewTextBoxColumn();
            SoThangThanhToan = new DataGridViewTextBoxColumn();
            SoTienThanhToan = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            grpThongTinHopDong.SuspendLayout();
            grpThongTinChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoTien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // grpThongTinHopDong
            // 
            grpThongTinHopDong.Controls.Add(label1);
            grpThongTinHopDong.Controls.Add(cboNhanVien);
            grpThongTinHopDong.Controls.Add(label2);
            grpThongTinHopDong.Controls.Add(cboKhachHang);
            grpThongTinHopDong.Controls.Add(label3);
            grpThongTinHopDong.Controls.Add(cboXe);
            grpThongTinHopDong.Controls.Add(label4);
            grpThongTinHopDong.Controls.Add(dtpNgayLap);
            grpThongTinHopDong.Dock = DockStyle.Top;
            grpThongTinHopDong.Location = new Point(0, 0);
            grpThongTinHopDong.Name = "grpThongTinHopDong";
            grpThongTinHopDong.Size = new Size(1250, 80);
            grpThongTinHopDong.TabIndex = 0;
            grpThongTinHopDong.TabStop = false;
            grpThongTinHopDong.Text = "Thông tin hợp đồng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 35);
            label1.Name = "label1";
            label1.Size = new Size(123, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhân viên lập (*):";
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(155, 32);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(200, 28);
            cboNhanVien.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(370, 34);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 1;
            label2.Text = "Khách hàng (*):";
            // 
            // cboKhachHang
            // 
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(490, 32);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(265, 28);
            cboKhachHang.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(770, 35);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 2;
            label3.Text = "Xe (*):";
            // 
            // cboXe
            // 
            cboXe.FormattingEnabled = true;
            cboXe.Location = new Point(825, 32);
            cboXe.Name = "cboXe";
            cboXe.Size = new Size(180, 28);
            cboXe.TabIndex = 2;
            cboXe.SelectionChangeCommitted += cboXe_SelectionChangeCommitted;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1015, 35);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 3;
            label4.Text = "Ngày lập";
            // 
            // dtpNgayLap
            // 
            dtpNgayLap.Format = DateTimePickerFormat.Short;
            dtpNgayLap.Location = new Point(1090, 33);
            dtpNgayLap.Name = "dtpNgayLap";
            dtpNgayLap.Size = new Size(123, 27);
            dtpNgayLap.TabIndex = 3;
            // 
            // grpThongTinChiTiet
            // 
            grpThongTinChiTiet.Controls.Add(label5);
            grpThongTinChiTiet.Controls.Add(label6);
            grpThongTinChiTiet.Controls.Add(label7);
            grpThongTinChiTiet.Controls.Add(label8);
            grpThongTinChiTiet.Controls.Add(dtpNgayThanhToan);
            grpThongTinChiTiet.Controls.Add(numSoThang);
            grpThongTinChiTiet.Controls.Add(numSoTien);
            grpThongTinChiTiet.Controls.Add(btnXacNhanThanhToan);
            grpThongTinChiTiet.Controls.Add(btnXoa);
            grpThongTinChiTiet.Controls.Add(dataGridView);
            grpThongTinChiTiet.Dock = DockStyle.Fill;
            grpThongTinChiTiet.Location = new Point(0, 80);
            grpThongTinChiTiet.Name = "grpThongTinChiTiet";
            grpThongTinChiTiet.Size = new Size(1250, 430);
            grpThongTinChiTiet.TabIndex = 1;
            grpThongTinChiTiet.TabStop = false;
            grpThongTinChiTiet.Text = "Thông tin chi tiết hợp đồng";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 33);
            label5.Name = "label5";
            label5.Size = new Size(142, 20);
            label5.TabIndex = 0;
            label5.Text = "Ngày thành toán (*):";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(320, 33);
            label6.Name = "label6";
            label6.Size = new Size(91, 20);
            label6.TabIndex = 1;
            label6.Text = "Số tháng (*):";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(600, 33);
            label7.Name = "label7";
            label7.Size = new Size(153, 20);
            label7.TabIndex = 2;
            label7.Text = "Số tiền thanh toán (*):";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 5);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 3;
            // 
            // dtpNgayThanhToan
            // 
            dtpNgayThanhToan.Format = DateTimePickerFormat.Short;
            dtpNgayThanhToan.Location = new Point(180, 28);
            dtpNgayThanhToan.Name = "dtpNgayThanhToan";
            dtpNgayThanhToan.Size = new Size(124, 27);
            dtpNgayThanhToan.TabIndex = 0;
            // 
            // numSoThang
            numSoTien.Name = "numSoTien";
            numSoTien.Size = new Size(140, 27);
            numSoTien.TabIndex = 2;
            numSoTien.ThousandsSeparator = true;
            // 
            // btnXacNhanThanhToan
            // 
            btnXacNhanThanhToan.Location = new Point(915, 28);
            btnXacNhanThanhToan.Name = "btnXacNhanThanhToan";
            btnXacNhanThanhToan.Size = new Size(169, 30);
            btnXacNhanThanhToan.TabIndex = 3;
            btnXacNhanThanhToan.Text = "Xác nhận thanh toán";
            btnXacNhanThanhToan.UseVisualStyleBackColor = true;
            btnXacNhanThanhToan.Click += btnXacNhanThanhToan_Click;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(1100, 28);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(130, 30);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { XeID, TenXe, NgayThanhToan, SoThangThanhToan, SoTienThanhToan, ThanhTien });
            dataGridView.Location = new Point(3, 68);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(1244, 355);
            dataGridView.TabIndex = 5;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnLuuHopDong);
            panelBottom.Controls.Add(btnInHopDong);
            panelBottom.Controls.Add(btnThoat);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 510);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1250, 50);
            panelBottom.TabIndex = 2;
            // 
            // btnLuuHopDong
            // 
            btnLuuHopDong.Location = new Point(497, 10);
            btnLuuHopDong.Name = "btnLuuHopDong";
            btnLuuHopDong.Size = new Size(189, 30);
            btnLuuHopDong.TabIndex = 0;
            btnLuuHopDong.Text = "Lưu hợp đồng";
            btnLuuHopDong.UseVisualStyleBackColor = true;
            btnLuuHopDong.Click += btnLuuHopDong_Click;
            // 
            // btnInHopDong
            // 
            btnInHopDong.Location = new Point(302, 10);
            btnInHopDong.Name = "btnInHopDong";
            btnInHopDong.Size = new Size(189, 30);
            btnInHopDong.TabIndex = 1;
            btnInHopDong.Text = "In hợp đồng...";
            btnInHopDong.UseVisualStyleBackColor = true;
            btnInHopDong.Click += btnInHopDong_Click;
            // 
            // btnThoat
            // 
            btnThoat.ForeColor = Color.Blue;
            btnThoat.Location = new Point(692, 10);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(189, 30);
            btnThoat.TabIndex = 2;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // XeID
            // 
            XeID.DataPropertyName = "XeID";
            XeID.HeaderText = "ID";
            XeID.MinimumWidth = 6;
            XeID.Name = "XeID";
            XeID.ReadOnly = true;
            XeID.Visible = false;
            // 
            // TenXe
            // 
            TenXe.DataPropertyName = "TenXe";
            TenXe.HeaderText = "Tên xe";
            TenXe.MinimumWidth = 6;
            TenXe.Name = "TenXe";
            TenXe.ReadOnly = true;
            // 
            // NgayThanhToan
            // 
            NgayThanhToan.DataPropertyName = "NgayThanhToan";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "dd/MM/yyyy";
            NgayThanhToan.DefaultCellStyle = dataGridViewCellStyle9;
            NgayThanhToan.HeaderText = "Ngày thanh toán";
            NgayThanhToan.MinimumWidth = 6;
            NgayThanhToan.Name = "NgayThanhToan";
            NgayThanhToan.ReadOnly = true;
            // 
            // SoThangThanhToan
            // 
            SoThangThanhToan.DataPropertyName = "SoThangThanhToan";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            SoThangThanhToan.DefaultCellStyle = dataGridViewCellStyle10;
            SoThangThanhToan.HeaderText = "Số tháng";
            SoThangThanhToan.MinimumWidth = 6;
            SoThangThanhToan.Name = "SoThangThanhToan";
            SoThangThanhToan.ReadOnly = true;
            // 
            // SoTienThanhToan
            // 
            SoTienThanhToan.DataPropertyName = "SoTienThanhToan";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            SoTienThanhToan.DefaultCellStyle = dataGridViewCellStyle11;
            SoTienThanhToan.HeaderText = "Số tiền thanh toán";
            SoTienThanhToan.MinimumWidth = 6;
            SoTienThanhToan.Name = "SoTienThanhToan";
            SoTienThanhToan.ReadOnly = true;
            // 
            // ThanhTien
            // 
            ThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            dataGridViewCellStyle12.ForeColor = Color.Blue;
            dataGridViewCellStyle12.Format = "N0";
            ThanhTien.DefaultCellStyle = dataGridViewCellStyle12;
            ThanhTien.HeaderText = "Thành tiền";
            ThanhTien.MinimumWidth = 6;
            ThanhTien.Name = "ThanhTien";
            ThanhTien.ReadOnly = true;
            // 
            // frmHopDong_ChiTiet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 560);
            Controls.Add(grpThongTinChiTiet);
            Controls.Add(grpThongTinHopDong);
            Controls.Add(panelBottom);
            Name = "frmHopDong_ChiTiet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hợp đồng chi tiết";
            Load += frmHopDong_ChiTiet_Load;
            grpThongTinHopDong.ResumeLayout(false);
            grpThongTinHopDong.PerformLayout();
            grpThongTinChiTiet.ResumeLayout(false);
            grpThongTinChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoTien).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTinHopDong;
        private Label label1;
        private ComboBox cboNhanVien;
        private Label label2;
        private ComboBox cboKhachHang;
        private Label label3;
        private ComboBox cboXe;
        private Label label4;
        private DateTimePicker dtpNgayLap;
        private GroupBox grpThongTinChiTiet;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private DateTimePicker dtpNgayThanhToan;
        private NumericUpDown numSoThang;
        private NumericUpDown numSoTien;
        private Button btnXacNhanThanhToan;
        private Button btnXoa;
        private DataGridView dataGridView;
        private Panel panelBottom;
        private Button btnLuuHopDong;
        private Button btnInHopDong;
        private Button btnThoat;
        private DataGridViewTextBoxColumn XeID;
        private DataGridViewTextBoxColumn TenXe;
        private DataGridViewTextBoxColumn NgayThanhToan;
        private DataGridViewTextBoxColumn SoThangThanhToan;
        private DataGridViewTextBoxColumn SoTienThanhToan;
        private DataGridViewTextBoxColumn ThanhTien;
    }
}
