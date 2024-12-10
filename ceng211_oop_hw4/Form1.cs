using System.Xml;

namespace ceng211_oop_hw4
{
    public partial class Form1 : Form
    {
        public string path = @"R:\C#\Homework4\logs.txt";
        DateTime now = DateTime.Now;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(path))
            {
                FileStream file = new FileStream(path, FileMode.Create);
                file.Close();
            }

            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine($"{now} | user opened program.");
                writer.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine($"{now} | user clicked useless button.");
                writer.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine($"{now} | {textBox1.Text}");
                    writer.Close();
                }
            }
            else
            {
                MessageBox.Show("Please write something.", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.Delete(path);
            listBox1.Items.Clear();
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                }
                reader.Close();
            }
            else
            {
                MessageBox.Show("File doesn't exist now. Add something.", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
