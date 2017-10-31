using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetCafe
{
    public partial class frmReportDetailCustomer : Form
    {
        string st;
        public frmReportDetailCustomer(string st)
        {
            InitializeComponent();
            this.st = st;
        }

        private void frmReportDetailCustomer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetCusDetail.tbActiveAccount' table. You can move, or remove it, as needed.
            this.DetailStaffTableAdapter.Fill(this.DataSetCusDetail.DetailStaff, st);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
