using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dela
{
    internal class Delo
    {
        //Каждое дело задается: текстовой описание, дата, исполнитель, статус (сделать, в процессе, готово).
        //поля
        private int ID; //индивидуальный номер каждого дела
        private string opisanie; //описание
        private DateTime data;  //дата
        private string ispolnitel; // исполнитель
        private int status; //статус: 1 - Сделать 2 - в процессе 3 - Готово
        //конструкторы
        public Delo(string opisanie, DateTime data, string ispolnitel, int status) //конструктор, если все поля заполнены
        {
            this.opisanie = opisanie;
            this.data = data;
            this.ispolnitel = ispolnitel;
            this.status = status;
        }
        public Delo() //конструктор, если поля не заполнены
        {
            this.opisanie = "дописать программу";
            this.data = DateTime.Now;
            this.ispolnitel = "Maria";
            this.status = 1;
        }
            //методы
            public int getDeloID()
        {
            return this.ID; //геттер, возвращает описание дела
        }
        public string getDeloOpisanie()
        {
            return this.opisanie; //геттер, возвращает описание дела
        }
        public DateTime getData()
        {
            return this.data; //геттер, возвращает дату
        }
        public string getIspolnitel()
        {
            return this.ispolnitel; //геттер, возвращает исполнителя
        }
        public int getStatus()
        {
            return this.status;//геттер, возвращает статус
        }

        public void setDeloID(int newID)
        {
            this.ID = newID; // сеттер, устанавливает ID
        }
        public void setDeloOpisanie(string newDeloOpisanie)
        {
            this.opisanie = newDeloOpisanie; // сеттер, устанавливает новое описание
        }
        public void setDate(DateTime newData)
        {
            this.data = newData; // сеттер, устанавливает дату
        }
        public void setIspolnitel(string newIspolnitel)
        { 
            this.ispolnitel = newIspolnitel; // сеттер, устанавливает исполнителя
        }
        public void setStatus(int newStatus)
        {
            this.status = newStatus; // сеттер, устанавливает статус
        }

    }
}
