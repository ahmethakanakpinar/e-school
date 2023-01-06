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
    public partial class form_yoneticipaneli : Form
    {
        public form_yoneticipaneli()
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
        static string bilgisayarAdi = Dns.GetHostName();
        static string constring = "Data Source=" + bilgisayarAdi + "\\SQLEXPRESS;Initial Catalog=eokul;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(constring);
        public void KisiListele()
        {

            string getir = "Select * From muduryardimci";

            SqlCommand komut = new SqlCommand(getir, baglanti);

            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dt_muduryardimcisi.DataSource = dt;
            baglanti.Close();




        }
        private void pictureBoxmdr_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into muduryardimci (adi,soyadi,tc,sifre,tekrarsifre,dogumtarihi,image,rutbe) values(@adi,@soyadi,@tc,@sifre,@tekrarsifre,@dogumtarihi,@image,rutbe)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@adi", textBoxmdr_adi.Text);
                komut.Parameters.AddWithValue("@soyadi", textBoxmdr_soyadi.Text);
                komut.Parameters.AddWithValue("@tc", textBoxmdr_tc.Text);
                DateTime dgm = dtpmdr_dogumtarihi.Value;      //ŞİFRE AYARLAMA
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
                komut.Parameters.AddWithValue("@dogumtarihi", dtpmdr_dogumtarihi.Value);
                komut.Parameters.AddWithValue("@image", textBoxmdr_image.Text);
                komut.Parameters.AddWithValue("@rutbe", "Yardımcı");
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

        private void pictureBoxmdr_duzenle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayitguncelle = ("Update muduryardimci Set adi = @adi, soyadi = @soyadi, dogumtarihi = @dogumtarihi, image = @image Where tc=@tc");
            SqlCommand komut = new SqlCommand(kayitguncelle, baglanti);
            komut.Parameters.AddWithValue("@adi", textBoxmdr_adi.Text);
            komut.Parameters.AddWithValue("@soyadi", textBoxmdr_soyadi.Text);

            komut.Parameters.AddWithValue("@dogumtarihi", dtpmdr_dogumtarihi.Value);
            komut.Parameters.AddWithValue("@image", textBoxmdr_image.Text);
            komut.Parameters.AddWithValue("@tc", dt_muduryardimcisi.CurrentRow.Cells[2].Value);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayit Düzenlendi");
            KisiListele();
        }
        public void verisil(string tc)
        {
            string sil = "Delete From muduryardimci Where tc = @tc";
            SqlCommand komut = new SqlCommand(sil, baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@tc", tc);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void pictureBoxmdr_sil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dt_muduryardimcisi.SelectedRows)
            {
                string tc = Convert.ToString(drow.Cells[2].Value);
                verisil(tc);
                KisiListele();
                textBoxmdr_adi.Clear();
                textBoxmdr_image.Clear();
                textBoxmdr_soyadi.Clear();
                textBoxmdr_tc.Clear();

            }
        }
        public static string kayit;
        private void pictureBoxmdr_bul_Click(object sender, EventArgs e)
        {
            if (11 == textBoxmdr_arama.TextLength)
            {
                kayit = "Select * From muduryardimci Where tc=@tc";

            }
            else
            {
                kayit = "Select * From muduryardimci Where adi=@adi";
            }
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@tc", textBoxmdr_arama.Text);
            komut.Parameters.AddWithValue("@adi", textBoxmdr_arama.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt_muduryardimcisi.DataSource = dt;
            baglanti.Close();
        }

        private void pictureBoxmdr_yenile_Click(object sender, EventArgs e)
        {
            KisiListele();
        }

        private void buttonmdr_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            textBoxmdr_image.Text = dosyayolu;
            pictureBoxmdr_image.ImageLocation = dosyayolu;
        }

        private void form_yoneticipaneli_Load(object sender, EventArgs e)
        {
            dt_muduryardimcisi.RowHeadersVisible = false;
            dt_muduryardimcisi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dt_muduryardimcisi.BorderStyle = BorderStyle.None;
            dt_muduryardimcisi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dt_muduryardimcisi.AllowUserToAddRows = false;
            dt_muduryardimcisi.AllowUserToAddRows = false;
            KisiListele();
             
        }

        private void dt_muduryardimcisi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxmdr_adi.Text = dt_muduryardimcisi.CurrentRow.Cells[0].Value.ToString();
            textBoxmdr_soyadi.Text = dt_muduryardimcisi.CurrentRow.Cells[1].Value.ToString();
            textBoxmdr_tc.Text = dt_muduryardimcisi.CurrentRow.Cells[2].Value.ToString();
            dtpmdr_dogumtarihi.Value = Convert.ToDateTime(dt_muduryardimcisi.CurrentRow.Cells[5].Value);
            pictureBoxmdr_image.ImageLocation = dt_muduryardimcisi.CurrentRow.Cells[6].Value.ToString();
            textBoxmdr_image.Text = dt_muduryardimcisi.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
