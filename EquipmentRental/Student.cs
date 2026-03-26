namespace EquipmentRental;

public class Student : User
{
    public Student(string name, string surname) : base(name, surname)
    {
        MaxAmountOfRents = 2;
        DailyPenaltyRate = 10;
    }
}