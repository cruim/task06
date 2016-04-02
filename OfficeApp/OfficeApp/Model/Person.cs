using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp
{
	 class Person : IHallo, IGoodbye
	{
		public string name;
		public int time;
        public string Name { get; set; }
		public int Time { get; set; }

		public Person(string name)
		{
			Name = name;
		}

		 public Person(string name, int time)
		 {
			 Name = name;
			 Time = time;
		 }

		 public void IsComing(Person person, int time)
		 {
			 if (person.Time >= 12 & person.Time <= 17)
			 {
				 Console.WriteLine("Добрый день {0}, сказал {1}", person.Name, this.Name);
			 }
			 else if (person.Time >= 17 & person.Time <= 24)
			 {
				 Console.WriteLine("Добрый вечер {0}, сказал {1}", person.Name, this.Name);
			 }
			 else if (person.Time >= 5 & person.Time <= 11)
			 {
				 Console.WriteLine("Доброе утро {0}, сказал {1}", person.Name, this.Name);
			 }
             else if (person.Time >= 0 & person.Time <= 5)
			 {
				 Console.WriteLine("{0} ты на время смотрел, зачем пришел на работу, сказал {1}", person.Name, this.Name);
			 }
		 }

		 public void IsGoAway(Person person)
		 {
			 Console.WriteLine("Счастливо {0}, сказал {1}", person.Name, this.Name);
		 }

	     
	}
}
