namespace Interface
{
    partial class UCWhiteboards
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCWhiteboards));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.lstRegisteredWhiteboards = new System.Windows.Forms.ListView();
            this.lblRegisteredWhiteboards = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Yellow;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(920, 324);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(472, 217);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "AGREGAR";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseEnter += new System.EventHandler(this.btnAdd_MouseEnter);
            this.btnAdd.MouseLeave += new System.EventHandler(this.btnAdd_MouseLeave);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.Yellow;
            this.btnModify.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.ForeColor = System.Drawing.Color.White;
            this.btnModify.Location = new System.Drawing.Point(1432, 324);
            this.btnModify.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(472, 217);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "MODIFICAR";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            this.btnModify.MouseEnter += new System.EventHandler(this.btnModify_MouseEnter);
            this.btnModify.MouseLeave += new System.EventHandler(this.btnModify_MouseLeave);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Yellow;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(920, 646);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(472, 217);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "ELIMINAR";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.MouseEnter += new System.EventHandler(this.btnDelete_MouseEnter);
            this.btnDelete.MouseLeave += new System.EventHandler(this.btnDelete_MouseLeave);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.Yellow;
            this.btnView.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(1432, 646);
            this.btnView.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(472, 217);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "VISUALIZAR";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.MouseEnter += new System.EventHandler(this.btnView_MouseEnter);
            this.btnView.MouseLeave += new System.EventHandler(this.btnView_MouseLeave);
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Location = new System.Drawing.Point(112, 69);
            this.btnHome.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(213, 148);
            this.btnHome.TabIndex = 4;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnHome.MouseEnter += new System.EventHandler(this.btnHome_MouseEnter);
            this.btnHome.MouseLeave += new System.EventHandler(this.btnHome_MouseLeave);
            // 
            // lstRegisteredWhiteboards
            // 
            this.lstRegisteredWhiteboards.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRegisteredWhiteboards.Location = new System.Drawing.Point(80, 370);
            this.lstRegisteredWhiteboards.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lstRegisteredWhiteboards.MultiSelect = false;
            this.lstRegisteredWhiteboards.Name = "lstRegisteredWhiteboards";
            this.lstRegisteredWhiteboards.Size = new System.Drawing.Size(791, 812);
            this.lstRegisteredWhiteboards.TabIndex = 5;
            this.lstRegisteredWhiteboards.UseCompatibleStateImageBehavior = false;
            this.lstRegisteredWhiteboards.View = System.Windows.Forms.View.Details;
            // 
            // lblRegisteredWhiteboards
            // 
            this.lblRegisteredWhiteboards.AutoSize = true;
            this.lblRegisteredWhiteboards.BackColor = System.Drawing.Color.Transparent;
            this.lblRegisteredWhiteboards.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisteredWhiteboards.Location = new System.Drawing.Point(147, 248);
            this.lblRegisteredWhiteboards.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblRegisteredWhiteboards.Name = "lblRegisteredWhiteboards";
            this.lblRegisteredWhiteboards.Size = new System.Drawing.Size(658, 87);
            this.lblRegisteredWhiteboards.TabIndex = 6;
            this.lblRegisteredWhiteboards.Text = "Pizarrones registrados";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(1691, 1040);
            this.btnExit.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(213, 148);
            this.btnExit.TabIndex = 7;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // UCWhiteboards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblRegisteredWhiteboards);
            this.Controls.Add(this.lstRegisteredWhiteboards);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "UCWhiteboards";
            this.Size = new System.Drawing.Size(1992, 1283);
            this.Load += new System.EventHandler(this.UCWhiteboards_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.ListView lstRegisteredWhiteboards;
        private System.Windows.Forms.Label lblRegisteredWhiteboards;
        private System.Windows.Forms.Button btnExit;
    }
}
