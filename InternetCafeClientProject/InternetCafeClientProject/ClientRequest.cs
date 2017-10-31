using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetCafeClientProject
{
    class ClientRequest
    {


        static Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //static void Main(string[] args)
        //{
        //    Console.Title = "Client";
        //    LoopConnect();    
        //    SendLoop("q");
        //    Console.ReadLine();
        //}


        public static void SendLoop(String req)
        {

            //while (true)
            //{

                Console.Write("Enter a request: ");
                // string req = Console.ReadLine();
                byte[] buffer = Encoding.ASCII.GetBytes(req);
                    client.Send(buffer);

                byte[] receiveBuff = new byte[1024];
                int rec = client.Receive(receiveBuff);
                byte[] data = new byte[rec];
                Array.Copy(receiveBuff, data, rec); 
                Console.WriteLine("Received: " + Encoding.ASCII.GetString(data));
            //}
        }
        public static void LoopConnect()
        {
            int attempt = 0;
            while (!client.Connected)
            {
                try
                {
                    attempt++;
                    //client.Connect("172.20.10.3", 100);
                    client.Connect("127.0.0.1", 100);
                }
                catch (SocketException)
                {
                    
                        //Console.Clear();
                     
                        DialogResult dialog = MessageBox.Show("Try again later", "System Disconnect", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes) {
                         System.Environment.Exit(0);
                         
                        
                    
                    }
                    
                   // Console.WriteLine("Connection attempts: " + attempt.ToString());
                }
            }

        }
    }

}
