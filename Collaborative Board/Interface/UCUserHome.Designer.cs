namespace GraphicInterface
{
    partial class UCUserHome
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCUserHome));
            this.lblHomeMenu = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnWhiteboards = new System.Windows.Forms.Button();
            this.btnScore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHomeMenu
            // 
            this.lblHomeMenu.AutoSize = true;
            this.lblHomeMenu.BackColor = System.Drawing.Color.Transparent;
            this.lblHomeMenu.Font = new System.Drawing.Font("Segoe Script", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomeMenu.Location = new System.Drawing.Point(197, 50);
            this.lblHomeMenu.Name = "lblHomeMenu";
            this.lblHomeMenu.Size = new System.Drawing.Size(339, 61);
            this.lblHomeMenu.TabIndex = 8;
            this.lblHomeMenu.Text = "Menú principal";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(639, 436);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 62);
            this.btnExit.TabIndex = 9;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnWhiteboards
            // 
            this.btnWhiteboards.BackColor = System.Drawing.Color.Yellow;
            this.btnWhiteboards.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWhiteboards.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWhiteboards.ForeColor = System.Drawing.Color.White;
            this.btnWhiteboards.Location = new System.Drawing.Point(131, 201);
            this.btnWhiteboards.Name = "btnWhiteboards";
            this.btnWhiteboards.Size = new System.Drawing.Size(196, 111);
            this.btnWhiteboards.TabIndex = 10;
            this.btnWhiteboards.Text = "PIZARRONES";
            this.btnWhiteboards.UseVisualStyleBackColor = false;
            this.btnWhiteboards.Click += new System.EventHandler(this.btnWhiteboards_Click);
            this.btnWhiteboards.MouseEnter += new System.EventHandler(this.btnWhiteboards_MouseEnter);
            this.btnWhiteboards.MouseLeave += new System.EventHandler(this.btnWhiteboards_MouseLeave);
            // 
            // btnScore
            // 
            this.btnScore.BackColor = System.Drawing.Color.Gray;
            this.btnScore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScore.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScore.ForeColor = System.Drawing.Color.White;
            this.btnScore.Location = new System.Drawing.Point(388, 201);
            this.btnScore.Name = "btnScore";
            this.btnScore.Size = new System.Drawing.Size(196, 111);
            this.btnScore.TabIndex = 11;
            this.btnScore.Text = "PUNTAJE";
            this.btnScore.UseVisualStyleBackColor = false;
            this.btnScore.Click += new System.EventHandler(this.btnScore_Click);
            this.btnScore.MouseEnter += new System.EventHandler(this.btnScore_MouseEnter);
            this.btnScore.MouseLeave += new System.EventHandler(this.btnScore_MouseLeave);
            // 
            // UCUserHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnScore);
            this.Controls.Add(this.btnWhiteboards);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblHomeMenu);
            this.Name = "UCUserHome";
            this.Size = new System.Drawing.Size(747, 538);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHomeMenu;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnWhiteboards;
        private System.Windows.Forms.Button btnScore;
    }
}
