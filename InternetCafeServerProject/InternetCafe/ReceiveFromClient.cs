using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace InternetCafe
{
    public class ReceiveFromClient
    {
        static SqlCommand com;
        static SqlDataReader dr;
        static IPAddress ipAd = IPAddress.Parse("192.168.43.2327");
        static byte[] buffer = new byte[1024];
        public static List<Socket> clients = new List<Socket>();
        static Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static string text = "";
        //static void Main(string[] args)
        //{
        //    Console.Title = "Server";
        //    setupServer();
        //    Console.ReadLine();
        //}
        public static void setupServer()
        {
            //Console.WriteLine("Setting up server....");
            server.Bind(new IPEndPoint(ipAd, 100));
            //server.Bind(new IPEndPoint(IPAddress.Any, 100));
            server.Listen(5);
            server.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }
        static void AcceptCallback(IAsyncResult AR)
        {
            
            Socket socket = server.EndAccept(AR);
            clients.Add(socket);
            //Console.WriteLine("Client connected");
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            server.BeginAccept(new AsyncCallback(AcceptCallback), null);

        }

        //private static void timeCountPause(Object sender, EventArgs e)
        //{
        //    timeCount++;
        //}

        static void ReceiveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int received = socket.EndReceive(AR);
            byte[] dataBuff = new byte[received];
            Array.Copy(buffer, dataBuff, received);
            text = Encoding.ASCII.GetString(dataBuff);
            Console.WriteLine("Received text: " + text);
            //try
            //{
                //InternetCafe.frmHome.label5.Visible = false;
            //}
            //catch (InvalidOperationException ex) { }
            string respond = string.Empty;
            if (text.ToLower() != "get time")
            {
                
                string[] receiveTextSplit = text.Split('|');
                if (receiveTextSplit[0] == "Topup")
                {

                    DialogResult dialog = MessageBox.Show("User " + receiveTextSplit[1] + " is requesting for topping up " + int.Parse(receiveTextSplit[2]) + " hours", "Client Request", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {

                        com = new SqlCommand();
                        com.Connection = frmMain.con;
                        com.CommandType = CommandType.Text;
                        com.CommandText = "SELECT rMinutes FROM tbCustomer where accName='" + receiveTextSplit[1] + "'";

                        dr = com.ExecuteReader();
                        int amountTime = 0;

                        dr.Read();
                        amountTime = int.Parse(dr[0].ToString());
                        dr.Close();
                        com.Dispose();

                        com = new SqlCommand();
                        com.Connection = frmMain.con;
                        com.CommandType = CommandType.Text;
                        com.CommandText = "UPDATE tbCustomer SET rMinutes=" + (amountTime + int.Parse(receiveTextSplit[2]) * 3600) + " where accName='" + receiveTextSplit[1] + "'";
                        com.ExecuteNonQuery();
                        com.Dispose();

                        com = new SqlCommand("insertPayment", frmMain.con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@acc", receiveTextSplit[1]);
                        com.Parameters.AddWithValue("@orderHour", int.Parse(receiveTextSplit[2]) * 3600);
                        com.ExecuteNonQuery();
                        com.Dispose();

                        respond = "Done|" + (amountTime + int.Parse(receiveTextSplit[2])*3600) +"|" + receiveTextSplit[4];
                    }
                    else
                    {
                        respond = "Your request has been cancelled";
                    }
                }
                else {
                    respond = "You are connected";
                }
                
            }
            else
            {
                respond = DateTime.Now.ToLongTimeString();
            }
            byte[] data = Encoding.ASCII.GetBytes(respond);
            try
            {
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            }
            catch (SocketException ex)
            {

            }
        }
        static void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

    }
}
