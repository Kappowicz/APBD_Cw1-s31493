using EquipmentRental.Exceptions;

namespace EquipmentRental.Models;

public abstract class User
{
    public readonly int Id;
    protected readonly string Name;
    protected readonly string Surname;
    private static int _currentAmountOfUsers = 0;
    
    public int MaxAmountOfRents {get; protected set;}
    protected int DailyPenaltyRate = 0;
    protected List<Equipment> RentedEquipments = new();
    
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
    }

    public string GetUniqueName()
    {
        return $"{Name}_{Surname}_{Id}";
    }

    public int GetDailyPenaltyRate()
    {
        return DailyPenaltyRate;
    }
    
    public void Rent(Equipment equipment)
    {
        if (RentedEquipments.Count >= MaxAmountOfRents)
            throw new EquipmentAlreadyRentedException(equipment.Id);
        
        RentedEquipments.Add(equipment);
    }

    public void Return(Equipment equipment)
    {
        if (!RentedEquipments.Contains(equipment))
            throw new Exception("No rented equipment found!");
        
        RentedEquipments.Remove(equipment);
    }
    
    
    
    public override string ToString()
    {
        string rentedEquipmentsList = string.Join(", ", RentedEquipments.Select(e => e.GetUniqueName()));
        return $"User qualified as {GetType().Name} with unique name: {GetUniqueName()} with borrowed items: {rentedEquipmentsList}";
    }
}