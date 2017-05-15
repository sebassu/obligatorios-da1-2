namespace Interface
{
    partial class UCAddMemberToTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAddMemberToTeam));
            this.lblAddMemberToTeam = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTeam = new System.Windows.Forms.Label();
            this.lstUsers = new System.Windows.Forms.ListView();
            this.lblTeamSelected = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAddMemberToTeam
            // 
            this.lblAddMemberToTeam.AutoSize = true;
            this.lblAddMemberToTeam.BackColor = System.Drawing.Color.Transparent;
            this.lblAddMemberToTeam.Font = new System.Drawing.Font("Segoe Script", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddMemberToTeam.Location = new System.Drawing.Point(154, 82);
            this.lblAddMemberToTeam.Name = "lblAddMemberToTeam";
            this.lblAddMemberToTeam.Size = new System.Drawing.Size(386, 44);
            this.lblAddMemberToTeam.TabIndex = 0;
            this.lblAddMemberToTeam.Text = "Agregar usuario a equipo";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(109, 227);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(143, 18);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Seleccionar usuario:";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Lime;
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(441, 453);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(99, 35);
            this.btnAccept.TabIndex = 18;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(559, 453);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 35);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.BackColor = System.Drawing.Color.Transparent;
            this.lblTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam.Location = new System.Drawing.Point(109, 150);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(58, 18);
            this.lblTeam.TabIndex = 20;
            this.lblTeam.Text = "Equipo:";
            // 
            // lstUsers
            // 
            this.lstUsers.Location = new System.Drawing.Point(281, 227);
            this.lstUsers.MultiSelect = false;
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(377, 220);
            this.lstUsers.TabIndex = 21;
            this.lstUsers.TileSize = new System.Drawing.Size(377, 30);
            this.lstUsers.UseCompatibleStateImageBehavior = false;
            this.lstUsers.View = System.Windows.Forms.View.Tile;
            // 
            // lblTeamSelected
            // 
            this.lblTeamSelected.AutoSize = true;
            this.lblTeamSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamSelected.Location = new System.Drawing.Point(278, 155);
            this.lblTeamSelected.Name = "lblTeamSelected";
            this.lblTeamSelected.Size = new System.Drawing.Size(0, 18);
            this.lblTeamSelected.TabIndex = 22;
            // 
            // UCAddMemberToTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblTeamSelected);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.lblTeam);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblAddMemberToTeam);
            this.Name = "UCAddMemberToTeam";
            this.Size = new System.Drawing.Size(747, 538);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddMemberToTeam;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.ListView lstUsers;
        private System.Windows.Forms.Label lblTeamSelected;
    }
}
