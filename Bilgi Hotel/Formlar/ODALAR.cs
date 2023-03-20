using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Button = System.Windows.Forms.Button;

namespace Bilgi_Hotel.Formlar
{

    public partial class ODALAR : Form
    {
        List<KeyValuePair<int, string>> OdaTipiListesi = new List<KeyValuePair<int, string>>();
        SqlConnection baglanti = new SqlConnection("Server = DESKTOP-7OTS1EG; Database = db_BilgiHotel; Trusted_Connection = True;");
        SqlDataReader dr;
        SqlCommand com;
        Baglanti con;
        
        public ODALAR()
        {
            InitializeComponent();
            con = new Baglanti("Server = DESKTOP-7OTS1EG; Database = db_BilgiHotel; Trusted_Connection = True;");
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
           
            label2.ForeColor = ThemeColor.SecondaryColor;
            label1.ForeColor = ThemeColor.SecondaryColor;
            label4.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.SecondaryColor;
            
            label7.ForeColor = ThemeColor.SecondaryColor;
            label8.ForeColor = ThemeColor.SecondaryColor;
            label9.ForeColor = ThemeColor.SecondaryColor;
            label10.ForeColor = ThemeColor.SecondaryColor;
            label11.ForeColor = ThemeColor.SecondaryColor;
        }
        private void odaBilgiDoldur()
        {
            listView1.Items.Clear();




            baglanti.Open();
            com = new SqlCommand("Select * From [dbo].[odalar2] as o JOIN odaTipleri as od on od.odaTipiID=o.odaTipID ", baglanti);

            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["odaNo"].ToString());
                item.SubItems.Add(dr["kat"].ToString());
                item.SubItems.Add(dr["odaFiyat"].ToString());
                item.SubItems.Add(dr["odaTipiOzellik"].ToString());
                listView1.Items.Add(item);

            }
            baglanti.Close();
        }

        private void Odalar_Load(object sender, EventArgs e)
        {
            LoadTheme();
            odaBilgiDoldur();
            baglanti.Open();


            //OdaTipleri Combobox Doldurma
            SqlCommand cmd = new SqlCommand("SELECT odaTipiID,odaTipiOzellik FROM [dbo].[odaTipleri]", baglanti);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                OdaTipiListesi.Add(new KeyValuePair<int, string>((int)reader[0], (string)reader[1]));
            }
            reader.Close();
            comboBox1.DataSource = OdaTipiListesi.ToList();
            comboBox1.ValueMember = "Key";
            comboBox1.DisplayMember = "Value";

            baglanti.Close();

        }
     

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



            int odaNumara = (int)numericUpDown1.Value;
          
            int odaKisiSayisi = (int)comboBox1.SelectedValue;
            int odaKat = (int)numericUpDown2.Value;
            int tekKisilik=(int)numericUpDown3.Value;
            int ciftKisilik=(int)numericUpDown4.Value;
            int odaFiyat = Convert.ToInt32(textBox2.Text);
            bool aktifMi = checkBox7.Checked;

            string odaAciklama = textBox1.Text;
            

            try
            {
                baglanti.Open();

                SqlCommand cmd = new SqlCommand($"INSERT INTO odalar2 (odaNo,kat,odaTipID,odaFiyat,odaAktifMi,odaAciklama) VALUES ({odaNumara},{odaKat},'{odaKisiSayisi}',{odaFiyat},'{aktifMi}','{odaAciklama}')", baglanti);

                cmd.ExecuteNonQuery();
                foreach (int itemIndices in checkedListBox1.CheckedIndices)
                {
                    SqlCommand cmdd=new SqlCommand( $"INSERT INTO [dbo].[odalarOdaÖzellikler] (odaNumara,odaOzellikID) VALUES({odaNumara},{itemIndices + 1})", baglanti);
                    cmdd.ExecuteNonQuery();
                }
                SqlCommand cmddd;
                if (checkBox8.Checked)
                {
                    cmddd = new SqlCommand($"INSERT INTO [dbo].[odalarYatakTipleri2] (odaNumara,yatakID,yatakAdet) VALUES ({odaNumara},3,1)", baglanti);
                }
                else
                {
                    cmddd = new SqlCommand($"INSERT INTO [dbo].[odalarYatakTipleri2] (odaNumara,yatakID,yatakAdet) VALUES ({odaNumara},1,{tekKisilik}),({odaNumara},2,{ciftKisilik})", baglanti);
                }

                cmddd.ExecuteNonQuery();

                
                baglanti.Close();
                odaBilgiDoldur();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oda Eklenirken Hata Oluştu! Hata Mesajı: " + ex.Message);
                baglanti.Close();
                return;
            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
         
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
         

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int odaNumara = (int)numericUpDown1.Value;

            int odaKisiSayisi = (int)comboBox1.SelectedValue;
            int odaKat = (int)numericUpDown2.Value;
            int tekKisilik = (int)numericUpDown3.Value;
            int ciftKisilik = (int)numericUpDown4.Value;
            int odaFiyat = Convert.ToInt32(textBox2.Text);
            bool aktifMi = checkBox7.Checked;

            string odaAciklama = textBox1.Text;


            try
            {
                baglanti.Open();

                SqlCommand cmd = new SqlCommand($"UPDATE odalar2 SET kat={odaKat},odaTipID='{odaKisiSayisi}',odaFiyat={odaFiyat},odaAktifMi='{aktifMi}',odaAciklama='{odaAciklama}' where odaNo={odaNumara}", baglanti);

                cmd.ExecuteNonQuery();

              
                


                    SqlCommand cmddd = new SqlCommand($"DELETE [dbo].[odalarOdaÖzellikler] where odaNumara={odaNumara}", baglanti);
                    cmddd.ExecuteNonQuery();
                  
                
                foreach (int itemIndicess in checkedListBox1.CheckedIndices)
                {


                    SqlCommand cmdda = new SqlCommand($"INSERT INTO [dbo].[odalarOdaÖzellikler] (odaNumara,odaOzellikID) VALUES({odaNumara},{itemIndicess + 1})", baglanti);
                    cmdda.ExecuteNonQuery();

                }

                SqlCommand cmdd = new SqlCommand($"DELETE [dbo].[odalarYatakTipleri2] where odaNumara={odaNumara}", baglanti);
                cmdd.ExecuteNonQuery();
              
                if (checkBox8.Checked)
                {
                    cmdd = new SqlCommand($"INSERT INTO [dbo].[odalarYatakTipleri2] (odaNumara,yatakID,yatakAdet) VALUES ({odaNumara},3,1)", baglanti);
                }
                else
                {
                    cmdd = new SqlCommand($"INSERT INTO [dbo].[odalarYatakTipleri2] (odaNumara,yatakID,yatakAdet) VALUES ({odaNumara},1,{tekKisilik}),({odaNumara},2,{ciftKisilik})", baglanti);

                }

                cmdd.ExecuteNonQuery();


                baglanti.Close();
                odaBilgiDoldur();
            }
            catch (Exception ex)
            {
               
                baglanti.Close();
                return;
            }
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            odaBilgiDoldur();
           
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            checkedListBox1.SetItemChecked(0, false);
            checkedListBox1.SetItemChecked(1, false);
            checkedListBox1.SetItemChecked(2, false);
            checkedListBox1.SetItemChecked(3, false);
            checkedListBox1.SetItemChecked(4, false);
            checkedListBox1.SetItemChecked(5, false);
            string odaOzellikler = checkedListBox1.Text;
            SqlCommand cmd = new SqlCommand("select * from odalar2 as o JOIN odalarOdaÖzellikler as oo on oo.odaNumara=o.odaNo JOIN odaOzellikleri as od on od.odaOzellikID=oo.odaOzellikID JOIN odalarYatakTipleri2 as oy on oy.odaNumara=o.odaNo JOIN yatakTipleri2 as yt on yt.yatakTipiID=oy.yatakID where odaNo='" + numericUpDown1.Value + "'", baglanti);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            } 
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.SelectedValue = dr[1];
                numericUpDown2.Value = Convert.ToInt16(dr[2]);
                switch ((int)dr["yatakID"])
                {
                    case 1:
                        numericUpDown3.Value = Convert.ToDecimal(dr["yatakAdet"]);
                        break;
                    case 2: 
                        numericUpDown4.Value = Convert.ToDecimal(dr["yatakAdet"]);
                        break;
                        case 3:
                        checkBox8.Checked = true;
                        break;
                }
                
                switch ((int)dr["odaOzellikID"])
                {
                    case 1:
                        checkedListBox1.SetItemChecked(0, true); break;
                        case 2: 
                        checkedListBox1.SetItemChecked(1, true); break;
                        case 3: 
                        checkedListBox1.SetItemChecked(2, true); break;
                        case 4:
                        checkedListBox1.SetItemChecked(3, true); break;
                        case 5:
                        checkedListBox1.SetItemChecked(4, true); break;
                        case 6: 
                        checkedListBox1.SetItemChecked (5, true); break;
                        default:
                        break;

                }
                textBox2.Text = dr[3].ToString();


                checkBox7.Checked = (Convert.ToInt32(dr["odaAktifMi"]) == 1) ? true : false;
                textBox1.Text = dr[5].ToString();

            }
            baglanti.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            comboBox1.SelectedIndex = -1;
            checkedListBox1.SetItemChecked(0, false);
            checkedListBox1.SetItemChecked(1, false);
            checkedListBox1.SetItemChecked(2, false);
            checkedListBox1.SetItemChecked(3, false);
            checkedListBox1.SetItemChecked(4, false);
            checkedListBox1.SetItemChecked(5, false);
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)

            {

                ListViewItem item = listView1.SelectedItems[0];

                numericUpDown1.Text = item.SubItems[0].Text;
                numericUpDown2.Text = item.SubItems[1].Text;
                textBox2.Text = item.SubItems[2].Text;
                comboBox1.SelectedItem = item.SubItems[3].Text;


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int odaNumara = (int)numericUpDown1.Value;

            try
            {
                baglanti.Open();

                
                SqlCommand cmd = new SqlCommand($"DELETE from [dbo].[odalarYatakTipleri2] where odaNumara={odaNumara};", baglanti);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand($"DELETE from [dbo].[odalarOdaÖzellikler] where odaNumara={odaNumara};", baglanti);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand($"DELETE from [dbo].[odalar2]  where odaNo={odaNumara};", baglanti);
                cmd.ExecuteNonQuery();
               










            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                baglanti.Close();
                return;
            }
            baglanti.Close();


        }
    }
}
