namespace Interface
{
    partial class SelectInform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectInform));
            this.btnWhiteboardsCreatedByTeam = new System.Windows.Forms.Button();
            this.btnCommentsSolvedByUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWhiteboardsCreatedByTeam
            // 
            this.btnWhiteboardsCreatedByTeam.BackColor = System.Drawing.Color.DarkBlue;
            this.btnWhiteboardsCreatedByTeam.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWhiteboardsCreatedByTeam.ForeColor = System.Drawing.Color.White;
            this.btnWhiteboardsCreatedByTeam.Location = new System.Drawing.Point(29, 57);
            this.btnWhiteboardsCreatedByTeam.Name = "btnWhiteboardsCreatedByTeam";
            this.btnWhiteboardsCreatedByTeam.Size = new System.Drawing.Size(217, 89);
            this.btnWhiteboardsCreatedByTeam.TabIndex = 0;
            this.btnWhiteboardsCreatedByTeam.Text = "Pizarrones creados por equipo";
            this.btnWhiteboardsCreatedByTeam.UseVisualStyleBackColor = false;
            this.btnWhiteboardsCreatedByTeam.Click += new System.EventHandler(this.btnWhiteboardsCreatedByTeam_Click);
            // 
            // btnCommentsSolvedByUser
            // 
            this.btnCommentsSolvedByUser.BackColor = System.Drawing.Color.DarkBlue;
            this.btnCommentsSolvedByUser.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommentsSolvedByUser.ForeColor = System.Drawing.Color.White;
            this.btnCommentsSolvedByUser.Location = new System.Drawing.Point(271, 57);
            this.btnCommentsSolvedByUser.Name = "btnCommentsSolvedByUser";
            this.btnCommentsSolvedByUser.Size = new System.Drawing.Size(217, 89);
            this.btnCommentsSolvedByUser.TabIndex = 1;
            this.btnCommentsSolvedByUser.Text = "Comentarios resueltos por usuario";
            this.btnCommentsSolvedByUser.UseVisualStyleBackColor = false;
            this.btnCommentsSolvedByUser.Click += new System.EventHandler(this.btnCommentsSolvedByUser_Click);
            // 
            // SelectInform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(518, 220);
            this.Controls.Add(this.btnCommentsSolvedByUser);
            this.Controls.Add(this.btnWhiteboardsCreatedByTeam);
            this.Name = "SelectInform";
            this.Text = "Seleccione informe deseado";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectInform_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWhiteboardsCreatedByTeam;
        private System.Windows.Forms.Button btnCommentsSolvedByUser;
    }
}