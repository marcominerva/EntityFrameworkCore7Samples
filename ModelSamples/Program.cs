using Microsoft.EntityFrameworkCore;
using ModelSamples.DataAccessLayer;
using ModelSamples.DataAccessLayer.Entities;

using var db = new DataContext();
await db.Database.MigrateAsync();

var donaldDuck = new Person
{
    FirstName = "Donald",
    LastName = "Duck",
    Address = new Address
    {
        City = "Paperopoli"
    }
};

var mickeyMouse = new Person
{
    Id = Guid.Parse("b11b9f4d-b403-43db-87e0-34a026603b39"),
    FirstName = "Mickey",
    LastName = "Mouse",
    Address = new Address
    {
        City = "Topolinia"
    }
};

var uncleScrooge = new Person
{
    FirstName = "Uncle",
    LastName = "Scrooge",
    Address = new Address
    {
        City = "Paperopoli"
    }
};

db.People.Add(donaldDuck);
db.People.Add(mickeyMouse);
db.People.Add(uncleScrooge);

await db.SaveChangesAsync();

var newPerson = new Person
{
    FirstName = "Fethry",
    LastName = "Duck",
    Address = new Address
    {
        City = "Taggia"
    }
};

db.People.Add(newPerson);
await db.SaveChangesAsync();

var taggiaPerson = await db.People.FirstOrDefaultAsync(p => p.Address.City == "Taggia");
taggiaPerson.Address.City = "Arma di Taggia";
taggiaPerson.Address.ZipCode = "18018";

await db.SaveChangesAsync();

//var person = await db.People.FirstOrDefaultAsync(p => p.Id == Guid.Parse("b11b9f4d-b403-43db-87e0-34a026603b39"));
//db.People.Remove(person);

//var peopleToDelete = await db.People.Where(p => p.Address.City == "Topolinia").ToListAsync();
//db.People.RemoveRange(peopleToDelete);

var rowsDeleted = await db.People.Where(p => p.Address.City == "Topolinia").ExecuteDeleteAsync();

//var peopleToUpdate = await db.People.Where(p => p.Address.City == "Paperopoli").ToListAsync();
//foreach (var personToUpdate in peopleToUpdate)
//{
//    personToUpdate.Address.City = "Duckburg";
//}

var rowsUpdated = await db.People.Where(p => p.FirstName == "Uncle" && p.LastName == "Scrooge")
  .ExecuteUpdateAsync(p => p.SetProperty(x => x.FirstName, x => "Scrooge")
    .SetProperty(x => x.LastName, x => "McDuck"));

//await db.SaveChangesAsync();

Console.ReadLine();