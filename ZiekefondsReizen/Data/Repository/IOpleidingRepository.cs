namespace ZiekefondsReizen.Data.Repository
{
    public interface IOpleidingRepository : IGenericRepository<Opleiding>
    {
        Task<IEnumerable<Opleiding>> GetAllOpleidingenAsync();
        Task<Opleiding?> GetOpleidingAsync(int id);
        void DeleteOpleiding(Opleiding opleiding);
    }
}
