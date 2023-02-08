namespace CherryBakewell.Base.Interfaces.Repository.Definitions
{
    /// <summary>
    /// Defiens a list of generic actions present on all repositories.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);

        //Other bits that would be part of a generic repository setup would also be here.
    }
}
