using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Heavenly_Judgement
{
    public partial class DeathForm : Form
    {
        Base dataBase = new Base();
        public string login2 = Main.login;
        public DeathForm()
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
        private void ProfPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.prof_click();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.prof_click();
        }

        private void SoulPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {
            this.soul_click();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.soul_click();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.vihod_click();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.vihod_click();
        }

        private void VihodPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeathForm_Load(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exit_MouseMove(object sender, MouseEventArgs e)
        {
            exit.Image = Properties.Resources.CrossDeath;
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.Image = Properties.Resources.Cross;
        }

        private void DeathForm_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        public void main_hover()
        {
            if (ProfPanel.BackColor == Color.FromArgb(50, 50, 50))
            {
                ProfPanel.BackColor = Color.FromArgb(70, 70, 70);
            }

        }
        public void main_leave()
        {
            if (ProfPanel.BackColor == Color.FromArgb(70, 70, 70))
            {
                ProfPanel.BackColor = Color.FromArgb(50, 50, 50);
            }
        }
        public void soul_hover()
        {
            if (SoulPanel.BackColor == Color.FromArgb(50, 50, 50))
            {
                SoulPanel.BackColor = Color.FromArgb(70, 70, 70);
            }
        }
        public void soul_leave()
        {
            if (SoulPanel.BackColor == Color.FromArgb(70, 70, 70))
            {
                SoulPanel.BackColor = Color.FromArgb(50, 50, 50);
            }
        }
        public void vihod_hover()
        {
            if (VihodPanel.BackColor == Color.FromArgb(50, 50, 50))
            {
                VihodPanel.BackColor = Color.FromArgb(70, 70, 70);
            }

        }
        public void vihod_leave()
        {
            if (VihodPanel.BackColor == Color.FromArgb(70, 70, 70))
            {
                VihodPanel.BackColor = Color.FromArgb(50, 50, 50);
            }
        }

        private void MainPanel_MouseHover(object sender, EventArgs e)
        {
            this.main_hover();
        }

        private void MainPanel_MouseLeave(object sender, EventArgs e)
        {
            this.main_leave();
        }

        private void OcheredPanel_MouseHover(object sender, EventArgs e)
        {
            this.soul_hover();
        }

        private void OcheredPanel_MouseLeave(object sender, EventArgs e)
        {
            this.soul_leave();
        }

        private void VhodPanel_MouseHover(object sender, EventArgs e)
        {
            this.vihod_hover();
        }

        private void VhodPanel_MouseLeave(object sender, EventArgs e)
        {
            this.vihod_leave();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            this.soul_hover();
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            this.soul_leave();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            this.soul_hover();
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.soul_leave();
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            this.vihod_hover();
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            this.vihod_leave();
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            this.vihod_hover();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.vihod_leave();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            this.main_hover();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.main_leave();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.main_hover();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.main_leave();
        }

        private void ProfPanel_MouseMove(object sender, MouseEventArgs e)
        {
            this.main_hover();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            this.main_hover();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.main_hover();
        }

        private void SoulPanel_MouseMove(object sender, MouseEventArgs e)
        {
            this.soul_hover();
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            this.soul_hover();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            this.soul_hover();
        }

        private void VihodPanel_MouseMove(object sender, MouseEventArgs e)
        {
            this.vihod_hover();
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            this.vihod_hover();
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            this.vihod_hover();
        }
        #endregion
        #region Профиль
        public void prof_click()
        {
            ProfPanel.BackColor = Color.DimGray;

            SoulPanel.BackColor = Color.FromArgb(50,50,50);
            VihodPanel.BackColor = Color.FromArgb(50, 50, 50);
            panelVihod.Visible = false;
            panel5.Visible = false;
            panel2.Visible = true;

            Random rnd = new Random();
            int rndhi = rnd.Next(0, 4);
            if (rndhi == 0)
            {
                labelhi.Text = "Работайте усредно, чтобы скорее оказаться на дне!";
            }
            else if (rndhi == 1)
            {
                labelhi.Text = "Убейте как можно больше за этот чудесный день!";
            }
            else if (rndhi == 2)
            {
                labelhi.Text = "Сегодня многие умрут благодаря вам!";
            }
            else if (rndhi == 3)
            {
                labelhi.Text = "Перейдите на вкладку 'Души', чтобы начать жатву.";
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
            SoulPanel.BackColor = Color.DimGray;

            ProfPanel.BackColor = Color.FromArgb(50, 50, 50);
            VihodPanel.BackColor = Color.FromArgb(50, 50, 50);
            panelVihod.Visible = false;
            panel2.Visible = false;
            panel5.Visible = true;
        }
        private void panel6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                panelOk.Visible = true;
                panel6.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                panel1.Enabled = false;
                exit.Visible = false;

            }
            else
            {
                panel7.Visible = true;
                panel6.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                panel1.Enabled = false;
                exit.Visible = false;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel6.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            panel1.Enabled = true;
            exit.Visible = true;
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
            exit.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panelOk.Visible = false;
            panel8.Visible = true;

            string fio = textBox1.Text.ToString();
            string gender = comboBox1.Text.ToString();
            object dater = dateTimePicker1.Value;
            object dates = dateTimePicker2.Value;
            string smert = textBox2.Text.ToString();
            Base.AddSoul(fio, gender, dater, dates, smert);

            if (login2 != "")
            {
                Base.PointPluse(login2);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
            panel6.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            panel1.Enabled = true;
            exit.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }
        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            panel6.BackColor = Color.FromArgb(50, 0, 0);
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(50, 50, 50);
        }
        private void button1_Click(object sender, EventArgs e)//Кто
        {
            string f = "";
            string i = "";
            string o = "";
            Random rnd = new Random();
            int rndG = rnd.Next(0, 2);
            int rndF = rnd.Next(0, 83);
            int rndI = rnd.Next(0, 71);
            int rndO = rnd.Next(0, 71);

            #region Женские
            if (rndG == 0)
            {
                #region Фамилия
                if (rndF == 0)
                {
                    f = "Иванова";
                }
                else if (rndF == 1)
                {
                    f = "Смирнова";
                }
                else if (rndF == 2)
                {
                    f = "Петрова";
                }
                else if (rndF == 3)
                {
                    f = "Попова";
                }
                else if (rndF == 4)
                {
                    f = "Кремлева";
                }
                else if (rndF == 5)
                {
                    f = "Путина";
                }
                else if (rndF == 6)
                {
                    f = "Фадеева";
                }
                else if (rndF == 7)
                {
                    f = "Ткачева";
                }
                else if (rndF == 8)
                {
                    f = "Токарева";
                }
                else if (rndF == 9)
                {
                    f = "Залевская";
                }
                else if (rndF == 10)
                {
                    f = "Горбачева";
                }
                else if (rndF == 11)
                {
                    f = "Воронина";
                }
                else if (rndF == 12)
                {
                    f = "Жупиева";
                }
                else if (rndF == 13)
                {
                    f = "Петухова";
                }
                else if (rndF == 14)
                {
                    f = "Яковлева";
                }
                else if (rndF == 15)
                {
                    f = "Галкина";
                }
                else if (rndF == 16)
                {
                    f = "Зрянина";
                }
                else if (rndF == 17)
                {
                    f = "Лягушкина";
                }
                else if (rndF == 18)
                {
                    f = "Лисичкина";
                }
                else if (rndF == 19)
                {
                    f = "Пронская";
                }
                else if (rndF == 20)
                {
                    f = "Широкова";
                }
                else if (rndF == 21)
                {
                    f = "Соколова";
                }
                else if (rndF == 22)
                {
                    f = "Кузнецова";
                }
                else if (rndF == 23)
                {
                    f = "Васильева";
                }
                else if (rndF == 24)
                {
                    f = "Новикова";
                }
                else if (rndF == 25)
                {
                    f = "Алексеева";
                }
                else if (rndF == 26)
                {
                    f = "Морозова";
                }
                else if (rndF == 27)
                {
                    f = "Федерова";
                }
                else if (rndF == 28)
                {
                    f = "Волкова";
                }
                else if (rndF == 29)
                {
                    f = "Лебедева";
                }
                else if (rndF == 30)
                {
                    f = "Егорова";
                }
                else if (rndF == 31)
                {
                    f = "Козлова";
                }
                else if (rndF == 32)
                {
                    f = "Степанова";
                }
                else if (rndF == 33)
                {
                    f = "Орлова";
                }
                else if (rndF == 34)
                {
                    f = "Андреева";
                }
                else if (rndF == 35)
                {
                    f = "Захарова";
                }
                else if (rndF == 36)
                {
                    f = "Зайцева";
                }
                else if (rndF == 37)
                {
                    f = "Соловьева";
                }
                else if (rndF == 38)
                {
                    f = "Борисова";
                }
                else if (rndF == 39)
                {
                    f = "Романова";
                }
                else if (rndF == 40)
                {
                    f = "Фролова";
                }
                else if (rndF == 41)
                {
                    f = "Королева";
                }
                else if (rndF == 42)
                {
                    f = "Гусева";
                }
                else if (rndF == 43)
                {
                    f = "Кисилева";
                }
                else if (rndF == 44)
                {
                    f = "Максимова";
                }
                else if (rndF == 45)
                {
                    f = "Калмыкова";
                }
                else if (rndF == 46)
                {
                    f = "Жукова";
                }
                else if (rndF == 47)
                {
                    f = "Сорокина";
                }
                else if (rndF == 48)
                {
                    f = "Ковалева";
                }
                else if (rndF == 49)
                {
                    f = "Полякова";
                }
                else if (rndF == 50)
                {
                    f = "Медведева";
                }
                else if (rndF == 51)
                {
                    f = "Комарова";
                }
                else if (rndF == 52)
                {
                    f = "Беляева";
                }
                else if (rndF == 53)
                {
                    f = "Осипова";
                }
                else if (rndF == 54)
                {
                    f = "Титова";
                }
                else if (rndF == 55)
                {
                    f = "Крылова";
                }
                else if (rndF == 56)
                {
                    f = "Куликова";
                }
                else if (rndF == 57)
                {
                    f = "Мельникова";
                }
                else if (rndF == 58)
                {
                    f = "Тихонова";
                }
                else if (rndF == 59)
                {
                    f = "Тихомирова";
                }
                else if (rndF == 60)
                {
                    f = "Казакова";
                }
                else if (rndF == 61)
                {
                    f = "Чернова";
                }
                else if (rndF == 62)
                {
                    f = "Савельева";
                }
                else if (rndF == 63)
                {
                    f = "Мартынова";
                }
                else if (rndF == 64)
                {
                    f = "Лазарева";
                }
                else if (rndF == 65)
                {
                    f = "Маслова";
                }
                else if (rndF == 66)
                {
                    f = "Журавлева";
                }
                else if (rndF == 67)
                {
                    f = "Леонова";
                }
                else if (rndF == 68)
                {
                    f = "Наумова";
                }
                else if (rndF == 69)
                {
                    f = "Кудрявцева";
                }
                else if (rndF == 70)
                {
                    f = "Прохорова";
                }
                else if (rndF == 71)
                {
                    f = "Потапова";
                }
                else if (rndF == 72)
                {
                    f = "Соболева";
                }
                else if (rndF == 73)
                {
                    f = "Миронова";
                }
                else if (rndF == 74)
                {
                    f = "Цветкова";
                }
                else if (rndF == 75)
                {
                    f = "Лукьянова";
                }
                else if (rndF == 76)
                {
                    f = "Логинова";
                }
                else if (rndF == 77)
                {
                    f = "Рябова";
                }
                else if (rndF == 78)
                {
                    f = "Мирошкина";
                }
                else if (rndF == 79)
                {
                    f = "Шишкина";
                }
                else if (rndF == 80)
                {
                    f = "Плеханова";
                }
                else if (rndF == 81)
                {
                    f = "Лешкевич";
                }
                else if (rndF == 82)
                {
                    f = "Лунькова";
                }
                #endregion
                #region Имя
                if (rndI == 0) i = " Анастасия ";
                else if (rndI == 1) i = " Екатерина ";
                else if (rndI == 2) i = " Дарья ";
                else if (rndI == 3) i = " Мария ";
                else if (rndI == 4) i = " София ";
                else if (rndI == 5) i = " Анна ";
                else if (rndI == 6) i = " Виктория ";
                else if (rndI == 7) i = " Полина ";
                else if (rndI == 8) i = " Елизавета ";
                else if (rndI == 9) i = " Ксения ";
                else if (rndI == 10) i = " Валерия ";
                else if (rndI == 11) i = " Варвара ";
                else if (rndI == 12) i = " Александра ";
                else if (rndI == 13) i = " Вероника ";
                else if (rndI == 14) i = " Арина ";
                else if (rndI == 15) i = " Алиса ";
                else if (rndI == 16) i = " Алина ";
                else if (rndI == 17) i = " Милана ";
                else if (rndI == 18) i = " Маргарита ";
                else if (rndI == 19) i = " Ульяна ";
                else if (rndI == 20) i = " Ангелина ";
                else if (rndI == 21) i = " Анжелика ";
                else if (rndI == 22) i = " Кристина ";
                else if (rndI == 23) i = " Юлия ";
                else if (rndI == 24) i = " Кира ";
                else if (rndI == 25) i = " Ева ";
                else if (rndI == 26) i = " Карина ";
                else if (rndI == 27) i = " Василиса ";
                else if (rndI == 28) i = " Ольга ";
                else if (rndI == 29) i = " Татьяна ";
                else if (rndI == 30) i = " Ирина ";
                else if (rndI == 31) i = " Таисия ";
                else if (rndI == 32) i = " Евгения ";
                else if (rndI == 33) i = " Яна ";
                else if (rndI == 34) i = " Марина ";
                else if (rndI == 35) i = " Вера ";
                else if (rndI == 36) i = " Елена ";
                else if (rndI == 37) i = " Надежда ";
                else if (rndI == 38) i = " Светлана ";
                else if (rndI == 39) i = " Злата ";
                else if (rndI == 40) i = " Олеся ";
                else if (rndI == 41) i = " Наталья ";
                else if (rndI == 42) i = " Эвелина ";
                else if (rndI == 43) i = " Лилия ";
                else if (rndI == 44) i = " Элина ";
                else if (rndI == 45) i = " Виолетта ";
                else if (rndI == 46) i = " Мирослава ";
                else if (rndI == 47) i = " Любовь ";
                else if (rndI == 48) i = " Альбина ";
                else if (rndI == 49) i = " Владислава ";
                else if (rndI == 50) i = " Ярослава ";
                else if (rndI == 51) i = " Валентина ";
                else if (rndI == 52) i = " Майя ";
                else if (rndI == 53) i = " Эльвира ";
                else if (rndI == 54) i = " Снежана ";
                else if (rndI == 55) i = " Лидия ";
                else if (rndI == 56) i = " Антонина ";
                else if (rndI == 57) i = " Есения ";
                else if (rndI == 58) i = " Оксана ";
                else if (rndI == 59) i = " Аделина ";
                else if (rndI == 60) i = " Галина ";
                else if (rndI == 61) i = " Людмила ";
                else if (rndI == 62) i = " Тамара ";
                else if (rndI == 63) i = " Алла ";
                else if (rndI == 64) i = " Жанна ";
                else if (rndI == 65) i = " Анфиса ";
                else if (rndI == 66) i = " Инна ";
                else if (rndI == 67) i = " Алиса ";
                else if (rndI == 68) i = " Евангелина ";
                else if (rndI == 69) i = " Лариса ";
                else if (rndI == 70) i = " Лия ";

                #endregion
                #region Отчество
                if (rndO == 0) o = "Ивановна";
                else if (rndO == 1) o = "Семененовна";
                else if (rndO == 2) o = "Петровна";
                else if (rndO == 3) o = "Артёмовна";
                else if (rndO == 4) o = "Александровна";
                else if (rndO == 5) o = "Максимовна";
                else if (rndO == 6) o = "Данииловна";
                else if (rndO == 7) o = "Даниловна";
                else if (rndO == 8) o = "Дмитриевна";
                else if (rndO == 9) o = "Кирилловна";
                else if (rndO == 10) o = "Никитична";
                else if (rndO == 11) o = "Михаиловна";
                else if (rndO == 12) o = "Егоровна";
                else if (rndO == 13) o = "Матвеевна";
                else if (rndO == 14) o = "Андреевна";
                else if (rndO == 15) o = "Ильина";
                else if (rndO == 16) o = "Романовна";
                else if (rndO == 17) o = "Алексеевна";
                else if (rndO == 18) o = "Сергеевна";
                else if (rndO == 19) o = "Владиславовна";
                else if (rndO == 20) o = "Ярославовна";
                else if (rndO == 21) o = "Тимофеевна";
                else if (rndO == 22) o = "Арсеньевна";
                else if (rndO == 23) o = "Денисовна";
                else if (rndO == 24) o = "Владимировна";
                else if (rndO == 25) o = "Павловна";
                else if (rndO == 26) o = "Глебовна";
                else if (rndO == 27) o = "Константиновна";
                else if (rndO == 28) o = "Богдановна";
                else if (rndO == 29) o = "Евгеньевна";
                else if (rndO == 30) o = "Николаевна";
                else if (rndO == 31) o = "Степановна";
                else if (rndO == 32) o = "Захаровна";
                else if (rndO == 33) o = "Тимуровна";
                else if (rndO == 34) o = "Фёдоровна";
                else if (rndO == 35) o = "Георгиевна";
                else if (rndO == 36) o = "Львовна";
                else if (rndO == 37) o = "Антоновна";
                else if (rndO == 38) o = "Вадимовна";
                else if (rndO == 39) o = "Игоревнова";
                else if (rndO == 40) o = "Руслановна";
                else if (rndO == 41) o = "Вячеславовна";
                else if (rndO == 42) o = "Григорьевна";
                else if (rndO == 43) o = "Макаровна";
                else if (rndO == 44) o = "Артуровна";
                else if (rndO == 45) o = "Викторовна";
                else if (rndO == 46) o = "Станиславовна";
                else if (rndO == 47) o = "Олеговна";
                else if (rndO == 48) o = "Давидовна";
                else if (rndO == 49) o = "Леонидовна";
                else if (rndO == 50) o = "Юриьевна";
                else if (rndO == 51) o = "Витальевна";
                else if (rndO == 52) o = "Васильевна";
                else if (rndO == 53) o = "Маратовна";
                else if (rndO == 54) o = "Анатольевна";
                else if (rndO == 55) o = "Валерьевна";
                else if (rndO == 56) o = "Борисовна";
                else if (rndO == 57) o = "Филипповна";
                else if (rndO == 58) o = "Валентиновна";
                else if (rndO == 59) o = "Геннадьевна";
                else if (rndO == 60) o = "Аркадьевна";
                else if (rndO == 61) o = "Абудловна";
                else if (rndO == 62) o = "Тарасовна";
                else if (rndO == 63) o = "Трофимовна";
                else if (rndO == 64) o = "Архиповна";
                else if (rndO == 65) o = "Назаровна";
                else if (rndO == 66) o = "Родионовна";
                else if (rndO == 67) o = "Мироновна";
                else if (rndO == 68) o = "Платоновна";
                else if (rndO == 69) o = "Германовна";
                else if (rndO == 70) o = "Игнатовна";
                #endregion
            }
            #endregion
            #region Мужские
            if (rndG == 1)
            {
                #region Фамилия
                if (rndF == 0)
                {
                    f = "Иванов";
                }
                else if (rndF == 1)
                {
                    f = "Смирнов";
                }
                else if (rndF == 2)
                {
                    f = "Петров";
                }
                else if (rndF == 3)
                {
                    f = "Попов";
                }
                else if (rndF == 4)
                {
                    f = "Кремлев";
                }
                else if (rndF == 5)
                {
                    f = "Путин";
                }
                else if (rndF == 6)
                {
                    f = "Фадеев";
                }
                else if (rndF == 7)
                {
                    f = "Ткачев";
                }
                else if (rndF == 8)
                {
                    f = "Токарев";
                }
                else if (rndF == 9)
                {
                    f = "Залевский";
                }
                else if (rndF == 10)
                {
                    f = "Горбачев";
                }
                else if (rndF == 11)
                {
                    f = "Воронин";
                }
                else if (rndF == 12)
                {
                    f = "Жупиев";
                }
                else if (rndF == 13)
                {
                    f = "Петухов";
                }
                else if (rndF == 14)
                {
                    f = "Яковлев";
                }
                else if (rndF == 15)
                {
                    f = "Галкин";
                }
                else if (rndF == 16)
                {
                    f = "Зрянин";
                }
                else if (rndF == 17)
                {
                    f = "Лягушкин";
                }
                else if (rndF == 18)
                {
                    f = "Лисичкин";
                }
                else if (rndF == 19)
                {
                    f = "Пронский";
                }
                else if (rndF == 20)
                {
                    f = "Широков";
                }
                else if (rndF == 21)
                {
                    f = "Соколов";
                }
                else if (rndF == 22)
                {
                    f = "Кузнецов";
                }
                else if (rndF == 23)
                {
                    f = "Васильев";
                }
                else if (rndF == 24)
                {
                    f = "Новиков";
                }
                else if (rndF == 25)
                {
                    f = "Алексеев";
                }
                else if (rndF == 26)
                {
                    f = "Морозов";
                }
                else if (rndF == 27)
                {
                    f = "Федеров";
                }
                else if (rndF == 28)
                {
                    f = "Волков";
                }
                else if (rndF == 29)
                {
                    f = "Лебедев";
                }
                else if (rndF == 30)
                {
                    f = "Егоров";
                }
                else if (rndF == 31)
                {
                    f = "Козлов";
                }
                else if (rndF == 32)
                {
                    f = "Степанов";
                }
                else if (rndF == 33)
                {
                    f = "Орлов";
                }
                else if (rndF == 34)
                {
                    f = "Андреев";
                }
                else if (rndF == 35)
                {
                    f = "Захаров";
                }
                else if (rndF == 36)
                {
                    f = "Зайцев";
                }
                else if (rndF == 37)
                {
                    f = "Соловьев";
                }
                else if (rndF == 38)
                {
                    f = "Борисов";
                }
                else if (rndF == 39)
                {
                    f = "Романов";
                }
                else if (rndF == 40)
                {
                    f = "Фролов";
                }
                else if (rndF == 41)
                {
                    f = "Королев";
                }
                else if (rndF == 42)
                {
                    f = "Гусев";
                }
                else if (rndF == 43)
                {
                    f = "Кисилев";
                }
                else if (rndF == 44)
                {
                    f = "Максимов";
                }
                else if (rndF == 45)
                {
                    f = "Калмыков";
                }
                else if (rndF == 46)
                {
                    f = "Жуков";
                }
                else if (rndF == 47)
                {
                    f = "Сорокин";
                }
                else if (rndF == 48)
                {
                    f = "Ковалев";
                }
                else if (rndF == 49)
                {
                    f = "Поляков";
                }
                else if (rndF == 50)
                {
                    f = "Медведев";
                }
                else if (rndF == 51)
                {
                    f = "Комаров";
                }
                else if (rndF == 52)
                {
                    f = "Беляев";
                }
                else if (rndF == 53)
                {
                    f = "Осипов";
                }
                else if (rndF == 54)
                {
                    f = "Титов";
                }
                else if (rndF == 55)
                {
                    f = "Крылов";
                }
                else if (rndF == 56)
                {
                    f = "Куликов";
                }
                else if (rndF == 57)
                {
                    f = "Мельников";
                }
                else if (rndF == 58)
                {
                    f = "Тихонов";
                }
                else if (rndF == 59)
                {
                    f = "Тихомиров";
                }
                else if (rndF == 60)
                {
                    f = "Казаков";
                }
                else if (rndF == 61)
                {
                    f = "Чернов";
                }
                else if (rndF == 62)
                {
                    f = "Савельев";
                }
                else if (rndF == 63)
                {
                    f = "Мартынов";
                }
                else if (rndF == 64)
                {
                    f = "Лазарев";
                }
                else if (rndF == 65)
                {
                    f = "Маслов";
                }
                else if (rndF == 66)
                {
                    f = "Журавлев";
                }
                else if (rndF == 67)
                {
                    f = "Леонов";
                }
                else if (rndF == 68)
                {
                    f = "Наумов";
                }
                else if (rndF == 69)
                {
                    f = "Кудрявцев";
                }
                else if (rndF == 70)
                {
                    f = "Прохоров";
                }
                else if (rndF == 71)
                {
                    f = "Потапов";
                }
                else if (rndF == 72)
                {
                    f = "Соболев";
                }
                else if (rndF == 73)
                {
                    f = "Миронов";
                }
                else if (rndF == 74)
                {
                    f = "Цветков";
                }
                else if (rndF == 75)
                {
                    f = "Лукьянов";
                }
                else if (rndF == 76)
                {
                    f = "Логинов";
                }
                else if (rndF == 77)
                {
                    f = "Рябов";
                }
                else if (rndF == 78)
                {
                    f = "Мирошкин";
                }
                else if (rndF == 79)
                {
                    f = "Шишкин";
                }
                else if (rndF == 80)
                {
                    f = "Плеханов";
                }
                else if (rndF == 81)
                {
                    f = "Лешкевич";
                }
                else if (rndF == 82)
                {
                    f = "Луньков";
                }

                #endregion
                #region Имя
                if (rndI == 0) i = " Иван ";
                else if (rndI == 1) i = " Семен ";
                else if (rndI == 2) i = " Петр ";
                else if (rndI == 3) i = " Артём ";
                else if (rndI == 4) i = " Александр ";
                else if (rndI == 5) i = " Максим ";
                else if (rndI == 6) i = " Даниил ";
                else if (rndI == 7) i = " Данил ";
                else if (rndI == 8) i = " Дмитрий ";
                else if (rndI == 9) i = " Кирилл ";
                else if (rndI == 10) i = " Никита ";
                else if (rndI == 11) i = " Михаил ";
                else if (rndI == 12) i = " Егор ";
                else if (rndI == 13) i = " Матвей ";
                else if (rndI == 14) i = " Андрей ";
                else if (rndI == 15) i = " Илья ";
                else if (rndI == 16) i = " Роман ";
                else if (rndI == 17) i = " Алексей ";
                else if (rndI == 18) i = " Сергей ";
                else if (rndI == 19) i = " Владислав ";
                else if (rndI == 20) i = " Ярослав ";
                else if (rndI == 21) i = " Тимофей ";
                else if (rndI == 22) i = " Арсений ";
                else if (rndI == 23) i = " Денис ";
                else if (rndI == 24) i = " Владимир ";
                else if (rndI == 25) i = " Павел ";
                else if (rndI == 26) i = " Глеб ";
                else if (rndI == 27) i = " Константин ";
                else if (rndI == 28) i = " Богдан ";
                else if (rndI == 29) i = " Евгений ";
                else if (rndI == 30) i = " Николай ";
                else if (rndI == 31) i = " Степан ";
                else if (rndI == 32) i = " Захар ";
                else if (rndI == 33) i = " Тимур ";
                else if (rndI == 34) i = " Фёдор ";
                else if (rndI == 35) i = " Георгий ";
                else if (rndI == 36) i = " Лев ";
                else if (rndI == 37) i = " Антон ";
                else if (rndI == 38) i = " Вадим ";
                else if (rndI == 39) i = " Игорь ";
                else if (rndI == 40) i = " Руслан ";
                else if (rndI == 41) i = " Вячеслав ";
                else if (rndI == 42) i = " Григорий ";
                else if (rndI == 43) i = " Макар ";
                else if (rndI == 44) i = " Артур ";
                else if (rndI == 45) i = " Виктор ";
                else if (rndI == 46) i = " Станислав ";
                else if (rndI == 47) i = " Олег ";
                else if (rndI == 48) i = " Давид ";
                else if (rndI == 49) i = " Леонид ";
                else if (rndI == 50) i = " Юрий ";
                else if (rndI == 51) i = " Виталий ";
                else if (rndI == 52) i = " Василий ";
                else if (rndI == 53) i = " Марат ";
                else if (rndI == 54) i = " Анатолий ";
                else if (rndI == 55) i = " Валерий ";
                else if (rndI == 56) i = " Борис ";
                else if (rndI == 57) i = " Филипп ";
                else if (rndI == 58) i = " Валентин ";
                else if (rndI == 59) i = " Геннадий ";
                else if (rndI == 60) i = " Аркадий ";
                else if (rndI == 61) i = " Абдул ";
                else if (rndI == 62) i = " Тарас ";
                else if (rndI == 63) i = " Трофим ";
                else if (rndI == 64) i = " Архип ";
                else if (rndI == 65) i = " Назар ";
                else if (rndI == 66) i = " Родион ";
                else if (rndI == 67) i = " Мирон ";
                else if (rndI == 68) i = " Платон ";
                else if (rndI == 69) i = " Герман ";
                else if (rndI == 70) i = " Игнат ";

                #endregion
                #region Отчество
                if (rndO == 0) o = "Иванович";
                else if (rndO == 1) o = "Семенович";
                else if (rndO == 2) o = "Петрович";
                else if (rndO == 3) o = "Артёмович";
                else if (rndO == 4) o = "Александрович";
                else if (rndO == 5) o = "Максимович";
                else if (rndO == 6) o = "Даниилович";
                else if (rndO == 7) o = "Данилович";
                else if (rndO == 8) o = "Дмитрьевич";
                else if (rndO == 9) o = "Кириллович";
                else if (rndO == 10) o = "Никитич";
                else if (rndO == 11) o = "Михалович";
                else if (rndO == 12) o = "Егорович";
                else if (rndO == 13) o = "Матвеевич";
                else if (rndO == 14) o = "Андреевич";
                else if (rndO == 15) o = "Ильин";
                else if (rndO == 16) o = "Романович";
                else if (rndO == 17) o = "Алексеевич";
                else if (rndO == 18) o = "Сергеевич";
                else if (rndO == 19) o = "Владиславович";
                else if (rndO == 20) o = "Ярославович";
                else if (rndO == 21) o = "Тимофеевич";
                else if (rndO == 22) o = "Арсениевич";
                else if (rndO == 23) o = "Денисович";
                else if (rndO == 24) o = "Владимирович";
                else if (rndO == 25) o = "Павлович";
                else if (rndO == 26) o = "Глебович";
                else if (rndO == 27) o = "Константинович";
                else if (rndO == 28) o = "Богданович";
                else if (rndO == 29) o = "Евгеньевич";
                else if (rndO == 30) o = "Николаевич";
                else if (rndO == 31) o = "Степанович";
                else if (rndO == 32) o = "Захарович";
                else if (rndO == 33) o = "Тимурович";
                else if (rndO == 34) o = "Фёдорович";
                else if (rndO == 35) o = "Георгиевич";
                else if (rndO == 36) o = "Львович";
                else if (rndO == 37) o = "Антонович";
                else if (rndO == 38) o = "Вадимович";
                else if (rndO == 39) o = "Игоревич";
                else if (rndO == 40) o = "Русланович";
                else if (rndO == 41) o = "Вячеславович";
                else if (rndO == 42) o = "Григорьевич";
                else if (rndO == 43) o = "Макарович";
                else if (rndO == 44) o = "Артурович";
                else if (rndO == 45) o = "Викторович";
                else if (rndO == 46) o = "Станиславович";
                else if (rndO == 47) o = "Олегович";
                else if (rndO == 48) o = "Давидович";
                else if (rndO == 49) o = "Леонидович";
                else if (rndO == 50) o = "Юрьевич";
                else if (rndO == 51) o = "Витальевич";
                else if (rndO == 52) o = "Васильевич";
                else if (rndO == 53) o = "Маратович";
                else if (rndO == 54) o = "Анатольевич";
                else if (rndO == 55) o = "Валерьевич";
                else if (rndO == 56) o = "Борисович";
                else if (rndO == 57) o = "Филиппович";
                else if (rndO == 58) o = "Валентинович";
                else if (rndO == 59) o = "Геннадьевич";
                else if (rndO == 60) o = "Аркадьевич";
                else if (rndO == 61) o = "Абдулович";
                else if (rndO == 62) o = "Тарасович";
                else if (rndO == 63) o = "Трофимович";
                else if (rndO == 64) o = "Архипович";
                else if (rndO == 65) o = "Назарович";
                else if (rndO == 66) o = "Родионович";
                else if (rndO == 67) o = "Миронович";
                else if (rndO == 68) o = "Платонович";
                else if (rndO == 69) o = "Германович";
                else if (rndO == 70) o = "Игнатович";
                #endregion
            }
            #endregion


            textBox1.Text = (f + i + o);
        }
        private void button2_Click(object sender, EventArgs e)//Причина
        {
            string p1 = "";
            string p2 = "";
            string p3 = "";
            Random rnd = new Random();
            int rndP1 = rnd.Next(0, 14);
            int rndP2 = rnd.Next(0, 15);
            int rndP3 = rnd.Next(0, 12);

            #region Часть1
                 if (rndP1 == 0) p1 = "Широков жалкий карлик, поэтому";
            else if (rndP1 == 1) p1 = "Эту душу люди не любили потому что";
            else if (rndP1 == 2) p1 = "Когда-то эта душа была счастлива, но";
            else if (rndP1 == 3) p1 = "Поздним вечером она возвращалась домой, как вдруг,";
            else if (rndP1 == 4) p1 = "Она переходила дорогу и";
            else if (rndP1 == 5) p1 = "Эта душа просто хотела поесть ночью, но";
            else if (rndP1 == 6) p1 = "Эта душа играла на Тимо и";
            else if (rndP1 == 7) p1 = "Эта душа не успела дописать курсовой потому что";
            else if (rndP1 == 8) p1 = "Эта душа не любила жалких карликов, как вдруг";
            else if (rndP1 == 9) p1 = "Эта душа общалась с Никитой, как вдруг,";
            else if (rndP1 == 10) p1 = "Эта душа просто решила наконец выйти из дома, но";
            else if (rndP1 == 11) p1 = "Прогулка по кладбищу показалась ей хорошей идеей, но";
            else if (rndP1 == 12) p1 = "Эта душа опазадала на пару и";
            else if (rndP1 == 13) p1 = "Она повесилась, потому что";
            #endregion
            #region Часть2
                 if (rndP2 == 0) p2 = " её разорвали собаки";
            else if (rndP2 == 1) p2 = " её переехал грузовик";
            else if (rndP2 == 2) p2 = " она повесилась";
            else if (rndP2 == 3) p2 = " её зарезали бумагой";
            else if (rndP2 == 4) p2 = " её застрелили";
            else if (rndP2 == 5) p2 = " она взорвалась";
            else if (rndP2 == 6) p2 = " Никита съел её";
            else if (rndP2 == 7) p2 = " она утонула";
            else if (rndP2 == 8) p2 = " она перерезала вены";
            else if (rndP2 == 9) p2 = " она утопилась";
            else if (rndP2 == 10) p2 = " у неё случился сердечный приступ";
            else if (rndP2 == 11) p2 = " на неё напали дикие панды";
            else if (rndP2 == 12) p2 = " на неё напал Никита Ткачев";
            else if (rndP2 == 13) p2 = " её потрогал Максим Широков";
            else if (rndP2 == 14) p2 = " она перестала дышать";
            #endregion
            #region Часть3
                 if (rndP3 == 0) p3 = ", а потом провалилась под лед.";
            else if (rndP3 == 1) p3 = ", а потом она повесилась.";
            else if (rndP3 == 2) p3 = ", её тело так никто и не нашел...";
            else if (rndP3 == 3) p3 = ", а её тело сбросили в реку.";
            else if (rndP3 == 4) p3 = ", а тело расчленили и продали.";
            else if (rndP3 == 5) p3 = " и звала маму перед смертью.";
            else if (rndP3 == 6) p3 = " хотя она обещала больше так не делать.";
            else if (rndP3 == 7) p3 = ", она понимала что её время пришло.";
            else if (rndP3 == 8) p3 = ". Она успела оставить завещание.";
            else if (rndP3 == 9) p3 = ", а потом её утопили.";
            else if (rndP3 == 10) p3 = " и про неё так никто и не вспомнил.";
            else if (rndP3 == 11) p3 = " а потом она запнулась об Широкова.";
            #endregion

            textBox2.Text = (p1 + p2 + p3);
        }
        private void label19_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int rndd = rnd.Next(1, 29);
            int rndm = rnd.Next(1, 13);
            int rndy = rnd.Next(1776, 2010);
            dateTimePicker1.Value = new DateTime(rndy, rndm, rndd);
        }
        #endregion
        #region Выход
        public void vihod_click()
        {
            VihodPanel.BackColor = Color.DimGray;

            SoulPanel.BackColor = Color.FromArgb(50, 50, 50);
            ProfPanel.BackColor = Color.FromArgb(50, 50, 50);
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
            pictureBox3.BackgroundImage = Properties.Resources.Death3;
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.Death;
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
