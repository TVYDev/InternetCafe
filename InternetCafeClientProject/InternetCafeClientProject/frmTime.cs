using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace InternetCafeClientProject
{
    public partial class usrInfoFrm : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader dr;
        double time;
        public usrInfoFrm()
        {
            InitializeComponent();
        }
        //For Logout

        private System.Windows.Forms.Timer timer;
        int second, minute, hour;



        private void Form1_Load(object sender, EventArgs e)
        {
           // connetionString="Data Source=IP_ADDRESS,PORT;
           // Network Library=DBMSSOCN;Initial Catalog=DatabaseName;
            //User ID=UserName;Password=Password
           // con = new SqlConnection("Data Source = 192.168.43.40, 1433; Initial Catalog = Cyber ; User ID = Vannyou ; Password = computer");
            //con = new SqlConnection("Data Source = Anonymous ; Initial Catalog = Cyber ; Integrated Security = True ; Pooling = False");
           // con.Open();

            lblUserName.Text = client_forms.Form1.username;

            lblUserName.TextAlign = ContentAlignment.MiddleCenter;


           time = int.Parse(client_forms.Form1.RemindHour);

            double cal = time / 60;

            if (cal >= 1)
            {
                hour = (int)Math.Floor(cal);
                cal = cal - (int)Math.Floor(cal);
                minute =(int) Math.Ceiling(cal * 60);
                if (minute > 0)
                {
                    minute -= 1;
                    second = 60;
                }
                else
                {
                    second = 0;
                }
            }
            else
            {
                hour = 0;
                minute = (int)time - 1;
                
                second = 60;

            }
            


           
            //second = int.Parse(lblSecond.Text);
            // minute = int.Parse(lblMinute.Text);
            // hour = int.Parse(lblHour.Text);
             timer = new System.Windows.Forms.Timer();
             timer.Tick += new EventHandler(Timer_Tick);
             timer.Interval = 1000;
             timer.Start();
            

            
            

        }

        private void Timer_Tick(object sender, EventArgs e) {
            if (second > 0)
            {
                second--;
            }
            if (hour == 0 && minute == 4 && second == 59)
            {

                MessageBox.Show("You have 5Minute left  Please top up now");
   
                
                //lblSecond.Text = second.ToString();
                //lblMinute.Text = minute.ToString();
                //lblHour.Text = hour.ToString();

            }

            if (second == 0 && minute == 0 && hour == 0)
            {
                timer.Stop();

            }
            else if (second <= 0 && minute > 0 ) {
                second = 60;
                minute -= 1;

            }
            if (minute == 0 && hour>0) {
            
                    minute = 60;
                    hour -= 1;
                
            }
            //else if (second == 0) {
            //    if (minute > 0)
            //    {
            //        second = 60;
            //        minute -=1;
            //    }
            //    else if (hour > 0) {
            //        minute = 60;
            //        hour--;
            //    }
            //}


          
            lblSecond.Text = second.ToString();
            lblMinute.Text = minute.ToString();
            lblHour.Text = hour.ToString();
          //  second--;
          

        }


        private void btnTopUp_Click(object sender, EventArgs e)
        {
            frmTopUp frmtop = new frmTopUp();
            frmtop.Show(); 
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = MessageBox.Show("Do You Want to Exit?","EXITING", MessageBoxButtons.YesNo);
            if (dialogresult == DialogResult.Yes)
            {
                ClientRequest.LoopConnect();
                InternetCafeClientProject.ClientRequest.SendLoop("out|" + client_forms.Form1.username + "|" + System.Environment.MachineName);
                
                timer.Stop();

               

                // Get Reminding time to Database
                client_forms.Form1 frmLogin = new client_forms.Form1();
                frmLogin.Show();
                this.Close();
             
               
              //  ExitWindowsEx(0, 0);
            }
            else {

                ///MessageBox.Show("Cancel");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblSecond_Click(object sender, EventArgs e)
        {

        }

        private void lblMinute_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {

          
            frmChangePassword change = new frmChangePassword();
            change.Show();

        }
    }

   

}
