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
        List<Delo> ListDel = new List<Delo>(); // лист с всеми делами
        public string Ispolnitel; // исполнитель, под которым вошли
        public string Parol; // пароль, под которым вошли


        private void button5_Click(object sender, EventArgs e)
        {
            //кнопка добавления дела
            Form3 form3 = new Form3();
            form3.Owner = this; // что бы потом с созданной формы вытащить из полей ввода текст
            form3.ShowDialog();
            if (form3.DialogResult == DialogResult.OK)
            {
                Delo delo = new Delo();
                delo.setDeloID(ListDel.Count+1);
                delo.setDeloOpisanie(form3.Opisanie);
                delo.setDate(form3.Date);
                delo.setIspolnitel(Ispolnitel);
                delo.setStatus(1); // статус новый
                ListDel.Add(delo);
                otbrazit_dela();
            }
        }
        private void otbrazit_dela()
        {
            //очищаем списки и заполняем их заново - метод
            listBox1.Items.Clear(); // список новые 
            listBox2.Items.Clear(); // список делаю 
            listBox3.Items.Clear(); // список готово 
            foreach (Delo delo in ListDel)
            {
                if (delo.getStatus() == 1) listBox1.Items.Add(delo.getDeloOpisanie());
                else if (delo.getStatus() == 2) listBox2.Items.Add(delo.getDeloOpisanie());
                else if (delo.getStatus() == 3) listBox3.Items.Add(delo.getDeloOpisanie());
            }           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //новое дело переместить в процессе
            if (listBox1.SelectedItem.ToString() != null) // если выбрана строка списка
            {
                String vibrDelo = listBox1.SelectedItem.ToString(); // берем текст выбранного пункта
                int nomerVibrDela = ListDel.FindIndex(item => item.getDeloOpisanie() == vibrDelo); //ищем номер дела по тексту
                ListDel[nomerVibrDela].setStatus(2); //задаем новый статус
                otbrazit_dela(); //перезаполняем списки
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // дело в процессе  переместить в новое
            if (listBox2.SelectedItem.ToString() != null) // если выбрана строка списка
            {
                String vibrDelo = listBox2.SelectedItem.ToString(); // берем текст выбранного пункта
                int nomerVibrDela = ListDel.FindIndex(item => item.getDeloOpisanie() == vibrDelo); //ищем номер дела по тексту
                ListDel[nomerVibrDela].setStatus(1); //задаем новый статус
                otbrazit_dela(); //перезаполняем списки
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // дело в процессе  переместить в готово
            if (listBox2.SelectedItem.ToString() != null) // если выбрана строка списка
            {
                String vibrDelo = listBox2.SelectedItem.ToString(); // берем текст выбранного пункта
                int nomerVibrDela = ListDel.FindIndex(item => item.getDeloOpisanie() == vibrDelo); //ищем номер дела по тексту
                ListDel[nomerVibrDela].setStatus(3); //задаем новый статус
                otbrazit_dela(); //перезаполняем списки
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // готовое дело переместить в процессе
            if (listBox3.SelectedItem.ToString() != null) // если выбрана строка списка
            {
                String vibrDelo = listBox3.SelectedItem.ToString(); // берем текст выбранного пункта
                int nomerVibrDela = ListDel.FindIndex(item => item.getDeloOpisanie() == vibrDelo); //ищем номер дела по тексту
                ListDel[nomerVibrDela].setStatus(2); //задаем новый статус
                otbrazit_dela(); //перезаполняем списки
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // удалить готовое дело
            if (listBox3.SelectedItem.ToString() != null) // если выбрана строка списка
            {
                String vibrDelo = listBox3.SelectedItem.ToString(); // берем текст выбранного пункта
                int nomerVibrDela = ListDel.FindIndex(item => item.getDeloOpisanie() == vibrDelo); //ищем номер дела по тексту
                ListDel.RemoveAt(nomerVibrDela); //удаляем
                otbrazit_dela(); //перезаполняем списки
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e) //когда программа закрывается
        {
            SohranitDela();
        }
        public void SohranitDela()
        {
            String file = Ispolnitel;
            file += ".txt";
            using (FileStream fileStream = new FileStream(file, FileMode.Open))
            {
                StreamWriter streamWriter = new StreamWriter(fileStream);
                //streamWriter.AutoFlush = true;
                streamWriter.WriteLine(Parol); // Пароль для входа
                streamWriter.WriteLine(ListDel.Count);//записываем число дел, нужно при чтении
                foreach (Delo delo in ListDel)
                {
                    if (delo.getDeloOpisanie() == "" || delo.getDeloOpisanie() == null) continue; //не записываем, если вдруг есть пустые дела 
                    streamWriter.WriteLine(delo.getDeloID());
                    streamWriter.WriteLine(delo.getDeloOpisanie());
                    streamWriter.WriteLine(delo.getData());
                    streamWriter.WriteLine(delo.getIspolnitel());
                    streamWriter.WriteLine(delo.getStatus());
                }
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
        public void ZagruzitDela()
        {
            String file = Ispolnitel;
            file += ".txt";
            string stroka; 
            using (FileStream fileStream = new FileStream(file, FileMode.Open))
            {
                StreamReader streamReader = new StreamReader(fileStream);
                stroka = streamReader.ReadLine(); //первая строка это пароль
                stroka = streamReader.ReadLine(); //вторая строка это число дел
                for (int i = 0; i <= Convert.ToInt32(stroka); i++)
                {
                    Delo delo = new Delo();
                    stroka = streamReader.ReadLine();
                    delo.setDeloID(Convert.ToInt32(stroka));
                    delo.setDeloOpisanie(streamReader.ReadLine());
                    delo.setDate(Convert.ToDateTime(streamReader.ReadLine()));
                    delo.setIspolnitel(streamReader.ReadLine());
                    delo.setStatus(Convert.ToInt32(streamReader.ReadLine()));
                    ListDel.Add(delo);
                    
                }
                streamReader.Close();
            }
            otbrazit_dela(); //перезаполняем списки
        }

    
    }
}
