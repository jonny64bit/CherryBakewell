using CherryBakewell.Database.Interfaces;

namespace CherryBakewell.Base.Interfaces.Repository.Definitions
{
    /// <summary>
    /// Defines a list of actions present on repoistories which are ordered.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOrderedRepository<T> where T : class, IOrdered
    {
        Task<List<T>> GetLast(int amount);
    }
}
