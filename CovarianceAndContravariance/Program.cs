namespace CovarianceAndContravariance;

class Program
{
    delegate Animal AnimalDelegate();   // for covariance
    delegate void DogDelegate(Dog d);   // for contravariance

    static Dog GetDog()
    {
        return new Dog();
    }

    static void HandleAnimal(Animal a)
    {
        Console.WriteLine($"Handling: {a.GetType().Name}");
    }

    static void Main()
    {
        // Covariance: method returns Dog, delegate expects Animal
        AnimalDelegate covariantDel = GetDog;
        Animal a = covariantDel();
        Console.WriteLine($"Covariance result type: {a.GetType().Name}");

        // Contravariance: method accepts Animal, delegate expects Dog
        DogDelegate contravariantDel = HandleAnimal;
        contravariantDel(new Dog());
    }

    // classes for example usage
    public class Animal { }
    public class Dog : Animal { }
}
