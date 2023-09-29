namespace ProjektArbere
{
    internal class Program
    {
           static string[] users = new string[] { "hans", "greta", "görgen", "frans", "tage"};
           static int[] codes = new int[5] { 1177, 2323, 4455, 9900, 8585 };

        static void Main(string[] args)
        {
            Console.WriteLine("Hej och välkommen till Bluff o båg Bank AB");

            DoesAccountExist();


        }




















        static void DoesAccountExist()
        {

            Console.WriteLine("Skriv ditt förnamn för att se om du har ett konto här: ");
            string userName = Console.ReadLine().ToLower();
            bool userExists = false;
            int tries = 0; 
            for (int i = 0; i < users.Length; i++)
            {

                if (users[i] == userName)
                {
                    Console.WriteLine($"Hej och välkommen {users[i]}");
                    userExists = true;
                }
            }
            if (!userExists)
            {
                Console.WriteLine($"Tyvärr har vi ingen med namnet som {userName} kund här");
            }   

            Console.WriteLine("Nu vill jag att du matar in din tillhörande pinkod till ditt konto, du har 3 försök på dig");
            
            while (tries < 3)
            {
                int userIndex = Array.IndexOf(users, userName);
                Console.Write("Skriv in kod: ");
                int pinCode = Convert.ToInt32(Console.ReadLine());
                if (userIndex != -1 && pinCode == codes[userIndex])
                {
                    Console.WriteLine("Välkommen in, du skrev rätt pinkod");
                }
                else
                {
                    Console.WriteLine("Fel kod, försök igen:");
                    tries++;
                }
            }
            Console.WriteLine("Du skrev fel kod tre gånger, nu stängs programmet ner");


        }
        static void MainMenu()
        {
            Console.WriteLine($@"1. Se dina konton och saldo
                                 2. Överföring mellan konton
                                 3. Ta ut pengar
                                 4. Logga ut");
            Console.WriteLine("Var god välj en siffra, 1-4");
            int choice = Convert.ToInt32( Console.ReadLine() );
            switch (choice)
            {
                case 1:

                    break;

                case 2:

                    break;

                case 3:

                    break;

                case 4:

                    break;

                default:
                    Console.WriteLine("Var god välj en siffra");
                    break;

            }


        }

    }
}