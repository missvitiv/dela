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
        private string opisanie; //описание
        private DateTime data;  //дата
        private string ispolnitel; // исполнитель
        private int status; //статус: 1 - Сделать 2 - в процессе 3 - Готово

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

    }
}
