using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC
{
    public partial class Host : Form
    {
        IPEndPoint IP;
        Socket Server;
        List<Socket> ClientList;
        int n = 0;
        public Host()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        void Connect()
        {
            ClientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 5000);
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            Server.Bind(IP);

            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        Server.Listen(100);
                        Socket Client = Server.Accept();
                        n = n + 1;
                        if (n == 1)
                        {
                            AddMessage("Đã khởi động MC");
                        }
                        else
                        {
                            int nn = n - 1;
                            AddMessage("Người chơi thứ " + nn + " đã kết nối");
                        }
                        ClientList.Add(Client);

                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(Client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 5000);
                    Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();
        }

        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);

                    foreach (Socket item in ClientList)
                    {
                        if (item != null && item != client)
                        {
                            item.Send(Serialize(message));
                        }
                    }
                    for(int i=0;i<ClientList.Count;i++)
                    {
                       ClientList[i].Send(Serialize(message));
                    }
                    AddMessage(message);
                }
            }
            catch
            {
                ClientList.Remove(client);
                client.Close();
            }
        }
        void AddMessage(string s)
        {
            lvOutPut.Items.Add(new ListViewItem() { Text = s });
        }
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }
    }
}
