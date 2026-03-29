using EquipmentRental.Exceptions;

namespace EquipmentRental.Models;

public abstract class User
{
    private static int _currentAmountOfUsers = 0;
    
    public int Id { get; }
    public abstract int MaxAmountOfRents { get; }
    public abstract int DailyPenaltyRate { get; }
    protected string Name { get; }
    protected string Surname { get; }
    protected List<Equipment> RentedEquipments { get; } = [];
    
    protected User(string name, string surname)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("User name cannot be empty!");
        
        if (string.IsNullOrWhiteSpace(surname))
            throw new ArgumentException("User surname cannot be empty!");
        
        Name = name;
        Surname = surname;
        Id = ++_currentAmountOfUsers; //first id will be 1
    }

    public string GetUniqueName() => $"{Name}_{Surname}_{Id}";
    
    public void Rent(Equipment equipment)
    {
        if (RentedEquipments.Count >= MaxAmountOfRents)
            throw new MaxRentedEquipmentCountException(Id);
        
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