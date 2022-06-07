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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //глобальные переменные
        Delo tek_delo = new Delo(); // текущее дело
        List<Delo> ListDel = new List<Delo>(); // лист с делами
        public string Ispolnitel // исполнитель, под которым вошли
        {
            get
            {
                return Ispolnitel;
            }
            set
            {
                Ispolnitel = value;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //кнопка добавления дела
            Form3 form3 = new Form3();
            form3.Owner = this; // что бы потом с созданной формы вытащить из полей ввода текст
            form3.ShowDialog();
            if (form3.DialogResult == DialogResult.OK)
            {
                tek_delo.setDeloOpisanie(form3.Opisanie);
                tek_delo.setDate(form3.Date);
                tek_delo.setIspolnitel(Ispolnitel);
                tek_delo.setStatus(1); // статус новый
                ListDel.Add(tek_delo);
            }
        }
        private void otbrazit_dela()
        {
            foreach (Delo delo in ListDel)
            {
                if (delo.getStatus() == 1) checkedListBox1.Items.Insert(0,delo.getDeloOpisanie);
            }

        }
    }
}
