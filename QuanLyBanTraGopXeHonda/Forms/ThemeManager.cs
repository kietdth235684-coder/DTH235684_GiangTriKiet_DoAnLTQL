using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuanLyBanTraGopXeHonda.Forms
{
    public static class ThemeManager
    {
        // Modern palette consistently used across the app
        public static readonly Color FormBackColor = Color.FromArgb(245, 247, 250);
        public static readonly Color PrimaryColor = Color.FromArgb(0, 120, 215);
        public static readonly Color DangerColor = Color.FromArgb(220, 53, 69);
        public static readonly Color SuccessColor = Color.FromArgb(40, 167, 69);
        public static readonly Color GrayColor = Color.FromArgb(108, 117, 125);
        public static readonly Color TextPrimaryColor = Color.FromArgb(30, 30, 30);

        // Standard Fonts
        public static readonly Font PrimaryFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        public static readonly Font HeaderFont = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);

        /// <summary>
        /// Applies the modern UI theme to a form and all its child controls.
        /// This version is specialized for stability and does not modify control positions.
        /// </summary>
        public static void ApplyTheme(Form form)
        {
            if (form == null) return;

            try
            {
                form.BackColor = FormBackColor;
                form.Font = PrimaryFont;
                form.ForeColor = TextPrimaryColor;

                // Handle MDI container background specifically
                if (form.IsMdiContainer)
                {
                    foreach (Control c in form.Controls)
                    {
                        if (c is MdiClient mdi)
                        {
                            mdi.BackColor = Color.FromArgb(220, 226, 235);
                            break;
                        }
                    }
                }

                ApplyThemeToControls(form.Controls);

                // For the main form, we also handle menu icons
                if (form.Name == "frmMain")
                {
                    InjectMenuIcons(form);
                }
            }
            catch (Exception)
            {
                // Silently fail to ensure the form still renders its original controls
            }
        }

        private static void ApplyThemeToControls(Control.ControlCollection controls)
        {
            if (controls == null) return;

            foreach (Control ctrl in controls)
            {
                try
                {
                    // Basic styling based on control type
                    if (ctrl is Button btn)
                    {
                        ApplyButtonTheme(btn);
                    }
                    else if (ctrl is DataGridView dgv)
                    {
                        ApplyDataGridViewTheme(dgv);
                    }
                    else if (ctrl is TextBox txt)
                    {
                        txt.BorderStyle = BorderStyle.FixedSingle;
                        txt.Font = PrimaryFont;
                    }
                    else if (ctrl is GroupBox grp)
                    {
                        grp.ForeColor = PrimaryColor;
                        grp.Font = HeaderFont;
                        // Recursively style controls inside groupbox
                        ApplyThemeToControls(grp.Controls);
                    }
                    else if (ctrl is MenuStrip ms)
                    {
                        ms.BackColor = Color.White;
                        ms.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());
                    }
                    else if (ctrl is StatusStrip ss)
                    {
                        ss.BackColor = Color.White;
                        ss.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());
                    }
                    else if (ctrl is Label lbl)
                    {
                        if (lbl.Font.Bold) lbl.ForeColor = PrimaryColor;
                    }

                    // Recursive call for nested containers (Panels, TabPages, etc.)
                    if (!(ctrl is GroupBox) && ctrl.Controls.Count > 0)
                    {
                        ApplyThemeToControls(ctrl.Controls);
                    }
                }
                catch { /* Safety fallback per control */ }
            }
        }

        private static void ApplyButtonTheme(Button btn)
        {
            try {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                btn.Cursor = Cursors.Hand;
                
                string text = (btn.Text ?? "").ToLower();
                
                // Use robust contains checks for common Vietnamese button text
                if (text.Contains("xóa") || text.Contains("xoá"))
                {
                    btn.BackColor = DangerColor;
                    btn.ForeColor = Color.White;
                }
                else if (text.Contains("thoát") || text.Contains("hủy") || text.Contains("huỷ") || text.Contains("không"))
                {
                    btn.BackColor = GrayColor;
                    btn.ForeColor = Color.White;
                }
                else if (text.Contains("thêm") || text.Contains("lưu") || text.Contains("nhập") || text.Contains("đăng nhập") || text.Contains("xác nhận"))
                {
                    btn.BackColor = SuccessColor;
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.BackColor = PrimaryColor;
                    btn.ForeColor = Color.White;
                }
            } catch { }
        }

        private static void ApplyDataGridViewTheme(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 35;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 250);
            dgv.DefaultCellStyle.SelectionForeColor = TextPrimaryColor;

        }

        private static void InjectMenuIcons(Form form)
        {
            try
            {
                MenuStrip ms = null;
                foreach (Control c in form.Controls) if (c is MenuStrip) ms = (MenuStrip)c;
                if (ms == null) return;

                // Calculate base directory safely
                string baseDir = System.IO.Path.Combine(Application.StartupPath.Replace("bin\\Debug\\net9.0-windows", "").Replace("bin\\Release\\net9.0-windows", "").TrimEnd('\\'), "Images", "Icons");
                
                Dictionary<string, string> map = new Dictionary<string, string>
                {
                    { "mnuHeThong", "settings.png" },
                    { "mnuQuanLy", "management.png" },
                    { "mnuBaoCaoThongKe", "chart.png" },
                    { "mnuTroGiup", "help.png" },
                    { "mnuXe", "motorcycle.png" },
                    { "mnuNhanVien", "users.png" },
                    { "mnuKhachHang", "users.png" },
                    { "mnuLoaiXe", "motorcycle.png" },
                    { "mnuHangXe", "management.png" },
                    { "mnuHopDong", "chart.png" }
                };

                foreach (ToolStripItem item in ms.Items)
                {
                    if (item.Name != null && map.ContainsKey(item.Name))
                    {
                        string path = System.IO.Path.Combine(baseDir, map[item.Name]);
                        if (System.IO.File.Exists(path)) item.Image = Image.FromFile(path);
                    }
                    
                    if (item is ToolStripMenuItem dropDown)
                    {
                        foreach (ToolStripItem sub in dropDown.DropDownItems)
                        {
                            if (sub.Name != null && map.ContainsKey(sub.Name))
                            {
                                string path = System.IO.Path.Combine(baseDir, map[sub.Name]);
                                if (System.IO.File.Exists(path)) sub.Image = Image.FromFile(path);
                            }
                        }
                    }
                }
            }
            catch { }
        }
    }

    public class CustomColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected => Color.FromArgb(230, 240, 250);
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(230, 240, 250);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(230, 240, 250);
        public override Color MenuItemBorder => ThemeManager.PrimaryColor;
        public override Color MenuBorder => Color.FromArgb(210, 210, 210);
    }
}
