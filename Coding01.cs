/* Use vscode.dev for quick edits online  GitHub, Azure Repos, and local files.  https://vscode.dev/
browser Extensions for Visual Studio Code @ https://marketplace.visualstudio.com/vscode
*/

// ++++++++++++++++++++
using System;
using System.Diagnostics;

class Coding01
{
    public static void Main()
{
int max = int.MaxValue;
int min = int.MinValue;
Console.WriteLine($"The range of integers is int.MinValue {min} to int.MaxValue {max}\n.");
int whatmax = max + 11;
int whatmin = min - 11;
Console.WriteLine($"An example of -ve overflow: {whatmin}");
Console.WriteLine($"An example of +ve overflow: {whatmax}\n.");

// outputs:
// The range of integers is int.MinValue -2147483648 to int.MaxValue 2147483647
// .
// An example of -ve overflow: 2147483637
// An example of +ve overflow: -2147483638
// .


// ++++++++++

decimal a = 19M;
decimal b = 23M;
decimal c = 9M;
decimal d = (a + b) / c;
Console.WriteLine($"decimal: {d}");

// outputs:  decimal: 4.6666666666666666666666666667

// decimal x = 1.0M;
// The M suffix on the numbers is how you indicate that a constant should use the decimal type. Otherwise, the compiler assumes the double type.
// You can use either a lower-case m or upper-case M as the literal suffix for a decimal.



double e = 19;
double f = 23;
double g = 9.137137137137137;
double h = (e + f) / g;
Console.WriteLine($"double: {h} <-limited to 14 decimal places\n.");

// outputs:
// double: 4.59662576687117 <-limited to 14 decimal places


// ++++++++++++++++++++++++


double doubthird = 1.0 / 3.0;
Console.WriteLine($"{doubthird}  native as double");

double decthird = 1.0 / 3.0;
decimal dec;
dec = (decimal) decthird;
Console.WriteLine($"{decthird}  cast to decimal");

double longthird = 1.0 / 3.0;
long lng;
lng = (long) longthird;
Console.WriteLine($"{longthird}  cast to long\n.");

// outputs:
// 0.333333333333333  native as double
// 0.333333333333333  cast to decimal
// 0.333333333333333  cast to long

// casting int to decimal, escape chars on console output.  a cast operation only temporarily treats a value as if it were a different data type
int first = 7;
int second = 5;
decimal quotient = (decimal)first / (decimal)second;
Console.WriteLine($"7 mod 5 is {{7%5}}{7%5} or {{first%second}} {first%second}");

/* outputs:
Decimal quotient: 1.3461538461538461538461538462
7 mod 5 is {7%5}2 or {first%second} 2
*/



// ++++++++++++++++

int max2 = int.MaxValue;
int min2 = int.MinValue;
Console.WriteLine($"The range of integers is int.MinValue {min2} to int.MaxValue {max2}");

float fmin = float.MinValue;
float fmax = float.MaxValue;
Console.WriteLine($"The range of float is float.MinValue {fmin} to float.MaxValue {fmax}");

double dmin = Double.MinValue;
double dmax = Double.MaxValue;
Console.WriteLine($"The range of double is Double.MinValue {dmin} to Double.MaxValue {dmax}");

decimal emax = decimal.MaxValue;
decimal emin = decimal.MinValue;
Console.WriteLine($"The range of decimal is decimal.MinValue {emin} to decimal.MaxValue {emax}");

short shmin = short.MinValue;
short shmax = short.MaxValue;
Console.WriteLine($"The range of short is short.MinValue {shmin} to short.MaxValue {shmax}");

long lmin = long.MinValue;
long lmax = long.MaxValue;
Console.WriteLine($"The range of long is long.MinValue {lmin} to long.MaxValue {lmax}\n.");

// outputs:
// The range of integers is int.MinValue -2147483648 to int.MaxValue 2147483647
// The range of float is float.MinValue -3.402823E+38 to float.MaxValue 3.402823E+38
// The range of double is Double.MinValue -1.79769313486232E+308 to Double.MaxValue 1.79769313486232E+308
// The range of decimal is decimal.MinValue -79228162514264337593543950335 to decimal.MaxValue 79228162514264337593543950335
// The range of short is short.MinValue -32768 to short.MaxValue 32767
// The range of long is long.MinValue -9223372036854775808 to long.MaxValue 9223372036854775807
// .
// +++++++++++++++

int a2 = 7;
int b2 = 4;
int c2 = 3;
int d2 = (a2 + b2) / c2;
Console.WriteLine($"int {d2}");
float e2 = 7;
float f2 = 4;
float g2 = 3;
float h2 = (e2 + f2) / g2;
Console.WriteLine($"float {h2}");
double i2 = 7;
double j2 = 4;
double k2 = 3;
double l2 = (i2+j2) / k2;
Console.WriteLine($"double {l2}");
decimal m2 = 7;
decimal n2 = 4;
decimal o2 = 3;
decimal p2 = (m2+n2) / o2;
Console.WriteLine($"decimal {p2}");
long q2 = 7;
long r2 = 4;
long s2 = 3;
long t2 = (q2+r2) / s2;
Console.WriteLine($"long {t2}\n.");

// outputs:
// int 3
// float 3.666667
// double 3.66666666666667
// decimal 3.6666666666666666666666666667
// long 3


// ++++++++++++++++++++


int a3 = 7;
int b3 = 4;
int c3 = 3;
int d3 = (a3 + b3) / c3;
int e3 = (a3 + b3) % c3;
int f3=a3+b3;
Console.WriteLine($"int quotient: {d3}");
Console.WriteLine($"int remainder: {e3}");
Console.WriteLine($"int fractional: {e3/f3}");
Console.WriteLine($"int fractional: {e3/c3}");
decimal g3 = 7;
decimal h3 = 4;
decimal i3 = 3;
decimal j3 = (g3+h3) / i3;
decimal k3 = (g3+h3) % i3;
decimal l3=g3+h3;
Console.WriteLine($"decimal quotient: {j3}");
Console.WriteLine($"decimal remainder: {k3}");
Console.WriteLine($"decimal fractional: {k3/l3}");
Console.WriteLine($"decimal fractional: {k3/i3}");

// outputs:
// int quotient: 3
// int remainder: 2
// int fractional: 0
// int fractional: 0
// decimal quotient: 3.6666666666666666666666666667
// decimal remainder: 2
// decimal fractional: 0.1818181818181818181818181818
// decimal fractional: 0.6666666666666666666666666667


// ++++++++++++++++++++++++

// Kon'nichiwa World
Console.WriteLine("\u3053\u3093\u306B\u3061\u306F World!");
var JP = "Japanese";
// To generate Japanese invoices:
// Nihon no seikyū-sho o seisei suru ni wa:
Console.Write ($"{JP} {Environment.NewLine}  \u65e5\u672c\u306e\u8acb\u6c42\u66f8\u3092 {Environment.NewLine}\t={Environment.NewLine}  \u751f\u6210\u3059\u308b\u306b\u306f  \uff1a\n");
// User command to run an application
Console.WriteLine(@"   c:\invoices\app.exe -j");

var newL = string.Format("Add a{0}new line{0}.", Environment.NewLine);
Console.WriteLine(newL);
// The advantage here is writing {0} every time we need a line break. 

/*outputs:
こんにちは World!
Japanese 
  日本の請求書を 
	=
  生成するには  ：
   c:\invoices\app.exe -j
Add a
new line.
*/


// ++++++++++++++++++++++++

object obj = "object obj";
Type obj1 = typeof(object); // ==> object
Type obj2 = obj.GetType();  // ==> string!
Console.WriteLine($"{Environment.NewLine}{obj}\t obj1 is {obj1}");
Console.WriteLine($"\t\t\t obj2 is {obj2}");
Console.WriteLine($"typeof(object) refers to the compile-time container{Environment.NewLine}obj.GetType() refers to the run-time contents of that container");

/*  outputs:
object obj	 obj1 is System.Object
			 obj2 is System.String
typeof(object) refers to the compile-time container
obj.GetType() refers to the run-time contents of that container
*/


// ++++++++++++++++++++++





// +++++++++++++++++++

}

}