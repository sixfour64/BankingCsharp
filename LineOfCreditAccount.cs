/*
refers to Object-Oriented programming (C#)  docs https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop

A line of credit accnt:
    Can have a negative balance, but not be greater in absolute value than the credit limit.
    Will incur an interest charge each month where the end of month balance isn't 0.
    Will incur a fee on each withdrawal that goes over the credit limit.

*/

using System;

namespace Banking
{
public class LineOfCreditAccount : BankAccount 
{

public LineOfCreditAccount(string name, decimal initialBalance) : base(name, initialBalance)  // generates from base Class's constructor:  public BankAccount(string name, decimal initialBalance)
  {
  }

public override void PerformMonthEndTransactions()
  {
    if (Balance < 0)
    {
        // Negate the balance to get a positive interest charge:
        decimal interest = -Balance * 0.07m;
        MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");

    }
  } // end method
  
 } // end class
} // end namespace