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
    public partial class form_devamsizlikbilgisi : Form
    {
        public form_devamsizlikbilgisi()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=AHMETHAKAN\\SQLEXPRESS;Initial Catalog=eokul;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(constring);
        private void form_devamsizlikbilgisi_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < 11; i++)
            //{

            //    for (int j = 0; j < 32; j++)
            //    {
            //        TextBox textBox = new TextBox();
            //        textBox.Size = new Size(25, 25);

            //        textBox.Location = new Point(30 + (20 * j), 150 + (20 * i));

            //        textBox.TextAlign = HorizontalAlignment.Center;
            //        textBox.Name = ("textBox_devamsizlik" + i);
            //        textBox.Enabled = false;
            //        panel1.Controls.Add(textBox);
            //        if (i == 0 && j == 0)
            //        {
            //            textBox.Enabled = false;
            //            textBox.Text = "Aylar";


            //        }

            //        if (i == 0 && j != 0)
            //        {

            //            textBox.Enabled = false;
            //            textBox.Text = j.ToString();
            //        }
            //        if (j == 0 && i != 0)
            //        {
            //            textBox.Enabled = false;
            //            if (i == 1)
            //                textBox.Text = "EYLÜL";
            //            else if (i == 2)
            //                textBox.Text = "EKİM";
            //            else if (i == 3)
            //                textBox.Text = "KASIM";
            //            else if (i == 4)
            //                textBox.Text = "ARALIK";
            //            else if (i == 5)
            //                textBox.Text = "OCAK";
            //            else if (i == 6)
            //                textBox.Text = "ŞUBAT";
            //            else if (i == 7)
            //                textBox.Text = "MART";
            //            else if (i == 8)
            //                textBox.Text = "NİSAN";
            //            else if (i == 9)
            //                textBox.Text = "MAYIS";
            //            else if (i == 10)
            //                textBox.Text = "HAZİRAN";
            //        }
            //    }
            //}
            for (int j = 0; j < 32; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(5 + (24 * j), 0);

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);

                textBox.Text = j.ToString();
                if (j == 0)
                {
                    textBox.Size = new Size(30, 25);
                    textBox.Text = "GUNLER";
                }
                   



                textBox.Enabled = false;
                panelgun.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                if(j==0)
                    textBox.Text = "EYLÜL";
                if (j == 1)
                    textBox.Text = "EKİM";
                if (j == 2)
                    textBox.Text = "KASIM";
                if (j == 3)
                    textBox.Text = "ARALIK";
                if (j == 4)
                    textBox.Text = "OCAK";
                if (j == 5)
                    textBox.Text = "ŞUBAT";
                if (j == 6)
                    textBox.Text = "MART";
                if (j == 7)
                    textBox.Text = "NİSAN";
                if (j == 8)
                    textBox.Text = "MAYIS";
                if (j == 9)
                    textBox.Text = "HAZİRAN";

                textBox.Enabled = false;
                panelay.Controls.Add(textBox);
            }

            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel1.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel2.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel3.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel4.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel5.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel6.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel7.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel8.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel9.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel10.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel11.Controls.Add(textBox);
            }

            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel12.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel13.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel14.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel15.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel16.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel17.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel18.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel19.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel20.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel21.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel22.Controls.Add(textBox);
            }

            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel23.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel24.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel25.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel26.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel27.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel28.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel29.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel30.Controls.Add(textBox);
            }
            for (int j = 0; j < 10; j++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(25, 25);

                textBox.Location = new Point(0, 0 + (20 * j));

                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Name = ("textBox_devamsizlik" + j);
                textBox.Enabled = false;
                panel31.Controls.Add(textBox);
            }
          
           



            baglanti.Open();
            SqlCommand commanddvm = new SqlCommand("Select * From devamsizlik", baglanti);
            SqlDataReader drdvm = commanddvm.ExecuteReader();
            int sayac = 0;
            while (drdvm.Read())
            {
                Form3 form3 = new Form3();
                if (drdvm[0].ToString() == Form2.giristc.ToString())
                {
                    DateTime dgm = Convert.ToDateTime(drdvm[3].ToString());
                    string gun = dgm.Day.ToString();
                    string ay = dgm.Month.ToString();
                    string yil = dgm.Year.ToString();
                    int i = 9;
                   
                    foreach (Control devamsizlik in ((Panel)panel.Controls["panel" + gun]).Controls)
                    {
                      
                        if(i == Convert.ToInt32(ay))
                        {
                            devamsizlik.Text = "G";
                            sayac++;

                        }
                        if(i == 12)
                        {
                            i = 0;
                        }
                            
                        i++;
                    }
                }
                
            }
            textBox1.Text = sayac.ToString();
            baglanti.Close();
          
        }
    }
}
