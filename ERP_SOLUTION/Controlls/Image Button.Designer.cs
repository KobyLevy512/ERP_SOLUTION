namespace ERP_SOLUTION.Controlls
{
    partial class Image_Button
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
            // Image_Button
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "Image_Button";
            this.Size = new System.Drawing.Size(256, 256);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Image_Button_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Image_Button_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Image_Button_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Image_Button_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Image_Button_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
