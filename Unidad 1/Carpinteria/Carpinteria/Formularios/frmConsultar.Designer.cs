
namespace Carpinteria.Formularios
{
    partial class frmConsultar
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
            this.lblNroPresupuesto = new System.Windows.Forms.Label();
            this.grdConsultar = new System.Windows.Forms.DataGridView();
            this.cNumeroPres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdDetalles = new System.Windows.Forms.DataGridView();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBorrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdConsultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNroPresupuesto
            // 
            this.lblNroPresupuesto.AutoSize = true;
            this.lblNroPresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroPresupuesto.Location = new System.Drawing.Point(366, 42);
            this.lblNroPresupuesto.Name = "lblNroPresupuesto";
            this.lblNroPresupuesto.Size = new System.Drawing.Size(190, 17);
            this.lblNroPresupuesto.TabIndex = 1;
            this.lblNroPresupuesto.Text = "Consulta de Presupuesto";
            // 
            // grdConsultar
            // 
            this.grdConsultar.AllowUserToAddRows = false;
            this.grdConsultar.AllowUserToDeleteRows = false;
            this.grdConsultar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdConsultar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNumeroPres,
            this.cCliente,
            this.cFecha,
            this.cDescuento,
            this.cTotal});
            this.grdConsultar.Location = new System.Drawing.Point(12, 88);
            this.grdConsultar.Name = "grdConsultar";
            this.grdConsultar.ReadOnly = true;
            this.grdConsultar.Size = new System.Drawing.Size(544, 350);
            this.grdConsultar.TabIndex = 2;
            // 
            // cNumeroPres
            // 
            this.cNumeroPres.HeaderText = "Numero de Presupuesto";
            this.cNumeroPres.Name = "cNumeroPres";
            this.cNumeroPres.ReadOnly = true;
            // 
            // cCliente
            // 
            this.cCliente.HeaderText = "Cliente";
            this.cCliente.Name = "cCliente";
            this.cCliente.ReadOnly = true;
            // 
            // cFecha
            // 
            this.cFecha.HeaderText = "Fecha";
            this.cFecha.Name = "cFecha";
            this.cFecha.ReadOnly = true;
            // 
            // cDescuento
            // 
            this.cDescuento.HeaderText = "Descuento";
            this.cDescuento.Name = "cDescuento";
            this.cDescuento.ReadOnly = true;
            // 
            // cTotal
            // 
            this.cTotal.HeaderText = "Total";
            this.cTotal.Name = "cTotal";
            this.cTotal.ReadOnly = true;
            // 
            // grdDetalles
            // 
            this.grdDetalles.AllowUserToAddRows = false;
            this.grdDetalles.AllowUserToDeleteRows = false;
            this.grdDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cProducto,
            this.cPrecio,
            this.cCantidad});
            this.grdDetalles.Location = new System.Drawing.Point(566, 88);
            this.grdDetalles.Name = "grdDetalles";
            this.grdDetalles.ReadOnly = true;
            this.grdDetalles.Size = new System.Drawing.Size(343, 350);
            this.grdDetalles.TabIndex = 3;
            // 
            // cProducto
            // 
            this.cProducto.HeaderText = "Producto";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            // 
            // cPrecio
            // 
            this.cPrecio.HeaderText = "Precio";
            this.cPrecio.Name = "cPrecio";
            this.cPrecio.ReadOnly = true;
            // 
            // cCantidad
            // 
            this.cCantidad.HeaderText = "Cantidad";
            this.cCantidad.Name = "cCantidad";
            this.cCantidad.ReadOnly = true;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(454, 477);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(102, 23);
            this.btnBorrar.TabIndex = 4;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // frmConsultar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 524);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.grdDetalles);
            this.Controls.Add(this.grdConsultar);
            this.Controls.Add(this.lblNroPresupuesto);
            this.Name = "frmConsultar";
            this.Text = "frmConsultar";
            this.Load += new System.EventHandler(this.frmConsultar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdConsultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNroPresupuesto;
        private System.Windows.Forms.DataGridView grdConsultar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNumeroPres;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTotal;
        private System.Windows.Forms.DataGridView grdDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCantidad;
        private System.Windows.Forms.Button btnBorrar;
    }
}