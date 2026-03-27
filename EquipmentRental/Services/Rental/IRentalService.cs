using EquipmentRental.Models;

namespace EquipmentRental.Services.Rental;

public interface IRentalService
{
    public void CreateRental(User renter, Equipment equipment, DateTime start);
    public void EndRental(int rentalId);
}