namespace task_account
{

    public class Account
    {
        public string name { get; set; }
        public double balance { get; set; }


        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            this.name = name;
            this.balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
                balance += amount;
                return true;
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (balance - amount >= 0)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetBalance()
        {
            return balance;
        }

        public static Account operator+(Account lhs,Account rhs)
        {
            Account account = new (lhs.name+" "+rhs.name,lhs.balance+rhs.balance);
            return account;
        }
        public override string ToString()
        {
            return $"[Account: {name}: {balance}]";
        }
    }
    public static class AccountUtil
    {
        // Utility helper functions for Account class

        public static void Display(List<Account> accounts)
        {
            Console.WriteLine("\n=== Accounts ==========================================");
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc);
            }
        }

        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }

    }
    class SavingsAccount : Account
    {
        public int intRate { get; set; }
        //public SavingsAccount(Account account, int intRate=000) : base(account.name, account.balance)
        //{
        //    this.intRate = intRate;
        //}

        public SavingsAccount(string name = "Unnamed Account", double balance = 0.00, int intRate = 0) : base(name, balance)
        {
            this.intRate = intRate;
        }

        public override bool Deposit(double amount)
        {
            return base.Deposit(amount + intRate);
        }
 }

   class CheckingAccount : Account
   {
       // private const double fee = 1.50;
        public double fee { get; set; }
        //public CheckingAccount(Account account, double fee =1.50 ):base (account.name, account.balance)
        //{
        //   this.fee = 1.50;
        //}
        public CheckingAccount( string name = "Unnamed Account", double balance=0.00 , double fee=1.5 ): base ( name,balance) { }

        public override bool Withdraw(double amount)
        {// return base. base.Withdraw(amount+fee );
            base.Withdraw(amount);
            if (balance -amount+fee>0)
            {
                balance -= amount + fee;
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
    
    class TrustAccount : SavingsAccount
    {
        //public trustAccounts(savAccounts savee) : base(savee.name, savee.balance, savee.intRate)
        //{

        //}

        public TrustAccount(string name = "Unnamed Account", double balance=0.0000, int intRate=00) : base(name, balance, intRate)
        {

        }
        public override bool Deposit(double amount)
        {
           
            base.Deposit(amount);
            if (amount > 0)
            {
                if (amount>=5000)
                {
                    balance += amount + 50; 
                }
                else
                {
                    balance += amount;
                }
                return true;
            }
            else
            {
                Console.WriteLine("the OPeration fail \n");
                return false;
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {


            // Accounts
           var accounts = new List<Account>();
            //Account acount = new Acount();
            //accounts.Add(account);
            accounts.Add(new Account());
            accounts.Add(new Account("Larry"));
            accounts.Add(new Account("Moe", 2000));
            accounts.Add(new Account("Curly", 5000));

            AccountUtil.Display(accounts);
            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);
            //operator overloading 
            // var sumAcc = new List<Account>();
         
            Account acc3 = new Account( "Eng Ahmed", 2000) + new Account("Sherif", 5000) ;
            Console.WriteLine("Overload + operator in Account class (to sum the balances of two objects you will be create in Main)\n");
            Console.Write($" The TOtle name : {acc3.name} \n");
            Console.Write($" the Sum of Two Balance : {acc3.balance} \n") ;
            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);
            //Savings
           var savAccounts = new List<Account>();

            savAccounts.Add(new SavingsAccount());
            savAccounts.Add(new SavingsAccount("Superman"));
            savAccounts.Add(new SavingsAccount("Batman", 2000));
            savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5));

            AccountUtil.Display(savAccounts);
            AccountUtil.Deposit(savAccounts, 1000);
            AccountUtil.Withdraw(savAccounts, 2000);

            // Checking

            var checAccounts = new List<Account>();
            checAccounts.Add(new CheckingAccount());
            checAccounts.Add(new CheckingAccount("Larry2"));
            checAccounts.Add(new CheckingAccount("Moe2", 2000));
            checAccounts.Add(new CheckingAccount("Curly2", 5000));

            AccountUtil.Display(checAccounts);
            AccountUtil.Deposit(checAccounts, 1000);
            AccountUtil.Withdraw(checAccounts, 2000);
            AccountUtil.Withdraw(checAccounts, 2000);

            // Trust

            var trustAccounts = new List<Account>();
            trustAccounts.Add(new TrustAccount());
            trustAccounts.Add(new TrustAccount("Superman2"));
            trustAccounts.Add(new TrustAccount("Batman2", 2000));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5));

            AccountUtil.Display(trustAccounts);
            AccountUtil.Deposit(trustAccounts, 1000);
            AccountUtil.Deposit(trustAccounts, 6000);
            AccountUtil.Withdraw(trustAccounts, 2000);
            AccountUtil.Withdraw(trustAccounts, 3000);
            AccountUtil.Withdraw(trustAccounts, 500);

            Console.WriteLine();



        }
    }
}
