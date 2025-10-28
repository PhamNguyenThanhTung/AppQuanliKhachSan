using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLKhachSan.myClass
{
    public class GradientPanel : Panel
    {
        public Color Color1 { get; set; } = Color.DeepSkyBlue;
        public Color Color2 { get; set; } = Color.RoyalBlue;
        public float GradientAngle { get; set; } = 0f;

        private Timer timer;
        private int hue = 0;

        public bool EnableDynamicGradient { get; set; } = false;

        public GradientPanel()
        {
            this.DoubleBuffered = true; // Giúp vẽ mượt hơn, giảm giật
            timer = new Timer();
            timer.Interval = 50; // Khoảng 20 khung hình/giây
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            hue = (hue + 1) % 360; // Xoay vòng màu HSL
            Color1 = FromHSL(hue, 0.6f, 0.5f);
            Color2 = FromHSL((hue + 40) % 360, 0.6f, 0.5f);
            this.Invalidate(); // Yêu cầu Panel vẽ lại với màu mới
        }

        public void StartGradient()
        {
            if (EnableDynamicGradient)
                timer.Start();
        }

        public void StopGradient()
        {
            timer.Stop();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Vẽ dải màu
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color1, Color2, GradientAngle))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        // --- Hàm Hỗ Trợ Chuyển Đổi HSL sang RGB ---
        private Color FromHSL(int hue, float saturation, float lightness)
        {
            float C = (1 - Math.Abs(2 * lightness - 1)) * saturation;
            float X = C * (1 - Math.Abs((hue / 60f) % 2 - 1));
            float m = lightness - C / 2;
            float r = 0, g = 0, b = 0;
            if (hue < 60) { r = C; g = X; }
            else if (hue < 120) { r = X; g = C; }
            else if (hue < 180) { g = C; b = X; }
            else if (hue < 240) { g = X; b = C; }
            else if (hue < 300) { r = X; b = C; }
            else { r = C; b = X; }

            return Color.FromArgb(
                (int)((r + m) * 255),
                (int)((g + m) * 255),
                (int)((b + m) * 255)
            );
        }
    }
}
