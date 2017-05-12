namespace Interface
{
    partial class UCAdministratorCommentsSolvedByUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAdministratorCommentsSolvedByUser));
            this.btnHome = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblCommentsSolvedByUser = new System.Windows.Forms.Label();
            this.lblCommentsCreatedFrom = new System.Windows.Forms.Label();
            this.lblCommentsCreatedUntil = new System.Windows.Forms.Label();
            this.lblCommentsSolvedFrom = new System.Windows.Forms.Label();
            this.lblCommentsSolvedUntil = new System.Windows.Forms.Label();
            this.lblCreatorUser = new System.Windows.Forms.Label();
            this.lblSolverUser = new System.Windows.Forms.Label();
            this.dgvCommentsSolvedByUser = new System.Windows.Forms.DataGridView();
            this.cmbCreatorUser = new System.Windows.Forms.ComboBox();
            this.cmbSolverUser = new System.Windows.Forms.ComboBox();
            this.dtpCommentsCreatedFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpCommentsCreatedUntil = new System.Windows.Forms.DateTimePicker();
            this.dtpCommentsSolvedFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpCommentsSolvedUntil = new System.Windows.Forms.DateTimePicker();
            this.btnApllyFilters = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommentsSolvedByUser)).BeginInit();
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
            this.btnHome.MouseEnter += new System.EventHandler(this.btnHome_MouseEnter);
            this.btnHome.MouseLeave += new System.EventHandler(this.btnHome_MouseLeave);
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
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblCommentsSolvedByUser
            // 
            this.lblCommentsSolvedByUser.AutoSize = true;
            this.lblCommentsSolvedByUser.BackColor = System.Drawing.Color.Transparent;
            this.lblCommentsSolvedByUser.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentsSolvedByUser.Location = new System.Drawing.Point(145, 83);
            this.lblCommentsSolvedByUser.Name = "lblCommentsSolvedByUser";
            this.lblCommentsSolvedByUser.Size = new System.Drawing.Size(393, 34);
            this.lblCommentsSolvedByUser.TabIndex = 2;
            this.lblCommentsSolvedByUser.Text = "Comentarios resueltos por usuario";
            // 
            // lblCommentsCreatedFrom
            // 
            this.lblCommentsCreatedFrom.AutoSize = true;
            this.lblCommentsCreatedFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblCommentsCreatedFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentsCreatedFrom.Location = new System.Drawing.Point(24, 134);
            this.lblCommentsCreatedFrom.Name = "lblCommentsCreatedFrom";
            this.lblCommentsCreatedFrom.Size = new System.Drawing.Size(200, 18);
            this.lblCommentsCreatedFrom.TabIndex = 3;
            this.lblCommentsCreatedFrom.Text = "Comentarios creados desde:";
            // 
            // lblCommentsCreatedUntil
            // 
            this.lblCommentsCreatedUntil.AutoSize = true;
            this.lblCommentsCreatedUntil.BackColor = System.Drawing.Color.Transparent;
            this.lblCommentsCreatedUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentsCreatedUntil.Location = new System.Drawing.Point(24, 164);
            this.lblCommentsCreatedUntil.Name = "lblCommentsCreatedUntil";
            this.lblCommentsCreatedUntil.Size = new System.Drawing.Size(196, 18);
            this.lblCommentsCreatedUntil.TabIndex = 4;
            this.lblCommentsCreatedUntil.Text = "Comentarios creados hasta:";
            // 
            // lblCommentsSolvedFrom
            // 
            this.lblCommentsSolvedFrom.AutoSize = true;
            this.lblCommentsSolvedFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblCommentsSolvedFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentsSolvedFrom.Location = new System.Drawing.Point(331, 134);
            this.lblCommentsSolvedFrom.Name = "lblCommentsSolvedFrom";
            this.lblCommentsSolvedFrom.Size = new System.Drawing.Size(207, 18);
            this.lblCommentsSolvedFrom.TabIndex = 5;
            this.lblCommentsSolvedFrom.Text = "Comentarios resueltos desde:";
            // 
            // lblCommentsSolvedUntil
            // 
            this.lblCommentsSolvedUntil.AutoSize = true;
            this.lblCommentsSolvedUntil.BackColor = System.Drawing.Color.Transparent;
            this.lblCommentsSolvedUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentsSolvedUntil.Location = new System.Drawing.Point(331, 164);
            this.lblCommentsSolvedUntil.Name = "lblCommentsSolvedUntil";
            this.lblCommentsSolvedUntil.Size = new System.Drawing.Size(203, 18);
            this.lblCommentsSolvedUntil.TabIndex = 6;
            this.lblCommentsSolvedUntil.Text = "Comentarios resueltos hasta:";
            // 
            // lblCreatorUser
            // 
            this.lblCreatorUser.AutoSize = true;
            this.lblCreatorUser.BackColor = System.Drawing.Color.Transparent;
            this.lblCreatorUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatorUser.Location = new System.Drawing.Point(72, 196);
            this.lblCreatorUser.Name = "lblCreatorUser";
            this.lblCreatorUser.Size = new System.Drawing.Size(119, 18);
            this.lblCreatorUser.TabIndex = 7;
            this.lblCreatorUser.Text = "Usuario creador:";
            // 
            // lblSolverUser
            // 
            this.lblSolverUser.AutoSize = true;
            this.lblSolverUser.BackColor = System.Drawing.Color.Transparent;
            this.lblSolverUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolverUser.Location = new System.Drawing.Point(341, 196);
            this.lblSolverUser.Name = "lblSolverUser";
            this.lblSolverUser.Size = new System.Drawing.Size(154, 18);
            this.lblSolverUser.TabIndex = 8;
            this.lblSolverUser.Text = "Usuario solucionador:";
            // 
            // dgvCommentsSolvedByUser
            // 
            this.dgvCommentsSolvedByUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCommentsSolvedByUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommentsSolvedByUser.Location = new System.Drawing.Point(27, 232);
            this.dgvCommentsSolvedByUser.Name = "dgvCommentsSolvedByUser";
            this.dgvCommentsSolvedByUser.Size = new System.Drawing.Size(595, 255);
            this.dgvCommentsSolvedByUser.TabIndex = 9;
            // 
            // cmbCreatorUser
            // 
            this.cmbCreatorUser.FormattingEnabled = true;
            this.cmbCreatorUser.Location = new System.Drawing.Point(195, 195);
            this.cmbCreatorUser.Name = "cmbCreatorUser";
            this.cmbCreatorUser.Size = new System.Drawing.Size(121, 21);
            this.cmbCreatorUser.TabIndex = 10;
            // 
            // cmbSolverUser
            // 
            this.cmbSolverUser.FormattingEnabled = true;
            this.cmbSolverUser.Location = new System.Drawing.Point(501, 195);
            this.cmbSolverUser.Name = "cmbSolverUser";
            this.cmbSolverUser.Size = new System.Drawing.Size(121, 21);
            this.cmbSolverUser.TabIndex = 11;
            // 
            // dtpCommentsCreatedFrom
            // 
            this.dtpCommentsCreatedFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCommentsCreatedFrom.Location = new System.Drawing.Point(224, 134);
            this.dtpCommentsCreatedFrom.Name = "dtpCommentsCreatedFrom";
            this.dtpCommentsCreatedFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpCommentsCreatedFrom.TabIndex = 12;
            // 
            // dtpCommentsCreatedUntil
            // 
            this.dtpCommentsCreatedUntil.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCommentsCreatedUntil.Location = new System.Drawing.Point(223, 164);
            this.dtpCommentsCreatedUntil.Name = "dtpCommentsCreatedUntil";
            this.dtpCommentsCreatedUntil.Size = new System.Drawing.Size(90, 20);
            this.dtpCommentsCreatedUntil.TabIndex = 13;
            // 
            // dtpCommentsSolvedFrom
            // 
            this.dtpCommentsSolvedFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCommentsSolvedFrom.Location = new System.Drawing.Point(539, 134);
            this.dtpCommentsSolvedFrom.Name = "dtpCommentsSolvedFrom";
            this.dtpCommentsSolvedFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpCommentsSolvedFrom.TabIndex = 14;
            // 
            // dtpCommentsSolvedUntil
            // 
            this.dtpCommentsSolvedUntil.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCommentsSolvedUntil.Location = new System.Drawing.Point(535, 164);
            this.dtpCommentsSolvedUntil.Name = "dtpCommentsSolvedUntil";
            this.dtpCommentsSolvedUntil.Size = new System.Drawing.Size(90, 20);
            this.dtpCommentsSolvedUntil.TabIndex = 15;
            // 
            // btnApllyFilters
            // 
            this.btnApllyFilters.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnApllyFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApllyFilters.Location = new System.Drawing.Point(634, 187);
            this.btnApllyFilters.Name = "btnApllyFilters";
            this.btnApllyFilters.Size = new System.Drawing.Size(80, 36);
            this.btnApllyFilters.TabIndex = 16;
            this.btnApllyFilters.Text = "Aplicar";
            this.btnApllyFilters.UseVisualStyleBackColor = false;
            // 
            // UCAdministratorCommentsSolvedByUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnApllyFilters);
            this.Controls.Add(this.dtpCommentsSolvedUntil);
            this.Controls.Add(this.dtpCommentsSolvedFrom);
            this.Controls.Add(this.dtpCommentsCreatedUntil);
            this.Controls.Add(this.dtpCommentsCreatedFrom);
            this.Controls.Add(this.cmbSolverUser);
            this.Controls.Add(this.cmbCreatorUser);
            this.Controls.Add(this.dgvCommentsSolvedByUser);
            this.Controls.Add(this.lblSolverUser);
            this.Controls.Add(this.lblCreatorUser);
            this.Controls.Add(this.lblCommentsSolvedUntil);
            this.Controls.Add(this.lblCommentsSolvedFrom);
            this.Controls.Add(this.lblCommentsCreatedUntil);
            this.Controls.Add(this.lblCommentsCreatedFrom);
            this.Controls.Add(this.lblCommentsSolvedByUser);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHome);
            this.Name = "UCAdministratorCommentsSolvedByUser";
            this.Size = new System.Drawing.Size(747, 538);
            this.Load += new System.EventHandler(this.UCAdministratorCommentsSolvedByUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommentsSolvedByUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblCommentsSolvedByUser;
        private System.Windows.Forms.Label lblCommentsCreatedFrom;
        private System.Windows.Forms.Label lblCommentsCreatedUntil;
        private System.Windows.Forms.Label lblCommentsSolvedFrom;
        private System.Windows.Forms.Label lblCommentsSolvedUntil;
        private System.Windows.Forms.Label lblCreatorUser;
        private System.Windows.Forms.Label lblSolverUser;
        private System.Windows.Forms.DataGridView dgvCommentsSolvedByUser;
        private System.Windows.Forms.ComboBox cmbCreatorUser;
        private System.Windows.Forms.ComboBox cmbSolverUser;
        private System.Windows.Forms.DateTimePicker dtpCommentsCreatedFrom;
        private System.Windows.Forms.DateTimePicker dtpCommentsCreatedUntil;
        private System.Windows.Forms.DateTimePicker dtpCommentsSolvedFrom;
        private System.Windows.Forms.DateTimePicker dtpCommentsSolvedUntil;
        private System.Windows.Forms.Button btnApllyFilters;
    }
}
