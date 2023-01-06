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
    public partial class form_yonetimpanel : Form
    {
        public form_yonetimpanel()
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
        public static int giris;
        private void pictureBox_duyurularpanel_Click(object sender, EventArgs e)
        {
            giris = 100;
            form_duyurular form_Duyurular = new form_duyurular();
            form_Duyurular.Show();
            this.Hide();
        }

        private void pictureBox_yoneticipanel_Click(object sender, EventArgs e)
        {
            form_yoneticipaneli form_Yoneticipaneli = new form_yoneticipaneli();
            form_Yoneticipaneli.Show();
            this.Hide();
        }

        private void pictureBox_ogretmenpanel_Click(object sender, EventArgs e)
        {
            form_ogretmenpaneli form_Ogretmenpaneli = new form_ogretmenpaneli();
            form_Ogretmenpaneli.Show();
            this.Hide();
        }

        private void pictureBox_ogrencipanel_Click(object sender, EventArgs e)
        {
            form_ogrencipaneli form_Ogrencipaneli = new form_ogrencipaneli();
            form_Ogrencipaneli.Show();
            this.Hide();
        }

        private void pictureBox_derslerpanel_Click(object sender, EventArgs e)
        {
            form_derslerpaneli form_Derslerpaneli= new form_derslerpaneli();
            form_Derslerpaneli.Show();
            this.Hide();
        }

        private void pictureBox_siniflarpanel_Click(object sender, EventArgs e)
        {
            form_bolumlerpaneli form_Bolumlerpaneli= new form_bolumlerpaneli();
            form_Bolumlerpaneli.Show();
            this.Hide();
        }

        private void pictureBox_dersprogrami_Click(object sender, EventArgs e)
        {
            form_haftalikdersprogrami form_Haftalikdersprogrami = new form_haftalikdersprogrami();
            form_Haftalikdersprogrami.Show();
            this.Hide();
        }

        private void pictureBox_paroladegistir_Click(object sender, EventArgs e)
        {
            form_sifredegistir form_Sifredegistir = new form_sifredegistir();
            form_Sifredegistir.Show();
            this.Hide();
        }

        private void pictureBox_notlarpanel_Click(object sender, EventArgs e)
        {
            form_notlarpaneli form_Notlarpaneli = new form_notlarpaneli();
            form_Notlarpaneli.Show();
            this.Hide();
        }

        private void form_yonetimpanel_Load(object sender, EventArgs e)
        {
       
            Form2 form2 = new Form2();
            label4.Text = "Hoşgeldin "+Form2.girisadsoyad.ToString();
        }
    }
}
