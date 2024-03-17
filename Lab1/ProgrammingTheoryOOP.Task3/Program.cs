using ProgrammingTheoryOOP.Task3.Entities;
using ProgrammingTheoryOOP.Task3.Infrastructure;

var table = new Table(10, 15);

table.Put(new Cup(100, null));
table.Put(new Plate(100, "Plate 1", 1, 1, 1));
table.Put(new Fork(100, "Fork 1", 1, 1, 1));
table.Put(new Spoon(100, "Spoon 1", 15, 10, 10));

Console.WriteLine(table.ToString());