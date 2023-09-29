namespace ProjektArbere
{
    internal class Program
    {
           static string[] users = new string[] { "hans", "greta", "görgen", "frans", "lina", "tage" };
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
            bool located = false;
            int tries = 0; 
            for (int i = 0; i < users.Length; i++)
            {

                if (users[i] == userName)
                {
                    Console.WriteLine($"Hej och välkommen {users[i]}");
                    located = true;
                }
            }

             if (!located)
            {
                Console.WriteLine($"Tyvärr har vi ingen med namnet som {userName} kund här");
            }   


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