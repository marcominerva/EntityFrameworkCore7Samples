using System.Data.Common;
using MappingSamples.DataAccessLayer;
using MappingSamples.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using var db = new DataContext();
await db.Database.MigrateAsync();

var student = new Student
{
    FirstName = "Marco",
    LastName = "Minerva",
    City = "Taggia",
    IdentificationNumber = "232440"
};

var worker = new Worker
{
    FirstName = "Ciccio",
    LastName = "Piricchio",
    City = "Arma di Taggia",
    Salary = 42
};

db.Students.Add(student);
db.Workers.Add(worker);

await db.SaveChangesAsync();

var dbPeople = await db.People.ToListAsync();
var dbStudent = await db.Students.ToListAsync();
var dbWorker = await db.Workers.ToListAsync();

var firstStudent = await db.Students.FirstOrDefaultAsync();
firstStudent.City = "Tabya";

await db.SaveChangesAsync();

Console.ReadLine();

internal class SampleInterceptor : DbCommandInterceptor
{
    public override DbCommand CommandInitialized(CommandEndEventData eventData, DbCommand result)
    {
        var command = base.CommandInitialized(eventData, result);
        //command.CommandText = """
        //                SELECT TOP(1) [s].[Id], [s].[City], [s].[FirstName], [s].[LastName], '42' AS [IdentificationNumber]
        //    FROM [Students] AS [s]
        //    """;

        return command;
    }

    public override DbCommand CommandCreated(CommandEndEventData eventData, DbCommand result)
    {
        var command = base.CommandCreated(eventData, result);
        return command;
    }
}