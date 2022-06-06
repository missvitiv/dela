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
            if (File.Exists(file)) //���� ���� ����� ������������ ���� 
            {
                using (FileStream fileStream = new FileStream(file, FileMode.Open)) //������ ����
                {
                    StreamReader streamReader = new StreamReader(fileStream);
                    String parolfile = streamReader.ReadLine(); //������ ������ ������
                    if (parol.Equals(parolfile)) //���� ��������� ������ ������������ ������������ �� �����
                    {
                        // �� ������������
                        Form2 form2 = new Form2(); 
                        this.Hide();
                        form2.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        label3.Text = "������ �� ���������!";
                    }

                }
            }
            else // ���� ������ ����� �� ����������, �� ������� ��� � ������������
            {
                using (FileStream fileStream = new FileStream(file, FileMode.Create))
                {
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.AutoFlush = true;
                    streamWriter.WriteLine(textBox2.Text);
                    //������������
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