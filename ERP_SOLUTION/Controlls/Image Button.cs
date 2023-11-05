using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERP_SOLUTION.Controlls
{
    public partial class Image_Button : UserControl
    {
        Bitmap cur, regular, hover, press;

        public Bitmap Regular
        {
            get => regular;
            set
            {
                regular = value;
                cur = regular;
                Invalidate();
            }
        }
        public Bitmap Hover
        {
            get => hover; set => hover = value;
        }
        public Bitmap Press
        {
            get => press; set => press = value;
        }
        public Image_Button()
        {
            InitializeComponent();
            cur = new Bitmap(1, 1);
        }

        private void Image_Button_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(cur, 0, 0, Width, Height);
        }

        private void Image_Button_MouseEnter(object sender, EventArgs e)
        {
            cur = hover;
            Invalidate();
        }

        private void Image_Button_MouseLeave(object sender, EventArgs e)
        {
            cur = regular;
            Invalidate();
        }

        private void Image_Button_MouseDown(object sender, MouseEventArgs e)
        {
            cur = press;
            Invalidate();
        }

        private void Image_Button_MouseUp(object sender, MouseEventArgs e)
        {
            cur = hover;
            Invalidate();
            OnMouseClick(e);
        }
    }
}
