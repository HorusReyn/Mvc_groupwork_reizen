namespace ZiekefondsReizen.Data.Repository
{
    public interface IDeelnemerRepository : IGenericRepository<Deelnemer>
    {
        Task<IEnumerable<Deelnemer>> GetAllDeelnemersAsync();
        Task<Deelnemer?> GetDeelnemerAsync(int id);
    }
}
