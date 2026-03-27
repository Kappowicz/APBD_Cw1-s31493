namespace EquipmentRental.Exceptions;

public class EquipmentNotFoundException(int equipmentId) : Exception($"Equipment with id {equipmentId} Not Found");