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
    public partial class SatanaForm : Form
    {
        Base dataBase = new Base();
        public string login2 = Main.login;
        public static string adkol = "0";
        public static int adkolvo = 0;
        public string mesto = "";
        public SatanaForm()
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
        private void SatanaForm_MouseDown(object sender, MouseEventArgs e)
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
            exit.Image = Properties.Resources.CrossSatan;
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
        { if (ProfPanel.BackColor == Color.BlueViolet) { ProfPanel.BackColor = Color.Indigo; } }
        public void main_hover()
        { if (ProfPanel.BackColor == Color.Indigo) { ProfPanel.BackColor = Color.BlueViolet; } }
        public void soul_leave()
        { if (SoulPanel.BackColor == Color.BlueViolet) { SoulPanel.BackColor = Color.Indigo; } }
        public void soul_hover()
        { if (SoulPanel.BackColor == Color.Indigo) { SoulPanel.BackColor = Color.BlueViolet; } }
        public void vihod_leave()
        { if (VihodPanel.BackColor == Color.BlueViolet) { VihodPanel.BackColor = Color.Indigo; } }
        public void vihod_hover()
        { if (VihodPanel.BackColor == Color.Indigo) { VihodPanel.BackColor = Color.BlueViolet; } }
        public void rab_leave()
        { if (RabPanel.BackColor == Color.BlueViolet) { RabPanel.BackColor = Color.Indigo; } }
        public void rab_hover()
        { if (RabPanel.BackColor == Color.Indigo) { RabPanel.BackColor = Color.BlueViolet; } }
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
        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            this.rab_hover();
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            this.rab_leave();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            this.rab_click();
        }
        #endregion
        #region Профиль
        public void prof_click()
        {
            ProfPanel.BackColor = Color.Purple;
            SoulPanel.BackColor = Color.Indigo;
            VihodPanel.BackColor = Color.Indigo;
            RabPanel.BackColor = Color.Indigo;
            panelVihod.Visible = false;
            panel2.Visible = true;
            panel6.Visible = false;
            panel4.Visible = false;

            Random rnd = new Random();
            int rndhi = rnd.Next(0, 1);
            if (rndhi == 0)
            {
                labelhi.Text = "Слава Сатане!";
            }
            else if (rndhi == 1)
            {
                labelhi.Text = "Души ждут.";
            }
            labelLogin.Text = Main.login;

            BogForm.raikol = String.Format("SELECT COUNT(status) FROM soul WHERE status = 5");
            BogForm.raikolvo = Convert.ToInt32(dataBase.GetFio(BogForm.raikol));

            adkol = String.Format("SELECT COUNT(status) FROM soul WHERE status = 6");
            labelRai.Text = dataBase.GetFio(adkol);
            string adrasp = String.Format("SELECT COUNT(status) FROM soul WHERE status = 4");
            labelRasp.Text = dataBase.GetFio(adrasp);
            adkolvo = Convert.ToInt32(labelRai.Text);

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chart1.Series[0].Points[0].YValues[0] = adkolvo;
            chart1.Series[0].Points[0].Label = dataBase.GetFio(adkol);
            chart1.Series[0].Points[1].YValues[0] = BogForm.raikolvo;
            chart1.Series[0].Points[1].Label = dataBase.GetFio(BogForm.raikol);
        }
        #endregion
        #region Души
        public void soul_click()
        {
            SoulPanel.BackColor = Color.Purple;
            ProfPanel.BackColor = Color.Indigo;
            VihodPanel.BackColor = Color.Indigo;
            RabPanel.BackColor = Color.Indigo;
            panelVihod.Visible = false;
            panel2.Visible = false;
            panel4.Visible = true;
            panel6.Visible = false;

            ToolTip t = new ToolTip();
            t.SetToolTip(krug1, "1 круг");
            t.SetToolTip(krug2, "2 круг");
            t.SetToolTip(krug3, "3 круг");
            t.SetToolTip(krug4, "4 круг");
            t.SetToolTip(krug5, "5 круг");
            t.SetToolTip(krug6, "6 круг");
            t.SetToolTip(krug7, "7 круг");
            t.SetToolTip(krug8, "8 круг");
            t.SetToolTip(krug9, "9 круг");

            string fio = String.Format("SELECT fio FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='4')");
            label13.Text = dataBase.GetFio(fio);
            string grehi = String.Format("SELECT grehi FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='4')");
            label22.Text = dataBase.GetFio(grehi);
            t.SetToolTip(label22, dataBase.GetFio(grehi));

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////МЕНЯТЬ ТУТЬ
            try
            {
                this.soulTableAdapter.Adlife(this.heavenDataSet.Soul);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            ////////////////////////////////////////////////]//////////////////////////////////////////////////////////////////////////////////////////////////////МЕНЯТЬ ТУТЬ
        }
        private void buttonYes_Click(object sender, EventArgs e)
        {
            panelOk.Visible = false;
            panel9.Visible = true;

            int status = 6;
            string id = String.Format("SELECT id FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='4')");

            Base.SudSoul(dataBase.GetFio(id), status, mesto);
        }
        private void buttonNo_Click(object sender, EventArgs e)
        {
            panelOk.Visible = false;
            panel1.Enabled = true;
            panel5.Enabled = true;
            exit.Enabled = true;
            dataGridView1.Enabled = true;
            mesto = "";
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
            panel1.Enabled = true;
            exit.Enabled = true;
            panel5.Enabled = true;
            dataGridView1.Enabled = true;
            mesto = "";
            this.soul_click();
        }

        #region Кружки
        public void krug_click()
        {
            panelOk.Visible = true;
            panel1.Enabled = false;
            panel5.Enabled = false;
            exit.Enabled = false;
            dataGridView1.Enabled = false;
        }
        private void krug1_Click(object sender, EventArgs e)
        {
            this.krug_click();
            label18.Text = "Отправить эту душу на 1 круг ада?";
            mesto = "1 круг";
        }
        private void krug2_Click(object sender, EventArgs e)
        {
            this.krug_click();
            label18.Text = "Отправить эту душу на 2 круг ада?";
            mesto = "2 круг";
        }
        private void krug3_Click(object sender, EventArgs e)
        {
            this.krug_click();
            label18.Text = "Отправить эту душу на 3 круг ада?";
            mesto = "3 круг";
        }
        private void krug4_Click(object sender, EventArgs e)
        {
            this.krug_click();
            label18.Text = "Отправить эту душу на 4 круг ада?";
            mesto = "4 круг";
        }
        private void krug5_Click(object sender, EventArgs e)
        {
            this.krug_click();
            label18.Text = "Отправить эту душу на 5 круг ада?";
            mesto = "5 круг";
        }
        private void krug6_Click(object sender, EventArgs e)
        {
            this.krug_click();
            label18.Text = "Отправить эту душу на 6 круг ада?";
            mesto = "6 круг";
        }
        private void krug7_Click(object sender, EventArgs e)
        {
            this.krug_click();
            label18.Text = "Отправить эту душу на 7 круг ада?";
            mesto = "7 круг";
        }
        private void krug8_Click(object sender, EventArgs e)
        {
            this.krug_click();
            label18.Text = "Отправить эту душу на 8 круг ада?";
            mesto = "8 круг";
        }
        private void krug9_Click(object sender, EventArgs e)
        {
            this.krug_click();
            label18.Text = "Отправить эту душу на 9 круг ада?";
            mesto = "9 круг";
        }
        private void panel5_Paint(object sender, PaintEventArgs e){ }
        private void krug1_MouseMove(object sender, MouseEventArgs e)
        {
            krug1.Image = Properties.Resources.Penta2;
            this.krug_move();
            label10.Text = "Первый круг (Лимб)\nСтраж: Харон.\nВид наказания: Безбольная скорбь.\nТомящиеся: Некрещёные младенцы и добродетельные нехристиане.";
        }
        private void krug2_MouseMove(object sender, MouseEventArgs e)
        {
            krug2.Image = Properties.Resources.Penta2;
            this.krug_move();
            label10.Text = "Второй круг ада.\nСтраж: Минос.\nВид наказания: Кручение и истязание бурей.\nТомящиеся: Сладострастники (блудники и прелюбодеи, просто страстные любовники).";
        }
        private void krug3_MouseMove(object sender, MouseEventArgs e)
        {
            krug3.Image = Properties.Resources.Penta2;
            this.krug_move();
            label10.Text = "Третий круг ада.\nСтраж: Цербер.\nВид наказания: Гниение под солнцем и дождём.\nТомящиеся: Чревоугодники, обжоры и гурманы.";
        }
        private void krug4_MouseMove(object sender, MouseEventArgs e)
        {
            krug4.Image = Properties.Resources.Penta2;
            this.krug_move();
            label10.Text = "Четвертый круг ада.\nСтраж: Плутос.\nВид наказания: Вечный спор.\nТомящиеся: Скупцы и расточители (Неумевшие совершать разумные траты).";
        }
        private void krug5_MouseMove(object sender, MouseEventArgs e)
        {
            krug5.Image = Properties.Resources.Penta2;
            this.krug_move();
            label10.Text = "Пятый круг (Стигийское болото)\nСтраж: Флегий — перевозчик через болото.\nВид наказания: Вечная драка по горло в болоте.\nТомящиеся: Гневные и ленивые.";
        }
        private void krug6_MouseMove(object sender, MouseEventArgs e)
        {
            krug6.Image = Properties.Resources.Penta2;
            this.krug_move();
            label10.Text = "Шестой круг (Стены города Дита)\nСтраж: Фурии.\nВид наказания: Раскаленные могилы.\nТомящиеся: Еретики и лжеучители";
        }
        private void krug7_MouseMove(object sender, MouseEventArgs e)
        {
            krug7.Image = Properties.Resources.Penta2;
            this.krug_move();
            label10.Text = "Седьмой круг ада.\nСтраж: Минотавр.\nВид наказания: Кипение в кровавой реке.\nТомящиеся: Совершавшие насилие.";
        }
        private void krug8_MouseMove(object sender, MouseEventArgs e)
        {
            krug8.Image = Properties.Resources.Penta2;
            this.krug_move();
            label10.Text = "Восьмой круг (Злопазухи, или Злые Щели)\nСтраж: Герион.\nВид наказания: Ну... там много всего...\nТомящиеся: Воры, лицемеры, льстецы, взяточники и тп.";
        }
        private void krug9_MouseMove(object sender, MouseEventArgs e)
        {
            krug9.Image = Properties.Resources.Penta2;
            this.krug_move();
            label10.Text = "Девятый круг (Ледяное озеро Коцит)\nСтраж: Гиганты.\nВид наказания: Вмерзание в лёд по шею.\nТомящиеся: Обманувшие доверившихся, предатели.";
        }
        public void krug_move()
        {
            label11.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            dataGridView1.Visible = false;
        }
        private void krug8_MouseLeave(object sender, EventArgs e)
        {
            krug1.Image = Properties.Resources.pentagon;
            krug2.Image = Properties.Resources.pentagon;
            krug3.Image = Properties.Resources.pentagon;
            krug4.Image = Properties.Resources.pentagon;
            krug5.Image = Properties.Resources.pentagon;
            krug6.Image = Properties.Resources.pentagon;
            krug7.Image = Properties.Resources.pentagon;
            krug8.Image = Properties.Resources.pentagon;
            krug9.Image = Properties.Resources.pentagon;
            label10.Text = "Куда отправить этого грешника?";
            label11.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
        }
        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            label10.Text = "Куда отправить этого грешника?";
            dataGridView1.Visible = false;
        }
        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            label10.Text = "Обитатели ада:";
            label11.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            dataGridView1.Visible = true;
        }
        private void panel4_MouseMove_1(object sender, MouseEventArgs e)
        {
            label10.Text = "Обитатели ада:";
            label11.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            dataGridView1.Visible = true;
        }
        private void panelOk_MouseMove(object sender, MouseEventArgs e)
        {
            label10.Text = "Обитатели ада:";
            label11.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            dataGridView1.Visible = true;
        }
        #endregion
        #endregion
        #region Рабы
        public void rab_click()
        {
            RabPanel.BackColor = Color.Purple;
            ProfPanel.BackColor = Color.Indigo;
            VihodPanel.BackColor = Color.Indigo;
            SoulPanel.BackColor = Color.Indigo;
            panelVihod.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel6.Visible = true;
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)//////////////////////////////////////////////////////////////////////////////////////////////////////МЕНЯТЬ ТУТЬ
        {
            if (comboBox1.Text != "") 
            {
                label20.Visible = true; comboBox2.Visible = true; 
                if(comboBox1.Text == "Смерть")
                {
                    try
                    {
                        this.sotrudTableAdapter.Smert(this.heavenDataSet1.Sotrud);
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
                else if (comboBox1.Text == "Чтец душ")
                {
                    try
                    {
                        this.sotrudTableAdapter.Chtec(this.heavenDataSet1.Sotrud);
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
                else if (comboBox1.Text == "Судья") 
                {
                    try
                    {
                        this.sotrudTableAdapter.Sudya(this.heavenDataSet1.Sotrud);
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
            }
        }///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////МЕНЯТЬ ТУТЬ
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox1.Text != "") { panel7.Visible = true; }
        }
        private void panel7_Click(object sender, EventArgs e)
        {
            panelUvol.Visible = true;
            panel1.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            exit.Enabled = false;
        }
        private void buttonUvol_Click(object sender, EventArgs e)
        {
            string pass = textBoxPass.Text;
            string query2 = String.Format("Select pass From Sotrud Where login = '{0}'", login2);
            if (dataBase.GetPersonalData(query2, pass) == 1)
            {
                panelUvol.Visible = false;
                panelOk2.Visible = true;

                string loginSotrud = comboBox2.Text;
                Base.Delete(loginSotrud);


                string id = String.Format("SELECT id FROM Soul WHERE mesto = '{0}'", loginSotrud);
                int status = 6;
                mesto = "Круг рабов";
                Base.SudSoul(dataBase.GetFio(id), status, mesto);
            }
            else
            {
                MessageBox.Show("Неверный пароль");
            }
        }
        private void buttonChanel_Click(object sender, EventArgs e)
        {
            panelUvol.Visible = false;
            panel1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            exit.Enabled = true;
            textBoxPass.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panelOk2.Visible = false;
            panel1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            exit.Enabled = true;
            comboBox1.SelectedIndex = -1;
            comboBox2.Visible = false;
            label20.Visible = false;
            panel7.Visible = false;
            textBoxPass.Text = "";
        }
        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            panel7.BackColor = Color.Purple;
        }
        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Indigo;
        }
        private void SatanaForm_Load(object sender, EventArgs e)/////////////////////////////////////////////////////////////////////////////////////////////////////////////МЕНЯТЬ ТУТЬ
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "heavenDataSet1.Sotrud". При необходимости она может быть перемещена или удалена.
            this.sotrudTableAdapter.Fill(this.heavenDataSet1.Sotrud);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "heavenDataSet.Soul". При необходимости она может быть перемещена или удалена.
            this.soulTableAdapter.Fill(this.heavenDataSet.Soul);

        }
        #endregion
        #region Выход
        public void vihod_click()
        {
            VihodPanel.BackColor = Color.Purple;
            ProfPanel.BackColor = Color.Indigo;
            SoulPanel.BackColor = Color.Indigo;
            RabPanel.BackColor = Color.Indigo;
            panelVihod.Visible = true;
            panel2.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
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
            pictureBox3.BackgroundImage = Properties.Resources.Satana2;
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.Satana;
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
