using Microsoft.EntityFrameworkCore;
using ModelSamples.DataAccessLayer;

using var db = new DataContext();

var person = await db.People.FirstOrDefaultAsync(p => p.Id == Guid.Parse("b11b9f4d-b403-43db-87e0-34a026603b39"));
db.People.Remove(person);

//var peopleToDelete = await db.People.Where(p => p.City == "Topolinia").ToListAsync();
//db.People.RemoveRange(peopleToDelete);

var peopleToUpdate = await db.People.Where(p => p.City == "Paperopoli").ToListAsync();
foreach (var personToUpdate in peopleToUpdate)
{
    personToUpdate.City = "Duckburg";
}

await db.SaveChangesAsync();

Console.ReadLine();