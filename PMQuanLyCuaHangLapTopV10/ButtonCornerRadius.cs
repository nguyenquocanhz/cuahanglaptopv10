using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PMQuanLyCuaHangLapTopV10
{
    public partial class ButtonCornerRadius : Button
    {
        private int _cornerRadius = 20;
        private bool _isHovered = false;
        private bool _isFocused = false;

        // Thuộc tính text
        private Color _hoverForeColor = Color.White;
        private Color _focusForeColor = Color.White;

        // Thuộc tính background
        private Color _hoverBackColor = Color.LightGray;
        private Color _focusBackColor = Color.Gray;

        [Category("Custom")]
        [Description("Độ cong của góc nút bấm.")]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = Math.Max(0, value);
                Invalidate();
            }
        }

        [Category("HoverColor")]
        [Description("Màu của text khi rê chuột.")]
        public Color HoverForeColor
        {
            get => _hoverForeColor;
            set
            {
                _hoverForeColor = value;
                Invalidate();
            }
        }

        [Category("Custom")]
        [Description("Màu của text khi nhận focus.")]
        public Color FocusForeColor
        {
            get => _focusForeColor;
            set
            {
                _focusForeColor = value;
                Invalidate();
            }
        }

        [Category("Custom")]
        [Description("Màu nền khi rê chuột.")]
        public Color HoverBackColor
        {
            get => _hoverBackColor;
            set
            {
                _hoverBackColor = value;
                Invalidate();
            }
        }

        [Category("Custom")]
        [Description("Màu nền khi nhận focus.")]
        public Color FocusBackColor
        {
            get => _focusBackColor;
            set
            {
                _focusBackColor = value;
                Invalidate();
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _isFocused = true;
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            _isFocused = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            // Vẽ mượt các đường cong
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            int diameter = CornerRadius * 2;
            GraphicsPath path = new GraphicsPath();

            // Vẽ các cung tròn cho góc
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            // Áp dụng region cho control để có hiệu ứng bo tròn
            this.Region = new Region(path);

            // Chọn màu nền theo trạng thái: ưu tiên Focus > Hover > BackColor mặc định
            Color drawBackColor = this.BackColor;
            if (_isFocused)
            {
                drawBackColor = FocusBackColor;
            }
            else if (_isHovered)
            {
                drawBackColor = HoverBackColor;
            }

            using (SolidBrush brush = new SolidBrush(drawBackColor))
            {
                pevent.Graphics.FillPath(brush, path);
            }

            // Vẽ viền khi hover hoặc focus
            Color borderColor = Color.White;
            int borderWidth = 0;
            if (_isFocused)
            {
                borderColor = Color.Black; // Viền khi nhận focus
                borderWidth = 2;
            }
            else if (_isHovered)
            {
                borderColor = Color.Green; // Viền khi hover
                borderWidth = 1;
            }

            if (borderWidth > 0)
            {
                using (Pen pen = new Pen(borderColor, borderWidth))
                {
                    pevent.Graphics.DrawPath(pen, path);
                }
            }

            // Chọn màu text theo trạng thái: ưu tiên Focus > Hover > ForeColor mặc định
            Color textColor = this.ForeColor;
            if (_isFocused)
            {
                textColor = FocusForeColor;
            }
            else if (_isHovered)
            {
                textColor = HoverForeColor;
            }

            // Vẽ text cho nút
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle,
                textColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
