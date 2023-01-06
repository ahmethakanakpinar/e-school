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
    public partial class form_sifredegistir : Form
    {
        static string bilgisayarAdi = Dns.GetHostName();
        static string constring = "Data Source=" + bilgisayarAdi + "\\SQLEXPRESS;Initial Catalog=eokul;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(constring);
        public form_sifredegistir()
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            form_yonetimpanel form_Yonetimpanel = new form_yonetimpanel();
            form_Yonetimpanel.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            form_yonetimpanel form_Yonetimpanel = new form_yonetimpanel();
            form_Yonetimpanel.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            form_yonetimpanel form_Yonetimpanel = new form_yonetimpanel();
            form_Yonetimpanel.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (form_yonetimpanel.giris == 100)
            {
                form_yonetimpanel form_Yonetimpanel = new form_yonetimpanel();
                form_Yonetimpanel.Show();
                this.Hide();
            }
            else if (form_yonetimpanel.giris == 50)
            {
                form_ogretmenpanel form_Ogretmenpanel = new form_ogretmenpanel();
                form_Ogretmenpanel.Show();
                this.Hide();

            }
            else if (form_yonetimpanel.giris == 0)
            {
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        public void degistir(string a)
        {
            if (tb_eskisifre.Text == Form2.girissifre.ToString())
            {
                if (tb_yenisifre.Text == tb_yenisifretekrar.Text)
                {
                    baglanti.Open();
                    //"Update muduryardimci Set sifre = @sifre, tekrarsifre = @tekrarsifre Where tc=@tc"
                    string kayitguncelle = (a);
                    SqlCommand komut = new SqlCommand(kayitguncelle, baglanti);
                    komut.Parameters.AddWithValue("@sifre", tb_yenisifre.Text);
                    komut.Parameters.AddWithValue("@tekrarsifre", tb_yenisifretekrar.Text);
                    komut.Parameters.AddWithValue("@tc", Form2.giristc.ToString());

                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Başarıyla Güncellendi");
                  
                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide();
                            
                  

                }
                else
                {
                    MessageBox.Show("Yeni Şifre ile Yeni Şifre Tekrar Uyuşmuyor");
                }
            }
            else
            {
                MessageBox.Show("Eski Şifre Hatalı Giriş");
            }
        }
        private void bt_sifred_Click(object sender, EventArgs e)
        {
            if(form_yonetimpanel.giris == 100)
            {
                degistir("Update muduryardimci Set sifre = @sifre, tekrarsifre = @tekrarsifre Where tc=@tc");
            }
            else if(form_yonetimpanel.giris == 50)
            {
                degistir("Update ogretmen Set sifre = @sifre, tekrarsifre = @tekrarsifre Where tc=@tc");
            }
            else if(form_yonetimpanel.giris == 0)
            {
                degistir("Update ogrenci Set sifre = @sifre, tekrarsifre = @tekrarsifre Where tc=@tc");
            }
         
        }

        private void tb_yenisifretekrar_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == Keys.Enter)
                {
                    bt_sifred_Click(sender, e);
                }
          
        }

        private void form_sifredegistir_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand commandogr = new SqlCommand("Select * From muduryardimci", baglanti);
            SqlDataReader drogr = commandogr.ExecuteReader();
            while (drogr.Read())
            {
                   if(Form2.giristc != drogr[2].ToString() && drogr[7].ToString() != "Müdür")
                    cb_muduryardimci.Items.Add(drogr[0].ToString() + " " + drogr[1].ToString());

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand commandogr2 = new SqlCommand("Select * From ogretmen", baglanti);
            SqlDataReader drogr2 = commandogr2.ExecuteReader();
            while (drogr2.Read())
            {
                
                    cb_ogretmen.Items.Add(drogr2[0].ToString() + " " + drogr2[1].ToString());

            }
            baglanti.Close();

            if(form_yonetimpanel.giris != 100)
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage4);
            }
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayitguncelle = ("Update muduryardimci Set sifre = @sifre, tekrarsifre = @tekrarsifre where adi+' '+soyadi = @adi");

            SqlCommand komut = new SqlCommand(kayitguncelle, baglanti);
            komut.Parameters.AddWithValue("@sifre", textBox4.Text);
            komut.Parameters.AddWithValue("@tekrarsifre", textBox5.Text);
            komut.Parameters.AddWithValue("@adi", cb_muduryardimci.SelectedItem.ToString());

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Güncellendi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayitguncelle = ("Update ogretmen Set sifre = @sifre, tekrarsifre = @tekrarsifre where adi+' '+soyadi = @adi");

            SqlCommand komut = new SqlCommand(kayitguncelle, baglanti);
            komut.Parameters.AddWithValue("@sifre", textBox7.Text);
            komut.Parameters.AddWithValue("@tekrarsifre", textBox8.Text);
            komut.Parameters.AddWithValue("@adi", cb_ogretmen.SelectedItem.ToString());

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Güncellendi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayitguncelle = ("Update ogrenci Set sifre = @sifre, tekrarsifre = @tekrarsifre where tc = @tc");

            SqlCommand komut = new SqlCommand(kayitguncelle, baglanti);
            komut.Parameters.AddWithValue("@sifre", textBox10.Text);
            komut.Parameters.AddWithValue("@tekrarsifre", textBox11.Text);
            komut.Parameters.AddWithValue("@tc", textBox13.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Güncellendi");
        }
    }
}
