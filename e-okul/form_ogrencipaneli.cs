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
    public partial class form_ogrencipaneli : Form
    {
        public form_ogrencipaneli()
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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void panel_degerlendirme_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {


        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //flowLayoutPanel1.AutoScroll = true;

            
            //flowLayoutPanel1.Controls.Add(textBox);
        }
        
        private void tabControl1_Click(object sender, EventArgs e)
        {
            
        
         
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            form_yonetimpanel form_Yonetimpanel = new form_yonetimpanel();
            form_Yonetimpanel.Show();
            this.Hide();

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            form_yonetimpanel form_Yonetimpanel = new form_yonetimpanel();
            form_Yonetimpanel.Show();
            this.Hide();
        }
      
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        static string bilgisayarAdi = Dns.GetHostName();
        static string constring = "Data Source=" + bilgisayarAdi + "\\SQLEXPRESS;Initial Catalog=eokul;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(constring);

        public void KisiListele(string a, DataGridView b)
        {
            
            string getir = a;
            
            SqlCommand komut = new SqlCommand(getir, baglanti);

            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            b.DataSource = dt;
            baglanti.Close();

           


        }
        private void pictureBox_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into ogrenci (adi,soyadi,tc,sifre,tekrarsifre,dogumtarihi,bolum,sinifi,image) values(@adi,@soyadi,@tc,@sifre,@tekrarsifre,@dogumtarihi,@bolum,@sinifi,@image)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@adi",textBox_adi.Text);
                komut.Parameters.AddWithValue("@soyadi", textBox_soyadi.Text);
                komut.Parameters.AddWithValue("@tc", textBox_tc.Text);
                DateTime dgm = dtp_dogumtarihi.Value;
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
                komut.Parameters.AddWithValue("@dogumtarihi", dtp_dogumtarihi.Value);
                komut.Parameters.AddWithValue("@bolum", comboBoxogr_bolumu.Text);
                komut.Parameters.AddWithValue("@sinifi", comboBoxogr_sinifi.Text);
                komut.Parameters.AddWithValue("@image", textBox_image.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayit Eklendi");
                KisiListele("Select * From ogrenci", dt_ogrenci);
            }
            catch(Exception hata)
            {
                MessageBox.Show("Hatali" + hata.Message);
            }

        }

        private void dt_ogretmen_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }
   
        private void button_resimekle_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            textBox_image.Text = dosyayolu;
            pictureBox1.ImageLocation = dosyayolu;
        }

        private void form_ogrencipaneli_Load(object sender, EventArgs e)
        {
          
        
            dt_ogrenci.RowHeadersVisible = false;
            dt_ogrenci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dt_ogrenci.BorderStyle = BorderStyle.None;
            dt_ogrenci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dt_ogrenci.AllowUserToAddRows = false;
            dt_ogrenci.AllowUserToAddRows = false;


            dtogrnott_ogrenci.RowHeadersVisible = false;
            dtogrnott_ogrenci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtogrnott_ogrenci.BorderStyle = BorderStyle.None;
            dtogrnott_ogrenci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtogrnott_ogrenci.AllowUserToAddRows = false;

            baglanti.Open();
            SqlCommand commandogr = new SqlCommand("Select * From bolumler", baglanti);
            SqlDataReader drogr = commandogr.ExecuteReader();
            while (drogr.Read())
            {
                if ("Ortak Ders" != drogr[0].ToString())
                {
                    comboBoxogr_bolumu.Items.Add(drogr[0].ToString());
                    cbogrnott_bolum.Items.Add(drogr[0].ToString());
                    cbogrdvm_bolum.Items.Add(drogr[0].ToString());

                }
                
              
            }
            baglanti.Close();
            KisiListele("Select * From ogrenci", dt_ogrenci);


           


        }

        private void dt_ogrenci_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }
        public void verisil(string tc, string a)
        {
            string sil = a;
            SqlCommand komut = new SqlCommand(sil,baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@tc",tc);
            komut.ExecuteNonQuery();
            baglanti.Close();



        }
  
    
        private void pictureBox_yenile_Click(object sender, EventArgs e)
        {
            KisiListele("Select * From ogrenci", dt_ogrenci);
        }

        private void pictureBox_sil_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow drow in dt_ogrenci.SelectedRows)
            {
                string id = Convert.ToString(drow.Cells[2].Value);
                verisil(id, "Delete From ogrenci Where tc = @tc");
                verisil(id, "Delete From devamsizlik Where tc = @tc");
                verisil(id, "Delete From ogrencinot Where tc = @tc");
                KisiListele("Select * From ogrenci", dt_ogrenci);
                textBox_adi.Clear();
                textBox_image.Clear();
                textBox_soyadi.Clear();
                textBox_tc.Clear();
            }
         
        }

        private void pictureBox_duzenle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayitguncelle = ("Update ogrenci Set adi = @adi, soyadi = @soyadi, dogumtarihi = @dogumtarihi, bolum = @bolum, sinifi = @sinifi, image = @image Where tc=@tc");
            SqlCommand komut = new SqlCommand(kayitguncelle,baglanti);
            komut.Parameters.AddWithValue("@adi", textBox_adi.Text);
            komut.Parameters.AddWithValue("@soyadi", textBox_soyadi.Text);
            komut.Parameters.AddWithValue("@dogumtarihi", dtp_dogumtarihi.Value);
            komut.Parameters.AddWithValue("@bolum", comboBoxogr_bolumu.Text);
            komut.Parameters.AddWithValue("@sinifi", comboBoxogr_sinifi.Text);
            komut.Parameters.AddWithValue("@image", textBox_image.Text);
            komut.Parameters.AddWithValue("@tc", dt_ogrenci.CurrentRow.Cells[2].Value);              
            komut.ExecuteNonQuery();
            baglanti.Close();
                MessageBox.Show("Kayit Düzenlendi");
            KisiListele("Select * From ogrenci", dt_ogrenci);

        }
        public static string kayit;
        private void pictureBox_bul_Click(object sender, EventArgs e)
        {
            
            if(11 == textBox_arama.TextLength)
            {
                kayit = "Select * From ogrenci Where tc=@tc";
                
            }
            else
            {
                kayit = "Select * From ogrenci Where adi=@adi";
            }
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@tc", textBox_arama.Text);
            komut.Parameters.AddWithValue("@adi", textBox_arama.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt_ogrenci.DataSource = dt;
            baglanti.Close();




        }
 
        private void textBox_arama_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox_tc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        public void dersgoster(string a,ListBox b,ComboBox c,ComboBox d)
        {
            
            baglanti.Open();
            SqlCommand commandders = new SqlCommand(a, baglanti);
            SqlDataReader drders = commandders.ExecuteReader();
            while (drders.Read())
            {

            


                if (c.SelectedItem.ToString() == drders[1].ToString() && d.SelectedItem.ToString() == drders[2].ToString())
                {
                    if (drders[0].ToString() != "")
                        b.Items.Add(drders[0].ToString());


                }




            }
            baglanti.Close();
        
        }
        private void dt_ogrenci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_adi.Text = dt_ogrenci.CurrentRow.Cells[0].Value.ToString();
            textBox_soyadi.Text = dt_ogrenci.CurrentRow.Cells[1].Value.ToString();
            textBox_tc.Text = dt_ogrenci.CurrentRow.Cells[2].Value.ToString();
            dtp_dogumtarihi.Value = Convert.ToDateTime(dt_ogrenci.CurrentRow.Cells[5].Value);
            comboBoxogr_bolumu.Text = dt_ogrenci.CurrentRow.Cells[6].Value.ToString();
            comboBoxogr_sinifi.Text = dt_ogrenci.CurrentRow.Cells[7].Value.ToString();
            pictureBox1.ImageLocation = dt_ogrenci.CurrentRow.Cells[8].Value.ToString();
            textBox_image.Text = dt_ogrenci.CurrentRow.Cells[8].Value.ToString();
            listBox_dersler.Items.Clear();
            dersgoster("Select distinct(pazartesi), bolum,sinif From haftalikdersogrenci where pazartesi != '' ", listBox_dersler, comboBoxogr_bolumu, comboBoxogr_sinifi);
            dersgoster("Select distinct(sali),bolum,sinif From haftalikdersogrenci where sali != '' ", listBox_dersler, comboBoxogr_bolumu, comboBoxogr_sinifi);
            dersgoster("Select distinct(carsamba),bolum,sinif From haftalikdersogrenci where carsamba != '' ", listBox_dersler, comboBoxogr_bolumu, comboBoxogr_sinifi);
            dersgoster("Select distinct(persembe),bolum,sinif From haftalikdersogrenci where persembe != '' ", listBox_dersler, comboBoxogr_bolumu, comboBoxogr_sinifi);
            dersgoster("Select distinct(cuma),bolum,sinif From haftalikdersogrenci where cuma != '' ", listBox_dersler, comboBoxogr_bolumu, comboBoxogr_sinifi);

        }

        private void comboBoxogr_bolumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxogr_sinifi.Items.Clear();
            baglanti.Open();
            SqlCommand commandogr = new SqlCommand("Select * From bolumler", baglanti);
            SqlDataReader drogr = commandogr.ExecuteReader(); 
            while (drogr.Read())
            {
                if(comboBoxogr_bolumu.SelectedItem.ToString() == drogr[0].ToString())
                { 
                for (int i = 0; i < Convert.ToInt16(drogr[1]); i++)
                {
                    comboBoxogr_sinifi.Items.Add(i + 1);
                }
                }

            }
            baglanti.Close();
        
        }


      

        private void dtogrnot_ogrenci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    

        private void cbogrnott_bolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbogrnott_sinif.Items.Clear();
            baglanti.Open();
            SqlCommand commandogrnot = new SqlCommand("Select * From bolumler", baglanti);
            SqlDataReader drogrnot = commandogrnot.ExecuteReader();
            while (drogrnot.Read())
            {
                if (cbogrnott_bolum.SelectedItem.ToString() == drogrnot[0].ToString())
                {
                    for (int i = 0; i < Convert.ToInt16(drogrnot[1]); i++)
                    {
                        cbogrnott_sinif.Items.Add(i + 1);
                    }
                }

            }
            baglanti.Close();
        }

        private void cbogrnott_sinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kayit = "Select adi,soyadi,tc,bolum,sinifi From ogrenci Where bolum=@bolum and sinifi=@sinifi";

            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@bolum", cbogrnott_bolum.Text);
            komut.Parameters.AddWithValue("@sinifi", cbogrnott_sinif.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtogrnott_ogrenci.DataSource = dt;
            baglanti.Close();
            listBoxxdersler.Items.Clear();
     
            dersgoster("Select distinct(pazartesi), bolum,sinif From haftalikdersogrenci where pazartesi != '' ", listBoxxdersler, cbogrnott_bolum, cbogrnott_sinif);
            dersgoster("Select distinct(sali),bolum,sinif From haftalikdersogrenci where sali != '' ", listBoxxdersler, cbogrnott_bolum, cbogrnott_sinif);
            dersgoster("Select distinct(carsamba),bolum,sinif From haftalikdersogrenci where carsamba != '' ", listBoxxdersler, cbogrnott_bolum, cbogrnott_sinif);
            dersgoster("Select distinct(persembe),bolum,sinif From haftalikdersogrenci where persembe != '' ", listBoxxdersler, cbogrnott_bolum, cbogrnott_sinif);
            dersgoster("Select distinct(cuma),bolum,sinif From haftalikdersogrenci where cuma != '' ", listBoxxdersler, cbogrnott_bolum, cbogrnott_sinif);
           

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        public int sinifortalamavize = 0;
        public int sinifortalamafinal = 0;
        private void dtogrnott_ogrenci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pl_sayi.Controls.Clear();
            pl_dersadi.Controls.Clear();
            pl_ogretmenadi.Controls.Clear();
            pl_vize.Controls.Clear();
            pl_final.Controls.Clear();
            pl_vizesinifort.Controls.Clear();
            pl_finalsinifort.Controls.Clear();
            
           
            for (int i = 0; i < listBoxxdersler.Items.Count; i++)
            {
        
                    Label labella = new Label();
                    labella.Size = new Size(20, 20);
                    labella.Location = new Point(0, 0 + (35 * i));
                    labella.Name = (("labeldersadi" + i).ToString());
                    labella.Text = ((i + 1).ToString() + ".");
                    pl_sayi.Controls.Add(labella);

                for (int m = 0; m < 2; m++)
                {
                    Label labelbilgi = new Label();

                    labelbilgi.Location = new Point(0, 0 + (35 * i));
                    labelbilgi.Name = (("ComboBox_devamsizlik" + i).ToString());

                    if (m == 0)
                    {
                        pl_dersadi.Controls.Add(labelbilgi);
                        labelbilgi.Text = listBoxxdersler.Items[i].ToString();
                      
                    }
                    if (m == 1)
                    {
                        baglanti.Open();
                        SqlCommand commandogrnot = new SqlCommand("Select * From dersler", baglanti);
                        SqlDataReader drogrnot = commandogrnot.ExecuteReader();
                        int j = 0;
                        while (drogrnot.Read())
                        {
                            if (drogrnot[0].ToString() == listBoxxdersler.Items[i].ToString())
                            {
                                pl_ogretmenadi.Controls.Add(labelbilgi);
                                labelbilgi.Text = drogrnot[5].ToString();

                            }
                         
                        }
                       
                        baglanti.Close();
                    
                    }     
                }
                for (int t = 0; t < 4; t++)
                {
                    TextBox ogrencitextboxsinav = new TextBox();
                    ogrencitextboxsinav.Multiline = true;
                    ogrencitextboxsinav.Size = new Size(50, 30);
                    ogrencitextboxsinav.Location = new Point(0, 0 + (35 * i));
                    if (t == 0)
                    {
                        pl_vize.Controls.Add(ogrencitextboxsinav);
                        ogrencitextboxsinav.Enter += Ogrencitextboxsinav_Enter;

                    }
                    if (t == 1)
                    {
                        pl_vizesinifort.Controls.Add(ogrencitextboxsinav);
                        ogrencitextboxsinav.Enabled = false;

                    }


                    if (t == 2)
                    {
                        pl_final.Controls.Add(ogrencitextboxsinav);
                    }
                    if (t == 3)
                    {
                        pl_finalsinifort.Controls.Add(ogrencitextboxsinav);
                        ogrencitextboxsinav.Enabled = false;
                    }
                }
              
               
            }

            string[] sinifvize = new string[listBoxxdersler.Items.Count];
            string[] siniffinal = new string[listBoxxdersler.Items.Count];
            string[] dersler = new string[listBoxxdersler.Items.Count];

            for (int i = 0; i < listBoxxdersler.Items.Count; i++)
            {
                dersler[i] = listBoxxdersler.Items[i].ToString();
            }


            baglanti.Open();
                    SqlCommand commandogrnotgos = new SqlCommand("Select * From ogrencinot", baglanti);
                    SqlDataReader drogrnotgos = commandogrnotgos.ExecuteReader();

                  
                    while (drogrnotgos.Read())
                    {

                if (dtogrnott_ogrenci.CurrentRow.Cells[2].Value.ToString() == drogrnotgos[0].ToString() &&  cbogrnott_bolum.SelectedItem.ToString() == drogrnotgos[1].ToString() && cbogrnott_sinif.SelectedItem.ToString() == drogrnotgos[2].ToString())
                {
                    int m = 0;

                    foreach (Control notvize in pl_vize.Controls)
                    {

                        if (drogrnotgos[3].ToString() == dersler[m].ToString())
                        {
                            notvize.Text = drogrnotgos[5].ToString();

                        }
                        m++;


                    }
                    m = 0;
                    foreach (Control notfinal in pl_final.Controls)
                    {


                        if (drogrnotgos[3].ToString() == dersler[m].ToString())
                            notfinal.Text = drogrnotgos[6].ToString();

                        m++;
                    }


                }


            }
            baglanti.Close();

            int vizetoplam = 0;
            int finaltoplam = 0;
            int vizesayac = 0;
            int finalsayac = 0;
            string[] vizesonuc = new string[listBoxxdersler.Items.Count];
            string[] finalsonuc = new string[listBoxxdersler.Items.Count];


            for (int i = 0; i < listBoxxdersler.Items.Count; i++)
            {
                baglanti.Open();
                SqlCommand commandort = new SqlCommand("Select * From ogrencinot", baglanti);
                SqlDataReader drort = commandort.ExecuteReader();
               
                while (drort.Read())
                {
               
                    if (listBoxxdersler.Items[i].ToString() == drort[3].ToString() && cbogrnott_bolum.SelectedItem.ToString() == drort[1].ToString() && cbogrnott_sinif.SelectedItem.ToString() == drort[2].ToString())
                    {

                        if (drort[5].ToString() != "")
                        {
                            vizesayac++;
                            vizetoplam += Convert.ToInt32(drort[5]);
                        }
                        if (drort[6].ToString() != "")
                        {
                            finalsayac++;
                            finaltoplam += Convert.ToInt32(drort[6]);
                        }

                    }
                }
                baglanti.Close();
                if (vizesayac != 0)
                {
                    vizesonuc[i] = (vizetoplam / vizesayac).ToString();

                }
                else
                {
                    vizesonuc[i] = "";
                }
                if (finalsayac != 0)
                {
                    finalsonuc[i] = (finaltoplam / finalsayac).ToString();
                }
                else
                {
                    finalsonuc[i] = "";
                }
                vizetoplam = 0;
                finaltoplam = 0;
                vizesayac = 0;
                finalsayac = 0;
            }
            int sayac = 0;
            foreach (Control vizeort in pl_vizesinifort.Controls)
            {
                if (vizesonuc[sayac] == null)
                {
                    vizeort.Text = "";
                    sayac++;
                }
                else
                {
                    vizeort.Text = vizesonuc[sayac].ToString();
                    sayac++;
                }
            }
            sayac = 0;
            foreach (Control finalort in pl_finalsinifort.Controls)
            {
                if (finalsonuc[sayac] == null)
                {
                    finalort.Text = "";
                    sayac++;
                }
                else
                {
                    finalort.Text = finalsonuc[sayac].ToString();
                    sayac++;
                }
            }








        }

            
         

         

         
        



  

        private void Ogrencitextboxsinav_Enter(object sender, EventArgs e)
        {
          
            //baglanti.Open();
            //SqlCommand commandnot = new SqlCommand("Select * From ogrencinot", baglanti);
            //SqlDataReader drnot = commandnot.ExecuteReader();
            //int gizle = 0;
            //int i = 0;
            //while (drnot.Read())
            //{
            //    foreach (Control dersadikontrol in pl_dersadi.Controls)
            //    {
            //        if(dersadikontrol.Text == drnot[3].ToString())
            //        {

            //            if (drnot[5].ToString() != "" && drnot[6].ToString() != "")
            //            {
            //                gizle = 1;
            //                foreach (Control eklebuton in pl_ekle.Controls)
            //                {
            //                    eklebuton.Visible = false;

            //                }
            //                textBox1.Text = "kapalı";

            //            }

            //            else if (drnot[5].ToString() == "" || drnot[6].ToString() == "")
            //            {
            //                gizle = 1;
            //                foreach (Control eklebuton in pl_ekle.Controls)
            //                {
            //                    eklebuton.Visible = false;

            //                }
            //                textBox1.Text = "kapalı";

            //            }
            //            else if (drnot[5].ToString() == null && drnot[6].ToString() == null)
            //            {
            //                if (gizle == 0)
            //                {
            //                    foreach (Control eklebuton in pl_ekle.Controls)
            //                    {
            //                        eklebuton.Visible = true;

            //                    }
            //                    textBox1.Text = "açık";
            //                }
            //            }

            //        }

            //    }
            //}
            //baglanti.Close();
        }

      
        public void duzelt(string a, string b, string c, string d, string e, string f)
        {
            baglanti.Open();
            string kayitguncelle = ("Update ogrencinot Set vize = @vize, final = @final Where tc = @tc and bolum = @bolum and sinifi = @sinifi and dersadi = @dersadi");

            SqlCommand komut = new SqlCommand(kayitguncelle, baglanti);
            komut.Parameters.AddWithValue("@vize", a);
            komut.Parameters.AddWithValue("@final", b);
            komut.Parameters.AddWithValue("@tc", c);
            komut.Parameters.AddWithValue("@bolum", d);
            komut.Parameters.AddWithValue("@sinifi", e);
            komut.Parameters.AddWithValue("@dersadi", f);

            komut.ExecuteNonQuery();
            baglanti.Close();
        }
      
    

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            form_yonetimpanel form_Yonetimpanel = new form_yonetimpanel();
            form_Yonetimpanel.Show();
            this.Hide();
        }

        private void pb_ekle_Click(object sender, EventArgs e)
        {
       
        }
        public void ekle(string a, string b, string c, string d, string e, string f, string g)
        {


            baglanti.Open();
            string kayit = "insert into ogrencinot (tc,bolum,sinifi,dersadi,ogretmenadi,vize,final) values(@tc,@bolum,@sinifi,@dersadi,@ogretmenadi,@vize,@final)";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@tc", a);
            komut.Parameters.AddWithValue("@bolum", b);
            komut.Parameters.AddWithValue("@sinifi", c);

            komut.Parameters.AddWithValue("@dersadi", d);
            komut.Parameters.AddWithValue("@ogretmenadi", e);
            komut.Parameters.AddWithValue("@vize", f);
            komut.Parameters.AddWithValue("@final", g);

            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        private void pb_kaydet_Click(object sender, EventArgs e)
        {

            string[] dersadi = new string[listBoxxdersler.Items.Count];
            string[] ogretmenadi = new string[listBoxxdersler.Items.Count];
            string[] vize = new string[listBoxxdersler.Items.Count];
            string[] final = new string[listBoxxdersler.Items.Count];

            int i = 0;

            foreach (Control ogrencidersadi in pl_dersadi.Controls)
            {

               
                    dersadi[i] = ogrencidersadi.Text;
              

                if (i != (listBoxxdersler.Items.Count - 1))
                    i++;
            }
            i = 0;
            foreach (Control ogrenciogretmenadi in pl_ogretmenadi.Controls)
            {
                ogretmenadi[i] = ogrenciogretmenadi.Text;

                if (i != (listBoxxdersler.Items.Count - 1))
                    i++;
            }
            i = 0;
            foreach (Control ogrencivize in pl_vize.Controls)
            {
                if(ogrencivize.Text != "")
                {
                    if (Convert.ToInt32(ogrencivize.Text) <= 100)
                    {
                        vize[i] = ogrencivize.Text;
                    }
                    
                    
                    else
                    {
                        MessageBox.Show("100 Üstünde Değer Girdiniz");
                        i--;
                     
                    }
                }
                else
                {
                    vize[i] = ogrencivize.Text;
                }
            
                    

                if (i != (listBoxxdersler.Items.Count - 1))
                    i++;
            }
            i = 0;
            foreach (Control ogrencifinal in pl_final.Controls)
            {
                if (ogrencifinal.Text != "")
                {
                    if (Convert.ToInt32(ogrencifinal.Text) <= 100)
                    {
                        final[i] = ogrencifinal.Text;
                    }             
                    else
                    {
                        MessageBox.Show("100 Üstünde Değer Girdiniz");
                        i--;
                     
                    }
                }
                else
                {
                    final[i] = ogrencifinal.Text;
                }

                if (i != (listBoxxdersler.Items.Count - 1))
                    i++;
            }





            int m = 0;
            int varise = 0;
            foreach (Control ogrencivize in pl_vize.Controls)
            {

                baglanti.Open();
                SqlCommand commandogrnotgos = new SqlCommand("Select * From ogrencinot", baglanti);
                SqlDataReader drogrnotgos = commandogrnotgos.ExecuteReader();



                while (drogrnotgos.Read())
                {
                    if (dtogrnott_ogrenci.CurrentRow.Cells[2].Value.ToString() == drogrnotgos[0].ToString() && cbogrnott_bolum.SelectedItem.ToString() == drogrnotgos[1].ToString() && cbogrnott_sinif.SelectedItem.ToString() == drogrnotgos[2].ToString() && dersadi[m] == drogrnotgos[3].ToString())
                    {
                        varise = 1;
                    }
                }
                baglanti.Close();

                if (ogrencivize.Text == "")
                {
                    if(varise == 1)
                    {
                        duzelt(vize[m], final[m], dtogrnott_ogrenci.CurrentRow.Cells[2].Value.ToString(), cbogrnott_bolum.SelectedItem.ToString(), cbogrnott_sinif.SelectedItem.ToString(), dersadi[m]);
                        MessageBox.Show("Düzenlendi");
                        varise = 0;
                    }
                }
                else if (varise == 1)
                {
                    duzelt(vize[m], final[m], dtogrnott_ogrenci.CurrentRow.Cells[2].Value.ToString(), cbogrnott_bolum.SelectedItem.ToString(), cbogrnott_sinif.SelectedItem.ToString(), dersadi[m]);
                    MessageBox.Show("Düzenlendi");
                    varise = 0;
                }
                else
                {
                    ekle(dtogrnott_ogrenci.CurrentRow.Cells[2].Value.ToString(), cbogrnott_bolum.SelectedItem.ToString(), cbogrnott_sinif.SelectedItem.ToString(), dersadi[m], ogretmenadi[m], vize[m], final[m]);
                    MessageBox.Show("Eklendi");
                }
                m++;
            }


        }

        private void cbogrdvm_sinifi_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            lbdvm_tc.Items.Clear();
            baglanti.Open();
            SqlCommand commandogrdvm = new SqlCommand("Select * From ogrenci", baglanti);
            SqlDataReader drogrdvm = commandogrdvm.ExecuteReader();
            while (drogrdvm.Read())
            {
                if (drogrdvm[6].ToString() == cbogrdvm_bolum.SelectedItem.ToString() && drogrdvm[7].ToString() == cbogrdvm_sinifi.SelectedItem.ToString())
                {
                    checkedListBox1.Items.Add(drogrdvm[0].ToString() + " " + drogrdvm[1].ToString());
                    lbdvm_tc.Items.Add(drogrdvm[2].ToString());
                }

            }
            baglanti.Close();
            dateTimePicker1_ValueChanged(null, null);
        

        }

        private void cbogrdvm_bolum_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbogrdvm_sinifi.Items.Clear();
            baglanti.Open();
            SqlCommand commandogrnot = new SqlCommand("Select * From bolumler", baglanti);
            SqlDataReader drogrnot = commandogrnot.ExecuteReader();
            while (drogrnot.Read())
            {
                if (cbogrdvm_bolum.SelectedItem.ToString() == drogrnot[0].ToString())
                {
                    for (int i = 0; i < Convert.ToInt16(drogrnot[1]); i++)
                    {
                        cbogrdvm_sinifi.Items.Add(i + 1);
                    }
                }

            }
            baglanti.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
                baglanti.Open();
            SqlCommand commandogrdvm = new SqlCommand("Select * From devamsizlik", baglanti);
            SqlDataReader drogrdvm = commandogrdvm.ExecuteReader();
            DateTime dgm = dateTimePicker1.Value;
            while (drogrdvm.Read())
            {
                if (drogrdvm[3].ToString() == dgm.Date.ToString())
                {
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        if (drogrdvm[0].ToString() == lbdvm_tc.Items[i].ToString())
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                       

                }

            }
            baglanti.Close();

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            lbdvm_tc.SelectedIndex = checkedListBox1.SelectedIndex;
            tbdvm_tc.Text = "";
            tbdvm_adsoyad.Text = "";
            tbdvm_td.Text = "";
            baglanti.Open();
            SqlCommand commandogrdvm = new SqlCommand("Select * From ogrenci", baglanti);
            SqlDataReader drogrdvm = commandogrdvm.ExecuteReader();
            while (drogrdvm.Read())
            {
                if (drogrdvm[6].ToString() == cbogrdvm_bolum.SelectedItem.ToString() && drogrdvm[7].ToString() == cbogrdvm_sinifi.SelectedItem.ToString() && (drogrdvm[0].ToString()+" "+ drogrdvm[1].ToString()) == checkedListBox1.SelectedItem.ToString())
                {
                    tbdvm_tc.Text = drogrdvm[2].ToString();
                    tbdvm_tc.Text = lbdvm_tc.SelectedItem.ToString();
                    tbdvm_adsoyad.Text = drogrdvm[0].ToString() + " " + drogrdvm[1].ToString();
                 
                }

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand commandogrdvmt = new SqlCommand("Select count(*) From devamsizlik where tc = @tc", baglanti);
            commandogrdvmt.Parameters.AddWithValue("@tc", lbdvm_tc.SelectedItem.ToString());
            SqlDataReader drogrdvmt = commandogrdvmt.ExecuteReader();
       
            while (drogrdvmt.Read())
            {
             
                    tbdvm_td.Text = drogrdvmt[0].ToString();

                

            }
            baglanti.Close();


        }
        public void dvmekle(string b)//çalışanlara saat ekleme fonksiyonu
        {
            baglanti.Open();
            string ekle = "insert into devamsizlik(tc,bolum,sinifi,tarih)values(@tc,@bolum,@sinifi,@tarih)";
            SqlCommand komut = new SqlCommand(ekle, baglanti);
            komut.Parameters.AddWithValue("@tc", b);
            komut.Parameters.AddWithValue("@bolum", cbogrdvm_bolum.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@sinifi", cbogrdvm_sinifi.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);


            komut.ExecuteNonQuery();

            baglanti.Close();
        }

        public void dvmsil(string b)//çalışanlara saat ekleme fonksiyonu
        {


            baglanti.Open();
            string sil = ("Delete From devamsizlik Where tc = @tc and bolum = @bolum and sinifi = @sinifi and tarih = @tarih");
            DateTime dgm = dateTimePicker1.Value;

            SqlCommand komut = new SqlCommand(sil, baglanti);
            komut.Parameters.AddWithValue("@tc", b);
            komut.Parameters.AddWithValue("@bolum", cbogrdvm_bolum.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@sinifi", cbogrdvm_sinifi.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@tarih", dgm.Date);


            komut.ExecuteNonQuery();

            baglanti.Close();
        }
        private void pbdvm_kaydet_Click(object sender, EventArgs e)
        {

            int m = 0;
            int varise = 0;





            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                baglanti.Open();
                SqlCommand commanddvm = new SqlCommand("Select * From devamsizlik", baglanti);
                SqlDataReader drdvm = commanddvm.ExecuteReader();
                DateTime dgm = dateTimePicker1.Value;
                string tarih = dgm.Date.ToString();
            
                while (drdvm.Read())
                {
                    if (lbdvm_tc.Items[i].ToString() == drdvm[0].ToString() && cbogrdvm_bolum.SelectedItem.ToString() == drdvm[1].ToString() && cbogrdvm_sinifi.SelectedItem.ToString() == drdvm[2].ToString() && tarih == drdvm[3].ToString())
                    {
                        varise = 1;
                     

                    }
                }
                baglanti.Close();

                if (checkedListBox1.GetItemChecked(i) == false)
                {
                    if (varise == 1)
                    {
                        dvmsil(lbdvm_tc.Items[i].ToString());
                        MessageBox.Show("Silindi");
                        varise = 0;
                    }
                }
                else
                {
                    if (varise == 0)
                    {
                        dvmekle(lbdvm_tc.Items[i].ToString());
                        MessageBox.Show("Eklendi");
                    
                    }
                }
                m++;


            }





          }


    }
    }
    
    
    