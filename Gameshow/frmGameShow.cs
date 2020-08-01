using MC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Gameshow
{
    public partial class MC : Form
    {
        public MC()
        {
            InitializeComponent();
        }
        Timer gameTimer = new Timer();

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeX_Tick(sender, e);
        }

        int OrigTime = 1800;
        void timeX_Tick(object sender, EventArgs e)
        {
            OrigTime--;
            txtCountDown.Text = OrigTime / 60 + ":" + ((OrigTime % 60) >= 10 ? (OrigTime % 60).ToString() : "0" + OrigTime % 60);
            if (OrigTime <= 0)
            {
                gameTimer.Enabled = false;
                btnStart.Enabled = true;
            }
        }

        private void MC_Load(object sender, EventArgs e)
        {
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            List<GameShow> lst = new List<GameShow>();
            lst.Add(
               new GameShow()
               {
                   Id = 1,
                   Name = "Ai là triệu phú",
                   StartDate = DateTime.Now.AddSeconds(1),
                   EndDate = DateTime.Now.AddMinutes(30)
               });

            lst.Add(
               new GameShow()
               {
                   Id = 2,
                   Name = "Nhanh như chớp",
                   StartDate = DateTime.Now.AddDays(1),
                   EndDate = DateTime.Now.AddDays(1).AddMinutes(30)
               });

            lst.Add(
               new GameShow()
               {
                   Id = 3,
                   Name = "Đấu trường 100",
                   StartDate = DateTime.Now.AddDays(2),
                   EndDate = DateTime.Now.AddDays(2).AddMinutes(30)
               });

            lst.Add(
               new GameShow()
               {
                   Id = 4,
                   Name = "Chiếc nón kì diệu",
                   StartDate = DateTime.Now.AddDays(3),
                   EndDate = DateTime.Now.AddDays(3).AddMinutes(30)
               });

            grvGameShow.DataSource = lst;
            var nearestGameShow = lst[0];
            lblName.Text = nearestGameShow.Name;
            lbDay.Text = nearestGameShow.StartDate.ToString("dd/MM/yyyy");
            lbHour.Text = nearestGameShow.StartDate.ToString("hh:mm");
            OrigTime = (int)Math.Round((nearestGameShow.StartDate - DateTime.Now).TotalSeconds, 0);
            gameTimer.Enabled = true;
            SoundPlayer gioithieu = new SoundPlayer(@Application.StartupPath + @"\resource\Nhac\allafigaro-khongloi.wav");
            gioithieu.Play();
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            mc mc = new mc();
            mc.Show();
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
