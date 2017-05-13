﻿namespace Interface
{
    partial class UCAddOrModifyTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAddOrModifyTeam));
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblMaximumAmmountUsers = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblTeamData = new System.Windows.Forms.Label();
            this.numMaximumAmmountUsers = new System.Windows.Forms.NumericUpDown();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picMarker = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximumAmmountUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMarker)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(115, 358);
            this.lblName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(167, 44);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(115, 634);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(230, 44);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Descripción:";
            // 
            // lblMaximumAmmountUsers
            // 
            this.lblMaximumAmmountUsers.AutoSize = true;
            this.lblMaximumAmmountUsers.BackColor = System.Drawing.Color.Transparent;
            this.lblMaximumAmmountUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaximumAmmountUsers.Location = new System.Drawing.Point(115, 496);
            this.lblMaximumAmmountUsers.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblMaximumAmmountUsers.Name = "lblMaximumAmmountUsers";
            this.lblMaximumAmmountUsers.Size = new System.Drawing.Size(535, 44);
            this.lblMaximumAmmountUsers.TabIndex = 2;
            this.lblMaximumAmmountUsers.Text = "Cantidad máxima de usuarios:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(683, 360);
            this.txtName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(585, 38);
            this.txtName.TabIndex = 10;
            // 
            // lblTeamData
            // 
            this.lblTeamData.AutoSize = true;
            this.lblTeamData.BackColor = System.Drawing.Color.Transparent;
            this.lblTeamData.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamData.Location = new System.Drawing.Point(643, 193);
            this.lblTeamData.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblTeamData.Name = "lblTeamData";
            this.lblTeamData.Size = new System.Drawing.Size(488, 87);
            this.lblTeamData.TabIndex = 13;
            this.lblTeamData.Text = "Datos de equipo";
            // 
            // numMaximumAmmountUsers
            // 
            this.numMaximumAmmountUsers.Location = new System.Drawing.Point(683, 502);
            this.numMaximumAmmountUsers.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numMaximumAmmountUsers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaximumAmmountUsers.Name = "numMaximumAmmountUsers";
            this.numMaximumAmmountUsers.Size = new System.Drawing.Size(592, 38);
            this.numMaximumAmmountUsers.TabIndex = 14;
            this.numMaximumAmmountUsers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(683, 634);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(585, 245);
            this.rtbDescription.TabIndex = 15;
            this.rtbDescription.Text = "";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Lime;
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(685, 975);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(264, 83);
            this.btnAccept.TabIndex = 17;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1011, 975);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(264, 83);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // picMarker
            // 
            this.picMarker.Image = ((System.Drawing.Image)(resources.GetObject("picMarker.Image")));
            this.picMarker.Location = new System.Drawing.Point(1381, 596);
            this.picMarker.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.picMarker.Name = "picMarker";
            this.picMarker.Size = new System.Drawing.Size(571, 620);
            this.picMarker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMarker.TabIndex = 18;
            this.picMarker.TabStop = false;
            // 
            // UCAddOrModifyTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.picMarker);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.numMaximumAmmountUsers);
            this.Controls.Add(this.lblTeamData);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblMaximumAmmountUsers);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "UCAddOrModifyTeam";
            this.Size = new System.Drawing.Size(1992, 1283);
            ((System.ComponentModel.ISupportInitialize)(this.numMaximumAmmountUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMarker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblMaximumAmmountUsers;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblTeamData;
        private System.Windows.Forms.NumericUpDown numMaximumAmmountUsers;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picMarker;
    }
}
