using EquipmentRental.Models;

namespace EquipmentRental.Services;

public interface IRentalService
{
    public void CreateRental(User renter, Equipment equipment, DateTime start, int allowedRentalDays = 10);
    public void EndRentalWithoutRepair(int rentalId);
    public void EndRentalWithRepairNeeded(int rentalId);
    public void PrintExtension();
    public void PrintOverdueRentals();
}