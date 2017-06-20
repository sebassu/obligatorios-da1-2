namespace GraphicInterface
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
            this.btnPrintPDF = new System.Windows.Forms.Button();
            this.btnAddText = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.pnlWhiteboard = new System.Windows.Forms.Panel();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlOptions.Controls.Add(this.btnPrintPng);
            this.pnlOptions.Controls.Add(this.btnPrintPDF);
            this.pnlOptions.Controls.Add(this.btnAddText);
            this.pnlOptions.Controls.Add(this.btnAddImage);
            this.pnlOptions.Location = new System.Drawing.Point(27, 12);
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
            this.btnPrintPng.Location = new System.Drawing.Point(8, 802);
            this.btnPrintPng.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnPrintPng.Name = "btnPrintPng";
            this.btnPrintPng.Size = new System.Drawing.Size(528, 219);
            this.btnPrintPng.TabIndex = 2;
            this.btnPrintPng.Text = "Imprimir en png";
            this.btnPrintPng.UseVisualStyleBackColor = false;
            this.btnPrintPng.Click += new System.EventHandler(this.BtnPrintPng_Click);
            // 
            // btnPrintPDF
            // 
            this.btnPrintPDF.BackColor = System.Drawing.Color.Navy;
            this.btnPrintPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintPDF.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPDF.ForeColor = System.Drawing.Color.White;
            this.btnPrintPDF.Location = new System.Drawing.Point(8, 1165);
            this.btnPrintPDF.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnPrintPDF.Name = "btnPrintPDF";
            this.btnPrintPDF.Size = new System.Drawing.Size(528, 219);
            this.btnPrintPDF.TabIndex = 1;
            this.btnPrintPDF.Text = "Imprimir en PDF";
            this.btnPrintPDF.UseVisualStyleBackColor = false;
            this.btnPrintPDF.Click += new System.EventHandler(this.BtnPrintPDF_Click);
            // 
            // btnAddText
            // 
            this.btnAddText.BackColor = System.Drawing.Color.Navy;
            this.btnAddText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddText.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddText.ForeColor = System.Drawing.Color.White;
            this.btnAddText.Location = new System.Drawing.Point(8, 436);
            this.btnAddText.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAddText.Name = "btnAddText";
            this.btnAddText.Size = new System.Drawing.Size(528, 219);
            this.btnAddText.TabIndex = 2;
            this.btnAddText.Text = "Agregar texto";
            this.btnAddText.UseVisualStyleBackColor = false;
            this.btnAddText.Click += new System.EventHandler(this.BtnAddText_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackColor = System.Drawing.Color.Navy;
            this.btnAddImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddImage.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.ForeColor = System.Drawing.Color.White;
            this.btnAddImage.Location = new System.Drawing.Point(8, 55);
            this.btnAddImage.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(528, 219);
            this.btnAddImage.TabIndex = 1;
            this.btnAddImage.Text = "Agregar imagen";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.BtnAddImage_Click);
            // 
            // pnlWhiteboard
            // 
            this.pnlWhiteboard.BackColor = System.Drawing.Color.LightGray;
            this.pnlWhiteboard.Location = new System.Drawing.Point(595, 12);
            this.pnlWhiteboard.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pnlWhiteboard.Name = "pnlWhiteboard";
            this.pnlWhiteboard.Size = new System.Drawing.Size(1785, 1445);
            this.pnlWhiteboard.TabIndex = 1;
            this.pnlWhiteboard.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlWhiteboard_Paint);
            // 
            // WhiteboardVisualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2397, 1484);
            this.Controls.Add(this.pnlWhiteboard);
            this.Controls.Add(this.pnlOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(2429, 1572);
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
        private System.Windows.Forms.Button btnPrintPDF;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnAddText;
        private System.Windows.Forms.Panel pnlWhiteboard;
    }
}

