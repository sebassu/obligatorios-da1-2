namespace GraphicInterface
{
    partial class ConnectionRegistration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionRegistration));
            this.lblAssociation = new System.Windows.Forms.Label();
            this.btnFinalize = new System.Windows.Forms.Button();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.rbnDirect = new System.Windows.Forms.RadioButton();
            this.gbxRadioButtons = new System.Windows.Forms.GroupBox();
            this.rbnNoDirection = new System.Windows.Forms.RadioButton();
            this.rbnBidirectional = new System.Windows.Forms.RadioButton();
            this.rbnInverse = new System.Windows.Forms.RadioButton();
            this.gbxRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAssociation
            // 
            this.lblAssociation.AutoSize = true;
            this.lblAssociation.BackColor = System.Drawing.Color.Transparent;
            this.lblAssociation.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssociation.Location = new System.Drawing.Point(520, 78);
            this.lblAssociation.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblAssociation.Name = "lblAssociation";
            this.lblAssociation.Size = new System.Drawing.Size(526, 87);
            this.lblAssociation.TabIndex = 15;
            this.lblAssociation.Text = "Agregar conexión";
            // 
            // btnFinalize
            // 
            this.btnFinalize.BackColor = System.Drawing.Color.Lime;
            this.btnFinalize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalize.ForeColor = System.Drawing.Color.Black;
            this.btnFinalize.Location = new System.Drawing.Point(699, 815);
            this.btnFinalize.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(267, 103);
            this.btnFinalize.TabIndex = 17;
            this.btnFinalize.Text = "Finalizar";
            this.btnFinalize.UseVisualStyleBackColor = false;
            this.btnFinalize.Click += new System.EventHandler(this.BtnFinalize_Click);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(246, 212);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(167, 44);
            this.lblFirstName.TabIndex = 18;
            this.lblFirstName.Text = "Nombre:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(614, 212);
            this.txtName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(452, 38);
            this.txtName.TabIndex = 19;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(246, 305);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(230, 44);
            this.lblDescription.TabIndex = 20;
            this.lblDescription.Text = "Descripción:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(614, 324);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(585, 185);
            this.rtbDescription.TabIndex = 21;
            this.rtbDescription.Text = "";
            // 
            // rbnDirect
            // 
            this.rbnDirect.AutoSize = true;
            this.rbnDirect.Location = new System.Drawing.Point(360, 55);
            this.rbnDirect.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rbnDirect.Name = "rbnDirect";
            this.rbnDirect.Size = new System.Drawing.Size(178, 48);
            this.rbnDirect.TabIndex = 23;
            this.rbnDirect.TabStop = true;
            this.rbnDirect.Text = "Directa";
            this.rbnDirect.UseVisualStyleBackColor = true;
            // 
            // gbxRadioButtons
            // 
            this.gbxRadioButtons.BackColor = System.Drawing.Color.Transparent;
            this.gbxRadioButtons.Controls.Add(this.rbnNoDirection);
            this.gbxRadioButtons.Controls.Add(this.rbnBidirectional);
            this.gbxRadioButtons.Controls.Add(this.rbnInverse);
            this.gbxRadioButtons.Controls.Add(this.rbnDirect);
            this.gbxRadioButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.gbxRadioButtons.Location = new System.Drawing.Point(254, 562);
            this.gbxRadioButtons.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbxRadioButtons.Name = "gbxRadioButtons";
            this.gbxRadioButtons.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbxRadioButtons.Size = new System.Drawing.Size(1267, 238);
            this.gbxRadioButtons.TabIndex = 24;
            this.gbxRadioButtons.TabStop = false;
            this.gbxRadioButtons.Text = "Direccionalidad";
            // 
            // rbnNoDirection
            // 
            this.rbnNoDirection.AutoSize = true;
            this.rbnNoDirection.Location = new System.Drawing.Point(853, 134);
            this.rbnNoDirection.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rbnNoDirection.Name = "rbnNoDirection";
            this.rbnNoDirection.Size = new System.Drawing.Size(383, 48);
            this.rbnNoDirection.TabIndex = 26;
            this.rbnNoDirection.TabStop = true;
            this.rbnNoDirection.Text = "Sin Direccionalidad";
            this.rbnNoDirection.UseVisualStyleBackColor = true;
            // 
            // rbnBidirectional
            // 
            this.rbnBidirectional.AutoSize = true;
            this.rbnBidirectional.Location = new System.Drawing.Point(853, 55);
            this.rbnBidirectional.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rbnBidirectional.Name = "rbnBidirectional";
            this.rbnBidirectional.Size = new System.Drawing.Size(274, 48);
            this.rbnBidirectional.TabIndex = 25;
            this.rbnBidirectional.TabStop = true;
            this.rbnBidirectional.Text = "Bidireccional";
            this.rbnBidirectional.UseVisualStyleBackColor = true;
            // 
            // rbnInverse
            // 
            this.rbnInverse.AutoSize = true;
            this.rbnInverse.Location = new System.Drawing.Point(360, 124);
            this.rbnInverse.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rbnInverse.Name = "rbnInverse";
            this.rbnInverse.Size = new System.Drawing.Size(181, 48);
            this.rbnInverse.TabIndex = 24;
            this.rbnInverse.TabStop = true;
            this.rbnInverse.Text = "Inversa";
            this.rbnInverse.UseVisualStyleBackColor = true;
            // 
            // ConnectionRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1821, 1196);
            this.Controls.Add(this.gbxRadioButtons);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.btnFinalize);
            this.Controls.Add(this.lblAssociation);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.Name = "ConnectionRegistration";
            this.Text = "Agregar conexión";
            this.TopMost = true;
            this.gbxRadioButtons.ResumeLayout(false);
            this.gbxRadioButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAssociation;
        private System.Windows.Forms.Button btnFinalize;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.RadioButton rbnDirect;
        private System.Windows.Forms.GroupBox gbxRadioButtons;
        private System.Windows.Forms.RadioButton rbnNoDirection;
        private System.Windows.Forms.RadioButton rbnBidirectional;
        private System.Windows.Forms.RadioButton rbnInverse;
    }
}