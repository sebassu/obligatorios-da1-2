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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblWhiteboardsCreatedByTeam = new System.Windows.Forms.Label();
            this.cmbTeams = new System.Windows.Forms.ComboBox();
            this.lblWhiteboardsCreatedFrom = new System.Windows.Forms.Label();
            this.lblTeam = new System.Windows.Forms.Label();
            this.lblWhiteboardsCreatedUntil = new System.Windows.Forms.Label();
            this.dtpWhiteboardsCreatedFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpWhiteboardsCreatedUntil = new System.Windows.Forms.DateTimePicker();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.dgvWhiteboardsCreatedByTeam = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerTeamColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creationDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModificationDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfElementsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWhiteboardsCreatedByTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Location = new System.Drawing.Point(42, 29);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(80, 62);
            this.btnHome.TabIndex = 0;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
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
            // btnApplyFilters
            // 
            this.btnApplyFilters.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnApplyFilters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyFilters.Location = new System.Drawing.Point(634, 145);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(80, 36);
            this.btnApplyFilters.TabIndex = 10;
            this.btnApplyFilters.Text = "Aplicar";
            this.btnApplyFilters.UseVisualStyleBackColor = false;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click);
            // 
            // dgvWhiteboardsCreatedByTeam
            // 
            this.dgvWhiteboardsCreatedByTeam.AllowUserToAddRows = false;
            this.dgvWhiteboardsCreatedByTeam.AllowUserToDeleteRows = false;
            this.dgvWhiteboardsCreatedByTeam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvWhiteboardsCreatedByTeam.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvWhiteboardsCreatedByTeam.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWhiteboardsCreatedByTeam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWhiteboardsCreatedByTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWhiteboardsCreatedByTeam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.ownerTeamColumn,
            this.creationDateColumn,
            this.lastModificationDateColumn,
            this.numberOfElementsColumn});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWhiteboardsCreatedByTeam.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvWhiteboardsCreatedByTeam.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvWhiteboardsCreatedByTeam.Location = new System.Drawing.Point(27, 195);
            this.dgvWhiteboardsCreatedByTeam.MultiSelect = false;
            this.dgvWhiteboardsCreatedByTeam.Name = "dgvWhiteboardsCreatedByTeam";
            this.dgvWhiteboardsCreatedByTeam.ReadOnly = true;
            this.dgvWhiteboardsCreatedByTeam.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvWhiteboardsCreatedByTeam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWhiteboardsCreatedByTeam.Size = new System.Drawing.Size(601, 291);
            this.dgvWhiteboardsCreatedByTeam.TabIndex = 38;
            // 
            // nameColumn
            // 
            this.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.nameColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nameColumn.HeaderText = "Nombre";
            this.nameColumn.MinimumWidth = 191;
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.ToolTipText = "Nombre del pizarrón";
            this.nameColumn.Width = 191;
            // 
            // ownerTeamColumn
            // 
            this.ownerTeamColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ownerTeamColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.ownerTeamColumn.HeaderText = "Equipo creador";
            this.ownerTeamColumn.MinimumWidth = 191;
            this.ownerTeamColumn.Name = "ownerTeamColumn";
            this.ownerTeamColumn.ReadOnly = true;
            this.ownerTeamColumn.ToolTipText = "Equipo dueño del pizarrón.";
            this.ownerTeamColumn.Width = 191;
            // 
            // creationDateColumn
            // 
            this.creationDateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.creationDateColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.creationDateColumn.HeaderText = "Fecha de creación";
            this.creationDateColumn.MinimumWidth = 191;
            this.creationDateColumn.Name = "creationDateColumn";
            this.creationDateColumn.ReadOnly = true;
            this.creationDateColumn.ToolTipText = "Fecha de creación del pizarrón.";
            this.creationDateColumn.Width = 191;
            // 
            // lastModificationDateColumn
            // 
            this.lastModificationDateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lastModificationDateColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.lastModificationDateColumn.HeaderText = "Fecha de última modificación";
            this.lastModificationDateColumn.MinimumWidth = 192;
            this.lastModificationDateColumn.Name = "lastModificationDateColumn";
            this.lastModificationDateColumn.ReadOnly = true;
            this.lastModificationDateColumn.ToolTipText = "Fecha de última modificación del pizarrón.";
            this.lastModificationDateColumn.Width = 213;
            // 
            // numberOfElementsColumn
            // 
            this.numberOfElementsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.numberOfElementsColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.numberOfElementsColumn.HeaderText = "Cantidad de elementos";
            this.numberOfElementsColumn.MinimumWidth = 200;
            this.numberOfElementsColumn.Name = "numberOfElementsColumn";
            this.numberOfElementsColumn.ReadOnly = true;
            this.numberOfElementsColumn.ToolTipText = "Cantidad de elementos contenidos en el pizarrón.";
            this.numberOfElementsColumn.Width = 200;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(614, 84);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 36);
            this.btnReset.TabIndex = 39;
            this.btnReset.Text = "Restablecer";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // UCWhiteboardsCreatedByTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dgvWhiteboardsCreatedByTeam);
            this.Controls.Add(this.btnApplyFilters);
            this.Controls.Add(this.dtpWhiteboardsCreatedUntil);
            this.Controls.Add(this.dtpWhiteboardsCreatedFrom);
            this.Controls.Add(this.lblWhiteboardsCreatedUntil);
            this.Controls.Add(this.lblTeam);
            this.Controls.Add(this.lblWhiteboardsCreatedFrom);
            this.Controls.Add(this.cmbTeams);
            this.Controls.Add(this.lblWhiteboardsCreatedByTeam);
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
        private System.Windows.Forms.Label lblWhiteboardsCreatedByTeam;
        private System.Windows.Forms.ComboBox cmbTeams;
        private System.Windows.Forms.Label lblWhiteboardsCreatedFrom;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.Label lblWhiteboardsCreatedUntil;
        private System.Windows.Forms.DateTimePicker dtpWhiteboardsCreatedFrom;
        private System.Windows.Forms.DateTimePicker dtpWhiteboardsCreatedUntil;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.DataGridView dgvWhiteboardsCreatedByTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerTeamColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creationDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModificationDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfElementsColumn;
        private System.Windows.Forms.Button btnReset;
    }
}
