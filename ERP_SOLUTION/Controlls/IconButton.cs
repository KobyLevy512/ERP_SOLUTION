using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERP_SOLUTION.Controlls
{
    public partial class IconButton : UserControl
    {
        static SolidBrush brush = new SolidBrush(Color.FromArgb(61, 85, 140));
        Bitmap icon = new Bitmap(1,1);
        string txt = "";

        public Bitmap Icon
        {
            get => icon;
            set
            {
                icon = value;
                Invalidate();
            }
        }

        public string Txt
        {
            get => txt;
            set
            {
                txt = value;
                Invalidate();
            }
        }
        public IconButton()
        {
            InitializeComponent();
        }

        private void IconButton_MouseEnter(object sender, EventArgs e)
        {
            BackgroundImage = Properties.Resources.Icon_Button_Hover;
            Invalidate();
        }

        private void IconButton_MouseLeave(object sender, EventArgs e)
        {
            BackgroundImage = Properties.Resources.Icon_Button_Regular;
            Invalidate();
        }

        private void IconButton_MouseDown(object sender, MouseEventArgs e)
        {
            BackgroundImage = Properties.Resources.Icon_Button_Press;
            Invalidate();
        }

        private void IconButton_MouseUp(object sender, MouseEventArgs e)
        {
            BackgroundImage = Properties.Resources.Icon_Button_Hover;
            Invalidate();
            InvokeOnClick(this, e);
        }

        private void IconButton_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(icon, 7, 5, 28, 28);
            e.Graphics.DrawString(txt, Font, brush, 36, 9);
        }
    }
}
