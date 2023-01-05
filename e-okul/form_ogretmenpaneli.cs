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
    public partial class form_ogretmenpaneli : Form
    {
        public form_ogretmenpaneli()
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            form_yonetimpanel form_Yonetimpanel = new form_yonetimpanel();
            form_Yonetimpanel.Show();
            this.Hide();
        }
        static string constring = "Data Source=AHMETHAKAN\\SQLEXPRESS;Initial Catalog=eokul;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(constring);
        public void KisiListele()
        {

            string getir = "Select * From ogretmen";

            SqlCommand komut = new SqlCommand(getir, baglanti);

            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dt_ogretmen.DataSource = dt;
            baglanti.Close();
        }
        private void pictureBox_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into ogretmen (adi,soyadi,tc,bolum,sifre,tekrarsifre,dogumtarihi,image) values(@adi,@soyadi,@tc,@bolum,@sifre,@tekrarsifre,@dogumtarihi,@image)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@adi", textBoxogrtmen_adi.Text);
                komut.Parameters.AddWithValue("@soyadi", textBoxogrtmen_soyadi.Text);
                komut.Parameters.AddWithValue("@tc", textBoxogrtmen_tc.Text);
                komut.Parameters.AddWithValue("@bolum", comboBoxogrtmen_bolum.Text);
                DateTime dgm = dtpogrtmen_dogumtarihi.Value;      //ŞİFRE AYARLAMA
                    string dgmtarihi = dgm.Date.ToString();
                    StringBuilder duzelt = new StringBuilder(dgmtarihi);
                    string sifre = "";
                    for (int i = 0; i < duzelt.Length; i++)
                    {
                        if (duzelt[i] == '.')
                        {
                        }
                        else if (duzelt[i] == ' ')
                        {
                            break;
                        }
                        else
                        {
                            sifre += duzelt[i];
                            sifre.ToLower();
                        }
                    }
                komut.Parameters.AddWithValue("@sifre", sifre);
                komut.Parameters.AddWithValue("@tekrarsifre", sifre);
                komut.Parameters.AddWithValue("@dogumtarihi", dtpogrtmen_dogumtarihi.Value);
                komut.Parameters.AddWithValue("@image", textBoxogrtmen_image.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayit Eklendi");
                KisiListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hatali" + hata.Message);
            }

        }

        private void pictureBox_duzenle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayitguncelle = ("Update ogretmen Set adi = @adi, soyadi = @soyadi, bolum = @bolum, dogumtarihi = @dogumtarihi, image = @image Where tc=@tc");
            SqlCommand komut = new SqlCommand(kayitguncelle, baglanti);
            komut.Parameters.AddWithValue("@adi", textBoxogrtmen_adi.Text);
            komut.Parameters.AddWithValue("@soyadi", textBoxogrtmen_soyadi.Text);
            komut.Parameters.AddWithValue("@bolum", comboBoxogrtmen_bolum.Text);

            komut.Parameters.AddWithValue("@dogumtarihi", dtpogrtmen_dogumtarihi.Value);
            komut.Parameters.AddWithValue("@image", textBoxogrtmen_image.Text);
            komut.Parameters.AddWithValue("@tc", dt_ogretmen.CurrentRow.Cells[2].Value);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayit Düzenlendi");
            KisiListele();
        }
        public void verisil(string tc,string a)
        {
            //"Delete From ogretmen Where tc = @tc"
            string sil = a;
            SqlCommand komut = new SqlCommand(sil, baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@tc", tc);
            komut.ExecuteNonQuery();
            baglanti.Close();

           

        }
        public void bosalt(string tc,string adisoyadi,string bolum,int sayi,string sinif)
        {
           
                baglanti.Open();
                string kayitguncelle = ("Update bolumler Set "+sinif+" Where adi = @adi");
                SqlCommand komut = new SqlCommand(kayitguncelle, baglanti);

               
                if (1 == sayi)
                {
                    komut.Parameters.AddWithValue("@sinif1", "");
                }
                else if (2 == sayi)
                {
                    komut.Parameters.AddWithValue("@sinif2", "");
                }
                else if (3 == sayi)
                {
                    komut.Parameters.AddWithValue("@sinif3", "");
                }
                else if (4 == sayi)
                {
                    komut.Parameters.AddWithValue("@sinif4", "");
                }
                else if (5 == sayi)
                {
                    komut.Parameters.AddWithValue("@sinif5", "");
                }
                else if (6 == sayi)
                {

                    komut.Parameters.AddWithValue("@sinif6", "");
                }
            komut.Parameters.AddWithValue("@adi", bolum);
            komut.ExecuteNonQuery();
                baglanti.Close();
            
       
              

        }
        
            public void dersbosalt(string bolum, string dersadi)
            {

            baglanti.Open();
            string kayitguncelleders = ("Update dersler Set dersogretmen = @dersogretmen Where bolum = @bolum and adi = @adi");
            SqlCommand komutders = new SqlCommand(kayitguncelleders, baglanti);
    
                komutders.Parameters.AddWithValue("@bolum", bolum);
                komutders.Parameters.AddWithValue("@adi", dersadi);
                komutders.Parameters.AddWithValue("@dersogretmen", "");

          
        


            komutders.ExecuteNonQuery();
            baglanti.Close();
            }
         

            //baglanti.Open();
            //SqlCommand command = new SqlCommand("Select * From dersler", baglanti);
            //SqlDataReader dr = command.ExecuteReader();
            //int i = 0;
            //while (dr.Read())
            //{
            //    i++;
            //}
            //baglanti.Close();
            //textBox_arama.Text = i.ToString();

            //baglanti.Open();
            //SqlCommand commandbolum = new SqlCommand("Select * From dersler", baglanti);
            //SqlDataReader drbolum = commandbolum.ExecuteReader();
            //while (drbolum.Read())
            //{
            //    comboBoxogrtmen_bolum.Items.Add(drbolum[0].ToString());
            //}
            //baglanti.Close();
        
        private void pictureBox_sil_Click(object sender, EventArgs e)
        {
            int olur = 0;
        
            foreach (DataGridViewRow drow in dt_ogretmen.SelectedRows)
            {
                string adisoyadi = Convert.ToString(drow.Cells[0].Value + " "+ drow.Cells[1].Value);
                string tc = Convert.ToString(drow.Cells[2].Value);
                string bolum = Convert.ToString(drow.Cells[3].Value);
        

                baglanti.Open();
                SqlCommand command = new SqlCommand("Select * From dersler", baglanti);
                SqlDataReader dr = command.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    if (dr[5].ToString() == adisoyadi)
                    {
                        sayac++;

                    }
                }
                baglanti.Close();
           

                string[] dersadi = new string[sayac];

                baglanti.Open();
                SqlCommand commandbolum = new SqlCommand("Select * From bolumler", baglanti);
                SqlDataReader drbolum = commandbolum.ExecuteReader();
                while (drbolum.Read())
                {
                    if (drbolum[2].ToString() == adisoyadi)
                        olur = 1;
                    else if(drbolum[3].ToString() == adisoyadi)
                        olur = 2;
                    else if (drbolum[4].ToString() == adisoyadi)
                        olur = 3;
                    else if (drbolum[5].ToString() == adisoyadi)
                        olur = 4;
                    else if (drbolum[6].ToString() == adisoyadi)
                        olur = 5;
                    else if (drbolum[7].ToString() == adisoyadi)
                        olur = 6;
                }
                baglanti.Close();



               if(olur == 1)
                    bosalt(tc,adisoyadi,bolum,1, "sinif1 = @sinif1");
                else if (olur == 2)
                    bosalt(tc, adisoyadi, bolum, 2, "sinif2 = @sinif2");
                else if (olur == 3)
                    bosalt(tc, adisoyadi, bolum, 3, "sinif3 = @sinif3");
                else if (olur == 4)
                    bosalt(tc, adisoyadi, bolum, 4, "sinif4 = @sinif4");
                else if (olur == 5)
                    bosalt(tc, adisoyadi, bolum, 5, "sinif5 = @sinif5");
                else if (olur == 6)
                    bosalt(tc, adisoyadi, bolum, 6, "sinif6 = @sinif6");


                baglanti.Open();
                SqlCommand commanddersler = new SqlCommand("Select * From dersler", baglanti);
                SqlDataReader drdersler = commanddersler.ExecuteReader();
                int sayi = 0;
                while (drdersler.Read())
                {
                    if (drdersler[5].ToString()==adisoyadi)
                    {
                        dersadi[sayi] = drdersler[0].ToString();
                        sayi++;
                    }
                    
                }
                baglanti.Close();

                for(int d = 0; d < sayac; d++)
                {
                    dersbosalt(bolum, dersadi[d].ToString());
                }


                verisil(tc, "Delete From ogretmen Where tc = @tc");
                verisil(tc, "Delete From haftalikdersogretmen Where tc = @tc");
                KisiListele();
                textBoxogrtmen_adi.Clear();
                textBoxogrtmen_image.Clear();
                textBoxogrtmen_soyadi.Clear();
                textBoxogrtmen_tc.Clear();
            
            }
        }
        public static string kayit;
        private void pictureBox_bul_Click(object sender, EventArgs e)
        {

            if (11 == textBox_arama.TextLength)
            {
                kayit = "Select * From ogretmen Where tc=@tc";

            }
            else
            {
                kayit = "Select * From ogretmen Where adi=@adi";
            }
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@tc", textBox_arama.Text);
            komut.Parameters.AddWithValue("@adi", textBox_arama.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt_ogretmen.DataSource = dt;
            baglanti.Close();

        }

        private void textBoxogrtmen_tc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox_arama_KeyPress(object sender, KeyPressEventArgs e)
        {
     
        }

        private void button_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            textBoxogrtmen_image.Text = dosyayolu;
            pictureBoxogrtmen_image.ImageLocation = dosyayolu;
        }

        private void dt_ogretmen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxogrtmen_adi.Text = dt_ogretmen.CurrentRow.Cells[0].Value.ToString();
            textBoxogrtmen_soyadi.Text = dt_ogretmen.CurrentRow.Cells[1].Value.ToString();
            textBoxogrtmen_tc.Text = dt_ogretmen.CurrentRow.Cells[2].Value.ToString();
            comboBoxogrtmen_bolum.Text = dt_ogretmen.CurrentRow.Cells[3].Value.ToString();
            dtpogrtmen_dogumtarihi.Value = Convert.ToDateTime(dt_ogretmen.CurrentRow.Cells[6].Value);
            pictureBoxogrtmen_image.ImageLocation = dt_ogretmen.CurrentRow.Cells[7].Value.ToString();
            textBoxogrtmen_image.Text = dt_ogretmen.CurrentRow.Cells[7].Value.ToString();
        }

        private void form_ogretmenpaneli_Load(object sender, EventArgs e)
        {
            dt_ogretmen.RowHeadersVisible = false;
            dt_ogretmen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dt_ogretmen.BorderStyle = BorderStyle.None;
            dt_ogretmen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dt_ogretmen.AllowUserToAddRows = false;
         
            baglanti.Open();
            SqlCommand commandbolum = new SqlCommand("Select * From bolumler", baglanti);
            SqlDataReader drbolum = commandbolum.ExecuteReader();
            while (drbolum.Read())
            {
                comboBoxogrtmen_bolum.Items.Add(drbolum[0].ToString());
            }
            baglanti.Close();
            KisiListele();
      
        }

        private void pictureBox_yenile_Click(object sender, EventArgs e)
        {
            KisiListele();
        }
    }
}
