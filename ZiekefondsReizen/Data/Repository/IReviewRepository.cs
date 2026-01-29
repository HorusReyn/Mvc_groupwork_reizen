namespace ZiekefondsReizen.Data.Repository
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review?> GetReviewAsync(int id);
    }
}
