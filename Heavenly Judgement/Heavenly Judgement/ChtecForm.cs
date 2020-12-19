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
    public partial class ChtecForm : Form
    {
        Base dataBase = new Base();
        public string login2 = Main.login;
        public ChtecForm()
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

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exit_MouseMove(object sender, MouseEventArgs e)
        {
            exit.Image = Properties.Resources.CrossChtec;
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
        {if (ProfPanel.BackColor == Color.FromArgb(231, 191, 86))   { ProfPanel.BackColor = Color.Goldenrod; }}
        public void main_hover()
        {if (ProfPanel.BackColor == Color.Goldenrod) { ProfPanel.BackColor = Color.FromArgb(231, 191, 86); } }
        public void soul_leave()
        {if (SoulPanel.BackColor == Color.FromArgb(231, 191, 86)) { SoulPanel.BackColor = Color.Goldenrod; }}
        public void soul_hover()
        {if (SoulPanel.BackColor == Color.Goldenrod) {SoulPanel.BackColor = Color.FromArgb(231, 191, 86); } }
        public void vihod_leave()
        {if (VihodPanel.BackColor == Color.FromArgb(231, 191, 86)) { VihodPanel.BackColor = Color.Goldenrod; } }
        public void vihod_hover()
        {if (VihodPanel.BackColor == Color.Goldenrod) { VihodPanel.BackColor = Color.FromArgb(231, 191, 86); } }
        private void ProfPanel_Click(object sender, EventArgs e)
        {
            this.prof_click();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.prof_click();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.prof_click();
        }
        private void SoulPanel_Click(object sender, EventArgs e)
        {
            this.soul_click();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            this.soul_click();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.soul_click();
        }
        private void VihodPanel_Click(object sender, EventArgs e)
        {
            this.vihod_click();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            this.vihod_click();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
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
            ProfPanel.BackColor = Color.DarkGoldenrod;

            SoulPanel.BackColor = Color.Goldenrod;
            VihodPanel.BackColor = Color.Goldenrod;
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
                labelhi.Text = "Прочитайте их всех!";
            }
            else if (rndhi == 2)
            {
                labelhi.Text = "Судья ждет от вас результатов!";
            }
            else if (rndhi == 3)
            {
                labelhi.Text = "Перейдите на вкладку 'Души', чтобы прочесть их.";
            }

            string chtecid = String.Format("Select id From Sotrud Where login = '{0}'", Main.login);
            labelLogin.Text = dataBase.GetFio(chtecid);
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
            SoulPanel.BackColor = Color.DarkGoldenrod;

            ProfPanel.BackColor = Color.Goldenrod;
            VihodPanel.BackColor = Color.Goldenrod;
            panelVihod.Visible = false;
            panel2.Visible = false;
            panel5.Visible = true;

            string fio = String.Format("SELECT fio FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='1')");
            label12.Text = dataBase.GetFio(fio);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string p1 = "";
            string p2 = "";
            string p3 = "";
            string p4 = "";
            string p5 = "";
            string p6 = "";
            string p7 = "";
            Random rnd = new Random();
            int rndP1 = rnd.Next(0, 3);
            int rndP2 = rnd.Next(0, 3);
            int rndP3 = rnd.Next(0, 3);
            int rndP4 = rnd.Next(0, 3);
            int rndP5 = rnd.Next(0, 3);
            int rndP6 = rnd.Next(0, 3);
            int rndP7 = rnd.Next(0, 3);
            if (rndP1 == 0) p1 = "Гордость. ";
            if (rndP2 == 0) p2 = "Зависть. ";
            if (rndP3 == 0) p3 = "Чревоугодие. ";
            if (rndP4 == 0) p4 = "Блуд. ";
            if (rndP5 == 0) p5 = "Гнев. ";
            if (rndP6 == 0) p6 = "Алчность. ";
            if (rndP7 == 0) p7 = "Лень.";
            if (rndP1 != 0 && rndP2 != 0 && rndP3 != 0 && rndP4 != 0 && rndP5 != 0 && rndP6 != 0 && rndP7 != 0) { p1 = "Эта душа безгрешна."; }
            textBox2.Text = (p1 + p2 + p3 + p4 + p5 + p6 + p7);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string p1 = "";
            string p2 = "";
            string p3 = "";
            string p4 = "";
            string p5 = "";
            string p6 = "";
            string p7 = "";
            string p8 = "";
            string p9 = "";
            string p10 = "";
            Random rnd = new Random();
            int rndP1 = rnd.Next(0, 3);
            int rndP2 = rnd.Next(0, 4);
            int rndP3 = rnd.Next(0, 3);
            int rndP4 = rnd.Next(0, 3);
            int rndP5 = rnd.Next(0, 3);
            int rndP6 = rnd.Next(0, 5);
            int rndP7 = rnd.Next(0, 3);
            int rndP8 = rnd.Next(0, 4);
            int rndP9 = rnd.Next(0, 5);
            int rndP10 = rnd.Next(0, 5);
            if (rndP1 == 0) p1 = "Щедрость. ";
            if (rndP2 == 0) p2 = "Усредие.  ";
            if (rndP3 == 0) p3 = "Терпеливость. ";
            if (rndP4 == 0) p4 = "Милосердие. ";
            if (rndP5 == 0) p5 = "Доброта. ";
            if (rndP6 == 0) p6 = "Смиренность. ";
            if (rndP7 == 0) p7 = "Честность. ";
            if (rndP8 == 0) p8 = "Смелость. ";
            if (rndP9 == 0) p9 = "Снятие котиков с деревьев. ";
            if (rndP10 == 0) p10= "Перевод старушек через дорогу.";

            if (rndP1 != 0 && rndP2 != 0 && rndP3 != 0 && rndP4 != 0 && rndP5 != 0 && rndP6 != 0 && rndP7 != 0 && rndP8 != 0 && rndP9 != 0 && rndP10 != 0) 
            { p1 = "Эта душа никчемна."; }
            textBox1.Text = (p1 + p2 + p3 + p4 + p5 + p6 + p7 + p8 + p9 + p10);
        }
        private void panel7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                panelOk.Visible = true;
                button1.Enabled = false;
                button2.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                panel1.Enabled = false;
                panel7.Enabled = false;
                exit.Visible = false;

            }
            else
            {
                panel8.Visible = true;
                button1.Enabled = false;
                button2.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                panel1.Enabled = false;
                panel7.Enabled = false;
                exit.Visible = false;
            }
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
                panel8.Visible = false;
                button1.Enabled = true;
                button2.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                panel1.Enabled = true;
            panel7.Enabled = true;
            exit.Visible = true;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            panelOk.Visible = false;
            panel9.Visible = true;

            string id = String.Format("SELECT id FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='1')");
            string grehi = textBox2.Text.ToString();
            string zaslugi = textBox1.Text.ToString();
            Base.ChtecSoul(dataBase.GetFio(id), zaslugi, grehi);
            if (login2 != "")
            {
                Base.PointPluse(login2);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            panelOk.Visible = false;
            panel6.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            panel1.Enabled = true;
            panel7.Enabled = true;
            exit.Visible = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
            panel6.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            panel1.Enabled = true;
            panel7.Enabled = true;
            exit.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            string fio = String.Format("SELECT fio FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='1')");
            label12.Text = dataBase.GetFio(fio);
        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.DarkGoldenrod;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Goldenrod;
        }
        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.DarkGoldenrod;
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Goldenrod;
        }
        private void label16_MouseMove(object sender, MouseEventArgs e)
        {
            panel7.BackColor = Color.DarkGoldenrod; 
        }
        private void label16_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Goldenrod;
        }
        #endregion
        #region Выход
        public void vihod_click()
        {
            VihodPanel.BackColor = Color.DarkGoldenrod;

            ProfPanel.BackColor = Color.Goldenrod;
            SoulPanel.BackColor = Color.Goldenrod;
            panel2.Visible = false;
            panelVihod.Visible = true;
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
            pictureBox3.BackgroundImage = Properties.Resources.Chtec2;
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.Chtec;
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
