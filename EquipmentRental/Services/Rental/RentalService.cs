using EquipmentRental.Exceptions;
using EquipmentRental.Models;

namespace EquipmentRental.Services.Rental;

public class RentalService : IRentalService
{
    private readonly List<Models.Rental> _rentals = [];
    
    public void CreateRental(User renter, Equipment equipment, DateTime start)
    {
        if (equipment.ItemStatus != Equipment.Status.Available)
        {
            if (equipment.ItemStatus == Equipment.Status.Rented)
            {
                throw new RentalConflictException(renter, equipment, start);
            }
            throw new EquipmentNotAvailableException(equipment.Id);
        }
        
        bool rentalConflict = _rentals.Any(rental =>
            rental.RentedEquipment == equipment
            && rental.Overlaps(start));

        if (!rentalConflict)
        {
            _rentals.Add(new Models.Rental(renter, equipment, start));
        }
        else
        {
            throw new RentalConflictException(renter, equipment, start);
        }
        
        //Console.WriteLine(rentalConflict);
    }

    public void EndRentalWithoutRepair(int rentalId)
    {
        var rental = _rentals.FirstOrDefault(rental => rental.Id == rentalId) ?? throw new RentalNotFoundException(rentalId);
        
        rental.Return(DateTime.Now);
        rental.RentedEquipment.ReturnWorkingEquipment();
    }
    
    public void EndRentalWithRepair(int rentalId)
    {
        var rental = _rentals.FirstOrDefault(rental => rental.Id == rentalId) ?? throw new RentalNotFoundException(rentalId);
        
        rental.Return(DateTime.Now);
        rental.RentedEquipment.ReturnBrokenEquipment();
    }

    public void PrintExtension()
    {
        foreach (var rental in _rentals)
        {
            Console.WriteLine(rental);
        }
    }
}