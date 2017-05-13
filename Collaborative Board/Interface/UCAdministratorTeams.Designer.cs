namespace Interface
{
    partial class UCAdministratorTeams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAdministratorTeams));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstTeams = new System.Windows.Forms.ListView();
            this.lblRegisteredTeams = new System.Windows.Forms.Label();
            this.btnAdministrate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(643, 436);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 62);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Location = new System.Drawing.Point(42, 29);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(80, 62);
            this.btnHome.TabIndex = 1;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnHome.MouseEnter += new System.EventHandler(this.btnHome_MouseEnter);
            this.btnHome.MouseLeave += new System.EventHandler(this.btnHome_MouseLeave);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkRed;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(290, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(203, 91);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "AGREGAR";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseEnter += new System.EventHandler(this.btnAdd_MouseEnter);
            this.btnAdd.MouseLeave += new System.EventHandler(this.btnAdd_MouseLeave);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.DarkRed;
            this.btnModify.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.ForeColor = System.Drawing.Color.White;
            this.btnModify.Location = new System.Drawing.Point(499, 160);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(224, 91);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "MODIFICAR";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            this.btnModify.MouseEnter += new System.EventHandler(this.btnModify_MouseEnter);
            this.btnModify.MouseLeave += new System.EventHandler(this.btnModify_MouseLeave);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkRed;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(290, 279);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(203, 91);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "ELIMINAR";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.MouseEnter += new System.EventHandler(this.btnDelete_MouseEnter);
            this.btnDelete.MouseLeave += new System.EventHandler(this.btnDelete_MouseLeave);
            // 
            // lstTeams
            // 
            this.lstTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTeams.Location = new System.Drawing.Point(42, 160);
            this.lstTeams.MultiSelect = false;
            this.lstTeams.Name = "lstTeams";
            this.lstTeams.Size = new System.Drawing.Size(242, 319);
            this.lstTeams.TabIndex = 5;
            this.lstTeams.UseCompatibleStateImageBehavior = false;
            this.lstTeams.View = System.Windows.Forms.View.Tile;
            // 
            // lblRegisteredTeams
            // 
            this.lblRegisteredTeams.AutoSize = true;
            this.lblRegisteredTeams.BackColor = System.Drawing.Color.Transparent;
            this.lblRegisteredTeams.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisteredTeams.Location = new System.Drawing.Point(43, 111);
            this.lblRegisteredTeams.Name = "lblRegisteredTeams";
            this.lblRegisteredTeams.Size = new System.Drawing.Size(231, 34);
            this.lblRegisteredTeams.TabIndex = 6;
            this.lblRegisteredTeams.Text = "Equipos registrados";
            // 
            // btnAdministrate
            // 
            this.btnAdministrate.BackColor = System.Drawing.Color.DarkRed;
            this.btnAdministrate.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrate.ForeColor = System.Drawing.Color.White;
            this.btnAdministrate.Location = new System.Drawing.Point(499, 279);
            this.btnAdministrate.Name = "btnAdministrate";
            this.btnAdministrate.Size = new System.Drawing.Size(224, 91);
            this.btnAdministrate.TabIndex = 7;
            this.btnAdministrate.Text = "ADMINISTRAR";
            this.btnAdministrate.UseVisualStyleBackColor = false;
            this.btnAdministrate.Click += new System.EventHandler(this.btnAdministrate_Click);
            this.btnAdministrate.MouseEnter += new System.EventHandler(this.btnAdministrate_MouseEnter);
            this.btnAdministrate.MouseLeave += new System.EventHandler(this.btnAdministrate_MouseLeave);
            // 
            // UCAdministratorTeams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnAdministrate);
            this.Controls.Add(this.lblRegisteredTeams);
            this.Controls.Add(this.lstTeams);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnExit);
            this.Name = "UCAdministratorTeams";
            this.Size = new System.Drawing.Size(747, 538);
            this.Load += new System.EventHandler(this.UCAdministratorTeams_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView lstTeams;
        private System.Windows.Forms.Label lblRegisteredTeams;
        private System.Windows.Forms.Button btnAdministrate;
    }
}
