// See https://aka.ms/new-console-template for more information
using Aves;

var pinguino = new Pinguino(5);
var aguila = new Aguila(10, 100);

Printer.PrintAve(pinguino);
Printer.PrintAve(aguila);
Printer.PrintAveVoladora(aguila);
Printer.PrintAveNoVoladora(pinguino);

Console.WriteLine("\nHello, World!");

Console.WriteLine("\nExtension methods");

var a = new int[]{1, 2, 3, 4, 5, 6, 7, 8};
var result = a.Where(x=> x % 2 == 0 && x.Between(4,6));

foreach(var x in result){
    Console.WriteLine(x);
}

Console.WriteLine("\nDelegados");

var operationsList = new List<PerformOperation> { 
    (a, b) => a + b, 
    (a, b) => a - b, 
    (a, b) => a * b, 
    (a, b) => a / b 
};

foreach(var operation in operationsList){
    Console.WriteLine(operation(2,2));
}

//Clousure --> Crea una instancia con los parámetros de la primera invocación y devuelve otra función, la cual tiene acceso a los parámetros
Func<int, Func<int, int>> clousure = (a) => (b) => a + b;

var obj = clousure(5);

Console.WriteLine("\nClousures");
Console.WriteLine(obj);
Console.WriteLine(obj(50));
Console.WriteLine(obj(5));

//Action
Action<DateTime,Action<object?>> printDate = (a,b)=>b(a);
printDate(DateTime.Now, Console.WriteLine);

//Records
Console.WriteLine("\nRecords");
var foo = new Foo("Pedro");
Console.WriteLine(foo.name);
var foo2 = new Foo("Pedro");
Console.WriteLine(foo == foo2);


//Yield e IEnumerable
Console.WriteLine("\nYield e IEnumerable");

var evenNumbers = Enumerable.Filter(a, n => n % 2 == 0);

foreach (int number in evenNumbers)
{
    Console.WriteLine(number);
}

public static partial class Enumerable {
    public static IEnumerable<int> Filter(this IEnumerable<int> src, Func<int, bool> condition){
        foreach(var value in src){
            if(condition(value)){
                yield return value;
            }
        }
    }
}

//Delegates
public delegate int PerformOperation (int a, int b);

//Extension methods
public static class ExtensionInteger{

    public static bool Between(this int src, int start, int end){
        return src >= start && src <= end;
    }
}

//Records
public readonly record struct Foo(string name);

