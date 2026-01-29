using Microsoft.EntityFrameworkCore;

namespace ZiekefondsReizen.Data.Repository
{
    public class DeelnemerRepository :GenericRepository<Deelnemer>, IDeelnemerRepository
    {
        public DeelnemerRepository(ZiekenfondsApiContext context) : base(context) { }
        public async Task<IEnumerable<Deelnemer>> GetAllDeelnemersAsync()
        {
            return await _context.deelnemers.ToListAsync();
        }
        public async Task<Deelnemer?> GetDeelnemerAsync(int id)
        {
            return await _context.deelnemers.FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
