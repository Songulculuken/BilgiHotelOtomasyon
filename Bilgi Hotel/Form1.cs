using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilgi_Hotel
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Server = .; Database = db_BilgiHotel; Trusted_Connection = True;");
        SqlDataReader dr;
        SqlCommand com;
        SqlCommand con;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
                checkBox1.Text = "Gizle";
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox2.UseSystemPasswordChar = false;
                checkBox1.Text = "Göster";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnn = new SqlConnection("Server = .; Database = db_BilgiHotel; Trusted_Connection = True;");
                SqlCommand cmd = new SqlCommand("select * from kullanicilar where kullaniciAd = @KAdi and kullaniciSifre = @KParola", cnn);
                cmd.Parameters.AddWithValue("@KAdi", textBox1.Text);
                cmd.Parameters.AddWithValue("@KParola", textBox2.Text);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows) 
                {
                    while (reader.Read()) 
                    {
                        if (reader["kullaniciTipiID"].ToString() == "1") 
                        {
                            // Kullanıcı Rolü 1 ise Admin Ekranı Aç 
                            Yonetici admin = new Yonetici();
                            admin.Show();
                            this.Hide();
                        }
                        else
                        {
                            
                           
                        }
                    }
                }
                else 
                {
                    reader.Close();
                    MessageBox.Show("Kullanıcı Adı veya Parola Geçersizdir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch 
            {
                MessageBox.Show("DB ye ulaşılamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    
}
