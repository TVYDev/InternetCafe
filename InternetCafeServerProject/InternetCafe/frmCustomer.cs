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
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {

            InitializeComponent();
        }




        SqlCommand sqlcmand;
        SqlConnection sqlcnect;
        SqlCommandBuilder sqlcmbuild;
        SqlDataAdapter sqlda;
        DataTable dt;
        SqlDataReader dr;
        int a;
        private void Customerform_Load(object sender, EventArgs e)
        {
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.AllowUserToOrderColumns = false;
            dgvCustomers.AllowUserToResizeColumns = false;
            dgvCustomers.ReadOnly = true;

            dgvCustomers.ClearSelection();

            btnSave.Visible = false;
            //int dgvw = dgvCustomers.Width;
            //dgvCustomers.Columns[0].HeaderText = "User Name";
            //dgvCustomers.Columns[1].Width = 0;
            //dgvCustomers.Columns[2].Width = dgvw / 3;
            //dgvCustomers.Columns[2].HeaderText = "Remaining Hour";
           
            //dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //dgvCustomers.Columns[0].Width = 160;

            //dgvCustomers.Columns[0].FillWeight = 160;
            //dgvCustomers.Columns[0].AutoSizeMode = dgvCustomers.Fill;

            dgvCustomers.Font = new Font("Comic Sans MS", 10);

            //show tip text in search box
            txtSearch.ForeColor = System.Drawing.SystemColors.ScrollBar;
            txtSearch.Text = "Search here...";
            






            // sqlcnect = new SqlConnection("Data Source=192.168.43.40, 1433;Initial Catalog=Cyber;User ID=vannyou;Password=computer");  //connect to server
            //sqlcnect = new SqlConnection("Data Source= PANHARITH;   Initial Catalog=Cyber;   User ID=ABC;    Password=ABC");            // own connection
            //sqlcnect = new SqlConnection("Data Source= TVY\\SQLEXPRESS;   Initial Catalog=Cyber;   User ID=vannyou;    Password=computer");
            //sqlcnect = new SqlConnection("Data Source=PC2\\SQLEXPRESS;Initial Catalog=Cyber;integrated Security=True;Pooling=false");
            //sqlcnect.Open();
            //MessageBox.Show("HHHHHHHHHHHHHHHHHHH");






            // btnAddNew.Enabled = false;
           // btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btndelete.Enabled = false;
            txtPassword.Enabled = false;
            txtUsername.Enabled = false;
            nudHours.Enabled = false;
            nudMinutes.Enabled = false;
            nudSeconds.Enabled = false;
            btnUpdate.Visible = false;
            btnedit.Enabled = false;
           


            //show data into datagridview
            //sqlda = new SqlDataAdapter("select accName as [Account Name], pwd, rMinutes/3600 as [Remained Hours] FROM tbCustomer", InternetCafe.frmMain.con);
            sqlda = new SqlDataAdapter("select accName as [Account Name], pwd, rMinutes/3600 as [Hours], (rMinutes%3600)/60 as [Minutes], rMinutes%60 as [Seconds] FROM tbCustomer", InternetCafe.frmMain.con);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            dgvCustomers.DataSource = dt;
            dgvCustomers.Columns[0].Width = 270;
            dgvCustomers.Columns[1].Width = 0;
            dgvCustomers.Columns[2].Width = 100;
            dgvCustomers.Columns[3].Width = 100;
            dgvCustomers.Columns[4].Width = 100;
            btnPrintReport.Enabled = false;

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            nudHours.Value = 0;
            
            
            btnSave.Visible = true;
            btnAddNew.Visible = false;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
            
            
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            nudHours.Enabled = true;
            nudMinutes.Value = 0;
            nudSeconds.Value = 0;
            txtUsername.Focus();
            btnPrintReport.Enabled = false;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sqlcmand = new SqlCommand("updatedata",frmMain.con);
            sqlcmand.Parameters.Add("@acc",SqlDbType.NVarChar).Value = txtUsername.Text;
            sqlcmand.Parameters.Add("@password",SqlDbType.NVarChar).Value = txtPassword.Text;
            sqlcmand.Parameters.Add("@rhour", SqlDbType.NVarChar).Value = nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value;
            sqlcmand.CommandType = CommandType.StoredProcedure;
            sqlcmand.ExecuteNonQuery();

            sqlda = new SqlDataAdapter("select accName as [Account Name], pwd, rMinutes/3600 as [Hours], (rMinutes%3600)/60 as [Minutes], rMinutes%60 as [Seconds] FROM tbCustomer", InternetCafe.frmMain.con);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            dgvCustomers.DataSource = dt;
            dgvCustomers.Columns[0].Width = 270;
            dgvCustomers.Columns[1].Width = 0;
            dgvCustomers.Columns[2].Width = 100;
            dgvCustomers.Columns[3].Width = 100;
            dgvCustomers.Columns[4].Width = 100;

            txtUsername.Clear();
            txtPassword.Clear();
            nudHours.Value = 0;


            btnedit.Visible = true;
            btnedit.Enabled = false;

            btnUpdate.Visible = false;
            btnUpdate.Enabled = false;

            btnAddNew.Visible = true;
            btndelete.Enabled = false;
            btnreset.Enabled = false;
            txtPassword.Enabled = false;
            nudHours.Enabled = false;
            nudMinutes.Enabled = false;
            nudSeconds.Enabled = false;
            btnPrintReport.Enabled = false;
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            sqlcmand = new SqlCommand("deletedata", InternetCafe.frmMain.con);
            sqlcmand.Parameters.Add("@accname", SqlDbType.NVarChar).Value = txtUsername.Text;
            sqlcmand.CommandType = CommandType.StoredProcedure;
            sqlcmand.ExecuteNonQuery();


            sqlda = new SqlDataAdapter("select accName as [Account Name], pwd, rMinutes/3600 as [Hours], (rMinutes%3600)/60 as [Minutes], rMinutes%60 as [Seconds] FROM tbCustomer", InternetCafe.frmMain.con);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            dgvCustomers.DataSource = dt;
            dgvCustomers.Columns[0].Width = 270;
            dgvCustomers.Columns[1].Width = 0;
            dgvCustomers.Columns[2].Width = 100;
            dgvCustomers.Columns[3].Width = 100;
            dgvCustomers.Columns[4].Width = 100;


            txtUsername.Clear();
            txtPassword.Clear();
            nudHours.Value = 0;
            nudMinutes.Value = 0;
            nudSeconds.Value = 0;
            btnedit.Enabled = false;
            nudHours.Enabled = false;
            nudMinutes.Enabled = false;
            nudSeconds.Enabled = false;
            btndelete.Enabled = false;
            btnPrintReport.Enabled = false;

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {

                if (txtSearch.Text == "Search here...")
                {

                    txtSearch.ForeColor = System.Drawing.SystemColors.ScrollBar;
                }
                else
                {
                    txtSearch.ForeColor = System.Drawing.SystemColors.WindowText;

                    sqlda = new SqlDataAdapter("Select * from tbCustomer where accName like '" + txtSearch.Text + "%'", InternetCafe.frmMain.con);
                    dt = new DataTable();
                    sqlda.Fill(dt);

                    dgvCustomers.Columns.Clear();
                    dgvCustomers.DataSource = dt;
                }
            }
            else
            {
                txtSearch.ForeColor = System.Drawing.SystemColors.ScrollBar;
                sqlda = new SqlDataAdapter("Select * from tbCustomer ", InternetCafe.frmMain.con);
                dt = new DataTable();
                sqlda.Fill(dt);

                dgvCustomers.Columns.Clear();
                dgvCustomers.DataSource = dt;




            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.ForeColor == System.Drawing.SystemColors.ScrollBar)
            {
                txtSearch.Text = "";
            }

        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.ForeColor = System.Drawing.SystemColors.ScrollBar;
                txtSearch.Text = "Search here...";

            }

        }
        String res="";
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Please Input Username!!!!!");
                txtUsername.Focus();
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please Input Password!!!!!");
                txtPassword.Focus();
            }
            else
            {
                
                sqlcmand = new SqlCommand("SELECT * FROM tbCustomer WHERE accName = '" + txtUsername.Text + "'", InternetCafe.frmMain.con);
                dr = sqlcmand.ExecuteReader();
                
                while (dr.Read())
                {
                    res= dr[0].ToString();
                }
                dr.Close();
               
                if (res != txtUsername.Text)
                {
                    sqlcmand = new SqlCommand("insertdata", InternetCafe.frmMain.con);
                    sqlcmand.Parameters.Add("@accname", SqlDbType.NVarChar).Value = txtUsername.Text;
                    sqlcmand.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtPassword.Text;
                    sqlcmand.Parameters.Add("@rhour", SqlDbType.Int).Value = nudHours.Value * 3600;
                    sqlcmand.CommandType = CommandType.StoredProcedure;
                    sqlcmand.ExecuteNonQuery();


                    sqlda = new SqlDataAdapter("select accName as [Account Name], pwd, rMinutes/3600 as [Hours], (rMinutes%3600)/60 as [Minutes], rMinutes%60 as [Seconds] FROM tbCustomer", InternetCafe.frmMain.con);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dgvCustomers.DataSource = dt;
                    dgvCustomers.Columns[0].Width = 270;
                    dgvCustomers.Columns[1].Width = 0;
                    dgvCustomers.Columns[2].Width = 100;
                    dgvCustomers.Columns[3].Width = 100;
                    dgvCustomers.Columns[4].Width = 100;


                    MessageBox.Show("Good To Go !!");
                    txtUsername.Clear();
                    txtPassword.Clear();
                    nudHours.Value = 0;
                    btnedit.Enabled = false;
                    btnSave.Visible = false;
                    btnAddNew.Visible = true;
                    btndelete.Enabled = false;
                    btnPrintReport.Enabled = false;

                    sqlcmand = new SqlCommand("insertPayment", frmMain.con);
                    sqlcmand.CommandType = CommandType.StoredProcedure;
                    sqlcmand.Parameters.AddWithValue("@acc", txtUsername.Text);
                    sqlcmand.Parameters.AddWithValue("@orderHour", nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value);
                    sqlcmand.ExecuteNonQuery();
                    sqlcmand.Dispose();
                }
                else
                {
                    //MessageBox.Show("Already");
                    res = "";
                }
            }


            btnAddNew.Visible = false;
            btnSave.Visible = true;
           
            
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddNew.Visible = true;
            btnSave.Visible = false;
            try
            {
                if (dgvCustomers.RowCount >= 0)
                {
                    btnedit.Visible = true;
                    btnedit.Enabled = true;
                    btndelete.Enabled = true;

                    DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                    txtUsername.Text = row.Cells[0].Value.ToString();
                    txtPassword.Text = row.Cells[1].Value.ToString();
                    nudHours.Value = (int)row.Cells[2].Value;
                    nudMinutes.Value = (int)row.Cells[3].Value;
                    nudSeconds.Value = (int)row.Cells[4].Value;
                    btnPrintReport.Enabled = true;
                    txtPassword.Enabled = false;
                    txtUsername.Enabled = false;
                    nudHours.Enabled = false;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Click the right cell you want to choose");

            }
        
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            //txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            nudHours.Enabled = true;
            
            
            btnedit.Enabled = false;
            btnedit.Visible = false;
            btnUpdate.Enabled = true;
            btnUpdate.Visible = true;
            btnAddNew.Enabled = true;
        }

        private void dgvCustomers_MouseEnter(object sender, EventArgs e)
        {
            //btnAddNew.Visible = true;
            //btnSave.Visible = false;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            //this.Refresh();
            //frmCustomer n = new frmCustomer();
            //n.Show();
        }

        private void dgvCustomers_MouseLeave(object sender, EventArgs e)
        {
           // btnAddNew.Visible = true;

           //btndelete.Enabled = false;
           //btnedit.Enabled = false;
        }

        private void btnreset_Click_1(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            nudHours.Value = 0;

            btndelete.Enabled = false;
            btnedit.Enabled = false;
            btnSave.Visible = false;
            btnAddNew.Visible = true;

            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            nudHours.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReportDetailCustomer rpDetailCus = new frmReportDetailCustomer(txtUsername.Text);
            rpDetailCus.ShowDialog();
        }
    }
}
