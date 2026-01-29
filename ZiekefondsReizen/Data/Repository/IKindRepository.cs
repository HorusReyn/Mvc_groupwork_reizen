namespace ZiekefondsReizen.Data.Repository
{
    public interface IKindRepository : IGenericRepository<Kind>
    {
        Task<IEnumerable<Kind>> GetAllKinderenAsync();
        Task<Kind?> GetKindAsync(int id);
        Task<Kind?> GetKinderenByParentAsync(int parentId);

        Task<IEnumerable<Kind>> GetAllViableKinderenAsync(Deelnemer deelnemer);
    }
}
