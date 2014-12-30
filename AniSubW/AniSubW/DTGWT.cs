using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace AniSubW
{
    public class DTGWT : DataGridView
    {
        private const int WM_ERASEBKGND = 0x0014;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_ERASEBKGND)
            {
                m.Result = IntPtr.Zero;
                return;
            }
            base.WndProc(ref m);
        }

        public DTGWT() : base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            this[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Transparent;
        }

        protected override void OnScroll(ScrollEventArgs e)
        {
            base.OnScroll(e);
            this.Refresh();
        }

        protected override void PaintBackground(Graphics graphics, Rectangle clipBounds, Rectangle gridBounds)
        {
            base.PaintBackground(graphics, clipBounds, gridBounds);
            Rectangle rectSource = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            Rectangle rectDest = new Rectangle(0, 0, rectSource.Width, rectSource.Height);

            Bitmap b = new Bitmap(Parent.ClientRectangle.Width, Parent.ClientRectangle.Height);

            graphics.DrawImage(b, rectDest, rectSource, GraphicsUnit.Pixel);
        }
    }

    public class MyListBox : ListBox
    {
        private bool mShowScroll;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!mShowScroll) cp.Style &= ~0x200000;
                return cp;
            }
        }

        [DefaultValue(false)]
        public bool ShowScrollbar
        {
            get { return mShowScroll; }
            set
            {
                if (value == mShowScroll) return;
                mShowScroll = value;
                if (this.Handle != IntPtr.Zero) RecreateHandle();
            }
        }
    }
}


