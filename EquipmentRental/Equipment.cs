namespace EquipmentRental;

public abstract class Equipment
{
    public enum Status
    {
        None = 0,
        Available,
        Rented,
        InRepair,
    }
    //used as an id of specific equipment, in the end should equal to length of _extensions list
    public static int CurrentAmountOfEquipments;

    private static List<Equipment> _extension = new();
    protected string Name;
    protected readonly int Id;
    protected Status ItemStatus;
    
    protected Equipment(string name, Status itemStatus)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Equipment name cannot be empty!");
        
        if (itemStatus == Status.None)
            throw new ArgumentException("Equipment status cannot be None!");
        
        this.Name = name;
        this.ItemStatus = itemStatus;
        this.Id = CurrentAmountOfEquipments;
        CurrentAmountOfEquipments++;
        _extension.Add(this);
    }

    public static void PrintExtension()
    {
        foreach (var eq in _extension)
        {
            Console.WriteLine(eq);
        }
    }
    
    public static void PrintExtension(Status requiredStatus)
    {
        foreach (var eq in _extension)
        {
            if (eq.ItemStatus == requiredStatus)
            {
                Console.WriteLine(eq);
            }
        }
    }

    public override string ToString()
    {
        return $"Equipment qualified as {Name} with unique id: {Id} and status: {ItemStatus}";
    }
}