using EquipmentRental.Models;

namespace EquipmentRental.Services.Rental;

public interface IRentalService
{
    public void CreateRental(User renter, Equipment equipment, DateTime start);
    public void EndRentalWithoutRepair(int rentalId);
    public void EndRentalWithRepairNeeded(int rentalId);
    public void PrintExtension();
}