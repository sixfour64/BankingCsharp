/*
refers to Object-Oriented programming (C#)  docs https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop

An interest earning account  Will get a credit of 2% of the month-ending-balance.

using System;
using System.Collections.Generic;  // used for System.Text.StringBuilder  in GetAccountHistory()
using System.Text;

*/

using System;

namespace Banking
{

public class InterestEarningAccount : BankAccount
{ // start class InterestEarningAccount

// generates from base Class's constructor:  public BankAccount(string name, decimal initialBalance)
public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
    {
    }

public override void PerformMonthEndTransactions()
    {
    if (Balance > 500m)
        {
        decimal interest = Balance * 0.05m;
        MakeDeposit(interest, DateTime.Now, "apply monthly interest");

        }
    }

}// end class InterestEarningAccount
} // end namespace