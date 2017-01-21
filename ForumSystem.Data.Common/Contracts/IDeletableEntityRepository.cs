namespace ForumSystem.Data.Common.Contracts
{
    using System.Linq;

    public interface IDeletableEntityRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();

        void ActualDelete(T entity);
    }
}
