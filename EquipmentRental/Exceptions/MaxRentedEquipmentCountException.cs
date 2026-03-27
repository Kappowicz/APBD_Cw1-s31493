namespace EquipmentRental.Exceptions;

public class MaxRentedEquipmentCountException(int userId) : Exception($"User with id {userId} rented max amount of equipment allowed to him!");