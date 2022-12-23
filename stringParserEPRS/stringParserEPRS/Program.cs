

using stringParserEPRS;

ParserEngine pe = new ParserEngine();
var a =  pe.Parse("5-31-2022AB.csv");

Console.WriteLine(a.Item1);
Console.WriteLine(a.Item2);

a = pe.Parse("05-31-2022AB.csv");

Console.WriteLine(a.Item1);
Console.WriteLine(a.Item2);

