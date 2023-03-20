using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Bilgi_Hotel.Formlar
{
    
    public partial class ÇALIŞANLAR : Form
    {
        List<KeyValuePair<int, string>> UlkeListesi = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> SehirListesi = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> IlceListesi = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> GorevListesi = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> CinsiyetListesi = new List<KeyValuePair<int, string>>();
        SqlConnection baglanti = new SqlConnection("Server = DESKTOP-7OTS1EG; Database = db_BilgiHotel; Trusted_Connection = True;");
        SqlDataReader dr;
        SqlCommand com;
        Baglanti con;
        public ÇALIŞANLAR()
        {
            InitializeComponent();
            
        }
        private void odaDoldur()
        {
            listView1.Items.Clear();
            baglanti.Open();
            com = new SqlCommand("Select * from [dbo].[calisanlar] as c JOIN gorevler as g on g.gorevID=c.gorevID  ", baglanti);

            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["calisanAd"].ToString());
                item.SubItems.Add(dr["calisanSoyad"].ToString());
                item.SubItems.Add(dr["calisanTelefonNo"].ToString());
                item.SubItems.Add(dr["gorevAd"].ToString());
                item.SubItems.Add(dr["calisanCalismaDurumu"].ToString());
                if(dr["calisanCalismaDurumu"].ToString() ==  "Çalışmıyor")
                        {
                    item.ForeColor = Color.Red;
                        }
                listView1.Items.Add(item);

            }
            baglanti.Close();
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
            label12.ForeColor = ThemeColor.SecondaryColor;
            label13.ForeColor = ThemeColor.SecondaryColor;
            label14.ForeColor = ThemeColor.SecondaryColor;
            label15.ForeColor = ThemeColor.SecondaryColor;
            label16.ForeColor = ThemeColor.SecondaryColor;
            label17.ForeColor = ThemeColor.SecondaryColor;
            label18.ForeColor = ThemeColor.SecondaryColor;
            label19.ForeColor = ThemeColor.SecondaryColor;
            label20.ForeColor = ThemeColor.SecondaryColor;
            label21.ForeColor = ThemeColor.SecondaryColor;  
            label22.ForeColor = ThemeColor.SecondaryColor;  
            label23.ForeColor = ThemeColor.SecondaryColor;
            label24.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            label6.ForeColor = ThemeColor.SecondaryColor;
        }
        private void Calisanlar_Load(object sender, EventArgs e)
        {
            odaDoldur();
             LoadTheme();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT ulkeID,ulkeAd FROM [dbo].[ulkeler]", baglanti);
            SqlDataReader reader = cmd.ExecuteReader();
           
            while (reader.Read())
            {
                UlkeListesi.Add(new KeyValuePair<int, string>((int)reader[0], (string)reader[1]));
            }
            reader.Close();
            comboBox1.DataSource = UlkeListesi.ToList();
            comboBox1.ValueMember = "Key";
            comboBox1.DisplayMember = "Value";

            baglanti.Close();

            baglanti.Open();
            SqlCommand cmda = new SqlCommand("SELECT sehirID,sehirAd FROM sehirler", baglanti);
            SqlDataReader readerr = cmda.ExecuteReader();

            while (readerr.Read())
            {
                SehirListesi.Add(new KeyValuePair<int, string>((int)readerr[0], (string)readerr[1]));
            }
            readerr.Close();
            comboBox2.DataSource = SehirListesi.ToList();
            comboBox2.ValueMember = "Key";
            comboBox2.DisplayMember = "Value";

            baglanti.Close();

            baglanti.Open();
            SqlCommand cmdaa = new SqlCommand("SELECT ilceID,ilceAd FROM [dbo].[ilceler]", baglanti);
            SqlDataReader readerrr = cmdaa.ExecuteReader();

            while (readerrr.Read())
            {
                IlceListesi.Add(new KeyValuePair<int, string>((int)readerrr[0], (string)readerrr[1]));
            }
            readerrr.Close();
            comboBox3.DataSource = IlceListesi.ToList();
            comboBox3.ValueMember = "Key";
            comboBox3.DisplayMember = "Value";

            baglanti.Close();

            baglanti.Open();
            SqlCommand cmde = new SqlCommand("SELECT gorevID,gorevAd FROM gorevler", baglanti);
            SqlDataReader readera = cmde.ExecuteReader();

            while (readera.Read())
            {
                GorevListesi.Add(new KeyValuePair<int, string>((int)readera[0], (string)readera[1]));
            }
            readera.Close();
            comboBox4.DataSource = GorevListesi.ToList();
            comboBox4.ValueMember = "Key";
            comboBox4.DisplayMember = "Value";

            baglanti.Close();

            baglanti.Open();
            SqlCommand cmdc = new SqlCommand("SELECT cinsiyetID,cinsiyetAd FROM [dbo].[cinsiyet]", baglanti);
            SqlDataReader readerc = cmdc.ExecuteReader();

            while (readerc.Read())
            {
                CinsiyetListesi.Add(new KeyValuePair<int, string>((int)readerc[0], (string)readerc[1]));
            }
            readerc.Close();
            comboBox5.DataSource = CinsiyetListesi.ToList();
            comboBox5.ValueMember = "Key";
            comboBox5.DisplayMember = "Value";

            baglanti.Close();


            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("sp_CalisanEkle", baglanti);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@calisanAd", textBox1.Text);
            cmd.Parameters.AddWithValue("@calisanSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@calisanTCKimlikNo", textBox3.Text);
            cmd.Parameters.AddWithValue("@calisanDogumTarih", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@calisanTelefonNo", textBox4.Text);
            cmd.Parameters.AddWithValue("@calisanEposta", textBox5.Text);
            cmd.Parameters.AddWithValue("@calisanAdres", textBox6.Text);
            cmd.Parameters.AddWithValue("@ulkeID", comboBox1.SelectedValue);
            cmd.Parameters.AddWithValue("@sehirID", comboBox2.SelectedValue);
            cmd.Parameters.AddWithValue("@ilceID", comboBox3.SelectedValue);
            cmd.Parameters.AddWithValue("@gorevID", comboBox4.SelectedValue);
            cmd.Parameters.AddWithValue("@cinsiyetID", comboBox5.SelectedValue);
            cmd.Parameters.AddWithValue("@calisanSaatlikUcret", textBox7.Text);
            cmd.Parameters.AddWithValue("@calisanMaas", textBox8.Text);
            cmd.Parameters.AddWithValue("@calisanSicilNo", textBox9.Text);
            cmd.Parameters.AddWithValue("@calisanEngelliMi", checkBox1.Checked);
            cmd.Parameters.AddWithValue("@calisanAcilDurumKisiAd", textBox10.Text);
            cmd.Parameters.AddWithValue("@calisanAcilDurumTelefonNo", textBox11.Text);
            cmd.Parameters.AddWithValue("@calisanIseBaslamaTarih", dateTimePicker2.Value);
            if (textBox13.Text == "Çalışıyor")
            {
                cmd.Parameters.AddWithValue("@calisanIstenCikisTarih", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@calisanIstenCikisTarih", dateTimePicker3.Value);
            }
           
            cmd.Parameters.AddWithValue("@calisanCalismaDurumu", textBox13.Text);
            cmd.Parameters.AddWithValue("@calisanAktifMi", checkBox2.Checked);
            cmd.Parameters.AddWithValue("@calisanAciklama", textBox12.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            odaDoldur();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("sp_CalisanGuncelle", baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@calisanAd", textBox1.Text);
            cmd.Parameters.AddWithValue("@calisanSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@calisanTCKimlikNo", textBox3.Text);
            cmd.Parameters.AddWithValue("@calisanDogumTarih", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@calisanTelefonNo", textBox4.Text);
            cmd.Parameters.AddWithValue("@calisanEposta", textBox5.Text);
            cmd.Parameters.AddWithValue("@calisanAdres", textBox6.Text);
            cmd.Parameters.AddWithValue("@ulkeID", comboBox1.SelectedValue);
            cmd.Parameters.AddWithValue("@sehirID", comboBox2.SelectedValue);
            cmd.Parameters.AddWithValue("@ilceID", comboBox3.SelectedValue);
            cmd.Parameters.AddWithValue("@gorevID", comboBox4.SelectedValue);
            cmd.Parameters.AddWithValue("@cinsiyetID", comboBox5.SelectedValue);
            cmd.Parameters.AddWithValue("@calisanSaatlikUcret", textBox7.Text);
            cmd.Parameters.AddWithValue("@calisanMaas", textBox8.Text);
            cmd.Parameters.AddWithValue("@calisanSicilNo", textBox9.Text);
            cmd.Parameters.AddWithValue("@calisanEngelliMi", checkBox1.Checked);
            cmd.Parameters.AddWithValue("@calisanAcilDurumKisiAd", textBox10.Text);
            cmd.Parameters.AddWithValue("@calisanAcilDurumTelefonNo", textBox11.Text);
            cmd.Parameters.AddWithValue("@calisanIseBaslamaTarih", dateTimePicker2.Value);
            if (textBox13.Text == "Çalışıyor")
            {
                cmd.Parameters.AddWithValue("@calisanIstenCikisTarih", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@calisanIstenCikisTarih", dateTimePicker3.Value);
            }

            cmd.Parameters.AddWithValue("@calisanCalismaDurumu", textBox13.Text);
            cmd.Parameters.AddWithValue("@calisanAktifMi", checkBox2.Checked);
            cmd.Parameters.AddWithValue("@calisanAciklama", textBox12.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            odaDoldur();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            SqlCommand cmd = new SqlCommand($"Delete from calisanlar where calisanAd='{ad}'", baglanti);
            try
            {
                baglanti.Open();
                MessageBox.Show(cmd.ExecuteNonQuery()+ "Çalışan Bilgileri Silindi");
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Çalışan Bilgileri Silinemedi" +ex.Message.ToString());
            }
            finally { baglanti.Close(); }
            odaDoldur();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from calisanlar where calisanAd='" + textBox14.Text + "'", baglanti);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dr[4]);
                textBox4.Text = dr[5].ToString();
                textBox5.Text = dr[6].ToString();
                textBox6.Text = dr[7].ToString();
                comboBox1.SelectedValue = dr[8];
                comboBox2.SelectedValue = dr[9];
                comboBox3.SelectedValue = dr[10];
                comboBox4.SelectedValue = dr[11];
                comboBox5.SelectedValue = dr[12];
                textBox7.Text = dr[13].ToString();
                textBox8.Text = dr[14].ToString();
                textBox9.Text = dr[15].ToString();
                checkBox1.Checked = (Convert.ToInt32(dr["calisanEngelliMi"]) == 1) ? true : false;
                textBox10.Text = dr[17].ToString();
                textBox11.Text = dr[18].ToString();
                dateTimePicker2.Value = Convert.ToDateTime(dr[19]);
                if(checkBox3.Checked==true)
                {
                    dateTimePicker3.Value = Convert.ToDateTime(dr[20]);
                }
                textBox13.Text = dr[21].ToString();
                checkBox2.Checked = (Convert.ToInt32(dr["calisanAktifMi"]) == 1) ? true : false;
                textBox12.Text = dr[23].ToString();
            }
            baglanti.Close();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            

            if (checkBox3.Checked) 
            { 
                dateTimePicker3.Enabled= true; 
            }
           else
            {
                dateTimePicker3.Enabled= false; 
            }
                        
                 
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2 .Clear();  
            textBox3 .Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
             checkBox3.Checked = false;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;   
            comboBox3.SelectedIndex = -1;   
            comboBox4.SelectedIndex = -1;   
            comboBox5.SelectedIndex = -1;
                
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            odaDoldur();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
                if (listView1.SelectedItems.Count > 0)

                {

                    ListViewItem item = listView1.SelectedItems[0];

                    textBox1.Text = item.SubItems[0].Text;
                    textBox2.Text = item.SubItems[1].Text;
                    textBox4.Text = item.SubItems[2].Text;
                    comboBox4.SelectedItem = item.SubItems[3].Text;
                    textBox13.Text = item.SubItems[4].Text;


                }
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from calisanlar where calisanAd='" + textBox1.Text + "'", baglanti);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {



                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dr[4]);
                textBox4.Text = dr[5].ToString();
                textBox5.Text = dr[6].ToString();
                textBox6.Text = dr[7].ToString();
                comboBox1.SelectedValue = dr[8];
                comboBox2.SelectedValue = dr[9];
                comboBox3.SelectedValue = dr[10];
                comboBox4.SelectedValue = dr[11];
                comboBox5.SelectedValue = dr[12];
                textBox7.Text = dr[13].ToString();
                textBox8.Text = dr[14].ToString();
                textBox9.Text = dr[15].ToString();
                checkBox1.Checked = (Convert.ToInt32(dr["calisanEngelliMi"]) == 1) ? true : false;
                textBox10.Text = dr[17].ToString();
                textBox11.Text = dr[18].ToString();
                dateTimePicker2.Value = Convert.ToDateTime(dr[19]);

                if (dr[20]== DBNull.Value)
                {
                    dateTimePicker3.Enabled = false;
                }
                else
                {

                    dateTimePicker3.Value = Convert.ToDateTime(dr[20]);
                    dateTimePicker3.Enabled = true;
                    checkBox3.Checked = true;
                }
                   
                
               
                textBox13.Text = dr[21].ToString();
                checkBox2.Checked = (Convert.ToInt32(dr["calisanAktifMi"]) == 1) ? true : false;
                textBox12.Text = dr[23].ToString();

            }
            baglanti.Close();
            odaDoldur();
        }
    }
}
