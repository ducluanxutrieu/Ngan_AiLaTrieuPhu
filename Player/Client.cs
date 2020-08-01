using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace Player
{
    public partial class Client : Form
    {
        IPEndPoint IP;
        Socket client;
        public int KtConnect = 0;
        string _Yes = "1";
        string _NO = "0";
        int Intcount = 0;
        public string DA = null;
        public bool Time = false;
        public bool b50 = true;
        public bool bgoi = true;
        public bool bkhangia = true;
        public Client()
        {
            InitializeComponent();
            pbl_Question.Visible = false;
            gbScore.Visible = false;            
            lblTG.Visible = false;
            InitializeLogin();

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
        public void scores(int cau)
        {
            switch (cau)
            {
                case 1: btnDiem.Text = "200.000"; break;
                case 2: btnDiem.Text = "400.000"; break;
                case 3: btnDiem.Text = "600.000"; break;
                case 4: btnDiem.Text = "1.000.000"; break;
                case 5: btnDiem.Text = "2.000.000"; break;
                case 6: btnDiem.Text = "3.000.000"; break;
                case 7: btnDiem.Text = "6.600.000"; break;
                case 8: btnDiem.Text = "10.000.000"; break;
                case 9: btnDiem.Text = "14.000.000"; break;
                case 10: btnDiem.Text = "22.000.000"; break;
                case 11: btnDiem.Text = "30.000.000"; break;
                case 12: btnDiem.Text = "40.000.000"; break;
                case 13: btnDiem.Text = "60.000.000"; break;
                case 14: btnDiem.Text = "85.000.000"; break;
                case 15: btnDiem.Text = "150.000.000"; break;
            }
        }
        private void EnabledTruebtn()
        {
            btnA.Enabled = true;
            btnB.Enabled = true;
            btnC.Enabled = true;
            btnD.Enabled = true;
        }
        private void ResetColorbtn()
        {
            btnA.ForeColor = Color.PaleGreen;
            btnB.ForeColor = Color.PaleGreen;
            btnC.ForeColor = Color.PaleGreen;
            btnD.ForeColor = Color.PaleGreen;
        }
        void _Close()
        {
            client.Close();
        }
        void Send(string s)
        {
            if (s != "")
            {
                client.Send(Serialize(s));
            }
        }
        void Receive()
        {
            try
            {
                while (true)
                {
                    btnA.Visible = true;
                    btnB.Visible = true;
                    btnC.Visible = true;
                    btnD.Visible = true;
                    byte[] message = new byte[1024 * 5000];
                    client.Receive(message);
                    string data = (string)Deserialize(message);
                    DA = data.Substring(0, data.IndexOf("@"));

                    data = data.Remove(0, data.IndexOf("@") + 1);
                    lblQuestion.Text = data.Substring(0, data.IndexOf("@"));


                    data = data.Remove(0, data.IndexOf("@") + 1);
                    btnA.Text = data.Substring(0, data.IndexOf("@"));

                    data = data.Remove(0, data.IndexOf("@") + 1);
                    btnB.Text = data.Substring(0, data.IndexOf("@"));

                    data = data.Remove(0, data.IndexOf("@") + 1);
                    btnC.Text = data.Substring(0, data.IndexOf("@"));

                    data = data.Remove(0, data.IndexOf("@") + 1);
                    btnD.Text = data.Substring(0, data.IndexOf("@"));
                    data = data.Remove(0, data.IndexOf("@") + 1);
                    Intcount = int.Parse(data);
                    scores(Intcount);
                    //BackColorbtnScores(Intcount);
                    EnabledTruebtn();
                    ResetColorbtn();
                    Time = true;
                }
            }
            catch
            {
                _Close();
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
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(IP);
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
        private void InitializeLogin()
        {
            CheckForIllegalCrossThreadCalls = false;
            String IPAddress = GetLocalIPAddress();
            Connect(IPAddress);
            if (KtConnect == 1)
            {
                pbl_Question.Visible = true;
                gbScore.Visible = true;
                lblTG.Visible = true;
            }
            else
            {
                MessageBox.Show("Bạn đã điền thiếu thông tin hoặc sai", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnDungchoi_Click(object sender, EventArgs e)
        {

        }
        public int STEP = 1000;
        public int TimeDown = 10000;
        public int Interval = 1000;
        int DemTG = 0;
        string chon = "";

        private void tmDemTg_Tick(object sender, EventArgs e)
        {
            if (DemTG >= 4)
            {
                tmDemTg.Stop();
                DemTG = 0;
                CheckDA();
            }
            else DemTG++;
        }
        static int SLDAD = 0;

        private void CheckDA()
        {
            if (chon == DA)
            {
                SoundPlayer NhacChonDung = new SoundPlayer(@Application.StartupPath + @"\resource\Sounds\dap\dung.wav");
                NhacChonDung.Play();
                chon = "";
                Send(_Yes);
                if (chon == "A")
                {
                    btnA.ForeColor = Color.Blue;
                }
                else if (chon == "B")
                {
                    btnB.ForeColor = Color.Blue;
                }
                else if (chon == "C")
                {
                    btnC.ForeColor = Color.Blue;
                }
                else if (chon == "D")
                {
                    btnD.ForeColor = Color.Blue;
                }
                SLDAD++;

            }
            else
            {
                if (DA == "A")
                {
                    SoundPlayer NhacChonSaiA = new SoundPlayer(@Application.StartupPath + @"\resource\Sounds\dap\asai.wav");
                    btnA.ForeColor = Color.Blue;
                    NhacChonSaiA.Play();
                }

                else
                {
                    if (DA == "B")
                    {
                        SoundPlayer NhacChonSaiB = new SoundPlayer(@Application.StartupPath + @"\resource\Sounds\dap\bsai.wav");
                        btnB.ForeColor = Color.Blue;
                        NhacChonSaiB.Play();
                    }
                    else
                    {
                        if (DA == "C")
                        {
                            SoundPlayer NhacChonSaiC = new SoundPlayer(@Application.StartupPath + @"\resource\Sounds\dap\csai.wav");
                            btnC.ForeColor = Color.Blue;
                            NhacChonSaiC.Play();
                        }
                        else
                        {
                            SoundPlayer NhacChonSaiD = new SoundPlayer(@Application.StartupPath + @"\resource\Sounds\dap\dsai.wav");
                            btnD.ForeColor = Color.Blue;
                            this.Opacity = 10;
                            NhacChonSaiD.Play();
                        }
                    }
                }
                chon = "";
                Send(_NO);
                DialogResult _KQ = MessageBox.Show("Bạn Đã Thua Cuộc, Kết thúc lượt chơi tại đây, hẹn gặp bạn ở số tiếp theo!!!!", "Thong bao", MessageBoxButtons.OK);
                if (_KQ == DialogResult.OK)
                {
                    Close();
                    _Close();
                }
            }
            Time = false;
            lblTG.Text = "60";
        }
        private void EnabledFalsebtn()
        {
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
        }
        private void btnA_Click(object sender, EventArgs e)
        {
            DialogResult _result = MessageBox.Show("Bạn có chắc chắn chọn đáp án A ?", "Thông Báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (_result == DialogResult.OK)
            {
                SoundPlayer NhacChon = new SoundPlayer(@Application.StartupPath + @"\resource\Sounds\chon\a.wav");
                NhacChon.Play();
                chon = "A";
                tmDemTg.Start();
                EnabledFalsebtn();
                btnA.ForeColor = Color.Red;
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            DialogResult _result = MessageBox.Show("Bạn có chắc chắn chọn đáp án C ?", "Thông Báo",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (_result == DialogResult.OK)
            {
                SoundPlayer NhacChon = new SoundPlayer(@Application.StartupPath + @"\resource\Sounds\chon\c.wav");
                NhacChon.Play();
                chon = "C";
                tmDemTg.Start();
                EnabledFalsebtn();
                btnC.ForeColor = Color.Red;
            }
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            DialogResult _result = MessageBox.Show("Bạn có chắc chắn chọn đáp án B ?", "Thông Báo",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (_result == DialogResult.OK)
            {
                SoundPlayer NhacChon = new SoundPlayer(@Application.StartupPath + @"\resource\Sounds\chon\b.wav");
                NhacChon.Play();
                chon = "B";
                tmDemTg.Start();
                EnabledFalsebtn();
                btnB.ForeColor = Color.Red;
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            DialogResult _result = MessageBox.Show("Bạn có chắc chắn chọn đáp án D ?", "Thông Báo",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (_result == DialogResult.OK)
            {
                SoundPlayer NhacChon = new SoundPlayer(@Application.StartupPath + @"\resource\Sounds\chon\d.wav");
                NhacChon.Play();
                chon = "D";
                tmDemTg.Start();
                EnabledFalsebtn();
                btnD.ForeColor = Color.Red;
            }
        }
    }
}
