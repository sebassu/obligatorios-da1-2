namespace GraphicInterface
{
    partial class Association
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Association));
            this.lblAssociation = new System.Windows.Forms.Label();
            this.btnFinalize = new System.Windows.Forms.Button();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.rbnDirect = new System.Windows.Forms.RadioButton();
            this.gbxRadioButtons = new System.Windows.Forms.GroupBox();
            this.rbnInverse = new System.Windows.Forms.RadioButton();
            this.rbnBidirectional = new System.Windows.Forms.RadioButton();
            this.rbnNoDirection = new System.Windows.Forms.RadioButton();
            this.gbxRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAssociation
            // 
            this.lblAssociation.AutoSize = true;
            this.lblAssociation.BackColor = System.Drawing.Color.Transparent;
            this.lblAssociation.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssociation.Location = new System.Drawing.Point(236, 37);
            this.lblAssociation.Name = "lblAssociation";
            this.lblAssociation.Size = new System.Drawing.Size(207, 34);
            this.lblAssociation.TabIndex = 15;
            this.lblAssociation.Text = "Agregar conexión";
            // 
            // btnFinalize
            // 
            this.btnFinalize.BackColor = System.Drawing.Color.Lime;
            this.btnFinalize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalize.ForeColor = System.Drawing.Color.Black;
            this.btnFinalize.Location = new System.Drawing.Point(303, 346);
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(100, 43);
            this.btnFinalize.TabIndex = 17;
            this.btnFinalize.Text = "Finalizar";
            this.btnFinalize.UseVisualStyleBackColor = false;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(133, 93);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(66, 18);
            this.lblFirstName.TabIndex = 18;
            this.lblFirstName.Text = "Nombre:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(271, 93);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(172, 20);
            this.txtName.TabIndex = 19;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(133, 132);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(91, 18);
            this.lblDescription.TabIndex = 20;
            this.lblDescription.Text = "Descripción:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(271, 140);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(222, 80);
            this.rtbDescription.TabIndex = 21;
            this.rtbDescription.Text = "";
            // 
            // rbnDirect
            // 
            this.rbnDirect.AutoSize = true;
            this.rbnDirect.Location = new System.Drawing.Point(135, 23);
            this.rbnDirect.Name = "rbnDirect";
            this.rbnDirect.Size = new System.Drawing.Size(73, 22);
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
            this.gbxRadioButtons.Location = new System.Drawing.Point(136, 240);
            this.gbxRadioButtons.Name = "gbxRadioButtons";
            this.gbxRadioButtons.Size = new System.Drawing.Size(475, 100);
            this.gbxRadioButtons.TabIndex = 24;
            this.gbxRadioButtons.TabStop = false;
            this.gbxRadioButtons.Text = "Direccionalidad";
            // 
            // rbnInverse
            // 
            this.rbnInverse.AutoSize = true;
            this.rbnInverse.Location = new System.Drawing.Point(135, 52);
            this.rbnInverse.Name = "rbnInverse";
            this.rbnInverse.Size = new System.Drawing.Size(73, 22);
            this.rbnInverse.TabIndex = 24;
            this.rbnInverse.TabStop = true;
            this.rbnInverse.Text = "Inversa";
            this.rbnInverse.UseVisualStyleBackColor = true;
            // 
            // rbnBidirectional
            // 
            this.rbnBidirectional.AutoSize = true;
            this.rbnBidirectional.Location = new System.Drawing.Point(320, 23);
            this.rbnBidirectional.Name = "rbnBidirectional";
            this.rbnBidirectional.Size = new System.Drawing.Size(110, 22);
            this.rbnBidirectional.TabIndex = 25;
            this.rbnBidirectional.TabStop = true;
            this.rbnBidirectional.Text = "Bidireccional";
            this.rbnBidirectional.UseVisualStyleBackColor = true;
            // 
            // rbnNoDirection
            // 
            this.rbnNoDirection.AutoSize = true;
            this.rbnNoDirection.Location = new System.Drawing.Point(320, 56);
            this.rbnNoDirection.Name = "rbnNoDirection";
            this.rbnNoDirection.Size = new System.Drawing.Size(148, 22);
            this.rbnNoDirection.TabIndex = 26;
            this.rbnNoDirection.TabStop = true;
            this.rbnNoDirection.Text = "SinDireccionalidad";
            this.rbnNoDirection.UseVisualStyleBackColor = true;
            // 
            // Association
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(676, 447);
            this.Controls.Add(this.gbxRadioButtons);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.btnFinalize);
            this.Controls.Add(this.lblAssociation);
            this.Name = "Association";
            this.Text = "Asociación";
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