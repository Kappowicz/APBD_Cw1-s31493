namespace EquipmentRental;

public class Laptop : Equipment
{
    private string _processorName;
    private int _amountOfRamGB;
    public Laptop(string name, Status status, string processorName, int amountOfRamGB) : base(name, status)
    {
        this._processorName = processorName;
        this._amountOfRamGB = amountOfRamGB;
    }

    public override string ToString()
    {
        return base.ToString() + $" Type: Laptop with specs: processor {_processorName} with {_amountOfRamGB}GB RAM";
    }
}