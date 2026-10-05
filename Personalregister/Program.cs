namespace Personalregister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? input;
            bool exit = false;

            List<Person> persons = [];

            while (!exit)
            {

                Console.WriteLine("Meny:");
                Console.WriteLine("1. Lägg till person");
                Console.WriteLine("2. Visa personer");
                Console.WriteLine("3. Avsluta");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Person? person = AddPerson();
                        if (person != null)
                        {
                            persons.Add(person);
                            Console.Clear();
                            PrintPerson(person);
                            Console.WriteLine();
                        }
                        break;
                    case "2":
                        if (persons.Count == 0)
                        {
                            Console.WriteLine("Inga personer att visa.");
                        }
                        else
                        {
                            Console.Clear();
                            PrintStaff(persons);
                            Console.WriteLine();
                        }
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ogiltig inmatning. Försök igen.");

                        break;
                }

            }



        }


        static Person? AddPerson()
        {
            Person person = new();
            Console.WriteLine("Ange för och Efternamn (exit för att avsluta):");
            string? input = Console.ReadLine();

            while (true)
            {
                if (input == "exit") return null;

                if (input == null)
                {
                    Console.WriteLine("Ogiltig inmatning. Försök igen.");
                    input = Console.ReadLine();
                    continue;
                }
                string[] nameParts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (nameParts.Length != 2)
                {
                    Console.WriteLine("Ogiltig inmatning. Ange både för och efternamn. (exit för att avsluta)");
                    input = Console.ReadLine();
                    continue;
                }
                person.FirstName = nameParts[0];
                person.LastName = nameParts[1];
                break;

            }

            Console.WriteLine("Ange lön (heltal, exit för att avsluta):");
            input = Console.ReadLine();

            while (true)
            {
                if (input == "exit") return null;

                if (!int.TryParse(input, out int salary) || salary < 0)
                {
                    Console.WriteLine("Ogiltig inmatning. Ange lön (heltal, exit för att avsluta):");
                    continue;
                }
                person.Salary = salary;
                return person;
            }

        }



        static void PrintStaff(List<Person> persons)
        {
            int counter = 1;
            foreach (var person in persons)
            {
                PrintPerson(person, counter++);
            }
        }


        static void PrintPerson(Person person, int? index = null)
        {
            if (index.HasValue)
            {
                Console.WriteLine($"{index.Value}: Name: {person.FirstName} {person.LastName}, Lön: {person.Salary}");
            }
            else
            {
                Console.WriteLine($"Name: {person.FirstName} {person.LastName}, Lön: {person.Salary}");
            }
        }


    }

    internal class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Salary { get; set; }
    }
}
