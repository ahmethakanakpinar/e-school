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
    public partial class form_notlarpaneli : Form
    {
        public form_notlarpaneli()
        {
            InitializeComponent();
        }
        static string bilgisayarAdi = Dns.GetHostName();
        static string constring = "Data Source=" + bilgisayarAdi + "\\SQLEXPRESS;Initial Catalog=eokul;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(constring);
        private void form_notlarpaneli_Load(object sender, EventArgs e)
        {
            dt_ogrencinot.RowHeadersVisible = false;
            dt_ogrencinot.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dt_ogrencinot.BorderStyle = BorderStyle.None;
            dt_ogrencinot.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dt_ogrencinot.AllowUserToAddRows = false;
            dt_ogrencinot.AllowUserToAddRows = false;

            if(form_yonetimpanel.giris != 50)
            {
                baglanti.Open();
                SqlCommand commandogr = new SqlCommand("Select * From bolumler", baglanti);
                SqlDataReader drogr = commandogr.ExecuteReader();
                while (drogr.Read())
                {
                    if ("Ortak Ders" != drogr[0].ToString())
                    {
                        cbognot_bolum.Items.Add(drogr[0].ToString());

                    }


                }
                baglanti.Close();
            }
            else
            {
                
                    baglanti.Open();
                    SqlCommand commandogr = new SqlCommand("select distinct(bolum),dersogretmen from dersler", baglanti);
                    SqlDataReader drogr = commandogr.ExecuteReader();
                    while (drogr.Read())
                    {
                    if (drogr[1].ToString() == Form2.girisadsoyad)
                            cbognot_bolum.Items.Add(drogr[0].ToString());

                    }
                    baglanti.Close();
            }
         
            kisilistele();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
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
        }
        public void dersgoster(string a, ListBox b,ComboBox c)
        {

            baglanti.Open();
            SqlCommand commandders = new SqlCommand(a, baglanti);
            SqlDataReader drders = commandders.ExecuteReader();
            while (drders.Read())
            {
                if (drders[1].ToString() == cbognot_bolum.Text && drders[2].ToString() == c.Text)
                {
                    b.Items.Add(drders[0].ToString());
                }
            }
            baglanti.Close();

        }
        public void dogruders(string a, ListBox b)
        {
          
            if (cbognot_bolum.SelectedItem.ToString() == "Ortak Ders")
            {
                baglanti.Open();
                SqlCommand commandders = new SqlCommand(a, baglanti);
                SqlDataReader drders = commandders.ExecuteReader();
                while (drders.Read())
                {
                  
                    b.Items.Add(drders[0].ToString());
                }
              
                baglanti.Close();
            }
            else
            {
                baglanti.Open();
                SqlCommand commandders = new SqlCommand(a, baglanti);
                SqlDataReader drders = commandders.ExecuteReader();
                while (drders.Read())
                {
                    if (drders[1].ToString() == cbognot_bolum.Text)
                    {
                        b.Items.Add(drders[0].ToString());
                    }
                }
                baglanti.Close();
            }
        

        }
  

        public void cek(string a)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                baglanti.Open();
                SqlCommand commandders = new SqlCommand(a, baglanti);
                SqlDataReader drders = commandders.ExecuteReader();
                while (drders.Read())
                {
                    if (Form2.giristc == drders[1].ToString() && listBox1.Items[i].ToString() == drders[0].ToString())
                    {
                        listBoxxdersler.Items.Add(drders[0].ToString());
                        listBox2.Items.Add(drders[2].ToString());
                        listBox3.Items.Add(drders[3].ToString());
                    }

                }
                baglanti.Close();
            }
        }
        private void cbognot_bolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbognot_sinifi.Items.Clear();
            cbognot_sinifi.Text = null;
            baglanti.Open();
            SqlCommand commandogrnot = new SqlCommand("Select * From bolumler", baglanti);
            SqlDataReader drogrnot = commandogrnot.ExecuteReader();
            while (drogrnot.Read())
            {
                if (cbognot_bolum.SelectedItem.ToString() == drogrnot[0].ToString())
                {
                    for (int i = 0; i < Convert.ToInt16(drogrnot[1]); i++)
                    {
                        cbognot_sinifi.Items.Add(i + 1);
                    }
                }

            }
            baglanti.Close();


            if(form_yonetimpanel.giris == 50)
            {

                listBoxxdersler.Items.Clear();
                listBox1.Items.Clear();
                pl_sayi.Controls.Clear();
                pl_tc.Controls.Clear();
                pl_ogrenciadi.Controls.Clear();
                pl_vize.Controls.Clear();
                pl_final.Controls.Clear();
                pl_vizesinifort.Controls.Clear();
                pl_finalsinifort.Controls.Clear();

             
                if (cbognot_bolum.SelectedItem.ToString() == "Ortak Ders")
                {
                    dogruders("Select distinct(pazartesi), bolum1,sinif1 From haftalikdersogretmen where pazartesi != '' ", listBox1);
                    dogruders("Select distinct(sali),bolum2,sinif2 From haftalikdersogretmen where sali != '' ", listBox1);
                    dogruders("Select distinct(carsamba),bolum3,sinif3 From haftalikdersogretmen where carsamba != '' ", listBox1);
                    dogruders("Select distinct(persembe),bolum4,sinif4 From haftalikdersogretmen where persembe != '' ", listBox1);
                    dogruders("Select distinct(cuma),bolum5,sinif5 From haftalikdersogretmen where cuma != '' ", listBox1);

                    IEnumerable<string> sonuc = listBox1.Items.Cast<string>().ToList().Distinct();
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(sonuc.ToArray());


                    cek("Select distinct(pazartesi),tc, bolum1,sinif1 From haftalikdersogretmen where pazartesi != '' ");
                    cek("Select distinct(sali),tc,bolum2,sinif2 From haftalikdersogretmen where sali != '' ");
                    cek("Select distinct(carsamba),tc,bolum3,sinif3 From haftalikdersogretmen where carsamba != '' ");
                    cek("Select distinct(persembe),tc,bolum4,sinif4 From haftalikdersogretmen where persembe != '' ");
                    cek("Select distinct(cuma),tc,bolum5,sinif5 From haftalikdersogretmen where cuma != '' ");
                }


                else
                {
                    dogruders("Select distinct(pazartesi), bolum,sinif From haftalikdersogrenci where pazartesi != '' ", listBox1);
                    dogruders("Select distinct(sali),bolum,sinif From haftalikdersogrenci where sali != '' ", listBox1);
                    dogruders("Select distinct(carsamba),bolum,sinif From haftalikdersogrenci where carsamba != '' ", listBox1);
                    dogruders("Select distinct(persembe),bolum,sinif From haftalikdersogrenci where persembe != '' ", listBox1);
                    dogruders("Select distinct(cuma),bolum,sinif From haftalikdersogrenci where cuma != '' ", listBox1);

                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        baglanti.Open();
                        SqlCommand commandders = new SqlCommand("Select * from dersler", baglanti);
                        SqlDataReader drders = commandders.ExecuteReader();
                        while (drders.Read())
                        {
                            if (Form2.girisadsoyad == drders[5].ToString() && listBox1.Items[i].ToString() == drders[0].ToString())
                            {
                                listBoxxdersler.Items.Add(drders[0].ToString());
                            }

                        }
                        baglanti.Close();
                    }
                }
                   
               
               
            }
        }
        public void kisilistele()
        {
            string getir = "Select adi, soyadi, tc From ogrenci";

            SqlCommand komut = new SqlCommand(getir, baglanti);

            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dt_ogrencinot.DataSource = dt;
            baglanti.Close();

        }
        private void cbognot_sinifi_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxxdersler.Items.Clear();
            pl_sayi.Controls.Clear();
            pl_tc.Controls.Clear();
            pl_ogrenciadi.Controls.Clear();
            pl_vize.Controls.Clear();
            pl_final.Controls.Clear();
            pl_vizesinifort.Controls.Clear();
            pl_finalsinifort.Controls.Clear();


            dersgoster("Select distinct(pazartesi), bolum,sinif From haftalikdersogrenci where pazartesi != '' ", listBoxxdersler, cbognot_sinifi);
            dersgoster("Select distinct(sali),bolum,sinif From haftalikdersogrenci where sali != '' ", listBoxxdersler, cbognot_sinifi);
            dersgoster("Select distinct(carsamba),bolum,sinif From haftalikdersogrenci where carsamba != '' ", listBoxxdersler, cbognot_sinifi);
            dersgoster("Select distinct(persembe),bolum,sinif From haftalikdersogrenci where persembe != '' ", listBoxxdersler, cbognot_sinifi);
            dersgoster("Select distinct(cuma),bolum,sinif From haftalikdersogrenci where cuma != '' ", listBoxxdersler, cbognot_sinifi);

            
            
            string kayit = "Select adi,soyadi,tc From ogrenci Where bolum=@bolum and sinifi = @sinifi";
           
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@bolum", cbognot_bolum.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@sinifi", cbognot_sinifi.SelectedItem.ToString());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt_ogrencinot.DataSource = dt;
            baglanti.Close();
        }

        private void listBoxxdersler_SelectedIndexChanged(object sender, EventArgs e)
        {



            if(form_yonetimpanel.giris == 50)
            {
                if(cbognot_bolum.SelectedItem.ToString() == "Ortak Ders")
                {

                      label2.Text = listBox2.Items[listBoxxdersler.SelectedIndex].ToString();
                      label1.Text = listBox3.Items[listBoxxdersler.SelectedIndex].ToString();



                    baglanti.Open();
                    string kayit = "Select adi,soyadi,tc From ogrenci Where bolum=@bolum and sinifi = @sinifi";

                    SqlCommand komut = new SqlCommand(kayit, baglanti);
                    komut.Parameters.AddWithValue("@bolum", label2.Text);
                    komut.Parameters.AddWithValue("@sinifi", label1.Text);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt_ogrencinot.DataSource = dt;
                    baglanti.Close();
                }
                else
                {
                         baglanti.Open();
                    SqlCommand commandogrnot = new SqlCommand("Select * From dersler", baglanti);
                    SqlDataReader drogrnot = commandogrnot.ExecuteReader();
                    while (drogrnot.Read())
                    {
                        if (listBoxxdersler.SelectedItem.ToString() == drogrnot[0].ToString())
                        {
                           label1.Text = drogrnot[1].ToString();
                           label2.Text = drogrnot[4].ToString();
                        }

                    }
                    baglanti.Close();


                    baglanti.Open();
                    string kayit = "Select adi,soyadi,tc From ogrenci Where bolum=@bolum and sinifi = @sinifi";

                    SqlCommand komut = new SqlCommand(kayit, baglanti);
                    komut.Parameters.AddWithValue("@bolum", cbognot_bolum.SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@sinifi", label1.Text);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt_ogrencinot.DataSource = dt;
                    baglanti.Close();
                }
               
            }


            pl_sayi.Controls.Clear();
            pl_tc.Controls.Clear();
            pl_ogrenciadi.Controls.Clear();
            pl_vize.Controls.Clear();
            pl_final.Controls.Clear();
            pl_vizesinifort.Controls.Clear();
            pl_finalsinifort.Controls.Clear();
            labelogr.Text = "";

            baglanti.Open();
            SqlCommand commandogr = new SqlCommand("Select * From dersler", baglanti);
            SqlDataReader drogr = commandogr.ExecuteReader();
            while (drogr.Read())
            {
                if (listBoxxdersler.SelectedItem.ToString() == drogr[0].ToString())
                {
                    labelogr.Text = drogr[5].ToString();
                }

            }
            baglanti.Close();


            for (int i = 0; i < dt_ogrencinot.RowCount; i++)
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
                        pl_tc.Controls.Add(labelbilgi);
                        labelbilgi.Text = dt_ogrencinot.Rows[i].Cells[2].Value.ToString();
                        //

                    }
                    if (m == 1)
                    {
                        labelbilgi.Size = new Size(200, 20);
                        pl_ogrenciadi.Controls.Add(labelbilgi);
                        labelbilgi.Text = dt_ogrencinot.Rows[i].Cells[0].Value.ToString()+" "+ dt_ogrencinot.Rows[i].Cells[1].Value.ToString();
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


            string[] sinifortvize = new string[dt_ogrencinot.RowCount];
            string[] sinifortfinal = new string[dt_ogrencinot.RowCount];
            string[] siniforttc = new string[dt_ogrencinot.RowCount];



            int sa = 0;
            foreach (Control tcdondur in pl_tc.Controls)
            {
                siniforttc[sa] = tcdondur.Text;
                sa++;
            }

            if (form_yonetimpanel.giris != 50)
            {
                baglanti.Open();
                SqlCommand commandogrnotgos = new SqlCommand("Select * From ogrencinot", baglanti);
                SqlDataReader drogrnotgos = commandogrnotgos.ExecuteReader();



                while (drogrnotgos.Read())
                {
                    sa = 0;
                    if (cbognot_bolum.SelectedItem.ToString() == drogrnotgos[1].ToString() && cbognot_sinifi.SelectedItem.ToString() == drogrnotgos[2].ToString() && listBoxxdersler.SelectedItem.ToString() == drogrnotgos[3].ToString())
                    {

                        foreach (Control notvize in pl_vize.Controls)
                        {

                            if (drogrnotgos[0].ToString() == siniforttc[sa].ToString())
                            {
                                notvize.Text = drogrnotgos[5].ToString();

                            }
                            sa++;

                        }
                        sa = 0;
                        foreach (Control notfinal in pl_final.Controls)
                        {


                            if (drogrnotgos[0].ToString() == siniforttc[sa].ToString())
                                notfinal.Text = drogrnotgos[6].ToString();

                            sa++;
                        }


                    }

                }
                baglanti.Close();
            }
            else
            {
                baglanti.Open();
                SqlCommand commandogrnotgos = new SqlCommand("Select * From ogrencinot", baglanti);
                SqlDataReader drogrnotgos = commandogrnotgos.ExecuteReader();



                while (drogrnotgos.Read())
                {
                    sa = 0;
                    if (label2.Text == drogrnotgos[1].ToString() && label1.Text == drogrnotgos[2].ToString() && listBoxxdersler.SelectedItem.ToString() == drogrnotgos[3].ToString())
                    {




                        foreach (Control notvize in pl_vize.Controls)
                        {

                            if (drogrnotgos[0].ToString() == siniforttc[sa].ToString())
                            {
                                notvize.Text = drogrnotgos[5].ToString();

                            }
                            sa++;

                        }
                        sa = 0;
                        foreach (Control notfinal in pl_final.Controls)
                        {


                            if (drogrnotgos[0].ToString() == siniforttc[sa].ToString())
                                notfinal.Text = drogrnotgos[6].ToString();

                            sa++;
                        }


                    }

                }
                baglanti.Close();
            }

              
            int vizetoplam = 0;
            int finaltoplam = 0;
            int vizesayac = 0;
            int finalsayac = 0;

            if (form_yonetimpanel.giris != 50)
            {
                baglanti.Open();
                SqlCommand commandort = new SqlCommand("Select * From ogrencinot", baglanti);
                SqlDataReader drort = commandort.ExecuteReader();
                while (drort.Read())
                {

                    if (listBoxxdersler.SelectedItem.ToString() == drort[3].ToString() && cbognot_bolum.SelectedItem.ToString() == drort[1].ToString() && cbognot_sinifi.SelectedItem.ToString() == drort[2].ToString())
                    {

                        if(drort[5].ToString() != "")
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
                if (vizesayac != 0)
                {
                    int vizesonuc = vizetoplam / vizesayac;
                    foreach (Control vizeort in pl_vizesinifort.Controls)
                    {

                        vizeort.Text = vizesonuc.ToString();

                    }
                }


                if (finalsayac != 0)
                {
                    int finalsonuc = finaltoplam / finalsayac;
                    foreach (Control finalort in pl_finalsinifort.Controls)
                    {

                        finalort.Text = finalsonuc.ToString();

                    }
                }




                    baglanti.Close();
            }
            else
            {
                baglanti.Open();
                SqlCommand commandort = new SqlCommand("Select * From ogrencinot", baglanti);
                SqlDataReader drort = commandort.ExecuteReader();
                while (drort.Read())
                {

                    if (listBoxxdersler.SelectedItem.ToString() == drort[3].ToString() && label2.Text == drort[1].ToString() && label1.Text == drort[2].ToString())
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

                if (vizesayac != 0)
                {
                    int vizesonuc = vizetoplam / vizesayac;
                    foreach (Control vizeort in pl_vizesinifort.Controls)
                    {

                        vizeort.Text = vizesonuc.ToString();

                    }
                }

                    
                  
                    if(finalsayac != 0)
                    {
                        int finalsonuc = finaltoplam / finalsayac;
                    foreach (Control finalort in pl_finalsinifort.Controls)
                    {

                        finalort.Text = finalsonuc.ToString();

                    }
                    }
                        


                 
                 
                baglanti.Close();
            }


               

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

     
        private void pb_kaydet_Click(object sender, EventArgs e)
        {

            string[] dersadi = new string[dt_ogrencinot.RowCount];
            string[] ogretmenadi = new string[dt_ogrencinot.RowCount];
            string[] vize = new string[dt_ogrencinot.RowCount];
            string[] final = new string[dt_ogrencinot.RowCount];
            string[] tc = new string[dt_ogrencinot.RowCount];

            int i = 0;


            i = 0;
            foreach (Control tcdondur in pl_tc.Controls)
            {
                tc[i] = tcdondur.Text;

                if (i != (listBoxxdersler.Items.Count - 1))
                    i++;
            }
            i = 0;
            foreach (Control ogrencivize in pl_vize.Controls)
            {
                if (ogrencivize.Text != "")
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



            if (form_yonetimpanel.giris != 50)
            {
                int m = 0;
                int varise = 0;
                foreach (Control ogrencivize in pl_vize.Controls)
                {

                    baglanti.Open();
                    SqlCommand commandogrnotgos = new SqlCommand("Select * From ogrencinot", baglanti);
                    SqlDataReader drogrnotgos = commandogrnotgos.ExecuteReader();



                    while (drogrnotgos.Read())
                    {
                        if (tc[m] == drogrnotgos[0].ToString() && cbognot_bolum.SelectedItem.ToString() == drogrnotgos[1].ToString() && cbognot_sinifi.SelectedItem.ToString() == drogrnotgos[2].ToString() && listBoxxdersler.SelectedItem.ToString() == drogrnotgos[3].ToString())
                        {
                            varise = 1;


                        }
                    }
                    baglanti.Close();

                    if (ogrencivize.Text == "")
                    {
                        if(varise == 1)
                        {
                            duzelt(vize[m], final[m], tc[m], cbognot_bolum.SelectedItem.ToString(), cbognot_sinifi.SelectedItem.ToString(), listBoxxdersler.SelectedItem.ToString());
                            MessageBox.Show("Düzenlendi");
                            varise = 0;
                        }
                    }
                    else if (varise == 1)
                    {
                        duzelt(vize[m], final[m], tc[m], cbognot_bolum.SelectedItem.ToString(), cbognot_sinifi.SelectedItem.ToString(), listBoxxdersler.SelectedItem.ToString());
                        MessageBox.Show("Düzenlendi");
                        varise = 0;
                    }
                    else
                    {
                        ekle(tc[m], cbognot_bolum.SelectedItem.ToString(), cbognot_sinifi.SelectedItem.ToString(), listBoxxdersler.SelectedItem.ToString(), labelogr.Text, vize[m], final[m]);
                        MessageBox.Show("Eklendi");
                    }
                    m++;
                }
            }
            else
            {
                int m = 0;
                int varise = 0;
                foreach (Control ogrencivize in pl_vize.Controls)
                {

                    baglanti.Open();
                    SqlCommand commandogrnotgos = new SqlCommand("Select * From ogrencinot", baglanti);
                    SqlDataReader drogrnotgos = commandogrnotgos.ExecuteReader();



                    while (drogrnotgos.Read())
                    {
                        if (tc[m] == drogrnotgos[0].ToString() && label2.Text == drogrnotgos[1].ToString() && label1.Text == drogrnotgos[2].ToString() && listBoxxdersler.SelectedItem.ToString() == drogrnotgos[3].ToString())
                        {
                            varise = 1;


                        }
                    }
                    baglanti.Close();

                    if (ogrencivize.Text == "")
                    {
                        if (varise == 1)
                        {
                            duzelt(vize[m], final[m], tc[m], label2.Text, label1.Text, listBoxxdersler.SelectedItem.ToString());
                            MessageBox.Show("Düzenlendi");
                            varise = 0;
                        }
                    }
                    else if (varise == 1)
                    {
                        duzelt(vize[m], final[m], tc[m], label2.Text, label1.Text, listBoxxdersler.SelectedItem.ToString());
                        MessageBox.Show("Düzenlendi");
                        varise = 0;
                    }
                    else
                    {
                        ekle(tc[m], label2.Text, label1.Text, listBoxxdersler.SelectedItem.ToString(), labelogr.Text, vize[m], final[m]);
                        MessageBox.Show("Eklendi");
                    }
                    m++;
                }
            }
          
               
                
            }
                   
        }
    }

