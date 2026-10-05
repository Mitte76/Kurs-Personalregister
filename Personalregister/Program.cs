namespace Personalregister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? input;
            bool exit = false;

            List<Person> persons = [new Person("John", "Doe", 50000)];

            while (!exit)
            {
                Console.WriteLine("Meny:");
                Console.WriteLine("1. Lägg till person");
                Console.WriteLine("2. Visa personer");
                Console.WriteLine("3. Editera person");
                Console.WriteLine("4. Avsluta");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Person? person = AddPerson();
                        if (person != null)
                        {
                            persons.Add(person);
                            Console.Clear();
                            Console.WriteLine("Person tillagd:");
                            PrintPerson(person, underline: true);
                            Console.WriteLine();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        if (persons.Count == 0)
                        {
                            Console.WriteLine("Inga personer att visa.");
                        }
                        else
                        {
                            PrintStaff(persons);
                            Console.WriteLine();
                        }
                        break;
                    case "3":
                        Console.Clear();
                        if (persons.Count == 0)
                        {
                            Console.WriteLine("Inga personer att visa.");
                        }
                        else
                        {
                            SelectPersonToEdit(persons);
                        }
                        break;
                    case "4":
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
            Console.Clear();
            Console.WriteLine("Ange för och Efternamn (skriv exit för att avbryta):");
            string? input = Console.ReadLine();

            while (true)
            {
                if (input == "exit")
                {
                    Console.Clear();
                    return null;
                }


                if (input == null)
                {
                    Console.WriteLine("Ogiltig inmatning. Ange både för och efternamn. (exit för att avsluta)");
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
                    input = Console.ReadLine();
                    continue;
                }
                person.Salary = salary;
                return person;
            }

        }

        static void SelectPersonToEdit(List<Person> persons)
        {

            Console.WriteLine("Välj person att editera (exit för att avbryta)");
            PrintStaff(persons);

            string? input = Console.ReadLine();
            if (input == "exit")
            {
                Console.Clear();
                return;
            }

            if (input != null && int.TryParse(input, out int numberToEdit))
            {
                Person person = persons[numberToEdit - 1];
                EditPerson(person);
            }
        }


        static void EditPerson(Person person)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vad vill du ändra?");
                Console.WriteLine($"1. Förnamn ({person.FirstName})");
                Console.WriteLine($"2. Efternamn ({person.LastName})");
                Console.WriteLine($"3. Lön ({person.Salary})");
                Console.WriteLine("4. Avbryt");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Ange nytt förnamn:");
                        input = Console.ReadLine();

                        if (input != "exit" && !string.IsNullOrWhiteSpace(input))
                            person.FirstName = input;

                        break;

                    case "2":
                        Console.WriteLine("Ange nytt efternamn:");
                        input = Console.ReadLine();

                        if (input != "exit" && !string.IsNullOrWhiteSpace(input))
                            person.LastName = input;

                        break;

                    case "3":
                        Console.WriteLine("Ange ny lön (heltal):");
                        input = Console.ReadLine();

                        if (input == "exit")
                            break;

                        if (int.TryParse(input, out int salary) && salary >= 0)
                        {
                            person.Salary = salary;
                        }
                        else
                        {
                            Console.WriteLine("Ogiltig inmatning. Lön ändrades inte.");
                        }

                        break;

                    case "4":
                        Console.Clear();
                        return;

                    default:
                        Console.WriteLine("Ogiltig inmatning. Ingen ändring gjordes.");
                        break;
                }
            }
        }

        static void PrintStaff(List<Person> persons)
        {
            int counter = 1;
            foreach (var person in persons)
            {
                PrintPerson(person, counter, counter == persons.Count);
                counter++;
            }
        }


        static void PrintPerson(Person person, int? index = null, bool underline = false)
        {

            string fullString = "";
            if (index.HasValue)
            {
                fullString = $"{index.Value}: Namn: {person.FirstName} {person.LastName}, Lön: {person.Salary}";
            }
            else
            {
                fullString = $"Namn: {person.FirstName} {person.LastName}, Lön: {person.Salary}";
            }

            if (underline)
            {
                Console.WriteLine(fullString);
                Console.WriteLine(new string('-', fullString.Length));
            }
            else
            {
                Console.WriteLine(fullString);
            }
        }


    }

    internal class Person
    {
        public Person(string firstName, string lastName, int salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }


        public Person()
        {
        }

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Salary { get; set; }
    }
}
