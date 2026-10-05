namespace Personalregister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String? input = "";
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
                            PrintPerson(person);
                        }
                        continue;
                    case "2":
                        if (persons.Count == 0)
                        {
                            Console.WriteLine("Inga personer att visa.");
                        }
                        else
                        {
                            PrintStaff(persons);
                        }
                        continue;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ogiltig inmatning. Försök igen.");

                        continue;
                }

            }



        }

        static Person? AddPerson()
        {
            Person person = new();
            bool isValid = false;
            Step currentStep = Step.Name;
            Console.WriteLine("Ange för och Efternamn");
            String? input = Console.ReadLine();

            while (input != "exit" || !isValid)
            {
                if(input == null)
                {
                    Console.WriteLine("Ogiltig inmatning. Försök igen.");
                    input = Console.ReadLine();
                    continue;
                }
                switch (currentStep)
                {
                    case Step.Name:
                        String[] nameParts = input.Split(' ');

                        if (nameParts.Length != 2)
                        {
                            Console.WriteLine("Ogiltig inmatning. Ange både för och efternamn.");
                            input = Console.ReadLine();
                            continue;
                        }
                        person.FirstName = nameParts[0];
                        person.LastName = nameParts[1];
                        currentStep++;
                        continue;
                    case Step.Salary:
                        Console.WriteLine("Ange lön (heltal):");
                        input = Console.ReadLine();
                        if (!int.TryParse(input, out int salary) || salary < 0)
                        {
                            Console.WriteLine("Ogiltig inmatning. Ange en giltig lön (heltal).");
                            input = Console.ReadLine();
                            continue;
                        }
                        person.Salary = salary;
                        currentStep++;
                        continue;
                    case Step.Finished:
                        return person;
                    default:
                        continue;
                }


            }

            return null;
        }

        static void PrintStaff(List<Person> persons)
        {
            foreach (var person in persons)
            {
                PrintPerson(person);
            }
        }


        static void PrintPerson(Person person)
        {
            Console.WriteLine($"Name: {person.FirstName} {person.LastName}, Lön: {person.Salary}");
        }


    }

    internal class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Salary { get; set; }
    }

    enum Step
    {
        Name = 1,
        Salary = 2,
        Finished = 3,
    }

}
