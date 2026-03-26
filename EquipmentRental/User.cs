namespace EquipmentRental;

public abstract class User
{
    protected readonly int Id;
    protected readonly string Name;
    protected readonly string Surname;
    private static int _currentAmountOfUsers = 0;
    
    private static List<User> _extension = new();
    protected int MaxAmountOfRents;
    
    protected User(string name, string surname)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("User name cannot be empty!");
        
        if (string.IsNullOrWhiteSpace(surname))
            throw new ArgumentException("User surname cannot be empty!");
        
        this.Name = name;
        this.Surname = surname;
        this.Id = _currentAmountOfUsers;
        _currentAmountOfUsers++;
        
        _extension.Add(this);
    }
    
    public static void PrintExtension()
    {
        foreach (var usr in _extension)
        {
            Console.WriteLine(usr);
        }
    }
    
    public override string ToString()
    {
        return $"User qualified as {GetType().Name} with unique id: {Id} and name: {Name} {Surname}";
    }
}