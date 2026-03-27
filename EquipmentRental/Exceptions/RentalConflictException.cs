namespace EquipmentRental.Exceptions;
using EquipmentRental.Models;

public class RentalConflictException(User renter, Equipment equipment, DateTime start) : Exception($"Cannot create rent with parameters:  \n {renter} \n {equipment}\n  {start}");