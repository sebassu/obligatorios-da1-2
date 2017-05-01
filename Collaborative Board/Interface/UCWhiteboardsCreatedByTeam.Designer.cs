namespace Interface
{
    partial class UCWhiteboardsCreatedByTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCWhiteboardsCreatedByTeam));
            this.btnHome = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvWhiteboardsCreatedByTeam = new System.Windows.Forms.DataGridView();
            this.lblWhiteboardsCreatedByTeam = new System.Windows.Forms.Label();
            this.cmbTeams = new System.Windows.Forms.ComboBox();
            this.lblWhiteboardsCreatedFrom = new System.Windows.Forms.Label();
            this.lblTeam = new System.Windows.Forms.Label();
            this.lblWhiteboardsCreatedUntil = new System.Windows.Forms.Label();
            this.dtpWhiteboardsCreatedFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpWhiteboardsCreatedUntil = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWhiteboardsCreatedByTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Location = new System.Drawing.Point(42, 29);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(80, 62);
            this.btnHome.TabIndex = 0;
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(634, 436);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 62);
            this.btnExit.TabIndex = 1;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // dgvWhiteboardsCreatedByTeam
            // 
            this.dgvWhiteboardsCreatedByTeam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWhiteboardsCreatedByTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWhiteboardsCreatedByTeam.Location = new System.Drawing.Point(42, 190);
            this.dgvWhiteboardsCreatedByTeam.Name = "dgvWhiteboardsCreatedByTeam";
            this.dgvWhiteboardsCreatedByTeam.Size = new System.Drawing.Size(574, 295);
            this.dgvWhiteboardsCreatedByTeam.TabIndex = 2;
            // 
            // lblWhiteboardsCreatedByTeam
            // 
            this.lblWhiteboardsCreatedByTeam.AutoSize = true;
            this.lblWhiteboardsCreatedByTeam.BackColor = System.Drawing.Color.Transparent;
            this.lblWhiteboardsCreatedByTeam.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhiteboardsCreatedByTeam.Location = new System.Drawing.Point(158, 86);
            this.lblWhiteboardsCreatedByTeam.Name = "lblWhiteboardsCreatedByTeam";
            this.lblWhiteboardsCreatedByTeam.Size = new System.Drawing.Size(352, 34);
            this.lblWhiteboardsCreatedByTeam.TabIndex = 3;
            this.lblWhiteboardsCreatedByTeam.Text = "Pizarrones creados por equipo";
            // 
            // cmbTeams
            // 
            this.cmbTeams.FormattingEnabled = true;
            this.cmbTeams.Location = new System.Drawing.Point(427, 147);
            this.cmbTeams.Name = "cmbTeams";
            this.cmbTeams.Size = new System.Drawing.Size(189, 21);
            this.cmbTeams.TabIndex = 4;
            // 
            // lblWhiteboardsCreatedFrom
            // 
            this.lblWhiteboardsCreatedFrom.AutoSize = true;
            this.lblWhiteboardsCreatedFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblWhiteboardsCreatedFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhiteboardsCreatedFrom.Location = new System.Drawing.Point(50, 133);
            this.lblWhiteboardsCreatedFrom.Name = "lblWhiteboardsCreatedFrom";
            this.lblWhiteboardsCreatedFrom.Size = new System.Drawing.Size(186, 18);
            this.lblWhiteboardsCreatedFrom.TabIndex = 5;
            this.lblWhiteboardsCreatedFrom.Text = "Pizarrones creados desde:";
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.BackColor = System.Drawing.Color.Transparent;
            this.lblTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam.Location = new System.Drawing.Point(365, 148);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(58, 18);
            this.lblTeam.TabIndex = 6;
            this.lblTeam.Text = "Equipo:";
            // 
            // lblWhiteboardsCreatedUntil
            // 
            this.lblWhiteboardsCreatedUntil.AutoSize = true;
            this.lblWhiteboardsCreatedUntil.BackColor = System.Drawing.Color.Transparent;
            this.lblWhiteboardsCreatedUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhiteboardsCreatedUntil.Location = new System.Drawing.Point(50, 161);
            this.lblWhiteboardsCreatedUntil.Name = "lblWhiteboardsCreatedUntil";
            this.lblWhiteboardsCreatedUntil.Size = new System.Drawing.Size(182, 18);
            this.lblWhiteboardsCreatedUntil.TabIndex = 7;
            this.lblWhiteboardsCreatedUntil.Text = "Pizarrones creados hasta:";
            // 
            // dtpWhiteboardsCreatedFrom
            // 
            this.dtpWhiteboardsCreatedFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWhiteboardsCreatedFrom.Location = new System.Drawing.Point(238, 134);
            this.dtpWhiteboardsCreatedFrom.Name = "dtpWhiteboardsCreatedFrom";
            this.dtpWhiteboardsCreatedFrom.Size = new System.Drawing.Size(119, 20);
            this.dtpWhiteboardsCreatedFrom.TabIndex = 8;
            // 
            // dtpWhiteboardsCreatedUntil
            // 
            this.dtpWhiteboardsCreatedUntil.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWhiteboardsCreatedUntil.Location = new System.Drawing.Point(238, 161);
            this.dtpWhiteboardsCreatedUntil.Name = "dtpWhiteboardsCreatedUntil";
            this.dtpWhiteboardsCreatedUntil.Size = new System.Drawing.Size(118, 20);
            this.dtpWhiteboardsCreatedUntil.TabIndex = 9;
            // 
            // UCWhiteboardsCreatedByTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.dtpWhiteboardsCreatedUntil);
            this.Controls.Add(this.dtpWhiteboardsCreatedFrom);
            this.Controls.Add(this.lblWhiteboardsCreatedUntil);
            this.Controls.Add(this.lblTeam);
            this.Controls.Add(this.lblWhiteboardsCreatedFrom);
            this.Controls.Add(this.cmbTeams);
            this.Controls.Add(this.lblWhiteboardsCreatedByTeam);
            this.Controls.Add(this.dgvWhiteboardsCreatedByTeam);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHome);
            this.Name = "UCWhiteboardsCreatedByTeam";
            this.Size = new System.Drawing.Size(747, 538);
            this.Load += new System.EventHandler(this.UCWhiteboardsCreatedByTeam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWhiteboardsCreatedByTeam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvWhiteboardsCreatedByTeam;
        private System.Windows.Forms.Label lblWhiteboardsCreatedByTeam;
        private System.Windows.Forms.ComboBox cmbTeams;
        private System.Windows.Forms.Label lblWhiteboardsCreatedFrom;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.Label lblWhiteboardsCreatedUntil;
        private System.Windows.Forms.DateTimePicker dtpWhiteboardsCreatedFrom;
        private System.Windows.Forms.DateTimePicker dtpWhiteboardsCreatedUntil;
    }
}
