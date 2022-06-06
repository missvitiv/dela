using System.IO;
namespace Dela
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String polzovatel = textBox1.Text;
            String parol = textBox2.Text;
            String file = polzovatel + ".txt";
            if (File.Exists(file)) //если файл этого пользователя есть 
            {
                using (FileStream fileStream = new FileStream(file, FileMode.Open)) //читаем файл
                {
                    StreamReader streamReader = new StreamReader(fileStream);
                    String parolfile = streamReader.ReadLine(); //читаем первую строку
                    if (parol.Equals(parolfile)) //если введенный пароль эквивалентен прочитанному из файла
                    {
                        // то авторизуемся
                        Form2 form2 = new Form2(); 
                        this.Hide();
                        form2.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        label3.Text = "пароль не совпадает!";
                    }

                }
            }
            else // если такого файла не существует, то создаем его и авторизуемся
            {
                using (FileStream fileStream = new FileStream(file, FileMode.Create))
                {
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.AutoFlush = true;
                    streamWriter.WriteLine(textBox2.Text);
                    //авторизуемся
                    Form2 form2 = new Form2();                
                    this.Hide();
                    form2.ShowDialog();
                    this.Show();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}