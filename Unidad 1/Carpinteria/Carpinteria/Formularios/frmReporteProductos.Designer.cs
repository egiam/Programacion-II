
namespace Carpinteria.Formularios
{
    partial class frmReporteProductos
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsProductos1 = new Carpinteria.Reportes.DSProductos();
            this.t_PRODUCTOSTableAdapter1 = new Carpinteria.Reportes.DSProductosTableAdapters.T_PRODUCTOSTableAdapter();
            this.tableAdapterManager1 = new Carpinteria.Reportes.DSProductosTableAdapters.TableAdapterManager();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dsProductos1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsProductos1
            // 
            this.dsProductos1.DataSetName = "DSProductos";
            this.dsProductos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // t_PRODUCTOSTableAdapter1
            // 
            this.t_PRODUCTOSTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.T_PRODUCTOSTableAdapter = this.t_PRODUCTOSTableAdapter1;
            this.tableAdapterManager1.UpdateOrder = Carpinteria.Reportes.DSProductosTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // reportViewer2
            // 
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Carpinteria.Reportes.rptProductos.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(12, 121);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(776, 317);
            this.reportViewer2.TabIndex = 0;
            // 
            // frmReporteProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer2);
            this.Name = "frmReporteProductos";
            this.Text = "frmReporteProductos";
            this.Load += new System.EventHandler(this.frmReporteProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsProductos1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Reportes.DSProductos dsProductos1;
        private Reportes.DSProductosTableAdapters.T_PRODUCTOSTableAdapter t_PRODUCTOSTableAdapter1;
        private Reportes.DSProductosTableAdapters.TableAdapterManager tableAdapterManager1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}