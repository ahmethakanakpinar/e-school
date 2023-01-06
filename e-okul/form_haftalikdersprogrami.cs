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
    public partial class form_haftalikdersprogrami : Form
    {
        public form_haftalikdersprogrami()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
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

            string getir = "Select * From ogretmen";

            SqlCommand komut = new SqlCommand(getir, baglanti);

            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dtdrsp_ogretmen.DataSource = dt;
            baglanti.Close();

        }



        private void form_haftalikdersprogrami_Load(object sender, EventArgs e)
        {
            dtdrsp_ogretmen.RowHeadersVisible = false;
            dtdrsp_ogretmen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtdrsp_ogretmen.BorderStyle = BorderStyle.None;
            dtdrsp_ogretmen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtdrsp_ogretmen.AllowUserToAddRows = false;
            KisiListele();
            baglanti.Open();
            SqlCommand commandblm = new SqlCommand("Select * From bolumler", baglanti);
            SqlDataReader drblm = commandblm.ExecuteReader();

            while (drblm.Read())
            {
                comboBoxdrspo_bolumler.Items.Add(drblm[0].ToString());
                if (drblm[0].ToString() != "Ortak Ders")
                cbdrspo_blm.Items.Add(drblm[0].ToString());

            }


            baglanti.Close();


        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            form_yonetimpanel form_Yonetimpanel = new form_yonetimpanel();
            form_Yonetimpanel.Show();
            this.Hide();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxdrspo_bolumler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kayitders = "Select * From ogretmen Where bolum=@bolum";

            SqlCommand komutders = new SqlCommand(kayitders, baglanti);
            komutders.Parameters.AddWithValue("@bolum", comboBoxdrspo_bolumler.Text);
            SqlDataAdapter daders = new SqlDataAdapter(komutders);
            DataTable dtders = new DataTable();
            daders.Fill(dtders);
            dtdrsp_ogretmen.DataSource = dtders;
            baglanti.Close();
        }

        private void pictureBox_yenile_Click(object sender, EventArgs e)
        {
            KisiListele();
        }
        public static string kayit;
        private void pictureBox_arama_Click(object sender, EventArgs e)
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
            dtdrsp_ogretmen.DataSource = dt;
            baglanti.Close();

        }
        private void sil()
        {
            cbhft_pzrt08.Items.Clear();
            cbhft_pzrt09.Items.Clear();
            cbhft_pzrt10.Items.Clear();
            cbhft_pzrt11.Items.Clear();
            cbhft_pzrt12.Items.Clear();
            cbhft_pzrt13.Items.Clear();
            cbhft_pzrt14.Items.Clear();
            cbhft_pzrt15.Items.Clear();
            cbhft_pzrt16.Items.Clear();
            cbhft_pzrt17.Items.Clear();

            cbhft_sali08.Items.Clear();
            cbhft_sali09.Items.Clear();
            cbhft_sali10.Items.Clear();
            cbhft_sali11.Items.Clear();
            cbhft_sali12.Items.Clear();
            cbhft_sali13.Items.Clear();
            cbhft_sali14.Items.Clear();
            cbhft_sali15.Items.Clear();
            cbhft_sali16.Items.Clear();
            cbhft_sali17.Items.Clear();

            cbhft_crsmba08.Items.Clear();
            cbhft_crsmba09.Items.Clear();
            cbhft_crsmba10.Items.Clear();
            cbhft_crsmba11.Items.Clear();
            cbhft_crsmba12.Items.Clear();
            cbhft_crsmba13.Items.Clear();
            cbhft_crsmba14.Items.Clear();
            cbhft_crsmba15.Items.Clear();
            cbhft_crsmba16.Items.Clear();
            cbhft_crsmba17.Items.Clear();

            cbhft_prsmbe08.Items.Clear();
            cbhft_prsmbe09.Items.Clear();
            cbhft_prsmbe10.Items.Clear();
            cbhft_prsmbe11.Items.Clear();
            cbhft_prsmbe12.Items.Clear();
            cbhft_prsmbe13.Items.Clear();
            cbhft_prsmbe14.Items.Clear();
            cbhft_prsmbe15.Items.Clear();
            cbhft_prsmbe16.Items.Clear();
            cbhft_prsmbe17.Items.Clear();

            cbhft_cuma08.Items.Clear();
            cbhft_cuma09.Items.Clear();
            cbhft_cuma10.Items.Clear();
            cbhft_cuma11.Items.Clear();
            cbhft_cuma12.Items.Clear();
            cbhft_cuma13.Items.Clear();
            cbhft_cuma14.Items.Clear();
            cbhft_cuma15.Items.Clear();
            cbhft_cuma16.Items.Clear();
            cbhft_cuma17.Items.Clear();


            labelhft_sinif1.Text = "";
            labelhft_blm1.Text = "";
            labelhft_sinif2.Text = "";
            labelhft_blm2.Text = "";
            labelhft_sinif3.Text = "";
            labelhft_blm3.Text = "";
            labelhft_sinif4.Text = "";
            labelhft_blm4.Text = "";
            labelhft_sinif5.Text = "";
            labelhft_blm5.Text = "";
            labelhft_sinif6.Text = "";
            labelhft_blm6.Text = "";
            labelhft_sinif7.Text = "";
            labelhft_blm7.Text = "";
            labelhft_sinif8.Text = "";
            labelhft_blm8.Text = "";
            labelhft_sinif9.Text = "";
            labelhft_blm9.Text = "";
            labelhft_sinif10.Text = "";
            labelhft_blm10.Text = "";
            labelhft_sinif11.Text = "";
            labelhft_blm11.Text = "";
            labelhft_sinif12.Text = "";
            labelhft_blm12.Text = "";
            labelhft_sinif13.Text = "";
            labelhft_blm13.Text = "";
            labelhft_sinif14.Text = "";
            labelhft_blm14.Text = "";
            labelhft_sinif15.Text = "";
            labelhft_blm15.Text = "";
            labelhft_sinif16.Text = "";
            labelhft_blm16.Text = "";
            labelhft_sinif17.Text = "";
            labelhft_blm17.Text = "";
            labelhft_sinif18.Text = "";
            labelhft_blm18.Text = "";
            labelhft_sinif19.Text = "";
            labelhft_blm19.Text = "";
            labelhft_sinif20.Text = "";
            labelhft_blm20.Text = "";
            labelhft_sinif21.Text = "";
            labelhft_blm21.Text = "";
            labelhft_sinif22.Text = "";
            labelhft_blm22.Text = "";
            labelhft_sinif23.Text = "";
            labelhft_blm23.Text = "";
            labelhft_sinif24.Text = "";
            labelhft_blm24.Text = "";
            labelhft_sinif25.Text = "";
            labelhft_blm25.Text = "";
            labelhft_sinif26.Text = "";
            labelhft_blm26.Text = "";
            labelhft_sinif27.Text = "";
            labelhft_blm27.Text = "";
            labelhft_sinif28.Text = "";
            labelhft_blm28.Text = "";
            labelhft_sinif29.Text = "";
            labelhft_blm29.Text = "";
            labelhft_sinif30.Text = "";
            labelhft_blm30.Text = "";
            labelhft_sinif31.Text = "";
            labelhft_blm31.Text = "";
            labelhft_sinif32.Text = "";
            labelhft_blm32.Text = "";
            labelhft_sinif33.Text = "";
            labelhft_blm33.Text = "";
            labelhft_sinif34.Text = "";
            labelhft_blm34.Text = "";
            labelhft_sinif35.Text = "";
            labelhft_blm35.Text = "";
            labelhft_sinif36.Text = "";
            labelhft_blm36.Text = "";
            labelhft_sinif37.Text = "";
            labelhft_blm37.Text = "";
            labelhft_sinif38.Text = "";
            labelhft_blm38.Text = "";
            labelhft_sinif39.Text = "";
            labelhft_blm39.Text = "";
            labelhft_sinif40.Text = "";
            labelhft_blm40.Text = "";
            labelhft_sinif41.Text = "";
            labelhft_blm41.Text = "";
            labelhft_sinif42.Text = "";
            labelhft_blm42.Text = "";
            labelhft_sinif43.Text = "";
            labelhft_blm43.Text = "";
            labelhft_sinif44.Text = "";
            labelhft_blm44.Text = "";
            labelhft_sinif45.Text = "";
            labelhft_blm45.Text = "";
            labelhft_sinif46.Text = "";
            labelhft_blm46.Text = "";
            labelhft_sinif47.Text = "";
            labelhft_blm47.Text = "";
            labelhft_sinif48.Text = "";
            labelhft_blm48.Text = "";
            labelhft_sinif49.Text = "";
            labelhft_blm49.Text = "";
            labelhft_sinif50.Text = "";
            labelhft_blm50.Text = "";

            cbhft_pzrt08.Items.Add("");
            cbhft_pzrt09.Items.Add("");
            cbhft_pzrt10.Items.Add("");
            cbhft_pzrt11.Items.Add("");
            cbhft_pzrt12.Items.Add("");
            cbhft_pzrt13.Items.Add("");
            cbhft_pzrt14.Items.Add("");
            cbhft_pzrt15.Items.Add("");
            cbhft_pzrt16.Items.Add("");
            cbhft_pzrt17.Items.Add("");

            cbhft_sali08.Items.Add("");
            cbhft_sali09.Items.Add("");
            cbhft_sali10.Items.Add("");
            cbhft_sali11.Items.Add("");
            cbhft_sali12.Items.Add("");
            cbhft_sali13.Items.Add("");
            cbhft_sali14.Items.Add("");
            cbhft_sali15.Items.Add("");
            cbhft_sali16.Items.Add("");
            cbhft_sali17.Items.Add("");

            cbhft_crsmba08.Items.Add("");
            cbhft_crsmba09.Items.Add("");
            cbhft_crsmba10.Items.Add("");
            cbhft_crsmba11.Items.Add("");
            cbhft_crsmba12.Items.Add("");
            cbhft_crsmba13.Items.Add("");
            cbhft_crsmba14.Items.Add("");
            cbhft_crsmba15.Items.Add("");
            cbhft_crsmba16.Items.Add("");
            cbhft_crsmba17.Items.Add("");

            cbhft_prsmbe08.Items.Add("");
            cbhft_prsmbe09.Items.Add("");
            cbhft_prsmbe10.Items.Add("");
            cbhft_prsmbe11.Items.Add("");
            cbhft_prsmbe12.Items.Add("");
            cbhft_prsmbe13.Items.Add("");
            cbhft_prsmbe14.Items.Add("");
            cbhft_prsmbe15.Items.Add("");
            cbhft_prsmbe16.Items.Add("");
            cbhft_prsmbe17.Items.Add("");

            cbhft_cuma08.Items.Add("");
            cbhft_cuma09.Items.Add("");
            cbhft_cuma10.Items.Add("");
            cbhft_cuma11.Items.Add("");
            cbhft_cuma12.Items.Add("");
            cbhft_cuma13.Items.Add("");
            cbhft_cuma14.Items.Add("");
            cbhft_cuma15.Items.Add("");
            cbhft_cuma16.Items.Add("");
            cbhft_cuma17.Items.Add("");


        }
        private void dtdrsp_ogretmen_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelhft_blm1_Click(object sender, EventArgs e)
        {

        }

        private void labelhft_sinif1_Click(object sender, EventArgs e)
        {

        }

        public void ortakdersgetir(string a, int b, string p, ComboBox b1, ComboBox b2, ComboBox b3, ComboBox b4, ComboBox b5, ComboBox b6, ComboBox b7, ComboBox b8, ComboBox b9, ComboBox b10)
        {
            b1.Enabled = true;
            b2.Enabled = true;
            b3.Enabled = true;
            b4.Enabled = true;
            b5.Enabled = true;
            b6.Enabled = true;
            b7.Enabled = true;
            b8.Enabled = true;
            b9.Enabled = true;
            b10.Enabled = true;
            baglanti.Open();
            //"Select saat, sinif1, bolum1, pazartesi from haftalikdersogretmen where sinif1 != '' "
            SqlCommand commandblmpzr = new SqlCommand(a, baglanti);
            SqlDataReader drblmpzr = commandblmpzr.ExecuteReader();
            while (drblmpzr.Read())
            {


                if (drblmpzr[0].ToString() == cbhftogr_gun08.Text)
                {
                    
                    b1.Text = drblmpzr[b].ToString();
                    
                    if (p == "Pazartesi" && b1.Text != "" && b1.Text == drblmpzr[b].ToString()) labelhft_blm1.Text = drblmpzr[1].ToString();
                    if (p == "Pazartesi" && b1.Text != "" && b1.Text == drblmpzr[b].ToString()) labelhft_sinif1.Text = (drblmpzr[2].ToString()+".Sınıf");
                    if (p == "Sali" && b1.Text != "" && b1.Text == drblmpzr[b].ToString()) labelhft_blm2.Text = drblmpzr[1].ToString();
                    if (p == "Sali" && b1.Text != "" && b1.Text == drblmpzr[b].ToString()) labelhft_sinif2.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Carsamba" && b1.Text != "" && b1.Text == drblmpzr[b].ToString()) labelhft_blm3.Text = drblmpzr[1].ToString();
                    if (p == "Carsamba" && b1.Text != "" && b1.Text == drblmpzr[b].ToString()) labelhft_sinif3.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Persembe" && b1.Text != "" && b1.Text == drblmpzr[b].ToString()) labelhft_blm4.Text = drblmpzr[1].ToString();
                    if (p == "Persembe" && b1.Text != "" && b1.Text == drblmpzr[b].ToString()) labelhft_sinif4.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Cuma" && b1.Text != "" && b1.Text == drblmpzr[b].ToString()) labelhft_blm5.Text = drblmpzr[1].ToString();
                    if (p == "Cuma" && b1.Text != "" && b1.Text == drblmpzr[b].ToString()) labelhft_sinif5.Text = (drblmpzr[2].ToString() + ".Sınıf");



                }

                if (drblmpzr[0].ToString() == cbhftogr_gun09.Text)
                {
                    b2.Text = drblmpzr[b].ToString();
                    if (p == "Pazartesi" && b2.Text != "" && b2.Text == drblmpzr[b].ToString()) labelhft_blm6.Text = drblmpzr[1].ToString();
                    if (p == "Pazartesi" && b2.Text != "" && b2.Text == drblmpzr[b].ToString()) labelhft_sinif6.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Sali" && b2.Text != "" && b2.Text == drblmpzr[b].ToString()) labelhft_blm7.Text = drblmpzr[1].ToString();
                    if (p == "Sali" && b2.Text != "" && b2.Text == drblmpzr[b].ToString()) labelhft_sinif7.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Carsamba" && b2.Text != "" && b2.Text == drblmpzr[b].ToString()) labelhft_blm8.Text = drblmpzr[1].ToString();
                    if (p == "Carsamba" && b2.Text != "" && b2.Text == drblmpzr[b].ToString()) labelhft_sinif8.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Persembe" && b2.Text != "" && b2.Text == drblmpzr[b].ToString()) labelhft_blm9.Text = drblmpzr[1].ToString();
                    if (p == "Persembe" && b2.Text != "" && b2.Text == drblmpzr[b].ToString()) labelhft_sinif9.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Cuma" && b2.Text != "" && b2.Text == drblmpzr[b].ToString()) labelhft_blm10.Text = drblmpzr[1].ToString();
                    if (p == "Cuma" && b2.Text != "" && b2.Text == drblmpzr[b].ToString()) labelhft_sinif10.Text = (drblmpzr[2].ToString() + ".Sınıf");
                }


                if (drblmpzr[0].ToString() == cbhftogr_gun10.Text)
                {

                    b3.Text = drblmpzr[b].ToString();
                    if (p == "Pazartesi" && b3.Text != "" && b3.Text == drblmpzr[b].ToString()) labelhft_blm11.Text = drblmpzr[1].ToString();
                    if (p == "Pazartesi" && b3.Text != "" && b3.Text == drblmpzr[b].ToString()) labelhft_sinif11.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Sali" && b3.Text != "" && b3.Text == drblmpzr[b].ToString()) labelhft_blm12.Text = drblmpzr[1].ToString();
                    if (p == "Sali" && b3.Text != "" && b3.Text == drblmpzr[b].ToString()) labelhft_sinif12.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Carsamba" && b3.Text != "" && b3.Text == drblmpzr[b].ToString()) labelhft_blm13.Text = drblmpzr[1].ToString();
                    if (p == "Carsamba" && b3.Text != "" && b3.Text == drblmpzr[b].ToString()) labelhft_sinif13.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Persembe" && b3.Text != "" && b3.Text == drblmpzr[b].ToString()) labelhft_blm14.Text = drblmpzr[1].ToString();
                    if (p == "Persembe" && b3.Text != "" && b3.Text == drblmpzr[b].ToString()) labelhft_sinif14.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Cuma" && b3.Text != "" && b3.Text == drblmpzr[b].ToString()) labelhft_blm15.Text = drblmpzr[1].ToString();
                    if (p == "Cuma" && b3.Text != "" && b3.Text == drblmpzr[b].ToString()) labelhft_sinif15.Text = (drblmpzr[2].ToString() + ".Sınıf");

                }

                if (drblmpzr[0].ToString() == cbhftogr_gun11.Text)
                {
                    b4.Text = drblmpzr[b].ToString();
                    if (p == "Pazartesi" && b4.Text != "" && b4.Text == drblmpzr[b].ToString()) labelhft_blm16.Text = drblmpzr[1].ToString();
                    if (p == "Pazartesi" && b4.Text != "" && b4.Text == drblmpzr[b].ToString()) labelhft_sinif16.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Sali" && b4.Text != "" && b4.Text == drblmpzr[b].ToString()) labelhft_blm17.Text = drblmpzr[1].ToString();
                    if (p == "Sali" && b4.Text != "" && b4.Text == drblmpzr[b].ToString()) labelhft_sinif17.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Carsamba" && b4.Text != "" && b4.Text == drblmpzr[b].ToString()) labelhft_blm18.Text = drblmpzr[1].ToString();
                    if (p == "Carsamba" && b4.Text != "" && b4.Text == drblmpzr[b].ToString()) labelhft_sinif18.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Persembe" && b4.Text != "" && b4.Text == drblmpzr[b].ToString()) labelhft_blm19.Text = drblmpzr[1].ToString();
                    if (p == "Persembe" && b4.Text != "" && b4.Text == drblmpzr[b].ToString()) labelhft_sinif19.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Cuma" && b4.Text != "" && b4.Text == drblmpzr[b].ToString()) labelhft_blm20.Text = drblmpzr[1].ToString();
                    if (p == "Cuma" && b4.Text != "" && b4.Text == drblmpzr[b].ToString()) labelhft_sinif20.Text = (drblmpzr[2].ToString() + ".Sınıf");

                }

                if (drblmpzr[0].ToString() == cbhftogr_gun12.Text)
                {
                    b5.Text = drblmpzr[b].ToString();
                    if (p == "Pazartesi" && b5.Text != "" && b5.Text == drblmpzr[b].ToString()) labelhft_blm21.Text = drblmpzr[1].ToString();
                    if (p == "Pazartesi" && b5.Text != "" && b5.Text == drblmpzr[b].ToString()) labelhft_sinif21.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Sali" && b5.Text != "" && b5.Text == drblmpzr[b].ToString()) labelhft_blm22.Text = drblmpzr[1].ToString();
                    if (p == "Sali" && b5.Text != "" && b5.Text == drblmpzr[b].ToString()) labelhft_sinif22.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Carsamba" && b5.Text != "" && b5.Text == drblmpzr[b].ToString()) labelhft_blm23.Text = drblmpzr[1].ToString();
                    if (p == "Carsamba" && b5.Text != "" && b5.Text == drblmpzr[b].ToString()) labelhft_sinif23.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Persembe" && b5.Text != "" && b5.Text == drblmpzr[b].ToString()) labelhft_blm24.Text = drblmpzr[1].ToString();
                    if (p == "Persembe" && b5.Text != "" && b5.Text == drblmpzr[b].ToString()) labelhft_sinif24.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Cuma" && b5.Text != "" && b5.Text == drblmpzr[b].ToString()) labelhft_blm25.Text = drblmpzr[1].ToString();
                    if (p == "Cuma" && b5.Text != "" && b5.Text == drblmpzr[b].ToString()) labelhft_sinif25.Text = (drblmpzr[2].ToString() + ".Sınıf");

                }

                if (drblmpzr[0].ToString() == cbhftogr_gun13.Text)
                {
                    b6.Text = drblmpzr[b].ToString();
                    if (p == "Pazartesi" && b6.Text != "" && b6.Text == drblmpzr[b].ToString()) labelhft_blm26.Text = drblmpzr[1].ToString();
                    if (p == "Pazartesi" && b6.Text != "" && b6.Text == drblmpzr[b].ToString()) labelhft_sinif26.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Sali" && b6.Text != "" && b6.Text == drblmpzr[b].ToString()) labelhft_blm27.Text = drblmpzr[1].ToString();
                    if (p == "Sali" && b6.Text != "" && b6.Text == drblmpzr[b].ToString()) labelhft_sinif27.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Carsamba" && b6.Text != "" && b6.Text == drblmpzr[b].ToString()) labelhft_blm28.Text = drblmpzr[1].ToString();
                    if (p == "Carsamba" && b6.Text != "" && b6.Text == drblmpzr[b].ToString()) labelhft_sinif28.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Persembe" && b6.Text != "" && b6.Text == drblmpzr[b].ToString()) labelhft_blm29.Text = drblmpzr[1].ToString();
                    if (p == "Persembe" && b6.Text != "" && b6.Text == drblmpzr[b].ToString()) labelhft_sinif29.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Cuma" && b6.Text != "" && b6.Text == drblmpzr[b].ToString()) labelhft_blm30.Text = drblmpzr[1].ToString();
                    if (p == "Cuma" && b6.Text != "" && b6.Text == drblmpzr[b].ToString()) labelhft_sinif30.Text = (drblmpzr[2].ToString() + ".Sınıf");

                }

                if (drblmpzr[0].ToString() == cbhftogr_gun14.Text)
                {
                    b7.Text = drblmpzr[b].ToString();
                    if (p == "Pazartesi" && b7.Text != "" && b7.Text == drblmpzr[b].ToString()) labelhft_blm31.Text = drblmpzr[1].ToString();
                    if (p == "Pazartesi" && b7.Text != "" && b7.Text == drblmpzr[b].ToString()) labelhft_sinif31.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Sali" && b7.Text != "" && b7.Text == drblmpzr[b].ToString()) labelhft_blm32.Text = drblmpzr[1].ToString();
                    if (p == "Sali" && b7.Text != "" && b7.Text == drblmpzr[b].ToString()) labelhft_sinif32.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Carsamba" && b7.Text != "" && b7.Text == drblmpzr[b].ToString()) labelhft_blm33.Text = drblmpzr[1].ToString();
                    if (p == "Carsamba" && b7.Text != "" && b7.Text == drblmpzr[b].ToString()) labelhft_sinif33.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Persembe" && b7.Text != "" && b7.Text == drblmpzr[b].ToString()) labelhft_blm34.Text = drblmpzr[1].ToString();
                    if (p == "Persembe" && b7.Text != "" && b7.Text == drblmpzr[b].ToString()) labelhft_sinif34.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Cuma" && b7.Text != "" && b7.Text == drblmpzr[b].ToString()) labelhft_blm35.Text = drblmpzr[1].ToString();
                    if (p == "Cuma" && b7.Text != "" && b7.Text == drblmpzr[b].ToString()) labelhft_sinif35.Text = (drblmpzr[2].ToString() + ".Sınıf");

                }

                if (drblmpzr[0].ToString() == cbhftogr_gun15.Text)
                {
                    b8.Text = drblmpzr[b].ToString();
                    if (p == "Pazartesi" && b8.Text != "" && b8.Text == drblmpzr[b].ToString()) labelhft_blm36.Text = drblmpzr[1].ToString();
                    if (p == "Pazartesi" && b8.Text != "" && b8.Text == drblmpzr[b].ToString()) labelhft_sinif36.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Sali" && b8.Text != "" && b8.Text == drblmpzr[b].ToString()) labelhft_blm37.Text = drblmpzr[1].ToString();
                    if (p == "Sali" && b8.Text != "" && b8.Text == drblmpzr[b].ToString()) labelhft_sinif37.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Carsamba" && b8.Text != "" && b8.Text == drblmpzr[b].ToString()) labelhft_blm38.Text = drblmpzr[1].ToString();
                    if (p == "Carsamba" && b8.Text != "" && b8.Text == drblmpzr[b].ToString()) labelhft_sinif38.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Persembe" && b8.Text != "" && b8.Text == drblmpzr[b].ToString()) labelhft_blm39.Text = drblmpzr[1].ToString();
                    if (p == "Persembe" && b8.Text != "" && b8.Text == drblmpzr[b].ToString()) labelhft_sinif39.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Cuma" && b8.Text != "" && b8.Text == drblmpzr[b].ToString()) labelhft_blm40.Text = drblmpzr[1].ToString();
                    if (p == "Cuma" && b8.Text != "" && b8.Text == drblmpzr[b].ToString()) labelhft_sinif40.Text = (drblmpzr[2].ToString() + ".Sınıf");

                }

                if (drblmpzr[0].ToString() == cbhftogr_gun16.Text)
                {
                    b9.Text = drblmpzr[b].ToString();
                    if (p == "Pazartesi" && b9.Text != "" && b9.Text == drblmpzr[b].ToString()) labelhft_blm41.Text = drblmpzr[1].ToString();
                    if (p == "Pazartesi" && b9.Text != "" && b9.Text == drblmpzr[b].ToString()) labelhft_sinif41.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Sali" && b9.Text != "" && b9.Text == drblmpzr[b].ToString()) labelhft_blm42.Text = drblmpzr[1].ToString();
                    if (p == "Sali" && b9.Text != "" && b9.Text == drblmpzr[b].ToString()) labelhft_sinif42.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Carsamba" && b9.Text != "" && b9.Text == drblmpzr[b].ToString()) labelhft_blm43.Text = drblmpzr[1].ToString();
                    if (p == "Carsamba" && b9.Text != "" && b9.Text == drblmpzr[b].ToString()) labelhft_sinif43.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Persembe" && b9.Text != "" && b9.Text == drblmpzr[b].ToString()) labelhft_blm44.Text = drblmpzr[1].ToString();
                    if (p == "Persembe" && b9.Text != "" && b9.Text == drblmpzr[b].ToString()) labelhft_sinif44.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Cuma" && b9.Text != "" && b9.Text == drblmpzr[b].ToString()) labelhft_blm45.Text = drblmpzr[1].ToString();
                    if (p == "Cuma" && b9.Text != "" && b9.Text == drblmpzr[b].ToString()) labelhft_sinif45.Text = (drblmpzr[2].ToString() + ".Sınıf");

                }

                if (drblmpzr[0].ToString() == cbhftogr_gun17.Text)
                {
                    b10.Text = drblmpzr[b].ToString();
                    if (p == "Pazartesi" && b10.Text != "" && b10.Text == drblmpzr[b].ToString()) labelhft_blm46.Text = drblmpzr[1].ToString();
                    if (p == "Pazartesi" && b10.Text != "" && b10.Text == drblmpzr[b].ToString()) labelhft_sinif46.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Sali" && b10.Text != "" && b10.Text == drblmpzr[b].ToString()) labelhft_blm47.Text = drblmpzr[1].ToString();
                    if (p == "Sali" && b10.Text != "" && b10.Text == drblmpzr[b].ToString()) labelhft_sinif47.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Carsamba" && b10.Text != "" && b10.Text == drblmpzr[b].ToString()) labelhft_blm48.Text = drblmpzr[1].ToString();
                    if (p == "Carsamba" && b10.Text != "" && b10.Text == drblmpzr[b].ToString()) labelhft_sinif48.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Persembe" && b10.Text != "" && b10.Text == drblmpzr[b].ToString()) labelhft_blm49.Text = drblmpzr[1].ToString();
                    if (p == "Persembe" && b10.Text != "" && b10.Text == drblmpzr[b].ToString()) labelhft_sinif49.Text = (drblmpzr[2].ToString() + ".Sınıf");
                    if (p == "Cuma" && b10.Text != "" && b10.Text == drblmpzr[b].ToString()) labelhft_blm50.Text = drblmpzr[1].ToString();
                    if (p == "Cuma" && b10.Text != "" && b10.Text == drblmpzr[b].ToString()) labelhft_sinif50.Text = (drblmpzr[2].ToString() + ".Sınıf");

                }

            }
            baglanti.Close();
        }
        public void enabledac()
        {
            cbhft_pzrt08.Enabled = true;
            cbhft_pzrt09.Enabled = true;
            cbhft_pzrt10.Enabled = true;
            cbhft_pzrt11.Enabled = true;
            cbhft_pzrt12.Enabled = true;
            cbhft_pzrt13.Enabled = true;
            cbhft_pzrt14.Enabled = true;
            cbhft_pzrt15.Enabled = true;
            cbhft_pzrt16.Enabled = true;
            cbhft_pzrt17.Enabled = true;

            cbhft_sali08.Enabled = true;
            cbhft_sali09.Enabled = true;
            cbhft_sali10.Enabled = true;
            cbhft_sali11.Enabled = true;
            cbhft_sali12.Enabled = true;
            cbhft_sali13.Enabled = true;
            cbhft_sali14.Enabled = true;
            cbhft_sali15.Enabled = true;
            cbhft_sali16.Enabled = true;
            cbhft_sali17.Enabled = true;

            cbhft_crsmba08.Enabled = true;
            cbhft_crsmba09.Enabled = true;
            cbhft_crsmba10.Enabled = true;
            cbhft_crsmba11.Enabled = true;
            cbhft_crsmba12.Enabled = true;
            cbhft_crsmba13.Enabled = true;
            cbhft_crsmba14.Enabled = true;
            cbhft_crsmba15.Enabled = true;
            cbhft_crsmba16.Enabled = true;
            cbhft_crsmba17.Enabled = true;

            cbhft_prsmbe08.Enabled = true;
            cbhft_prsmbe09.Enabled = true;
            cbhft_prsmbe10.Enabled = true;
            cbhft_prsmbe11.Enabled = true;
            cbhft_prsmbe12.Enabled = true;
            cbhft_prsmbe13.Enabled = true;
            cbhft_prsmbe14.Enabled = true;
            cbhft_prsmbe15.Enabled = true;
            cbhft_prsmbe16.Enabled = true;
            cbhft_prsmbe17.Enabled = true;

            cbhft_cuma08.Enabled = true;
            cbhft_cuma09.Enabled = true;
            cbhft_cuma10.Enabled = true;
            cbhft_cuma11.Enabled = true;
            cbhft_cuma12.Enabled = true;
            cbhft_cuma13.Enabled = true;
            cbhft_cuma14.Enabled = true;
            cbhft_cuma15.Enabled = true;
            cbhft_cuma16.Enabled = true;
            cbhft_cuma17.Enabled = true;
        }
        public void enabledkapat()
            {
            cbhft_pzrt08.Enabled = false;
            cbhft_pzrt09.Enabled = false;
            cbhft_pzrt10.Enabled = false;
            cbhft_pzrt11.Enabled = false;
            cbhft_pzrt12.Enabled = false;
            cbhft_pzrt13.Enabled = false;
            cbhft_pzrt14.Enabled = false;
            cbhft_pzrt15.Enabled = false;
            cbhft_pzrt16.Enabled = false;
            cbhft_pzrt17.Enabled = false;

            cbhft_sali08.Enabled = false;
            cbhft_sali09.Enabled = false;
            cbhft_sali10.Enabled = false;
            cbhft_sali11.Enabled = false;
            cbhft_sali12.Enabled = false;
            cbhft_sali13.Enabled = false;
            cbhft_sali14.Enabled = false;
            cbhft_sali15.Enabled = false;
            cbhft_sali16.Enabled = false;
            cbhft_sali17.Enabled = false;

            cbhft_crsmba08.Enabled = false;
            cbhft_crsmba09.Enabled = false;
            cbhft_crsmba10.Enabled = false;
            cbhft_crsmba11.Enabled = false;
            cbhft_crsmba12.Enabled = false;
            cbhft_crsmba13.Enabled = false;
            cbhft_crsmba14.Enabled = false;
            cbhft_crsmba15.Enabled = false;
            cbhft_crsmba16.Enabled = false;
            cbhft_crsmba17.Enabled = false;

            cbhft_prsmbe08.Enabled = false;
            cbhft_prsmbe09.Enabled = false;
            cbhft_prsmbe10.Enabled = false;
            cbhft_prsmbe11.Enabled = false;
            cbhft_prsmbe12.Enabled = false;
            cbhft_prsmbe13.Enabled = false;
            cbhft_prsmbe14.Enabled = false;
            cbhft_prsmbe15.Enabled = false;
            cbhft_prsmbe16.Enabled = false;
            cbhft_prsmbe17.Enabled = false;

            cbhft_cuma08.Enabled = false;
            cbhft_cuma09.Enabled = false;
            cbhft_cuma10.Enabled = false;
            cbhft_cuma11.Enabled = false;
            cbhft_cuma12.Enabled = false;
            cbhft_cuma13.Enabled = false;
            cbhft_cuma14.Enabled = false;
            cbhft_cuma15.Enabled = false;
            cbhft_cuma16.Enabled = false;
            cbhft_cuma17.Enabled = false;
        }

        private void dtdrsp_ogretmen_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            sil();
           
            baglanti.Open();
            SqlCommand commanddersk = new SqlCommand("Select * From dersler", baglanti);
            SqlDataReader drdersk = commanddersk.ExecuteReader();

            while (drdersk.Read())
            {

                if ((dtdrsp_ogretmen.CurrentRow.Cells[0].Value + " " + dtdrsp_ogretmen.CurrentRow.Cells[1].Value) == drdersk[5].ToString())
                {

                    cbhft_pzrt08.Items.Add(drdersk[0].ToString());
                    cbhft_pzrt09.Items.Add(drdersk[0].ToString());
                    cbhft_pzrt10.Items.Add(drdersk[0].ToString());
                    cbhft_pzrt11.Items.Add(drdersk[0].ToString());
                    cbhft_pzrt12.Items.Add(drdersk[0].ToString());
                    cbhft_pzrt13.Items.Add(drdersk[0].ToString());
                    cbhft_pzrt14.Items.Add(drdersk[0].ToString());
                    cbhft_pzrt15.Items.Add(drdersk[0].ToString());
                    cbhft_pzrt16.Items.Add(drdersk[0].ToString());
                    cbhft_pzrt17.Items.Add(drdersk[0].ToString());

                    cbhft_sali08.Items.Add(drdersk[0].ToString());
                    cbhft_sali09.Items.Add(drdersk[0].ToString());
                    cbhft_sali10.Items.Add(drdersk[0].ToString());
                    cbhft_sali11.Items.Add(drdersk[0].ToString());
                    cbhft_sali12.Items.Add(drdersk[0].ToString());
                    cbhft_sali13.Items.Add(drdersk[0].ToString());
                    cbhft_sali14.Items.Add(drdersk[0].ToString());
                    cbhft_sali15.Items.Add(drdersk[0].ToString());
                    cbhft_sali16.Items.Add(drdersk[0].ToString());
                    cbhft_sali17.Items.Add(drdersk[0].ToString());

                    cbhft_crsmba08.Items.Add(drdersk[0].ToString());
                    cbhft_crsmba09.Items.Add(drdersk[0].ToString());
                    cbhft_crsmba10.Items.Add(drdersk[0].ToString());
                    cbhft_crsmba11.Items.Add(drdersk[0].ToString());
                    cbhft_crsmba12.Items.Add(drdersk[0].ToString());
                    cbhft_crsmba13.Items.Add(drdersk[0].ToString());
                    cbhft_crsmba14.Items.Add(drdersk[0].ToString());
                    cbhft_crsmba15.Items.Add(drdersk[0].ToString());
                    cbhft_crsmba16.Items.Add(drdersk[0].ToString());
                    cbhft_crsmba17.Items.Add(drdersk[0].ToString());

                    cbhft_prsmbe08.Items.Add(drdersk[0].ToString());
                    cbhft_prsmbe09.Items.Add(drdersk[0].ToString());
                    cbhft_prsmbe10.Items.Add(drdersk[0].ToString());
                    cbhft_prsmbe11.Items.Add(drdersk[0].ToString());
                    cbhft_prsmbe12.Items.Add(drdersk[0].ToString());
                    cbhft_prsmbe13.Items.Add(drdersk[0].ToString());
                    cbhft_prsmbe14.Items.Add(drdersk[0].ToString());
                    cbhft_prsmbe15.Items.Add(drdersk[0].ToString());
                    cbhft_prsmbe16.Items.Add(drdersk[0].ToString());
                    cbhft_prsmbe17.Items.Add(drdersk[0].ToString());

                    cbhft_cuma08.Items.Add(drdersk[0].ToString());
                    cbhft_cuma09.Items.Add(drdersk[0].ToString());
                    cbhft_cuma10.Items.Add(drdersk[0].ToString());
                    cbhft_cuma11.Items.Add(drdersk[0].ToString());
                    cbhft_cuma12.Items.Add(drdersk[0].ToString());
                    cbhft_cuma13.Items.Add(drdersk[0].ToString());
                    cbhft_cuma14.Items.Add(drdersk[0].ToString());
                    cbhft_cuma15.Items.Add(drdersk[0].ToString());
                    cbhft_cuma16.Items.Add(drdersk[0].ToString());
                    cbhft_cuma17.Items.Add(drdersk[0].ToString());
                }
            }
            baglanti.Close();
            enabledac();
            pictureBoxdpogr_ekle.Visible = true;
            pictureBoxdpogr_kaydet.Visible = true;
            pictureBoxdpogr_sil.Visible = true;


            baglanti.Open();

            SqlCommand commandhfo = new SqlCommand("Select * From haftalikdersogretmen", baglanti);
            SqlDataReader drhfo = commandhfo.ExecuteReader();
            int i = 0;


            int gizle = 0;
            while (drhfo.Read())
            {
             
                if (dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString() == drhfo[0].ToString())
                {
                    gizle = 1;
                    if (drhfo[1].ToString() == "08:00")
                    {

                        cbhft_pzrt08.Text = drhfo[4].ToString();
                        if (drhfo[2].ToString() == "")
                            labelhft_sinif1.Text = (drhfo[2].ToString());
                        else
                            labelhft_sinif1.Text = (drhfo[2].ToString() + ".Sınıf");
                        labelhft_blm1.Text = drhfo[3].ToString();
                        cbhft_sali08.Text = drhfo[7].ToString();
                        if (drhfo[5].ToString() == "")
                            labelhft_sinif2.Text = (drhfo[5].ToString());
                        else
                            labelhft_sinif2.Text = (drhfo[5].ToString() + ".Sınıf");
                       
                        labelhft_blm2.Text = drhfo[6].ToString();
                        cbhft_crsmba08.Text = drhfo[10].ToString();
                        if (drhfo[8].ToString() == "")
                            labelhft_sinif3.Text = (drhfo[8].ToString());
                        else
                            labelhft_sinif3.Text = (drhfo[8].ToString() + ".Sınıf");
                        labelhft_blm3.Text = drhfo[9].ToString();
                        cbhft_prsmbe08.Text = drhfo[13].ToString();
                        if (drhfo[11].ToString() == "")
                            labelhft_sinif4.Text = (drhfo[11].ToString());
                        else
                            labelhft_sinif4.Text = (drhfo[11].ToString() + ".Sınıf");
                        labelhft_blm4.Text = drhfo[12].ToString();
                        cbhft_cuma08.Text = drhfo[16].ToString();
                        if (drhfo[14].ToString() == "")
                            labelhft_sinif5.Text = (drhfo[14].ToString());
                        else
                            labelhft_sinif5.Text = (drhfo[14].ToString() + ".Sınıf");
                        labelhft_blm5.Text = drhfo[15].ToString();


                    }
                    else if (drhfo[1].ToString() == "09:00")
                    {
                        cbhft_pzrt09.Text = drhfo[4].ToString();
                        if (drhfo[2].ToString() == "")
                            labelhft_sinif6.Text = (drhfo[2].ToString());
                        else
                            labelhft_sinif6.Text = (drhfo[2].ToString() + ".Sınıf");
                        labelhft_blm6.Text = drhfo[3].ToString();

                        cbhft_sali09.Text = drhfo[7].ToString();
                        if (drhfo[5].ToString() == "")
                            labelhft_sinif7.Text = (drhfo[5].ToString());
                        else
                            labelhft_sinif7.Text = (drhfo[5].ToString() + ".Sınıf");
                        labelhft_blm7.Text = drhfo[6].ToString();

                        cbhft_crsmba09.Text = drhfo[10].ToString();
                        if (drhfo[8].ToString() == "")
                            labelhft_sinif8.Text = (drhfo[8].ToString());
                        else
                            labelhft_sinif8.Text = (drhfo[8].ToString() + ".Sınıf");
                        labelhft_blm8.Text = drhfo[9].ToString();

                        cbhft_prsmbe09.Text = drhfo[13].ToString();
                        if (drhfo[11].ToString() == "")
                            labelhft_sinif9.Text = (drhfo[11].ToString());
                        else
                            labelhft_sinif9.Text = (drhfo[11].ToString() + ".Sınıf");
                        labelhft_blm9.Text = drhfo[12].ToString();

                        cbhft_cuma09.Text = drhfo[16].ToString();
                        if (drhfo[14].ToString() == "")
                            labelhft_sinif10.Text = (drhfo[14].ToString());
                        else
                            labelhft_sinif10.Text = (drhfo[14].ToString() + ".Sınıf");
                        labelhft_blm10.Text = drhfo[15].ToString();

                    }
                    else if (drhfo[1].ToString() == "10:00")
                    {

                        cbhft_pzrt10.Text = drhfo[4].ToString();
                        if (drhfo[2].ToString() == "")
                            labelhft_sinif11.Text = (drhfo[2].ToString());
                        else
                            labelhft_sinif11.Text = (drhfo[2].ToString() + ".Sınıf");
                        labelhft_blm11.Text = drhfo[3].ToString();

                        cbhft_sali10.Text = drhfo[7].ToString();
                        if (drhfo[5].ToString() == "")
                            labelhft_sinif12.Text = (drhfo[5].ToString());
                        else
                            labelhft_sinif12.Text = (drhfo[5].ToString() + ".Sınıf");
                        labelhft_blm12.Text = drhfo[6].ToString();

                        cbhft_crsmba10.Text = drhfo[10].ToString();
                        if (drhfo[8].ToString() == "")
                            labelhft_sinif13.Text = (drhfo[8].ToString());
                        else
                            labelhft_sinif13.Text = (drhfo[8].ToString() + ".Sınıf");
                        labelhft_blm13.Text = drhfo[9].ToString();

                        cbhft_prsmbe10.Text = drhfo[13].ToString();
                        if (drhfo[11].ToString() == "")
                            labelhft_sinif14.Text = (drhfo[11].ToString());
                        else
                            labelhft_sinif14.Text = (drhfo[11].ToString() + ".Sınıf");
                        labelhft_blm14.Text = drhfo[12].ToString();

                        cbhft_cuma10.Text = drhfo[16].ToString();
                        if (drhfo[14].ToString() == "")
                            labelhft_sinif15.Text = (drhfo[14].ToString());
                        else
                            labelhft_sinif15.Text = (drhfo[14].ToString() + ".Sınıf");
                        labelhft_blm15.Text = drhfo[15].ToString();

                    }
                    else if (drhfo[1].ToString() == "11:00")
                    {
                        cbhft_pzrt11.Text = drhfo[4].ToString();
                        if (drhfo[2].ToString() == "")
                            labelhft_sinif16.Text = (drhfo[2].ToString());
                        else
                            labelhft_sinif16.Text = (drhfo[2].ToString() + ".Sınıf");
                        labelhft_blm16.Text = drhfo[3].ToString();

                        cbhft_sali11.Text = drhfo[7].ToString();
                        if (drhfo[5].ToString() == "")
                            labelhft_sinif17.Text = (drhfo[5].ToString());
                        else
                            labelhft_sinif17.Text = (drhfo[5].ToString() + ".Sınıf");
                        labelhft_blm17.Text = drhfo[6].ToString();

                        cbhft_crsmba11.Text = drhfo[10].ToString();
                        if (drhfo[8].ToString() == "")
                            labelhft_sinif18.Text = (drhfo[8].ToString());
                        else
                            labelhft_sinif18.Text = (drhfo[8].ToString() + ".Sınıf");
                        labelhft_blm18.Text = drhfo[9].ToString();

                        cbhft_prsmbe11.Text = drhfo[13].ToString();
                        if (drhfo[11].ToString() == "")
                            labelhft_sinif19.Text = (drhfo[11].ToString());
                        else
                            labelhft_sinif19.Text = (drhfo[11].ToString() + ".Sınıf");
                        labelhft_blm19.Text = drhfo[12].ToString();

                        cbhft_cuma11.Text = drhfo[16].ToString();
                        if (drhfo[14].ToString() == "")
                            labelhft_sinif20.Text = (drhfo[14].ToString());
                        else
                            labelhft_sinif20.Text = (drhfo[14].ToString() + ".Sınıf");
                        labelhft_blm20.Text = drhfo[15].ToString();

                    }
                    else if (drhfo[1].ToString() == "12:00")
                    {
                        cbhft_pzrt12.Text = drhfo[4].ToString();
                        if (drhfo[2].ToString() == "")
                            labelhft_sinif21.Text = (drhfo[2].ToString());
                        else
                            labelhft_sinif21.Text = (drhfo[2].ToString() + ".Sınıf");
                        labelhft_blm21.Text = drhfo[3].ToString();

                        cbhft_sali12.Text = drhfo[7].ToString();
                        if (drhfo[5].ToString() == "")
                            labelhft_sinif22.Text = (drhfo[5].ToString());
                        else
                            labelhft_sinif22.Text = (drhfo[5].ToString() + ".Sınıf");
                        labelhft_blm22.Text = drhfo[6].ToString();

                        cbhft_crsmba12.Text = drhfo[10].ToString();
                        if (drhfo[8].ToString() == "")
                            labelhft_sinif23.Text = (drhfo[8].ToString());
                        else
                            labelhft_sinif23.Text = (drhfo[8].ToString() + ".Sınıf");
                        labelhft_blm23.Text = drhfo[9].ToString();

                        cbhft_prsmbe12.Text = drhfo[13].ToString();
                        if (drhfo[11].ToString() == "")
                            labelhft_sinif24.Text = (drhfo[11].ToString());
                        else
                            labelhft_sinif24.Text = (drhfo[11].ToString() + ".Sınıf");
                        labelhft_blm24.Text = drhfo[12].ToString();

                        cbhft_cuma12.Text = drhfo[16].ToString();
                        if (drhfo[14].ToString() == "")
                            labelhft_sinif25.Text = (drhfo[14].ToString());
                        else
                            labelhft_sinif25.Text = (drhfo[14].ToString() + ".Sınıf");
                        labelhft_blm25.Text = drhfo[15].ToString();
                    }
                    else if (drhfo[1].ToString() == "13:00")
                    {
                        cbhft_pzrt13.Text = drhfo[4].ToString();
                        if (drhfo[2].ToString() == "")
                            labelhft_sinif26.Text = (drhfo[2].ToString());
                        else
                            labelhft_sinif26.Text = (drhfo[2].ToString() + ".Sınıf");
                        labelhft_blm26.Text = drhfo[3].ToString();

                        cbhft_sali13.Text = drhfo[7].ToString();
                        if (drhfo[5].ToString() == "")
                            labelhft_sinif27.Text = (drhfo[5].ToString());
                        else
                            labelhft_sinif27.Text = (drhfo[5].ToString() + ".Sınıf");
                        labelhft_blm27.Text = drhfo[6].ToString();

                        cbhft_crsmba13.Text = drhfo[10].ToString();
                        if (drhfo[8].ToString() == "")
                            labelhft_sinif28.Text = (drhfo[8].ToString());
                        else
                            labelhft_sinif28.Text = (drhfo[8].ToString() + ".Sınıf");
                        labelhft_blm28.Text = drhfo[9].ToString();

                        cbhft_prsmbe13.Text = drhfo[13].ToString();
                        if (drhfo[11].ToString() == "")
                            labelhft_sinif29.Text = (drhfo[11].ToString());
                        else
                            labelhft_sinif29.Text = (drhfo[11].ToString() + ".Sınıf");
                        labelhft_blm29.Text = drhfo[12].ToString();

                        cbhft_cuma13.Text = drhfo[16].ToString();
                        if (drhfo[14].ToString() == "")
                            labelhft_sinif30.Text = (drhfo[14].ToString());
                        else
                            labelhft_sinif30.Text = (drhfo[14].ToString() + ".Sınıf");
                        labelhft_blm30.Text = drhfo[15].ToString();


                    }
                    else if (drhfo[1].ToString() == "14:00")
                    {
                        cbhft_pzrt14.Text = drhfo[4].ToString();
                        if (drhfo[2].ToString() == "")
                            labelhft_sinif31.Text = (drhfo[2].ToString());
                        else
                            labelhft_sinif31.Text = (drhfo[2].ToString() + ".Sınıf");
                        labelhft_blm31.Text = drhfo[3].ToString();

                        cbhft_sali14.Text = drhfo[7].ToString();
                        if (drhfo[5].ToString() == "")
                            labelhft_sinif32.Text = (drhfo[5].ToString());
                        else
                            labelhft_sinif32.Text = (drhfo[5].ToString() + ".Sınıf");
                        labelhft_blm32.Text = drhfo[6].ToString();

                        cbhft_crsmba14.Text = drhfo[10].ToString();
                        if (drhfo[8].ToString() == "")
                            labelhft_sinif33.Text = (drhfo[8].ToString());
                        else
                            labelhft_sinif33.Text = (drhfo[8].ToString() + ".Sınıf");
                        labelhft_blm33.Text = drhfo[9].ToString();

                        cbhft_prsmbe14.Text = drhfo[13].ToString();
                        if (drhfo[11].ToString() == "")
                            labelhft_sinif34.Text = (drhfo[11].ToString());
                        else
                            labelhft_sinif34.Text = (drhfo[11].ToString() + ".Sınıf");
                        labelhft_blm34.Text = drhfo[12].ToString();

                        cbhft_cuma14.Text = drhfo[16].ToString();
                        if (drhfo[14].ToString() == "")
                            labelhft_sinif35.Text = (drhfo[14].ToString());
                        else
                            labelhft_sinif35.Text = (drhfo[14].ToString() + ".Sınıf");
                        labelhft_blm35.Text = drhfo[15].ToString();

                    }
                    else if (drhfo[1].ToString() == "15:00")
                    {
                        cbhft_pzrt15.Text = drhfo[4].ToString();
                        if (drhfo[2].ToString() == "")
                            labelhft_sinif36.Text = (drhfo[2].ToString());
                        else
                            labelhft_sinif36.Text = (drhfo[2].ToString() + ".Sınıf");
                        labelhft_blm36.Text = drhfo[3].ToString();

                        cbhft_sali15.Text = drhfo[7].ToString();
                        if (drhfo[5].ToString() == "")
                            labelhft_sinif37.Text = (drhfo[5].ToString());
                        else
                            labelhft_sinif37.Text = (drhfo[5].ToString() + ".Sınıf");
                        labelhft_blm37.Text = drhfo[5].ToString();

                        cbhft_crsmba15.Text = drhfo[10].ToString();
                        if (drhfo[8].ToString() == "")
                            labelhft_sinif38.Text = (drhfo[8].ToString());
                        else
                            labelhft_sinif38.Text = (drhfo[8].ToString() + ".Sınıf");
                        labelhft_blm38.Text = drhfo[9].ToString();

                        cbhft_prsmbe15.Text = drhfo[13].ToString();
                        if (drhfo[11].ToString() == "")
                            labelhft_sinif39.Text = (drhfo[11].ToString());
                        else
                            labelhft_sinif39.Text = (drhfo[11].ToString() + ".Sınıf");
                        labelhft_blm39.Text = drhfo[12].ToString();

                        cbhft_cuma15.Text = drhfo[16].ToString();
                        if (drhfo[14].ToString() == "")
                            labelhft_sinif40.Text = (drhfo[14].ToString());
                        else
                            labelhft_sinif40.Text = (drhfo[14].ToString() + ".Sınıf");
                        labelhft_blm40.Text = drhfo[15].ToString();

                    }
                    else if (drhfo[1].ToString() == "16:00")
                    {
                        cbhft_pzrt16.Text = drhfo[4].ToString();
                        if (drhfo[2].ToString() == "")
                            labelhft_sinif41.Text = (drhfo[2].ToString());
                        else
                            labelhft_sinif41.Text = (drhfo[2].ToString() + ".Sınıf");
                        labelhft_blm41.Text = drhfo[3].ToString();

                        cbhft_sali16.Text = drhfo[7].ToString();
                        if (drhfo[5].ToString() == "")
                            labelhft_sinif42.Text = (drhfo[5].ToString());
                        else
                            labelhft_sinif42.Text = (drhfo[5].ToString() + ".Sınıf");
                        labelhft_blm42.Text = drhfo[6].ToString();

                        cbhft_crsmba16.Text = drhfo[10].ToString();
                        if (drhfo[8].ToString() == "")
                            labelhft_sinif43.Text = (drhfo[8].ToString());
                        else
                            labelhft_sinif43.Text = (drhfo[8].ToString() + ".Sınıf");
                        labelhft_blm43.Text = drhfo[9].ToString();

                        cbhft_prsmbe16.Text = drhfo[13].ToString();
                        if (drhfo[11].ToString() == "")
                            labelhft_sinif44.Text = (drhfo[11].ToString());
                        else
                            labelhft_sinif44.Text = (drhfo[11].ToString() + ".Sınıf");
                        labelhft_blm44.Text = drhfo[12].ToString();

                        cbhft_cuma16.Text = drhfo[16].ToString();
                        if (drhfo[14].ToString() == "")
                            labelhft_sinif45.Text = (drhfo[14].ToString());
                        else
                            labelhft_sinif45.Text = (drhfo[14].ToString() + ".Sınıf");
                        labelhft_blm45.Text = drhfo[15].ToString();


                    }
                    else if (drhfo[1].ToString() == "17:00")
                    {
                        cbhft_pzrt17.Text = drhfo[4].ToString();
                        if (drhfo[2].ToString() == "")
                            labelhft_sinif46.Text = (drhfo[2].ToString());
                        else
                            labelhft_sinif46.Text = (drhfo[2].ToString() + ".Sınıf");
                        labelhft_blm46.Text = drhfo[3].ToString();

                        cbhft_sali17.Text = drhfo[7].ToString();
                        if (drhfo[5].ToString() == "")
                            labelhft_sinif47.Text = (drhfo[5].ToString());
                        else
                            labelhft_sinif47.Text = (drhfo[5].ToString() + ".Sınıf");
                        labelhft_blm47.Text = drhfo[6].ToString();

                        cbhft_crsmba17.Text = drhfo[10].ToString();
                        if (drhfo[8].ToString() == "")
                            labelhft_sinif48.Text = (drhfo[8].ToString());
                        else
                            labelhft_sinif48.Text = (drhfo[8].ToString() + ".Sınıf");
                        labelhft_blm48.Text = drhfo[9].ToString();

                        cbhft_prsmbe17.Text = drhfo[13].ToString();
                        if (drhfo[11].ToString() == "")
                            labelhft_sinif49.Text = (drhfo[11].ToString());
                        else
                            labelhft_sinif49.Text = (drhfo[11].ToString() + ".Sınıf");
                        labelhft_blm49.Text = drhfo[12].ToString();

                        cbhft_cuma17.Text = drhfo[16].ToString();
                        if (drhfo[14].ToString() == "")
                            labelhft_sinif50.Text = (drhfo[14].ToString());
                        else
                            labelhft_sinif50.Text = (drhfo[14].ToString() + ".Sınıf");
                        labelhft_blm50.Text = drhfo[15].ToString();

                    }
                    if(dtdrsp_ogretmen.CurrentRow.Cells[3].Value.ToString() != "Ortak Ders")
                    {
                        pictureBoxdpogr_ekle.Visible = false;
                    }
                  
                    pictureBoxdpogr_kaydet.Visible = true;
                    pictureBoxdpogr_sil.Visible = true;
                    i++;
                }
                else
                {
                    if(gizle == 0)
                    {
                        pictureBoxdpogr_ekle.Visible = true;
                        pictureBoxdpogr_kaydet.Visible = false;
                        pictureBoxdpogr_sil.Visible = false;
                    }
                }
               
           
            }
            baglanti.Close();
            if (dtdrsp_ogretmen.CurrentRow.Cells[3].Value.ToString() == "Ortak Ders")
            {
             
                ortakdersgetir("Select saat, bolum,sinif,pazartesi from haftalikdersogrenci where pazartesi != '' ", 3,"Pazartesi", cbhft_pzrt08, cbhft_pzrt09, cbhft_pzrt10, cbhft_pzrt11, cbhft_pzrt12, cbhft_pzrt13, cbhft_pzrt14, cbhft_pzrt15, cbhft_pzrt16, cbhft_pzrt17);
             
                ortakdersgetir("Select saat, bolum,sinif,sali from haftalikdersogrenci where sali != '' ", 3, "Sali", cbhft_sali08, cbhft_sali09, cbhft_sali10, cbhft_sali11, cbhft_sali12, cbhft_sali13, cbhft_sali14, cbhft_sali15, cbhft_sali16, cbhft_sali17);
                ortakdersgetir("Select saat, bolum,sinif,carsamba from haftalikdersogrenci where carsamba != '' ", 3, "Carsamba", cbhft_crsmba08, cbhft_crsmba09, cbhft_crsmba10, cbhft_crsmba11, cbhft_crsmba12, cbhft_crsmba13, cbhft_crsmba14, cbhft_crsmba15, cbhft_crsmba16, cbhft_crsmba17);
                ortakdersgetir("Select saat, bolum,sinif,persembe from haftalikdersogrenci where persembe != '' ", 3, "Persembe", cbhft_prsmbe08, cbhft_prsmbe09, cbhft_prsmbe10, cbhft_prsmbe11, cbhft_prsmbe12, cbhft_prsmbe13, cbhft_prsmbe14, cbhft_prsmbe15, cbhft_prsmbe16, cbhft_prsmbe17);
                ortakdersgetir("Select saat, bolum,sinif,cuma from haftalikdersogrenci where cuma != '' ", 3, "Cuma", cbhft_cuma08, cbhft_cuma09, cbhft_cuma10, cbhft_cuma11, cbhft_cuma12, cbhft_cuma13, cbhft_cuma14, cbhft_cuma15, cbhft_cuma16, cbhft_cuma17);
                enabledkapat();

                baglanti.Open();
                SqlCommand commanddersko = new SqlCommand("Select * From haftalikdersogretmen", baglanti);
                SqlDataReader drdersko = commanddersko.ExecuteReader();
                int gizleortak = 0;
                while (drdersko.Read())
                {
                    if (dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString() == drdersko[0].ToString())
                    {
                        gizleortak = 1;
                        pictureBoxdpogr_ekle.Visible = false;
                        pictureBoxdpogr_kaydet.Visible = false;
                        pictureBoxdpogr_sil.Visible = true;


                    }
                    else
                    {
                        if (gizleortak == 0)
                        {
                            pictureBoxdpogr_ekle.Visible = true;
                            pictureBoxdpogr_kaydet.Visible = false;
                            pictureBoxdpogr_sil.Visible = false;
                        }
                    }
                }
                baglanti.Close();
                   
              
                
            }
        }
      
       
    
        private void fazlasatir(string a,string b,string c, string d, string e, string f, string g,string lbls1, string lbls2, string lbls3, string lbls4, string lbls5, string lblb1, string lblb2, string lblb3, string lblb4, string lblb5)
        {
            if(dtdrsp_ogretmen.CurrentRow.Cells[3].Value.ToString() == "Ortak Ders")
            {
                if (lblb1.Length > 0)
                    lbls1 = lbls1.Substring(0, 1);
                if (lblb2.Length > 0)
                    lbls2 = lbls2.Substring(0, 1);
                if (lblb3.Length > 0)
                    lbls3 = lbls3.Substring(0, 1);
                if (lblb4.Length > 0)
                    lbls4 = lbls4.Substring(0, 1);
                if (lblb5.Length > 0)
                    lbls5 = lbls5.Substring(0, 1);



                baglanti.Open();
                string kayit = "insert into haftalikdersogretmen (tc,saat,sinif1,bolum1,pazartesi,sinif2,bolum2,sali,sinif3,bolum3,carsamba,sinif4,bolum4,persembe,sinif5,bolum5,cuma) values(@tc,@saat,@sinif1,@bolum1,@pazartesi,@sinif2,@bolum2,@sali,@sinif3,@bolum3,@carsamba,@sinif4,@bolum4,@persembe,@sinif5,@bolum5,@cuma)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@tc", a);
                komut.Parameters.AddWithValue("@saat", b);
                komut.Parameters.AddWithValue("@sinif1", lbls1);
                komut.Parameters.AddWithValue("@bolum1", lblb1);
                komut.Parameters.AddWithValue("@pazartesi", c);
                komut.Parameters.AddWithValue("@sinif2", lbls2);
                komut.Parameters.AddWithValue("@bolum2", lblb2);
                komut.Parameters.AddWithValue("@sali", d);
                komut.Parameters.AddWithValue("@sinif3", lbls3);
                komut.Parameters.AddWithValue("@bolum3", lblb3);
                komut.Parameters.AddWithValue("@carsamba", e);
                komut.Parameters.AddWithValue("@sinif4", lbls4);
                komut.Parameters.AddWithValue("@bolum4", lblb4);
                komut.Parameters.AddWithValue("@persembe", f);
                komut.Parameters.AddWithValue("@sinif5", lbls5);
                komut.Parameters.AddWithValue("@bolum5", lblb5);
                komut.Parameters.AddWithValue("@cuma", g);
                komut.ExecuteNonQuery();
                baglanti.Close();

            }
            else
            {
                baglanti.Open();
                SqlCommand commanddersko = new SqlCommand("Select adi,sinifi,bolum From dersler", baglanti);
                SqlDataReader drdersko = commanddersko.ExecuteReader();

                while (drdersko.Read())
                {
                    if (drdersko[0].ToString() == c.ToString())
                    {
                        lbls1 = drdersko[1].ToString();
                        lblb1 = drdersko[2].ToString();
                    }
                    if (drdersko[0].ToString() == d.ToString())
                    {
                        lbls2 = drdersko[1].ToString();
                        lblb2 = drdersko[2].ToString();
                    }
                    if (drdersko[0].ToString() == e.ToString())
                    {
                        lbls3 = drdersko[1].ToString();
                        lblb3 = drdersko[2].ToString();
                    }
                    if (drdersko[0].ToString() == f.ToString())
                    {
                        lbls4 = drdersko[1].ToString();
                        lblb4 = drdersko[2].ToString();
                    }
                    if (drdersko[0].ToString() == g.ToString())
                    {
                        lbls5 = drdersko[1].ToString();
                        lblb5 = drdersko[2].ToString();
                    }
                }
                baglanti.Close();

                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into haftalikdersogretmen (tc,saat,sinif1,bolum1,pazartesi,sinif2,bolum2,sali,sinif3,bolum3,carsamba,sinif4,bolum4,persembe,sinif5,bolum5,cuma) values(@tc,@saat,@sinif1,@bolum1,@pazartesi,@sinif2,@bolum2,@sali,@sinif3,@bolum3,@carsamba,@sinif4,@bolum4,@persembe,@sinif5,@bolum5,@cuma)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@tc", a);

                komut.Parameters.AddWithValue("@saat", b);
                komut.Parameters.AddWithValue("@sinif1", lbls1);
                komut.Parameters.AddWithValue("@bolum1", lblb1);
                komut.Parameters.AddWithValue("@pazartesi", c);
                komut.Parameters.AddWithValue("@sinif2", lbls2);
                komut.Parameters.AddWithValue("@bolum2", lblb2);
                komut.Parameters.AddWithValue("@sali", d);
                komut.Parameters.AddWithValue("@sinif3", lbls3);
                komut.Parameters.AddWithValue("@bolum3", lblb3);
                komut.Parameters.AddWithValue("@carsamba", e);
                komut.Parameters.AddWithValue("@sinif4", lbls4);
                komut.Parameters.AddWithValue("@bolum4", lblb4);
                komut.Parameters.AddWithValue("@persembe", f);
                komut.Parameters.AddWithValue("@sinif5", lbls5);
                komut.Parameters.AddWithValue("@bolum5", lblb5);
                komut.Parameters.AddWithValue("@cuma", g);



                komut.ExecuteNonQuery();
                baglanti.Close();
            }




        }
       

        private void pictureBoxdpogr_ekle_Click(object sender, EventArgs e)
        {

            if(dtdrsp_ogretmen.CurrentRow.Cells[3].Value.ToString() == "Ortak Ders")
            {
                try
                {

                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun08.Text, cbhft_pzrt08.Text, cbhft_sali08.Text, cbhft_crsmba08.Text, cbhft_prsmbe08.Text, cbhft_cuma08.Text, labelhft_sinif1.Text, labelhft_sinif2.Text, labelhft_sinif3.Text, labelhft_sinif4.Text, labelhft_sinif5.Text, labelhft_blm1.Text, labelhft_blm2.Text, labelhft_blm3.Text, labelhft_blm4.Text, labelhft_blm5.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun09.Text, cbhft_pzrt09.Text, cbhft_sali09.Text, cbhft_crsmba09.Text, cbhft_prsmbe09.Text, cbhft_cuma09.Text, labelhft_sinif6.Text, labelhft_sinif7.Text, labelhft_sinif8.Text, labelhft_sinif9.Text, labelhft_sinif10.Text, labelhft_blm6.Text, labelhft_blm7.Text, labelhft_blm8.Text, labelhft_blm9.Text, labelhft_blm10.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun10.Text, cbhft_pzrt10.Text, cbhft_sali10.Text, cbhft_crsmba10.Text, cbhft_prsmbe10.Text, cbhft_cuma10.Text, labelhft_sinif11.Text, labelhft_sinif12.Text, labelhft_sinif13.Text, labelhft_sinif14.Text, labelhft_sinif15.Text, labelhft_blm11.Text, labelhft_blm12.Text, labelhft_blm13.Text, labelhft_blm14.Text, labelhft_blm15.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun11.Text, cbhft_pzrt11.Text, cbhft_sali11.Text, cbhft_crsmba11.Text, cbhft_prsmbe11.Text, cbhft_cuma11.Text, labelhft_sinif16.Text, labelhft_sinif17.Text, labelhft_sinif18.Text, labelhft_sinif19.Text, labelhft_sinif20.Text, labelhft_blm16.Text, labelhft_blm17.Text, labelhft_blm18.Text, labelhft_blm19.Text, labelhft_blm20.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun12.Text, cbhft_pzrt12.Text, cbhft_sali12.Text, cbhft_crsmba12.Text, cbhft_prsmbe12.Text, cbhft_cuma12.Text, labelhft_sinif21.Text, labelhft_sinif22.Text, labelhft_sinif23.Text, labelhft_sinif24.Text, labelhft_sinif25.Text, labelhft_blm21.Text, labelhft_blm22.Text, labelhft_blm23.Text, labelhft_blm24.Text, labelhft_blm25.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun13.Text, cbhft_pzrt13.Text, cbhft_sali13.Text, cbhft_crsmba13.Text, cbhft_prsmbe13.Text, cbhft_cuma13.Text, labelhft_sinif26.Text, labelhft_sinif27.Text, labelhft_sinif28.Text, labelhft_sinif29.Text, labelhft_sinif30.Text, labelhft_blm26.Text, labelhft_blm27.Text, labelhft_blm28.Text, labelhft_blm29.Text, labelhft_blm30.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun14.Text, cbhft_pzrt14.Text, cbhft_sali14.Text, cbhft_crsmba14.Text, cbhft_prsmbe14.Text, cbhft_cuma14.Text, labelhft_sinif31.Text, labelhft_sinif32.Text, labelhft_sinif33.Text, labelhft_sinif34.Text, labelhft_sinif35.Text, labelhft_blm31.Text, labelhft_blm32.Text, labelhft_blm33.Text, labelhft_blm34.Text, labelhft_blm35.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun15.Text, cbhft_pzrt15.Text, cbhft_sali15.Text, cbhft_crsmba15.Text, cbhft_prsmbe15.Text, cbhft_cuma15.Text, labelhft_sinif36.Text, labelhft_sinif37.Text, labelhft_sinif38.Text, labelhft_sinif39.Text, labelhft_sinif40.Text, labelhft_blm36.Text, labelhft_blm37.Text, labelhft_blm38.Text, labelhft_blm39.Text, labelhft_blm40.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun16.Text, cbhft_pzrt16.Text, cbhft_sali16.Text, cbhft_crsmba16.Text, cbhft_prsmbe16.Text, cbhft_cuma16.Text, labelhft_sinif41.Text, labelhft_sinif42.Text, labelhft_sinif43.Text, labelhft_sinif44.Text, labelhft_sinif45.Text, labelhft_blm41.Text, labelhft_blm42.Text, labelhft_blm43.Text, labelhft_blm44.Text, labelhft_blm45.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun17.Text, cbhft_pzrt17.Text, cbhft_sali17.Text, cbhft_crsmba17.Text, cbhft_prsmbe17.Text, cbhft_cuma17.Text, labelhft_sinif46.Text, labelhft_sinif47.Text, labelhft_sinif48.Text, labelhft_sinif49.Text, labelhft_sinif50.Text, labelhft_blm46.Text, labelhft_blm47.Text, labelhft_blm48.Text, labelhft_blm49.Text, labelhft_blm50.Text);

                    MessageBox.Show("Kayit Eklendi");

                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hatali " + hata.Message);
                }
            }
            else
            {
                try
                {

                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun08.Text, cbhft_pzrt08.Text, cbhft_sali08.Text, cbhft_crsmba08.Text, cbhft_prsmbe08.Text, cbhft_cuma08.Text, labelhft_sinif1.Text, labelhft_sinif2.Text, labelhft_sinif3.Text, labelhft_sinif4.Text, labelhft_sinif5.Text, labelhft_blm1.Text, labelhft_blm2.Text, labelhft_blm3.Text, labelhft_blm4.Text, labelhft_blm5.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun09.Text, cbhft_pzrt09.Text, cbhft_sali09.Text, cbhft_crsmba09.Text, cbhft_prsmbe09.Text, cbhft_cuma09.Text, labelhft_sinif6.Text, labelhft_sinif7.Text, labelhft_sinif8.Text, labelhft_sinif9.Text, labelhft_sinif10.Text, labelhft_blm6.Text, labelhft_blm7.Text, labelhft_blm8.Text, labelhft_blm9.Text, labelhft_blm10.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun10.Text, cbhft_pzrt10.Text, cbhft_sali10.Text, cbhft_crsmba10.Text, cbhft_prsmbe10.Text, cbhft_cuma10.Text, labelhft_sinif11.Text, labelhft_sinif12.Text, labelhft_sinif13.Text, labelhft_sinif14.Text, labelhft_sinif15.Text, labelhft_blm11.Text, labelhft_blm12.Text, labelhft_blm13.Text, labelhft_blm14.Text, labelhft_blm15.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun11.Text, cbhft_pzrt11.Text, cbhft_sali11.Text, cbhft_crsmba11.Text, cbhft_prsmbe11.Text, cbhft_cuma11.Text, labelhft_sinif16.Text, labelhft_sinif17.Text, labelhft_sinif18.Text, labelhft_sinif19.Text, labelhft_sinif20.Text, labelhft_blm16.Text, labelhft_blm17.Text, labelhft_blm18.Text, labelhft_blm19.Text, labelhft_blm20.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun12.Text, cbhft_pzrt12.Text, cbhft_sali12.Text, cbhft_crsmba12.Text, cbhft_prsmbe12.Text, cbhft_cuma12.Text, labelhft_sinif21.Text, labelhft_sinif22.Text, labelhft_sinif23.Text, labelhft_sinif24.Text, labelhft_sinif25.Text, labelhft_blm21.Text, labelhft_blm22.Text, labelhft_blm23.Text, labelhft_blm24.Text, labelhft_blm25.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun13.Text, cbhft_pzrt13.Text, cbhft_sali13.Text, cbhft_crsmba13.Text, cbhft_prsmbe13.Text, cbhft_cuma13.Text, labelhft_sinif26.Text, labelhft_sinif27.Text, labelhft_sinif28.Text, labelhft_sinif29.Text, labelhft_sinif30.Text, labelhft_blm26.Text, labelhft_blm27.Text, labelhft_blm28.Text, labelhft_blm29.Text, labelhft_blm30.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun14.Text, cbhft_pzrt14.Text, cbhft_sali14.Text, cbhft_crsmba14.Text, cbhft_prsmbe14.Text, cbhft_cuma14.Text, labelhft_sinif31.Text, labelhft_sinif32.Text, labelhft_sinif33.Text, labelhft_sinif34.Text, labelhft_sinif35.Text, labelhft_blm31.Text, labelhft_blm32.Text, labelhft_blm33.Text, labelhft_blm34.Text, labelhft_blm35.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun15.Text, cbhft_pzrt15.Text, cbhft_sali15.Text, cbhft_crsmba15.Text, cbhft_prsmbe15.Text, cbhft_cuma15.Text, labelhft_sinif36.Text, labelhft_sinif37.Text, labelhft_sinif38.Text, labelhft_sinif39.Text, labelhft_sinif40.Text, labelhft_blm36.Text, labelhft_blm37.Text, labelhft_blm38.Text, labelhft_blm39.Text, labelhft_blm40.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun16.Text, cbhft_pzrt16.Text, cbhft_sali16.Text, cbhft_crsmba16.Text, cbhft_prsmbe16.Text, cbhft_cuma16.Text, labelhft_sinif41.Text, labelhft_sinif42.Text, labelhft_sinif43.Text, labelhft_sinif44.Text, labelhft_sinif45.Text, labelhft_blm41.Text, labelhft_blm42.Text, labelhft_blm43.Text, labelhft_blm44.Text, labelhft_blm45.Text);
                    fazlasatir(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun17.Text, cbhft_pzrt17.Text, cbhft_sali17.Text, cbhft_crsmba17.Text, cbhft_prsmbe17.Text, cbhft_cuma17.Text, labelhft_sinif46.Text, labelhft_sinif47.Text, labelhft_sinif48.Text, labelhft_sinif49.Text, labelhft_sinif50.Text, labelhft_blm46.Text, labelhft_blm47.Text, labelhft_blm48.Text, labelhft_blm49.Text, labelhft_blm50.Text);

                    MessageBox.Show("Kayit Eklendi");

                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hatali " + hata.Message);
                }
            }
        
            KisiListele();

          
        }

        private void guncel(string a, string b, string c, string d, string e, string f, string g, string lbls1, string lbls2, string lbls3, string lbls4, string lbls5, string lblb1, string lblb2, string lblb3, string lblb4, string lblb5)
        {
            baglanti.Open();
            SqlCommand commanddersko = new SqlCommand("Select adi,sinifi,bolum From dersler", baglanti);
            SqlDataReader drdersko = commanddersko.ExecuteReader();
            int giris = 0;
            while (drdersko.Read())
            {
                if (drdersko[0].ToString() == c.ToString())
                {
                    giris = 1;  
                    lbls1 = drdersko[1].ToString();     
                    lblb1 = drdersko[2].ToString();
                }
                else
                {
                    if(giris == 0)
                    {
                        lbls1 = "";
                        lblb1 = "";
                    }
                 
                }
              
                if (drdersko[0].ToString() == d.ToString())
                {
                    giris = 1;
                    lbls2 = drdersko[1].ToString();     
                        lblb2 = drdersko[2].ToString();
                }
                else
                {
                    if (giris == 0)
                    {
                        lbls2 = "";
                        lblb2 = "";
                    }
                }
               
                if (drdersko[0].ToString() == e.ToString())
                {
                    giris = 1;
                    lbls3 = drdersko[1].ToString();
                    lblb3 = drdersko[2].ToString();
                }
                else
                {
                    if (giris == 0)
                    {
                        lbls3 = "";
                        lblb3 = "";
                    }
                }
             
                if (drdersko[0].ToString() == f.ToString())
                {
                    giris = 1;
                    lbls4 = drdersko[1].ToString();
                    lblb4 = drdersko[2].ToString();
                }
                else
                {
                    if (giris == 0)
                    {
                        lbls4 = "";
                        lblb4 = "";
                    }
                }
             
                if (drdersko[0].ToString() == g.ToString())
                {
                    giris = 1;
                    lbls5 = drdersko[1].ToString();
                    lblb5 = drdersko[2].ToString();
                }
                else
                {
                    if (giris == 0)
                    {
                        lbls5 = "";
                        lblb5 = "";
                    }
                }
               
            }
            baglanti.Close();




            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string kayitguncelle = ("Update haftalikdersogretmen Set saat = @saat, sinif1 = @sinif1, bolum1 = @bolum1, pazartesi = @pazartesi, sinif2 = @sinif2, bolum2 = @bolum2, sali = @sali, sinif3 = @sinif3, bolum3 = @bolum3, carsamba = @carsamba, sinif4 = @sinif4, bolum4 = @bolum4, persembe = @persembe, sinif5 = @sinif5, bolum5 = @bolum5, cuma = @cuma Where tc = @tc and saat = @saat");

            SqlCommand komut = new SqlCommand(kayitguncelle, baglanti);
            komut.Parameters.AddWithValue("@tc", a);
            komut.Parameters.AddWithValue("@saat", b);
            komut.Parameters.AddWithValue("@sinif1", lbls1);
            komut.Parameters.AddWithValue("@bolum1", lblb1);
            komut.Parameters.AddWithValue("@pazartesi", c);
            komut.Parameters.AddWithValue("@sinif2", lbls2);
            komut.Parameters.AddWithValue("@bolum2", lblb2);
            komut.Parameters.AddWithValue("@sali", d);
            komut.Parameters.AddWithValue("@sinif3", lbls3);
            komut.Parameters.AddWithValue("@bolum3", lblb3);
            komut.Parameters.AddWithValue("@carsamba", e);
            komut.Parameters.AddWithValue("@sinif4", lbls4);
            komut.Parameters.AddWithValue("@bolum4", lblb4);
            komut.Parameters.AddWithValue("@persembe", f);
            komut.Parameters.AddWithValue("@sinif5", lbls5);
            komut.Parameters.AddWithValue("@bolum5", lblb5);
            komut.Parameters.AddWithValue("@cuma", g);

            komut.ExecuteNonQuery();
            baglanti.Close();


        }
    public void dersogrenciguncelle(string a,string b,string c, string d, string e,string f, string g, string h)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string kayitguncelle = ("Update haftalikdersogrenci Set saat = @saat, pazartesi = @pazartesi, sali = @sali, carsamba = @carsamba, persembe = @persembe, cuma = @cuma Where bolum = @bolum and sinif = @sinif and saat = @saat");
            SqlCommand komut = new SqlCommand(kayitguncelle, baglanti);
            komut.Parameters.AddWithValue("@bolum", a);
            komut.Parameters.AddWithValue("@sinif", b);
            komut.Parameters.AddWithValue("@saat", c);
            komut.Parameters.AddWithValue("@pazartesi", d);
            komut.Parameters.AddWithValue("@sali", e);
            komut.Parameters.AddWithValue("@carsamba", f);
            komut.Parameters.AddWithValue("@persembe", g);
            komut.Parameters.AddWithValue("@cuma", h);

            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void pictureBoxdpogr_kaydet_Click(object sender, EventArgs e)
        {

            try
            {

                guncel(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun08.Text, cbhft_pzrt08.Text, cbhft_sali08.Text, cbhft_crsmba08.Text, cbhft_prsmbe08.Text, cbhft_cuma08.Text, labelhft_sinif1.Text, labelhft_sinif2.Text, labelhft_sinif3.Text, labelhft_sinif4.Text, labelhft_sinif5.Text, labelhft_blm1.Text, labelhft_blm2.Text, labelhft_blm3.Text, labelhft_blm4.Text, labelhft_blm5.Text);
                guncel(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun09.Text, cbhft_pzrt09.Text, cbhft_sali09.Text, cbhft_crsmba09.Text, cbhft_prsmbe09.Text, cbhft_cuma09.Text, labelhft_sinif6.Text, labelhft_sinif7.Text, labelhft_sinif8.Text, labelhft_sinif9.Text, labelhft_sinif10.Text, labelhft_blm6.Text, labelhft_blm7.Text, labelhft_blm8.Text, labelhft_blm9.Text, labelhft_blm10.Text);
                guncel(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun10.Text, cbhft_pzrt10.Text, cbhft_sali10.Text, cbhft_crsmba10.Text, cbhft_prsmbe10.Text, cbhft_cuma10.Text, labelhft_sinif11.Text, labelhft_sinif12.Text, labelhft_sinif13.Text, labelhft_sinif14.Text, labelhft_sinif15.Text, labelhft_blm11.Text, labelhft_blm12.Text, labelhft_blm13.Text, labelhft_blm14.Text, labelhft_blm15.Text);
                guncel(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun11.Text, cbhft_pzrt11.Text, cbhft_sali11.Text, cbhft_crsmba11.Text, cbhft_prsmbe11.Text, cbhft_cuma11.Text, labelhft_sinif16.Text, labelhft_sinif17.Text, labelhft_sinif18.Text, labelhft_sinif19.Text, labelhft_sinif20.Text, labelhft_blm16.Text, labelhft_blm17.Text, labelhft_blm18.Text, labelhft_blm19.Text, labelhft_blm20.Text);
                guncel(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun12.Text, cbhft_pzrt12.Text, cbhft_sali12.Text, cbhft_crsmba12.Text, cbhft_prsmbe12.Text, cbhft_cuma12.Text, labelhft_sinif21.Text, labelhft_sinif22.Text, labelhft_sinif23.Text, labelhft_sinif24.Text, labelhft_sinif25.Text, labelhft_blm21.Text, labelhft_blm22.Text, labelhft_blm23.Text, labelhft_blm24.Text, labelhft_blm25.Text);
                guncel(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun13.Text, cbhft_pzrt13.Text, cbhft_sali13.Text, cbhft_crsmba13.Text, cbhft_prsmbe13.Text, cbhft_cuma13.Text, labelhft_sinif26.Text, labelhft_sinif27.Text, labelhft_sinif28.Text, labelhft_sinif29.Text, labelhft_sinif30.Text, labelhft_blm26.Text, labelhft_blm27.Text, labelhft_blm28.Text, labelhft_blm29.Text, labelhft_blm30.Text);
                guncel(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun14.Text, cbhft_pzrt14.Text, cbhft_sali14.Text, cbhft_crsmba14.Text, cbhft_prsmbe14.Text, cbhft_cuma14.Text, labelhft_sinif31.Text, labelhft_sinif32.Text, labelhft_sinif33.Text, labelhft_sinif34.Text, labelhft_sinif35.Text, labelhft_blm31.Text, labelhft_blm32.Text, labelhft_blm33.Text, labelhft_blm34.Text, labelhft_blm35.Text);
                guncel(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun15.Text, cbhft_pzrt15.Text, cbhft_sali15.Text, cbhft_crsmba15.Text, cbhft_prsmbe15.Text, cbhft_cuma15.Text, labelhft_sinif36.Text, labelhft_sinif37.Text, labelhft_sinif38.Text, labelhft_sinif39.Text, labelhft_sinif40.Text, labelhft_blm36.Text, labelhft_blm37.Text, labelhft_blm38.Text, labelhft_blm39.Text, labelhft_blm40.Text);
                guncel(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun16.Text, cbhft_pzrt16.Text, cbhft_sali16.Text, cbhft_crsmba16.Text, cbhft_prsmbe16.Text, cbhft_cuma16.Text, labelhft_sinif41.Text, labelhft_sinif42.Text, labelhft_sinif43.Text, labelhft_sinif44.Text, labelhft_sinif45.Text, labelhft_blm41.Text, labelhft_blm42.Text, labelhft_blm43.Text, labelhft_blm44.Text, labelhft_blm45.Text);
                guncel(dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(), cbhft_gun17.Text, cbhft_pzrt17.Text, cbhft_sali17.Text, cbhft_crsmba17.Text, cbhft_prsmbe17.Text, cbhft_cuma17.Text, labelhft_sinif46.Text, labelhft_sinif47.Text, labelhft_sinif48.Text, labelhft_sinif49.Text, labelhft_sinif50.Text, labelhft_blm46.Text, labelhft_blm47.Text, labelhft_blm48.Text, labelhft_blm49.Text, labelhft_blm50.Text);
                MessageBox.Show("Kayit Düzenlendi");

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hatali " + hata.Message);
            }


            KisiListele();
        }
        private void sil(string a, int s, string bg, string ag,string mg)
        {
            string sil = a;
            SqlCommand komut = new SqlCommand(sil, baglanti);
            baglanti.Open();
            komut.Parameters.AddWithValue("@tc", ag);
            komut.Parameters.AddWithValue("@saat", bg);
            if(s==1)
                komut.Parameters.AddWithValue("@sinif", mg);

            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void pictureBoxdpogr_sil_Click(object sender, EventArgs e)
        {
            sil("Delete From haftalikdersogretmen Where tc = @tc and saat = @saat",0, cbhft_gun08.Text, dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(),"");
            sil("Delete From haftalikdersogretmen Where tc = @tc and saat = @saat",0, cbhft_gun09.Text, dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(),"");
            sil("Delete From haftalikdersogretmen Where tc = @tc and saat = @saat",0, cbhft_gun10.Text, dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(),"");
            sil("Delete From haftalikdersogretmen Where tc = @tc and saat = @saat",0, cbhft_gun11.Text, dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(),"");
            sil("Delete From haftalikdersogretmen Where tc = @tc and saat = @saat",0, cbhft_gun12.Text, dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(),"");
            sil("Delete From haftalikdersogretmen Where tc = @tc and saat = @saat",0, cbhft_gun13.Text, dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(),"");
            sil("Delete From haftalikdersogretmen Where tc = @tc and saat = @saat",0, cbhft_gun14.Text, dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(),"");
            sil("Delete From haftalikdersogretmen Where tc = @tc and saat = @saat",0, cbhft_gun15.Text, dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(),"");
            sil("Delete From haftalikdersogretmen Where tc = @tc and saat = @saat",0, cbhft_gun16.Text, dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(),"");
            sil("Delete From haftalikdersogretmen Where tc = @tc and saat = @saat",0, cbhft_gun17.Text, dtdrsp_ogretmen.CurrentRow.Cells[2].Value.ToString(),"");
            MessageBox.Show("Kayit Silindi");
            KisiListele();
        }

        private void cbdrspo_blm_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbdrspo_snf.Text = "";
            cbdrspo_snf.Items.Clear();
            baglanti.Open();
            SqlCommand commandblm = new SqlCommand("Select * From bolumler", baglanti);
            SqlDataReader drblm = commandblm.ExecuteReader();

            while (drblm.Read())
            {
                if (drblm[0].ToString() == cbdrspo_blm.SelectedItem.ToString())
                    for (int i = 0; i < Convert.ToInt32(drblm[1].ToString()); i++)
                    {
                        cbdrspo_snf.Items.Add(i + 1);
                    }
            }
            baglanti.Close();

           
        }
        private void ogrencihaftalikgetir(string a, ComboBox b1, ComboBox b2, ComboBox b3, ComboBox b4, ComboBox b5, ComboBox b6, ComboBox b7, ComboBox b8, ComboBox b9, ComboBox b10)
        {
            b1.Enabled = true;
            b2.Enabled = true;
            b3.Enabled = true;
            b4.Enabled = true;
            b5.Enabled = true;
            b6.Enabled = true;
            b7.Enabled = true;
            b8.Enabled = true;
            b9.Enabled = true;
            b10.Enabled = true;
           
                        baglanti.Open();
                        //"Select saat, sinif1, bolum1, pazartesi from haftalikdersogretmen where sinif1 != '' "
                        SqlCommand commandblmpzr = new SqlCommand(a, baglanti);
                        SqlDataReader drblmpzr = commandblmpzr.ExecuteReader();
                        while (drblmpzr.Read())
                        {
                            if (drblmpzr[1].ToString() == cbdrspo_snf.SelectedItem.ToString() && drblmpzr[2].ToString() == cbdrspo_blm.SelectedItem.ToString())
                            {

                                if (drblmpzr[0].ToString() == cbhftogr_gun08.Text)
                                {
                                    b1.Items.Add(drblmpzr[3].ToString());
                                    b1.SelectedIndex = 0;
                                    b1.Text = drblmpzr[3].ToString();

                                    b1.Enabled = false;
                                }

                                if (drblmpzr[0].ToString() == cbhftogr_gun09.Text)
                                {
                                    b2.Items.Add(drblmpzr[3].ToString());
                                    b2.SelectedIndex = 0;
                                    b2.Text = drblmpzr[3].ToString();

                                    b2.Enabled = false;
                                }


                                if (drblmpzr[0].ToString() == cbhftogr_gun10.Text)
                                {

                                    b3.Items.Add(drblmpzr[3].ToString());
                                    b3.SelectedIndex = 0;
                                    b3.Text = drblmpzr[3].ToString();


                                    b3.Enabled = false;
                                }

                                if (drblmpzr[0].ToString() == cbhftogr_gun11.Text)
                                {
                                    b4.Items.Add(drblmpzr[3].ToString());
                                    b4.SelectedIndex = 0;
                                    b4.Text = drblmpzr[3].ToString();

                                    b4.Enabled = false;
                                }

                                if (drblmpzr[0].ToString() == cbhftogr_gun12.Text)
                                {
                                    b5.Items.Add(drblmpzr[3].ToString());
                                    b5.SelectedIndex = 0;
                                    b5.Text = drblmpzr[3].ToString();

                                    b5.Enabled = false;
                                }

                                if (drblmpzr[0].ToString() == cbhftogr_gun13.Text)
                                {
                                    b6.Items.Add(drblmpzr[3].ToString());
                                    b6.SelectedIndex = 0;
                                    b6.Text = drblmpzr[3].ToString();

                                    b6.Enabled = false;
                                }

                                if (drblmpzr[0].ToString() == cbhftogr_gun14.Text)
                                {
                                    b7.Items.Add(drblmpzr[3].ToString());
                                    b7.SelectedIndex = 0;
                                    b7.Text = drblmpzr[3].ToString();

                                    b7.Enabled = false;
                                }

                                if (drblmpzr[0].ToString() == cbhftogr_gun15.Text)
                                {
                                    b8.Items.Add(drblmpzr[3].ToString());
                                    b8.SelectedIndex = 0;
                                    b8.Text = drblmpzr[3].ToString();

                                    b8.Enabled = false;
                                }

                                if (drblmpzr[0].ToString() == cbhftogr_gun16.Text)
                                {
                                    b9.Items.Add(drblmpzr[3].ToString());
                                    b9.SelectedIndex = 0;
                                    b9.Text = drblmpzr[3].ToString();

                                    b9.Enabled = false;
                                }

                                if (drblmpzr[0].ToString() == cbhftogr_gun17.Text)
                                {
                                    b10.Items.Add(drblmpzr[3].ToString());
                                    b10.SelectedIndex = 0;
                                    b10.Text = drblmpzr[3].ToString();

                                    b10.Enabled = false;
                                }


                            }
                        }
                        baglanti.Close();
                    

        }
        public void ortakekle()
        {

            cbhftogr_pzrt08.Items.Add("");
            cbhftogr_pzrt09.Items.Add("");
            cbhftogr_pzrt10.Items.Add("");
            cbhftogr_pzrt11.Items.Add("");
            cbhftogr_pzrt12.Items.Add("");
            cbhftogr_pzrt13.Items.Add("");
            cbhftogr_pzrt14.Items.Add("");
            cbhftogr_pzrt15.Items.Add("");
            cbhftogr_pzrt16.Items.Add("");
            cbhftogr_pzrt17.Items.Add("");

            cbhftogr_sali08.Items.Add("");
            cbhftogr_sali09.Items.Add("");
            cbhftogr_sali10.Items.Add("");
            cbhftogr_sali11.Items.Add("");
            cbhftogr_sali12.Items.Add("");
            cbhftogr_sali13.Items.Add("");
            cbhftogr_sali14.Items.Add("");
            cbhftogr_sali15.Items.Add("");
            cbhftogr_sali16.Items.Add("");
            cbhftogr_sali17.Items.Add("");

            cbhftogr_crsmba08.Items.Add("");
            cbhftogr_crsmba09.Items.Add("");
            cbhftogr_crsmba10.Items.Add("");
            cbhftogr_crsmba11.Items.Add("");
            cbhftogr_crsmba12.Items.Add("");
            cbhftogr_crsmba13.Items.Add("");
            cbhftogr_crsmba14.Items.Add("");
            cbhftogr_crsmba15.Items.Add("");
            cbhftogr_crsmba16.Items.Add("");
            cbhftogr_crsmba17.Items.Add("");

            cbhftogr_prsmbe08.Items.Add("");
            cbhftogr_prsmbe09.Items.Add("");
            cbhftogr_prsmbe10.Items.Add("");
            cbhftogr_prsmbe11.Items.Add("");
            cbhftogr_prsmbe12.Items.Add("");
            cbhftogr_prsmbe13.Items.Add("");
            cbhftogr_prsmbe14.Items.Add("");
            cbhftogr_prsmbe15.Items.Add("");
            cbhftogr_prsmbe16.Items.Add("");
            cbhftogr_prsmbe17.Items.Add("");

            cbhftogr_cuma08.Items.Add("");
            cbhftogr_cuma09.Items.Add("");
            cbhftogr_cuma10.Items.Add("");
            cbhftogr_cuma11.Items.Add("");
            cbhftogr_cuma12.Items.Add("");
            cbhftogr_cuma13.Items.Add("");
            cbhftogr_cuma14.Items.Add("");
            cbhftogr_cuma15.Items.Add("");
            cbhftogr_cuma16.Items.Add("");
            cbhftogr_cuma17.Items.Add("");

            baglanti.Open();
            SqlCommand commandblmd = new SqlCommand("Select * From dersler where bolum = 'Ortak Ders'", baglanti);
            SqlDataReader drblmd = commandblmd.ExecuteReader();

            while (drblmd.Read())
            {
                cbhftogr_pzrt08.Items.Add(drblmd[0].ToString());
                cbhftogr_pzrt09.Items.Add(drblmd[0].ToString());
                cbhftogr_pzrt10.Items.Add(drblmd[0].ToString());
                cbhftogr_pzrt11.Items.Add(drblmd[0].ToString());
                cbhftogr_pzrt12.Items.Add(drblmd[0].ToString());
                cbhftogr_pzrt13.Items.Add(drblmd[0].ToString());
                cbhftogr_pzrt14.Items.Add(drblmd[0].ToString());
                cbhftogr_pzrt15.Items.Add(drblmd[0].ToString());
                cbhftogr_pzrt16.Items.Add(drblmd[0].ToString());
                cbhftogr_pzrt17.Items.Add(drblmd[0].ToString());

                cbhftogr_sali08.Items.Add(drblmd[0].ToString());
                cbhftogr_sali09.Items.Add(drblmd[0].ToString());
                cbhftogr_sali10.Items.Add(drblmd[0].ToString());
                cbhftogr_sali11.Items.Add(drblmd[0].ToString());
                cbhftogr_sali12.Items.Add(drblmd[0].ToString());
                cbhftogr_sali13.Items.Add(drblmd[0].ToString());
                cbhftogr_sali14.Items.Add(drblmd[0].ToString());
                cbhftogr_sali15.Items.Add(drblmd[0].ToString());
                cbhftogr_sali16.Items.Add(drblmd[0].ToString());
                cbhftogr_sali17.Items.Add(drblmd[0].ToString());

                cbhftogr_crsmba08.Items.Add(drblmd[0].ToString());
                cbhftogr_crsmba09.Items.Add(drblmd[0].ToString());
                cbhftogr_crsmba10.Items.Add(drblmd[0].ToString());
                cbhftogr_crsmba11.Items.Add(drblmd[0].ToString());
                cbhftogr_crsmba12.Items.Add(drblmd[0].ToString());
                cbhftogr_crsmba13.Items.Add(drblmd[0].ToString());
                cbhftogr_crsmba14.Items.Add(drblmd[0].ToString());
                cbhftogr_crsmba15.Items.Add(drblmd[0].ToString());
                cbhftogr_crsmba16.Items.Add(drblmd[0].ToString());
                cbhftogr_crsmba17.Items.Add(drblmd[0].ToString());

                cbhftogr_prsmbe08.Items.Add(drblmd[0].ToString());
                cbhftogr_prsmbe09.Items.Add(drblmd[0].ToString());
                cbhftogr_prsmbe10.Items.Add(drblmd[0].ToString());
                cbhftogr_prsmbe11.Items.Add(drblmd[0].ToString());
                cbhftogr_prsmbe12.Items.Add(drblmd[0].ToString());
                cbhftogr_prsmbe13.Items.Add(drblmd[0].ToString());
                cbhftogr_prsmbe14.Items.Add(drblmd[0].ToString());
                cbhftogr_prsmbe15.Items.Add(drblmd[0].ToString());
                cbhftogr_prsmbe16.Items.Add(drblmd[0].ToString());
                cbhftogr_prsmbe17.Items.Add(drblmd[0].ToString());

                cbhftogr_cuma08.Items.Add(drblmd[0].ToString());
                cbhftogr_cuma09.Items.Add(drblmd[0].ToString());
                cbhftogr_cuma10.Items.Add(drblmd[0].ToString());
                cbhftogr_cuma11.Items.Add(drblmd[0].ToString());
                cbhftogr_cuma12.Items.Add(drblmd[0].ToString());
                cbhftogr_cuma13.Items.Add(drblmd[0].ToString());
                cbhftogr_cuma14.Items.Add(drblmd[0].ToString());
                cbhftogr_cuma15.Items.Add(drblmd[0].ToString());
                cbhftogr_cuma16.Items.Add(drblmd[0].ToString());
                cbhftogr_cuma17.Items.Add(drblmd[0].ToString());

            }
            baglanti.Close();

        }
        public void ogrsil()
        {
            cbhftogr_pzrt08.Items.Clear();
            cbhftogr_pzrt09.Items.Clear();
            cbhftogr_pzrt10.Items.Clear();
            cbhftogr_pzrt11.Items.Clear();
            cbhftogr_pzrt12.Items.Clear();
            cbhftogr_pzrt13.Items.Clear();
            cbhftogr_pzrt14.Items.Clear();
            cbhftogr_pzrt15.Items.Clear();
            cbhftogr_pzrt16.Items.Clear();
            cbhftogr_pzrt17.Items.Clear();

            cbhftogr_sali08.Items.Clear();
            cbhftogr_sali09.Items.Clear();
            cbhftogr_sali10.Items.Clear();
            cbhftogr_sali11.Items.Clear();
            cbhftogr_sali12.Items.Clear();
            cbhftogr_sali13.Items.Clear();
            cbhftogr_sali14.Items.Clear();
            cbhftogr_sali15.Items.Clear();
            cbhftogr_sali16.Items.Clear();
            cbhftogr_sali17.Items.Clear();

            cbhftogr_crsmba08.Items.Clear();
            cbhftogr_crsmba09.Items.Clear();
            cbhftogr_crsmba10.Items.Clear();
            cbhftogr_crsmba11.Items.Clear();
            cbhftogr_crsmba12.Items.Clear();
            cbhftogr_crsmba13.Items.Clear();
            cbhftogr_crsmba14.Items.Clear();
            cbhftogr_crsmba15.Items.Clear();
            cbhftogr_crsmba16.Items.Clear();
            cbhftogr_crsmba17.Items.Clear();

            cbhftogr_prsmbe08.Items.Clear();
            cbhftogr_prsmbe09.Items.Clear();
            cbhftogr_prsmbe10.Items.Clear();
            cbhftogr_prsmbe11.Items.Clear();
            cbhftogr_prsmbe12.Items.Clear();
            cbhftogr_prsmbe13.Items.Clear();
            cbhftogr_prsmbe14.Items.Clear();
            cbhftogr_prsmbe15.Items.Clear();
            cbhftogr_prsmbe16.Items.Clear();
            cbhftogr_prsmbe17.Items.Clear();

            cbhftogr_cuma08.Items.Clear();
            cbhftogr_cuma09.Items.Clear();
            cbhftogr_cuma10.Items.Clear();
            cbhftogr_cuma11.Items.Clear();
            cbhftogr_cuma12.Items.Clear();
            cbhftogr_cuma13.Items.Clear();
            cbhftogr_cuma14.Items.Clear();
            cbhftogr_cuma15.Items.Clear();
            cbhftogr_cuma16.Items.Clear();
            cbhftogr_cuma17.Items.Clear();
        }
        private void ogrencihaftalikdersekle(string a, string b, string c, string d, string e, string f, string g, string h)
        {


            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string kayit = "insert into haftalikdersogrenci (bolum,sinif,saat,pazartesi,sali,carsamba,persembe,cuma) values(@bolum,@sinif,@saat,@pazartesi,@sali,@carsamba,@persembe,@cuma)";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@bolum", a);
            komut.Parameters.AddWithValue("@sinif", b);
            komut.Parameters.AddWithValue("@saat", c);
            komut.Parameters.AddWithValue("@pazartesi", d);
            komut.Parameters.AddWithValue("@sali", e);
            komut.Parameters.AddWithValue("@carsamba", f);
            komut.Parameters.AddWithValue("@persembe", g);
            komut.Parameters.AddWithValue("@cuma", h);

            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        private void ogrencihaftalikdersguncelle(string a, string b, string c, string d, string e, string f, string g, string h)
        {


            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string kayitguncelle = ("Update haftalikdersogrenci Set saat = @saat, pazartesi = @pazartesi, sali = @sali, carsamba = @carsamba, persembe = @persembe, cuma = @cuma Where bolum = @bolum and sinif = @sinif and saat = @saat");
            SqlCommand komut = new SqlCommand(kayitguncelle, baglanti);
            komut.Parameters.AddWithValue("@bolum", a);
            komut.Parameters.AddWithValue("@sinif", b);
            komut.Parameters.AddWithValue("@saat", c);
            komut.Parameters.AddWithValue("@pazartesi", d);
            komut.Parameters.AddWithValue("@sali", e);
            komut.Parameters.AddWithValue("@carsamba", f);
            komut.Parameters.AddWithValue("@persembe", g);
            komut.Parameters.AddWithValue("@cuma", h);

            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        public void secilihaldegetir(int a,ComboBox b1, ComboBox b2, ComboBox b3, ComboBox b4, ComboBox b5, ComboBox b6, ComboBox b7, ComboBox b8, ComboBox b9, ComboBox b10)
        {
          
                    
                        baglanti.Open();
                        SqlCommand commanddersk = new SqlCommand("Select * From haftalikdersogrenci", baglanti);
                        SqlDataReader drdersk = commanddersk.ExecuteReader();

                        while (drdersk.Read())
                        {

                            if (cbdrspo_blm.SelectedItem.ToString() == drdersk[0].ToString() && cbdrspo_snf.SelectedItem.ToString() == drdersk[1].ToString())
                            {
                                if (drdersk[2].ToString() == cbhftogr_gun08.Text)
                                {
                                    b1.Text = drdersk[a].ToString();



                                }

                                if (drdersk[2].ToString() == cbhftogr_gun09.Text)
                                {
                                    b2.Text = drdersk[a].ToString();

                                }


                                if (drdersk[2].ToString() == cbhftogr_gun10.Text)
                                {

                                    b3.Text = drdersk[a].ToString();


                                }

                                if (drdersk[2].ToString() == cbhftogr_gun11.Text)
                                {
                                    b4.Text = drdersk[a].ToString();


                                }

                                if (drdersk[2].ToString() == cbhftogr_gun12.Text)
                                {
                                    b5.Text = drdersk[a].ToString();


                                }

                                if (drdersk[2].ToString() == cbhftogr_gun13.Text)
                                {
                                    b6.Text = drdersk[a].ToString();


                                }

                                if (drdersk[2].ToString() == cbhftogr_gun14.Text)
                                {
                                    b7.Text = drdersk[a].ToString();


                                }

                                if (drdersk[2].ToString() == cbhftogr_gun15.Text)
                                {
                                    b8.Text = drdersk[a].ToString();


                                }

                                if (drdersk[2].ToString() == cbhftogr_gun16.Text)
                                {
                                    b9.Text = drdersk[a].ToString();


                                }

                                if (drdersk[2].ToString() == cbhftogr_gun17.Text)
                                {
                                    b10.Text = drdersk[a].ToString();


                                }

                            }


                        }
                        baglanti.Close();
                    
        }
        private void cbdrspo_snf_SelectedIndexChanged(object sender, EventArgs e)
        {



            ogrsil();

            ortakekle();
            secilihaldegetir(3, cbhftogr_pzrt08, cbhftogr_pzrt09, cbhftogr_pzrt10, cbhftogr_pzrt11, cbhftogr_pzrt12, cbhftogr_pzrt13, cbhftogr_pzrt14, cbhftogr_pzrt15, cbhftogr_pzrt16, cbhftogr_pzrt17);
            secilihaldegetir(4, cbhftogr_sali08, cbhftogr_sali09, cbhftogr_sali10, cbhftogr_sali11, cbhftogr_sali12, cbhftogr_sali13, cbhftogr_sali14, cbhftogr_sali15, cbhftogr_sali16, cbhftogr_sali17);
            secilihaldegetir(5, cbhftogr_crsmba08, cbhftogr_crsmba09, cbhftogr_crsmba10, cbhftogr_crsmba11, cbhftogr_crsmba12, cbhftogr_crsmba13, cbhftogr_crsmba14, cbhftogr_crsmba15, cbhftogr_crsmba16, cbhftogr_crsmba17);
            secilihaldegetir(6, cbhftogr_prsmbe08, cbhftogr_prsmbe09, cbhftogr_prsmbe10, cbhftogr_prsmbe11, cbhftogr_prsmbe12, cbhftogr_prsmbe13, cbhftogr_prsmbe14, cbhftogr_prsmbe15, cbhftogr_prsmbe16, cbhftogr_prsmbe17);
            secilihaldegetir(7, cbhftogr_cuma08, cbhftogr_cuma09, cbhftogr_cuma10, cbhftogr_cuma11, cbhftogr_cuma12, cbhftogr_cuma13, cbhftogr_cuma14, cbhftogr_cuma15, cbhftogr_cuma16, cbhftogr_cuma17);
            
            ogrencihaftalikgetir("Select saat, sinif1, bolum1, pazartesi from haftalikdersogretmen where sinif1 != '' ", cbhftogr_pzrt08, cbhftogr_pzrt09, cbhftogr_pzrt10, cbhftogr_pzrt11, cbhftogr_pzrt12, cbhftogr_pzrt13, cbhftogr_pzrt14, cbhftogr_pzrt15, cbhftogr_pzrt16, cbhftogr_pzrt17);
            ogrencihaftalikgetir("Select saat, sinif2, bolum2, sali from haftalikdersogretmen where sinif2 != '' ", cbhftogr_sali08, cbhftogr_sali09, cbhftogr_sali10, cbhftogr_sali11, cbhftogr_sali12, cbhftogr_sali13, cbhftogr_sali14, cbhftogr_sali15, cbhftogr_sali16, cbhftogr_sali17);
            ogrencihaftalikgetir("Select saat, sinif3, bolum3, carsamba from haftalikdersogretmen where sinif3 != '' ", cbhftogr_crsmba08, cbhftogr_crsmba09, cbhftogr_crsmba10, cbhftogr_crsmba11, cbhftogr_crsmba12, cbhftogr_crsmba13, cbhftogr_crsmba14, cbhftogr_crsmba15, cbhftogr_crsmba16, cbhftogr_crsmba17);
            ogrencihaftalikgetir("Select saat, sinif4, bolum4, persembe from haftalikdersogretmen where sinif4 != '' ", cbhftogr_prsmbe08, cbhftogr_prsmbe09, cbhftogr_prsmbe10, cbhftogr_prsmbe11, cbhftogr_prsmbe12, cbhftogr_prsmbe13, cbhftogr_prsmbe14, cbhftogr_prsmbe15, cbhftogr_prsmbe16, cbhftogr_prsmbe17);
            ogrencihaftalikgetir("Select saat, sinif5, bolum5, cuma from haftalikdersogretmen where sinif5 != '' ", cbhftogr_cuma08, cbhftogr_cuma09, cbhftogr_cuma10, cbhftogr_cuma11, cbhftogr_cuma12, cbhftogr_cuma13, cbhftogr_cuma14, cbhftogr_cuma15, cbhftogr_cuma16, cbhftogr_cuma17);

         
                try
                {
                    ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun08.Text, cbhftogr_pzrt08.Text, cbhftogr_sali08.Text, cbhftogr_crsmba08.Text, cbhftogr_prsmbe08.Text, cbhftogr_cuma08.Text);
                    ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun09.Text, cbhftogr_pzrt09.Text, cbhftogr_sali09.Text, cbhftogr_crsmba09.Text, cbhftogr_prsmbe09.Text, cbhftogr_cuma09.Text);
                    ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun10.Text, cbhftogr_pzrt10.Text, cbhftogr_sali10.Text, cbhftogr_crsmba10.Text, cbhftogr_prsmbe10.Text, cbhftogr_cuma10.Text);
                    ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun11.Text, cbhftogr_pzrt11.Text, cbhftogr_sali11.Text, cbhftogr_crsmba11.Text, cbhftogr_prsmbe11.Text, cbhftogr_cuma11.Text);
                    ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun12.Text, cbhftogr_pzrt12.Text, cbhftogr_sali12.Text, cbhftogr_crsmba12.Text, cbhftogr_prsmbe12.Text, cbhftogr_cuma12.Text);
                    ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun13.Text, cbhftogr_pzrt13.Text, cbhftogr_sali13.Text, cbhftogr_crsmba13.Text, cbhftogr_prsmbe13.Text, cbhftogr_cuma13.Text);
                    ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun14.Text, cbhftogr_pzrt14.Text, cbhftogr_sali14.Text, cbhftogr_crsmba14.Text, cbhftogr_prsmbe14.Text, cbhftogr_cuma14.Text);
                    ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun15.Text, cbhftogr_pzrt15.Text, cbhftogr_sali15.Text, cbhftogr_crsmba15.Text, cbhftogr_prsmbe15.Text, cbhftogr_cuma15.Text);
                    ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun16.Text, cbhftogr_pzrt16.Text, cbhftogr_sali16.Text, cbhftogr_crsmba16.Text, cbhftogr_prsmbe16.Text, cbhftogr_cuma16.Text);
                    ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun17.Text, cbhftogr_pzrt17.Text, cbhftogr_sali17.Text, cbhftogr_crsmba17.Text, cbhftogr_prsmbe17.Text, cbhftogr_cuma17.Text);

                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hatali " + hata.Message);
                }
            
          
            
           
            baglanti.Open();

            SqlCommand commandhfo = new SqlCommand("Select * From haftalikdersogrenci", baglanti);
            SqlDataReader drhfo = commandhfo.ExecuteReader();
         


            int gizle = 0;
            while (drhfo.Read())
            {
                if (cbdrspo_blm.SelectedItem.ToString() == drhfo[0].ToString() && cbdrspo_snf.SelectedItem.ToString() == drhfo[1].ToString())
                {
                   
                        gizle = 1;
                        pictureBoxhftogr_ekle.Visible = false;
                        pictureBoxhftogr_kaydet.Visible = true;
                        pictureBoxhftogr_sil.Visible = true;
                }
                else
                {
                    if (gizle == 0)
                    {
                        pictureBoxhftogr_ekle.Visible = true;
                        pictureBoxhftogr_kaydet.Visible = false;
                        pictureBoxhftogr_sil.Visible = false;
                    }
                }
            }
            baglanti.Close();

        }
        private void pictureBoxhftogr_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                ogrencihaftalikdersekle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun08.Text, cbhftogr_pzrt08.Text, cbhftogr_sali08.Text, cbhftogr_crsmba08.Text, cbhftogr_prsmbe08.Text, cbhftogr_cuma08.Text);
                ogrencihaftalikdersekle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun09.Text, cbhftogr_pzrt09.Text, cbhftogr_sali09.Text, cbhftogr_crsmba09.Text, cbhftogr_prsmbe09.Text, cbhftogr_cuma09.Text);
                ogrencihaftalikdersekle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun10.Text, cbhftogr_pzrt10.Text, cbhftogr_sali10.Text, cbhftogr_crsmba10.Text, cbhftogr_prsmbe10.Text, cbhftogr_cuma10.Text);
                ogrencihaftalikdersekle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun11.Text, cbhftogr_pzrt11.Text, cbhftogr_sali11.Text, cbhftogr_crsmba11.Text, cbhftogr_prsmbe11.Text, cbhftogr_cuma11.Text);
                ogrencihaftalikdersekle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun12.Text, cbhftogr_pzrt12.Text, cbhftogr_sali12.Text, cbhftogr_crsmba12.Text, cbhftogr_prsmbe12.Text, cbhftogr_cuma12.Text);
                ogrencihaftalikdersekle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun13.Text, cbhftogr_pzrt13.Text, cbhftogr_sali13.Text, cbhftogr_crsmba13.Text, cbhftogr_prsmbe13.Text, cbhftogr_cuma13.Text);
                ogrencihaftalikdersekle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun14.Text, cbhftogr_pzrt14.Text, cbhftogr_sali14.Text, cbhftogr_crsmba14.Text, cbhftogr_prsmbe14.Text, cbhftogr_cuma14.Text);
                ogrencihaftalikdersekle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun15.Text, cbhftogr_pzrt15.Text, cbhftogr_sali15.Text, cbhftogr_crsmba15.Text, cbhftogr_prsmbe15.Text, cbhftogr_cuma15.Text);
                ogrencihaftalikdersekle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun16.Text, cbhftogr_pzrt16.Text, cbhftogr_sali16.Text, cbhftogr_crsmba16.Text, cbhftogr_prsmbe16.Text, cbhftogr_cuma16.Text);
                ogrencihaftalikdersekle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun17.Text, cbhftogr_pzrt17.Text, cbhftogr_sali17.Text, cbhftogr_crsmba17.Text, cbhftogr_prsmbe17.Text, cbhftogr_cuma17.Text);
                MessageBox.Show("Kayit Eklendi");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hatali " + hata.Message);
            }
        
        }

        private void pictureBoxhftogr_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun08.Text, cbhftogr_pzrt08.Text, cbhftogr_sali08.Text, cbhftogr_crsmba08.Text, cbhftogr_prsmbe08.Text, cbhftogr_cuma08.Text);
                ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun09.Text, cbhftogr_pzrt09.Text, cbhftogr_sali09.Text, cbhftogr_crsmba09.Text, cbhftogr_prsmbe09.Text, cbhftogr_cuma09.Text);
                ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun10.Text, cbhftogr_pzrt10.Text, cbhftogr_sali10.Text, cbhftogr_crsmba10.Text, cbhftogr_prsmbe10.Text, cbhftogr_cuma10.Text);
                ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun11.Text, cbhftogr_pzrt11.Text, cbhftogr_sali11.Text, cbhftogr_crsmba11.Text, cbhftogr_prsmbe11.Text, cbhftogr_cuma11.Text);
                ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun12.Text, cbhftogr_pzrt12.Text, cbhftogr_sali12.Text, cbhftogr_crsmba12.Text, cbhftogr_prsmbe12.Text, cbhftogr_cuma12.Text);
                ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun13.Text, cbhftogr_pzrt13.Text, cbhftogr_sali13.Text, cbhftogr_crsmba13.Text, cbhftogr_prsmbe13.Text, cbhftogr_cuma13.Text);
                ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun14.Text, cbhftogr_pzrt14.Text, cbhftogr_sali14.Text, cbhftogr_crsmba14.Text, cbhftogr_prsmbe14.Text, cbhftogr_cuma14.Text);
                ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun15.Text, cbhftogr_pzrt15.Text, cbhftogr_sali15.Text, cbhftogr_crsmba15.Text, cbhftogr_prsmbe15.Text, cbhftogr_cuma15.Text);
                ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun16.Text, cbhftogr_pzrt16.Text, cbhftogr_sali16.Text, cbhftogr_crsmba16.Text, cbhftogr_prsmbe16.Text, cbhftogr_cuma16.Text);
                ogrencihaftalikdersguncelle(cbdrspo_blm.Text, cbdrspo_snf.Text, cbhftogr_gun17.Text, cbhftogr_pzrt17.Text, cbhftogr_sali17.Text, cbhftogr_crsmba17.Text, cbhftogr_prsmbe17.Text, cbhftogr_cuma17.Text);
                MessageBox.Show("Kayit Kaydedildi");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hatali " + hata.Message);
            }
        }

        private void pictureBoxhftogr_sil_Click(object sender, EventArgs e)
        {
            sil("Delete From haftalikdersogrenci Where bolum = @tc and saat = @saat and sinif = @sinif", 1, cbhftogr_gun08.Text, cbdrspo_blm.Text, cbdrspo_snf.Text);
            sil("Delete From haftalikdersogrenci Where bolum = @tc and saat = @saat and sinif = @sinif", 1, cbhftogr_gun09.Text, cbdrspo_blm.Text, cbdrspo_snf.Text);
            sil("Delete From haftalikdersogrenci Where bolum = @tc and saat = @saat and sinif = @sinif", 1, cbhftogr_gun10.Text, cbdrspo_blm.Text, cbdrspo_snf.Text);
            sil("Delete From haftalikdersogrenci Where bolum = @tc and saat = @saat and sinif = @sinif", 1, cbhftogr_gun11.Text, cbdrspo_blm.Text, cbdrspo_snf.Text);
            sil("Delete From haftalikdersogrenci Where bolum = @tc and saat = @saat and sinif = @sinif", 1, cbhftogr_gun12.Text, cbdrspo_blm.Text, cbdrspo_snf.Text);
            sil("Delete From haftalikdersogrenci Where bolum = @tc and saat = @saat and sinif = @sinif", 1, cbhftogr_gun13.Text, cbdrspo_blm.Text, cbdrspo_snf.Text);
            sil("Delete From haftalikdersogrenci Where bolum = @tc and saat = @saat and sinif = @sinif", 1, cbhftogr_gun14.Text, cbdrspo_blm.Text, cbdrspo_snf.Text);
            sil("Delete From haftalikdersogrenci Where bolum = @tc and saat = @saat and sinif = @sinif", 1, cbhftogr_gun15.Text, cbdrspo_blm.Text, cbdrspo_snf.Text);
            sil("Delete From haftalikdersogrenci Where bolum = @tc and saat = @saat and sinif = @sinif", 1, cbhftogr_gun16.Text, cbdrspo_blm.Text, cbdrspo_snf.Text);
            sil("Delete From haftalikdersogrenci Where bolum = @tc and saat = @saat and sinif = @sinif", 1, cbhftogr_gun17.Text, cbdrspo_blm.Text, cbdrspo_snf.Text);
            MessageBox.Show("Kayit Silindi");
        }
    }
}