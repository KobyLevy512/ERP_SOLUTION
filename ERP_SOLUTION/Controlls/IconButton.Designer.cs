namespace ERP_SOLUTION.Controlls
{
    partial class IconButton
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // IconButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::ERP_SOLUTION.Properties.Resources.Icon_Button_Regular;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("72 Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "IconButton";
            this.Size = new System.Drawing.Size(171, 38);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.IconButton_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IconButton_MouseDown);
            this.MouseEnter += new System.EventHandler(this.IconButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.IconButton_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.IconButton_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
