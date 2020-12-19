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
    public partial class BogForm : Form
    {
        Base dataBase = new Base();
        public string login2 = Main.login;
        public static string raikol = "0";
        public static int raikolvo = 0;
        public string mesto = "";
        public static string doljn2;
        public static string addid;
        public static int addid2;
        public static string loginUser;
        public static string passUser;
        public BogForm()
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
        private void BogForm_MouseDown(object sender, MouseEventArgs e)
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
            exit.Image = Properties.Resources.Cross1;
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
        { if (ProfPanel.BackColor == Color.FromArgb(95, 95, 255)) { ProfPanel.BackColor = Color.FromArgb(102, 122, 255); } }
        public void main_hover()
        { if (ProfPanel.BackColor == Color.FromArgb(102, 122, 255)) { ProfPanel.BackColor = Color.FromArgb(95, 95, 255); } }
        public void soul_leave()
        { if (SoulPanel.BackColor == Color.FromArgb(95, 95, 255)) { SoulPanel.BackColor = Color.FromArgb(102, 122, 255); } }
        public void soul_hover()
        { if (SoulPanel.BackColor == Color.FromArgb(102, 122, 255)) { SoulPanel.BackColor = Color.FromArgb(95, 95, 255); } }
        public void vihod_leave()
        { if (VihodPanel.BackColor == Color.FromArgb(95, 95, 255)) { VihodPanel.BackColor = Color.FromArgb(102, 122, 255); } }
        public void vihod_hover()
        { if (VihodPanel.BackColor == Color.FromArgb(102, 122, 255)) { VihodPanel.BackColor = Color.FromArgb(95, 95, 255); } }
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
            ProfPanel.BackColor = Color.FromArgb(134, 149, 255);
            SoulPanel.BackColor = Color.FromArgb(102, 122, 255);
            VihodPanel.BackColor = Color.FromArgb(102, 122, 255);
            panelVihod.Visible = false;
            panel2.Visible = true;
            panel4.Visible = false;

            Random rnd = new Random();
            int rndhi = rnd.Next(0, 3);
            if (rndhi == 0)
            {
                labelhi.Text = "Здравсвтуйте, Боже!";
            }
            else if (rndhi == 1)
            {
                labelhi.Text = "Благослови Вас Вы.";
            }
            else if (rndhi == 2)
            {
                labelhi.Text = "Души ждут.";
            }
            labelLogin.Text = Main.login;

            SatanaForm.adkol = String.Format("SELECT COUNT(status) FROM soul WHERE status = 6");
            SatanaForm.adkolvo = Convert.ToInt32(dataBase.GetFio(SatanaForm.adkol));

            raikol = String.Format("SELECT COUNT(status) FROM soul WHERE status = 5");
            labelRai.Text = dataBase.GetFio(raikol);
            string rairasp = String.Format("SELECT COUNT(status) FROM soul WHERE status = 3");
            labelRasp.Text = dataBase.GetFio(rairasp);

            raikolvo = Convert.ToInt32(labelRai.Text);

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chart1.Series[0].Points[0].YValues[0] = SatanaForm.adkolvo;
            chart1.Series[0].Points[0].Label = dataBase.GetFio(SatanaForm.adkol);
            chart1.Series[0].Points[1].YValues[0] = raikolvo;
            chart1.Series[0].Points[1].Label = dataBase.GetFio(raikol);

        }
        #endregion
        #region Души
        public void soul_click()
        {
            SoulPanel.BackColor = Color.FromArgb(134, 149, 255);
            ProfPanel.BackColor = Color.FromArgb(102, 122, 255);
            VihodPanel.BackColor = Color.FromArgb(102, 122, 255);
            panelVihod.Visible = false;
            panel2.Visible = false;
            panel4.Visible = true;

            ToolTip t = new ToolTip();
            t.SetToolTip(pictureBox7, "Эдем");
            t.SetToolTip(pictureBox8, "Элизиум");
            t.SetToolTip(pictureBox9, "Вальгалла");
            t.SetToolTip(pictureBox10, "Завербовать");
            string fio = String.Format("SELECT fio FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='3')");
            this.fio.Text = dataBase.GetFio(fio);
            string grehi = String.Format("SELECT zaslugi FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='3')");
            blag.Text = dataBase.GetFio(grehi);
            t.SetToolTip(blag, dataBase.GetFio(grehi));

            ////////////////////////////////////////////////]//////////////////////////////////////////////////////////////////////////////////////////////////////МЕНЯТЬ ТУТЬ
            try
            {
                this.soulTableAdapter.Rai2(this.heavenDataSet.Soul);
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

            int status = 5;
            string id = String.Format("SELECT id FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='3')");

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
        #region Mesta
        public void krug_click()
        {
            panelOk.Visible = true;
            panel1.Enabled = false;
            panel5.Enabled = false;
            exit.Enabled = false;
            dataGridView1.Enabled = false;
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.krug_click();
            label18.Text = "Отправить эту душу в Эдем?";
            mesto = "Эдем";
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.krug_click();
            label18.Text = "Отправить эту душу в Элизиум?";
            mesto = "Элизиум";
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.krug_click();
            label18.Text = "Отправить эту душу в Вальгаллу?";
            mesto = "Вальгалла";
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //this.krug_click();
            //label18.Text = "Завербовать эту душу?";
            mesto = "Раб";
            panelADDUSER.Visible = true;
            panel5.Enabled = false;

        }
        private void comboBoxDoljn_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxDoljn.Text != "")
            {
                label13.Visible = true; textID.Visible = true; textBoxPass.Visible = true; label13.Visible = true; label14.Visible = true;
                if (comboBoxDoljn.Text == "Смерть")
                {
                    addid = String.Format("SELECT id FROM Sotrud WHERE id = (SELECT MAX(id) FROM Sotrud WHERE doljn='Смерть')");
                    addid2 = Convert.ToInt32(dataBase.GetFio(addid)) + 1;
                    textID.Text = Convert.ToString(addid2);
                    loginUser = "Смерть" + Convert.ToString(addid2);
                    doljn2 = "Смерть";
                }
                else if (comboBoxDoljn.Text == "Чтец душ")
                {
                    addid = String.Format("SELECT id FROM Sotrud WHERE id = (SELECT MAX(id) FROM Sotrud WHERE doljn='Чтец душ')");
                    addid2 = Convert.ToInt32(dataBase.GetFio(addid)) + 1;
                    textID.Text = Convert.ToString(addid2);
                    loginUser = "Чтец" + Convert.ToString(addid2);
                    doljn2 = "Чтец душ";
                }
                else if (comboBoxDoljn.Text == "Судья")
                {
                    addid = String.Format("SELECT id FROM Sotrud WHERE id = (SELECT MAX(id) FROM Sotrud WHERE doljn='Судья')");
                    addid2 = Convert.ToInt32(dataBase.GetFio(addid)) + 1;
                    textID.Text = Convert.ToString(addid2);
                    loginUser = "Судья" + Convert.ToString(addid2);
                    doljn2 = "Судья";
                }
            }
        }
        private void textBoxPass_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPass.Text != "" && comboBoxDoljn.Text != "")
            {
                panel7.Visible = true;
                passUser = textBoxPass.Text;
            }
        }
        private void panel7_Click_1(object sender, EventArgs e)
        {
            panelUvol.Visible = true;
            panel1.Enabled = false;
            panel5.Enabled = false;
            exit.Enabled = false;
            panelADDUSER.Visible = false;
            dataGridView1.Visible = false;
            label10.Visible = false;
            panel6.Enabled = false;
            panel7.Enabled = false;
        }

        private void panel6_Click_1(object sender, EventArgs e)
        {
            panelADDUSER.Visible = false;
            panel5.Enabled = true;
            mesto = "";
        }
        private void buttonUvol_Click(object sender, EventArgs e)
        {
            string pass = textBox1.Text;
            string query2 = String.Format("Select pass From Sotrud Where login = '{0}'", login2);
            if (dataBase.GetPersonalData(query2, pass) == 1)
            {
                panelUvol.Visible = false;
                panelOk2.Visible = true;
                int point2 = 0;
                Base.AddUser(addid2, doljn2, point2, loginUser, passUser);
                mesto = loginUser;
                int status = 7;
                string id = String.Format("SELECT id FROM Soul WHERE id = (SELECT MIN(id) FROM Soul WHERE status='3')");
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
            panel5.Enabled = true;
            exit.Enabled = true;
            textBox1.Text = "";
            panelADDUSER.Visible = true;
            dataGridView1.Visible = true;
            label10.Visible = true;
            panel6.Enabled = true;
            panel7.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panelADDUSER.Visible = true;
            dataGridView1.Visible = true;
            label10.Visible = true;
            panelOk2.Visible = false;
            panel1.Enabled = true;
            panel5.Enabled = true;
            exit.Enabled = true;
            panel6.Enabled = true;
            panel7.Enabled = true;
            textBox1.Text = "";
            panelADDUSER.Visible = false;
            panel5.Enabled = true;
            mesto = "";
            textBoxPass.Text = "";
            textID.Text = "";
            comboBoxDoljn.SelectedIndex = -1;
            this.soul_click();
        }
        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox7.Image = Properties.Resources.EdemINV;
            label10.Text = "Эдем.";
            label11.Text = "Райских сад для хороших людей.";
            pictureBoxBG.Visible = true;
            pictureBoxBG.BackgroundImage = Properties.Resources.EdemBG;
            dataGridView1.Visible = false;
        }
        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.Edem;
            pictureBoxBG.Visible = false;
        }
        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox8.Image = Properties.Resources.ElysiumINV;
            label10.Text = "Элизиум.";
            label11.Text = "Райская VIP-зона. Для очень хороших людей.";
            pictureBoxBG.Visible = true;
            pictureBoxBG.BackgroundImage = Properties.Resources.ElysiumBG;
            dataGridView1.Visible = false;
        }
        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.Image = Properties.Resources.Elysium;
            pictureBoxBG.Visible = false;
        }
        private void pictureBox9_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox9.Image = Properties.Resources.ValhallaINV;
            label10.Text = "Вальгалла.";
            label11.Text = "Для павших в битве воинов.";
            dataGridView1.Visible = false;
            pictureBoxBG.Visible = true;
            pictureBoxBG.BackgroundImage = Properties.Resources.ValhallaBG;
        }
        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.Image = Properties.Resources.Valhalla;
            dataGridView1.Visible = false;
            pictureBoxBG.Visible = false;
            label10.Text = "Куда отправить эту душу?";
            label11.Text = "";
        }
        private void pictureBox10_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox10.Image = Properties.Resources.WorkINV;
            label10.Text = "Завербовать.";
            label11.Text = "Для особенных.";
            pictureBoxBG.Visible = true;
            pictureBoxBG.BackgroundImage = Properties.Resources.WorkBG;
            dataGridView1.Visible = false;
        }
        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.Image = Properties.Resources.Work;
            pictureBoxBG.Visible = false;
        }
        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            dataGridView1.Visible = false;
            pictureBoxBG.Visible = false;
            label10.Text = "Куда отправить эту душу?";
            label11.Text = "";
        }
        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            pictureBoxBG.Visible = false;
            label10.Text = "Обитатели рая:";
            label11.Text = "";
        }
        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            dataGridView1.Visible = true;
            pictureBoxBG.Visible = false;
            label10.Text = "Обитатели рая:";
            label11.Text = "";
        }
        private void panelOk_MouseMove(object sender, MouseEventArgs e)
        {
            dataGridView1.Visible = true;
            pictureBoxBG.Visible = false;
            label10.Text = "Обитатели рая:";
            label11.Text = "";
        }
        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            panel7.BackColor = Color.FromArgb(134, 149, 255);
        }
        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(102, 122, 255);
        }
        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            panel6.BackColor = Color.FromArgb(134, 149, 255);
        }
        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(102, 122, 255);
        }
        #endregion
        #endregion
        #region Выход
        public void vihod_click()
        {
            VihodPanel.BackColor = Color.FromArgb(134, 149, 255);
            ProfPanel.BackColor = Color.FromArgb(102, 122, 255);
            SoulPanel.BackColor = Color.FromArgb(102, 122, 255);
            panelVihod.Visible = true;
            panel2.Visible = false;
            panel4.Visible = false; 
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
            pictureBox3.BackgroundImage = Properties.Resources.Bog3;
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.Bog;
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

        private void BogForm_Load(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////]//////////////////////////////////////////////////////////////////////////////////////////////////////МЕНЯТЬ ТУТЬ
            // TODO: данная строка кода позволяет загрузить данные в таблицу "heavenDataSet.Soul". При необходимости она может быть перемещена или удалена.
            this.soulTableAdapter.Fill(this.heavenDataSet.Soul);

        }

    }
}
