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
        
        this._processorName = processorName;
        this._amountOfRamGB = amountOfRamGB;
    }

    public override string ToString()
    {
        return base.ToString() + $" Type: Laptop with specs: processor {_processorName} with {_amountOfRamGB}GB RAM";
    }
}