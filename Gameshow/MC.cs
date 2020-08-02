using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace MC
{
    public partial class mc : Form
    {
        int KtConnect = 0;
        int IntCount = 0;
        IPEndPoint IP;
        Socket Client;
        bool kt = false;
        int Value_NextQs = -1;
        List<CauHoi> list = new List<CauHoi>();

        public mc()
        {
            InitializeComponent();
            pnlCauHoi.Visible = false;
            btnLoadQuestions.Visible = false;
            SoundPlayer modau = new SoundPlayer(@Application.StartupPath + @"\resource\Nhac\modau.wav");
            modau.Play();
            InitalizeServer();
        }

        private void InitalizeServer()
        {
            //start host
            Host host = new Host();
            host.Show();


            CheckForIllegalCrossThreadCalls = false;

            String IPAddress = GetLocalIPAddress();
            Connect(IPAddress);
            if (KtConnect == 1)
            {
                pnlCauHoi.Visible = true;
                btnLoadQuestions.Visible = true;
                CheckNumberQS();
                LoadQs();
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public void RemoveQsSend()
        {
            // Danh cho cau hoi de
            if (kt == false)
            {
                list.RemoveAt(Value_NextQs);
                if (list.Count != 0)
                {
                    if (Value_NextQs != list.Count - 1)
                    {
                        txtQuestion.Text = list[Value_NextQs]._Question;
                        txtA.Text = list[Value_NextQs]._ListAnswer.answerA;
                        txtB.Text = list[Value_NextQs]._ListAnswer.answerB;
                        txtC.Text = list[Value_NextQs]._ListAnswer.answerC;
                        txtD.Text = list[Value_NextQs]._ListAnswer.answerD;
                        txtDA.Text = list[Value_NextQs]._TrueAnswer;
                    }
                    else
                    {
                        Value_NextQs = 0;
                        txtQuestion.Text = list[Value_NextQs]._Question;
                        txtA.Text = list[Value_NextQs]._ListAnswer.answerA;
                        txtB.Text = list[Value_NextQs]._ListAnswer.answerB;
                        txtC.Text = list[Value_NextQs]._ListAnswer.answerC;
                        txtD.Text = list[Value_NextQs]._ListAnswer.answerD;
                        txtDA.Text = list[Value_NextQs]._TrueAnswer;
                    }
                }
                else
                {
                    txtQuestion.Text = "";
                    txtA.Text = "";
                    txtB.Text = "";
                    txtC.Text = "";
                    txtD.Text = "";
                    txtDA.Text = "";
                    btnLoadQuestions.Enabled = false;
                }
            }
        }
            object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }
        void CloseClient()
        {
            Client.Close();
        }
        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    Client.Receive(data);
                    string message = (string)Deserialize(data);
                    if (message == "1")
                    {
                        btnSend.Enabled = true;
                        RemoveQsSend();
                    }
                    else if (message == "0")
                    {
                        btnSend.Enabled = true;
                    }
                }
            }
            catch
            {
                CloseClient();
            }
        }
        void Connect(string s)
        {
            try
            {
                IP = new IPEndPoint(IPAddress.Parse(s), 5000);
            }
            catch
            {
            }
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                Client.Connect(IP);
                KtConnect = 1;
            }
            catch
            {

                return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();

        }
        public void CheckNumberQS()
        {
            lblDe.Text = list.Count.ToString();
        }
       
        public void LoadQs()
        {
            CauHoi temp = null;
            string[] lines = File.ReadAllLines(@Application.StartupPath + @"\resource\DanhSachCauHoi.txt");
            foreach (string s in lines)
            {
                if (s.StartsWith("@@"))
                {
                    temp = new CauHoi();
                    temp._TrueAnswer = s.Substring(2);
                }
                if (s.StartsWith("**"))
                {
                    list.Add(temp);
                }
                if (s.StartsWith("A."))
                {
                    temp._ListAnswer.answerA = s.Substring(2);
                }
                if (s.StartsWith("B."))
                {
                    temp._ListAnswer.answerB = s.Substring(2);
                }
                if (s.StartsWith("C."))
                {
                    temp._ListAnswer.answerC = s.Substring(2);
                }
                if (s.StartsWith("D."))
                {
                    temp._ListAnswer.answerD = s.Substring(2);
                }
                if (s.StartsWith("Q."))
                {
                    temp._Question = s.Substring(2);
                }
            }
        }
        void LoadCauHoi()
        {
            if (list.Count > 0)
            {
                kt = false;
                Value_NextQs++;
                if (Value_NextQs <= list.Count - 1)
                {
                    txtQuestion.Text = list[Value_NextQs]._Question;
                    txtA.Text = list[Value_NextQs]._ListAnswer.answerA;
                    txtB.Text = list[Value_NextQs]._ListAnswer.answerB;
                    txtC.Text = list[Value_NextQs]._ListAnswer.answerC;
                    txtD.Text = list[Value_NextQs]._ListAnswer.answerD;
                    txtDA.Text = list[Value_NextQs]._TrueAnswer;
                }
                else
                {
                    Value_NextQs = 0;
                    txtQuestion.Text = list[Value_NextQs]._Question;
                    txtA.Text = list[Value_NextQs]._ListAnswer.answerA;
                    txtB.Text = list[Value_NextQs]._ListAnswer.answerB;
                    txtC.Text = list[Value_NextQs]._ListAnswer.answerC;
                    txtD.Text = list[Value_NextQs]._ListAnswer.answerD;
                    txtDA.Text = list[Value_NextQs]._TrueAnswer;
                }
            }
        }

        public void XoaCauHoiSauKhiLoad()
        {
            if (kt == false)
            {
                list.RemoveAt(Value_NextQs);
                if (list.Count != 0)
                {
                    if (Value_NextQs != list.Count - 1)
                    {
                        txtQuestion.Text = list[Value_NextQs]._Question;
                        txtA.Text = list[Value_NextQs]._ListAnswer.answerA;
                        txtB.Text = list[Value_NextQs]._ListAnswer.answerB;
                        txtC.Text = list[Value_NextQs]._ListAnswer.answerC;
                        txtD.Text = list[Value_NextQs]._ListAnswer.answerD;
                        txtDA.Text = list[Value_NextQs]._TrueAnswer;
                    }
                    else
                    {
                        Value_NextQs = 0;
                        txtQuestion.Text = list[Value_NextQs]._Question;
                        txtA.Text = list[Value_NextQs]._ListAnswer.answerA;
                        txtB.Text = list[Value_NextQs]._ListAnswer.answerB;
                        txtC.Text = list[Value_NextQs]._ListAnswer.answerC;
                        txtD.Text = list[Value_NextQs]._ListAnswer.answerD;
                        txtDA.Text = list[Value_NextQs]._TrueAnswer;
                    }
                }
                else
                {
                    txtQuestion.Text = "";
                    txtA.Text = "";
                    txtB.Text = "";
                    txtC.Text = "";
                    txtD.Text = "";
                    txtDA.Text = "";
                    btnLoadQuestions.Enabled = false;
                }
            }
        }
        private void btnLoadQuestions_Click(object sender, EventArgs e)
        {
            LoadCauHoi();
            Value_NextQs = 1;
        }

        public bool CheckBeforeSend()
        {
            if (string.IsNullOrEmpty(txtQuestion.Text) == true)
                return false;
            if (string.IsNullOrEmpty(txtA.Text) == true)
                return false;
            if (string.IsNullOrEmpty(txtB.Text) == true)
                return false;
            if (string.IsNullOrEmpty(txtC.Text) == true)
                return false;
            if (string.IsNullOrEmpty(txtD.Text) == true)
                return false;
            if (string.IsNullOrEmpty(txtDA.Text) == true)
                return false;
            return true;
        }
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }
        void Send(string s)
        {
            if (s != "")
            {
                Client.Send(Serialize(s));
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (CheckBeforeSend() == true)
            {
                IntCount++;
                lbcount.Text = IntCount.ToString();
                string question = txtQuestion.Text;
                string a = txtA.Text;
                string b = txtB.Text;
                string c = txtC.Text;
                string d = txtD.Text;
                string da = txtDA.Text;
                string data = string.Format("{0}" + "@" + "{1}" + "@" + "{2}" + "@" + "{3}" + "@" + "{4}" + "@" + "{5}" + "@" + "{6}", da, question, a, b, c, d, IntCount);
                Send(data);
                //RemoveQsSend();
                CheckNumberQS();
                btnSend.Enabled = false;
            }
            else
            {
                MessageBox.Show("Thiếu thông tin câu hỏi !", "Lỗi");
            }
        }

        private void btn_AddQues_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@Application.StartupPath + @"\resource\DanhSachCauHoi.txt",true);
            sw.WriteLine();
            sw.WriteLine("@@" + txtDA.Text);
            sw.WriteLine("Q." + txtQuestion.Text);
            sw.WriteLine("A." + txtA.Text);
            sw.WriteLine("B." + txtB.Text);
            sw.WriteLine("C." + txtC.Text);
            sw.WriteLine("D." + txtD.Text);
            sw.Write("**");
            sw.Close();
            MessageBox.Show("Đã thêm câu hỏi thành công", "Thông báo");
            LoadCauHoi();
        }

        private void btn_hint_answer_MouseHover(object sender, EventArgs e)
        {
            txtDA.Visible = false;
        }

        private void btn_hint_answer_MouseLeave(object sender, EventArgs e)
        {
            txtDA.Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (kt == false)
            {
                if (Value_NextQs < list.Count)
                {
                    txtQuestion.Text = list[Value_NextQs]._Question;
                    txtA.Text = list[Value_NextQs]._ListAnswer.answerA;
                    txtB.Text = list[Value_NextQs]._ListAnswer.answerB;
                    txtC.Text = list[Value_NextQs]._ListAnswer.answerC;
                    txtD.Text = list[Value_NextQs]._ListAnswer.answerD;
                    txtDA.Text = list[Value_NextQs]._TrueAnswer;
                    Value_NextQs++;
                }
                if (Value_NextQs >= list.Count)
                {
                    Value_NextQs = 0;
                    MessageBox.Show("Đã hết câu hỏi", "Thông báo");
                }
            }
        }
    }
 }
