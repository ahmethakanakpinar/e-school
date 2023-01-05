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

namespace e_okul
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=AHMETHAKAN\\SQLEXPRESS;Initial Catalog=eokul;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(constring);
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        public void formgetir(Form form)
        {
            panel2.Controls.Clear();
            form.MdiParent = this;
            panel2.Controls.Add(form);
            form.Show();
        }
        private void button_duyurular_Click(object sender, EventArgs e)
        {
            form_yonetimpanel.giris = 0;
            
            form_duyurular form_duyurular = new form_duyurular();
            formgetir(form_duyurular);
            
            form_duyurular.pictureBox4.Hide();
            form_duyurular.pictureBoxdyr_ekle.Visible = false;
            form_duyurular.pictureBoxdyr_kaydet.Enabled = false;
            form_duyurular.pictureBoxdyr_sil.Enabled = false;
            form_duyurular.pictureBox5.Visible = false;
            form_duyurular.label1.Enabled = false;
            form_duyurular.checkBoxdyr_mdryardimci.Visible = false;
            form_duyurular.checkBoxdyr_ogretmen.Visible = false;
            form_duyurular.checkBoxdyr_ogrenci.Visible = false;
            form_duyurular.textBoxdyr_baslik.Enabled = false;
            form_duyurular.richTextBoxdyr_mesaj.Enabled = false;
            form_duyurular.pictureBoxdyr_yenile.Visible = false;
            form_duyurular.label1.Visible = false;
          

        }

        private void button_devamsizlik_Click(object sender, EventArgs e)
        {
            form_devamsizlikbilgisi form_devamsizlikbilgisi = new form_devamsizlikbilgisi();
            formgetir(form_devamsizlikbilgisi);
        }

        private void button_not_Click(object sender, EventArgs e)
        {
            form_not form_Not = new form_not();
            formgetir(form_Not);
          
        }

        private void button_haftalikdersprogrami_Click(object sender, EventArgs e)
        {
            form_haftalikdersogrenci form_Haftalikdersogrenci = new form_haftalikdersogrenci();
            formgetir(form_Haftalikdersogrenci);
            form_Haftalikdersogrenci.pictureBox1.Visible = false;
            form_Haftalikdersogrenci.pictureBox2.Visible = false;



        }

        private void button_aldiğibelgeler_Click(object sender, EventArgs e)
        {
            form_aldiğibelgeler form_Aldiğibelgeler = new form_aldiğibelgeler();
            formgetir(form_Aldiğibelgeler);
        }

        private void button_yilsonunot_Click(object sender, EventArgs e)
        {
            form_yilsonunot form_Yilsonunot = new form_yilsonunot();
            formgetir(form_Yilsonunot);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            l_tc.Text = Form2.giristc.ToString();
            l_ad.Text = Form2.girisadsoyad.ToString();
            baglanti.Open();
            SqlCommand commandders = new SqlCommand("Select * From ogrenci", baglanti);
            SqlDataReader drders = commandders.ExecuteReader();
            while (drders.Read())
            {
                if(drders[2].ToString() == l_tc.Text)
                {
                    pictureBox_resim.ImageLocation = drders[8].ToString();
                    l_bolum.Text = drders[6].ToString();
                    for(int i = 0; i < Convert.ToInt32(drders[7]); i++)
                    {
                        cb_sinif.Items.Add(i + 1);
                        cb_sinif.SelectedIndex = cb_sinif.Items.Count-1;
                    }
                }
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand commandsnfogr = new SqlCommand("Select * From bolumler", baglanti);
            SqlDataReader drsnfogr = commandsnfogr.ExecuteReader();
            while (drsnfogr.Read())
            {
                if (drsnfogr[0].ToString() == l_bolum.Text)
                {         
                            l_sinifogretmeni.Text = drsnfogr["sinif" + cb_sinif.Text].ToString();  
   
                }
            }
            baglanti.Close();
        }

        private void button_sifredegistir_Click(object sender, EventArgs e)
        {
            form_sifredegistir form_Sifredegistir = new form_sifredegistir();
            form_Sifredegistir.Show();
            this.Hide();
            form_Sifredegistir.tabPage1.Text = "Öğrenci";

             
        }
    }
}