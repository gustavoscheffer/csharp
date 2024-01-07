 abstract class Pet
{

    private string first;

    public Pet(string firstname)
    {
        first = firstname;
    }

    public string First { get => first; }

    public abstract string MakeNoise();

    public override string ToString()
    {
        return First;
    }

}
