using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace e_okul
{
    public partial class form_ogretmenpanel : Form
    {
        public form_ogretmenpanel()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

      

        private void pictureBoxogr_duyurularpanel_Click(object sender, EventArgs e)
        {
            form_yonetimpanel.giris = 50;
            form_duyurular form_Duyurular = new form_duyurular();
            form_Duyurular.Show();
            this.Hide();
            form_Duyurular.checkBoxdyr_mdryardimci.Visible = false;
            form_Duyurular.label1.Location = new Point(435, 52);
        }

        private void pictureBoxogr_dersprogrami_Click(object sender, EventArgs e)
        {
            form_yonetimpanel.giris = 50;
            form_haftalikdersogrenci form_Haftalikdersogrenci = new form_haftalikdersogrenci();
            form_Haftalikdersogrenci.Show();
            this.Hide();
        }

        private void pictureBoxogr_paroladegistir_Click(object sender, EventArgs e)
        {
            form_yonetimpanel.giris = 50;
            form_sifredegistir form_Sifredegistir = new form_sifredegistir();
            form_Sifredegistir.Show();
            this.Hide();
            form_Sifredegistir.tabPage1.Text = "Öğretmen";
        }

        private void pictureBox_notlarpanel_Click(object sender, EventArgs e)
        {
            form_yonetimpanel.giris = 50;
            form_notlarpaneli form_Notlarpaneli = new form_notlarpaneli();
            form_Notlarpaneli.Show();
            this.Hide();
            form_Notlarpaneli.label72.Visible = false;
            form_Notlarpaneli.cbognot_sinifi.Visible = false;
        }

        private void form_ogretmenpanel_Load(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            label4.Text = "Hoşgeldin " + Form2.girisadsoyad.ToString();
        }
    }
}
