namespace EquipmentRental.Exceptions;

public class EquipmentNotAvailableException(int id) : Exception($"Equipment with id {id} is not available.");