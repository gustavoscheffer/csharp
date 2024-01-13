public class Person
{
    private string firstName;
    private string lastName;
    private DateOnly birthdate;
    private List<Pet> pets = new();

    public Person(string fName, string lNane, DateOnly bd)
    {
        firstName = fName;
        lastName = lNane;
        birthdate = bd;
    }


    public string FirstName { get => firstName; }
    public string LastName { get => lastName; }
    public DateOnly BirthDate { get => birthdate; }
    public List<Pet> Pets { get => pets; }

}
