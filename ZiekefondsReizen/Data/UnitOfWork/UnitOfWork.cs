using ZiekefondsReizen.Data.Repository;

namespace ZiekefondsReizen.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZiekenfondsApiContext _context;

        private IGroepsreisRepository groepsreisRepository;
        private IBestemmingRepository bestemmingRepository;


        private IKindRepository kindRepository;

        private IOpleidingRepository opleidingRepository;
        private IActiviteitRepository activiteitRepository;
        private IOnkostenRepository onkostenRepository;

        private IDeelnemerRepository deelnemerRepository;

        private IReviewRepository reviewerRepository;



        public UnitOfWork(ZiekenfondsApiContext context)
        {
            _context = context;
        }

        public IGroepsreisRepository GroepsreisRepository
        {
            get
            {
                return groepsreisRepository ??= new GroepsreisRepository(_context);
            }
        }

        public IBestemmingRepository BestemmingRepository
        {
            get
            {
                return bestemmingRepository ??= new BestemmingRepository(_context);
            }
        }
        public IKindRepository KindRepository
        {
            get
            {
                return kindRepository ??= new KindRepository(_context);
            }
        }
        public IOpleidingRepository OpleidingRepository
        {
            get
            {
                return opleidingRepository ??= new OpleidingRepository(_context);
            }
        }

        public IActiviteitRepository ActiviteitRepository
        {
            get
            {
                return activiteitRepository ??= new ActiviteitRepository(_context);
            }
        }
        public IOnkostenRepository OnkostenRepository
        {
            get
            {
                return onkostenRepository ??= new OnkostenRepository(_context);
            }
        }
        public IDeelnemerRepository DeelnemerRepository
        {
            get
            {
                return deelnemerRepository ??= new DeelnemerRepository(_context);
            }
        }

        public IReviewRepository ReviewRepository
        {
            get
            {
                return reviewerRepository ??= new ReviewRepository(_context);

            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}