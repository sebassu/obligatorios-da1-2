namespace Interface
{
    partial class UserWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSystem = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlSystem
            // 
            this.pnlSystem.Location = new System.Drawing.Point(0, 1);
            this.pnlSystem.Name = "pnlSystem";
            this.pnlSystem.Size = new System.Drawing.Size(747, 538);
            this.pnlSystem.TabIndex = 0;
            this.pnlSystem.Click += new System.EventHandler(this.PnlSystem_Click);
            // 
            // UserWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(751, 539);
            this.Controls.Add(this.pnlSystem);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserWindow";
            this.Text = "Collaborative Whiteboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserWindow_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSystem;
    }
}

