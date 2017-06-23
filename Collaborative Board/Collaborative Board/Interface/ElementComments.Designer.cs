namespace GraphicInterface
{
    partial class ElementComments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElementComments));
            this.lblElementComments = new System.Windows.Forms.Label();
            this.lstComments = new System.Windows.Forms.ListView();
            this.comments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.rtbNewComment = new System.Windows.Forms.RichTextBox();
            this.btnSaveComment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblElementComments
            // 
            this.lblElementComments.AutoSize = true;
            this.lblElementComments.BackColor = System.Drawing.Color.Transparent;
            this.lblElementComments.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElementComments.Location = new System.Drawing.Point(120, 37);
            this.lblElementComments.Name = "lblElementComments";
            this.lblElementComments.Size = new System.Drawing.Size(293, 34);
            this.lblElementComments.TabIndex = 14;
            this.lblElementComments.Text = "Comentarios de elemento";
            // 
            // lstComments
            // 
            this.lstComments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.comments});
            this.lstComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstComments.Location = new System.Drawing.Point(33, 85);
            this.lstComments.MultiSelect = false;
            this.lstComments.Name = "lstComments";
            this.lstComments.Size = new System.Drawing.Size(466, 196);
            this.lstComments.TabIndex = 15;
            this.lstComments.TileSize = new System.Drawing.Size(466, 40);
            this.lstComments.UseCompatibleStateImageBehavior = false;
            this.lstComments.View = System.Windows.Forms.View.Tile;
            // 
            // comments
            // 
            this.comments.Width = 466;
            // 
            // btnSolve
            // 
            this.btnSolve.BackColor = System.Drawing.Color.Lime;
            this.btnSolve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolve.ForeColor = System.Drawing.Color.Black;
            this.btnSolve.Location = new System.Drawing.Point(523, 166);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(100, 43);
            this.btnSolve.TabIndex = 16;
            this.btnSolve.Text = "Resolver";
            this.btnSolve.UseVisualStyleBackColor = false;
            this.btnSolve.Click += new System.EventHandler(this.BtnSolve_Click);
            // 
            // btnAddComment
            // 
            this.btnAddComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddComment.Location = new System.Drawing.Point(33, 318);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(108, 50);
            this.btnAddComment.TabIndex = 17;
            this.btnAddComment.Text = "Agregar comentario";
            this.btnAddComment.UseVisualStyleBackColor = true;
            this.btnAddComment.Click += new System.EventHandler(this.BtnAddComment_Click);
            // 
            // rtbNewComment
            // 
            this.rtbNewComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNewComment.Location = new System.Drawing.Point(158, 300);
            this.rtbNewComment.Name = "rtbNewComment";
            this.rtbNewComment.Size = new System.Drawing.Size(364, 96);
            this.rtbNewComment.TabIndex = 18;
            this.rtbNewComment.Text = "";
            this.rtbNewComment.Visible = false;
            // 
            // btnSaveComment
            // 
            this.btnSaveComment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveComment.Location = new System.Drawing.Point(539, 318);
            this.btnSaveComment.Name = "btnSaveComment";
            this.btnSaveComment.Size = new System.Drawing.Size(108, 50);
            this.btnSaveComment.TabIndex = 19;
            this.btnSaveComment.Text = "Guardar comentario";
            this.btnSaveComment.UseVisualStyleBackColor = true;
            this.btnSaveComment.Visible = false;
            this.btnSaveComment.Click += new System.EventHandler(this.BtnSaveComment_Click);
            // 
            // ElementComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(676, 447);
            this.Controls.Add(this.btnSaveComment);
            this.Controls.Add(this.rtbNewComment);
            this.Controls.Add(this.btnAddComment);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.lstComments);
            this.Controls.Add(this.lblElementComments);
            this.Name = "ElementComments";
            this.Text = "Comentarios de elemento";
            this.Load += new System.EventHandler(this.ElementComments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblElementComments;
        private System.Windows.Forms.ListView lstComments;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.RichTextBox rtbNewComment;
        private System.Windows.Forms.Button btnSaveComment;
        private System.Windows.Forms.ColumnHeader comments;
    }
}