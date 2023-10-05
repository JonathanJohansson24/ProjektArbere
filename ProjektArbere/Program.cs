using System.ComponentModel.Design;

namespace ProjektArbere
{
    internal class Program
    {
        static List<double> checkingAccount = new List<double>();
        static List<double> savingsAccount = new List<double>();
        static string[] users = new string[] { "hans", "greta", "görgen", "frans", "tage" };
        static int[] codes = new int[5] { 1177, 2323, 4455, 9900, 8585 };

        static void Main(string[] args)
        {
            checkingAccount.Add(10000);
            savingsAccount.Add(15000);
            bool keepGoing = true;

            Console.WriteLine("Hej och välkommen till Bluff o båg Bank AB");
            while (keepGoing)
            {

                DoesAccountExist();


            }

        }




















        static void DoesAccountExist()
        {

            Console.WriteLine("Skriv ditt förnamn för att se om du har ett konto här: ");
            string userName = Console.ReadLine().ToLower();
            bool userExists = false;
            int tries = 0;
            do
            {
                for (int i = 0; i < users.Length; i++)
                {
                    if (users[i] == userName)
                    {
                        Console.WriteLine($"Hej och välkommen {users[i]}");
                        userExists = true;
                        break;
                    }
                }

                if (!userExists)
                {
                    Console.WriteLine($"Tyvärr har vi ingen med namnet som {userName} kund här.\n Var vänlig testa igen");
                    userName = Console.ReadLine().ToLower();
                }
            } while (!userExists);



            Console.WriteLine("Nu vill jag att du matar in din tillhörande pinkod till ditt konto, du har 3 försök på dig");

            while (tries < 3)
            {
                int userIndex = Array.IndexOf(users, userName);
                Console.Write("Skriv in kod: ");
                int pinCode = Convert.ToInt32(Console.ReadLine());
                if (userIndex != -1 && pinCode == codes[userIndex])
                {
                    Console.WriteLine("Välkommen in, du skrev rätt pinkod");
                    break;
                }

                if (tries == 2)
                {
                    Console.WriteLine("Du skrev fel kod tre gånger, nu stängs programmet ner");
                    Environment.Exit(0);

                }
                else
                {
                    Console.WriteLine("Fel kod, försök igen:");
                    tries++;
                }

            }
            MainMenu();

        }
        static void MainMenu()
        {
            bool userOptions = false;
            while (!userOptions)
            {

                Console.WriteLine("1. Se dina konton och saldo \n2. Överföring mellan konton \n3. Ta ut pengar \n4. Sätta in pengar  \n5. Logga ut");

                Console.WriteLine("Var god välj en siffra, 1-4");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        UserAccounts();
                        break;

                    case 2:
                        TransferFunds();
                        break;

                    case 3:
                        WithdrawFunds();
                        break;

                    case 4:
                        AddFunds();
                        break;
                    case 5:
                        Console.WriteLine("Nu kommer du tillbaka till inloggningssidan");
                        userOptions = true;
                        break;


                    default:
                        Console.WriteLine("Var god välj en siffra");
                        break;

                }


            }
        }
        static void UserAccounts()
        {
            Console.WriteLine("Det finns två konton i ditt namn, ett sparkonto och ett lönekonto.");
            Console.WriteLine("Vill du se saldot för \n1. Sparkonto. \n2. Lönekonto.");
            Console.WriteLine("Var god välj 1 eller 2.");

            try
            {
                int userChoice = Convert.ToInt32(Console.ReadLine());
                if (userChoice == 1)
                {
                    Console.WriteLine("Sparkonto: ");
                    double totalSavings = savingsAccount.Sum();
                    Console.WriteLine($"Ditt saldo är för nuvarande {totalSavings}kr");

                }
                if (userChoice == 2)
                {
                    Console.WriteLine("Lönekonto: ");
                    double totalCheckings = checkingAccount.Sum();
                    Console.WriteLine($"Ditt saldo är för nuvarande {totalCheckings}kr");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void AddFunds()
        {

        }
        static void WithdrawFunds()
        {

        }
        static void TransferFunds()
        {

        }
    }
}