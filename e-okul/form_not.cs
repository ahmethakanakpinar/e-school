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
    public partial class form_not : Form
    {
        public form_not()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=AHMETHAKAN\\SQLEXPRESS;Initial Catalog=eokul;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(constring);
        public void dersgoster(string a, ListBox b, string c, string d)
        {

            baglanti.Open();
            SqlCommand commandders = new SqlCommand(a, baglanti);
            SqlDataReader drders = commandders.ExecuteReader();
            while (drders.Read())
            {

                if (c.ToString() == drders[1].ToString() && d.ToString() == drders[2].ToString())
                {
                    if (drders[0].ToString() != "")
                        b.Items.Add(drders[0].ToString());
                }
            }
            baglanti.Close();

        }
        private void form_not_Load(object sender, EventArgs e)
        {
            dersgoster("Select distinct(pazartesi), bolum,sinif From haftalikdersogrenci where pazartesi != '' ", listBox_dersler, Form2.girisbolum, Form2.girissinif);
            dersgoster("Select distinct(sali),bolum,sinif From haftalikdersogrenci where sali != '' ", listBox_dersler, Form2.girisbolum, Form2.girissinif);
            dersgoster("Select distinct(carsamba),bolum,sinif From haftalikdersogrenci where carsamba != '' ", listBox_dersler, Form2.girisbolum, Form2.girissinif);
            dersgoster("Select distinct(persembe),bolum,sinif From haftalikdersogrenci where persembe != '' ", listBox_dersler, Form2.girisbolum, Form2.girissinif);
            dersgoster("Select distinct(cuma),bolum,sinif From haftalikdersogrenci where cuma != '' ", listBox_dersler, Form2.girisbolum, Form2.girissinif);


            pl_sayi.Controls.Clear();
            pl_dersadi.Controls.Clear();
            pl_ogretmenadi.Controls.Clear();
            pl_vize.Controls.Clear();
            pl_final.Controls.Clear();
            pl_vizesinifort.Controls.Clear();
            pl_finalsinifort.Controls.Clear();


            for (int i = 0; i < listBox_dersler.Items.Count; i++)
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
                        labelbilgi.Text = listBox_dersler.Items[i].ToString();

                    }
                    if (m == 1)
                    {
                        baglanti.Open();
                        SqlCommand commandogrnot = new SqlCommand("Select * From dersler", baglanti);
                        SqlDataReader drogrnot = commandogrnot.ExecuteReader();
                        int j = 0;
                        while (drogrnot.Read())
                        {
                            if (drogrnot[0].ToString() == listBox_dersler.Items[i].ToString())
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

                        ogrencitextboxsinav.Enabled = false;
                    }
                    if (t == 1)
                    {
                        pl_vizesinifort.Controls.Add(ogrencitextboxsinav);
                        ogrencitextboxsinav.Enabled = false;

                    }


                    if (t == 2)
                    {
                        pl_final.Controls.Add(ogrencitextboxsinav);
                        ogrencitextboxsinav.Enabled = false;
                    }
                    if (t == 3)
                    {
                        pl_finalsinifort.Controls.Add(ogrencitextboxsinav);
                        ogrencitextboxsinav.Enabled = false;
                    }
                }


            }
            string[] sinifvize = new string[listBox_dersler.Items.Count];
            string[] siniffinal = new string[listBox_dersler.Items.Count];
            string[] dersler = new string[listBox_dersler.Items.Count];

            for (int i = 0; i < listBox_dersler.Items.Count; i++)
            {
                dersler[i] = listBox_dersler.Items[i].ToString();
            }


            baglanti.Open();
            SqlCommand commandogrnotgos = new SqlCommand("Select * From ogrencinot", baglanti);
            SqlDataReader drogrnotgos = commandogrnotgos.ExecuteReader();


            while (drogrnotgos.Read())
            {

                if (Form2.giristc == drogrnotgos[0].ToString() && Form2.girisbolum == drogrnotgos[1].ToString() && Form2.girissinif == drogrnotgos[2].ToString())
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
            string[] vizesonuc = new string[listBox_dersler.Items.Count];
            string[] finalsonuc = new string[listBox_dersler.Items.Count];


            for (int i = 0; i < listBox_dersler.Items.Count; i++)
            {
                baglanti.Open();
                SqlCommand commandort = new SqlCommand("Select * From ogrencinot", baglanti);
                SqlDataReader drort = commandort.ExecuteReader();

                while (drort.Read())
                {

                    if (listBox_dersler.Items[i].ToString() == drort[3].ToString() && Form2.girisbolum == drort[1].ToString() && Form2.girissinif == drort[2].ToString())
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
                        int gecici =  (vizetoplam / vizesayac);
                        vizesonuc[i] = gecici.ToString();

                    }
                    else
                    {
                    vizesonuc[i] = "";
                    }
                    if(finalsayac != 0)
                    {
                        int gecici = finaltoplam / finalsayac;
                        finalsonuc[i] = gecici.ToString();
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
                    if(finalsonuc[sayac] == null)
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
    }
}
