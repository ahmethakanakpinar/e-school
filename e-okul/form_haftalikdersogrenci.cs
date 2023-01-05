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
    public partial class form_haftalikdersogrenci : Form
    {
        public form_haftalikdersogrenci()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=AHMETHAKAN\\SQLEXPRESS;Initial Catalog=eokul;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(constring);

        public void dersprogramigetir(string a,Panel b)
        {
            string[] getir = new string[10];
            baglanti.Open();
            //"Select bolum,sinif,saat,pazartesi From haftalikdersogrenci"
            SqlCommand command = new SqlCommand(a, baglanti);
            SqlDataReader dr = command.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                if (dr[0].ToString() == Form2.girisbolum && dr[1].ToString() == Form2.girissinif)
                { 
                    getir[i] = dr[3].ToString();
                    i++;
                }
            }
            baglanti.Close();
                    i = 0;   
                    foreach (Control ogrencitextbox in b.Controls)
                    {
                       
                        ogrencitextbox.Text = getir[i];
                    
                        i++;
                    }
        }
        public void dersprogramiogretmengetir(string a, Panel b)
        {
            if(Form2.girisbolum == "Ortak Ders")
            {
                string[] getir = new string[30];
                baglanti.Open();
                // "Select tc,sinif1,bolum1,pazartesi From haftalikdersogretmen"
                SqlCommand command = new SqlCommand(a, baglanti);
                SqlDataReader dr = command.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (dr[0].ToString() == Form2.giristc)
                    {
                        if (dr[1].ToString() != "")
                            getir[i] = dr[1].ToString() + ".Sınıf";
                        i++;
                        getir[i] = dr[2].ToString();
                        i++;
                        getir[i] = dr[3].ToString();
                        i++;

                    }
                }
                baglanti.Close();
                i = 0;
                foreach (Control ogrencitextbox in b.Controls)
                {

                    ogrencitextbox.Text = getir[i];

                    i++;
                }
            }
            else
            {
                string[] getir = new string[30];
                baglanti.Open();
                // "Select tc,sinif1,bolum1,pazartesi From haftalikdersogretmen"
                SqlCommand command = new SqlCommand(a, baglanti);
                SqlDataReader dr = command.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (dr[0].ToString() == Form2.giristc)
                    {
                        if (dr[1].ToString() != "")
                            getir[i] = dr[1].ToString() + ".Sınıf";
                        i++;
                        getir[i] = dr[2].ToString();
                        i++;
                        getir[i] = dr[3].ToString();
                        i++;

                    }
                }
                baglanti.Close();
                i = 0;
                foreach (Control ogrencitextbox in b.Controls)
                {

                    ogrencitextbox.Text = getir[i];

                    i++;
                }
            }
          
        }
        //public void ortakdersgetirme(string a, Panel b)
        //{
        //    int sayac = 0;
        //    baglanti.Open();
        //    // "Select saat, bolum,sinif,pazartesi from haftalikdersogrenci where pazartesi != ''"
        //    SqlCommand commandderssayi = new SqlCommand("Select * From dersler", baglanti);
        //    SqlDataReader drderssayi = commandderssayi.ExecuteReader();
         
        //    while (drderssayi.Read())
        //    {
        //        if (drderssayi[5].ToString() == Form2.girisadsoyad)
        //        {
        //            sayac++;
        //        }
        //    }
        //    baglanti.Close();
        //    string[] dersadi = new string[sayac];
        //    baglanti.Open();
        //    // "Select saat, bolum,sinif,pazartesi from haftalikdersogrenci where pazartesi != ''"
        //    SqlCommand commandders = new SqlCommand("Select * From dersler", baglanti);
        //    SqlDataReader drders = commandders.ExecuteReader();
        //    int i = 0;
        //    while (drders.Read())
        //    {
        //        if (drders[5].ToString() == Form2.girisadsoyad)
        //        {
        //            dersadi[i] = drders[0].ToString();

        //        }
        //    }
        //    baglanti.Close();
           
        //    string[] getir = new string[30];
        //    baglanti.Open();
        //    // "Select saat, bolum,sinif,pazartesi from haftalikdersogrenci where pazartesi != ''"
        //    SqlCommand command = new SqlCommand(a, baglanti);
        //    SqlDataReader dr = command.ExecuteReader();
        //    i = 0;
        //    for (int m = 0; m < sayac; m++)
        //    {
        //        while (dr.Read())
        //        {
        //            if (dr[3].ToString() == dersadi[m])
        //            {
        //                if (dr[0].ToString() == "08:00")
        //                {
                            
        //                    getir[i] = dr[1].ToString() + ".Sınıf";
        //                    i++;
        //                    getir[i] = dr[2].ToString();
        //                    i++;
        //                    getir[i] = dr[3].ToString();
        //                    i++;
        //                }
        //                else
        //                {
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                }
        //                if (dr[0].ToString() == "09:00")
        //                {
                            
        //                    getir[i] = dr[1].ToString() + ".Sınıf";
        //                    i++;
        //                    getir[i] = dr[2].ToString();
        //                    i++;
        //                    getir[i] = dr[3].ToString();
        //                    i++;
        //                }
        //                else
        //                {
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                }
        //                if (dr[0].ToString() == "10:00")
        //                {
                           
        //                    getir[i] = dr[1].ToString() + ".Sınıf";
        //                    i++;
        //                    getir[i] = dr[2].ToString();
        //                    i++;
        //                    getir[i] = dr[3].ToString();
        //                    i++;
        //                }
        //                else
        //                {
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                }
        //                if (dr[0].ToString() == "11:00")
        //                {
                         
        //                    getir[i] = dr[1].ToString() + ".Sınıf";
        //                    i++;
        //                    getir[i] = dr[2].ToString();
        //                    i++;
        //                    getir[i] = dr[3].ToString();
        //                    i++;
        //                }
        //                else
        //                {
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                }
        //                if (dr[0].ToString() == "12:00")
        //                {
                            
        //                    getir[i] = dr[1].ToString() + ".Sınıf";
        //                    i++;
        //                    getir[i] = dr[2].ToString();
        //                    i++;
        //                    getir[i] = dr[3].ToString();
        //                    i++;
        //                }
        //                else
        //                {
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                }
        //                if (dr[0].ToString() == "13:00")
        //                {
                           
        //                    getir[i] = dr[1].ToString() + ".Sınıf";
        //                    i++;
        //                    getir[i] = dr[2].ToString();
        //                    i++;
        //                    getir[i] = dr[3].ToString();
        //                    i++;
        //                }
        //                else
        //                {
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                }
        //                if (dr[0].ToString() == "14:00")
        //                {
                            
        //                    getir[i] = dr[1].ToString() + ".Sınıf";
        //                    i++;
        //                    getir[i] = dr[2].ToString();
        //                    i++;
        //                    getir[i] = dr[3].ToString();
        //                    i++;
        //                }
        //                else
        //                {
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                }
        //                if (dr[0].ToString() == "15:00")
        //                {
                           
        //                    getir[i] = dr[1].ToString() + ".Sınıf";
        //                    i++;
        //                    getir[i] = dr[2].ToString();
        //                    i++;
        //                    getir[i] = dr[3].ToString();
        //                    i++;
        //                }
        //                else
        //                {
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                }
        //                if (dr[0].ToString() == "16:00")
        //                {
                            
        //                    getir[i] = dr[1].ToString() + ".Sınıf";
        //                    i++;
        //                    getir[i] = dr[2].ToString();
        //                    i++;
        //                    getir[i] = dr[3].ToString();
        //                    i++;
        //                }
        //                else
        //                {
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                }
        //                if (dr[0].ToString() == "17:00")
        //                {
                           
        //                    getir[i] = dr[1].ToString() + ".Sınıf";
        //                    i++;
        //                    getir[i] = dr[2].ToString();
        //                    i++;
        //                    getir[i] = dr[3].ToString();
        //                    i++;
        //                }
        //                else
        //                {
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                    getir[i] = "";
        //                    i++;
        //                }


        //            }
        //        }
        //    }
        //    baglanti.Close();
        //    i = 0;
        //    foreach (Control ogrencitextbox in b.Controls)
        //    {

        //        ogrencitextbox.Text = getir[i];

        //        i++;
        //    }
        //}


        private void form_haftalikdersogrenci_Load(object sender, EventArgs e)
        {
            panel_pazartesi.Controls.Clear();
            panel_sali.Controls.Clear();
            panel_carsamba.Controls.Clear();
            panel_persembe.Controls.Clear();
            panel_cuma.Controls.Clear();
            


            if(form_yonetimpanel.giris != 50)
            {
                for (int m = 0; m < 10; m++)
                {
                    TextBox ogrencitextbox = new TextBox();
                    ogrencitextbox.Multiline = true;
                    ogrencitextbox.Size = new Size(50, 30);
                    ogrencitextbox.Location = new Point(0, 0 + (40 * (m)));
                    ogrencitextbox.TabIndex = 2;
                    ogrencitextbox.Enabled = false;
                    panelgun.Controls.Add(ogrencitextbox);
                    if (m == 0)
                        ogrencitextbox.Text = "08:00";
                    else if (m == 1)
                        ogrencitextbox.Text = "09:00";
                    else if (m == 2)
                        ogrencitextbox.Text = "10:00";
                    else if (m == 3)
                        ogrencitextbox.Text = "11:00";
                    else if (m == 4)
                        ogrencitextbox.Text = "12:00";
                    else if (m == 5)
                        ogrencitextbox.Text = "13:00";
                    else if (m == 6)
                        ogrencitextbox.Text = "14:00";
                    else if (m == 7)
                        ogrencitextbox.Text = "15:00";
                    else if (m == 8)
                        ogrencitextbox.Text = "16:00";
                    else if (m == 9)
                        ogrencitextbox.Text = "17:00";
                }
                for (int i = 0; i < 10; i++)
                {


                    for (int t = 0; t < 5; t++)
                    {
                        TextBox ogrencitextboxsinav = new TextBox();
                        ogrencitextboxsinav.Multiline = true;
                        ogrencitextboxsinav.Size = new Size(120, 30);
                        ogrencitextboxsinav.Location = new Point(0, 0 + (40 * i));

                        if (t == 0)
                        {
                            panel_pazartesi.Controls.Add(ogrencitextboxsinav);
                            ogrencitextboxsinav.Enabled = false;

                        }
                        if (t == 1)
                        {
                            panel_sali.Controls.Add(ogrencitextboxsinav);
                            ogrencitextboxsinav.Enabled = false;


                        }
                        if (t == 2)
                        {
                            panel_carsamba.Controls.Add(ogrencitextboxsinav);
                            ogrencitextboxsinav.Enabled = false;


                        }
                        if (t == 3)
                        {
                            panel_persembe.Controls.Add(ogrencitextboxsinav);
                            ogrencitextboxsinav.Enabled = false;


                        }
                        if (t == 4)
                        {
                            panel_cuma.Controls.Add(ogrencitextboxsinav);
                            ogrencitextboxsinav.Enabled = false;


                        }
                    }


                }
            }
            else
            {
                for(int m = 0; m<10;m++)
                {
                    TextBox ogrencitextbox = new TextBox();
                    ogrencitextbox.Multiline = true;
                    ogrencitextbox.Size = new Size(50, 30);
                    ogrencitextbox.Location = new Point(0, 20 + (70 * (m)));
                    ogrencitextbox.TabIndex = 2;
                    ogrencitextbox.Enabled = false;
                    panelgun.Controls.Add(ogrencitextbox);
                    if (m == 0)
                        ogrencitextbox.Text = "08:00";
                    else if (m == 1)
                        ogrencitextbox.Text = "09:00";
                    else if (m == 2)
                        ogrencitextbox.Text = "10:00";
                    else if (m == 3)
                        ogrencitextbox.Text = "11:00";
                    else if (m == 4)
                        ogrencitextbox.Text = "12:00";
                    else if (m == 5)
                        ogrencitextbox.Text = "13:00";
                    else if (m == 6)
                        ogrencitextbox.Text = "14:00";
                    else if (m == 7)
                        ogrencitextbox.Text = "15:00";
                    else if (m == 8)
                        ogrencitextbox.Text = "16:00";
                    else if (m == 9)
                        ogrencitextbox.Text = "17:00";
                }
                
                for (int i = 0; i < 10; i++)
                {


                    for (int t = 0; t < 5; t++)
                    {

                        TextBox ogrencitextboxsinav = new TextBox();
                        Label label = new Label();
                        Label label2 = new Label();
                        label.Location = new Point(0, 0 + (70 * i));
                        label.TabIndex = 0;
                        ogrencitextboxsinav.Multiline = true;
                        ogrencitextboxsinav.Size = new Size(120, 30);
                        ogrencitextboxsinav.Location = new Point(0, 20 + (70 * (i)));
                        ogrencitextboxsinav.TabIndex = 2;
                        label2.Location = new Point(0, 45 + (70 * (i)));
                        label2.Size = new Size(130, 20);
                        label2.TabIndex = 1;

                        if (t == 0)
                        {
                            panel_pazartesi.Controls.Add(label);
                            panel_pazartesi.Controls.Add(label2);
                            panel_pazartesi.Controls.Add(ogrencitextboxsinav);
                           
                            ogrencitextboxsinav.Enabled = false;

                        }
                        if (t == 1)
                        {
                            panel_sali.Controls.Add(label);
                            panel_sali.Controls.Add(label2);
                            panel_sali.Controls.Add(ogrencitextboxsinav);
                           
                            ogrencitextboxsinav.Enabled = false;


                        }
                        if (t == 2)
                        {
                            panel_carsamba.Controls.Add(label);
                            panel_carsamba.Controls.Add(label2);
                            panel_carsamba.Controls.Add(ogrencitextboxsinav);
                         
                            ogrencitextboxsinav.Enabled = false;


                        }
                        if (t == 3)
                        {
                            panel_persembe.Controls.Add(label);
                            panel_persembe.Controls.Add(label2);
                            panel_persembe.Controls.Add(ogrencitextboxsinav);
                        
                            ogrencitextboxsinav.Enabled = false;


                        }
                        if (t == 4)
                        {
                            panel_cuma.Controls.Add(label);
                            panel_cuma.Controls.Add(label2);
                            panel_cuma.Controls.Add(ogrencitextboxsinav);
                          
                            ogrencitextboxsinav.Enabled = false;


                        }
                    }


                }

            }
           
            if(form_yonetimpanel.giris != 50)
            {
                dersprogramigetir("Select bolum,sinif,saat,pazartesi From haftalikdersogrenci", panel_pazartesi);
                dersprogramigetir("Select bolum,sinif,saat,sali From haftalikdersogrenci", panel_sali);
                dersprogramigetir("Select bolum,sinif,saat,carsamba From haftalikdersogrenci", panel_carsamba);
                dersprogramigetir("Select bolum,sinif,saat,persembe From haftalikdersogrenci", panel_persembe);
                dersprogramigetir("Select bolum,sinif,saat,cuma From haftalikdersogrenci", panel_cuma);
            }
            //else if(Form2.girisbolum == "Ortak Ders")
            //{
            //    ortakdersgetirme("Select saat, bolum,sinif,pazartesi from haftalikdersogrenci where pazartesi != ''", panel_pazartesi);
            //    ortakdersgetirme("Select saat, bolum,sinif,sali from haftalikdersogrenci where sali != ''", panel_sali);
            //    ortakdersgetirme("Select saat, bolum,sinif,carsamba from haftalikdersogrenci where carsamba != ''", panel_carsamba);
            //    ortakdersgetirme("Select saat, bolum,sinif,persembe from haftalikdersogrenci where persembe != ''", panel_persembe);
            //    ortakdersgetirme("Select saat, bolum,sinif,cuma from haftalikdersogrenci where cuma != ''", panel_cuma);
            //}
            else
            {
                dersprogramiogretmengetir("Select tc,sinif1,bolum1,pazartesi From haftalikdersogretmen", panel_pazartesi);
                dersprogramiogretmengetir("Select tc,sinif2,bolum2,sali From haftalikdersogretmen", panel_sali);
                dersprogramiogretmengetir("Select tc,sinif3,bolum3,carsamba  From haftalikdersogretmen", panel_carsamba);
                dersprogramiogretmengetir("Select tc,sinif4,bolum4,persembe  From haftalikdersogretmen", panel_persembe);
                dersprogramiogretmengetir("Select tc,sinif5,bolum5,cuma  From haftalikdersogretmen", panel_cuma);
            }
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
