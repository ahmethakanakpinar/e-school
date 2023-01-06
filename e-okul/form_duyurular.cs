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
    public partial class form_duyurular : Form
    {
        public form_duyurular()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(form_yonetimpanel.giris == 100 )
            {
                form_yonetimpanel form_Yonetimpanel = new form_yonetimpanel();
                form_Yonetimpanel.Show();
                this.Hide();
                //sa
            }
            else if(form_yonetimpanel.giris == 50)
            {
                form_ogretmenpanel form_Ogretmenpanel = new form_ogretmenpanel();
                form_Ogretmenpanel.Show();
                this.Hide();

            }
           
        }
        static string bilgisayarAdi = Dns.GetHostName();
        static string constring = "Data Source=" + bilgisayarAdi + "\\SQLEXPRESS;Initial Catalog=eokul;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(constring);
        public void KisiListele(string a)
        {
            listBoxdyr_baslik.Items.Clear();
            baglanti.Open();
            SqlCommand commanddyr = new SqlCommand(a, baglanti);
            SqlDataReader drdyr = commanddyr.ExecuteReader();
            while (drdyr.Read())
            {
                listBoxdyr_baslik.Items.Add(drdyr[0].ToString());
            }
            baglanti.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into duyurular (baslik,mesaj,muduryardimci,ogretmen,ogrenci,yazankisi) values(@baslik,@mesaj,@muduryardimci,@ogretmen,@ogrenci,@yazankisi)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@baslik", textBoxdyr_baslik.Text);
                komut.Parameters.AddWithValue("@mesaj", richTextBoxdyr_mesaj.Text);
                if(checkBoxdyr_mdryardimci.Checked == true)
                {
                   
                    komut.Parameters.AddWithValue("@muduryardimci", "evet");
                }
                else
                {
                    komut.Parameters.AddWithValue("@muduryardimci", "hayır");
                }
                if (checkBoxdyr_ogretmen.Checked == true)
                {

                    komut.Parameters.AddWithValue("@ogretmen", "evet");
                }
                else
                {
                    komut.Parameters.AddWithValue("@ogretmen", "hayır");
                }
                if (checkBoxdyr_ogrenci.Checked == true)
                {
                    komut.Parameters.AddWithValue("@ogrenci", "evet");
                }
                else
                {
                    komut.Parameters.AddWithValue("@ogrenci", "hayır");
                }
                komut.Parameters.AddWithValue("@yazankisi", label4.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayit Eklendi");
                textBoxdyr_baslik.Clear();


                bul();
                richTextBoxdyr_mesaj.Clear();
                textBoxdyr_baslik.Clear();
                checkBoxdyr_ogrenci.Checked = false;
                checkBoxdyr_mdryardimci.Checked = false;
                checkBoxdyr_ogretmen.Checked = false;

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hatali " + hata.Message);
            }
        }

        private void form_duyurular_Load(object sender, EventArgs e)
        {
            if(form_yonetimpanel.giris.ToString() == 100.ToString())
            {
                 KisiListele("Select * from duyurular");
                Form2 form2 = new Form2();
                label4.Text = Form2.girisadsoyad.ToString();
                pictureBoxdyr_kaydet.Visible = false;
                pictureBoxdyr_sil.Visible = false;
            }    
           else if(form_yonetimpanel.giris.ToString() == 0.ToString())
            {
                KisiListele("select * from duyurular where ogrenci = 'evet'");
                Form2 form2 = new Form2();
                label4.Text = Form2.girisadsoyad.ToString();
                pictureBoxdyr_kaydet.Visible = false;
                pictureBoxdyr_sil.Visible = false;
            }
            else if (form_yonetimpanel.giris.ToString() == 50.ToString())
            {
                KisiListele("select * from duyurular where ogrenci = 'evet' or ogretmen = 'evet' ");
                Form2 form2 = new Form2();
                label4.Text = Form2.girisadsoyad.ToString();
                pictureBoxdyr_kaydet.Visible = false;
                pictureBoxdyr_sil.Visible = false;
            }


        }

        private void listBoxdyr_baslik_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxdyr_mesaj.Clear();
            label4.Text = "";
            checkBoxdyr_mdryardimci.Checked = false;
            checkBoxdyr_ogretmen.Checked = false;
            checkBoxdyr_ogrenci.Checked = false;
            baglanti.Open();
            SqlCommand commandduyuru = new SqlCommand("Select * From duyurular", baglanti);
            SqlDataReader drduyuru = commandduyuru.ExecuteReader();

            while (drduyuru.Read())
            {
                if (drduyuru[0] != null)
                {
                    if (listBoxdyr_baslik.SelectedItem.ToString() == drduyuru[0].ToString())
                    {
                        if (form_yonetimpanel.giris.ToString() != 0.ToString())
                        {
                            pictureBoxdyr_ekle.Visible = false;
                            pictureBoxdyr_kaydet.Visible = true;
                            pictureBoxdyr_sil.Visible = true;

                        }
                        richTextBoxdyr_mesaj.Text = drduyuru[1].ToString();
                        label4.Text = drduyuru[5].ToString();
                        if (drduyuru[2].ToString() == "evet")
                        {
                            checkBoxdyr_mdryardimci.Checked = true;
                        }
                        if (drduyuru[3].ToString() == "evet")
                        {
                            checkBoxdyr_ogretmen.Checked = true;
                        }
                        if (drduyuru[4].ToString() == "evet")
                        {
                            checkBoxdyr_ogrenci.Checked = true;
                        }


                    }
                }
              
               


            }
            baglanti.Close();
            textBoxdyr_baslik.Text = listBoxdyr_baslik.SelectedItem.ToString();

            if (form_yonetimpanel.giris.ToString() == 50.ToString())
            {
                if (label4.Text != Form2.girisadsoyad)
                {
                    pictureBoxdyr_kaydet.Visible = false;
                    richTextBoxdyr_mesaj.Enabled = false;
                    textBoxdyr_baslik.Enabled = false;
                    pictureBoxdyr_sil.Visible = false;
                }
                else
                {
                    pictureBoxdyr_kaydet.Visible = true;
                    richTextBoxdyr_mesaj.Enabled = true;
                    textBoxdyr_baslik.Enabled = true;
                    pictureBoxdyr_sil.Visible = true;
                }
            }
           
        }

        private void pictureBoxdyr_duzenleme_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayitguncelle = ("Update duyurular Set mesaj = @mesaj, muduryardimci = @muduryardimci, ogretmen = @ogretmen, ogrenci = @ogrenci Where baslik=@baslik");
            SqlCommand komut = new SqlCommand(kayitguncelle, baglanti);

            komut.Parameters.AddWithValue("@mesaj", richTextBoxdyr_mesaj.Text);
            if (checkBoxdyr_mdryardimci.Checked == true)
            {

                komut.Parameters.AddWithValue("@muduryardimci", "evet");
            }
            else
            {
                komut.Parameters.AddWithValue("@muduryardimci", "hayır");
            }
            if (checkBoxdyr_ogretmen.Checked == true)
            {

                komut.Parameters.AddWithValue("@ogretmen", "evet");
            }
            else
            {
                komut.Parameters.AddWithValue("@ogretmen", "hayır");
            }
            if (checkBoxdyr_ogrenci.Checked == true)
            {
                komut.Parameters.AddWithValue("@ogrenci", "evet");
            }
            else
            {
                komut.Parameters.AddWithValue("@ogrenci", "hayır");
            }
            komut.Parameters.AddWithValue("@baslik", textBoxdyr_baslik.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayit Düzenlendi");
            bul();
            richTextBoxdyr_mesaj.Clear();
            textBoxdyr_baslik.Clear();
            checkBoxdyr_ogrenci.Checked = false;
            checkBoxdyr_mdryardimci.Checked = false;
            checkBoxdyr_ogretmen.Checked = false;
        }
        public void verisil(string adi)
        {
            string sil = "Delete From duyurular Where baslik = @baslik";
            SqlCommand komut = new SqlCommand(sil, baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@baslik", adi);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void pictureBoxdyr_sil_Click(object sender, EventArgs e)
        {
            
                string adi = Convert.ToString(listBoxdyr_baslik.SelectedItem);
                verisil(adi);
            bul();
            richTextBoxdyr_mesaj.Clear();
            textBoxdyr_baslik.Clear();
            checkBoxdyr_ogrenci.Checked = false;
            checkBoxdyr_mdryardimci.Checked = false;
            checkBoxdyr_ogretmen.Checked = false;

        }
        public void bul()
        {
            if (form_yonetimpanel.giris.ToString() == 100.ToString())
            {
                KisiListele("Select * from duyurular");
                label4.Text = Form2.girisadsoyad.ToString();
                pictureBoxdyr_kaydet.Visible = false;
                pictureBoxdyr_sil.Visible = false;
            }
            else if (form_yonetimpanel.giris.ToString() == 0.ToString())
            {
                KisiListele("select * from duyurular where ogrenci = 'evet'");

                label4.Text = Form2.girisadsoyad.ToString();
                pictureBoxdyr_kaydet.Visible = false;
                pictureBoxdyr_sil.Visible = false;
            }
            else if (form_yonetimpanel.giris.ToString() == 50.ToString())
            {
                KisiListele("select * from duyurular where ogrenci = 'evet' or ogretmen = 'evet' ");

                label4.Text = Form2.girisadsoyad.ToString();
                pictureBoxdyr_kaydet.Visible = false;
                pictureBoxdyr_sil.Visible = false;
                textBoxdyr_baslik.Enabled = true;
                richTextBoxdyr_mesaj.Enabled = true;
            }
        }
        private void pictureBoxdyr_yenile_Click(object sender, EventArgs e)
        {
            if (form_yonetimpanel.giris.ToString() == 100.ToString())
            {
                KisiListele("Select * from duyurular");   
                label4.Text = Form2.girisadsoyad.ToString();
                pictureBoxdyr_kaydet.Visible = false;
                pictureBoxdyr_sil.Visible = false;
            }
            else if (form_yonetimpanel.giris.ToString() == 0.ToString())
            {
                KisiListele("select * from duyurular where ogrenci = 'evet'");
            
                label4.Text = Form2.girisadsoyad.ToString();
                pictureBoxdyr_kaydet.Visible = false;
                pictureBoxdyr_sil.Visible = false;
            }
            else if (form_yonetimpanel.giris.ToString() == 50.ToString())
            {
                KisiListele("select * from duyurular where ogrenci = 'evet' or ogretmen = 'evet' ");
            
                label4.Text = Form2.girisadsoyad.ToString();
                pictureBoxdyr_kaydet.Visible = false;
                pictureBoxdyr_sil.Visible = false;
                textBoxdyr_baslik.Enabled = true;
                richTextBoxdyr_mesaj.Enabled = true;

            } 
            richTextBoxdyr_mesaj.Clear();
            pictureBoxdyr_ekle.Visible = true;
            pictureBoxdyr_kaydet.Visible = false;
            pictureBoxdyr_sil.Visible = false;
            Form2 form2 = new Form2();
            label4.Text = Form2.girisadsoyad.ToString();
            textBoxdyr_baslik.Clear();
            checkBoxdyr_ogrenci.Checked = false;
            checkBoxdyr_mdryardimci.Checked = false;
            checkBoxdyr_ogretmen.Checked = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
 }

