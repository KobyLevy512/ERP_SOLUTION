using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ERP_SOLUTION.Controlls
{
    public partial class TreeButton : UserControl
    {
        public delegate void ChildClick(string child);

        Bitmap arrow = Properties.Resources.ArrowDown;
        string txt = "";

        bool isOpen = false;

        public List<string> Childs = new List<string>();
        public event ChildClick OnChildClick;
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
                AutoSize = false;
                Size = new Size(137, 31);
            }
        }

        private void TreeButton_MouseDown(object sender, MouseEventArgs e)
        {
            BackgroundImage = Properties.Resources.Icon_Button_Press;
            Invalidate();
        }

        private void TreeButton_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(txt, Font, IconButton.brush, 5, 6);
            e.Graphics.DrawImage(arrow, 115, 10, 20, 10);
        }

        private void OpenChilds()
        {
            Controls.Clear();
            int dy = 26;
            foreach(string str in Childs)
            {
                IconButton i = new IconButton();
                i.Size = new Size(153, 26);
                i.Location = new Point(0, dy);
                i.Txt = str;
                i.Click += OnChildClickFunc;
                Controls.Add(i);
                dy += 26;
            }
            AutoSize = true;
            Invalidate();
        }
        private void OnChildClickFunc(object child, EventArgs e)
        {
            IconButton c = (IconButton) child;
            OnChildClick?.Invoke(c.Txt);
        }
    }
}
