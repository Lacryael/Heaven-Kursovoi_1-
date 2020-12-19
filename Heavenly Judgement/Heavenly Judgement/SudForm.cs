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
using System.Text.RegularExpressions;

namespace Heavenly_Judgement
{
    public partial class SudForm : Form
    {
        Base dataBase = new Base();
        public string login2 = Main.login;
        public int status = 2;
        public string mesto = "";
        public SudForm()
        {
            InitializeComponent();
            exit.Image = Properties.Resources.Cross;
            Opacity = 0;
            Timer timer = new Timer();
            timer.Tick += new EventHandler((sender, e) =>
            {
                if ((Opacity += 0.05d) == 1) timer.Stop();
            });
            timer.Interval = 10;
            timer.Start();

            this.prof_click();

        }
        #region Меню
        private void ChtecForm_Load(object sender, EventArgs e)
        {

        }
        private void SudForm_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exit_MouseMove(object sender, MouseEventArgs e)
        {
            exit.Image = Properties.Resources.CrossSud;
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.Image = Properties.Resources.Cross;
        }
        private void ChtecForm_MouseDown(object sender, MouseEventArgs e)
        {

            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        public void main_leave()
        { if (ProfPanel.BackColor == Color.FromArgb(228, 169, 169)) { ProfPanel.BackColor = Color.LightCoral; } }
        public void main_hover()
        { if (ProfPanel.BackColor == Color.LightCoral) { ProfPanel.BackColor = Color.FromArgb(228, 169, 169); } }
        public void soul_leave()
        { if (SoulPanel.BackColor == Color.FromArgb(228, 169, 169)) { SoulPanel.BackColor = Color.LightCoral; } }
        public void soul_hover()
        { if (SoulPanel.BackColor == Color.LightCoral) { SoulPanel.BackColor = Color.FromArgb(228, 169, 169); } }
        public void vihod_leave()
        { if (VihodPanel.BackColor == Color.FromArgb(228, 169, 169)) { VihodPanel.BackColor = Color.LightCoral; } }
        public void vihod_hover()
        { if (VihodPanel.BackColor == Color.LightCoral) { VihodPanel.BackColor = Color.FromArgb(228, 169, 169); } }
        private void ProfPanel_Click(object sender, EventArgs e)
        {
            this.prof_click();
        }
        private void SoulPanel_Click(object sender, EventArgs e)
        {
            this.soul_click();
        }
        private void VihodPanel_Click(object sender, EventArgs e)
        {
            this.vihod_click();
        }
        private void ProfPanel_MouseMove_1(object sender, MouseEventArgs e)
        {
            this.main_hover();
        }
        private void SoulPanel_MouseMove(object sender, MouseEventArgs e)
        {
            this.soul_hover();
        }
        private void VihodPanel_MouseMove(object sender, MouseEventArgs e)
        {
            this.vihod_hover();
        }
        private void ProfPanel_MouseLeave(object sender, EventArgs e)
        {
            this.main_leave();
        }
        private void SoulPanel_MouseLeave(object sender, EventArgs e)
        {
            this.soul_leave();
        }
        private void VihodPanel_MouseLeave(object sender, EventArgs e)
        {
            this.vihod_leave();
        }
        #endregion
        #region Профиль
        public void prof_click()
        {
            ProfPanel.BackColor = Color.IndianRed;

            SoulPanel.BackColor = Color.LightCoral;
            VihodPanel.BackColor = Color.LightCoral;
            panelVihod.Visible = false;
            panel2.Visible = true;
            panel5.Visible = false;

            Random rnd = new Random();
            int rndhi = rnd.Next(0, 4);
            if (rndhi == 0)
            {
                labelhi.Text = "Работайте усредно, чтобы скорее оказаться на дне!";
            }
            else if (rndhi == 1)
            {
                labelhi.Text = "Засудите их всех!";
            }
            else if (rndhi == 2)
            {
                labelhi.Text = "В аду требуют больше душ!";
            }
            else if (rndhi == 3)
            {
                labelhi.Text = "Перейдите на вкладку 'Души', чтобы начать суд.";
            }
            labelLogin.Text = Main.login;
            string point = String.Format("Select point From Sotrud Where login = '{0}'", Main.login);
            labelPoint.Text = dataBase.GetFio(point);
            point = labelPoint.Text;
            int rang = 0;
            if (Convert.ToInt32(point) == 0)
            {
                rang = 9;
            }
            else if (Convert.ToInt32(point) > 1 && Convert.ToInt32(point) < 100)
            {
                rang = 8;
            }
            else if (Convert.ToInt32(point) > 101 && Convert.ToInt32(point) < 1000)
            {
                rang = 7;
            }
            else if (Convert.ToInt32(point) > 1001 && Convert.ToInt32(point) < 10000)
            {
                rang = 6;
            }
            else if (Convert.ToInt32(point) > 10001 && Convert.ToInt32(point) < 100000)
            {
                rang = 5;
            }
            else if (Convert.ToInt32(point) > 100001 && Convert.ToInt32(point) < 1000000)
            {
                rang = 4;
            }
            else if (Convert.ToInt32(point) > 1000001 && Convert.ToInt32(point) < 10000000)
            {
                rang = 3;
            }
            else if (Convert.ToInt32(point) > 10000001 && Convert.ToInt32(point) < 999999999)
            {
                rang = 2;
            }
            else rang = 1;
            labelRang.Text = Convert.ToString(rang);
        }
        #endregion
        #region Души
        public void soul_click()
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(pictureAd, "В АД!");
            t.SetToolTip(pictureRai, "В РАЙ!");

            SoulPanel.BackColor = Color.IndianRed;

            ProfPanel.BackColor = Color.LightCoral;
            VihodPanel.BackColor = Color.LightCoral;
            panelVihod.Visible = false;
            panel2.Visible = false;
            panel5.Visible = true;

            string fio = String.Format("SELECT fio FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='2')");
            label12.Text = dataBase.GetFio(fio);
            string grehi = String.Format("SELECT grehi FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='2')");
            grehibox.Text = dataBase.GetFio(grehi);
            string blag = String.Format("SELECT zaslugi FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='2')");
            blagbox.Text = dataBase.GetFio(blag);
            string smert = String.Format("SELECT smert FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='2')");
            smertbox.Text = dataBase.GetFio(smert);
        }
        private void pictureAd_Click(object sender, EventArgs e)
        {
            panelOk.Visible = true;
            pictureAd.Enabled = false;
            pictureRai.Enabled = false;
            panel1.Enabled = false;
            exit.Visible = false;
            label18.Text = "Заслуживает ли эта душа попасть в ад?";

            status = 4;
            mesto = "Ад";
        }
        private void pictureRai_Click(object sender, EventArgs e)
        {
            panelOk.Visible = true;
            pictureAd.Enabled = false;
            pictureRai.Enabled = false;
            panel1.Enabled = false;
            exit.Visible = false;
            label18.Text = "Заслуживает ли эта душа попасть в рай?";

            status = 3;
            mesto = "Рай";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panelOk.Visible = false;
            panel9.Visible = true;

            string id = String.Format("SELECT id FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='2')");
            Base.SudSoul(dataBase.GetFio(id), status, mesto);
            int ochered = 0;
            Base.OcheredPluse(ochered);
            if (login2 != "")
            {
                Base.PointPluse(login2);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
            pictureAd.Enabled = true;
            pictureRai.Enabled = true;
            panel1.Enabled = true;
            exit.Visible = true;
            status = 2;
            mesto = "";
            this.soul_click();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            panelOk.Visible = false;
            pictureAd.Enabled = true;
            pictureRai.Enabled = true;
            panel1.Enabled = true;
            exit.Visible = true;
            status = 2;
            mesto = "";
        }
        private void pictureAd_MouseMove(object sender, MouseEventArgs e)
        {
            pictureAd.BackgroundImage = Properties.Resources.Ad2;
        }
        private void pictureAd_MouseLeave(object sender, EventArgs e)
        {
            pictureAd.BackgroundImage = Properties.Resources.Ad;
        }
        private void pictureRai_MouseMove(object sender, MouseEventArgs e)
        {
            pictureRai.BackgroundImage = Properties.Resources.Rai2;
        }
        private void pictureRai_MouseLeave(object sender, EventArgs e)
        {
            pictureRai.BackgroundImage = Properties.Resources.Rai;
        }
        #endregion
        #region Выход
        public void vihod_click()
        {
            VihodPanel.BackColor = Color.IndianRed;

            ProfPanel.BackColor = Color.LightCoral;
            SoulPanel.BackColor = Color.LightCoral;

            panelVihod.Visible = true;
            panel2.Visible = false;
            panel5.Visible = false;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Main.login = "";
            Main main = new Main();
            this.Hide();
            main.Show();
        }
        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.Sudya3;
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.Sudya;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.prof_click();
        }
        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.BackgroundImage = Properties.Resources.Cross;
        }
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = Properties.Resources.CrossControl;
        }
        #endregion

    }
}
