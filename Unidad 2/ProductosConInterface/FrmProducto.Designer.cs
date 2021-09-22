namespace ProductosConInterface
{
    partial class frmProductos
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstProductos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMedidaCantidad = new System.Windows.Forms.TextBox();
            this.lblMedidaCantidad = new System.Windows.Forms.Label();
            this.rbtSuelto = new System.Windows.Forms.RadioButton();
            this.rbtPack = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnTotal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstProductos
            // 
            this.lstProductos.FormattingEnabled = true;
            this.lstProductos.Location = new System.Drawing.Point(366, 18);
            this.lstProductos.Name = "lstProductos";
            this.lstProductos.Size = new System.Drawing.Size(219, 264);
            this.lstProductos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(107, 74);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(150, 20);
            this.txtCodigo.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(107, 133);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(249, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(107, 192);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(150, 20);
            this.txtPrecio.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Precio";
            // 
            // txtMedidaCantidad
            // 
            this.txtMedidaCantidad.Location = new System.Drawing.Point(107, 251);
            this.txtMedidaCantidad.Name = "txtMedidaCantidad";
            this.txtMedidaCantidad.Size = new System.Drawing.Size(150, 20);
            this.txtMedidaCantidad.TabIndex = 8;
            // 
            // lblMedidaCantidad
            // 
            this.lblMedidaCantidad.AutoSize = true;
            this.lblMedidaCantidad.Location = new System.Drawing.Point(25, 257);
            this.lblMedidaCantidad.Name = "lblMedidaCantidad";
            this.lblMedidaCantidad.Size = new System.Drawing.Size(42, 13);
            this.lblMedidaCantidad.TabIndex = 7;
            this.lblMedidaCantidad.Text = "Medida";
            // 
            // rbtSuelto
            // 
            this.rbtSuelto.AutoSize = true;
            this.rbtSuelto.Location = new System.Drawing.Point(107, 18);
            this.rbtSuelto.Name = "rbtSuelto";
            this.rbtSuelto.Size = new System.Drawing.Size(55, 17);
            this.rbtSuelto.TabIndex = 9;
            this.rbtSuelto.TabStop = true;
            this.rbtSuelto.Text = "Suelto";
            this.rbtSuelto.UseVisualStyleBackColor = true;
            this.rbtSuelto.CheckedChanged += new System.EventHandler(this.rbtSuelto_CheckedChanged);
            // 
            // rbtPack
            // 
            this.rbtPack.AutoSize = true;
            this.rbtPack.Location = new System.Drawing.Point(207, 18);
            this.rbtPack.Name = "rbtPack";
            this.rbtPack.Size = new System.Drawing.Size(50, 17);
            this.rbtPack.TabIndex = 10;
            this.rbtPack.TabStop = true;
            this.rbtPack.Text = "Pack";
            this.rbtPack.UseVisualStyleBackColor = true;
            this.rbtPack.CheckedChanged += new System.EventHandler(this.rbtPack_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tipo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(372, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Total : $";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(424, 309);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(161, 20);
            this.txtTotal.TabIndex = 13;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(30, 307);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(129, 23);
            this.btnCargar.TabIndex = 14;
            this.btnCargar.Text = "Cargar Producto";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnTotal
            // 
            this.btnTotal.Location = new System.Drawing.Point(227, 309);
            this.btnTotal.Name = "btnTotal";
            this.btnTotal.Size = new System.Drawing.Size(129, 23);
            this.btnTotal.TabIndex = 15;
            this.btnTotal.Text = "Mostrar Total";
            this.btnTotal.UseVisualStyleBackColor = true;
            this.btnTotal.Click += new System.EventHandler(this.btnTotal_Click);
            // 
            // frmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 348);
            this.Controls.Add(this.btnTotal);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rbtPack);
            this.Controls.Add(this.rbtSuelto);
            this.Controls.Add(this.txtMedidaCantidad);
            this.Controls.Add(this.lblMedidaCantidad);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstProductos);
            this.Name = "frmProductos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.frmProductos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMedidaCantidad;
        private System.Windows.Forms.Label lblMedidaCantidad;
        private System.Windows.Forms.RadioButton rbtSuelto;
        private System.Windows.Forms.RadioButton rbtPack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnTotal;
    }
}

