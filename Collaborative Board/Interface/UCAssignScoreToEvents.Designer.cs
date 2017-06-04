namespace GraphicInterface
{
    partial class UCAssignScoreToEvents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAssignScoreToEvents));
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAssignScoreToEvents = new System.Windows.Forms.Label();
            this.lblCreateWhiteboard = new System.Windows.Forms.Label();
            this.lblDeleteWhiteboard = new System.Windows.Forms.Label();
            this.lblAddElement = new System.Windows.Forms.Label();
            this.lblAddComment = new System.Windows.Forms.Label();
            this.lblMarkCommentAsSolved = new System.Windows.Forms.Label();
            this.numMarkCommentAsSolved = new System.Windows.Forms.NumericUpDown();
            this.numAddComment = new System.Windows.Forms.NumericUpDown();
            this.numAddElement = new System.Windows.Forms.NumericUpDown();
            this.numDeleteWhiteboard = new System.Windows.Forms.NumericUpDown();
            this.numCreateWhiteboard = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numMarkCommentAsSolved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAddComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAddElement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeleteWhiteboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCreateWhiteboard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Lime;
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(341, 397);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(99, 35);
            this.btnAccept.TabIndex = 19;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(476, 397);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 35);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblAssignScoreToEvents
            // 
            this.lblAssignScoreToEvents.AutoSize = true;
            this.lblAssignScoreToEvents.BackColor = System.Drawing.Color.Transparent;
            this.lblAssignScoreToEvents.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignScoreToEvents.Location = new System.Drawing.Point(212, 75);
            this.lblAssignScoreToEvents.Name = "lblAssignScoreToEvents";
            this.lblAssignScoreToEvents.Size = new System.Drawing.Size(303, 34);
            this.lblAssignScoreToEvents.TabIndex = 21;
            this.lblAssignScoreToEvents.Text = "Asignar puntaje a eventos";
            // 
            // lblCreateWhiteboard
            // 
            this.lblCreateWhiteboard.AutoSize = true;
            this.lblCreateWhiteboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateWhiteboard.Location = new System.Drawing.Point(169, 150);
            this.lblCreateWhiteboard.Name = "lblCreateWhiteboard";
            this.lblCreateWhiteboard.Size = new System.Drawing.Size(95, 16);
            this.lblCreateWhiteboard.TabIndex = 22;
            this.lblCreateWhiteboard.Text = "Crear pizarrón:";
            // 
            // lblDeleteWhiteboard
            // 
            this.lblDeleteWhiteboard.AutoSize = true;
            this.lblDeleteWhiteboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeleteWhiteboard.Location = new System.Drawing.Point(169, 200);
            this.lblDeleteWhiteboard.Name = "lblDeleteWhiteboard";
            this.lblDeleteWhiteboard.Size = new System.Drawing.Size(130, 16);
            this.lblDeleteWhiteboard.TabIndex = 23;
            this.lblDeleteWhiteboard.Text = "Eliminar un pizarrón: ";
            // 
            // lblAddElement
            // 
            this.lblAddElement.AutoSize = true;
            this.lblAddElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddElement.Location = new System.Drawing.Point(169, 250);
            this.lblAddElement.Name = "lblAddElement";
            this.lblAddElement.Size = new System.Drawing.Size(136, 16);
            this.lblAddElement.TabIndex = 24;
            this.lblAddElement.Text = "Agregar un elemento:";
            // 
            // lblAddComment
            // 
            this.lblAddComment.AutoSize = true;
            this.lblAddComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddComment.Location = new System.Drawing.Point(169, 300);
            this.lblAddComment.Name = "lblAddComment";
            this.lblAddComment.Size = new System.Drawing.Size(147, 16);
            this.lblAddComment.TabIndex = 25;
            this.lblAddComment.Text = "Agregar un comentario:";
            // 
            // lblMarkCommentAsSolved
            // 
            this.lblMarkCommentAsSolved.AutoSize = true;
            this.lblMarkCommentAsSolved.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarkCommentAsSolved.Location = new System.Drawing.Point(169, 350);
            this.lblMarkCommentAsSolved.Name = "lblMarkCommentAsSolved";
            this.lblMarkCommentAsSolved.Size = new System.Drawing.Size(211, 16);
            this.lblMarkCommentAsSolved.TabIndex = 26;
            this.lblMarkCommentAsSolved.Text = "Marcar comentario como resuelto:";
            // 
            // numMarkCommentAsSolved
            // 
            this.numMarkCommentAsSolved.Location = new System.Drawing.Point(402, 350);
            this.numMarkCommentAsSolved.Name = "numMarkCommentAsSolved";
            this.numMarkCommentAsSolved.Size = new System.Drawing.Size(120, 20);
            this.numMarkCommentAsSolved.TabIndex = 27;
            // 
            // numAddComment
            // 
            this.numAddComment.Location = new System.Drawing.Point(402, 300);
            this.numAddComment.Name = "numAddComment";
            this.numAddComment.Size = new System.Drawing.Size(120, 20);
            this.numAddComment.TabIndex = 28;
            // 
            // numAddElement
            // 
            this.numAddElement.Location = new System.Drawing.Point(402, 250);
            this.numAddElement.Name = "numAddElement";
            this.numAddElement.Size = new System.Drawing.Size(120, 20);
            this.numAddElement.TabIndex = 29;
            // 
            // numDeleteWhiteboard
            // 
            this.numDeleteWhiteboard.Location = new System.Drawing.Point(402, 195);
            this.numDeleteWhiteboard.Name = "numDeleteWhiteboard";
            this.numDeleteWhiteboard.Size = new System.Drawing.Size(120, 20);
            this.numDeleteWhiteboard.TabIndex = 30;
            // 
            // numCreateWhiteboard
            // 
            this.numCreateWhiteboard.Location = new System.Drawing.Point(402, 145);
            this.numCreateWhiteboard.Name = "numCreateWhiteboard";
            this.numCreateWhiteboard.Size = new System.Drawing.Size(120, 20);
            this.numCreateWhiteboard.TabIndex = 31;
            // 
            // UCAssignScoreToEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.numCreateWhiteboard);
            this.Controls.Add(this.numDeleteWhiteboard);
            this.Controls.Add(this.numAddElement);
            this.Controls.Add(this.numAddComment);
            this.Controls.Add(this.numMarkCommentAsSolved);
            this.Controls.Add(this.lblMarkCommentAsSolved);
            this.Controls.Add(this.lblAddComment);
            this.Controls.Add(this.lblAddElement);
            this.Controls.Add(this.lblDeleteWhiteboard);
            this.Controls.Add(this.lblCreateWhiteboard);
            this.Controls.Add(this.lblAssignScoreToEvents);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Name = "UCAssignScoreToEvents";
            this.Size = new System.Drawing.Size(747, 538);
            ((System.ComponentModel.ISupportInitialize)(this.numMarkCommentAsSolved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAddComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAddElement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeleteWhiteboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCreateWhiteboard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAssignScoreToEvents;
        private System.Windows.Forms.Label lblCreateWhiteboard;
        private System.Windows.Forms.Label lblDeleteWhiteboard;
        private System.Windows.Forms.Label lblAddElement;
        private System.Windows.Forms.Label lblAddComment;
        private System.Windows.Forms.Label lblMarkCommentAsSolved;
        private System.Windows.Forms.NumericUpDown numMarkCommentAsSolved;
        private System.Windows.Forms.NumericUpDown numAddComment;
        private System.Windows.Forms.NumericUpDown numAddElement;
        private System.Windows.Forms.NumericUpDown numDeleteWhiteboard;
        private System.Windows.Forms.NumericUpDown numCreateWhiteboard;
    }
}
