namespace Interface
{
    partial class WhiteboardVisualization
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
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.btnPrintPng = new System.Windows.Forms.Button();
            this.btnDeleteElement = new System.Windows.Forms.Button();
            this.btnPrintPDF = new System.Windows.Forms.Button();
            this.btnModifyElement = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnAddText = new System.Windows.Forms.Button();
            this.pnlWhiteboard = new System.Windows.Forms.Panel();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlOptions.Controls.Add(this.btnPrintPng);
            this.pnlOptions.Controls.Add(this.btnDeleteElement);
            this.pnlOptions.Controls.Add(this.btnPrintPDF);
            this.pnlOptions.Controls.Add(this.btnModifyElement);
            this.pnlOptions.Controls.Add(this.btnAddImage);
            this.pnlOptions.Controls.Add(this.btnAddText);
            this.pnlOptions.Location = new System.Drawing.Point(26, 13);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(552, 1445);
            this.pnlOptions.TabIndex = 0;
            // 
            // btnPrintPng
            // 
            this.btnPrintPng.BackColor = System.Drawing.Color.Navy;
            this.btnPrintPng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintPng.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPng.ForeColor = System.Drawing.Color.White;
            this.btnPrintPng.Location = new System.Drawing.Point(8, 1228);
            this.btnPrintPng.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnPrintPng.Name = "btnPrintPng";
            this.btnPrintPng.Size = new System.Drawing.Size(528, 155);
            this.btnPrintPng.TabIndex = 2;
            this.btnPrintPng.Text = "Imprimir en png";
            this.btnPrintPng.UseVisualStyleBackColor = false;
            // 
            // btnDeleteElement
            // 
            this.btnDeleteElement.BackColor = System.Drawing.Color.Navy;
            this.btnDeleteElement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteElement.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteElement.ForeColor = System.Drawing.Color.White;
            this.btnDeleteElement.Location = new System.Drawing.Point(8, 751);
            this.btnDeleteElement.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnDeleteElement.Name = "btnDeleteElement";
            this.btnDeleteElement.Size = new System.Drawing.Size(528, 155);
            this.btnDeleteElement.TabIndex = 1;
            this.btnDeleteElement.Text = "Eliminar elemento";
            this.btnDeleteElement.UseVisualStyleBackColor = false;
            // 
            // btnPrintPDF
            // 
            this.btnPrintPDF.BackColor = System.Drawing.Color.Navy;
            this.btnPrintPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintPDF.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPDF.ForeColor = System.Drawing.Color.White;
            this.btnPrintPDF.Location = new System.Drawing.Point(8, 990);
            this.btnPrintPDF.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnPrintPDF.Name = "btnPrintPDF";
            this.btnPrintPDF.Size = new System.Drawing.Size(528, 155);
            this.btnPrintPDF.TabIndex = 1;
            this.btnPrintPDF.Text = "Imprimir en PDF";
            this.btnPrintPDF.UseVisualStyleBackColor = false;
            // 
            // btnModifyElement
            // 
            this.btnModifyElement.BackColor = System.Drawing.Color.Navy;
            this.btnModifyElement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModifyElement.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyElement.ForeColor = System.Drawing.Color.White;
            this.btnModifyElement.Location = new System.Drawing.Point(8, 513);
            this.btnModifyElement.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnModifyElement.Name = "btnModifyElement";
            this.btnModifyElement.Size = new System.Drawing.Size(528, 155);
            this.btnModifyElement.TabIndex = 3;
            this.btnModifyElement.Text = "Ver comentarios de elemento";
            this.btnModifyElement.UseVisualStyleBackColor = false;
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackColor = System.Drawing.Color.Navy;
            this.btnAddImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddImage.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.ForeColor = System.Drawing.Color.White;
            this.btnAddImage.Location = new System.Drawing.Point(8, 36);
            this.btnAddImage.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(528, 155);
            this.btnAddImage.TabIndex = 1;
            this.btnAddImage.Text = "Agregar imagen";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.BtnAddImage_Click);
            // 
            // btnAddText
            // 
            this.btnAddText.BackColor = System.Drawing.Color.Navy;
            this.btnAddText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddText.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddText.ForeColor = System.Drawing.Color.White;
            this.btnAddText.Location = new System.Drawing.Point(8, 274);
            this.btnAddText.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAddText.Name = "btnAddText";
            this.btnAddText.Size = new System.Drawing.Size(528, 155);
            this.btnAddText.TabIndex = 2;
            this.btnAddText.Text = "Agregar texto";
            this.btnAddText.UseVisualStyleBackColor = false;
            this.btnAddText.Click += new System.EventHandler(this.BtnAddText_Click);
            // 
            // pnlWhiteboard
            // 
            this.pnlWhiteboard.BackColor = System.Drawing.Color.White;
            this.pnlWhiteboard.Location = new System.Drawing.Point(594, 13);
            this.pnlWhiteboard.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pnlWhiteboard.Name = "pnlWhiteboard";
            this.pnlWhiteboard.Size = new System.Drawing.Size(1909, 1445);
            this.pnlWhiteboard.TabIndex = 1;
            // 
            // WhiteboardVisualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2520, 1474);
            this.Controls.Add(this.pnlWhiteboard);
            this.Controls.Add(this.pnlOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2552, 1562);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(2552, 1562);
            this.Name = "WhiteboardVisualization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Whiteboard";
            this.TopMost = true;
            this.pnlOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Button btnPrintPng;
        private System.Windows.Forms.Button btnDeleteElement;
        private System.Windows.Forms.Button btnPrintPDF;
        private System.Windows.Forms.Button btnModifyElement;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnAddText;
        private System.Windows.Forms.Panel pnlWhiteboard;
    }
}

