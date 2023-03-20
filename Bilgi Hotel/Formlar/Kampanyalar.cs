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

namespace Bilgi_Hotel.Formlar
{
    public partial class Kampanyalar : Form
    {
        SqlConnection baglanti = new SqlConnection("Server = .; Database = db_BilgiHotel; Trusted_Connection = True;");
        SqlDataReader dr;
        SqlCommand com;
        Baglanti con;
        public Kampanyalar()
        {
            InitializeComponent();
            
        }
        private void kampanyaDoldur()
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
            label1.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            label4.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.SecondaryColor;
            label6.ForeColor = ThemeColor.SecondaryColor;
            label10.ForeColor = ThemeColor.SecondaryColor;

        }
        private void Kampanyalar_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            kampanyaDoldur();

        }
    }
}
