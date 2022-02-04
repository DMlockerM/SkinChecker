using System.Net;
using Newtonsoft.Json.Linq;

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
            var text = File.ReadAllText("SkinChecker.json");
            JObject json = JObject.Parse(text);

            label2.Text = (string)json["locale"][(string)json["nowlang"]]["currlang"];
            button1.Text = (string)json["locale"][(string)json["nowlang"]]["look"];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                var text = File.ReadAllText("SkinChecker.json");
                JObject json = JObject.Parse(text);
                MessageBox.Show((string)json["locale"][(string)json["nowlang"]]["err_nonick"], "err_nonick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                string sURL = $"https://minotar.net/armor/body/{textBox1.Text}/210.png";
                try
                {
                    WebRequest req = WebRequest.Create(sURL);
                    WebResponse res = req.GetResponse();
                    Stream imgStream = res.GetResponseStream();
                    Image img1 = Image.FromStream(imgStream);
                    imgStream.Close();
                    pictureBox1.Image = img1;
                    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var text = File.ReadAllText("SkinChecker.json");
            JObject json = JObject.Parse(text);

            switch (comboBox1.Text)
            {
                case "":
                    MessageBox.Show((string)json["locale"][(string)json["nowlang"]]["err_nochoicelang"], "err_nochoicelang", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "Русский":
                    json["nowlang"] = "RU";
                    dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(text);
                    jsonObj["nowlang"] = "RU";

                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText("SkinChecker.json", output);
                    label2.Text = (string)json["locale"]["RU"]["currlang"];
                    button1.Text = (string)json["locale"]["RU"]["look"];
                    break;
                case "English":
                    json["nowlang"] = "EN";
                    dynamic jsonObj1 = Newtonsoft.Json.JsonConvert.DeserializeObject(text);
                    jsonObj1["nowlang"] = "EN";

                    string output1 = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj1, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText("SkinChecker.json", output1);
                    label2.Text = (string)json["locale"]["EN"]["currlang"];
                    button1.Text = (string)json["locale"]["EN"]["look"]; 
                    break;
                default:
                    MessageBox.Show("O.O");
                    break;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}