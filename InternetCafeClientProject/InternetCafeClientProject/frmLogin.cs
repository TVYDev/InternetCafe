using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
using System.Data.SqlClient;
using System.Diagnostics;
using InternetCafeClientProject;


namespace client_forms
{
  

    public partial class Form1 : Form
    {
        bool showPwd = false;

        //For Logout;
        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int operationFlag, int operationReason);

        public static SqlConnection con;
        public static SqlCommand com;
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;

        public static String username;
        public static String password;
        public static String RemindHour;

        private int Time = 5;

        private System.Windows.Forms.Timer CountdownTimer;
        

        public Form1()
        {
            InitializeComponent();
            
       
            txtPassword.PasswordChar = '\0';


            btnShowPassword.FlatStyle = FlatStyle.Flat;
            btnShowPassword.BackgroundImageLayout = ImageLayout.Stretch;

        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            CountdownTimer = new System.Windows.Forms.Timer();
            CountdownTimer.Tick += new EventHandler(CheckLogOutTimer);
            CountdownTimer.Interval = 1000;
            CountdownTimer.Start();

           // con = new SqlConnection("Data Source = 192.168.43.40, 1433 ; Initial Catalog = Cyber ;User ID=vannyou;Password=computer");
            con = new SqlConnection("Data Source = TVY\\SQLEXPRESS ; Initial Catalog = Cyber ;User ID=vannyou;Password=computer");
            //con = new SqlConnection("Data Source = Anonymous; Initial Catalog = Cyber ; Integrated Security = true");

            con.Open();
            txtUsername.Text = "Enter username here...";
            txtUsername.ForeColor = System.Drawing.SystemColors.ScrollBar;
            txtPassword.Text = "Enter password here...";
            txtPassword.ForeColor = System.Drawing.SystemColors.ScrollBar;

            btnLogin.Focus();

            if (txtPassword.Text != "Enter password here...")
            {
                txtPassword.PasswordChar = '\u2022';
            }

            btnShowPassword.BackgroundImage = ((System.Drawing.Image)(InternetCafeClientProject.Properties.Resources.unshownPwd));
            
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
            {
                if (txtPassword.Text == "Enter password here...")
                {
                    txtPassword.ForeColor = System.Drawing.SystemColors.ScrollBar;
                }
                else
                {
                    txtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
                }
            }
            else {
                txtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
                if (showPwd == true)
                {
                    txtPassword.PasswordChar = '\0';
                }
                else {
                    txtPassword.PasswordChar = '\u2022';
                }
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (showPwd == true)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '\u2022';
            }

            if (txtPassword.ForeColor == System.Drawing.SystemColors.ScrollBar)
            {
                txtPassword.Text = "";
            }
            else {
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "") {
                txtPassword.ForeColor = System.Drawing.SystemColors.ScrollBar;
                txtPassword.Text = "Enter password here...";
                txtPassword.PasswordChar = '\0';
            }
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            if (txtUsername.ForeColor == System.Drawing.SystemColors.ScrollBar)
            {
                txtUsername.Text = "";
            }
            else {
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.ForeColor = System.Drawing.SystemColors.ScrollBar;
                txtUsername.Text = "Enter username here...";
            }
            else {}
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text != "")
            {
                if (txtUsername.Text == "Enter username here...")
                {
                    txtUsername.ForeColor = System.Drawing.SystemColors.ScrollBar;
                }
                else
                {
                    txtUsername.ForeColor = System.Drawing.SystemColors.WindowText;
                }
            }
            else
            {
                txtUsername.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "Enter password here...")
            {
                if (showPwd == false)
                {
                    btnShowPassword.BackgroundImage = ((System.Drawing.Image)(InternetCafeClientProject.Properties.Resources.showPwd));
                    txtPassword.PasswordChar = '\0';
                    showPwd = true;
                }
                else
                {
                    btnShowPassword.BackgroundImage = ((System.Drawing.Image)(InternetCafeClientProject.Properties.Resources.unshownPwd));
                    txtPassword.PasswordChar = '\u2022';
                    showPwd = false;
                }
                
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Boolean B = false;
            
            com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;

            com.CommandText = "Select * From tbCustomer";


            dr = com.ExecuteReader();
            while (dr.Read()) {
                if (dr[0].ToString() == txtUsername.Text && dr[1].ToString()==txtPassword.Text) {

                    username = dr[0].ToString();
                    password = dr[1].ToString();
                    RemindHour = dr[2].ToString();
                    
                    B= true;   
                }

               
            }

            dr.Close();
            dr.Dispose();

            if (B == true){
                MessageBox.Show("Login successfully");
                ClientRequest.LoopConnect();
                InternetCafeClientProject.ClientRequest.SendLoop("in|" + username + "|" + System.Environment.MachineName);

                this.Hide();
                InternetCafeClientProject.usrInfoFrm formTime = new InternetCafeClientProject.usrInfoFrm();
                formTime.Show();
            }
            else if (B ==false) {
                MessageBox.Show("Incorrect username or password");
            }
            dr.Close();
            com.Dispose();

            //if (txtUsername.Text == "Enter username here...") {
            //    MessageBox.Show("You must enter your username");
            //    txtUsername.Clear();
            //    txtUsername.Focus();   
            //}
            //else if (txtPassword.Text == "Enter password here...") {
            //    MessageBox.Show("You must enter your password");
            //    txtPassword.PasswordChar = '\u2022';
            //    txtPassword.Clear();
            //    txtPassword.Focus();
            //}

            //else if ((txtUsername.Text != username) || (txtPassword.Text != password)) {
            //    MessageBox.Show("Incorrect username or password");
            //}
            //else if ((txtUsername.Text == username) && (txtPassword.Text == password)) {
            //    MessageBox.Show("Login successfully");
            //    this.Hide();
            //    InternetCafeClientProject.usrInfoFrm formTime = new InternetCafeClientProject.usrInfoFrm();
            //    formTime.Show();
            //}

        }

        private void CheckLogOutTimer(Object Sender, EventArgs E) {
            Time--;
         
            if (Time <= 0) {

                //Commmand for shutdown...
               // InternetCafeClientProject.CmdClass cmd = new InternetCafeClientProject.CmdClass();
              //  cmd.ExecuteCommand("shutdown -f -t 10 -s");

                //Command for sleep
             //   ExitWindowsEx(4, 0);
                
            
            }
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
        
    }
}
