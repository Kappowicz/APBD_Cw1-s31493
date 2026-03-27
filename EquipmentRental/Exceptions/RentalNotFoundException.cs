namespace EquipmentRental.Exceptions;

public class RentalNotFoundException(int id) : Exception($"Rental with id: {id}  was not found.");