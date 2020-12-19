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
    public partial class AdminForm : Form
    {
        Base dataBase = new Base();
        public AdminForm()
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
        private void AdminForm_MouseDown(object sender, MouseEventArgs e)
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
        #region Удаление и добавление
        public void prof_click()
        {
            ProfPanel.BackColor = Color.Purple;
            SoulPanel.BackColor = Color.Indigo;
            VihodPanel.BackColor = Color.Indigo;
            panelVihod.Visible = false;
            panel6.Visible = true;
            panel2.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить пользователя?", "Удаление", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string login = comboBox1.Text;
                Base.Delete(login);

                DataUpdate();
            }
            else this.prof_click();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Добавить пользователя?", "Добавление", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                int addid2 = Convert.ToInt32(textID.Text);
                string doljn2 = comboDoljn.Text;
                int point2 = 0;
                string loginUser = textLogin.Text;
                string passUser = textPass.Text;
                Base.AddUser(addid2, doljn2, point2, loginUser, passUser);

                DataUpdate();
            }
            else this.prof_click();
        }
        #endregion
        #region Клиенты
        public void soul_click()
        {
            SoulPanel.BackColor = Color.Purple;

            ProfPanel.BackColor = Color.Indigo;
            VihodPanel.BackColor = Color.Indigo;
            panelVihod.Visible = false;
            panel6.Visible = false;
            panel2.Visible = true;
        }
        private void textIdSoul_TextChanged(object sender, EventArgs e)
        {
            if (textIdSoul.Text != "")
            {
                int id = Convert.ToInt32(textIdSoul.Text);
                string status = String.Format("Select status From Soul Where id = '{0}'", id);
                string fio = String.Format("Select fio From Soul Where id = '{0}'", id);
                string gender = String.Format("Select gender From Soul Where id = '{0}'", id);
                string smert = String.Format("Select smert From Soul Where id = '{0}'", id);
                string zaslugi = String.Format("Select zaslugi From Soul Where id = '{0}'", id);
                string grehi = String.Format("Select grehi From Soul Where id = '{0}'", id);
                string mesto = String.Format("Select mesto From Soul Where id = '{0}'", id);
                textStatus.Text = dataBase.GetFio(status);
                textName.Text = dataBase.GetFio(fio);
                textGender.Text = dataBase.GetFio(gender);
                textSmert.Text = dataBase.GetFio(smert);
                textZaslugi.Text = dataBase.GetFio(zaslugi);
                textGrehi.Text = dataBase.GetFio(grehi);
                textMesto.Text = dataBase.GetFio(mesto);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textStatus.Enabled = true;
            textName.Enabled = true;
            textGender.Enabled = true;
            textSmert.Enabled = true;
            textZaslugi.Enabled = true;
            textGrehi.Enabled = true;
            textMesto.Enabled = true;
            button3.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Применить изменения души?", "Изменение", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(textIdSoul.Text);
                int status = Convert.ToInt32(textStatus.Text);
                string fio = textName.Text;
                string gender = textGender.Text;
                string smert = textSmert.Text;
                string zaslugi = textZaslugi.Text ;
                string grehi = textGrehi.Text;
                string mesto = textMesto.Text;
                Base.ChangeSoul(id, status, fio, gender, smert, zaslugi, grehi, mesto);

                DataUpdate(); 

                textStatus.Enabled = false;
                textName.Enabled = false;
                textGender.Enabled = false;
                textSmert.Enabled = false;
                textZaslugi.Enabled = false;
                textGrehi.Enabled = false;
                textMesto.Enabled = false;
                button3.Enabled = false;
            }
            else this.soul_click();
        }
        #endregion
        #region Выход
        public void vihod_click()
        {
            VihodPanel.BackColor = Color.Purple;

            ProfPanel.BackColor = Color.Indigo;
            SoulPanel.BackColor = Color.Indigo;
            panel6.Visible = false;
            panelVihod.Visible = true;
            panel2.Visible = false;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
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

        private void AdminForm_Load(object sender, EventArgs e)
        {
            DataUpdate();
        }
        public void DataUpdate() ////////////////////////////////////АаааааааааааааааААААААААААААааааааааааааааааа. Вот.
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "heavenDataSet.Soul". При необходимости она может быть перемещена или удалена.
           // this.soulTableAdapter.Fill(this.heavenDataSet.Soul);
          //  this.sotrudTableAdapter.Fill(this.heavenDataSet1.Sotrud);
        }
    }
}
