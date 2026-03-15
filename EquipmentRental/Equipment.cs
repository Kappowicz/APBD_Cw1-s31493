namespace DefaultNamespace;

public abstract class Equipment
{
    public enum Status
    {
        None,
        Available,
        Rented,
    }
    //used as an id of specific equipment
    public static int IndexOfEquipment;

    private static List<Equipment> Extension = new();
    private string name;
    private int id;
    private Status status;
    
    Equipment(string name, Status status)
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
}