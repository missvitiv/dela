using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dela
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //что бы можно было вытащить из предыдущей формы данные из этой
        //https://www.cyberforum.ru/windows-forms/thread110436.html#a_Q2
        public string Opisanie
        {
            get
            {
                return richTextBox1.Text;
            }
        }

        public DateTime Date
        {
            get
            {
                return dateTimePicker1.Value;
            }
        }

    }
}
