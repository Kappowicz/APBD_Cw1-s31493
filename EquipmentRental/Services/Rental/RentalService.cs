using EquipmentRental.Exceptions;
using EquipmentRental.Models;

namespace EquipmentRental.Services.Rental;

public class RentalService : IRentalService
{
    private readonly List<Models.Rental> _rentals;
    
    public void CreateRental(User renter, Equipment equipment, DateTime start)
    {
        
        throw new NotImplementedException();
    }

    public void EndRental(int rentalId)
    {
        var rental = _rentals.FirstOrDefault(rental => rental.Id == rentalId) ?? throw new RentalNotFoundException(rentalId);
        
        
    }
}