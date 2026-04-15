namespace QuanLyBanTraGopXeHonda.Reports
{
    partial class frmThongKeXe
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
            pnlFilter = new Panel();
            lblHangXe = new Label();
            cboHangXe = new ComboBox();
            lblLoaiXe = new Label();
            cboLoaiXe = new ComboBox();
            btnLocKetQua = new Button();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            pnlFilter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.Controls.Add(lblHangXe);
            pnlFilter.Controls.Add(cboHangXe);
            pnlFilter.Controls.Add(lblLoaiXe);
            pnlFilter.Controls.Add(cboLoaiXe);
            pnlFilter.Controls.Add(btnLocKetQua);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 0);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(6, 6, 6, 4);
            pnlFilter.Size = new Size(1100, 40);
            pnlFilter.TabIndex = 2;
            // 
            // lblHangXe
            // 
            lblHangXe.AutoSize = true;
            lblHangXe.Location = new Point(10, 11);
            lblHangXe.Name = "lblHangXe";
            lblHangXe.Size = new Size(67, 20);
            lblHangXe.TabIndex = 0;
            lblHangXe.Text = "Hãng xe:";
            // 
            // cboHangXe
            // 
            cboHangXe.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHangXe.Location = new Point(83, 8);
            cboHangXe.Name = "cboHangXe";
            cboHangXe.Size = new Size(160, 28);
            cboHangXe.TabIndex = 1;
            // 
            // lblLoaiXe
            // 
            lblLoaiXe.AutoSize = true;
            lblLoaiXe.Location = new Point(250, 11);
            lblLoaiXe.Name = "lblLoaiXe";
            lblLoaiXe.Size = new Size(59, 20);
            lblLoaiXe.TabIndex = 2;
            lblLoaiXe.Text = "Loại xe:";
            // 
            // cboLoaiXe
            // 
            cboLoaiXe.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiXe.Location = new Point(310, 7);
            cboLoaiXe.Name = "cboLoaiXe";
            cboLoaiXe.Size = new Size(160, 28);
            cboLoaiXe.TabIndex = 3;
            // 
            // btnLocKetQua
            // 
            btnLocKetQua.Location = new Point(485, 6);
            btnLocKetQua.Name = "btnLocKetQua";
            btnLocKetQua.Size = new Size(120, 26);
            btnLocKetQua.TabIndex = 4;
            btnLocKetQua.Text = "Lọc kết quả";
            btnLocKetQua.Click += btnLocKetQua_Click;
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(0, 40);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(1100, 710);
            reportViewer1.TabIndex = 1;
            // 
            // frmThongKeXe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 750);
            Controls.Add(reportViewer1);
            Controls.Add(pnlFilter);
            Name = "frmThongKeXe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê xe";
            Load += frmThongKeXe_Load;
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFilter;
        private Label lblHangXe;
        private ComboBox cboHangXe;
        private Label lblLoaiXe;
        private ComboBox cboLoaiXe;
        private Button btnLocKetQua;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}