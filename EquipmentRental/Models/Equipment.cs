using EquipmentRental.Enums;

namespace EquipmentRental.Models;

public abstract class Equipment
{
    //used as an id of specific equipment, in the end should equal to length of _extensions list
    private static int _currentAmountOfEquipments = 0;

    protected string Name;
    public readonly int Id;
    public EquipmentStatus ItemStatus { get; protected set; }

    //user who borrowed this equipment, can be null if available
    protected User? Renter;
    
    protected Equipment(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Equipment name cannot be empty!");
        
        this.Name = name;
        this.Id = _currentAmountOfEquipments;
        _currentAmountOfEquipments++;
        ItemStatus = EquipmentStatus.Available;
    }

    public void SetRenter(User renter)
    {
        if (Renter != null)
            throw new Exception("This equipment is already rented!");
        
        Renter = renter;
        ItemStatus = EquipmentStatus.Rented;
    }

    //can set there status to broken
    public void ReturnWorkingEquipment()
    {
        Renter = null;
        ItemStatus = EquipmentStatus.Available;
    }

    public void ReturnBrokenEquipment()
    {
        Renter = null;
        ItemStatus = EquipmentStatus.RequiresRepair;
    }
    
    public void SetAsInRepair()
    {
        if (Renter != null)
        {
            Renter.Return(this);
        }
        
        ItemStatus = EquipmentStatus.InRepair;
    }
    
    public string GetUniqueName()
    {
        return $"{Name}_{Id}";
    }
    
    public override string ToString()
    {
        return $"Equipment qualified as {GetType().Name} {Name} with unique id: {Id} and status: {ItemStatus} with renter: {Renter?.GetUniqueName() ?? "None"}";
    }
}