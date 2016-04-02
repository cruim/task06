using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp
{
	delegate void IsComeIn(Person person, int time);

	delegate void IsGoAway(Person person);

	class Office
	{
		public event IsComeIn EmpoyerComeIn;
		public event IsGoAway EmployerGoAway;

		public void IsEmployerGoAway(Person person)
		{
			if (EmployerGoAway != null)
			{
				EmployerGoAway(person);
			}

		}

		public void IsEmpoyerComeIn(Person person, int time)
		{
			if (EmpoyerComeIn != null)
			{
				EmpoyerComeIn(person, time);
			}

		}

		public int Time { get; set; }

	}
}

