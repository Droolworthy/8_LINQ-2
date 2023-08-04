//В нашей великой стране Арстоцка произошла амнистия!
//Всех людей, заключенных за преступление "Антиправительственное", следует исключить из списка заключенных.
//Есть список заключенных, каждый заключенный состоит из полей: ФИО, преступление.
//Вывести список до амнистии и после.
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ2
{
    internal class Program
    {
        static void Main()
        {
            Jail jail = new Jail();

            jail.Work();
        }
    }

    class Jail
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public Jail()
        {
            CreateCriminals();
        }

        public void Work()
        {
            bool isWork = true;

            string commandOutputListCriminals = "1";
            string commandExit = "2";
            string crime = "Антиправительственное";

            while (isWork)
            {
                Console.WriteLine($"Вывести список заключённых - {commandOutputListCriminals} \nВыход - {commandExit}");

                Console.Write("\nВвод: ");
                string userInput = Console.ReadLine();

                if (userInput == commandOutputListCriminals)
                {
                    Console.WriteLine("\nПреступники до амнистии:");

                    for (int i = 0; i < _criminals.Count; i++)
                    {
                        Console.WriteLine($"ФИО - {_criminals[i].FullName}, Преступление - {_criminals[i].Crime}");
                    }

                    _criminals = _criminals.Where(criminal => criminal.Crime != crime).ToList();

                    Console.WriteLine("\nПреступники после амнистии:");

                    foreach (var criminal in _criminals)
                    {
                        Console.WriteLine($"ФИО - {criminal.FullName}, Преступление - {criminal.Crime}");
                    }

                    Console.Write("\nДля продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (userInput == commandExit)
                {
                    isWork = false;
                }
                else
                {
                    Console.WriteLine("Ошибка. Попробуйте ещё раз.");
                }
            }
        }

        private void CreateCriminals()
        {
            _criminals.Add(new Criminal("Петров Петр Петрович", "Убийство"));
            _criminals.Add(new Criminal("Иванов Иван Иванович", "Убийство"));
            _criminals.Add(new Criminal("Гусева Екатерина Сергеевна", "Убийство"));
            _criminals.Add(new Criminal("Кузнецова Анна Денисовна", "Антиправительственное"));
            _criminals.Add(new Criminal("Орехов Дмитрий Викторович", "Антиправительственное"));
            _criminals.Add(new Criminal("Королёв Николай Сергеевич", "Антиправительственное"));
            _criminals.Add(new Criminal("Малышев Илья Николаевич", "Кража"));
            _criminals.Add(new Criminal("Целиков Павел Михайлович", "Кража"));
        }
    }

    class Criminal
    {
        public Criminal(string completeName, string offense)
        {
            FullName = completeName;
            Crime = offense;
        }

        public string FullName { get; private set; }
        public string Crime { get; private set; }
    }
}
