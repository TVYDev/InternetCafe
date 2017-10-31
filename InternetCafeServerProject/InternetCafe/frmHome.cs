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
using System.Net.Sockets;

namespace InternetCafe
{
    public partial class frmHome : Form
    {
        Timer timer;
        Timer[] arrTimer = new Timer[10];
        static SqlCommand com;
        static SqlDataReader dr;
        

        int[] remainedTime = new int[10];
        int[] count = {0,0,0,0,0,0,0,0,0,0};

        public frmHome()
        {
            InitializeComponent();

            
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblUser1.Visible = false;
            lblUser2.Visible = false;
            lblUser3.Visible = false;
            lblUser4.Visible = false;
            lblUser5.Visible = false;
            lblUser6.Visible = false;
            lblUser7.Visible = false;
            lblUser8.Visible = false;
            lblUser9.Visible = false;
            lblUser10.Visible = false;

            btnAdd1H.Enabled = false;
            btnAdd2H.Enabled = false;
            btnAdd3H.Enabled = false;
            btnAdd4H.Enabled = false;
            btnAdd5H.Enabled = false;
            btnAdd6H.Enabled = false;

            timer = new Timer();
            timer.Tick += new EventHandler(timerHandle);
            timer.Interval = 1000;
            timer.Start();

            lblPC1.BackColor = Color.Transparent;
            lblPC2.BackColor = Color.Transparent;
            lblPC3.BackColor = Color.Transparent;
            lblPC4.BackColor = Color.Transparent;
            lblPC5.BackColor = Color.Transparent;
            lblPC6.BackColor = Color.Transparent;
            lblPC7.BackColor = Color.Transparent;
            lblPC8.BackColor = Color.Transparent;
            lblPC9.BackColor = Color.Transparent;
            lblPC10.BackColor = Color.Transparent;

            lblPC1.MouseClick += pc_click;
            lblPC2.MouseClick += pc_click;
            lblPC3.MouseClick += pc_click;
            lblPC4.MouseClick += pc_click;
            lblPC5.MouseClick += pc_click;
            lblPC6.MouseClick += pc_click;
            lblPC7.MouseClick += pc_click;
            lblPC8.MouseClick += pc_click;
            lblPC9.MouseClick += pc_click;
            lblPC10.MouseClick += pc_click;

            btnAdd1H.MouseClick += click_addTime;
            btnAdd2H.MouseClick += click_addTime;
            btnAdd3H.MouseClick += click_addTime;
            btnAdd4H.MouseClick += click_addTime;
            btnAdd5H.MouseClick += click_addTime;
            btnAdd6H.MouseClick += click_addTime;

        }
        private void timerHandle(Object sender, EventArgs e) {
            string receiveText = ReceiveFromClient.text;
            ReceiveFromClient.text = "";
            if (receiveText != "")
            {
                string[] receiveTextSplit = receiveText.Split('|');
                if (receiveTextSplit[0] != "Topup")
                {
                    if (receiveTextSplit[0] == "in")
                    {
                        com = new SqlCommand("insertActiveAccount", frmMain.con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@accName", receiveTextSplit[1]);
                        com.ExecuteNonQuery();
                        com.Dispose();

                        switch (receiveTextSplit[2])
                        {
                            case "PC1":
                                lblPC1.Image = (Image)InternetCafe.Properties.Resources.pc_green;
                                lblUser1.Visible = true;
                                lblUser1.Text = receiveTextSplit[1];
                                arrTimer[0] = new Timer();
                                arrTimer[0].Tick += new EventHandler((sender1, e1) => countDownTime(sender, e, receiveTextSplit[1], 0));
                                arrTimer[0].Interval = 1000;
                                arrTimer[0].Start();
                                break;
                            case "PC2":
                                lblPC2.Image = (Image)InternetCafe.Properties.Resources.pc_green;
                                lblUser2.Visible = true;
                                lblUser2.Text = receiveTextSplit[1];
                                arrTimer[1] = new Timer();
                                arrTimer[1].Tick += new EventHandler((sender1, e1) => countDownTime(sender, e, receiveTextSplit[1], 1));
                                arrTimer[1].Interval = 1000;
                                arrTimer[1].Start();
                                break;
                            case "SSK-10":
                                lblPC3.Image = (Image)InternetCafe.Properties.Resources.pc_green;
                                lblUser3.Visible = true;
                                lblUser3.Text = receiveTextSplit[1];
                                arrTimer[2] = new Timer();
                                arrTimer[2].Tick += new EventHandler((sender1, e1) => countDownTime(sender, e, receiveTextSplit[1], 2));
                                arrTimer[2].Interval = 1000;
                                arrTimer[2].Start();
                                break;
                            case "ANONYMOUS":
                                lblPC4.Image = (Image)InternetCafe.Properties.Resources.pc_green;
                                lblUser4.Visible = true;
                                lblUser4.Text = receiveTextSplit[1];
                                arrTimer[3] = new Timer();
                                arrTimer[3].Tick += new EventHandler((sender1, e1) => countDownTime(sender, e, receiveTextSplit[1], 3));
                                arrTimer[3].Interval = 1000;
                                arrTimer[3].Start();
                                break;
                            case "PC5":
                                lblPC5.Image = (Image)InternetCafe.Properties.Resources.pc_green;
                                lblUser5.Visible = true;
                                lblUser5.Text = receiveTextSplit[1];
                                arrTimer[4] = new Timer();
                                arrTimer[4].Tick += new EventHandler((sender1, e1) => countDownTime(sender, e, receiveTextSplit[1], 4));
                                arrTimer[4].Interval = 1000;
                                arrTimer[4].Start();
                                break;
                            case "PC6":
                                lblPC6.Image = (Image)InternetCafe.Properties.Resources.pc_green;
                                lblUser6.Visible = true;
                                lblUser6.Text = receiveTextSplit[1];
                                arrTimer[5] = new Timer();
                                arrTimer[5].Tick += new EventHandler((sender1, e1) => countDownTime(sender, e, receiveTextSplit[1], 5));
                                arrTimer[5].Interval = 1000;
                                arrTimer[5].Start();
                                break;
                            case "PC7":
                                lblPC7.Image = (Image)InternetCafe.Properties.Resources.pc_green;
                                lblUser7.Visible = true;
                                lblUser7.Text = receiveTextSplit[1];
                                arrTimer[6] = new Timer();
                                arrTimer[6].Tick += new EventHandler((sender1, e1) => countDownTime(sender, e, receiveTextSplit[1], 6));
                                arrTimer[6].Interval = 1000;
                                arrTimer[6].Start();
                                break;
                            case "PC8":
                                lblPC8.Image = (Image)InternetCafe.Properties.Resources.pc_green;
                                lblUser8.Visible = true;
                                lblUser8.Text = receiveTextSplit[1];
                                arrTimer[7] = new Timer();
                                arrTimer[7].Tick += new EventHandler((sender1, e1) => countDownTime(sender, e, receiveTextSplit[1], 7));
                                arrTimer[7].Interval = 1000;
                                arrTimer[7].Start();
                                break;
                            case "PC9":
                                lblPC9.Image = (Image)InternetCafe.Properties.Resources.pc_green;
                                lblUser9.Visible = true;
                                lblUser9.Text = receiveTextSplit[1];
                                arrTimer[8] = new Timer();
                                arrTimer[8].Tick += new EventHandler((sender1, e1) => countDownTime(sender, e, receiveTextSplit[1], 8));
                                arrTimer[8].Interval = 1000;
                                arrTimer[8].Start();
                                break;
                            case "TVY":
                                lblPC10.Image = (Image)InternetCafe.Properties.Resources.pc_green;
                                lblUser10.Visible = true;
                                lblUser10.Text = receiveTextSplit[1];
                                arrTimer[9] = new Timer();
                                arrTimer[9].Tick += new EventHandler((sender1, e1) => countDownTime(sender, e, receiveTextSplit[1], 9));
                                arrTimer[9].Interval = 1000;
                                arrTimer[9].Start();
                                break;
                        }

                    }
                    else
                    {
                        com = new SqlCommand("insertDeactiveAccount", frmMain.con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@accName", receiveTextSplit[1]);
                        com.ExecuteNonQuery();
                        com.Dispose();

                        switch (receiveTextSplit[2])
                        {
                            case "PC1":
                                lblPC1.Image = (Image)InternetCafe.Properties.Resources.pc_blue;
                                lblUser1.Visible = false;
                                arrTimer[0].Stop();
                                break;
                            case "PC2":
                                lblPC2.Image = (Image)InternetCafe.Properties.Resources.pc_blue;
                                lblUser2.Visible = false;
                                arrTimer[1].Stop();
                                break;
                            case "SSK-10":
                                lblPC3.Image = (Image)InternetCafe.Properties.Resources.pc_blue;
                                lblUser3.Visible = false;
                                arrTimer[2].Stop();
                                break;
                            case "ANONYMOUS":
                                lblPC4.Image = (Image)InternetCafe.Properties.Resources.pc_blue;
                                lblUser4.Visible = false;
                                arrTimer[3].Stop();
                                break;
                            case "PC5":
                                lblPC5.Image = (Image)InternetCafe.Properties.Resources.pc_blue;
                                lblUser5.Visible = false;
                                arrTimer[4].Stop();
                                break;
                            case "PC6":
                                lblPC6.Image = (Image)InternetCafe.Properties.Resources.pc_blue;
                                lblUser6.Visible = false;
                                arrTimer[5].Stop();
                                break;
                            case "PC7":
                                lblPC7.Image = (Image)InternetCafe.Properties.Resources.pc_blue;
                                lblUser7.Visible = false;
                                arrTimer[6].Stop();
                                break;
                            case "PC8":
                                lblPC8.Image = (Image)InternetCafe.Properties.Resources.pc_blue;
                                lblUser8.Visible = false;
                                arrTimer[7].Stop();
                                break;
                            case "PC9":
                                lblPC9.Image = (Image)InternetCafe.Properties.Resources.pc_blue;
                                lblUser9.Visible = false;
                                arrTimer[8].Stop();
                                break;
                            case "TVY":
                                lblPC10.Image = (Image)InternetCafe.Properties.Resources.pc_blue;
                                lblUser10.Visible = false;
                                arrTimer[9].Stop();
                                break;
                        }
                    }
                }
                //else {
                //    DialogResult dialog = MessageBox.Show("User " + receiveTextSplit[1] + " is requesting for topping up " + int.Parse(receiveTextSplit[2]) + " hours","Client Request",MessageBoxButtons.YesNo);
                //    if (dialog == DialogResult.Yes)
                //    {

                //        com = new SqlCommand();
                //        com.Connection = frmMain.con;
                //        com.CommandType = CommandType.Text;
                //        com.CommandText = "SELECT rMinutes FROM tbCustomer where accName='" + receiveTextSplit[1] + "'";

                //        dr = com.ExecuteReader();
                //        int amountTime = 0;

                //        dr.Read();
                //        amountTime = int.Parse(dr[0].ToString());
                //        dr.Close();
                //        com.Dispose();

                //        com = new SqlCommand();
                //        com.Connection = frmMain.con;
                //        com.CommandType = CommandType.Text;
                //        com.CommandText = "UPDATE tbCustomer SET rMinutes=" + (amountTime + int.Parse(receiveTextSplit[2]) * 60) + " where accName='" + receiveTextSplit[1] + "'";
                //        com.ExecuteNonQuery();
                //        com.Dispose();
                //    }
                //    else {
                //        MessageBox.Show("Client Requent Cancelled");
                //    }
                //}

            }
        }

        private void pc_click(object sender, EventArgs e) {
            //get all lblPC and count how many of them are selected
            Label[] arrLabel = { lblPC1, lblPC2, lblPC3, lblPC4, lblPC5, lblPC6, lblPC7, lblPC8, lblPC9, lblPC10 };
            Label[] arrLabelUser = { lblUser1, lblUser2, lblUser3, lblUser4, lblUser5, lblUser6, lblUser7, lblUser8, lblUser9, lblUser10 };
            int countSelected = 0;
            for (int i = 0; i < arrLabel.Length; i++) {
                if (arrLabel[i].BackColor == Color.LightSteelBlue) {
                    countSelected++;
                }
            }

            //this label variable gets reference from certain Label that we send from form_load
            Label lbl = sender as Label;
            //
            if (lbl != null) {
                    if (lbl.BackColor == Color.Transparent)
                    {
                            int index = 0;
                            string username = "";

                            for (int i = 0; i < arrLabel.Length; i++)
                            {
                                if (lbl == arrLabel[i])
                                {
                                    username = arrLabelUser[i].Text;
                                    index = i;
                                    break;
                                }
                            }

                            if (arrLabelUser[index].Visible == true)
                            {

                                //if there is one or more lblPC selected already, then change all of them into unselected
                                if (countSelected >= 1)
                                {
                                    foreach (Label label in arrLabel)
                                    {
                                        label.BackColor = Color.Transparent;
                                    }
                                }
                                //make the particular lblPC we click into selected state
                                lbl.BackColor = Color.LightSteelBlue;



                                com = new SqlCommand();
                                com.Connection = frmMain.con;
                                com.CommandType = CommandType.Text;
                                //com.CommandText = "SELECT * FROM tbCustomer";
                                com.CommandText = "SELECT TOP 1 A.accName, rMinutes, aDate, aTime FROM tbCustomer A INNER JOIN tbActiveAccount B ON A.accName=B.accName WHERE A.accName='" + username + "' ORDER BY aAccID DESC";
    
                                dr = com.ExecuteReader();
                                int amountTime = 0;

                                while (dr.Read())
                                {
                                    if (dr[0].ToString() == username)
                                    {
                                        amountTime = int.Parse(dr[1].ToString());
                                        //string part1, part2;
                                        //if (amountTime < 60)
                                        //{
                                        //    part1 = "00";
                                        //    part2 = "" + amountTime;
                                        //}
                                        //else
                                        //{
                                        //    part1 = "" + Math.Floor(amountTime / 60.0);
                                        //    part2 = "" + Math.Ceiling(((amountTime / 60.0) - Math.Floor(amountTime / 60.0)) * 60);
                                        //}

                                        int hour = amountTime / 3600;
                                        int minute = (amountTime % 3600) / 60;
                                        int second = amountTime % 60;

                                        DateTime curTime = Convert.ToDateTime(DateTime.Now.ToString());
                                        DateTime startTime = Convert.ToDateTime(dr[3].ToString());
                                        TimeSpan t = curTime.Subtract(startTime);
                                        
                                        lblRemainedTime.Text = hour + ":" + minute + ":" + second;
                                        lblUsername.Text = username;
                                        lblStartTime.Text = startTime.ToString("hh:mm:ss tt");

                                        

                                        lblUsedTime.Text = t.ToString(@"hh\:mm\:ss");

                                        btnAdd1H.Enabled = true;
                                        btnAdd2H.Enabled = true;
                                        btnAdd3H.Enabled = true;
                                        btnAdd4H.Enabled = true;
                                        btnAdd5H.Enabled = true;
                                        btnAdd6H.Enabled = true;

                                        break;
                                    }
                                }
                                dr.Close();
                                com.Dispose();
                            }
                    }
                    else
                    {
                        lbl.BackColor = Color.Transparent;
                        lblUsername.Text = "N/A";
                        lblStartTime.Text = "00:00";
                        lblUsedTime.Text = "00:00";
                        lblRemainedTime.Text = "00:00";

                        btnAdd1H.Enabled = false;
                        btnAdd2H.Enabled = false;
                        btnAdd3H.Enabled = false;
                        btnAdd4H.Enabled = false;
                        btnAdd5H.Enabled = false;
                        btnAdd6H.Enabled = false;
                    }
            }
        }

        private void countDownTime(Object sender, EventArgs e, string username, int index)
        {

            //if (count[index] == 0) {
            //    remainedTime[index] = amountTime;
            //    count[index]++;
            //}

            com = new SqlCommand();
            com.Connection = frmMain.con;
            com.CommandType = CommandType.Text;
            com.CommandText = "SELECT * FROM tbCustomer";

            dr = com.ExecuteReader();
            int amountTime = 0;

            while (dr.Read())
            {
                if (dr[0].ToString() == username)
                {
                    amountTime = int.Parse(dr[2].ToString());
                }
            }

            dr.Close();
            com.Dispose();



            com = new SqlCommand();
            com.Connection = frmMain.con;
            com.CommandType = CommandType.Text;
            //MessageBox.Show("1 From countDownTime " + remainedTime);
            //remainedTime[index]--;
            com.CommandText = "UPDATE tbCustomer SET rMinutes= " + (amountTime-1) + "WHERE accName='" + username + "'";
            
            //MessageBox.Show("2 From countDownTime " + remainedTime);
            com.ExecuteNonQuery();
            com.Dispose();
        }


        

        private void click_addTime(object sender, EventArgs e) {
            


            Label[] arrLabel = { lblPC1, lblPC2, lblPC3, lblPC4, lblPC5, lblPC6, lblPC7, lblPC8, lblPC9, lblPC10 };
            Label[] arrLabelUser = { lblUser1, lblUser2, lblUser3, lblUser4, lblUser5, lblUser6, lblUser7, lblUser8, lblUser9, lblUser10 };
            string username = "";
            for (int i = 0; i < arrLabel.Length; i++)
            {
                if (arrLabel[i].BackColor == Color.LightSteelBlue)
                {
                    username = arrLabelUser[i].Text;
                    break;
                }
            }
            Button[] arrButton = { btnAdd1H, btnAdd2H, btnAdd3H, btnAdd4H, btnAdd5H, btnAdd6H };
            Button selectedButton = sender as Button;
            int amountTimeToAdd = 0;

            for (int i = 0; i < arrButton.Length; i++)
            {
                if (arrButton[i] == selectedButton)
                {
                    amountTimeToAdd = i + 1;
                    break;
                 }
            }

            DialogResult result = MessageBox.Show("You are about to add " + amountTimeToAdd + " hour(s) into user: " + username, "Cyber Cafe", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


            if (result == DialogResult.Yes)
            {
                com = new SqlCommand();
                com.Connection = frmMain.con;
                com.CommandType = CommandType.Text;
                com.CommandText = "SELECT rMinutes FROM tbCustomer where accName='" + username + "'";

                dr = com.ExecuteReader();
                int amountTime = 0;

                dr.Read();
                amountTime = int.Parse(dr[0].ToString());
                dr.Close();
                com.Dispose();

                com = new SqlCommand();
                com.Connection = frmMain.con;
                com.CommandType = CommandType.Text;
                com.CommandText = "UPDATE tbCustomer SET rMinutes=" + (amountTime + amountTimeToAdd * 3600) + " where accName='" + username + "'";
                com.ExecuteNonQuery();
                com.Dispose();

                com = new SqlCommand("insertPayment",frmMain.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@acc", username);
                com.Parameters.AddWithValue("@orderHour", amountTimeToAdd * 3600);
                com.ExecuteNonQuery();
                com.Dispose();
            }
        }

        private void pnDisplayPC_Click(object sender, EventArgs e)
        {
            lblPC1.BackColor = Color.Transparent;
            lblPC2.BackColor = Color.Transparent;
            lblPC3.BackColor = Color.Transparent;
            lblPC4.BackColor = Color.Transparent;
            lblPC5.BackColor = Color.Transparent;
            lblPC6.BackColor = Color.Transparent;
            lblPC7.BackColor = Color.Transparent;
            lblPC8.BackColor = Color.Transparent;
            lblPC9.BackColor = Color.Transparent;
            lblPC10.BackColor = Color.Transparent;

            lblUsername.Text = "N/A";
            lblStartTime.Text = "00:00";
            lblUsedTime.Text = "00:00";
            lblRemainedTime.Text = "00:00";

            btnAdd1H.Enabled = false;
            btnAdd2H.Enabled = false;
            btnAdd3H.Enabled = false;
            btnAdd4H.Enabled = false;
            btnAdd5H.Enabled = false;
            btnAdd6H.Enabled = false;
        }

        private void label23_Click(object sender, EventArgs e)
        {
            InternetCafeClientProject.ClientRequest.LoopConnect("192.168.1.108");
            InternetCafeClientProject.ClientRequest.SendLoop("YOU ARE TOPPED UP");
            MessageBox.Show("DONE");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.ASCII.GetBytes("Hello");
            try
            {
                
                InternetCafe.ReceiveFromClient.clients[0].BeginSend(data, 0, data.Length, SocketFlags.None, null, InternetCafe.ReceiveFromClient.clients[0]);
                MessageBox.Show("SUCCCESS");
            }
            catch (SocketException ex)
            {
                MessageBox.Show("ERRRROR");
            }
        }
        
            
    }
}

