namespace DefaultNamespace;

public abstract class Equipment
{
    public enum Status
    {
        None = 0,
        Available,
        Rented,
    }
    //used as an id of specific equipment
    public static int IndexOfEquipment;

    private static List<Equipment> Extension = new();
    protected string name;
    protected int id;
    protected Status status;
    
    protected Equipment(string name, Status status)
    {
        this.id = IndexOfEquipment;
        IndexOfEquipment++;
        this.name = name;
        this.status = status;
        
        Extension.Add(this);
    }

    public static void PrintExtension()
    {
        foreach (var eq in Extension)
        {
            Console.WriteLine(eq);
        }
    }
    
    public static void PrintExtension(Status requiredStatus)
    {
        foreach (var eq in Extension)
        {
            if (eq.status == requiredStatus)
            {
                Console.WriteLine(eq);
            }
        }
    }

    public override string ToString()
    {
        return $"Equipment qualified as {name} with unique id: {id} and status: {status}";
    }
}