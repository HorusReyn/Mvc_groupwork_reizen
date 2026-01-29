namespace ZiekefondsReizen.Data.Repository
{
    public class ActiviteitRepository : GenericRepository<Activiteit>, IActiviteitRepository
    {
        public ActiviteitRepository(ZiekenfondsApiContext context) : base(context) { }
    }
}
