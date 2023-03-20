using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilgi_Hotel
{
    public partial class Yonetici : Form
    {

        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public Yonetici()
        {
            InitializeComponent();
            random = new Random();
            button8.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Yonetici_Load(object sender, EventArgs e)
        {

        }

        //Method
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while(tempIndex == index)
            {
               index =  random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index]; 
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton=(Button)btnSender;        
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft San Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162))); 
                    panel3.BackColor = color;
                    panel2.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    button8.Visible = true;

                }
            }
        }

        private void DisableButton()
            { 
            foreach(Control previousBtn in panel1.Controls)
            {
                if(previousBtn.GetType()== typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76) ;
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font= new System.Drawing.Font("Microsoft San Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));

                }
            }
            
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeForm!=null)
            {
                activeForm.Close();
            }
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel4.Controls.Add(childForm);
            this.panel4.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label2.Text = childForm.Text;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.ODALAR(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.ÇALIŞANLAR(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.Kullanici(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.Vardiyalar(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.Kampanyalar(), sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.Satis(), sender);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formlar.AYARLAR(), sender);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            label2.Text = "ANA SAYFA";
            panel3.BackColor = Color.FromArgb(0, 150, 136);
            panel2.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            button8.Visible = false;
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
