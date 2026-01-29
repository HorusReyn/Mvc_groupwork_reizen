
namespace ZiekefondsReizen.Data.Repository
{
    public class OpleidingRepository : GenericRepository<Opleiding>, IOpleidingRepository
    {
        public OpleidingRepository(ZiekenfondsApiContext context) : base(context) { }

        public void DeleteOpleiding(Opleiding opleiding)
        {
            List<Opleiding> opvolgingen = _context.opleidingen
                .Include(o => o.OpleidingVereist)
                .Where(o => o.OpleidingVereistId == opleiding.Id)
                .ToList();

            foreach (Opleiding opvolging in opvolgingen)
            {
                opvolging.OpleidingVereist = null;
                opvolging.OpleidingVereistId = null;

                _context.opleidingen.Update(opvolging);
            }

            _context.opleidingen.Remove(opleiding);
        }
        public async Task<IEnumerable<Opleiding>> GetAllOpleidingenAsync()
        {
            return await _context.opleidingen.Include(o => o.OpleidingVereist).ToListAsync();
        }

        public async Task<Opleiding?> GetOpleidingAsync(int id)
        {
            return await _context.opleidingen.Include(o => o.OpleidingVereist).FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
