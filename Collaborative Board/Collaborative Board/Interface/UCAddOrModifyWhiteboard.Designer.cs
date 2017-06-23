namespace GraphicInterface
{
    partial class UCAddOrModifyWhiteboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAddOrModifyWhiteboard));
            this.picMarker = new System.Windows.Forms.PictureBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblWhiteboardData = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblOwnerTeam = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbOwnerTeam = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMarker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // picMarker
            // 
            this.picMarker.Image = ((System.Drawing.Image)(resources.GetObject("picMarker.Image")));
            this.picMarker.Location = new System.Drawing.Point(1381, 596);
            this.picMarker.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.picMarker.Name = "picMarker";
            this.picMarker.Size = new System.Drawing.Size(571, 620);
            this.picMarker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMarker.TabIndex = 21;
            this.picMarker.TabStop = false;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Lime;
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(608, 1013);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(264, 83);
            this.btnAccept.TabIndex = 20;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(947, 1013);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(264, 83);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(184, 291);
            this.lblName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(167, 44);
            this.lblName.TabIndex = 22;
            this.lblName.Text = "Nombre:";
            // 
            // lblWhiteboardData
            // 
            this.lblWhiteboardData.AutoSize = true;
            this.lblWhiteboardData.BackColor = System.Drawing.Color.Transparent;
            this.lblWhiteboardData.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhiteboardData.Location = new System.Drawing.Point(520, 145);
            this.lblWhiteboardData.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblWhiteboardData.Name = "lblWhiteboardData";
            this.lblWhiteboardData.Size = new System.Drawing.Size(543, 87);
            this.lblWhiteboardData.TabIndex = 23;
            this.lblWhiteboardData.Text = "Datos de pizarrón";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(184, 739);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(230, 44);
            this.lblDescription.TabIndex = 24;
            this.lblDescription.Text = "Descripción:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.BackColor = System.Drawing.Color.Transparent;
            this.lblWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidth.Location = new System.Drawing.Point(184, 510);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(138, 44);
            this.lblWidth.TabIndex = 25;
            this.lblWidth.Text = "Ancho:";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.BackColor = System.Drawing.Color.Transparent;
            this.lblHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeight.Location = new System.Drawing.Point(184, 622);
            this.lblHeight.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(131, 44);
            this.lblHeight.TabIndex = 26;
            this.lblHeight.Text = "Altura:";
            // 
            // lblOwnerTeam
            // 
            this.lblOwnerTeam.AutoSize = true;
            this.lblOwnerTeam.BackColor = System.Drawing.Color.Transparent;
            this.lblOwnerTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerTeam.Location = new System.Drawing.Point(184, 403);
            this.lblOwnerTeam.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblOwnerTeam.Name = "lblOwnerTeam";
            this.lblOwnerTeam.Size = new System.Drawing.Size(311, 44);
            this.lblOwnerTeam.TabIndex = 27;
            this.lblOwnerTeam.Text = "Equipo asociado:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(536, 739);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(668, 233);
            this.rtbDescription.TabIndex = 28;
            this.rtbDescription.Text = "";
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(536, 615);
            this.numHeight.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numHeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(675, 38);
            this.numHeight.TabIndex = 29;
            this.numHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(536, 503);
            this.numWidth.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numWidth.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(675, 38);
            this.numWidth.TabIndex = 30;
            this.numWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(536, 291);
            this.txtName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(668, 38);
            this.txtName.TabIndex = 32;
            // 
            // cmbOwnerTeam
            // 
            this.cmbOwnerTeam.FormattingEnabled = true;
            this.cmbOwnerTeam.Location = new System.Drawing.Point(536, 410);
            this.cmbOwnerTeam.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cmbOwnerTeam.Name = "cmbOwnerTeam";
            this.cmbOwnerTeam.Size = new System.Drawing.Size(668, 39);
            this.cmbOwnerTeam.TabIndex = 33;
            // 
            // UCAddOrModifyWhiteboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.cmbOwnerTeam);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblOwnerTeam);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblWhiteboardData);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picMarker);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "UCAddOrModifyWhiteboard";
            this.Size = new System.Drawing.Size(1992, 1283);
            ((System.ComponentModel.ISupportInitialize)(this.picMarker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picMarker;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblWhiteboardData;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblOwnerTeam;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbOwnerTeam;
    }
}
