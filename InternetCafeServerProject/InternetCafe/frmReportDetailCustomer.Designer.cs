namespace InternetCafe
{
    partial class frmReportDetailCustomer
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DetailStaffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetCusDetail = new InternetCafe.DataSetCusDetail();
            this.DetailStaffTableAdapter = new InternetCafe.DataSetCusDetailTableAdapters.DetailStaffTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DetailStaffBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetCusDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DetailStaffBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "InternetCafe.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(653, 595);
            this.reportViewer1.TabIndex = 0;
            // 
            // DetailStaffBindingSource
            // 
            this.DetailStaffBindingSource.DataMember = "DetailStaff";
            this.DetailStaffBindingSource.DataSource = this.DataSetCusDetail;
            // 
            // DataSetCusDetail
            // 
            this.DataSetCusDetail.DataSetName = "DataSetCusDetail";
            this.DataSetCusDetail.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DetailStaffTableAdapter
            // 
            this.DetailStaffTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportDetailCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 595);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportDetailCustomer";
            this.Load += new System.EventHandler(this.frmReportDetailCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DetailStaffBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetCusDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DetailStaffBindingSource;
        private DataSetCusDetail DataSetCusDetail;
        private DataSetCusDetailTableAdapters.DetailStaffTableAdapter DetailStaffTableAdapter;


    }
}