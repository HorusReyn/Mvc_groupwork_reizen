
namespace ZiekefondsReizen.Data.Repository
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ZiekenfondsApiContext context) : base(context) { }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _context.reviews.Include(r => r.Bestemming).ToListAsync();
        }

        public async Task<Review?> GetReviewAsync(int id)
        {
            return await _context.reviews.Include(r => r.Bestemming).FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
