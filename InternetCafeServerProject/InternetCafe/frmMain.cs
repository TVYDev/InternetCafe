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
    public partial class frmMain : Form
    {
        public static frmStaff fStaff;
        public static frmCustomer fCustomer;
        public static frmHome fHome;

        public static SqlConnection con;
        static SqlCommand com;


        public frmMain()
        {
            InitializeComponent();

            fHome = new frmHome();
            fHome.TopLevel = false;
            fStaff = new frmStaff();
            fStaff.TopLevel = false;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TopMost = true;
            //Focus();
            //BringToFront();
            //Activate();

            pnHourPrice.BackColor = Color.FromArgb(150,20, 110, 220);
            //btnUpdatePrice.BackColor = Color.FromArgb(200, 20, 110, 220);

            label1.Height = 1;

            btnHome_Click(sender, e);

            InternetCafe.ReceiveFromClient.setupServer();

            con = new SqlConnection("Data Source = TVY\\SQLEXPRESS;Initial Catalog=Cyber;User ID=vannyou;Password=computer");
            con.Open();

            com = new SqlCommand("SELECT unitPrice FROM dbo.getHourPrice()", frmMain.con);
            SqlDataReader dr;
            dr = com.ExecuteReader();
            dr.Read();
            lblHourPrice.Text = double.Parse(dr[0].ToString()) + "";
            dr.Close();

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            if(!pnDisplay.Controls.Contains(fStaff)){
                pnDisplay.Controls.Clear();
                pnDisplay.Controls.Add(fStaff);
                
                fStaff.Show();
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (!pnDisplay.Controls.Contains(fCustomer))
            {
                pnDisplay.Controls.Clear();
                pnDisplay.Controls.Add(fCustomer);
                fCustomer = new frmCustomer();
                fCustomer.TopLevel = false;
                fCustomer.Show();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (!pnDisplay.Controls.Contains(fHome))
            {
                pnDisplay.Controls.Clear();
                pnDisplay.Controls.Add(fHome);
                
                fHome.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            frmHourPrice formHP = new frmHourPrice();
            formHP.ShowDialog();
        }
    }
}
