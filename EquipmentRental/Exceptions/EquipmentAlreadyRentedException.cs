namespace EquipmentRental.Exceptions;

public class EquipmentAlreadyRentedException(int equipmentId) : Exception($"Equipment with id {equipmentId} is already rented!");