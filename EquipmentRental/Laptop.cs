namespace DefaultNamespace;

public class Laptop : Equipment
{
    protected string processorName;
    protected int amountOfRamGB;
    public Laptop(string name, Status status, string processorName, int amountOfRamGB) : base(name, status)
    {
        this.processorName = processorName;
        this.amountOfRamGB = amountOfRamGB;
    }

    public override string ToString()
    {
        return base.ToString() + $" Type: Laptop with specs: processor {processorName} with {amountOfRamGB}GB RAM";
    }
}