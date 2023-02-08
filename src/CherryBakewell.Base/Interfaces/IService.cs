using AutoMapper;
using Microsoft.Extensions.Logging;
using CherryBakewell.Database;

namespace CherryBakewell.Base.Interfaces;

public interface IService
{
    DAL Context { get; }
    ILogger Logger { get; }
    ILoggerFactory LoggerFactory { get; }
    IMapper Mapper { get; }
}