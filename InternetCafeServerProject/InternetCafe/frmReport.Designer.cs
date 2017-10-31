namespace InternetCafe
{
    partial class frmReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cyberDataSet = new InternetCafe.CyberDataSet();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbStaffTableAdapter1 = new InternetCafe.CyberDataSetTableAdapters.tbStaffTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cyberDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "tbStaff";
            this.bindingSource1.DataSource = this.cyberDataSet;
            // 
            // cyberDataSet
            // 
            this.cyberDataSet.DataSetName = "CyberDataSet";
            this.cyberDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.bindingSource1;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "InternetCafe.Report2.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(1019, 370);
            this.reportViewer2.TabIndex = 0;
            // 
            // tbStaffTableAdapter1
            // 
            this.tbStaffTableAdapter1.ClearBeforeFill = true;
            // 
            // frmReport
            // 
            this.ClientSize = new System.Drawing.Size(1019, 370);
            this.Controls.Add(this.reportViewer2);
            this.Name = "frmReport";
            this.Load += new System.EventHandler(this.frmReport_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cyberDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbStaffBindingSource;
       
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private CyberDataSet cyberDataSet;
        private System.Windows.Forms.BindingSource bindingSource1;
        private CyberDataSetTableAdapters.tbStaffTableAdapter tbStaffTableAdapter1;
    }
}