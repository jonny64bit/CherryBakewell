using CherryBakewell.Base.Interfaces.Repository.Definitions;
using CherryBakewell.Database.Models;

namespace CherryBakewell.Base.Interfaces.Repository
{
    public interface ICalculationRepository : IGenericRepository<Calculation>, IOrderedRepository<Calculation>
    {
    }
}
