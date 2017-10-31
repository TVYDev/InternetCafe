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
using System.IO;

namespace InternetCafe
{
    public partial class frmStaff : Form
    {
        SqlCommand com;
        MemoryStream ms;
        byte[] photo;
        //int sID = 0;
        string file,button;


        public frmStaff()
        {
            InitializeComponent();

            dgvStaff.EnableHeadersVisualStyles = false;
            dgvStaff.RowHeadersVisible = false;
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           
            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AllowUserToDeleteRows = false;
            dgvStaff.AllowUserToResizeColumns = false;
            dgvStaff.AllowUserToOrderColumns = false;
            dgvStaff.ReadOnly = true;
            dgvStaff.Font = new Font("Comic Sans MS", 10);
      
            rdbMale.Checked = true;

            txtSearch.ForeColor = System.Drawing.SystemColors.ScrollBar;
            txtSearch.Text = "Search here...";

            pbStaff.BorderStyle = BorderStyle.FixedSingle;

            foreach (Control c in Controls)
            {
                c.Enabled = false;
            }

            btnNew.Enabled = true;
            txtSearch.Enabled = true;
            dgvStaff.Enabled = true;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            button = "New";
            foreach (Control c in Controls)
            {
                c.Enabled = true;
            }
            txtSearch.ForeColor = System.Drawing.SystemColors.ScrollBar;
        }
        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSearch.ForeColor == System.Drawing.SystemColors.ScrollBar)
            {
                txtSearch.Text = "";
            }
            else { }
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
                }
            }
            else {
                txtSearch.ForeColor = System.Drawing.SystemColors.ScrollBar;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                file = open.FileName;
                pbStaff.Image = new Bitmap(file);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox && c.Tag == null)
                    c.Text = "";
                    c.Enabled = false;
                    dgvStaff.Enabled = true;
                    btnNew.Enabled = true;
                    txtSearch.Enabled = true;
            }
            pbStaff.Image = null;
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtSalary_Click(object sender, EventArgs e)
        {
            Control current = txtSalary;
            if (current.Text.Equals("0"))
            {
                current.Text = String.Empty;
            }
            else { }
        }

        private void txtSalary_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSalary_Leave(object sender, EventArgs e)
        {
            Control current = txtSalary;
            if (current.Text.Equals(String.Empty))
            {
                current.Text = "0";
            }
            else { }
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.ForeColor = System.Drawing.SystemColors.ScrollBar;
                txtSearch.Text = "Search here...";
            }
            else { }
        }
        public void saveData(String sd)
        {
            mtbPhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            com = new SqlCommand(sd, frmMain.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@n", txtName.Text);
            if (rdbMale.Checked)
            {
                com.Parameters.AddWithValue("@g", "M");
            }
            else
            {
                com.Parameters.AddWithValue("@g", "F");
            }
            com.Parameters.AddWithValue("@d", dtpkDOB.Value);
            com.Parameters.AddWithValue("@p", txtPosition.Text);
            com.Parameters.AddWithValue("@s", txtSalary.Text);
            com.Parameters.AddWithValue("@add", txtAddress.Text);
            com.Parameters.AddWithValue("@ph", mtbPhone.Text);
            if (file != null)
            {
                photo = File.ReadAllBytes(file);
            }
            com.Parameters.AddWithValue("@pho", photo);
            com.Parameters.AddWithValue("@h", dtpkHiredDate.Value);
            com.Parameters.AddWithValue("@st", chbEmployed.Checked);
            com.ExecuteNonQuery();
            file = null;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //frmMain.con.Open();
            String msg = "Please fill all the require field!!!";
            String o = "Not all field are completed";
            MessageBoxButtons ok = MessageBoxButtons.OK;
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show(msg,o,ok);
                txtName.Focus();
                return;
            }
            if (rdbMale.Checked == false && rdbFemale.Checked == false)
            {
                MessageBox.Show(msg,o,ok);
                rdbMale.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dtpkDOB.Text.Trim()))
            {
                MessageBox.Show(msg,o,ok);
                dtpkDOB.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPosition.Text.Trim()))
            {
                MessageBox.Show(msg,o,ok);
                txtPosition.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSalary.Text.Trim()))
            {
                MessageBox.Show(msg,o,ok);
                txtSalary.Focus();
                return;
            }
            if (string.IsNullOrEmpty(mtbPhone.Text.Trim()))
            {
                MessageBox.Show(msg,o,ok);
                mtbPhone.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                MessageBox.Show(msg,o,ok);
                txtAddress.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dtpkHiredDate.Text.Trim()))
            {
                MessageBox.Show(msg,o,ok);
                dtpkHiredDate.Focus();
                return;
            }
            if (pbStaff.Image == null)
            {
                MessageBox.Show(msg, o, ok);
                btnBrowse.Focus();
            }
            saveData("SaveData");
            frmStaff_Load(sender, e);
            frmMain.con.Dispose();
            MessageBox.Show("Your record was saved");
        }
        public void showData()
        {
            String sql = "select * from tbStaff where stopWork='False'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, InternetCafe.frmMain.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvStaff.DataSource = dt;
            dgvStaff.Columns[0].Width = 75;
            dgvStaff.Columns[1].Width = 300;
        }
        private void frmStaff_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
                com = new SqlCommand("SearchData", frmMain.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@i", txtSearch.Text);
                com.Parameters.AddWithValue("@n", txtSearch.Text);
                
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                sda.SelectCommand = com;
                sda.Fill(dt);
                dgvStaff.DataSource = dt;
                dgvStaff.Columns[0].Width = 75;
                dgvStaff.Columns[1].Width = 300;
                //this.dgvStaff.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //this.dgvStaff.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvStaff_CellClick(sender, e);
            //}
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //enable control
            foreach(Control c in Controls){
                c.Enabled = true;
                btnNew.Enabled = false;
                btnSave.Enabled = false;
            }

            int i;
            if (dgvStaff.RowCount > 0)
            {
                i = e.RowIndex;
                if (i < 0)
                    return;
                DataGridViewRow row = dgvStaff.Rows[i];
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();

                if (row.Cells[2].Value.ToString() == "M")
                    rdbMale.Checked = true;
                else
                    rdbFemale.Checked = true;

                dtpkDOB.Format = DateTimePickerFormat.Long;
                dtpkDOB.Text = row.Cells[3].Value.ToString();

                txtPosition.Text = row.Cells[4].Value.ToString();
                txtSalary.Text = row.Cells[5].Value.ToString();

                mtbPhone.Text = row.Cells[7].Value.ToString();
                txtAddress.Text = row.Cells[6].Value.ToString();

                photo = (byte[])row.Cells[8].Value;
                ms = new MemoryStream(photo);
                pbStaff.Image = Image.FromStream(ms);

                dtpkHiredDate.Format = DateTimePickerFormat.Long;
                dtpkHiredDate.Text = row.Cells[9].Value.ToString();

                if (row.Cells[10].Value.ToString() == "True")
                {
                    chbEmployed.Checked = true;
                }
                else {
                    chbEmployed.Checked = false;
                }
            }
                btnUpdate.Enabled = true;
                btnCancel.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //frmMain.con.Open();
            mtbPhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            //Enable all textbox
            foreach (Control c in Controls)
            {
                c.Enabled = true;
            }

            com = new SqlCommand("UpdateStaff", frmMain.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@i", txtID.Text);
            com.Parameters.AddWithValue("@n", txtName.Text);
            if (rdbMale.Checked)
            {
                com.Parameters.AddWithValue("@g", "M");
            }
            else
            {
                com.Parameters.AddWithValue("@g", "F");
            }
            com.Parameters.AddWithValue("@d", dtpkDOB.Value);
            com.Parameters.AddWithValue("@p", txtPosition.Text);
            com.Parameters.AddWithValue("@s", txtSalary.Text);
            com.Parameters.AddWithValue("@add", txtAddress.Text);
            com.Parameters.AddWithValue("@ph", mtbPhone.Text);
            if (file != null)
            {
                photo = File.ReadAllBytes(file);
            }
            com.Parameters.AddWithValue("@pho", photo);
            com.Parameters.AddWithValue("@h", dtpkHiredDate.Value);
            com.Parameters.AddWithValue("@st", chbEmployed.Checked);
            com.ExecuteNonQuery();
            file = null;
            MessageBox.Show("Your record was saved.","Update",MessageBoxButtons.OK,MessageBoxIcon.Information);
            frmStaff_Load(sender, e);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from tbStaff", frmMain.con);
            sda.Fill(dt);
            frmMain.con.Close();
            foreach (Control c in Controls)
            {
                if(c.Tag == null)
                c.Enabled = false;              
            }
            btnNew.Enabled = true;
            btnNew.Focus();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           frmReport fReport=new frmReport();
            fReport.Show();
        }       
    }
}
