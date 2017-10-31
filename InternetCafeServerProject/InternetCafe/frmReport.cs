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
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.tbStaff' table. You can move, or remove it, as needed.
            //this.tbStaffTableAdapter.Fill(this.DataSet1.tbStaff);

            this.reportViewer1.RefreshReport();
        }

        private void tbStaffBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void frmReport_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cyberDataSet.tbStaff' table. You can move, or remove it, as needed.
            this.tbStaffTableAdapter1.Fill(this.cyberDataSet.tbStaff);

            this.reportViewer2.RefreshReport();
        }
    }
}
