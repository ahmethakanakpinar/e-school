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
using System.Net;

namespace e_okul
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        static string bilgisayarAdi = Dns.GetHostName();
        static string constring = "Data Source=" + bilgisayarAdi + "\\SQLEXPRESS;Initial Catalog=eokul;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(constring);
        public static string girisadsoyad;
        public static string girissifre;
        public static string giristc;
        public static string girisbolum;
        public static string girissinif;
        private void button_giris_Click(object sender, EventArgs e)
        {

            string resimkarakter;
            string kullaniciadi;
            string sifre;
            int giris = 0;

            resimkarakter = tb_resimkarakter.Text;
            kullaniciadi = tb_kullaniciadi.Text;
            sifre = tb_sifre.Text;
            if (Form1.tiklanma == 1)
            {
               

                if(resimkarakter == tb_resim.Text)
                {
                    baglanti.Open();
                    SqlCommand commandmdr = new SqlCommand("Select * From muduryardimci", baglanti);
                    SqlDataReader drmdr = commandmdr.ExecuteReader();
                    while (drmdr.Read())
                    {
                        if (drmdr[2].ToString() == kullaniciadi && drmdr[3].ToString() == sifre)
                        {
                            girisadsoyad = drmdr[0].ToString() + " " + drmdr[1].ToString();
                            girissifre = drmdr[3].ToString();
                            giristc = drmdr[2].ToString();
                            giris = 1;
                            form_yonetimpanel form_yonetimpanel = new form_yonetimpanel();
                            form_yonetimpanel.Show();
                            this.Hide();
                            form_yonetimpanel.giris = 100;
                        }
                    }
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand commandogretmen = new SqlCommand("Select * From ogretmen", baglanti);
                    SqlDataReader drogretmen = commandogretmen.ExecuteReader();
                    while (drogretmen.Read())
                    {
                        if (drogretmen[2].ToString() == kullaniciadi && drogretmen[4].ToString() == sifre)
                        {
                            girisadsoyad = drogretmen[0].ToString() + " " + drogretmen[1].ToString();
                            girissifre = drogretmen[4].ToString();
                            giristc = drogretmen[2].ToString();
                            girisbolum = drogretmen[3].ToString();
                            giris = 1;
                           form_ogretmenpanel form_Ogretmenpanel = new form_ogretmenpanel();
                            form_Ogretmenpanel.Show();
                            this.Hide();
                            form_yonetimpanel.giris = 50;




                        }
                    }
                    if (giris == 0)
                    {
                        MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı");
                    }
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Resimdeki Rakamlar Hatalı Girilmiştir");
                }
             
               

            }
            if (Form1.tiklanma == 2)
            {
                if (resimkarakter == tb_resim.Text)
                {
                    baglanti.Open();
                    SqlCommand commandmdr = new SqlCommand("Select * From ogrenci", baglanti);
                    SqlDataReader drmdr = commandmdr.ExecuteReader();
                    while (drmdr.Read())
                    {
                        if (drmdr[2].ToString() == kullaniciadi && drmdr[3].ToString() == sifre)
                        {
                            girisadsoyad = drmdr[0].ToString() + " " + drmdr[1].ToString();
                            girissifre = drmdr[3].ToString();
                            giristc = drmdr[2].ToString();
                        girisbolum = drmdr[6].ToString();
                        girissinif = drmdr[7].ToString();
                        
                            giris = 1;
                            Form3 form3 = new Form3();
                            form3.Show();
                            this.Hide();
                        form_yonetimpanel.giris = 0;




                    }
                    }
                    if (giris == 0)
                    {
                        MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı");
                    }
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Resimdeki Rakamlar Hatalı Girilmiştir");
                }



            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int RastgeleSayi1 = rnd.Next(1000, 9999);
            tb_resim.Text = RastgeleSayi1.ToString();
        }

        private void tb_kullaniciadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tb_resimkarakter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tb_sifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_giris_Click(sender, e);
            }
        }
    }
}
