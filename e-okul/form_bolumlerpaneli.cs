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
    public partial class form_bolumlerpaneli : Form
    {
        public form_bolumlerpaneli()
        {
            InitializeComponent();
        }
       
        private void form_bolumlerpaneli_Load(object sender, EventArgs e)
        {
            dtblm_bolumler.RowHeadersVisible = false;
            dtblm_bolumler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtblm_bolumler.BorderStyle = BorderStyle.None;
            dtblm_bolumler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtblm_bolumler.AllowUserToAddRows = false;

            dtblm_bolumogrenci.RowHeadersVisible = false;
            dtblm_bolumogrenci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtblm_bolumogrenci.BorderStyle = BorderStyle.None;
            dtblm_bolumogrenci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtblm_bolumogrenci.AllowUserToAddRows = false;

            dtblm_bolumogretmen.RowHeadersVisible = false;
            dtblm_bolumogretmen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtblm_bolumogretmen.BorderStyle = BorderStyle.None;
            dtblm_bolumogretmen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtblm_bolumogretmen.AllowUserToAddRows = false;

            dtblm_bolumders.RowHeadersVisible = false;
            dtblm_bolumders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtblm_bolumders.BorderStyle = BorderStyle.None;
            dtblm_bolumders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtblm_bolumders.AllowUserToAddRows = false;


            tumunugizle();

            KisiListele();

        }
        private void tumunugizle() //sinifogretmenliği gizleme
        {
            labelblm_1.Visible = false;
            labelblm_2.Visible = false;
            labelblm_3.Visible = false;
            labelblm_4.Visible = false;
            labelblm_5.Visible = false;
            labelblm_6.Visible = false;
            comboBoxblm_sinif1.Visible = false;
            comboBoxblm_sinif2.Visible = false;
            comboBoxblm_sinif3.Visible = false;
            comboBoxblm_sinif4.Visible = false;
            comboBoxblm_sinif5.Visible = false;
            comboBoxblm_sinif6.Visible = false;
        }
        public void button1_Click(object sender, EventArgs e) //sinifogretmenliği seçim
        {
            if(comboBoxblm_kacyil.SelectedItem == "2")
            {
                tumunugizle();
                labelblm_1.Visible = true;
                labelblm_2.Visible = true;
                
                comboBoxblm_sinif1.Visible = true;
                comboBoxblm_sinif2.Visible = true;
               

            }
            else if(comboBoxblm_kacyil.SelectedItem == "4")
            {
                tumunugizle();
                labelblm_1.Visible = true;
                labelblm_2.Visible = true;
                labelblm_3.Visible = true;
                labelblm_4.Visible = true;

                comboBoxblm_sinif1.Visible = true;
                comboBoxblm_sinif2.Visible = true;
                comboBoxblm_sinif3.Visible = true;
                comboBoxblm_sinif4.Visible = true;


            }
            else if (comboBoxblm_kacyil.SelectedItem == "5")
            {
                tumunugizle();
                labelblm_1.Visible = true;
                labelblm_2.Visible = true;
                labelblm_3.Visible = true;
                labelblm_4.Visible = true;
                labelblm_5.Visible = true;

                comboBoxblm_sinif1.Visible = true;
                comboBoxblm_sinif2.Visible = true;
                comboBoxblm_sinif3.Visible = true;
                comboBoxblm_sinif4.Visible = true;
                comboBoxblm_sinif5.Visible = true;
            }
            else if (comboBoxblm_kacyil.SelectedItem == "6")
            {
                tumunugizle();
                labelblm_1.Visible = true;
                labelblm_2.Visible = true;
                labelblm_3.Visible = true;
                labelblm_4.Visible = true;
                labelblm_5.Visible = true;
                labelblm_6.Visible = true;
                comboBoxblm_sinif1.Visible = true;
                comboBoxblm_sinif2.Visible = true;
                comboBoxblm_sinif3.Visible = true;
                comboBoxblm_sinif4.Visible = true;
                comboBoxblm_sinif5.Visible = true;
                comboBoxblm_sinif6.Visible = true;


            }
            //panel1.Controls.Clear();
            //int kacyil;
            //kacyil = Convert.ToInt32(comboBoxblm_kacyil.Text);

            //for (int i = 0; i<kacyil;i++)
            //{
            //    Label label = new Label();

            //    label.Size = new Size(70, 25);

            //    label.Location = new Point(10, 10 + (25 * i));
            //    label.Text = ((i+1)+".Sınıf Öğr. :" );
            //    label.TabIndex = 1;
            //    label.Name = ("label_sinifogretmeni" + i);
            //    panel1.Controls.Add(label);

            //    ComboBox comboBox = new ComboBox();

            //    comboBox.Size = new Size(120, 25);

            //    comboBox.Location = new Point(80, 10 + (25*i));

            //    comboBox.TabIndex = 2;
            //    comboBox.Name = ("comboBox_sinifogretmeni" + i);
            //    panel1.Controls.Add(comboBox);


            //}

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           

        }
        static string constring = "Data Source=AHMETHAKAN\\SQLEXPRESS;Initial Catalog=eokul;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(constring);
        public void KisiListele()
        {

            string getir = "Select * From bolumler";

            SqlCommand komut = new SqlCommand(getir, baglanti);

            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dtblm_bolumler.DataSource = dt;
            baglanti.Close();
        }
        public void KisiListeleogr()
        {

            string getir = "Select * From ogrenci";

            SqlCommand komut = new SqlCommand(getir, baglanti);

            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dtblm_bolumogrenci.DataSource = dt;
            baglanti.Close();
        }
        private void pictureBoxblm_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into bolumler (adi,kacyil,sinif1,sinif2,sinif3,sinif4,sinif5,sinif6) values(@adi,@kacyil,@sinif1,@sinif2,@sinif3,@sinif4,@sinif5,@sinif6)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@adi", textBoxblm_adi.Text);
                komut.Parameters.AddWithValue("@kacyil", comboBoxblm_kacyil.Text);

                komut.Parameters.AddWithValue("@sinif1", comboBoxblm_sinif1.Text);
                komut.Parameters.AddWithValue("@sinif2", comboBoxblm_sinif2.Text);
                komut.Parameters.AddWithValue("@sinif3", comboBoxblm_sinif3.Text);
                komut.Parameters.AddWithValue("@sinif4", comboBoxblm_sinif4.Text);
                komut.Parameters.AddWithValue("@sinif5", comboBoxblm_sinif5.Text);
                komut.Parameters.AddWithValue("@sinif6", comboBoxblm_sinif6.Text);
              
           
      

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayit Eklendi");
                textBoxblm_adi.Clear();
          
                textBoxblm_adi.Focus();

                KisiListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hatali " + hata.Message);
            }
        }

        private void pictureBoxblm_duzenle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayitguncelle = ("Update bolumler Set kacyil = @kacyil, sinif1 = @sinif1, sinif2 = @sinif2, sinif3 = @sinif3, sinif4 = @sinif4, sinif5 = @sinif5, sinif6 = @sinif6 Where adi=@adi");
            SqlCommand komut = new SqlCommand(kayitguncelle, baglanti);
           
            komut.Parameters.AddWithValue("@kacyil", comboBoxblm_kacyil.Text);
            komut.Parameters.AddWithValue("@sinif1", comboBoxblm_sinif1.Text);
            komut.Parameters.AddWithValue("@sinif2", comboBoxblm_sinif2.Text);
            komut.Parameters.AddWithValue("@sinif3", comboBoxblm_sinif3.Text);
            komut.Parameters.AddWithValue("@sinif4", comboBoxblm_sinif4.Text);
            komut.Parameters.AddWithValue("@sinif5", comboBoxblm_sinif5.Text);
            komut.Parameters.AddWithValue("@sinif6", comboBoxblm_sinif6.Text);
            komut.Parameters.AddWithValue("@adi", dtblm_bolumler.CurrentRow.Cells[0].Value);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayit Düzenlendi");
            KisiListele();
        }

        private void dtblm_bolumler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxblm_adi.Text = dtblm_bolumler.CurrentRow.Cells[0].Value.ToString();
            comboBoxblm_kacyil.Text = dtblm_bolumler.CurrentRow.Cells[1].Value.ToString();
            comboBoxblm_sinif1.Text = dtblm_bolumler.CurrentRow.Cells[2].Value.ToString();
            comboBoxblm_sinif2.Text = dtblm_bolumler.CurrentRow.Cells[3].Value.ToString();
            comboBoxblm_sinif3.Text = dtblm_bolumler.CurrentRow.Cells[4].Value.ToString();
            comboBoxblm_sinif4.Text = dtblm_bolumler.CurrentRow.Cells[5].Value.ToString();
            comboBoxblm_sinif5.Text = dtblm_bolumler.CurrentRow.Cells[6].Value.ToString();
            comboBoxblm_sinif6.Text = dtblm_bolumler.CurrentRow.Cells[7].Value.ToString();
            button1_Click(new Button(), new EventArgs());

            comboBoxblm_sinif1.Items.Clear();
            comboBoxblm_sinif2.Items.Clear();
            comboBoxblm_sinif3.Items.Clear();
            comboBoxblm_sinif4.Items.Clear();
            comboBoxblm_sinif5.Items.Clear();
            comboBoxblm_sinif6.Items.Clear();

            baglanti.Open();
            SqlCommand command = new SqlCommand("Select * From ogretmen", baglanti);
            SqlDataReader dr = command.ExecuteReader();
          
            while (dr.Read())
            {
                if (dtblm_bolumler.CurrentRow.Cells[0].Value.ToString() == dr[3].ToString())
                {
                    comboBoxblm_sinif1.Items.Add(dr[0].ToString() + " " + dr[1].ToString());
                    comboBoxblm_sinif2.Items.Add(dr[0].ToString() + " " + dr[1].ToString());
                    comboBoxblm_sinif3.Items.Add(dr[0].ToString() + " " + dr[1].ToString());
                    comboBoxblm_sinif4.Items.Add(dr[0].ToString() + " " + dr[1].ToString());
                    comboBoxblm_sinif5.Items.Add(dr[0].ToString() + " " + dr[1].ToString());
                    comboBoxblm_sinif6.Items.Add(dr[0].ToString() + " " + dr[1].ToString());
                }
            }
            baglanti.Close();


            string kayitogr = "Select * From ogrenci Where bolum=@bolum";
            
            SqlCommand komutogr = new SqlCommand(kayitogr, baglanti);
            komutogr.Parameters.AddWithValue("@bolum", dtblm_bolumler.CurrentRow.Cells[0].Value);
            SqlDataAdapter daogr = new SqlDataAdapter(komutogr);
            DataTable dtogr = new DataTable();
            daogr.Fill(dtogr);
            dtblm_bolumogrenci.DataSource = dtogr;
            baglanti.Close();

            string kayitogt = "Select * From ogretmen Where bolum=@bolum";

            SqlCommand komutogt = new SqlCommand(kayitogt, baglanti);
            komutogt.Parameters.AddWithValue("@bolum", dtblm_bolumler.CurrentRow.Cells[0].Value);
            SqlDataAdapter daogt = new SqlDataAdapter(komutogt);
            DataTable dtogt = new DataTable();
            daogt.Fill(dtogt);
            dtblm_bolumogretmen.DataSource = dtogt;
            baglanti.Close();

            string kayitders = "Select * From dersler Where bolum=@bolum";

            SqlCommand komutders = new SqlCommand(kayitders, baglanti);
            komutders.Parameters.AddWithValue("@bolum", dtblm_bolumler.CurrentRow.Cells[0].Value);
            SqlDataAdapter daders = new SqlDataAdapter(komutders);
            DataTable dtders = new DataTable();
            daders.Fill(dtders);
            dtblm_bolumders.DataSource = dtders;
            baglanti.Close();





        }
        public void verisil(string adi)
        {
            string sil = "Delete From bolumler Where adi = @adi";
            SqlCommand komut = new SqlCommand(sil, baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@adi", adi);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void pictureBoxblm_sil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dtblm_bolumler.SelectedRows)
            {
                string adi = Convert.ToString(drow.Cells[0].Value);
                verisil(adi);
                KisiListele();
            }
        }
    }
}

