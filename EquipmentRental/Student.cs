namespace EquipmentRental;

public class Student : User
{
    protected new int MaxAmountOfRents = 2;
    
    public Student(string name, string surname) : base(name, surname)
    {
        
    }
}