namespace EquipmentRental.Models;

public class Employee : User
{
    public Employee(string name, string surname) : base(name, surname)
    {
        MaxAmountOfRents = 5;
        DailyPenaltyRate = 1;
    }
}