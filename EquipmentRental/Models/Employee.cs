namespace EquipmentRental.Models;

public class Employee(string name, string surname) : User(name, surname)
{
    public override int MaxAmountOfRents => 5;
    public override int DailyPenaltyRate => 1;
}