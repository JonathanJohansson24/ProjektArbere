using System.ComponentModel.Design;
using System.Reflection.Metadata;

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

            ShowUsers();

            while (keepGoing)
            {

                DoesAccountExist();                                             // a method to control/login from the user to see if the account name and password is correct and existing


            }

        }



















        static void ShowUsers()
        {
            Console.WriteLine("Hej och välkommen till Bluff o båg Bank AB");                            // simple method that show up at the start of the program, showing all the available usernames
            Console.WriteLine("\n\nHär kommer en lista av alla användarnamn");
            foreach (string user in users)
            {
                Console.WriteLine($"\n\t\t{user}\n");
            }
            Console.WriteLine("\nValfritt knapptryck för att komma vidare.");
            Console.ReadKey();
        }
        static void DoesAccountExist()
        {
            Console.Clear();
            Console.WriteLine("Skriv ditt förnamn för att komma vidare: ");
            string userName = Console.ReadLine().ToLower();
            Console.Clear();
            bool userExists = false;
            int tries = 0;
            do
            {
                for (int i = 0; i < users.Length; i++)                                      // a for-loop that loops through the user checks if the input matches any of the name in the array of users.
                {                                                                           // if the user exists the bool sets to true and leaves the do-while loop
                    if (users[i] == userName)
                    {
                        Console.WriteLine($"Hej och välkommen {users[i]}");
                        userExists = true;
                        break;
                    }
                }

                if (!userExists)
                {
                    Console.WriteLine($"Tyvärr har vi ingen med namnet som {userName} kund här.\n Var vänlig testa igen");              // if the user tries to enter a username that doesnt exist this will happen
                    userName = Console.ReadLine().ToLower();
                }
            } while (!userExists);                                                                                                      //keeps the loop going until the user puts in a username that does exist

            int pinCode = 0;

            Console.WriteLine("Nu vill jag att du matar in din tillhörande pinkod till ditt konto, du har 3 försök på dig");
            Console.Write("Skriv in kod: ");
            while (tries < 3)                                       // a whileloop with 3 tries, if the users enters wrong password 3 times the program will shut down. 
            {
                try
                {

                    int userIndex = Array.IndexOf(users, userName);                                    // sort out the index of the users array that matches the userName so we can get the same index from
                    pinCode = Convert.ToInt32(Console.ReadLine());                                      // out int array - codes 
                    if (userIndex != -1 && pinCode == codes[userIndex])                                 // check if the userIndex isnt -1 cause i have nothing there, and then if pincode is the same location as 
                    {                                                                                   // codes and the user from the arrays
                        Console.Clear();
                        Console.WriteLine("Välkommen in, du skrev rätt pinkod");
                        break;
                    }

                    if (tries == 2)                                                                     // since i start the pincode at 0; I chose to have tries == 2 as the ending, cause in that case the user gets to try it 3 times before it shut down.
                    {
                        Console.WriteLine("Du skrev fel kod tre gånger, nu stängs programmet ner");
                        Environment.Exit(0);

                    }
                    else
                    {                                                                                     // adds the tries counter by one for each wrongful attempts at the password.
                        Console.WriteLine("Fel kod, försök igen:");
                        tries++;
                    }
                }
                catch
                {
                    Console.WriteLine("Var vänlig skriv endast in siffror: ");
                }

            }
            MainMenu(userName, pinCode);                                                                    // calls on the second method MainMenu()

        }
        static void MainMenu(string userName, int pinCode)
        {
            bool userOptions = false;
            while (!userOptions)
            {

                Console.WriteLine("\n1. Se dina konton och saldo \n2. Överföring mellan konton \n3. Ta ut pengar \n4. Logga ut\n");
                try
                {
                    Console.WriteLine("Var god välj en siffra, 1-4");                               // a simple switch case so the user can easily choose a number from 1-4 depending on what they want to do
                    int choice = Convert.ToInt32(Console.ReadLine());                               // depending on the choice all cases directs the user to a specific method 
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            UserAccounts(userName);                                                 // Check the account, what existing accounts are visible for the user thats logged in. 
                            break;

                        case 2:
                            Console.Clear();
                            TransferFunds(userName);                                                //Lets the user transfer money between their own accounts. 
                            break;

                        case 3:
                            Console.Clear();
                            WithdrawFunds(userName, pinCode);                                       //Lets the user withdraw money from any of the accounts of their choice. 
                            break;


                        case 4:
                            Console.Clear();
                            Console.WriteLine("Tryck på enter så kommer du tillbaka till startsidan");

                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }                   // a while-loop that only lets the user leave whenever they press ENTER
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
        {                                                               // depending on what name is logged in, the specific if case is chosen. 
            if (userName == "hans")
            {
                Console.WriteLine("Det finns tre konton i ditt namn, ett sparkonto, ett matkonto och ett reskonto.");           // lets the user see the various of accounts in their name, depending on what
                Console.WriteLine("Vill du se saldot för \n1: Sparkonto. \n2: Matkonto \n3: Resekonto");                        // account the user wants to see, it has to put in the correct number
                Console.WriteLine("Var god välj 1, 2 eller 3.");                                                                // and all users have the same logic, only thing that changes are the amount of accounts.

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Sparkonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {hansSavingsAccount.Sum()}kr");

                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Matkonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {hansFoodAccount.Sum()}kr");

                    }
                    if (userChoice == 3)
                    {
                        Console.Clear();
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
                        Console.Clear();
                        Console.WriteLine("Sparkonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {gretasSavingsAccount.Sum()}kr");

                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
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
                        Console.Clear();
                        Console.WriteLine("Sparkonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {görgensSavingsAccount.Sum()}kr");

                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Hälsovårdskonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {görgensHealthAccount.Sum()}kr");

                    }
                    if (userChoice == 3)
                    {
                        Console.Clear();
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
                        Console.Clear();
                        Console.WriteLine("Lönekonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {fransCheckingAccount.Sum()}kr");

                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
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
                        Console.Clear();
                        Console.WriteLine("Lönekonto: ");

                        Console.WriteLine($"Ditt saldo är för nuvarande {tagesCheckingAccount.Sum()}kr");

                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
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
        {                                                                                 //just did a bunch of adding to each list so they all had a value at the beginning of the program
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
        {                                                       // depending on what name is logged in, the specific if case is chosen. Same structure for all the users, just amounts of accounts and the name change.
            if (userName == "hans")
            {
                Console.WriteLine("Vilket konto vill du ta ut ifrån?\n\n1. Sparkonto.\n2. Resekonto. \n3. Matkonto");
                Console.WriteLine("Var god välj 1, 2 eller 3.");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine($"Sparkonto: \nDitt saldo är för nuvarande {hansSavingsAccount.Sum()}kr\nHur mycket vill du ta ut?"); // asks the user how much they wanna withdraw

                        double withdrawal = Convert.ToDouble(Console.ReadLine());
                        if (withdrawal <= hansSavingsAccount.Sum())                                                             //checks if the withdrawal is the same or lower then the total sum of the account, if thats true this will execute.
                        {

                            Console.WriteLine("Var god skriv in din pinkod för att fullfölja uttaget");         // the user has to use the correct pincode in order to confirm the withdrawal
                            int newPin = Convert.ToInt32(Console.ReadLine());                                   // if the user fails with the password, the users if returned to the loginsite.
                            if (newPin == pinCode)
                            {
                                hansSavingsAccount[0] -= withdrawal;
                                Console.WriteLine($"Du har valt att ta ut {withdrawal}kr, ditt saldo är nu {hansSavingsAccount.Sum()}");

                            }
                            else
                            {
                                Console.WriteLine("Tyvärr, det var fel pinkod.");
                            }
                        }
                        else if (withdrawal > hansSavingsAccount.Sum())                                         // and if the withdrawal is greater then the sum, nothing more will happend then a message
                        {                                                                                       // saying, "not enough funds" 
                            Console.WriteLine("Du kan inte ta ut mer än vad du har på kontot.");
                        }


                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine($"Resekonto: \nDitt saldo är för nuvarande {hansTravelAccount.Sum()}kr\nHur mycket vill du ta ut?");

                        double withdrawal = Convert.ToDouble(Console.ReadLine());

                        if (withdrawal <= hansTravelAccount.Sum())
                        {

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
                        else if (withdrawal > hansTravelAccount.Sum())
                        {
                            Console.WriteLine("Du kan inte ta ut mer än vad du har på kontot.");
                        }


                    }
                    if (userChoice == 3)
                    {
                        Console.Clear();
                        Console.WriteLine($"Matkonto: \nDitt saldo är för nuvarande {hansFoodAccount.Sum()}kr\nHur mycket vill du ta ut?");

                        double withdrawal = Convert.ToDouble(Console.ReadLine());

                        if (withdrawal <= hansFoodAccount.Sum())

                        {


                            Console.WriteLine("Var god skriv in din pinkod för att fullfölja uttaget");
                            int newPin = Convert.ToInt32(Console.ReadLine());
                            if (newPin == pinCode)
                            {
                                hansFoodAccount[0] -= withdrawal;
                                Console.WriteLine($"Du har valt att ta ut {withdrawal} ditt saldo är nu {hansFoodAccount.Sum()}");

                            }
                            else
                            {
                                Console.WriteLine("Tyvärr, det var fel pinkod.");
                            }
                        }
                        else if (withdrawal > hansFoodAccount.Sum())
                        {
                            Console.WriteLine("Du kan inte ta ut mer än vad du har på kontot.");
                        }

                    }
                }
                catch
                {
                    Console.WriteLine("Mata in 1, 2 eller 3.");
                }
            }
            if (userName == "greta")
            {
                Console.WriteLine("Vilket konto vill du ta ut ifrån?\n\n1. Sparkonto.\n2. Lönekonto.");
                Console.WriteLine("Var god välj 1 eller 2.");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine($"Sparkonto: \nDitt saldo är för nuvarande {gretasSavingsAccount.Sum()}kr\nHur mycket vill du ta ut?");

                        double withdrawal = Convert.ToDouble(Console.ReadLine());
                        if (withdrawal <= gretasSavingsAccount.Sum())
                        {

                            Console.WriteLine("Var god skriv in din pinkod för att fullfölja uttaget");
                            int newPin = Convert.ToInt32(Console.ReadLine());
                            if (newPin == pinCode)
                            {
                                gretasSavingsAccount[0] -= withdrawal;
                                Console.WriteLine($"Du har valt att ta ut {withdrawal} ditt saldo är nu {gretasSavingsAccount.Sum()}");

                            }
                            else
                            {
                                Console.WriteLine("Tyvärr, det var fel pinkod.");
                            }
                        }
                        else if (withdrawal > gretasSavingsAccount.Sum())
                        {
                            Console.WriteLine("Du kan inte ta ut mer än vad du har på kontot.");
                        }



                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine($"Lönekonto: \nDitt saldo är för nuvarande {gretasCheckingAccount.Sum()}kr\nHur mycket vill du ta ut?");

                        double withdrawal = Convert.ToDouble(Console.ReadLine());
                        if (withdrawal <= gretasCheckingAccount.Sum())
                        {

                            Console.WriteLine("Var god skriv in din pinkod för att fullfölja uttaget");
                            int newPin = Convert.ToInt32(Console.ReadLine());
                            if (newPin == pinCode)
                            {
                                gretasCheckingAccount[0] -= withdrawal;
                                Console.WriteLine($"Du har valt att ta ut {withdrawal} ditt saldo är nu {gretasCheckingAccount.Sum()}");

                            }
                            else
                            {
                                Console.WriteLine("Tyvärr, det var fel pinkod.");
                            }
                        }
                        else if (withdrawal > gretasCheckingAccount.Sum())
                        {
                            Console.WriteLine("Du kan inte ta ut mer än vad du har på kontot.");
                        }



                    }

                }
                catch
                {
                    Console.WriteLine("Mata in 1 eller 2");
                }
            }
            if (userName == "görgen")
            {
                Console.WriteLine("Vilket konto vill du ta ut ifrån?\n\n1. Sparkonto.\n2. Hälsokonto. \n3. Vildmarkskonto");
                Console.WriteLine("Var god välj 1, 2 eller 3.");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine($"Sparkonto: \nDitt saldo är för nuvarande {görgensSavingsAccount.Sum()}kr\nHur mycket vill du ta ut?");

                        double withdrawal = Convert.ToDouble(Console.ReadLine());
                        if (withdrawal <= görgensSavingsAccount.Sum())
                        {


                            Console.WriteLine("Var god skriv in din pinkod för att fullfölja uttaget");
                            int newPin = Convert.ToInt32(Console.ReadLine());
                            if (newPin == pinCode)
                            {
                                görgensSavingsAccount[0] -= withdrawal;
                                Console.WriteLine($"Du har valt att ta ut {withdrawal} ditt saldo är nu {görgensSavingsAccount.Sum()}");

                            }
                            else
                            {
                                Console.WriteLine("Tyvärr, det var fel pinkod.");
                            }
                        }
                        else if (withdrawal > görgensSavingsAccount.Sum())
                        {
                            Console.WriteLine("Du kan inte ta ut mer än vad du har på kontot.");
                        }




                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine($"Hälsokonto: \nDitt saldo är för nuvarande {görgensHealthAccount.Sum()}kr\nHur mycket vill du ta ut?");

                        double withdrawal = Convert.ToDouble(Console.ReadLine());
                        if (withdrawal <= görgensHealthAccount.Sum())
                        {
                            Console.WriteLine("Var god skriv in din pinkod för att fullfölja uttaget");
                            int newPin = Convert.ToInt32(Console.ReadLine());
                            if (newPin == pinCode)
                            {
                                görgensHealthAccount[0] -= withdrawal;
                                Console.WriteLine($"Du har valt att ta ut {withdrawal} ditt saldo är nu {görgensHealthAccount.Sum()}");

                            }
                            else
                            {
                                Console.WriteLine("Tyvärr, det var fel pinkod.");
                            }
                        }
                        else if (withdrawal > görgensHealthAccount.Sum())
                        {
                            Console.WriteLine("Du kan inte ta ut mer än vad du har på kontot.");
                        }


                    }
                    if (userChoice == 3)
                    {
                        Console.Clear();
                        Console.WriteLine($"Vildmarkskonto: \nDitt saldo är för nuvarande {görgensWildlifeAccount.Sum()}kr\nHur mycket vill du ta ut?");

                        double withdrawal = Convert.ToDouble(Console.ReadLine());
                        if (withdrawal <= görgensWildlifeAccount.Sum())
                        {

                            Console.WriteLine("Var god skriv in din pinkod för att fullfölja uttaget");
                            int newPin = Convert.ToInt32(Console.ReadLine());
                            if (newPin == pinCode)
                            {
                                görgensWildlifeAccount[0] -= withdrawal;
                                Console.WriteLine($"Du har valt att ta ut {withdrawal} ditt saldo är nu {görgensWildlifeAccount.Sum()}");

                            }
                            else
                            {
                                Console.WriteLine("Tyvärr, det var fel pinkod.");
                            }
                        }
                        else if (withdrawal > görgensWildlifeAccount.Sum())
                        {
                            Console.WriteLine("Du kan inte ta ut mer än vad du har på kontot.");
                        }


                    }
                }
                catch
                {
                    Console.WriteLine("Mata in 1, 2 eller 3.");
                }
            }
            if (userName == "frans")
            {
                Console.WriteLine("Vilket konto vill du ta ut ifrån?\n\n1. Lönekonto.\n2. Bowlingkonto.");
                Console.WriteLine("Var god välj 1 eller 2.");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine($"Lönekonto: \nDitt saldo är för nuvarande {fransCheckingAccount.Sum()}kr\nHur mycket vill du ta ut?");

                        double withdrawal = Convert.ToDouble(Console.ReadLine());
                        if (withdrawal <= fransCheckingAccount.Sum())
                        {
                            Console.WriteLine("Var god skriv in din pinkod för att fullfölja uttaget");
                            int newPin = Convert.ToInt32(Console.ReadLine());
                            if (newPin == pinCode)
                            {
                                fransCheckingAccount[0] -= withdrawal;
                                Console.WriteLine($"Du har valt att ta ut {withdrawal} ditt saldo är nu {fransCheckingAccount.Sum()}");
                            }
                            else
                            {
                                Console.WriteLine("Tyvärr, det var fel pinkod.");
                            }
                        }
                        else if (withdrawal > fransCheckingAccount.Sum())
                        {
                            Console.WriteLine("Du kan inte ta ut mer än vad du har på kontot.");
                        }



                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine($"Bowlingkonto: \nDitt saldo är för nuvarande {fransBowlingAccount.Sum()}kr\nHur mycket vill du ta ut?");

                        double withdrawal = Convert.ToDouble(Console.ReadLine());
                        if (withdrawal <= fransBowlingAccount.Sum())
                        {

                            Console.WriteLine("Var god skriv in din pinkod för att fullfölja uttaget");
                            int newPin = Convert.ToInt32(Console.ReadLine());
                            if (newPin == pinCode)
                            {
                                fransBowlingAccount[0] -= withdrawal;
                                Console.WriteLine($"Du har valt att ta ut {withdrawal} ditt saldo är nu {fransBowlingAccount.Sum()}");

                            }
                            else
                            {
                                Console.WriteLine("Tyvärr, det var fel pinkod.");
                            }
                        }
                        else if (withdrawal > fransBowlingAccount.Sum())
                        {
                            Console.WriteLine("Du kan inte ta ut mer än vad du har på kontot.");
                        }



                    }

                }
                catch
                {
                    Console.WriteLine("Mata in 1 eller 2");
                }
            }
            if (userName == "tage")
            {
                Console.WriteLine("Vilket konto vill du ta ut ifrån?\n\n1. Lönekonto.\n2. Golfkonto.");
                Console.WriteLine("Var god välj 1 eller 2.");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine($"Sparkonto: \nDitt saldo är för nuvarande {tagesCheckingAccount.Sum()}kr\nHur mycket vill du ta ut?");

                        double withdrawal = Convert.ToDouble(Console.ReadLine());
                        if (withdrawal <= tagesCheckingAccount.Sum())
                        {

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
                        else if (withdrawal > tagesCheckingAccount.Sum())
                        {
                            Console.WriteLine("Du kan inte ta ut mer än vad du har på kontot.");
                        }



                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine($"Golfkonto: \nDitt saldo är för nuvarande {tagesGolfAccount.Sum()}kr\nHur mycket vill du ta ut?");

                        double withdrawal = Convert.ToDouble(Console.ReadLine());
                        if (withdrawal <= tagesGolfAccount.Sum())
                        {

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
                        else if (withdrawal > tagesGolfAccount.Sum())
                        {
                            Console.WriteLine("Du kan inte ta ut mer än vad du har på kontot.");
                        }

                    }

                }
                catch
                {
                    Console.WriteLine("Mata in 1 eller 2");
                }
            }

        }
        static void TransferFunds(string userName)
        {                                                                   // depending on what name is logged in, the specific if case is chosen. commented the first account, all is basicly the same 
            if (userName == "hans")
            {
                Console.WriteLine("Vilket konto villför över ifrån?\n\n1. Sparkonto.\n2. Resekonto. \n3. Matkonto");
                Console.WriteLine("Var god välj 1, 2 eller 3.");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.Clear();                                                                                                            //show the total, and asks how much that the user wanna transfer
                        Console.WriteLine($"Sparkonto: \nDitt saldo är för nuvarande {hansSavingsAccount.Sum()}kr\nHur mycket vill du för över?");

                        double transfer = Convert.ToDouble(Console.ReadLine());


                        if (transfer <= hansSavingsAccount.Sum())                                           //as in the withdrawal method, checks if the transfer is equal to or less then the sum, in order to 
                        {                                                                                   // execute this sequence
                            hansSavingsAccount[0] -= transfer;                                              // removes the transfer sum from the account
                            Console.WriteLine($"Du har valt att föra över {transfer}kr, ditt saldo är nu {hansSavingsAccount.Sum()}");
                            Console.WriteLine("Till vilket konto vill du föra över? \n1. Resekonto. \n2. Matkonto");                // asks the user to wich account they wanna transfer the funds. 
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:                                                                                             // adds the transfer funds to the new account and show the sum of the new account
                                    hansTravelAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Resekontot är nu {hansTravelAccount.Sum()}");
                                    break;

                                case 2:
                                    hansFoodAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Matkontot är nu {hansFoodAccount.Sum()}");
                                    break;

                                default:
                                    Console.WriteLine("Välj 1 eller 2");
                                    break;

                            }


                        }
                        else if (transfer > hansSavingsAccount.Sum())
                        {
                            Console.WriteLine("Tyvärr, du har för lite pengar på kontot för att göra den överföringen.");
                        }




                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine($"Resekonto: \nDitt saldo är för nuvarande {hansTravelAccount.Sum()}kr\nHur mycket vill du för över?");

                        double transfer = Convert.ToDouble(Console.ReadLine());


                        if (transfer <= hansTravelAccount.Sum())
                        {
                            hansTravelAccount[0] -= transfer;
                            Console.WriteLine($"Du har valt att föra över {transfer}kr, ditt saldo är nu {hansTravelAccount.Sum()}");
                            Console.WriteLine("Till vilket konto vill du föra över? \n1. Sparkonto. \n2. Matkonto");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:

                                    hansSavingsAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Sparkontot är nu {hansSavingsAccount.Sum()}");
                                    break;
                                case 2:

                                    hansFoodAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Matkontot är nu {hansFoodAccount.Sum()}");
                                    break;
                                default:
                                    Console.WriteLine("Välj 1 eller 2.");
                                    break;
                            }
                        }
                        else if (transfer > hansTravelAccount.Sum())
                        {
                            Console.WriteLine("Tyvärr, du har för lite pengar på kontot för att göra den överföringen.");
                        }


                    }
                    else if (userChoice == 3)
                    {
                        Console.Clear();
                        Console.WriteLine($"Matkonto: \nDitt saldo är för nuvarande {hansFoodAccount.Sum()}kr\nHur mycket vill du för över?");

                        double transfer = Convert.ToDouble(Console.ReadLine());


                        if (transfer <= hansFoodAccount.Sum())
                        {
                            hansFoodAccount[0] -= transfer;
                            Console.WriteLine($"Du har valt att föra över {transfer}kr, ditt saldo är nu {hansFoodAccount.Sum()}");
                            Console.WriteLine("Till vilket konto vill du föra över? \n1. Sparkonto. \n2. Resekonto");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    hansSavingsAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Resekontot är nu {hansSavingsAccount.Sum()}");
                                    break;
                                case 2:
                                    hansTravelAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Resekontot är nu {hansTravelAccount.Sum()}");
                                    break;

                            }

                        }
                        else if (transfer > hansFoodAccount.Sum())
                        {
                            Console.WriteLine("Tyvärr, du har för lite pengar på kontot för att göra den överföringen.");
                        }

                    }
                }

                catch
                {
                    Console.WriteLine("Mata in 1, 2 eller 3.");
                }
            }
            if (userName == "greta")
            {
                Console.WriteLine("Vilket konto villför över ifrån?\n\n1. Sparkonto.\n2. Lönekonto.");
                Console.WriteLine("Var god välj 1 eller 2.");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine($"Sparkonto: \nDitt saldo är för nuvarande {gretasSavingsAccount.Sum()}kr\nHur mycket vill du för över?");

                        double transfer = Convert.ToDouble(Console.ReadLine());


                        if (transfer <= gretasSavingsAccount.Sum())
                        {
                            gretasSavingsAccount[0] -= transfer;
                            Console.WriteLine($"Du har valt att föra över {transfer}kr, ditt saldo är nu {gretasSavingsAccount.Sum()}");
                            Console.WriteLine("Till vilket konto vill du föra över? \n1. Lönekonto.");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    gretasCheckingAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Lönekontot är nu {gretasCheckingAccount.Sum()}");
                                    break;



                                default:
                                    Console.WriteLine("Välj siffran 1.");
                                    break;

                            }


                        }
                        else if (transfer > gretasSavingsAccount.Sum())
                        {
                            Console.WriteLine("Tyvärr, du har för lite pengar på kontot för att göra den överföringen.");
                        }




                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine($"Lönekonto: \nDitt saldo är för nuvarande {gretasCheckingAccount.Sum()}kr\nHur mycket vill du för över?");

                        double transfer = Convert.ToDouble(Console.ReadLine());


                        if (transfer <= gretasCheckingAccount.Sum())
                        {
                            gretasCheckingAccount[0] -= transfer;
                            Console.WriteLine($"Du har valt att föra över {transfer}kr, ditt saldo är nu {gretasCheckingAccount.Sum()}");
                            Console.WriteLine("Till vilket konto vill du föra över? \n1. Sparkonto.");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:

                                    gretasSavingsAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Sparkontot är nu {gretasSavingsAccount.Sum()}");
                                    break;

                                default:
                                    Console.WriteLine("Välj 1.");
                                    break;
                            }
                        }
                        else if (transfer > gretasCheckingAccount.Sum())
                        {
                            Console.WriteLine("Tyvärr, du har för lite pengar på kontot för att göra den överföringen.");
                        }


                    }

                }

                catch
                {
                    Console.WriteLine("Mata in 1 eller 2.");
                }
            }
            if (userName == "görgen")
            {
                Console.WriteLine("Vilket konto villför över ifrån?\n\n1. Sparkonto.\n2. Hälsokonto. \n3. Vildmarkskonto");
                Console.WriteLine("Var god välj 1, 2 eller 3.");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine($"Sparkonto: \nDitt saldo är för nuvarande {görgensSavingsAccount.Sum()}kr\nHur mycket vill du för över?");

                        double transfer = Convert.ToDouble(Console.ReadLine());


                        if (transfer <= görgensSavingsAccount.Sum())
                        {
                            hansSavingsAccount[0] -= transfer;
                            Console.WriteLine($"Du har valt att föra över {transfer}kr, ditt saldo är nu {görgensSavingsAccount.Sum()}");
                            Console.WriteLine("Till vilket konto vill du föra över? \n1. Hälsokonto. \n2. Vildmarkskonto");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    görgensHealthAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Resekontot är nu {görgensHealthAccount.Sum()}");
                                    break;

                                case 2:
                                    görgensWildlifeAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Vildmarkskontot är nu {görgensWildlifeAccount.Sum()}");
                                    break;

                                default:
                                    Console.WriteLine("Välj 1, 2 eller 3");
                                    break;

                            }


                        }
                        else if (transfer > görgensSavingsAccount.Sum())
                        {
                            Console.WriteLine("Tyvärr, du har för lite pengar på kontot för att göra den överföringen.");
                        }




                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine($"Hälsokonto: \nDitt saldo är för nuvarande {görgensHealthAccount.Sum()}kr\nHur mycket vill du för över?");

                        double transfer = Convert.ToDouble(Console.ReadLine());


                        if (transfer <= görgensHealthAccount.Sum())
                        {
                            görgensHealthAccount[0] -= transfer;
                            Console.WriteLine($"Du har valt att föra över {transfer}kr, ditt saldo är nu {görgensHealthAccount.Sum()}");
                            Console.WriteLine("Till vilket konto vill du föra över? \n1. Sparkonto. \n2. Vildmarkskonto");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:

                                    hansSavingsAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Sparkontot är nu {hansSavingsAccount.Sum()}");
                                    break;
                                case 2:

                                    görgensWildlifeAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Vildmarkskontot är nu {görgensWildlifeAccount.Sum()}");
                                    break;
                                default:
                                    Console.WriteLine("Välj 1 eller 2.");
                                    break;
                            }
                        }
                        else if (transfer > görgensHealthAccount.Sum())
                        {
                            Console.WriteLine("Tyvärr, du har för lite pengar på kontot för att göra den överföringen.");
                        }


                    }
                    if (userChoice == 3)
                    {
                        Console.Clear();
                        Console.WriteLine($"Vildmarkskonto: \nDitt saldo är för nuvarande {görgensWildlifeAccount.Sum()}kr\nHur mycket vill du för över?");

                        double transfer = Convert.ToDouble(Console.ReadLine());


                        if (transfer <= görgensWildlifeAccount.Sum())
                        {
                            görgensWildlifeAccount[0] -= transfer;
                            Console.WriteLine($"Du har valt att föra över {transfer}kr, ditt saldo är nu {görgensWildlifeAccount.Sum()}");
                            Console.WriteLine("Till vilket konto vill du föra över? \n1. Sparkonto. \n2. Hälsokonto");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    görgensSavingsAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Sparkontot är nu {görgensSavingsAccount.Sum()}");
                                    break;
                                case 2:
                                    görgensHealthAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Hälsokontot är nu {görgensHealthAccount.Sum()}");
                                    break;

                            }

                        }
                        else if (transfer > görgensWildlifeAccount.Sum())
                        {
                            Console.WriteLine("Tyvärr, du har för lite pengar på kontot för att göra den överföringen.");
                        }

                    }
                }

                catch
                {
                    Console.WriteLine("Mata in 1, 2 eller 3.");
                }
            }
            if (userName == "frans")
            {
                Console.WriteLine("Vilket konto villför över ifrån?\n\n1. Lönekonto.\n2. Bowlingkonto.");
                Console.WriteLine("Var god välj 1 eller 2.");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine($"Lönekonto: \nDitt saldo är för nuvarande {fransCheckingAccount.Sum()}kr\nHur mycket vill du för över?");

                        double transfer = Convert.ToDouble(Console.ReadLine());


                        if (transfer <= fransCheckingAccount.Sum())
                        {
                            fransCheckingAccount[0] -= transfer;
                            Console.WriteLine($"Du har valt att föra över {transfer}kr, ditt saldo är nu {fransCheckingAccount.Sum()}");
                            Console.WriteLine("Till vilket konto vill du föra över? \n1. Bowlingkonto");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    fransBowlingAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Bowlingkontot är nu {fransBowlingAccount.Sum()}");
                                    break;


                                default:
                                    Console.WriteLine("Välj 1.");
                                    break;

                            }


                        }
                        else if (transfer > fransCheckingAccount.Sum())
                        {
                            Console.WriteLine("Tyvärr, du har för lite pengar på kontot för att göra den överföringen.");
                        }




                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine($"Bowlingkonto: \nDitt saldo är för nuvarande {fransBowlingAccount.Sum()}kr\nHur mycket vill du för över?");

                        double transfer = Convert.ToDouble(Console.ReadLine());


                        if (transfer <= fransBowlingAccount.Sum())
                        {
                            fransBowlingAccount[0] -= transfer;
                            Console.WriteLine($"Du har valt att föra över {transfer}kr, ditt saldo är nu {hansTravelAccount.Sum()}");
                            Console.WriteLine("Till vilket konto vill du föra över? \n1. Lönekonto. ");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:

                                    fransCheckingAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Lönekontot är nu {fransCheckingAccount.Sum()}");
                                    break;

                                default:
                                    Console.WriteLine("Välj 1.");
                                    break;
                            }
                        }
                        else if (transfer > fransBowlingAccount.Sum())
                        {
                            Console.WriteLine("Tyvärr, du har för lite pengar på kontot för att göra den överföringen.");
                        }


                    }

                }

                catch
                {
                    Console.WriteLine("Mata in 1 eller 2.");
                }
            }
            if (userName == "tage")
            {
                Console.WriteLine("Vilket konto villför över ifrån?\n\n1. Lönekonto.\n2. Golfkonto.");
                Console.WriteLine("Var god välj 1 eller 2.");

                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine($"Lönekonto: \nDitt saldo är för nuvarande {tagesCheckingAccount.Sum()}kr\nHur mycket vill du för över?");

                        double transfer = Convert.ToDouble(Console.ReadLine());


                        if (transfer <= tagesCheckingAccount.Sum())
                        {
                            tagesCheckingAccount[0] -= transfer;
                            Console.WriteLine($"Du har valt att föra över {transfer}kr, ditt saldo är nu {tagesCheckingAccount.Sum()}");
                            Console.WriteLine("Till vilket konto vill du föra över? \n1. Golfkontot");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    tagesGolfAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Golfkontot är nu {tagesGolfAccount.Sum()}");
                                    break;


                                default:
                                    Console.WriteLine("Välj 1.");
                                    break;

                            }


                        }
                        else if (transfer > tagesCheckingAccount.Sum())
                        {
                            Console.WriteLine("Tyvärr, du har för lite pengar på kontot för att göra den överföringen.");
                        }




                    }
                    if (userChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine($"Golfkonto: \nDitt saldo är för nuvarande {tagesGolfAccount.Sum()}kr\nHur mycket vill du för över?");

                        double transfer = Convert.ToDouble(Console.ReadLine());


                        if (transfer <= tagesGolfAccount.Sum())
                        {
                            tagesGolfAccount[0] -= transfer;
                            Console.WriteLine($"Du har valt att föra över {transfer}kr, ditt saldo är nu {tagesGolfAccount.Sum()}");
                            Console.WriteLine("Till vilket konto vill du föra över? \n1. Lönekonto. ");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:

                                    tagesCheckingAccount[0] += transfer;
                                    Console.WriteLine($"Du har fört över {transfer}kr, ditt totalbelopp på Lönekontot är nu {tagesCheckingAccount.Sum()}");
                                    break;

                                default:
                                    Console.WriteLine("Välj 1.");
                                    break;
                            }
                        }
                        else if (transfer > tagesGolfAccount.Sum())
                        {
                            Console.WriteLine("Tyvärr, du har för lite pengar på kontot för att göra den överföringen.");
                        }


                    }

                }

                catch
                {
                    Console.WriteLine("Mata in 1 eller 2.");
                }
            }
        }
    }
}
