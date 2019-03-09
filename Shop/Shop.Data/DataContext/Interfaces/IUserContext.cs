using Shop.Shared.Entities;

namespace Shop.Data.DataContext.Interfaces
{
    public interface IUserContext : IDataContext<User>
    {
        User GetAuthorizedUser(string login, string password);

        User GetRegistratedUser(string login, string password, string email, string phonenumber);
    }
}
