namespace EquipmentRental.Models;

public class Laptop : Equipment
{
    private string _processorName;
    private int _amountOfRamGB;
    public Laptop(string name, string processorName, int amountOfRamGB) : base(name)
    {
        if (string.IsNullOrWhiteSpace(processorName))
            throw new ArgumentException("Processor name cannot be empty!");
        
        if (amountOfRamGB <= 0)
            throw new ArgumentException("Laptop can't have no ram!");
        
        _processorName = processorName;
        _amountOfRamGB = amountOfRamGB;
    }

    public override string ToString()
    {
        return base.ToString() + $" with specs: processor {_processorName} with {_amountOfRamGB}GB RAM";
    }
}