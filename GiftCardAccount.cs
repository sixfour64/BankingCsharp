/*
refers to Object-Oriented programming (C#)  docs https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop

A gift card account  Can be refilled with a specified amount once each month, on the last day of the month.
*/

using System;

namespace Banking
{

public class GiftCardAccount : BankAccount 
{  // start Class GiftCardAccount

public GiftCardAccount(string name, decimal initialBalance) : base(name, initialBalance)  // generates from base Class's constructor:  public BankAccount(string name, decimal initialBalance)
  {
  }

private readonly decimal _monthlyDeposit = 0m;
  
public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
    => _monthlyDeposit = monthlyDeposit;

public override void PerformMonthEndTransactions()
  {
    if (_monthlyDeposit != 0)
    {
      MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");  
    }
  }


} // end Class GiftCardAccount
} // end namespace