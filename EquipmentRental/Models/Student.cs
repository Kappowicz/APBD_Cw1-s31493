namespace EquipmentRental.Models;

public class Student(string name, string surname) : User(name, surname)
{
    public override int MaxAmountOfRents => 2;
    public override int DailyPenaltyRate => 5;
}