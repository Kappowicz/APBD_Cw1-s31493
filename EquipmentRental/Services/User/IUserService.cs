using EquipmentRental.Models;

namespace EquipmentRental.Services;

public interface IUserService
{
    public void AddUser(User user);
    public User GetUserById(int userId);
    public void PrintExtension();
}