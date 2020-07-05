namespace Data.DbContexts
{
    public interface IGenerateDatabaseContext
    {
        IDatabaseContext NewContext();
    }

}
