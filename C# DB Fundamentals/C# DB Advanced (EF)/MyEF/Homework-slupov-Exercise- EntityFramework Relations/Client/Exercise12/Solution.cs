using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataBankSystem;
using Models.BankSystem;

namespace Client.Exercise12
{
    public class Solution
    {
        private static readonly BankSystemContext db = new BankSystemContext();
        private static string[] cmdTokens { get; set; }
        private static Customer LoggedIn { get; set; }
        private static Random rnd = new Random();
        private static Dictionary<string, byte> ValidCommands = new Dictionary<string, byte>()
        {
            {"Register", 4},
            {"Login", 3},
            {"Logout", 1},
            {"Add", 4},
            {"ListAccounts", 1},
            {"Deposit", 3},
            {"Withdraw", 3},
            {"DeductFee", 2},
            {"AddInterest", 2}
        };

        public static void Start()
        {
//            InitializeWindow();
            string cmd = Console.ReadLine();

            while (cmd != "Shutdown")
            {
                if (cmd == "")
                {
                    Console.Write("No input, try again: ");
                    cmd = Console.ReadLine();
                    continue;
                }
                cmdTokens = cmd.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                try
                {
                    //if the command name is valid but the parameter count is wrong
                    if (cmdTokens.Length != ValidCommands[cmdTokens[0]])
                    {
                        Console.WriteLine($"Invalid parameter count to command: {cmdTokens[0]}");
                        Console.Write("Try again: ");
                        cmd = Console.ReadLine();
                        continue;
                    }
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("The given command is not a valid one");
                }


                switch (cmdTokens[0])
                {
                    case "Register":
                        RegisterCustomer();
                        break;
                    case "Login":
                        Login();
                        break;
                    case "Logout":
                        Logout();
                        break;
                    case "Add":
                        switch (cmdTokens[1])
                        {
                            case "SavingAccount":
                                AddSavingAccount();
                                break;
                            case "CheckingAccount":
                                AddCheckingAccount();
                                break;
                        }
                        break;
                    case "ListAccounts":
                        ListAccounts();
                        break;
                    case "Deposit":
                        Deposit();
                        break;
                    case "Withdraw":
                        Withdraw();
                        break;
                    case "DeductFee":
                        DeductFee();
                        break;
                    case "AddInterest":
                        AddInterest();
                        break;
                    default:
                        Console.WriteLine("Incorrect command! ");
                        break;
                }
                Console.Write("Next command: ");
                cmd = Console.ReadLine();
            }
        }

        private static void InitializeWindow()
        {
            Console.WindowHeight = 20;
            Console.BufferHeight = 20;
            Console.WindowWidth = 100;
            Console.BufferWidth = 100;
            Console.CursorVisible = false;
        }

        private static void ListAllCustomers()
        {
            foreach (var cus in db.Customers.ToList())
            {
                Console.WriteLine(cus.Username);
            }
        }

        private static void RegisterCustomer()
        {
            Regex UsernameChecker = new Regex(@"^[a-zA-Z]{1}[a-zA-Z0-9]{2,}$");

            Regex LowerCaseChecker = new Regex(@"[a-z]");
            Regex UpperCaseChecker = new Regex(@"[A-Z]");
            Regex DigitChecker = new Regex(@"[0-9]");

            Regex EmailChecker =
                new Regex(
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            bool isPasswordValid = (Regex.IsMatch(cmdTokens[2], LowerCaseChecker.ToString()) &&
                                    Regex.IsMatch(cmdTokens[2], UpperCaseChecker.ToString()) &&
                                    Regex.IsMatch(cmdTokens[2], DigitChecker.ToString()));
            if (!isPasswordValid)
            {
                Console.WriteLine("Incorrect PASSWORD");
                return;
            }
            if (!Regex.IsMatch(cmdTokens[3], EmailChecker.ToString()))
            {
                Console.WriteLine("Incorrect EMAIL");
                return;
            }
            if (!Regex.IsMatch(cmdTokens[1], UsernameChecker.ToString()))
            {
                Console.WriteLine("Incorrect USERNAME");
                return;
            }

            try
            {
                db.Customers.Add(new Customer
                {
                    Username = cmdTokens[1],
                    //insert hashing algorithm when switch to byte[]
                    Password = cmdTokens[2],
                    Email = cmdTokens[3]
                });
                db.SaveChanges();
                Console.WriteLine($"{cmdTokens[1]} was registered in the system!");
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("duplicate"))
                {
                    Console.WriteLine("Username is already registered");
                }
            }
            catch (DbEntityValidationException ex)
            {
                Console.Write("DbEntityValidationException: ");
                foreach (var dbEntityValidationResult in ex.EntityValidationErrors)
                {
                    foreach (var validationError in dbEntityValidationResult.ValidationErrors)
                    {
                        Console.Write(validationError.ErrorMessage);
                        Console.WriteLine();
                    }
                }
            }
        }

        private static void Login()
        {
            string tempUsername = cmdTokens[1];
            if (db.Customers.Any(c => c.Username == tempUsername))
            {
                Customer temp = db.Customers.First(c => c.Username == tempUsername);
                if (temp.Password == cmdTokens[2])
                {
                    LoggedIn = temp;
                    Console.WriteLine($"Successfully logged in {LoggedIn.Username}");
                }
                else
                {
                    Console.WriteLine($"Invalid Password to Username: {temp.Username}");
                }
            }
            else
            {
                Console.WriteLine($"No such username in our database :(");
            }
        }

        private static void Logout()
        {
            if (LoggedIn == null)
            {
                Console.WriteLine("You need to log in first");
                return;
            }
            if (LoggedIn != null)
            {
                //dangling pointer or no?
                LoggedIn = null;
                Console.WriteLine("Loging out...");
            }
            else
            {
                Console.WriteLine("No logged in user at the moment");
            }
        }

        private static void AddSavingAccount()
        {
            if (LoggedIn == null)
            {
                Console.WriteLine("You need to log in first");
                return;
            }
            var randIBAN = GenerateIBAN();
            db.SavingAccounts.Add(new SavingAccount()
            {
                Balance = decimal.Parse(cmdTokens[2]),
                Interest = double.Parse(cmdTokens[3]),
                IBAN = randIBAN,
                Owner = LoggedIn
            });

            try
            {
                db.SaveChanges();
                Console.WriteLine($"Successfully added savings account with IBAN: {randIBAN}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private static void AddCheckingAccount()
        {
            if (LoggedIn == null)
            {
                Console.WriteLine("You need to log in first");
                return;
            }

            var randIBAN = GenerateIBAN();
            db.CheckingAccounts.Add(new CheckingAccount()
            {
                Balance = decimal.Parse(cmdTokens[2]),
                Fee = decimal.Parse(cmdTokens[3]),
                IBAN = randIBAN,
                Owner = LoggedIn
            });

            try
            {
                db.SaveChanges();
                Console.WriteLine($"Successfully added checking account with IBAN: {randIBAN}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string GenerateIBAN()
        {
            string result = "";
            for (int i = 0; i < 10; i++)
            {
                switch (rnd.Next(0, 2))
                {
                    case 0:
                        //digits
                        result += (char) rnd.Next(48, 58);
                        break;
                    case 1:
                        //uppercases
                        result += (char) rnd.Next(65, 91);
                        break;
                }
            }
            if (db.CheckingAccounts.Any(a => a.IBAN == result) || db.SavingAccounts.Any(a => a.IBAN == result))
            {
                GenerateIBAN();
            }
            return result;
        }

        /// <summary>
        /// lists accounts of currently logged in user
        /// </summary>
        private static void ListAccounts()
        {

            if (LoggedIn == null)
            {
                Console.WriteLine("You need to log in first");
                return;
            }

            //throws an exception TODO:FIX THIS ISSUE
            if (!db.SavingAccounts.Any(a => a.Owner.Username == LoggedIn.Username))
            {
                Console.WriteLine("Customer has no SAVING ACCOUNTS");
            }
            else
            {
                Console.WriteLine($"SAVING ACCOUNTS for {LoggedIn.Username}: ");
                foreach (var sa in db.SavingAccounts.Where(a => a.Owner.Username == LoggedIn.Username).OrderBy(a => a.IBAN))
                {
                    Console.WriteLine($"--IBAN: {sa.IBAN}");
                    Console.WriteLine($"--BALANCE: {sa.Balance}");
                    Console.WriteLine($"--INTEREST: {sa.Interest}");
                    Console.WriteLine(new string('+', 100));

                }
            }
            Console.WriteLine(new string('-', 100));

            if (!db.CheckingAccounts.Any(a => a.Owner.Username == LoggedIn.Username))
            {
                Console.WriteLine("Customer has no CHECKING ACCOUNTS");
            }
            else
            {
                Console.WriteLine($"CHECKING ACCOUNTS for {LoggedIn.Username}");
                foreach (var ca in db.CheckingAccounts.Where(a => a.Owner.Username == LoggedIn.Username).OrderBy(a => a.IBAN))
                {
                    Console.WriteLine($"--IBAN:{ca.IBAN}");
                    Console.WriteLine($"--Balance:{ca.Balance}");
                    Console.WriteLine($"--Fee:{ca.Fee}");
                    Console.WriteLine(new string('+',100));
                }
            }
        }

        private static void Deposit()
        {
            var accType = "";
            if (LoggedIn == null)
            {
                Console.WriteLine("You need to log in first!");
                return;
            }

            //does the Logged In user has such account
            if (
                !(LoggedIn.SavingAccounts.Any(a => a.IBAN != cmdTokens[1]) ||
                  LoggedIn.CheckingAccounts.Any(a => a.IBAN != cmdTokens[1])))
            {
                Console.WriteLine("User has no such account");
                return;
            }

            //determine account type
            accType = db.CheckingAccounts.Any(a => a.IBAN == cmdTokens[1]) ? "CheckingAccount" : "SavingAccount";

            switch (accType)
            {
                case "CheckingAccount":
                    var CAccount = db.CheckingAccounts.First(a => a.IBAN == cmdTokens[1]);
                    CAccount.Deposit(decimal.Parse(cmdTokens[2]));
                    Console.WriteLine($"Account {CAccount.IBAN} has a balance of {CAccount.Balance}");
                    break;
                case "SavingAccount":
                    var SAccount = db.SavingAccounts.First(a => a.IBAN == cmdTokens[1]);
                    SAccount.Deposit(decimal.Parse(cmdTokens[2]));
                    Console.WriteLine($"Account {SAccount.IBAN} has a balance of {SAccount.Balance}");
                    break;
                default:
                    Console.WriteLine("ERROR: Unknown account type");
                    return;
            }
        }

        private static void Withdraw()
        {
            var accType = "";
            if (LoggedIn == null)
            {
                Console.WriteLine("You need to log in first!");
                return;
            }

            //does the Logged In user has such account
            if (
                !(LoggedIn.SavingAccounts.Any(a => a.IBAN != cmdTokens[1]) ||
                  LoggedIn.CheckingAccounts.Any(a => a.IBAN != cmdTokens[1])))
            {
                Console.WriteLine("User has no such account");
                return;
            }

            //determine account type
            accType = db.CheckingAccounts.Any(a => a.IBAN == cmdTokens[1]) ? "CheckingAccount" : "SavingAccount";

            switch (accType)
            {
                case "CheckingAccount":
                    var CAccount = db.CheckingAccounts.First(a => a.IBAN == cmdTokens[1]);
                    CAccount.Withdraw(decimal.Parse(cmdTokens[2]));
                    Console.WriteLine($"Withdrawn from {CAccount.IBAN}. Current balance: {CAccount.Balance}");
                    break;
                case "SavingAccount":
                    var SAccount = db.SavingAccounts.First(a => a.IBAN == cmdTokens[1]);
                    SAccount.Withdraw(decimal.Parse(cmdTokens[2]));
                    Console.WriteLine($"Withdrawn from {SAccount.IBAN}. Current balance: {SAccount.Balance}");
                    break;
                default:
                    Console.WriteLine("ERROR: Unknown account type");
                    return;
            }
        }

        private static void DeductFee()
        {
            if (LoggedIn == null)
            {
                Console.WriteLine("You need to log in first!");
                return;
            }

            //does the Logged In user has such account
            if (!LoggedIn.CheckingAccounts.Any(a => a.IBAN == cmdTokens[1]))
            {
                Console.WriteLine("User has no such checking account");
                return;
            }

            var CAccount = db.CheckingAccounts.First(a => a.IBAN == cmdTokens[1]);
            CAccount.DeductFee();

            Console.WriteLine($"Deducted fee of {CAccount.IBAN}. Current balance: {CAccount.Balance}");
        }

        private static void AddInterest()
        {
            if (LoggedIn == null)
            {
                Console.WriteLine("You need to log in first!");
                return;
            }

            //does the Logged In user has such account
            if (!LoggedIn.SavingAccounts.Any(a => a.IBAN == cmdTokens[1]))
            {
                Console.WriteLine("User has no such saving account");
                return;
            }

            var SAccount = db.SavingAccounts.First(a => a.IBAN == cmdTokens[1]);
            SAccount.AddInterest();

            Console.WriteLine($"Added interest to {SAccount.IBAN}. Current balance: {SAccount.Balance}");
        }
    }
}