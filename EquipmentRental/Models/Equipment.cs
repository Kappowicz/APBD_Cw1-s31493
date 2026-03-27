namespace EquipmentRental.Models;

public abstract class Equipment
{
    public enum Status
    {
        None = 0,
        Available,
        Rented,
        RequiresRepair,
        InRepair,
    }
    //used as an id of specific equipment, in the end should equal to length of _extensions list
    private static int _currentAmountOfEquipments = 0;

    private static List<Equipment> _extension = new();
    protected string Name;
    public readonly int Id;
    public Status ItemStatus { get; protected set; }

    //user who borrowed this equipment, can be null if available
    protected User? Renter;
    
    protected Equipment(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Equipment name cannot be empty!");
        
        this.Name = name;
        this.Id = _currentAmountOfEquipments;
        _currentAmountOfEquipments++;
        ItemStatus = Status.Available;
        
        _extension.Add(this);
    }

    public void SetRenter(User renter)
    {
        if (Renter != null)
            throw new Exception("This equipment is already rented!");
        
        Renter = renter;
        ItemStatus = Status.Rented;
    }

    //can set there status to broken
    public void ReturnWorkingEquipment()
    {
        Renter = null;
        ItemStatus = Status.Available;
    }

    public void ReturnBrokenEquipment()
    {
        Renter = null;
        ItemStatus = Status.RequiresRepair;
    }
    
    public void SetAsInRepair()
    {
        if (Renter != null)
        {
            Renter.Return(this);
        }
        
        ItemStatus = Status.InRepair;
    }
    
    public string GetUniqueName()
    {
        return $"{Name}_{Id}";
    }
    
    public override string ToString()
    {
        return $"Equipment qualified as {Name} with unique id: {Id} and status: {ItemStatus} with renter: {Renter?.GetUniqueName() ?? "None"}";
    }
}