
namespace ZiekefondsReizen.Data.Repository
{
    public class GroepsreisRepository : GenericRepository<Groepsreis>, IGroepsreisRepository
    {
        public GroepsreisRepository(ZiekenfondsApiContext context) : base(context) {}

        public async Task<IEnumerable<Groepsreis>> GetAllGroepsreizenAsync()
        {
            return await _context.Groepsreizen.Include(g => g.Bestemming).Include(g => g.Deelnemers).ToListAsync();
        }

        public async Task<IEnumerable<Groepsreis>> GetAvailableGroepsreizenAsync()
        {
            return await _context.Groepsreizen.Include(g => g.Bestemming).Include(g => g.Deelnemers)
                .Where(g => g.Begindatum.CompareTo(DateOnly.FromDateTime(DateTime.Now)) > 0)
                .ToListAsync();
        }

        public async Task<Groepsreis?> GetGroepsreisAsync(int id)
        {
            return await _context.Groepsreizen.Include(g => g.Bestemming).ThenInclude(b => b.Reviews).Include(g => g.Deelnemers).ThenInclude(d => d.Kind).FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
