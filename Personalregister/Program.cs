namespace Personalregister
{
    internal class Program
    {
        static int personsPerPage = 20;

        static void Main()
        {
            string? input;
            bool exit = false;

            //List<Person> persons = [];


            List<Person> persons =
            [
                new Person("John", "Doe", 50000),
                new Person("Anna", "Andersson", 42000),
                new Person("Erik", "Svensson", 55000),
                new Person("Maria", "Johansson", 48000),
                new Person("Peter", "Karlsson", 62000),
                new Person("Lisa", "Nilsson", 39000),
                new Person("Johan", "Larsson", 51000),
                new Person("Emma", "Lindberg", 47000),
                new Person("Daniel", "Bergström", 58000),
                new Person("Sara", "Gustafsson", 45000),
                new Person("Mikael", "Persson", 53000),
                new Person("Sofia", "Olsson", 44000),
                new Person("Anders", "Lindström", 61000),
                new Person("Elin", "Hansson", 41000),
                new Person("Marcus", "Viklund", 57000),
                new Person("Julia", "Björk", 49000),
                new Person("Oscar", "Sandberg", 52000),
                new Person("Ida", "Lundberg", 46000),
                new Person("Fredrik", "Ekström", 59000),
                new Person("Karin", "Wallin", 43000),
                new Person("Victor", "Nyström", 64000),
                new Person("Malin", "Holm", 40000),
                new Person("Simon", "Bergman", 56000),
                new Person("Nina", "Forsberg", 47000),
                new Person("Robert", "Lund", 63000),
                new Person("Camilla", "Mattsson", 45000),
                new Person("Patrik", "Sjöberg", 54000),
                new Person("Therese", "Wikström", 48000),
                new Person("Niklas", "Ström", 60000),
                new Person("Louise", "Åkesson", 42000),
                new Person("Henrik", "Dahlberg", 51000),
                new Person("Frida", "Engström", 55000),
                new Person("Martin", "Norberg", 49000),
                new Person("Jenny", "Berg", 46000),
                new Person("Alexander", "Lind", 67000),
                new Person("Rebecca", "Edlund", 44000),
                new Person("Gustav", "Holmberg", 58000),
                new Person("Caroline", "Eklund", 53000),
                new Person("Sebastian", "Öberg", 62000),
                new Person("Hanna", "Rosén", 41000)
            ];

            while (!exit)
            {
                Console.WriteLine("Meny:");
                Console.WriteLine("1. Lägg till person");
                Console.WriteLine("2. Visa personer");
                Console.WriteLine("3. Redigera person");
                Console.WriteLine("4. Ta bort person");
                Console.WriteLine("5. Avsluta");
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
                            PrintPerson(person, first: true, underline: true);
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
                            SortStaff(persons, true);
                            Console.Clear();
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
                            SortStaff(persons);
                            SelectPersonToEdit(persons);
                        }
                        break;
                    case "4":
                        Console.Clear();
                        if (persons.Count == 0)
                        {
                            Console.WriteLine("Inga personer att visa.");
                        }
                        else
                        {
                            DeletePerson(persons);
                        }
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ogiltig inmatning. Försök igen.");

                        break;
                }

            }
        }

        static Person? AddPerson()
        {
            Console.Clear();
            Console.WriteLine("Ange för och Efternamn (skriv exit för att avbryta):");
            string? input = Console.ReadLine();
            string? firstName;
            string? lastName;
            int? salary;
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
                firstName = nameParts[0];
                lastName = nameParts[1];
                break;

            }

            Console.WriteLine("Ange lön (heltal, exit för att avsluta):");
            input = Console.ReadLine();

            while (true)
            {
                if (input == "exit") return null;

                if (!int.TryParse(input, out int salaryOut) || salaryOut < 0)
                {
                    Console.WriteLine("Ogiltig inmatning. Ange lön (heltal, exit för att avsluta):");
                    input = Console.ReadLine();
                    continue;
                }
                salary = salaryOut;

                if (salary.HasValue && firstName != null && lastName != null)
                {
                    Person person = new(firstName, lastName, salary.Value);

                    return person;
                }
                return null;
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
                Console.WriteLine("4. Backa");

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

        static void DeletePerson(List<Person> persons)
        {
            SortStaff(persons);
            Console.WriteLine("Välj person att ta bort (exit för att avbryta)");
            string? input = Console.ReadLine();
            if (input == "exit")
            {
                Console.Clear();
                return;
            }
            if (input != null && int.TryParse(input, out int idToDelete))
            {
                Person? person = persons.FirstOrDefault(p => p.ID == idToDelete);

                if (person == null)
                {
                    Console.Clear();
                    Console.WriteLine("Ingen person hittades med det ID:t.");
                    return;
                }

                Console.WriteLine($"Är du säker på att du vill ta bort {person.FirstName} {person.LastName}? (ja/nej)");
                string? confirmation = Console.ReadLine();
                if (confirmation != null && confirmation.ToLower() != "ja")
                {
                    Console.Clear();
                    Console.WriteLine("Borttagning avbruten.");
                    return;
                }
                persons.Remove(person);
                Console.Clear();
                Console.WriteLine($"Person borttagen: {person.FirstName} {person.LastName}, Lön: {person.Salary}, ID: {person.ID}");
                Console.WriteLine();
            }
        }
        static void SelectPersonToEdit(List<Person> persons, bool pauseAtEnd = false)
        {
            Console.WriteLine("Välj person att redigera (exit för att avbryta)");

            string? input = Console.ReadLine();
            if (input == "exit")
            {
                Console.Clear();
                return;
            }
            if (input != null && int.TryParse(input, out int idToEdit))
            {
                Person? person = persons.FirstOrDefault(p => p.ID == idToEdit);

                if (person == null)
                {
                    Console.Clear();
                    Console.WriteLine("Ingen person hittades med det ID:t.");
                    PrintStaff(persons, pauseAtEnd);
                    SelectPersonToEdit(persons, pauseAtEnd);
                    return;
                }

                EditPerson(person);
            }
            else
            {
                SelectPersonToEdit(persons, pauseAtEnd);
            }
        }

        static void SortStaff(List<Person> persons, bool pauseAtEnd = false)
        {
            Console.WriteLine("Sortera efter:");
            Console.WriteLine("1. Förnamn");
            Console.WriteLine("2. Efternamn");
            Console.WriteLine("3. Lön");
            Console.WriteLine("4. ID");
            string? input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":
                    persons.Sort((p1, p2) => string.Compare(p1.FirstName, p2.FirstName));
                    PrintStaff(persons, pauseAtEnd);
                    break;
                case "2":
                    persons.Sort((p1, p2) => string.Compare(p1.LastName, p2.LastName));
                    PrintStaff(persons, pauseAtEnd);
                    break;
                case "3":
                    persons.Sort((p1, p2) => p1.Salary.CompareTo(p2.Salary));
                    PrintStaff(persons, pauseAtEnd);
                    break;
                case "4":
                    persons.Sort((p1, p2) => p1.ID.CompareTo(p2.ID));
                    PrintStaff(persons, pauseAtEnd);
                    break;
                default:
                    Console.Clear();
                    SortStaff(persons, pauseAtEnd);
                    break;
            }
        }

        static void PrintStaff(List<Person> persons, bool pauseAtEnd = false)
        {
            int counter = 1;
            bool first = true;

            foreach (var person in persons)
            {
                PrintPerson(person, first, (counter == persons.Count || counter % personsPerPage == 0));
                first = false;
                if (counter % personsPerPage == 0 || counter >= persons.Count)
                {

                    if (counter < persons.Count)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta. x för att avsluta");

                        char key = Console.ReadKey(true).KeyChar;

                        if (key == 'x')
                        {
                            break;
                        }
                    } else if(pauseAtEnd)
                    {
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
                        Console.ReadKey(true);
                    }

                    if (counter < persons.Count)
                    {
                        Console.Clear();
                    }
                    first = true;
                }

                counter++;
            }
        }

        static void PrintPerson(Person person, bool first = false, bool underline = false)
        {
            string fullString;

            fullString = $"  {person.ID,-3}    {person.FirstName,-16} {person.LastName,-20} {person.Salary,-7}";

            if (first)
            {
                Console.WriteLine($"  {"ID",-3}    {"Förnamn",-16} {"Efternamn",-20} {"Lön",-7}");
                Console.WriteLine(new string('-', fullString.Length));
            }

            Console.WriteLine(fullString);

            if (underline)
                Console.WriteLine(new string('-', fullString.Length));
        }

    }

    internal class Person(string firstName, string lastName, int salary)
    {
        private static int nextId = 1;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public int Salary { get; set; } = salary;
        public int ID { get; } = nextId++;
    }

}
