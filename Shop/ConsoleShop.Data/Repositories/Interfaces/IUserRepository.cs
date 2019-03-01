using ConsoleShop.Shared.Entities;

namespace ConsoleShop.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetAuthorizedUser(string login, string password);

        User GetRegistratedUser(string login, string password, string email, string phonenumber);
    }
}
