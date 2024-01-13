public class Dog : Pet
{
    public Dog(string firstname) : base(firstname) { }

    public override string MakeNoise() => "bark";
}