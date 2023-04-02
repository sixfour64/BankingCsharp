/* 
19 banking video lessons:  https://learn.microsoft.com/en-us/shows/csharp-101/?wt.mc_id=educationalcsharp-c9-scottha
banking follow along docs:  https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/classes

banking's new/follow-on-next Lessons:  Object-Oriented programming (C#)  docs https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop
all bankings code examples are on MS's github @   https://github.com/dotnet/docs/tree/main/docs/csharp/fundamentals/tutorials/snippets/object-oriented-programming

each time at KR:
get .Net SDK 7.0 installer  https://dotnet.microsoft.com/en-us/download/dotnet/sdk-for-vs-code?utm_source=vs-code&amp;utm_medium=referral&amp;utm_campaign=sdk-install
install the MS plug in 'ms-dotnettools.csharp' to Visual Studio code 

dotnet run --project "/home/runner/CSharpReplitTemplate/BankAccount.csproj"
*/

global using System;
global using System.Collections.Generic;  // used for System.Text.StringBuilder  in GetAccountHistory()
global using System.Text;

namespace Banking
{

class Program
	{ // start class 
    
    static void Main (string[] args)
      {//start Method
Console.WriteLine ($".{Environment.NewLine}Hello World - BankAccount.cs{Environment.NewLine}."); 
        
var account = new BankAccount("Lee money", 456789);
        Console.WriteLine($"Account# {account.Number} was created for \"{account.Owner}\" with $ {account.Balance}\n.");
                
        // some sample tx's:
		account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
		Console.Write(account.Balance);Console.WriteLine(@"   account.MakeWithdrawal(500, DateTime.Now, ""Rent payment"");");

		account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
		Console.Write(account.Balance);Console.WriteLine(@"   account.MakeDeposit(100, DateTime.Now, ""Friend paid me back"");");
  
          Console.WriteLine(account.GetAccountHistory());
  

// Test that the initial balances must be positive.
BankAccount invalidAccount;

try
	{
    invalidAccount = new BankAccount("invalid", -55);
	}    
catch (ArgumentOutOfRangeException e)
	{
    Console.WriteLine("\n.Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
    return;
	}
  
Type obj1 = typeof(BankAccount); // ==> object
object o = invalidAccount;
Type obj2 = o.GetType();  
Console.WriteLine($"{Environment.NewLine}{obj1} is object's compile-time typeof()");
Console.WriteLine($"instance {o} is of GetType= {obj2}");
Console.WriteLine($"\ttypeof(object) refers to the compile-time container{Environment.NewLine}\tobj.GetType() refers to the run-time contents of that container");
  
  
// Test for a negative balance.
try
	{
    account.MakeWithdrawal(75000, System.DateTime.Now, "Attempt to overdraw");
	}
catch (InvalidOperationException e)
	{
    Console.WriteLine("\n.Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
	}

//  tx's to test the GiftCardAccount and the InterestEarningAccounts
var giftCard = new GiftCardAccount("gift card", 100, 50);
giftCard.MakeWithdrawal(20, System.DateTime.Now, "get expensive coffee");
giftCard.MakeWithdrawal(50, System.DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransactions();
// can make additional deposits:
giftCard.MakeDeposit(27.50m, System.DateTime.Now, "add some additional spending money");
Console.WriteLine(giftCard.GetAccountHistory());

var savings = new InterestEarningAccount("savings account", 10000);
savings.MakeDeposit(750, System.DateTime.Now, "save some money");
savings.MakeDeposit(1250, System.DateTime.Now, "Add more savings");
savings.MakeWithdrawal(250, System.DateTime.Now, "Needed to pay monthly bills");
savings.PerformMonthEndTransactions();
Console.WriteLine(savings.GetAccountHistory());


var lineOfCredit = new LineOfCreditAccount("line of credit", 55550, 2000);
// How much is too much to borrow?
lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
lineOfCredit.PerformMonthEndTransactions();
Console.WriteLine(lineOfCredit.GetAccountHistory());

        
Console.WriteLine($".{Environment.NewLine}--end of BankAccount.cs--{Environment.NewLine}");
        
    }  // end Main method
}  // end class BankAccountTX


public class BankAccount
  {  // start Class BankAccount
    public string Number { get; }
    public string Owner { get; set; }
	public decimal Balance
	{
    get
  	  {
        decimal balance = 0;
        foreach (var item in allTransactions)
        	{
            balance += item.Amount;
      		}
        return balance;
  	  }
	}
    
    private static int s_accountNumberSeed = 1234567890;
    
    private List<Transaction> allTransactions = new List<Transaction>(); // gathers up all txs into a List

    
// BankAccount constructors:
private readonly decimal _minimumBalance;

public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }
// The : this() expression calls the below constructor, the one with three parameters.

public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
{
    Number = s_accountNumberSeed.ToString();
    s_accountNumberSeed++;

    Owner = name;
    _minimumBalance = minimumBalance;
    if (initialBalance > 0)
        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
}
 
   
public void MakeDeposit(decimal amount, DateTime date, string note)
	{//start Method
    if (amount <= 0)
 		   {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
 		   }
    var deposit = new Transaction(amount, date, note);
    allTransactions.Add(deposit);
	} // end Method


// MakeWithdrawal method, updated for LineOfCreditAccount
public void MakeWithdrawal(decimal amount, DateTime date, string note)
{ //start Method
    if (amount <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
    }
    Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
    Transaction? withdrawal = new(-amount, date, note);
    _allTransactions.Add(withdrawal);
    if (overdraftTransaction != null)
        _allTransactions.Add(overdraftTransaction);
} // end Method

protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
{ // start Method
    if (isOverdrawn)
    {
        throw new InvalidOperationException("Not sufficient funds for this withdrawal");
    }
    else
    {
        return default;
    }
} // end Method
  
  
public string GetAccountHistory()
	{//start Method
    var report = new System.Text.StringBuilder();

    decimal balance = 0;
    report.AppendLine($"\nDate\t\tAmount\tBalance\tNote\t\t\t {Owner}'s tx history");
    foreach (var item in allTransactions)
  	  {
        balance += item.Amount;
        report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
}
    return report.ToString();
	} // end Method


//  virtual method for 03.02.cs,  03.03.cs,  03.04.cs 
public virtual void PerformMonthEndTransactions() { }  

} // end class BankAccount
 

public class Transaction
	{ // start class
    public decimal Amount { get; }
    public DateTime Date { get; }
    public string Notes { get; }

    public Transaction(decimal amount, DateTime date, string note)
 	   {
        this.Amount = amount;
        this.Date = date;
        this.Notes = note;
  	  }


	} // end class
  } // end namespace