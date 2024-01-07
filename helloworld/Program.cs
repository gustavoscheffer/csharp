var p1 = new Person("Gustavo", "Scheffer", new DateOnly(1987, 2, 8));
var p2 = new Person("Naides", "Leao", new DateOnly(1988, 6, 3));

p1.Pets.Add(new Dog("Luck"));
p1.Pets.Add(new Cat("Mana"));
p2.Pets.Add(new Dog("Luck"));
p2.Pets.Add(new Dog("Raj"));

var people = new List<Person> { p1, p2 };

foreach (var person in people)
{
    Console.WriteLine($"My name is : {person.FirstName} {person.LastName} and my birthday is at: {person.BirthDate}");
    Console.WriteLine($"His/Her Pets:");

    foreach (var pet in person.Pets)
    {
        Console.WriteLine(" - " + pet + "I'm a " + pet.GetType() + " and I : " + pet.MakeNoise());
    }

}
