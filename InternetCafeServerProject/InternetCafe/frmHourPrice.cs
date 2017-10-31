using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InternetCafe
{
    public partial class frmHourPrice : Form
    {
        static SqlCommand com;
        SqlDataAdapter da;
        DataTable dt;

        public frmHourPrice()
        {
            InitializeComponent();

            nudHourPrice.Minimum = 0;
            nudHourPrice.Maximum = 10000;
            nudHourPrice.Increment = 100;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            com = new SqlCommand("setHourPrice", frmMain.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@price", nudHourPrice.Value);
            com.ExecuteNonQuery();

            btnUpdate.Enabled = false;
            lblInfoUpdatePrice.Visible = true;

            da = new SqlDataAdapter("SELECT * FROM dbo.getHourPriceList() ORDER BY hno DESC", frmMain.con);
            dt = new DataTable();
            da.Fill(dt);

            dgvHourPriceHistory.DataSource = dt;
            dgvHourPriceHistory.Columns[0].Width = 0;

            frmMain.lblHourPrice.Text = nudHourPrice.Value + "";
        }

        private void frmHourPrice_Load(object sender, EventArgs e)
        {
            lblInfoUpdatePrice.Visible = false;
            nudHourPrice.Value = Decimal.Parse(frmMain.lblHourPrice.Text);

            dgvHourPriceHistory.EnableHeadersVisualStyles = false;
            dgvHourPriceHistory.RowHeadersVisible = false;
            dgvHourPriceHistory.ReadOnly = true;
            dgvHourPriceHistory.AllowUserToAddRows = false;
            dgvHourPriceHistory.AllowUserToDeleteRows = false;
            dgvHourPriceHistory.AllowUserToOrderColumns = false;
            dgvHourPriceHistory.AllowUserToResizeColumns = false;
            dgvHourPriceHistory.AllowUserToResizeRows = false;
            dgvHourPriceHistory.Font = new Font("Comic Sans MS", 10);
            dgvHourPriceHistory.RowsDefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvHourPriceHistory.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dgvHourPriceHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            da = new SqlDataAdapter("SELECT * FROM dbo.getHourPriceList() ORDER BY hno DESC", frmMain.con);
            dt = new DataTable();
            da.Fill(dt);

            dgvHourPriceHistory.DataSource = dt;
            dgvHourPriceHistory.Columns[0].Width = 0;
        }

        private void nudHourPrice_ValueChanged(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            lblInfoUpdatePrice.Visible = false;
        }
    }
}
