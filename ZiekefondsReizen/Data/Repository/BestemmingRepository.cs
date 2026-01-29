
namespace ZiekefondsReizen.Data.Repository
{
    public class BestemmingRepository : GenericRepository<Bestemming>, IBestemmingRepository
    {
        public BestemmingRepository(ZiekenfondsApiContext context) : base(context) { }

        public async Task<Bestemming?> GetBestemmingAsync(int id)
        {
            return await _context.bestemmingen.Include(b => b.Reviews).FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task DeleteBestemming(Bestemming bestemming)
        {
            List<Groepsreis> groepsreizen = await _context.Groepsreizen.Where(g => g.BestemmingId == bestemming.Id).ToListAsync();
            foreach (Groepsreis groepsreis in groepsreizen)
            {
                _context.Groepsreizen.Remove(groepsreis);
            }
            List<Review> reviews = await _context.reviews.Where(r => r.BestemmingId == bestemming.Id).ToListAsync();
            foreach (Review review in reviews)
            {
                _context.reviews.Remove(review);
            }

            _context.bestemmingen.Remove(bestemming);
        }
    }
}
