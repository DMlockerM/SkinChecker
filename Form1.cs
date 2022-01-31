using System.Net;

namespace SkinChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Вы не ввели никнейм.");
            } else
            {
                string sURL = $"https://minotar.net/armor/body/{textBox1.Text}/210.png";
                WebRequest req = WebRequest.Create(sURL);
                WebResponse res = req.GetResponse();
                Stream imgStream = res.GetResponseStream();
                Image img1 = Image.FromStream(imgStream);
                imgStream.Close();
                pictureBox1.Image = img1;

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}