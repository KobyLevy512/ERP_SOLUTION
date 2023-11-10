using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ERP_SOLUTION.Controlls
{
    public partial class TreeButton : UserControl
    {
        Bitmap arrow = Properties.Resources.ArrowDown;
        string txt = "";

        bool isOpen = false;

        public List<IconButton> Childs = new List<IconButton>();
        public string Txt
        {
            get => txt;
            set
            {
                txt = value;
                Invalidate();
            }
        }
        public TreeButton()
        {
            InitializeComponent();
        }

        private void TreeButton_MouseEnter(object sender, EventArgs e)
        {
            BackgroundImage = Properties.Resources.Icon_Button_Hover;
            Invalidate();
        }

        private void TreeButton_MouseLeave(object sender, EventArgs e)
        {
            BackgroundImage = Properties.Resources.Icon_Button_Regular;
            Invalidate();
        }

        private void TreeButton_MouseUp(object sender, MouseEventArgs e)
        {
            BackgroundImage = Properties.Resources.Icon_Button_Hover;
            Invalidate();
            isOpen = !isOpen;
            if(isOpen)
            {
                arrow = Properties.Resources.ArrowUp;
                OpenChilds();
            }
            else
            {
                arrow = Properties.Resources.ArrowDown;
                Controls.Clear();
            }
        }

        private void TreeButton_MouseDown(object sender, MouseEventArgs e)
        {
            BackgroundImage = Properties.Resources.Icon_Button_Press;
            Invalidate();
        }

        private void TreeButton_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(txt, Font, IconButton.brush, 5, 3);
            e.Graphics.DrawImage(arrow, 70, 2, 32, 32);
        }

        private void OpenChilds()
        {
            Controls.Clear();
            int dy = 31;
            foreach(IconButton i in Childs)
            {
                i.Location = new Point(0, dy);
                Controls.Add(i);
                dy += 31;
            }
        }
    }
}
