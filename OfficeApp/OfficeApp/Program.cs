using System;
using NLog;
using OfficeApp;

namespace OfficeApp
{
	class Program
	{
	    static void Main(string[] args)
	    {
			Logger logger = LogManager.GetCurrentClassLogger();
	        Office office = new Office();
	        Person firstPerson = new Person("Том");
	        Person secondPerson = new Person("Лео");
	        Person thirdPerson = new Person("Макс");

	        office.EmpoyerComeIn += firstPerson.IsComing;
	        office.EmployerGoAway += secondPerson.IsGoAway;
	        office.EmployerGoAway += thirdPerson.IsGoAway;
	        Console.WriteLine("Вводите время прихода работников использую целые числа от 0 до 24\n");
		    ConsoleKeyInfo cki;

	        try
	        {
	            Console.Write("Введите время прихода Тома: ");
                
	            bool isSuccessFirst = false;
	            //Обработчик допустимого времени для первого сотрудника
	            #region
	            while (!isSuccessFirst)
	            {
	                try
	                {
                         
	                    int first = Int32.Parse(Console.ReadLine());

	                    if (first >= 0 && first <= 24) // требуемое условие
	                    {
                            
	                        firstPerson.Time = first;
	                        isSuccessFirst = true;
	                    }
	                    else
	                    {
	                        Console.WriteLine("Введенное число не удовлетворяет критериям.");
							logger.Info("Попытка ввода некорректных данных в блоке второго сотрудника");
	                    }
	                }
	                catch (Exception e)
	                {
	                    Console.WriteLine(e.Message);
	                }
	            }
	            #endregion
	            Console.WriteLine("На работу пришел {0} в {1} часа(ов)", firstPerson.Name, firstPerson.Time);

	            Console.Write("\nВведите время прихода Лео: ");
	            bool isSuccessSecond = false;
	            //Обработчик допустимого времени для второго сотрудника
	            #region
	            while (!isSuccessSecond)
	            {
	                try
	                {

	                    int second = Int32.Parse(Console.ReadLine());

	                    if (second >= 0 && second <= 24) // требуемое условие
	                    {

	                        secondPerson.Time = second;
	                        isSuccessSecond = true;
	                    }
	                    else
	                    {
	                        Console.WriteLine("Введенное число не удовлетворяет критериям.");
							logger.Info("Попытка ввода некорректных данных в блоке вторго сотрудника");
	                    }
	                }
	                catch (Exception e)
	                {
	                    Console.WriteLine(e.Message);
	                }
	            }
	            #endregion
	            Console.WriteLine("На работу пришел {0} в {1} часа(ов)", secondPerson.Name, secondPerson.Time);
	            office.IsEmpoyerComeIn(secondPerson, secondPerson.Time);
                
	            office.EmpoyerComeIn += secondPerson.IsComing;
	            Console.Write("\nВведите время прихода Макса: ");
	            bool isSuccessThird = false;
	            //Обработчик допустимого времени для третьего сотрудника
	            #region
	            while (!isSuccessThird)
	            {
	                try
	                {

	                    int third = Int32.Parse(Console.ReadLine());

	                    if (third >= 0 && third <= 24) // требуемое условие
	                    {

	                        thirdPerson.Time = third;
	                        isSuccessThird = true;
	                    }
	                    else
	                    {
	                        Console.WriteLine("Введенное число не удовлетворяет критериям.");
							logger.Info("Попытка ввода некорректных данных в блоке третьего сотрудника");
	                    }
	                }
	                catch (Exception e)
	                {
	                    Console.WriteLine(e.Message);
	                }
	            }
	            #endregion
		        
	            Console.WriteLine("На работу пришел {0} в {1} часа(ов)", thirdPerson.Name, thirdPerson.Time);
	            office.IsEmpoyerComeIn(thirdPerson, thirdPerson.Time);

	            Console.WriteLine("\nДля того, чтобы сотрудник ушел с работы, нажмите Enter " +
	                              "\nили нажмите Esq для выхода из программы");
		        cki = Console.ReadKey(true);
		        if (cki.Key == ConsoleKey.Escape)
		        {
			        Environment.Exit(0);
		        }

	            Console.WriteLine("Том решил уйти с работы");
	            office.IsEmployerGoAway(firstPerson);
				cki = Console.ReadKey(true);
				if (cki.Key == ConsoleKey.Escape)
				{
					Environment.Exit(0);
				}
	            Console.WriteLine("\nЛео решил уйти с работы");
	            office.EmployerGoAway -= firstPerson.IsGoAway;
	            office.EmployerGoAway -= secondPerson.IsGoAway;
	            office.IsEmployerGoAway(secondPerson);
				cki = Console.ReadKey(true);
				if (cki.Key == ConsoleKey.Escape)
				{
					Environment.Exit(0);
				}
	            Console.WriteLine("\nМакс решил уйти с работы \nОфис пуст");
	            office.EmployerGoAway -= thirdPerson.IsGoAway;
	            office.IsEmployerGoAway(thirdPerson);
				cki = Console.ReadKey(true);
				if (cki.Key == ConsoleKey.Escape)
				{
					Environment.Exit(0);
				}
			}
	        catch (FormatException)
	        {
	            Console.WriteLine("Вводите только целые числа от 0 до 24");
	            Console.ReadLine();
	        }
	    }
	}
}
