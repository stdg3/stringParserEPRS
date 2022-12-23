

using stringParserEPRS;

ParserEngine pe = new ParserEngine();
var test =  pe.Parse("5-31-2022AB.c");

Console.WriteLine(test.FileExt);
Console.WriteLine(test.FileDate);

test = pe.Parse("05-31-2022.csv");

Console.WriteLine(test.FileExt);
Console.WriteLine(test.FileDate);

