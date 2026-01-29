using Microsoft.EntityFrameworkCore;

namespace ZiekefondsReizen.Data.Repository
{
    public class KindRepository: GenericRepository<Kind>,IKindRepository
    {
        public KindRepository(ZiekenfondsApiContext context) : base(context) { }

        public async Task<IEnumerable<Kind>> GetAllKinderenAsync()
        {
            return await _context.kinderen.Include(k => k.Deelnames).ThenInclude(d => d.Groepsreis).ThenInclude(g => g.Bestemming).ToListAsync();
        }

        public async Task<IEnumerable<Kind>> GetAllViableKinderenAsync(Deelnemer deelnemer)
        {
            if (deelnemer != null && deelnemer.Groepsreis != null && deelnemer.Groepsreis.Bestemming != null)
            {
                return await _context.kinderen
                .Where(k => DateTime.Today.Year - k.Geboortedatum.Year > deelnemer.Groepsreis.Bestemming.MinLeeftijd)
                .Where(k => DateTime.Today.Year - k.Geboortedatum.Year < deelnemer.Groepsreis.Bestemming.MaxLeeftijd)
                .ToListAsync();
            }
            else return new List<Kind>();
        }

        public async Task<Kind?> GetKindAsync(int id)
        {
            return await _context.kinderen.Include(k => k.Deelnames).ThenInclude(d => d.Groepsreis).ThenInclude(g => g.Bestemming).FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Kind?> GetKinderenByParentAsync(int parentId)
        {
            throw new NotImplementedException();
        }
    }
}
