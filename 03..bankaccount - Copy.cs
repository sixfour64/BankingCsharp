/* 
19 banking video lessons:  https://learn.microsoft.com/en-us/shows/csharp-101/?wt.mc_id=educationalcsharp-c9-scottha
banking follow along docs:  https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/classes

banking's new/follow-on-next Lessons:  Object-Oriented programming (C#)  docs https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop
all bankings code examples are on MS's github @   https://github.com/dotnet/docs/tree/main/docs/csharp/fundamentals/tutorials/snippets/object-oriented-programming

each time at KR:
get .Net SDK 7.0 installer  https://dotnet.microsoft.com/en-us/download/dotnet/sdk-for-vs-code?utm_source=vs-code&amp;utm_medium=referral&amp;utm_campaign=sdk-install
install the MS plug in 'ms-dotnettools.csharp' to Visual Studio code 
*/

using System;
using System.Collections.Generic;  // used for System.Text.StringBuilder  in GetAccountHistory()
using System.Text;


namespace MySuperBank
  {
  
class Program
	{ // start class Program
    
    static void Main (string[] args)
      {//start Method
        var account = new BankAccount("Lee money", 4444);
        Console.WriteLine($"Account# {account.Number} was created for {account.Owner} with $ {account.Balance}\n.");
                
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
    account.MakeWithdrawal(75000, DateTime.Now, "Attempt to overdraw");
	}
catch (InvalidOperationException e)
	{
    Console.WriteLine("\n.Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
	}

//  to test these changes for the GiftCardAccount and the InterestEarningAccoun
var giftCard = new GiftCardAccount("gift card", 100, 50);
giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransactions();
// can make additional deposits:
giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
Console.WriteLine(giftCard.GetAccountHistory());

var savings = new InterestEarningAccount("savings account", 10000);
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
savings.PerformMonthEndTransactions();
Console.WriteLine(savings.GetAccountHistory());


 
    }  // end Main method
}  // end class Program


public class BankAccount
  {  // start Class
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
    
    private static int accountNumberSeed = 1234567890;
    
    private List<Transaction> allTransactions = new List<Transaction>(); // gathers up all txs into a List


public BankAccount(string name, decimal initialBalance)
	{  //start Method
		{
    this.Owner = name;
    this.Number = accountNumberSeed.ToString();
    accountNumberSeed++;
    MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
		}
    }// end Method


public void MakeDeposit(decimal amount, DateTime date, string note)
	{//start Method
    if (amount <= 0)
 		   {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
 		   }
    var deposit = new Transaction(amount, date, note);
    allTransactions.Add(deposit);
	} // end Method


public void MakeWithdrawal(decimal amount, DateTime date, string note)
	{ //start Method
    if (amount <= 0)
  	  {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
  	  }
    if (Balance - amount < 0)
   	 {
        throw new InvalidOperationException("Insufficient funds for this withdrawal");
 	   }
    var withdrawal = new Transaction(-amount, date, note);
    allTransactions.Add(withdrawal);
	} // end Method
  
  
public string GetAccountHistory()
	{//start Method
    var report = new System.Text.StringBuilder();

    decimal balance = 0;
    report.AppendLine("\nDate\t\tAmount\tBalance\tNote\t\t\t account's tx history");
    foreach (var item in allTransactions)
  	  {
        balance += item.Amount;
        report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
}
    return report.ToString();
	} // end Method


//  virtual method for 03.02.cs,  03.03.cs,  03.04.cs 
public virtual void PerformMonthEndTransactions() { }  


// public BankAccount(string name, decimal initialBalance)



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



}  // namespace end