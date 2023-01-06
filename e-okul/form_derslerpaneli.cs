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
    public partial class form_derslerpaneli : Form
    {
        public form_derslerpaneli()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            form_yonetimpanel form_Yonetimpanel = new form_yonetimpanel();
            form_Yonetimpanel.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        static string bilgisayarAdi = Dns.GetHostName();
        static string constring = "Data Source=" + bilgisayarAdi + "\\SQLEXPRESS;Initial Catalog=eokul;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(constring);
        public void KisiListele()
        {

            string getir = "Select * From dersler";

            SqlCommand komut = new SqlCommand(getir, baglanti);

            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dt_dersler.DataSource = dt;
            baglanti.Close();
        }
     
        private void pictureBox_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into dersler (adi,sinifi,derskredisi,derssaati,bolum,derskodu,dersogretmen) values(@adi,@sinifi,@derskredisi,@derssaati,@bolum,@derskodu,@dersogretmen)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@adi", textBoxdersler_adi.Text);
                komut.Parameters.AddWithValue("@sinifi", comboBoxdersler_sinif.Text);
                komut.Parameters.AddWithValue("@derskredisi", textBoxdersler_derskredi.Text);
                komut.Parameters.AddWithValue("@bolum", comboBoxders_bolum.Text);

                komut.Parameters.AddWithValue("@derssaati", textBoxdersler_derssaati.Text);
                   //derskoduayarlama
             
                StringBuilder duzelt = new StringBuilder(textBoxdersler_adi.Text);
                string sifre = "#";
                if (duzelt.Length < 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if(i < duzelt.Length)
                        { 
                        if (duzelt[i] == '.' || duzelt[i] == ' ' || duzelt[i] == '+')
                        {
                        }
                        else
                        {
                            sifre += duzelt[i];
                            sifre.ToLower();
                        }
                        }
                        else
                        {
                            sifre += duzelt[duzelt.Length-1];
                            sifre.ToLower();
                        }
                    }
                    
                }
                else if(duzelt.Length<9)
                {
                    for (int i = 0; i < duzelt.Length; i++)
                    {
                        if (duzelt[i] == '.' || duzelt[i] == ' ' || duzelt[i] == '+')
                        {
                        }
                        else
                        {
                            sifre += duzelt[i];
                            sifre.ToLower();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 9; i += 2)
                    {
                        if (duzelt[i] == '.' || duzelt[i] == ' ' || duzelt[i] == '+')
                        {
                        }
                        else
                        {
                            sifre += duzelt[i];
                            sifre.ToLower();
                        }
                    }
                }
              
                komut.Parameters.AddWithValue("@derskodu", sifre.ToLower().Substring(0,5));
                komut.Parameters.AddWithValue("@dersogretmen", comboBoxders_ogretmen.Text);

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayit Eklendi");
                textBoxdersler_adi.Clear();
                textBoxdersler_derskredi.Clear();
                textBoxdersler_derssaati.Clear();
                comboBoxdersler_sinif.SelectedIndex = 0;
                textBoxdersler_adi.Focus();
                
                KisiListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hatali " + hata.Message);
            }
        }

        private void pictureBox_duzenle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayitguncelle = ("Update dersler Set sinifi = @sinifi, derskredisi = @derskredisi, derssaati = @derssaati, bolum = @bolum, dersogretmen = @dersogretmen Where adi=@adi");
            SqlCommand komut = new SqlCommand(kayitguncelle, baglanti);
        
            komut.Parameters.AddWithValue("@sinifi", comboBoxdersler_sinif.Text);
            komut.Parameters.AddWithValue("@derskredisi", textBoxdersler_derskredi.Text);
            komut.Parameters.AddWithValue("@derssaati", textBoxdersler_derssaati.Text);
            komut.Parameters.AddWithValue("@bolum", comboBoxders_bolum.Text);
            komut.Parameters.AddWithValue("@dersogretmen", comboBoxders_ogretmen.Text);
            komut.Parameters.AddWithValue("@adi", dt_dersler.CurrentRow.Cells[0].Value);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayit Düzenlendi");
            //KisiListele();
        }
        public void verisil(string adi)
        {
            string sil = "Delete From dersler Where adi = @adi";
            SqlCommand komut = new SqlCommand(sil, baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@adi", adi);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void pictureBox_sil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dt_dersler.SelectedRows)
            {
                string adi = Convert.ToString(drow.Cells[0].Value);
                verisil(adi);
                KisiListele();
            }
        }

        private void dt_dersler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxdersler_adi.Text = dt_dersler.CurrentRow.Cells[0].Value.ToString();
            comboBoxdersler_sinif.Text = dt_dersler.CurrentRow.Cells[1].Value.ToString();
            textBoxdersler_derskredi.Text = dt_dersler.CurrentRow.Cells[2].Value.ToString();
            textBoxdersler_derssaati.Text = dt_dersler.CurrentRow.Cells[3].Value.ToString();
            comboBoxders_bolum.Text = dt_dersler.CurrentRow.Cells[4].Value.ToString();
            comboBoxders_ogretmen.Text = dt_dersler.CurrentRow.Cells[5].Value.ToString();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            KisiListele();
        }

        private void form_derslerpaneli_Load(object sender, EventArgs e)
        {
            dt_dersler.RowHeadersVisible = false;
            dt_dersler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dt_dersler.BorderStyle = BorderStyle.None;
            dt_dersler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dt_dersler.AllowUserToAddRows = false;


            baglanti.Open();
            SqlCommand commandogretmen = new SqlCommand("Select * From ogretmen",baglanti);
            SqlDataReader drogretmen = commandogretmen.ExecuteReader();
            while(drogretmen.Read())
            {
                comboBoxders_ogretmen.Items.Add(drogretmen[0].ToString()+" "+ drogretmen[1].ToString());
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand commandbolum = new SqlCommand("Select * From bolumler", baglanti);
            SqlDataReader drbolum = commandbolum.ExecuteReader();
            while (drbolum.Read())
            {
                comboBoxders_bolum.Items.Add(drbolum[0].ToString());
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand commandblm = new SqlCommand("Select * From bolumler", baglanti);
            SqlDataReader drblm = commandblm.ExecuteReader();
            while (drblm.Read())
            {
                comboBoxders_bolumler.Items.Add(drblm[0].ToString());
            }
            baglanti.Close();




            KisiListele();
        }

        private void comboBoxders_bolumler_SelectedIndexChanged(object sender, EventArgs e)
        {
       

            string kayitders = "Select * From dersler Where bolum=@bolum";

            SqlCommand komutders = new SqlCommand(kayitders, baglanti);
            komutders.Parameters.AddWithValue("@bolum", comboBoxders_bolumler.Text);
            SqlDataAdapter daders = new SqlDataAdapter(komutders);
            DataTable dtders = new DataTable();
            daders.Fill(dtders);
            dt_dersler.DataSource = dtders;
            baglanti.Close();
        }

        private void comboBoxders_bolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxders_ogretmen.Items.Clear();
            baglanti.Open();
            SqlCommand command = new SqlCommand("Select * From ogretmen", baglanti);
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                if (comboBoxders_bolum.Text == dr[3].ToString() || "Ortak Ders" == dr[3].ToString())
                {
                    comboBoxders_ogretmen.Items.Add(dr[0].ToString() + " " + dr[1].ToString());
                }
                
               
            }
            baglanti.Close();
            if ("Ortak Ders" == comboBoxders_bolum.Text)
            {
                comboBoxdersler_sinif.Enabled = false;
                comboBoxdersler_sinif.Text = "0";
            }
            else
            {
                comboBoxdersler_sinif.Enabled = true;

            }

        }
    }
}
