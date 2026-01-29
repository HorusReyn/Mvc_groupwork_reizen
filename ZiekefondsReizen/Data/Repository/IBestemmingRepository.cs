namespace ZiekefondsReizen.Data.Repository
{
    public interface IBestemmingRepository : IGenericRepository<Bestemming>
    {
        Task<Bestemming?> GetBestemmingAsync(int id);
        Task DeleteBestemming(Bestemming bestemming);
    }
}
