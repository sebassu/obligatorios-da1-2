namespace Interface
{
    partial class UCAdministratorHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAdministratorHome));
            this.lblHomeMenu = new System.Windows.Forms.Label();
            this.btnTeams = new System.Windows.Forms.Button();
            this.btnWhiteboards = new System.Windows.Forms.Button();
            this.btnInforms = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHomeMenu
            // 
            this.lblHomeMenu.AutoSize = true;
            this.lblHomeMenu.BackColor = System.Drawing.Color.Transparent;
            this.lblHomeMenu.Font = new System.Drawing.Font("Segoe Script", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomeMenu.Location = new System.Drawing.Point(200, 76);
            this.lblHomeMenu.Name = "lblHomeMenu";
            this.lblHomeMenu.Size = new System.Drawing.Size(339, 61);
            this.lblHomeMenu.TabIndex = 7;
            this.lblHomeMenu.Text = "Menú principal";
            // 
            // btnTeams
            // 
            this.btnTeams.BackColor = System.Drawing.Color.DarkRed;
            this.btnTeams.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTeams.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeams.ForeColor = System.Drawing.Color.White;
            this.btnTeams.Location = new System.Drawing.Point(381, 179);
            this.btnTeams.Name = "btnTeams";
            this.btnTeams.Size = new System.Drawing.Size(196, 111);
            this.btnTeams.TabIndex = 3;
            this.btnTeams.Text = "EQUIPOS";
            this.btnTeams.UseVisualStyleBackColor = false;
            this.btnTeams.Click += new System.EventHandler(this.btnTeams_Click);
            this.btnTeams.MouseEnter += new System.EventHandler(this.btnTeams_MouseEnter);
            this.btnTeams.MouseLeave += new System.EventHandler(this.btnTeams_MouseLeave);
            // 
            // btnWhiteboards
            // 
            this.btnWhiteboards.BackColor = System.Drawing.Color.Yellow;
            this.btnWhiteboards.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWhiteboards.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWhiteboards.ForeColor = System.Drawing.Color.White;
            this.btnWhiteboards.Location = new System.Drawing.Point(169, 306);
            this.btnWhiteboards.Name = "btnWhiteboards";
            this.btnWhiteboards.Size = new System.Drawing.Size(196, 111);
            this.btnWhiteboards.TabIndex = 4;
            this.btnWhiteboards.Text = "PIZARRONES";
            this.btnWhiteboards.UseVisualStyleBackColor = false;
            this.btnWhiteboards.Click += new System.EventHandler(this.btnWhiteboards_Click);
            this.btnWhiteboards.MouseEnter += new System.EventHandler(this.btnWhiteboards_MouseEnter);
            this.btnWhiteboards.MouseLeave += new System.EventHandler(this.btnWhiteboards_MouseLeave);
            // 
            // btnInforms
            // 
            this.btnInforms.BackColor = System.Drawing.Color.Navy;
            this.btnInforms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInforms.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInforms.ForeColor = System.Drawing.Color.White;
            this.btnInforms.Location = new System.Drawing.Point(381, 306);
            this.btnInforms.Name = "btnInforms";
            this.btnInforms.Size = new System.Drawing.Size(196, 111);
            this.btnInforms.TabIndex = 5;
            this.btnInforms.Text = "INFORMES";
            this.btnInforms.UseVisualStyleBackColor = false;
            this.btnInforms.Click += new System.EventHandler(this.btnInforms_Click);
            this.btnInforms.MouseEnter += new System.EventHandler(this.btnInforms_MouseEnter);
            this.btnInforms.MouseLeave += new System.EventHandler(this.btnInforms_MouseLeave);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.Green;
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Location = new System.Drawing.Point(169, 179);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(196, 111);
            this.btnUsers.TabIndex = 6;
            this.btnUsers.Text = "USUARIOS";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            this.btnUsers.MouseEnter += new System.EventHandler(this.btnUsers_MouseEnter);
            this.btnUsers.MouseLeave += new System.EventHandler(this.btnUsers_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(639, 436);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 62);
            this.btnExit.TabIndex = 8;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // UCAdministratorHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblHomeMenu);
            this.Controls.Add(this.btnTeams);
            this.Controls.Add(this.btnWhiteboards);
            this.Controls.Add(this.btnInforms);
            this.Controls.Add(this.btnUsers);
            this.Name = "UCAdministratorHome";
            this.Size = new System.Drawing.Size(747, 538);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHomeMenu;
        private System.Windows.Forms.Button btnTeams;
        private System.Windows.Forms.Button btnWhiteboards;
        private System.Windows.Forms.Button btnInforms;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnExit;
    }
}
