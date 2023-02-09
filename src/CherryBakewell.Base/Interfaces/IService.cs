using AutoMapper;
using Microsoft.Extensions.Logging;
using CherryBakewell.Database;
using CherryBakewell.Base.Interfaces.Repository;

namespace CherryBakewell.Base.Interfaces;

public interface IService
{
    DAL Context { get; }
    ILogger Logger { get; }
    ILoggerFactory LoggerFactory { get; }
    IMapper Mapper { get; }
    ICalculationRepository Calculation { get; }
}