using System;
using System.Collections.Generic;

// video lessons:  https://learn.microsoft.com/en-au/shows/csharp-101/
// video's text chapters to follow along <online version>:  https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/
// video's text chapters to follow along <local to my PC version>: https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/arrays-and-collections
// start the online IDE via:  https://www.w3schools.com/cs/cs_compiler.php
// you usually want your file to have the same name as its main class.
// you can include constructors other than Main, see NLog below, for example.  Constructors must have the same name as the class or struct
// names of class should use PascalCase, names of variables should use camelCase
// you can pass an array of args as inputs to the Main() method when you start the .cs app from the command line/shell

namespace W3Schools
{

class NLog
{
    // Private Constructor:
    private NLog() { }
    public static double e = Math.E; 
    //2.71828...
}


class W3SchoolsPascalCase
  {
  
  // public static void Main(string[] args)
  public static void Main(string[] arrayname)
    {
      
       Console.WriteLine("e is: {0}\n.", NLog.e);
    
int a = 5;
int b = 6;
int c = 4;
if ((a + b + c > 10) && (a == b))
{
    Console.WriteLine("The answer is greater than 10");
    Console.WriteLine("And the first number is equal to the second\n.");
}
else
{
    Console.WriteLine("The answer is not greater than 10");
    Console.WriteLine("Or the first number is not equal to the second\n.");
}

int counter = 0;
while (counter < 4)
{
  Console.WriteLine($"Hello World! The counter is {counter}");
  counter = counter+1;
}

for (short counter2 = -32764; counter2 < 0; counter2--)
{
  System.Console.WriteLine($"Hello World! The counter is {counter2}");
}

var namesListOf = new List<string> {"dude","Ana", "Felipe"};
// You specify the type of the elements in the List<T> between the angle brackets.
// List<T> type can grow or shrink via add remove
// The List<T> enables you to reference individual items by index as well. You access items using the [ and ] tokens.

Console.WriteLine("\n.\nCapacity: {0}", namesListOf.Capacity);
Console.WriteLine("Count: {0}", namesListOf.Count);

int nameItemEnum = -1;
foreach (string nameItem in namesListOf)
{
nameItemEnum++;
Console.WriteLine($"foreach {nameItem} is index# {nameItemEnum}");
Console.WriteLine($"foreach {nameItem.ToUpper()}");
}

// int or var myindex = namesListOf.IndexOf("Ana");
// System.Int32 is longhand version of 'int'
System.Int32 myindex = namesListOf.IndexOf(namesListOf[0]);
Console.WriteLine($"The name {namesListOf[myindex]} is at index# {myindex}");
var notFound = namesListOf.IndexOf("Not Found");
Console.WriteLine($"When an item is not found, IndexOf returns {notFound}");

Console.WriteLine(".");
for (int countr = 0; countr < namesListOf.Count; countr++)
{
  Console.WriteLine($"for {namesListOf[countr]} is List's index# {countr}");
  Console.WriteLine($"for {namesListOf[countr].ToUpper()}!");
}

namesListOf.Clear();
int Cap=namesListOf.Capacity;
int Cnt=namesListOf.Count;
Console.WriteLine($".\ncapacity= {Cap}");
Console.WriteLine($"count= {Cnt}");

    }
  }
}