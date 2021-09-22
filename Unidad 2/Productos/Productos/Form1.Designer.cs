
namespace Productos
{
    partial class frmProductos
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
            this.lstProductos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMedidaCantidad = new System.Windows.Forms.TextBox();
            this.lblMedidaCantidad = new System.Windows.Forms.Label();
            this.rbtSuelto = new System.Windows.Forms.RadioButton();
            this.rbtPack = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnCargarProd = new System.Windows.Forms.Button();
            this.btnMostrarTotal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstProductos
            // 
            this.lstProductos.FormattingEnabled = true;
            this.lstProductos.Location = new System.Drawing.Point(385, 12);
            this.lstProductos.Name = "lstProductos";
            this.lstProductos.Size = new System.Drawing.Size(305, 277);
            this.lstProductos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(123, 82);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(156, 20);
            this.txtCodigo.TabIndex = 2;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(123, 162);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(156, 20);
            this.txtPrecio.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Precio";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(123, 123);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(156, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre";
            // 
            // txtMedidaCantidad
            // 
            this.txtMedidaCantidad.Location = new System.Drawing.Point(123, 200);
            this.txtMedidaCantidad.Name = "txtMedidaCantidad";
            this.txtMedidaCantidad.Size = new System.Drawing.Size(156, 20);
            this.txtMedidaCantidad.TabIndex = 8;
            // 
            // lblMedidaCantidad
            // 
            this.lblMedidaCantidad.AutoSize = true;
            this.lblMedidaCantidad.Location = new System.Drawing.Point(24, 207);
            this.lblMedidaCantidad.Name = "lblMedidaCantidad";
            this.lblMedidaCantidad.Size = new System.Drawing.Size(42, 13);
            this.lblMedidaCantidad.TabIndex = 7;
            this.lblMedidaCantidad.Text = "Medida";
            // 
            // rbtSuelto
            // 
            this.rbtSuelto.AutoSize = true;
            this.rbtSuelto.Location = new System.Drawing.Point(123, 48);
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
            this.rbtPack.Location = new System.Drawing.Point(229, 48);
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
            this.label5.Location = new System.Drawing.Point(38, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tipo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Total:     $";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(443, 308);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(156, 20);
            this.txtTotal.TabIndex = 13;
            // 
            // btnCargarProd
            // 
            this.btnCargarProd.Location = new System.Drawing.Point(219, 381);
            this.btnCargarProd.Name = "btnCargarProd";
            this.btnCargarProd.Size = new System.Drawing.Size(129, 23);
            this.btnCargarProd.TabIndex = 14;
            this.btnCargarProd.Text = "Cargar Producto";
            this.btnCargarProd.UseVisualStyleBackColor = true;
            this.btnCargarProd.Click += new System.EventHandler(this.btnCargarProd_Click);
            // 
            // btnMostrarTotal
            // 
            this.btnMostrarTotal.Location = new System.Drawing.Point(374, 381);
            this.btnMostrarTotal.Name = "btnMostrarTotal";
            this.btnMostrarTotal.Size = new System.Drawing.Size(128, 23);
            this.btnMostrarTotal.TabIndex = 15;
            this.btnMostrarTotal.Text = "Mostrar Total";
            this.btnMostrarTotal.UseVisualStyleBackColor = true;
            this.btnMostrarTotal.Click += new System.EventHandler(this.btnMostrarTotal_Click);
            // 
            // frmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMostrarTotal);
            this.Controls.Add(this.btnCargarProd);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rbtPack);
            this.Controls.Add(this.rbtSuelto);
            this.Controls.Add(this.txtMedidaCantidad);
            this.Controls.Add(this.lblMedidaCantidad);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrecio);
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
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMedidaCantidad;
        private System.Windows.Forms.Label lblMedidaCantidad;
        private System.Windows.Forms.RadioButton rbtSuelto;
        private System.Windows.Forms.RadioButton rbtPack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnCargarProd;
        private System.Windows.Forms.Button btnMostrarTotal;
    }
}

