using ZiekefondsReizen.Models;
using Microsoft.EntityFrameworkCore;

namespace ZiekefondsReizen.Data.Repository
{
    public class OnkostenRepository : GenericRepository<Onkosten>, IOnkostenRepository
    {
        public OnkostenRepository(ZiekenfondsApiContext context) : base(context) { }
    }
}