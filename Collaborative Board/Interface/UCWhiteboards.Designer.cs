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
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(335, 136);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(191, 91);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "AGREGAR";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.btnAdd.MouseEnter += new System.EventHandler(this.BtnAdd_MouseEnter);
            this.btnAdd.MouseLeave += new System.EventHandler(this.BtnAdd_MouseLeave);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.Yellow;
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModify.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.ForeColor = System.Drawing.Color.White;
            this.btnModify.Location = new System.Drawing.Point(532, 136);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(196, 91);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "MODIFICAR";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.BtnModify_Click);
            this.btnModify.MouseEnter += new System.EventHandler(this.BtnModify_MouseEnter);
            this.btnModify.MouseLeave += new System.EventHandler(this.BtnModify_MouseLeave);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Yellow;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(335, 271);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(191, 91);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "ELIMINAR";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            this.btnDelete.MouseEnter += new System.EventHandler(this.BtnDelete_MouseEnter);
            this.btnDelete.MouseLeave += new System.EventHandler(this.BtnDelete_MouseLeave);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.Yellow;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(532, 271);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(196, 91);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "VISUALIZAR";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            this.btnView.MouseEnter += new System.EventHandler(this.BtnView_MouseEnter);
            this.btnView.MouseLeave += new System.EventHandler(this.BtnView_MouseLeave);
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Location = new System.Drawing.Point(42, 29);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(80, 62);
            this.btnHome.TabIndex = 4;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.BtnHome_Click);
            this.btnHome.MouseEnter += new System.EventHandler(this.BtnHome_MouseEnter);
            this.btnHome.MouseLeave += new System.EventHandler(this.BtnHome_MouseLeave);
            // 
            // lstRegisteredWhiteboards
            // 
            this.lstRegisteredWhiteboards.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRegisteredWhiteboards.Location = new System.Drawing.Point(30, 155);
            this.lstRegisteredWhiteboards.MultiSelect = false;
            this.lstRegisteredWhiteboards.Name = "lstRegisteredWhiteboards";
            this.lstRegisteredWhiteboards.Size = new System.Drawing.Size(299, 343);
            this.lstRegisteredWhiteboards.TabIndex = 5;
            this.lstRegisteredWhiteboards.TileSize = new System.Drawing.Size(299, 36);
            this.lstRegisteredWhiteboards.UseCompatibleStateImageBehavior = false;
            this.lstRegisteredWhiteboards.View = System.Windows.Forms.View.Tile;
            // 
            // lblRegisteredWhiteboards
            // 
            this.lblRegisteredWhiteboards.AutoSize = true;
            this.lblRegisteredWhiteboards.BackColor = System.Drawing.Color.Transparent;
            this.lblRegisteredWhiteboards.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisteredWhiteboards.Location = new System.Drawing.Point(55, 104);
            this.lblRegisteredWhiteboards.Name = "lblRegisteredWhiteboards";
            this.lblRegisteredWhiteboards.Size = new System.Drawing.Size(261, 34);
            this.lblRegisteredWhiteboards.TabIndex = 6;
            this.lblRegisteredWhiteboards.Text = "Pizarrones registrados";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(634, 436);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 62);
            this.btnExit.TabIndex = 7;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // UCWhiteboards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
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
            this.Name = "UCWhiteboards";
            this.Size = new System.Drawing.Size(747, 538);
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
