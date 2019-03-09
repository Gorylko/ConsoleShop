namespace Shop.Data.DataContext.Interfaces
{
    public interface ICategoryContext : IDataContext<string>
    {
        int GetIdByName(string name);

        string GetAllString();
    }
}
