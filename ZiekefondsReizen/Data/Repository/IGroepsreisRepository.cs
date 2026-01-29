namespace ZiekefondsReizen.Data.Repository
{
    public interface IGroepsreisRepository : IGenericRepository<Groepsreis>
    {
        Task<IEnumerable<Groepsreis>> GetAllGroepsreizenAsync();
        Task<IEnumerable<Groepsreis>> GetAvailableGroepsreizenAsync();
        Task<Groepsreis?> GetGroepsreisAsync(int id);
    }
}
