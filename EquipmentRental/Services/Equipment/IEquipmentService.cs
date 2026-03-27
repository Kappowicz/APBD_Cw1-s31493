using EquipmentRental.Enums;
using EquipmentRental.Models;

namespace EquipmentRental.Services;

public interface IEquipmentService
{
    public void AddEquipment(Equipment eq);
    public Equipment GetEquipmentById(int id);
    public void PrintExtension();
    public void PrintExtension(EquipmentStatus requiredStatus);
}