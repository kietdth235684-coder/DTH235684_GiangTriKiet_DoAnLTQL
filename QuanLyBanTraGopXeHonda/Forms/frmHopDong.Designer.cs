namespace QuanLyBanTraGopXeHonda.Forms
{
    partial class frmHopDong
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dataGridView = new DataGridView();
            panelBottom = new Panel();
            btnLapHopDong = new Button();
            btnInHopDong = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            btnTimKiem = new Button();
            btnXuat = new Button();
            ID = new DataGridViewTextBoxColumn();
            ID_Goc = new DataGridViewTextBoxColumn();
            HoVaTenNhanVien = new DataGridViewTextBoxColumn();
            HoVaTenKhachHang = new DataGridViewTextBoxColumn();
            TenXe = new DataGridViewTextBoxColumn();
            NgayLapHD = new DataGridViewTextBoxColumn();
            TongTienHopDong = new DataGridViewTextBoxColumn();
            XemChiTiet = new DataGridViewLinkColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1100, 440);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách hợp đồng";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, ID_Goc, HoVaTenNhanVien, HoVaTenKhachHang, TenXe, NgayLapHD, TongTienHopDong, XemChiTiet });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(1094, 414);
            dataGridView.TabIndex = 0;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnLapHopDong);
            panelBottom.Controls.Add(btnInHopDong);
            panelBottom.Controls.Add(btnSua);
            panelBottom.Controls.Add(btnXoa);
            panelBottom.Controls.Add(btnThoat);
            panelBottom.Controls.Add(btnTimKiem);
            panelBottom.Controls.Add(btnXuat);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 440);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1100, 50);
            panelBottom.TabIndex = 1;
            // 
            // btnLapHopDong
            // 
            btnLapHopDong.Location = new Point(12, 10);
            btnLapHopDong.Name = "btnLapHopDong";
            btnLapHopDong.Size = new Size(152, 30);
            btnLapHopDong.TabIndex = 0;
            btnLapHopDong.Text = "Lập hợp đồng mới...";
            btnLapHopDong.UseVisualStyleBackColor = true;
            btnLapHopDong.Click += btnLapHopDong_Click;
            // 
            // btnInHopDong
            // 
            btnInHopDong.Location = new Point(224, 10);
            btnInHopDong.Name = "btnInHopDong";
            btnInHopDong.Size = new Size(110, 30);
            btnInHopDong.TabIndex = 1;
            btnInHopDong.Text = "In hợp đồng...";
            btnInHopDong.UseVisualStyleBackColor = true;
            btnInHopDong.Click += btnInHopDong_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(394, 10);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(80, 30);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa...";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(534, 10);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(80, 30);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.ForeColor = Color.Blue;
            btnThoat.Location = new Point(674, 10);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(80, 30);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(814, 10);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(100, 30);
            btnTimKiem.TabIndex = 5;
            btnTimKiem.Text = "Tìm kiếm...";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(974, 10);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(110, 30);
            btnXuat.TabIndex = 6;
            btnXuat.Text = "Xuất Excel...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // ID_Goc
            // 
            ID_Goc.DataPropertyName = "ID_Goc";
            ID_Goc.HeaderText = "ID_Goc";
            ID_Goc.Name = "ID_Goc";
            ID_Goc.ReadOnly = true;
            ID_Goc.Visible = false;
            // 
            // HoVaTenNhanVien
            // 
            HoVaTenNhanVien.DataPropertyName = "HoVaTenNhanVien";
            HoVaTenNhanVien.HeaderText = "Nhân viên";
            HoVaTenNhanVien.MinimumWidth = 6;
            HoVaTenNhanVien.Name = "HoVaTenNhanVien";
            HoVaTenNhanVien.ReadOnly = true;
            // 
            // HoVaTenKhachHang
            // 
            HoVaTenKhachHang.DataPropertyName = "HoVaTenKhachHang";
            HoVaTenKhachHang.HeaderText = "Khách hàng";
            HoVaTenKhachHang.MinimumWidth = 6;
            HoVaTenKhachHang.Name = "HoVaTenKhachHang";
            HoVaTenKhachHang.ReadOnly = true;
            // 
            // TenXe
            // 
            TenXe.DataPropertyName = "TenXe";
            TenXe.HeaderText = "Tên xe";
            TenXe.MinimumWidth = 6;
            TenXe.Name = "TenXe";
            TenXe.ReadOnly = true;
            // 
            // NgayLapHD
            // 
            NgayLapHD.DataPropertyName = "NgayLapHD";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            NgayLapHD.DefaultCellStyle = dataGridViewCellStyle1;
            NgayLapHD.HeaderText = "Ngày lập";
            NgayLapHD.MinimumWidth = 6;
            NgayLapHD.Name = "NgayLapHD";
            NgayLapHD.ReadOnly = true;
            // 
            // TongTienHopDong
            // 
            TongTienHopDong.DataPropertyName = "TongTienHopDong";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.Blue;
            dataGridViewCellStyle2.Format = "N0";
            TongTienHopDong.DefaultCellStyle = dataGridViewCellStyle2;
            TongTienHopDong.HeaderText = "Tổng tiền";
            TongTienHopDong.MinimumWidth = 6;
            TongTienHopDong.Name = "TongTienHopDong";
            TongTienHopDong.ReadOnly = true;
            // 
            // XemChiTiet
            // 
            XemChiTiet.DataPropertyName = "XemChiTiet";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            XemChiTiet.DefaultCellStyle = dataGridViewCellStyle3;
            XemChiTiet.HeaderText = "Chi tiết";
            XemChiTiet.MinimumWidth = 6;
            XemChiTiet.Name = "XemChiTiet";
            XemChiTiet.ReadOnly = true;
            // 
            // frmHopDong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 490);
            Controls.Add(groupBox1);
            Controls.Add(panelBottom);
            Name = "frmHopDong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hợp đồng";
            Load += frmHopDong_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView;
        private Panel panelBottom;
        private Button btnLapHopDong;
        private Button btnInHopDong;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
        private Button btnTimKiem;
        private Button btnXuat;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ID_Goc;
        private DataGridViewTextBoxColumn HoVaTenNhanVien;
        private DataGridViewTextBoxColumn HoVaTenKhachHang;
        private DataGridViewTextBoxColumn TenXe;
        private DataGridViewTextBoxColumn NgayLapHD;
        private DataGridViewTextBoxColumn TongTienHopDong;
        private DataGridViewLinkColumn XemChiTiet;
    }
}