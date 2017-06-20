namespace GraphicInterface
{
    partial class UCTeamRanking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTeamRanking));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTeamRanking = new System.Windows.Forms.Label();
            this.lblTeam = new System.Windows.Forms.Label();
            this.lblTeamSelected = new System.Windows.Forms.Label();
            this.dgvRankingBoard = new System.Windows.Forms.DataGridView();
            this.userEmailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userScoreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankingBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(646, 436);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 62);
            this.btnExit.TabIndex = 15;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Location = new System.Drawing.Point(36, 37);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 79);
            this.btnBack.TabIndex = 28;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTeamRanking
            // 
            this.lblTeamRanking.AutoSize = true;
            this.lblTeamRanking.BackColor = System.Drawing.Color.Transparent;
            this.lblTeamRanking.Font = new System.Drawing.Font("Segoe Script", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamRanking.Location = new System.Drawing.Point(226, 72);
            this.lblTeamRanking.Name = "lblTeamRanking";
            this.lblTeamRanking.Size = new System.Drawing.Size(295, 44);
            this.lblTeamRanking.TabIndex = 29;
            this.lblTeamRanking.Text = "Ranking de equipo";
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.BackColor = System.Drawing.Color.Transparent;
            this.lblTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam.Location = new System.Drawing.Point(277, 144);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(58, 18);
            this.lblTeam.TabIndex = 30;
            this.lblTeam.Text = "Equipo:";
            // 
            // lblTeamSelected
            // 
            this.lblTeamSelected.AutoSize = true;
            this.lblTeamSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamSelected.Location = new System.Drawing.Point(360, 146);
            this.lblTeamSelected.Name = "lblTeamSelected";
            this.lblTeamSelected.Size = new System.Drawing.Size(0, 18);
            this.lblTeamSelected.TabIndex = 31;
            // 
            // dgvRankingBoard
            // 
            this.dgvRankingBoard.AllowUserToAddRows = false;
            this.dgvRankingBoard.AllowUserToDeleteRows = false;
            this.dgvRankingBoard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRankingBoard.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRankingBoard.BackgroundColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRankingBoard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRankingBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRankingBoard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userEmailColumn,
            this.userScoreColumn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRankingBoard.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRankingBoard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRankingBoard.Location = new System.Drawing.Point(36, 181);
            this.dgvRankingBoard.MultiSelect = false;
            this.dgvRankingBoard.Name = "dgvRankingBoard";
            this.dgvRankingBoard.ReadOnly = true;
            this.dgvRankingBoard.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRankingBoard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRankingBoard.Size = new System.Drawing.Size(587, 302);
            this.dgvRankingBoard.TabIndex = 39;
            // 
            // userEmailColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.userEmailColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.userEmailColumn.HeaderText = "Usuario";
            this.userEmailColumn.MinimumWidth = 191;
            this.userEmailColumn.Name = "userEmailColumn";
            this.userEmailColumn.ReadOnly = true;
            this.userEmailColumn.ToolTipText = "Mail del usuario.";
            this.userEmailColumn.Width = 191;
            // 
            // userScoreColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.userScoreColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.userScoreColumn.HeaderText = "Puntaje";
            this.userScoreColumn.MinimumWidth = 191;
            this.userScoreColumn.Name = "userScoreColumn";
            this.userScoreColumn.ReadOnly = true;
            this.userScoreColumn.ToolTipText = "Puntaje del Usuario.";
            this.userScoreColumn.Width = 191;
            // 
            // UCTeamRanking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.dgvRankingBoard);
            this.Controls.Add(this.lblTeamSelected);
            this.Controls.Add(this.lblTeam);
            this.Controls.Add(this.lblTeamRanking);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnExit);
            this.Name = "UCTeamRanking";
            this.Size = new System.Drawing.Size(747, 538);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankingBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTeamRanking;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.Label lblTeamSelected;
        private System.Windows.Forms.DataGridView dgvRankingBoard;
        private System.Windows.Forms.DataGridViewTextBoxColumn userEmailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userScoreColumn;
    }
}
