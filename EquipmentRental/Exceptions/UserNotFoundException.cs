namespace EquipmentRental.Exceptions;

public class UserNotFoundException(int userId) : Exception($"User with id {userId} was not found!");