namespace GraphicInterface
{
    partial class UCScoreMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCScoreMenu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnResetTeamScore = new System.Windows.Forms.Button();
            this.btnAssignScoreToEvents = new System.Windows.Forms.Button();
            this.btnTeamRanking = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvScoringBoard = new System.Windows.Forms.DataGridView();
            this.teamNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamScoreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScoringBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnResetTeamScore
            // 
            this.btnResetTeamScore.BackColor = System.Drawing.Color.Gray;
            this.btnResetTeamScore.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetTeamScore.ForeColor = System.Drawing.Color.White;
            this.btnResetTeamScore.Location = new System.Drawing.Point(502, 332);
            this.btnResetTeamScore.Name = "btnResetTeamScore";
            this.btnResetTeamScore.Size = new System.Drawing.Size(221, 91);
            this.btnResetTeamScore.TabIndex = 9;
            this.btnResetTeamScore.Text = "REINICIAR PUNTAJE EQUIPO";
            this.btnResetTeamScore.UseVisualStyleBackColor = false;
            this.btnResetTeamScore.Click += new System.EventHandler(this.BtnResetTeamScore_Click);
            this.btnResetTeamScore.MouseEnter += new System.EventHandler(this.BtnResetTeamScore_MouseEnter);
            this.btnResetTeamScore.MouseLeave += new System.EventHandler(this.BtnResetTeamScore_MouseLeave);
            // 
            // btnAssignScoreToEvents
            // 
            this.btnAssignScoreToEvents.BackColor = System.Drawing.Color.Gray;
            this.btnAssignScoreToEvents.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignScoreToEvents.ForeColor = System.Drawing.Color.White;
            this.btnAssignScoreToEvents.Location = new System.Drawing.Point(502, 110);
            this.btnAssignScoreToEvents.Name = "btnAssignScoreToEvents";
            this.btnAssignScoreToEvents.Size = new System.Drawing.Size(222, 91);
            this.btnAssignScoreToEvents.TabIndex = 10;
            this.btnAssignScoreToEvents.Text = "ASIGNAR PUNTAJE A EVENTOS";
            this.btnAssignScoreToEvents.UseVisualStyleBackColor = false;
            this.btnAssignScoreToEvents.Click += new System.EventHandler(this.BtnAssignScoreToEvents_Click);
            this.btnAssignScoreToEvents.MouseEnter += new System.EventHandler(this.BtnAssignScoreToEvents_MouseEnter);
            this.btnAssignScoreToEvents.MouseLeave += new System.EventHandler(this.BtnAssignScoreToEvents_MouseLeave);
            // 
            // btnTeamRanking
            // 
            this.btnTeamRanking.BackColor = System.Drawing.Color.Gray;
            this.btnTeamRanking.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeamRanking.ForeColor = System.Drawing.Color.White;
            this.btnTeamRanking.Location = new System.Drawing.Point(502, 220);
            this.btnTeamRanking.Name = "btnTeamRanking";
            this.btnTeamRanking.Size = new System.Drawing.Size(222, 91);
            this.btnTeamRanking.TabIndex = 11;
            this.btnTeamRanking.Text = "VER RANKING EQUIPO";
            this.btnTeamRanking.UseVisualStyleBackColor = false;
            this.btnTeamRanking.Click += new System.EventHandler(this.BtnTeamRanking_Click);
            this.btnTeamRanking.MouseEnter += new System.EventHandler(this.BtnTeamRanking_MouseEnter);
            this.btnTeamRanking.MouseLeave += new System.EventHandler(this.BtnTeamRanking_MouseLeave);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(168, 110);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(210, 34);
            this.lblScore.TabIndex = 12;
            this.lblScore.Text = "Tabla de puntajes";
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Location = new System.Drawing.Point(42, 29);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(80, 62);
            this.btnHome.TabIndex = 13;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.BtnHome_Click);
            this.btnHome.MouseEnter += new System.EventHandler(this.BtnHome_MouseEnter);
            this.btnHome.MouseLeave += new System.EventHandler(this.BtnHome_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(643, 436);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 62);
            this.btnExit.TabIndex = 14;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // dgvScoringBoard
            // 
            this.dgvScoringBoard.AllowUserToAddRows = false;
            this.dgvScoringBoard.AllowUserToDeleteRows = false;
            this.dgvScoringBoard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvScoringBoard.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvScoringBoard.BackgroundColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScoringBoard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScoringBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScoringBoard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.teamNameColumn,
            this.teamScoreColumn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvScoringBoard.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvScoringBoard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvScoringBoard.Location = new System.Drawing.Point(42, 158);
            this.dgvScoringBoard.MultiSelect = false;
            this.dgvScoringBoard.Name = "dgvScoringBoard";
            this.dgvScoringBoard.ReadOnly = true;
            this.dgvScoringBoard.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvScoringBoard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScoringBoard.Size = new System.Drawing.Size(443, 317);
            this.dgvScoringBoard.TabIndex = 38;
            // 
            // teamNameColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.teamNameColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.teamNameColumn.HeaderText = "Equipo";
            this.teamNameColumn.MinimumWidth = 191;
            this.teamNameColumn.Name = "teamNameColumn";
            this.teamNameColumn.ReadOnly = true;
            this.teamNameColumn.ToolTipText = "Nombre del equipo.";
            this.teamNameColumn.Width = 191;
            // 
            // teamScoreColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.teamScoreColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.teamScoreColumn.HeaderText = "Puntaje";
            this.teamScoreColumn.MinimumWidth = 191;
            this.teamScoreColumn.Name = "teamScoreColumn";
            this.teamScoreColumn.ReadOnly = true;
            this.teamScoreColumn.ToolTipText = "Puntaje del equipo.";
            this.teamScoreColumn.Width = 191;
            // 
            // UCScoreMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.dgvScoringBoard);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnTeamRanking);
            this.Controls.Add(this.btnAssignScoreToEvents);
            this.Controls.Add(this.btnResetTeamScore);
            this.Name = "UCScoreMenu";
            this.Size = new System.Drawing.Size(747, 538);
            this.Load += new System.EventHandler(this.UCScoreAdministrator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScoringBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnResetTeamScore;
        private System.Windows.Forms.Button btnAssignScoreToEvents;
        private System.Windows.Forms.Button btnTeamRanking;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvScoringBoard;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamScoreColumn;
    }
}
