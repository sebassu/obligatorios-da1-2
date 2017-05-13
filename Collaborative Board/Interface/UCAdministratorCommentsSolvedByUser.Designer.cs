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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblCommentsSolvedByUser = new System.Windows.Forms.Label();
            this.lblCommentsCreatedFrom = new System.Windows.Forms.Label();
            this.lblCommentsCreatedUntil = new System.Windows.Forms.Label();
            this.lblCommentsSolvedFrom = new System.Windows.Forms.Label();
            this.lblCommentsSolvedUntil = new System.Windows.Forms.Label();
            this.lblCreatorUser = new System.Windows.Forms.Label();
            this.lblSolverUser = new System.Windows.Forms.Label();
            this.cmbCreatorUser = new System.Windows.Forms.ComboBox();
            this.cmbSolverUser = new System.Windows.Forms.ComboBox();
            this.dtpCommentsCreatedFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpCommentsCreatedUntil = new System.Windows.Forms.DateTimePicker();
            this.dtpCommentsSolvedFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpCommentsSolvedUntil = new System.Windows.Forms.DateTimePicker();
            this.btnApllyFilters = new System.Windows.Forms.Button();
            this.dgvCommentsSolvedByUser = new System.Windows.Forms.DataGridView();
            this.commentTextColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creationDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creatorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solverColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.whiteboardColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resolutionDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommentsSolvedByUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Location = new System.Drawing.Point(42, 29);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(80, 79);
            this.btnHome.TabIndex = 0;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.MouseEnter += new System.EventHandler(this.btnHome_MouseEnter);
            this.btnHome.MouseLeave += new System.EventHandler(this.btnHome_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(634, 415);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 83);
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
            // cmbCreatorUser
            // 
            this.cmbCreatorUser.FormattingEnabled = true;
            this.cmbCreatorUser.Location = new System.Drawing.Point(195, 195);
            this.cmbCreatorUser.Name = "cmbCreatorUser";
            this.cmbCreatorUser.Size = new System.Drawing.Size(121, 21);
            this.cmbCreatorUser.Sorted = true;
            this.cmbCreatorUser.TabIndex = 10;
            // 
            // cmbSolverUser
            // 
            this.cmbSolverUser.FormattingEnabled = true;
            this.cmbSolverUser.Location = new System.Drawing.Point(501, 195);
            this.cmbSolverUser.Name = "cmbSolverUser";
            this.cmbSolverUser.Size = new System.Drawing.Size(121, 21);
            this.cmbSolverUser.Sorted = true;
            this.cmbSolverUser.TabIndex = 11;
            // 
            // dtpCommentsCreatedFrom
            // 
            this.dtpCommentsCreatedFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCommentsCreatedFrom.Location = new System.Drawing.Point(224, 134);
            this.dtpCommentsCreatedFrom.MinDate = new System.DateTime(2017, 5, 12, 0, 0, 0, 0);
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
            this.dtpCommentsSolvedFrom.Size = new System.Drawing.Size(86, 20);
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
            this.btnApllyFilters.Location = new System.Drawing.Point(626, 195);
            this.btnApllyFilters.Name = "btnApllyFilters";
            this.btnApllyFilters.Size = new System.Drawing.Size(99, 36);
            this.btnApllyFilters.TabIndex = 16;
            this.btnApllyFilters.Text = "Aplicar";
            this.btnApllyFilters.UseVisualStyleBackColor = false;
            this.btnApllyFilters.Click += new System.EventHandler(this.btnApllyFilters_Click);
            // 
            // dgvCommentsSolvedByUser
            // 
            this.dgvCommentsSolvedByUser.AllowUserToAddRows = false;
            this.dgvCommentsSolvedByUser.AllowUserToDeleteRows = false;
            this.dgvCommentsSolvedByUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCommentsSolvedByUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCommentsSolvedByUser.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommentsSolvedByUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCommentsSolvedByUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommentsSolvedByUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.commentTextColumn,
            this.creationDateColumn,
            this.creatorColumn,
            this.solverColumn,
            this.whiteboardColumn,
            this.resolutionDateColumn});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommentsSolvedByUser.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvCommentsSolvedByUser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCommentsSolvedByUser.Location = new System.Drawing.Point(29, 228);
            this.dgvCommentsSolvedByUser.MultiSelect = false;
            this.dgvCommentsSolvedByUser.Name = "dgvCommentsSolvedByUser";
            this.dgvCommentsSolvedByUser.ReadOnly = true;
            this.dgvCommentsSolvedByUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCommentsSolvedByUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommentsSolvedByUser.Size = new System.Drawing.Size(591, 262);
            this.dgvCommentsSolvedByUser.TabIndex = 37;
            // 
            // commentTextColumn
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.commentTextColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.commentTextColumn.HeaderText = "Comentario";
            this.commentTextColumn.MinimumWidth = 191;
            this.commentTextColumn.Name = "commentTextColumn";
            this.commentTextColumn.ReadOnly = true;
            this.commentTextColumn.ToolTipText = "Texto del comentario.";
            this.commentTextColumn.Width = 191;
            // 
            // creationDateColumn
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.creationDateColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.creationDateColumn.HeaderText = "Fecha de creación";
            this.creationDateColumn.MinimumWidth = 191;
            this.creationDateColumn.Name = "creationDateColumn";
            this.creationDateColumn.ReadOnly = true;
            this.creationDateColumn.ToolTipText = "Fecha de creación del comentario.";
            this.creationDateColumn.Width = 191;
            // 
            // creatorColumn
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.creatorColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.creatorColumn.HeaderText = "Creador";
            this.creatorColumn.MinimumWidth = 192;
            this.creatorColumn.Name = "creatorColumn";
            this.creatorColumn.ReadOnly = true;
            this.creatorColumn.ToolTipText = "Usuario creador del comentario.";
            this.creatorColumn.Width = 192;
            // 
            // solverColumn
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.solverColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.solverColumn.HeaderText = "Solucionador";
            this.solverColumn.MinimumWidth = 200;
            this.solverColumn.Name = "solverColumn";
            this.solverColumn.ReadOnly = true;
            this.solverColumn.ToolTipText = "Usuario que resuelve el comentario.";
            this.solverColumn.Width = 200;
            // 
            // whiteboardColumn
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.whiteboardColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.whiteboardColumn.HeaderText = "Pizarrón";
            this.whiteboardColumn.MinimumWidth = 191;
            this.whiteboardColumn.Name = "whiteboardColumn";
            this.whiteboardColumn.ReadOnly = true;
            this.whiteboardColumn.ToolTipText = "Pizarrón al cual el elemento vinculado al comentario pertenece.";
            this.whiteboardColumn.Width = 191;
            // 
            // resolutionDateColumn
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.resolutionDateColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.resolutionDateColumn.HeaderText = "Fecha de resolución";
            this.resolutionDateColumn.MinimumWidth = 200;
            this.resolutionDateColumn.Name = "resolutionDateColumn";
            this.resolutionDateColumn.ReadOnly = true;
            this.resolutionDateColumn.ToolTipText = "Fecha de resuelto el comentario.";
            this.resolutionDateColumn.Width = 200;
            // 
            // UCAdministratorCommentsSolvedByUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.dgvCommentsSolvedByUser);
            this.Controls.Add(this.btnApllyFilters);
            this.Controls.Add(this.dtpCommentsSolvedUntil);
            this.Controls.Add(this.dtpCommentsSolvedFrom);
            this.Controls.Add(this.dtpCommentsCreatedUntil);
            this.Controls.Add(this.dtpCommentsCreatedFrom);
            this.Controls.Add(this.cmbSolverUser);
            this.Controls.Add(this.cmbCreatorUser);
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
        private System.Windows.Forms.ComboBox cmbCreatorUser;
        private System.Windows.Forms.ComboBox cmbSolverUser;
        private System.Windows.Forms.DateTimePicker dtpCommentsCreatedFrom;
        private System.Windows.Forms.DateTimePicker dtpCommentsCreatedUntil;
        private System.Windows.Forms.DateTimePicker dtpCommentsSolvedFrom;
        private System.Windows.Forms.DateTimePicker dtpCommentsSolvedUntil;
        private System.Windows.Forms.Button btnApllyFilters;
        private System.Windows.Forms.DataGridView dgvCommentsSolvedByUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentTextColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creationDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creatorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn solverColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn whiteboardColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resolutionDateColumn;
    }
}
