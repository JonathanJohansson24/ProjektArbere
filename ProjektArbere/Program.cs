using System.ComponentModel.Design;

namespace ProjektArbere
{
    internal class Program
    {
        static List<double> hansSavingsAccount = new List<double>();
        static List<double> hansFoodAccount = new List<double>();
        static List<double> hansTravelAccount = new List<double>();
        static List<double> gretasCheckingAccount = new List<double>();
        static List<double> gretasSavingsAccount = new List<double>();
        static List<double> görgensSavingsAccount = new List<double>();
        static List<double> görgensHealthAccount = new List<double>();
        static List<double> görgensWildlifeAccount = new List<double>();
        static List<double> fransCheckingAccount = new List<double>();
        static List<double> fransBowlingAccount = new List<double>();
        static List<double> tagesCheckingAccount = new List<double>();
        static List<double> tagesGolfAccount = new List<double>();
        static string[] users = new string[] { "hans", "greta", "görgen", "frans", "tage" };
        static int[] codes = new int[] { 1177, 2323, 4455, 9900, 8585 };

        static void Main(string[] args)
        {
            bool keepGoing = true;
            AddFunds();
            
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

            int pinCode = 0;

            Console.WriteLine("Nu vill jag att du matar in din tillhörande pinkod till ditt konto, du har 3 försök på dig");
            Console.Write("Skriv in kod: ");
            while (tries < 3)
            {
                try
                {

                    int userIndex = Array.IndexOf(users, userName);
                    pinCode = Convert.ToInt32(Console.ReadLine());
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
                catch
                {
                    Console.WriteLine("Var vänlig skriv endast in siffror: ");
                }

            }
            MainMenu(userName, pinCode);

        }
        static void MainMenu(string userName, int pinCode)
        {
            bool userOptions = false;
            while (!userOptions)
            {

                Console.WriteLine("1. Se dina konton och saldo \n2. Överföring mellan konton \n3. Ta ut pengar \n4. Logga ut");
                try
                {
                    Console.WriteLine("Var god välj en siffra, 1-4");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            UserAccounts(userName);
                            break;

                        case 2:
                            TransferFunds();
                            break;

                        case 3:
                            WithdrawFunds(userName, pinCode);
                            break;

                        
                        case 4:
                            Console.WriteLine("Nu kommer du tillbaka till inloggningssidan");
                            userOptions = true;
                            break;


                        default:
                            Console.WriteLine("Var god välj en siffra");
                            break;

                    }

                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Var god mata in något");
                }


            }
        }
        static void UserAccounts(string userName)
        {
            if (userName == "hans")
            {
                Console.WriteLine("Det finns tre konton i ditt namn, ett sparkonto, ett matkonto och ett reskonto.");
                Console.WriteLine("Vill du se saldot för \n1: Sparkonto. \n2: Lönekonto \n3: Resekonto");
                Console.WriteLine("Var god välj 1, 2 eller 3.");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.WriteLine("Sparkonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {hansSavingsAccount.Sum()}kr");

                    }
                    if (userChoice == 2)
                    {
                        Console.WriteLine("Matkonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {hansFoodAccount.Sum()}kr");

                    }
                    if (userChoice == 3)
                    {
                        Console.WriteLine("Resekonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {hansTravelAccount.Sum()}kr");
                    }
                }
                catch
                {
                    Console.WriteLine("Mata in 1, 2 eller 3.");
                }

            }
            if (userName == "greta")
            {
                Console.WriteLine("Det finns två konton i ditt namn, ett sparkonto och ett lönekonto.");
                Console.WriteLine("Vill du se saldot för \n1: Sparkonto. \n2: Lönekonto");
                Console.WriteLine("Var god välj 1 eller 2");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.WriteLine("Sparkonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {gretasSavingsAccount.Sum()}kr");

                    }
                    if (userChoice == 2)
                    {
                        Console.WriteLine("Lönekonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {gretasCheckingAccount.Sum()}kr");

                    }

                }
                catch
                {
                    Console.WriteLine("Mata in 1 eller 2.");
                }

            }
            if (userName == "görgen")
            {
                Console.WriteLine("Det finns tre konton i ditt namn, ett sparkonto, ett hälsovårdskonto och ett vildmarkskonto.");
                Console.WriteLine("Vill du se saldot för \n1: Sparkonto. \n2: Hälsovårdskonto \n3: Vildmarkskonto");
                Console.WriteLine("Var god välj 1, 2 eller 3.");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.WriteLine("Sparkonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {görgensSavingsAccount.Sum()}kr");

                    }
                    if (userChoice == 2)
                    {
                        Console.WriteLine("Hälsovårdskonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {görgensHealthAccount.Sum()}kr");

                    }
                    if (userChoice == 3)
                    {
                        Console.WriteLine("Vildmarkskonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {görgensWildlifeAccount.Sum()}kr");
                    }
                }
                catch
                {
                    Console.WriteLine("Mata in 1, 2 eller 3.");
                }

            }
            if (userName == "frans")
            {
                Console.WriteLine("Det finns två konton i ditt namn, ett lönekonto och ett bowling.");
                Console.WriteLine("Vill du se saldot för \n1: Lönekonto. \n2: Bowlingkonto");
                Console.WriteLine("Var god välj 1 eller 2");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.WriteLine("Lönekonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {fransCheckingAccount.Sum()}kr");

                    }
                    if (userChoice == 2)
                    {
                        Console.WriteLine("Lönekonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {fransBowlingAccount.Sum()}kr");

                    }

                }
                catch
                {
                    Console.WriteLine("Mata in 1 eller 2.");
                }
            }
            if (userName == "tage")
            {
                Console.WriteLine("Det finns två konton i ditt namn, ett lönekonto och ett golfkonto.");
                Console.WriteLine("Vill du se saldot för \n1: Lönekonto. \n2: Golfkonto");
                Console.WriteLine("Var god välj 1 eller 2");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.WriteLine("Lönekonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {tagesCheckingAccount.Sum()}kr");

                    }
                    if (userChoice == 2)
                    {
                        Console.WriteLine("Golfkonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {tagesGolfAccount.Sum()}kr");

                    }

                }
                catch
                {
                    Console.WriteLine("Mata in 1 eller 2.");
                }
            }
        }

        static void AddFunds()
        {
            hansFoodAccount.Add(10000);
            hansSavingsAccount.Add(15000);
            hansTravelAccount.Add(9000);
            gretasCheckingAccount.Add(13000);
            gretasSavingsAccount.Add(21000);
            görgensSavingsAccount.Add(75000);
            görgensHealthAccount.Add(8300);
            görgensWildlifeAccount.Add(6000);
            fransCheckingAccount.Add(8000);
            fransBowlingAccount.Add(9000);
            tagesCheckingAccount.Add(6500);
            tagesGolfAccount.Add(3500);
        }
        static void WithdrawFunds(string userName, int pinCode)
        {
            Console.WriteLine("Vilket konto vill du ta ut ifrån?\n\n1. Sparkonto.\n2. Lönekonto.");


            Console.WriteLine("Var god välj 1 eller 2.");

            try
            {
                int userChoice = Convert.ToInt32(Console.ReadLine());
                if (userChoice == 1)
                {
                    Console.WriteLine($"Sparkonto: \nDitt saldo är för nuvarande {tagesCheckingAccount.Sum()}kr\nHur mycket vill du ta ut?");

                    double withdrawal = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Var god skriv in din pinkod för att fullfölja uttaget");
                    int newPin = Convert.ToInt32(Console.ReadLine());
                    if (newPin == pinCode)
                    {
                        tagesCheckingAccount[0] -= withdrawal;
                        Console.WriteLine($"Du har valt att ta ut {withdrawal} ditt saldo är nu {tagesCheckingAccount.Sum()}");

                    }
                    else
                    {
                        Console.WriteLine("Tyvärr, det var fel pinkod.");
                    }



                }
                if (userChoice == 2)
                {
                    Console.WriteLine($"Sparkonto: \nDitt saldo är för nuvarande {tagesGolfAccount.Sum()}kr\nHur mycket vill du ta ut?");

                    double withdrawal = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Var god skriv in din pinkod för att fullfölja uttaget");
                    int newPin = Convert.ToInt32(Console.ReadLine());
                    if (newPin == pinCode)
                    {
                        tagesGolfAccount[0] -= withdrawal;
                        Console.WriteLine($"Du har valt att ta ut {withdrawal} ditt saldo är nu {tagesGolfAccount.Sum()}");

                    }
                    else
                    {
                        Console.WriteLine("Tyvärr, det var fel pinkod.");
                    }


                }
            }
            catch
            {
                Console.WriteLine("Mata in 1 eller 2.");
            }

        }
        static void TransferFunds()
        {

        }
    }
}
