namespace QuanLyBanTraGopXeHonda.Forms
{
    partial class frmDoiMatKhau
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblMatKhauCu = new Label();
            lblMatKhauMoi = new Label();
            lblXacNhan = new Label();
            txtMatKhauCu = new TextBox();
            txtMatKhauMoi = new TextBox();
            txtXacNhan = new TextBox();
            btnDoiMatKhau = new Button();
            btnHuyBo = new Button();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(12, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(376, 36);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐỔI MẬT KHẨU";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblMatKhauCu
            //
            lblMatKhauCu.AutoSize = true;
            lblMatKhauCu.Location = new Point(20, 70);
            lblMatKhauCu.Name = "lblMatKhauCu";
            lblMatKhauCu.Size = new Size(100, 20);
            lblMatKhauCu.TabIndex = 1;
            lblMatKhauCu.Text = "Mật khẩu cũ:";
            //
            // txtMatKhauCu
            //
            txtMatKhauCu.Location = new Point(160, 67);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.PasswordChar = '●';
            txtMatKhauCu.Size = new Size(220, 27);
            txtMatKhauCu.TabIndex = 2;
            //
            // lblMatKhauMoi
            //
            lblMatKhauMoi.AutoSize = true;
            lblMatKhauMoi.Location = new Point(20, 115);
            lblMatKhauMoi.Name = "lblMatKhauMoi";
            lblMatKhauMoi.Size = new Size(100, 20);
            lblMatKhauMoi.TabIndex = 3;
            lblMatKhauMoi.Text = "Mật khẩu mới:";
            //
            // txtMatKhauMoi
            //
            txtMatKhauMoi.Location = new Point(160, 112);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '●';
            txtMatKhauMoi.Size = new Size(220, 27);
            txtMatKhauMoi.TabIndex = 4;
            //
            // lblXacNhan
            //
            lblXacNhan.AutoSize = true;
            lblXacNhan.Location = new Point(20, 160);
            lblXacNhan.Name = "lblXacNhan";
            lblXacNhan.Size = new Size(120, 20);
            lblXacNhan.TabIndex = 5;
            lblXacNhan.Text = "Xác nhận mật khẩu:";
            //
            // txtXacNhan
            //
            txtXacNhan.Location = new Point(160, 157);
            txtXacNhan.Name = "txtXacNhan";
            txtXacNhan.PasswordChar = '●';
            txtXacNhan.Size = new Size(220, 27);
            txtXacNhan.TabIndex = 6;
            txtXacNhan.KeyDown += txtXacNhan_KeyDown;
            //
            // btnDoiMatKhau
            //
            btnDoiMatKhau.Location = new Point(90, 205);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(120, 35);
            btnDoiMatKhau.TabIndex = 7;
            btnDoiMatKhau.Text = "Đổi mật khẩu";
            btnDoiMatKhau.UseVisualStyleBackColor = true;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            //
            // btnHuyBo
            //
            btnHuyBo.Location = new Point(225, 205);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(90, 35);
            btnHuyBo.TabIndex = 8;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            //
            // frmDoiMatKhau
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 260);
            Controls.Add(lblTitle);
            Controls.Add(lblMatKhauCu);
            Controls.Add(txtMatKhauCu);
            Controls.Add(lblMatKhauMoi);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(lblXacNhan);
            Controls.Add(txtXacNhan);
            Controls.Add(btnDoiMatKhau);
            Controls.Add(btnHuyBo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDoiMatKhau";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đổi mật khẩu";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblMatKhauCu;
        private Label lblMatKhauMoi;
        private Label lblXacNhan;
        private TextBox txtMatKhauCu;
        private TextBox txtMatKhauMoi;
        private TextBox txtXacNhan;
        private Button btnDoiMatKhau;
        private Button btnHuyBo;
    }
}