using EquipmentRental.Enums;
using EquipmentRental.Models;
using EquipmentRental.Exceptions;

namespace EquipmentRental.Services;

public class EquipmentService : IEquipmentService
{
    private List<Equipment> _equipments = [];

    public void AddEquipment(Equipment eq)
    {
        _equipments.Add(eq);
    }

    public Equipment GetEquipmentById(int id)
    {
        return _equipments.FirstOrDefault(equipment => equipment.Id == id) ?? throw new EquipmentNotFoundException(id);
    }
    
    public void PrintExtension()
    {
        foreach (var eq in _equipments)
        {
            Console.WriteLine(eq);
        }
    }
    
    public void PrintExtension(EquipmentStatus requiredStatus)
    {
        foreach (var eq in _equipments)
        {
            if (eq.ItemStatus == requiredStatus)
            {
                Console.WriteLine(eq);
            }
        }
    }
}