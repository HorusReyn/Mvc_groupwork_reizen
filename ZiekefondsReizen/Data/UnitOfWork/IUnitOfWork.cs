using ZiekefondsReizen.Data.Repository;

namespace ZiekefondsReizen.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGroepsreisRepository GroepsreisRepository { get; }
        IBestemmingRepository BestemmingRepository { get; }
        IKindRepository KindRepository { get; }
        IOpleidingRepository OpleidingRepository { get; }
        IActiviteitRepository ActiviteitRepository { get; }
        IOnkostenRepository OnkostenRepository { get; }
        IDeelnemerRepository DeelnemerRepository { get; }
        IReviewRepository ReviewRepository { get; }

	      public void SaveChanges();

    }
}
