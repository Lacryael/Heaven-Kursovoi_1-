using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Heavenly_Judgement
{
    public partial class Main : Form
    {
        public static Timer timer = new Timer();
        public static string login;
        public static int satanstate = 0;
        public static int bogstate = 0;
        public static int deathstate = 0;
        public static int sudstate = 0;
        public static int chtecstate = 0;
        Base dataBase = new Base();


        public Main()
        {
            InitializeComponent();
            exit.Image = Properties.Resources.Cross;
            pictureBox1.BackgroundImage = Properties.Resources.Main;
            pictureBox2.BackgroundImage = Properties.Resources.Ochered;
            pictureBox3.BackgroundImage = Properties.Resources.Spravka;
            pictureBox4.BackgroundImage = Properties.Resources.Vhod;
            button2.BackgroundImage = Properties.Resources.Poisk;
            Opacity = 0;
            Timer timer = new Timer();
            timer.Tick += new EventHandler((sender, e) =>
            {
                if ((Opacity += 0.05d) == 1) timer.Stop();
            });
            timer.Interval = 10;
            timer.Start();

            string vsego0 = String.Format("SELECT id FROM Soul WHERE id = (SELECT MAX(id) FROM Soul WHERE status='1')");
            string min0 = String.Format("SELECT status FROM Soul WHERE id = '{0}'", 0);

            int vsego = Convert.ToInt32(dataBase.GetFio(vsego0));
            int min = Convert.ToInt32(dataBase.GetFio(min0));
            Random rnd = new Random();
            int rndid = rnd.Next(min, vsego);
            labelId.Text = Convert.ToString(rndid);
            ToolTip t = new ToolTip();
            t.SetToolTip(labelId, "Кликните дважды чтобы скопировать");

        }

        #region ТестКнопки (Для перехода по формам без авторизции - сделать видимыми.)
        private void label19_DoubleClick(object sender, EventArgs e)
        {
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void label17_DoubleClick(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DeathForm death = new DeathForm();
            this.Hide();
            death.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SatanaForm satana = new SatanaForm();
            this.Hide();
            satana.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            BogForm bog = new BogForm();
            this.Hide();
            bog.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            SudForm sud = new SudForm();
            this.Hide();
            sud.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            ChtecForm chtec = new ChtecForm();
            this.Hide();
            chtec.Show();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            this.Hide();
            admin.Show();
        }
        #endregion//Для перехода по формам без авторизации.  //Для перехода по формам без авторизации сделать видимыми
        #region ГЛАВНАЯ
        public void main_click()
        {
            MainPanel.BackColor = Color.FromArgb(134, 149, 255);

            OcheredPanel.BackColor = Color.FromArgb(102, 122, 255);
            SpravPanel.BackColor = Color.FromArgb(102, 122, 255);
            VhodPanel.BackColor = Color.FromArgb(102, 122, 255);

            panel2.Visible = true;
            panelOchered.Visible = true;
            panelSpravka.Visible = true;
            panelMain.Visible = true;


        }
        private void label17_Click(object sender, EventArgs e)
        {
            string vsego0 = String.Format("SELECT id FROM Soul WHERE id = (SELECT MAX(id) FROM Soul WHERE status='1')");
            string min0 = String.Format("SELECT status FROM Soul WHERE id = '{0}'", 0);

            int vsego = Convert.ToInt32(dataBase.GetFio(vsego0));
            int min = Convert.ToInt32(dataBase.GetFio(min0));
            Random rnd = new Random();
            int rndid = rnd.Next(min, vsego);
            labelId.Text = Convert.ToString(rndid);
            ToolTip t = new ToolTip();
            t.SetToolTip(labelId, "Кликните дважды чтобы скопировать");
        }

        #endregion
        #region ОЧЕРЕДЬ
        public void ochered_click()
        {
            OcheredPanel.BackColor = Color.FromArgb(134, 149, 255);

            MainPanel.BackColor = Color.FromArgb(102, 122, 255);
            SpravPanel.BackColor = Color.FromArgb(102, 122, 255);
            VhodPanel.BackColor = Color.FromArgb(102, 122, 255);

            panel2.Visible = true;
            panelOchered.Visible = true;
            panelSpravka.Visible = false;
            timer.Stop();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "id" && textBox1.Text != "")
            {
                string id2 = textBox1.Text.ToString();
                string query = String.Format("Select id From Soul Where id = '{0}'", id2);
                query = String.Format("Select id From Soul Where id = '{0}'", id2);

                if (dataBase.GetId(query, id2) == 1)
                {
                    int id = Convert.ToInt32(textBox1.Text);
                    string nullid = String.Format("Select status From Soul Where id = '{0}'", 0);
                    int ochered = id - Convert.ToInt32(dataBase.GetFio(nullid));
                    if (ochered <= 0) { labelOchered.Text = "0"; }
                    else labelOchered.Text = Convert.ToString(ochered);

                    string status2 = String.Format("Select status From Soul Where id = '{0}'", id);
                    int status = Convert.ToInt32(dataBase.GetFio(status2));

                    if (status == 1) { labelStatus.Text = "Обрабатывется чтецом душ"; labelStatus.Location = new Point(259, 256); pictureAd.BackgroundImage = Properties.Resources.Ad; pictureRai.BackgroundImage = Properties.Resources.Rai; }
                    else if (status == 2) { labelStatus.Text = "Ожидается решение судьи"; labelStatus.Location = new Point(259, 256); pictureAd.BackgroundImage = Properties.Resources.Ad; pictureRai.BackgroundImage = Properties.Resources.Rai; }
                    else if (status == 3)
                    {
                        labelStatus.Text = "Бог подбирает для вас место в раю";
                        pictureRai.BackgroundImage = Properties.Resources.Rai2;
                        labelStatus.Location = new Point(10, 322);
                        pictureAd.BackgroundImage = Properties.Resources.Ad;
                        ;
                    }
                    else if (status == 4) { labelStatus.Text = "Сатана ищет вам местечко в аду"; pictureAd.BackgroundImage = Properties.Resources.Ad2; labelStatus.Location = new Point(10, 322); pictureRai.BackgroundImage = Properties.Resources.Rai; }
                    else if (status == 5) { labelStatus.Text = "Вы уже в аду."; labelStatus.Location = new Point(259, 256); pictureAd.BackgroundImage = Properties.Resources.Ad2; pictureRai.BackgroundImage = Properties.Resources.Rai; }
                    else if (status == 6) { labelStatus.Text = "Вы уже в раю."; labelStatus.Location = new Point(259, 256); pictureRai.BackgroundImage = Properties.Resources.Rai2; pictureAd.BackgroundImage = Properties.Resources.Ad; }
                }
                else
                {
                    textBox1.Text = "id"; 
                    textBox1.ForeColor = Color.LightGray;
                    labelStatus.Text = "Несуществующий ID.";
                }
            }
            
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "id")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.FromArgb(102, 122, 255);
                //textBox1.Text = textBox1.Text + Clipboard.GetText();
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == "") {textBox1.Text = "id";textBox1.ForeColor = Color.LightGray;}
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "666") { textBox1.ForeColor = Color.Maroon; }
            else { textBox1.ForeColor = Color.FromArgb(102, 122, 255); }
        }
        private void pictureRai_Click(object sender, EventArgs e)
        {
            if (textLogin.Text == "Admin" && textBox1.Text == "666" && textPass.Text == "Admin")
            {
                Application.Exit();
            }
        }
        private void pictureAd_Click(object sender, EventArgs e)
        {

            if (textLogin.Text == "Admin" && textBox1.Text == "666" && textPass.Text == "Admin")
            {
                AdminForm admin = new AdminForm();
                this.Hide();
                admin.Show();
            }
        }
        #endregion
        #region СПРАВКА
        public void sprav_click()
        {
            SpravPanel.BackColor = Color.FromArgb(134, 149, 255);

            MainPanel.BackColor = Color.FromArgb(102, 122, 255);
            OcheredPanel.BackColor = Color.FromArgb(102, 122, 255);
            VhodPanel.BackColor = Color.FromArgb(102, 122, 255);

            panel2.Visible = true;
            panelOchered.Visible = true;
            panelSpravka.Visible = true;
            panelMain.Visible = false;

        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.BackgroundImage = Properties.Resources.Butt2;
            pictureBox5.Cursor = Cursors.Hand;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panelhell.Visible = true;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = Properties.Resources.Butt1;
            pictureBox5.Cursor = Cursors.Default;
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox6.BackgroundImage = Properties.Resources.HellBut1;
            pictureBox6.Cursor = Cursors.Hand;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackgroundImage = Properties.Resources.HellBut;
            pictureBox6.Cursor = Cursors.Default;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panelhell.Visible = false;
        }
        #endregion
        #region ВХОД
        public void vhod_click()
        {
            if(VhodPanel.BackColor == Color.FromArgb(95, 95, 255))
            {
                VhodPanel.BackColor = Color.FromArgb(134, 149, 255);

                MainPanel.BackColor = Color.FromArgb(102, 122, 255);
                SpravPanel.BackColor = Color.FromArgb(102, 122, 255);
                OcheredPanel.BackColor = Color.FromArgb(102, 122, 255);

                panel3.Visible = true;
                pictureSatana.Visible = false; pictureBog.Visible = false; pictureDeath.Visible = false; pictureSud.Visible = false;
                pictureChtec.Visible = false; textLogin.Visible = false; textPass.Visible = false;
                panel2.Visible = true;
                panelOchered.Visible = false;
                panelSpravka.Visible = false;


                int time = 0;
                timer.Tick += new EventHandler((sender, e) =>
                {
                    if ((time++) == 9999999) timer.Stop();
                    if (time == 1) pictureSatana.Visible = true;
                    if (time == 3) pictureBog.Visible = true;
                    if (time == 6) pictureDeath.Visible = true;
                    if (time == 9) pictureSud.Visible = true;
                    if (time == 12) pictureChtec.Visible = true;
                    if (time == 13) { textLogin.Visible = true; textPass.Visible = true; }
                    else
                    {
                        if (textLogin.Text == "С" || textLogin.Text == "Са" || textLogin.Text == "Сат" || textLogin.Text == "Сата" || textLogin.Text == "Сатан" || textLogin.Text == "Сатана")
                        {
                            pictureSatana.BackgroundImage = Properties.Resources.Satana2; satanstate = 1;
                        }
                        else if (Regex.Match(textLogin.Text, @"Сатана\w").Success) { pictureSatana.BackgroundImage = Properties.Resources.Satana2; satanstate = 1; }
                        else { pictureSatana.BackgroundImage = Properties.Resources.Satana; satanstate = 0; }

                        if (textLogin.Text == "С" || textLogin.Text == "См" || textLogin.Text == "Сме" || textLogin.Text == "Смер" || textLogin.Text == "Смерт" || textLogin.Text == "Смерть")
                        {
                            pictureDeath.BackgroundImage = Properties.Resources.Death2; deathstate = 1;
                        }
                        else if (Regex.Match(textLogin.Text, @"Смерть\w").Success) { pictureDeath.BackgroundImage = Properties.Resources.Death2; deathstate = 1; }
                        else { pictureDeath.BackgroundImage = Properties.Resources.Death; deathstate = 0; }

                        if (textLogin.Text == "Б" || textLogin.Text == "Бо" || textLogin.Text == "Бог")
                        {
                            pictureBog.BackgroundImage = Properties.Resources.Bog2; bogstate = 1;
                        }
                        else if (Regex.Match(textLogin.Text, @"Бог\w").Success) { pictureBog.BackgroundImage = Properties.Resources.Bog2; bogstate = 1; }
                        else { pictureBog.BackgroundImage = Properties.Resources.Bog; bogstate = 0; }

                        if (textLogin.Text == "С" || textLogin.Text == "Су" || textLogin.Text == "Суд" || textLogin.Text == "Судь" || textLogin.Text == "Судья")
                        {
                            pictureSud.BackgroundImage = Properties.Resources.Sudya2; sudstate = 1;
                        }
                        else if (Regex.Match(textLogin.Text, @"Судья\w").Success) { pictureSud.BackgroundImage = Properties.Resources.Sudya2; sudstate = 1; }
                        else { pictureSud.BackgroundImage = Properties.Resources.Sudya; sudstate = 0; }

                        if (textLogin.Text == "Ч" || textLogin.Text == "Чт" || textLogin.Text == "Чте" || textLogin.Text == "Чтец")
                        {
                            pictureChtec.BackgroundImage = Properties.Resources.Chtec2; chtecstate = 1;
                        }
                        else if (Regex.Match(textLogin.Text, @"Чтец\w").Success) { pictureChtec.BackgroundImage = Properties.Resources.Chtec2; chtecstate = 1; }
                        else { pictureChtec.BackgroundImage = Properties.Resources.Chtec; chtecstate = 0; }

                        if (textLogin.Text == "A" && textBox1.Text == "666")
                        {
                            pictureDeath.BackgroundImage = Properties.Resources.Death2;
                        }
                        else if (textLogin.Text == "Ad" && textBox1.Text == "666")
                        {
                            pictureSatana.BackgroundImage = Properties.Resources.Satana2;
                            pictureDeath.BackgroundImage = Properties.Resources.Death2;
                        }
                        else if (textLogin.Text == "Adm" && textBox1.Text == "666")
                        {
                            pictureSatana.BackgroundImage = Properties.Resources.Satana2;
                            pictureDeath.BackgroundImage = Properties.Resources.Death2;
                            pictureChtec.BackgroundImage = Properties.Resources.Chtec2;
                        }
                        else if (textLogin.Text == "Admi" && textBox1.Text == "666")
                        {
                            pictureSatana.BackgroundImage = Properties.Resources.Satana2;
                            pictureDeath.BackgroundImage = Properties.Resources.Death2;
                            pictureChtec.BackgroundImage = Properties.Resources.Chtec2;
                            pictureSud.BackgroundImage = Properties.Resources.Sudya2;
                        }
                        else if (textLogin.Text == "Admin" && textBox1.Text == "666")
                        {
                            pictureSatana.BackgroundImage = Properties.Resources.Satana2;
                            pictureDeath.BackgroundImage = Properties.Resources.Death2;
                            pictureBog.BackgroundImage = Properties.Resources.Bog2;
                            pictureSud.BackgroundImage = Properties.Resources.Sudya2;
                            pictureChtec.BackgroundImage = Properties.Resources.Chtec2;
                        }
                        if (textLogin.Text == "Admin" && textBox1.Text == "666" && textPass.Text == "Admin")
                        {
                            pictureAd.BackgroundImage = Properties.Resources.Ad2;
                            pictureRai.BackgroundImage = Properties.Resources.Rai2;
                            pictureSatana.BackgroundImage = Properties.Resources.Satana3;
                            pictureDeath.BackgroundImage = Properties.Resources.Death3;
                            pictureBog.BackgroundImage = Properties.Resources.Bog3;
                            pictureSud.BackgroundImage = Properties.Resources.Sudya3;
                            pictureChtec.BackgroundImage = Properties.Resources.Chtec3;
                        }
                    }
                });
                timer.Interval = 60;
                timer.Start();

            }
            
        }
        private void textLogin_Click(object sender, EventArgs e)
        {
            if (textLogin.Text == "Логин")
            {
                textLogin.Text = "";
                textLogin.ForeColor = Color.Black;
            }

        }
        private void textPass_Click(object sender, EventArgs e)
        {
            if (textPass.Text == "Пароль")
            {
                textPass.Text = "";
                textPass.ForeColor = Color.Black;
                textPass.PasswordChar = '*';
            }
        }
        private void textLogin_Leave(object sender, EventArgs e)
        {
            if(textLogin.Text == "")
            {
                textLogin.Text = "Логин";
                textLogin.ForeColor = Color.LightGray;
            }
        }
        private void textPass_Leave(object sender, EventArgs e)
        {
            if (textPass.Text == "")
            {
                textPass.Text = "Пароль";
                textPass.ForeColor = Color.LightGray;
                textPass.PasswordChar = '\0';
            }
        }

        #region ВХОД-КНОПКИ
        private void pictureSatana_Click(object sender, EventArgs e)
        {
            if (satanstate == 1)
            {
                string query = String.Format("Select login From Sotrud Where login = '{0}'", login);
                string query2 = String.Format("Select pass From Sotrud Where login = '{0}'", login);
                login = textLogin.Text.ToString();
                query = String.Format("Select login From Sotrud Where login ='{0}'", login);
                if (dataBase.GetPersonalData(query, login) == 1)
                {
                    string pass = textPass.Text;
                    query2 = String.Format("Select pass From Sotrud Where login = '{0}'", login);
                    if (dataBase.GetPersonalData(query2, pass) == 1)
                    {
                        SatanaForm satana = new SatanaForm();
                        this.Hide();
                        satana.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }
        private void pictureSatana_MouseMove(object sender, MouseEventArgs e)
        {
            if (satanstate == 1)
            {
                pictureSatana.Cursor = Cursors.Hand;
                pictureSatana.BackgroundImage = Properties.Resources.Satana3;
                timer.Stop();
            }


        }
        private void pictureSatana_MouseLeave(object sender, EventArgs e)
        {
            if (satanstate == 1)
            {
                pictureSatana.Cursor = DefaultCursor;
                pictureSatana.BackgroundImage = Properties.Resources.Satana2;
                timer.Start();
            }
        }
        private void pictureBog_Click(object sender, EventArgs e)
        {
            if (bogstate == 1)
            {
                string query = String.Format("Select login From Sotrud Where login = '{0}'", login);
                string query2 = String.Format("Select pass From Sotrud Where login = '{0}'", login);
                login = textLogin.Text.ToString();
                query = String.Format("Select login From Sotrud Where login ='{0}'", login);
                if (dataBase.GetPersonalData(query, login) == 1)
                {
                    string pass = textPass.Text;
                    query2 = String.Format("Select pass From Sotrud Where login = '{0}'", login);
                    if (dataBase.GetPersonalData(query2, pass) == 1)
                    {
                        BogForm bog = new BogForm();
                        this.Hide();
                        bog.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }
        private void pictureBog_MouseMove(object sender, MouseEventArgs e)
        {
            if (bogstate == 1)
            {
                pictureBog.Cursor = Cursors.Hand;
                pictureBog.BackgroundImage = Properties.Resources.Bog3;
                timer.Stop();
            }
        }
        private void pictureBog_MouseLeave(object sender, EventArgs e)
        {
            if (bogstate == 1)
            {
                pictureBog.Cursor = DefaultCursor;
                pictureBog.BackgroundImage = Properties.Resources.Bog2;
                timer.Start();
            }
        }
        private void pictureDeath_Click(object sender, EventArgs e)
        {
            if (deathstate == 1)
            {
                string query = String.Format("Select login From Sotrud Where login = '{0}'", login);
                string query2 = String.Format("Select pass From Sotrud Where login = '{0}'", login);
                login = textLogin.Text.ToString();
                query = String.Format("Select login From Sotrud Where login ='{0}'", login);
                if (dataBase.GetPersonalData(query, login) == 1)
                {
                    string pass = textPass.Text;
                    query2 = String.Format("Select pass From Sotrud Where login = '{0}'", login);
                    if (dataBase.GetPersonalData(query2, pass) == 1)
                    {
                        DeathForm death = new DeathForm();
                        this.Hide();
                        death.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }
        private void pictureDeath_MouseMove(object sender, MouseEventArgs e)
        {
            if (deathstate == 1)
            {
                pictureDeath.Cursor = Cursors.Hand;
                pictureDeath.BackgroundImage = Properties.Resources.Death3;
                timer.Stop();
            }
        }
        private void pictureDeath_MouseLeave(object sender, EventArgs e)
        {
            if (deathstate == 1)
            {
                pictureDeath.Cursor = DefaultCursor;
                pictureDeath.BackgroundImage = Properties.Resources.Death2;
                timer.Start();
            }
        }

        private void pictureSud_Click(object sender, EventArgs e)
        {
            if (sudstate == 1)
            {
                string query = String.Format("Select login From Sotrud Where login = '{0}'", login);
                string query2 = String.Format("Select pass From Sotrud Where login = '{0}'", login);
                login = textLogin.Text.ToString();
                query = String.Format("Select login From Sotrud Where login ='{0}'", login);
                if (dataBase.GetPersonalData(query, login) == 1)
                {
                    string pass = textPass.Text;
                    query2 = String.Format("Select pass From Sotrud Where login = '{0}'", login);
                    if (dataBase.GetPersonalData(query2, pass) == 1)
                    {
                        SudForm sud = new SudForm();
                        this.Hide();
                        sud.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }
        private void pictureSud_MouseMove(object sender, MouseEventArgs e)
        {
            if (sudstate == 1)
            {
                pictureSud.Cursor = Cursors.Hand;
                pictureSud.BackgroundImage = Properties.Resources.Sudya3;
                timer.Stop();
            }
        }
        private void pictureSud_MouseLeave(object sender, EventArgs e)
        {
            if (sudstate == 1)
            {
                pictureSud.Cursor = DefaultCursor;
                pictureSud.BackgroundImage = Properties.Resources.Sudya2;
                timer.Start();
            }
        }

        private void pictureChtec_Click(object sender, EventArgs e)
        {
            if (chtecstate == 1)
            {
                string query = String.Format("Select login From Sotrud Where login = '{0}'", login);
                string query2 = String.Format("Select pass From Sotrud Where login = '{0}'", login);
                login = textLogin.Text.ToString();
                query = String.Format("Select login From Sotrud Where login ='{0}'", login);
                if (dataBase.GetPersonalData(query, login) == 1)
                {
                    string pass = textPass.Text;
                    query2 = String.Format("Select pass From Sotrud Where login = '{0}'", login);
                    if (dataBase.GetPersonalData(query2, pass) == 1)
                    {
                        ChtecForm chtec = new ChtecForm();
                        this.Hide();
                        chtec.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }

        private void pictureChtec_MouseMove(object sender, MouseEventArgs e)
        {
            if (chtecstate == 1)
            {
                pictureChtec.Cursor = Cursors.Hand;
                pictureChtec.BackgroundImage = Properties.Resources.Chtec3;
                timer.Stop();
            }
        }
        private void pictureChtec_MouseLeave(object sender, EventArgs e)
        {
            if (chtecstate == 1)
            {
                pictureChtec.Cursor = DefaultCursor;
                pictureChtec.BackgroundImage = Properties.Resources.Chtec2;
                timer.Start();
            }
        }

        private void textLogin_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
        }
        #endregion
        #endregion
        #region Меню

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exit_CursorChanged(object sender, EventArgs e)
        {
            exit.Image = Properties.Resources.Cross1;
        }

        private void exit_MouseMove(object sender, MouseEventArgs e)
        {
            exit.Image = Properties.Resources.Cross1;
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.Image = Properties.Resources.Cross;
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        public void main_hover()
        {
            if (MainPanel.BackColor == Color.FromArgb(102, 122, 255))
            {
                MainPanel.BackColor = Color.FromArgb(95, 95, 255);
            }

        }
        private void labelStatus_Click(object sender, EventArgs e)
        {

        }
        public void main_leave()
        {
            if (MainPanel.BackColor == Color.FromArgb(95, 95, 255))
            {
                MainPanel.BackColor = Color.FromArgb(102, 122, 255);
            }
        }

        public void ochered_hover()
        {
            if (OcheredPanel.BackColor == Color.FromArgb(102, 122, 255))
            {
                OcheredPanel.BackColor = Color.FromArgb(95, 95, 255);
            }

        }

        public void ochered_leave()
        {
            if (OcheredPanel.BackColor == Color.FromArgb(95, 95, 255))
            {
                OcheredPanel.BackColor = Color.FromArgb(102, 122, 255);
            }
        }

        public void sprav_hover()
        {
            if (SpravPanel.BackColor == Color.FromArgb(102, 122, 255))
            {
                SpravPanel.BackColor = Color.FromArgb(95, 95, 255);
            }

        }

        public void sprav_leave()
        {
            if (SpravPanel.BackColor == Color.FromArgb(95, 95, 255))
            {
                SpravPanel.BackColor = Color.FromArgb(102, 122, 255);
            }
        }

        public void vhod_hover()
        {
            if (VhodPanel.BackColor == Color.FromArgb(102, 122, 255))
            {
                VhodPanel.BackColor = Color.FromArgb(95, 95, 255);
            }

        }

        public void vhod_leave()
        {
            if (VhodPanel.BackColor == Color.FromArgb(95, 95, 255))
            {
                VhodPanel.BackColor = Color.FromArgb(102, 122, 255);
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {
            this.main_click();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.main_click();
        }

        private void MainPanel_Click(object sender, EventArgs e)
        {
            this.main_click();
        }

        private void OcheredPanel_Click(object sender, EventArgs e)
        {
            this.ochered_click();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.ochered_click();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.ochered_click();
        }

        private void SpravPanel_Click(object sender, EventArgs e)
        {
            this.sprav_click();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.sprav_click();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.sprav_click();
        }

        private void VhodPanel_Click(object sender, EventArgs e)
        {
            this.vhod_click();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.vhod_click();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.vhod_click();
        }


        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            this.main_hover();
        }

        private void MainPanel_MouseLeave(object sender, EventArgs e)
        {
            this.main_leave();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            this.main_hover();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.main_leave();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.main_hover();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.main_leave();
        }

        private void OcheredPanel_MouseMove(object sender, MouseEventArgs e)
        {
            this.ochered_hover();
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            this.ochered_hover();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            this.ochered_hover();
        }

        private void OcheredPanel_MouseLeave(object sender, EventArgs e)
        {
            this.ochered_leave();
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            this.ochered_leave();
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.ochered_leave();
        }

        private void SpravPanel_MouseMove(object sender, MouseEventArgs e)
        {
            this.sprav_hover();
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            this.sprav_hover();
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            this.sprav_hover();
        }

        private void SpravPanel_MouseLeave(object sender, EventArgs e)
        {
            this.sprav_leave();
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            this.sprav_leave();
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.sprav_leave();
        }

        private void VhodPanel_MouseMove(object sender, MouseEventArgs e)
        {
            this.vhod_hover();
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            this.vhod_hover();
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            this.vhod_hover();
        }

        private void VhodPanel_MouseLeave(object sender, EventArgs e)
        {
            this.vhod_leave();
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            this.vhod_leave();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.vhod_leave();
        }
        #endregion
    }
}
