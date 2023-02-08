using AutoMapper;
using Microsoft.Extensions.Logging;
using CherryBakewell.Base.Interfaces;
using CherryBakewell.Database;
using CherryBakewell.Base.Interfaces.Repository;

namespace CherryBakewell.Base;

public class Service : IService
{
    public Service(DAL context, ILoggerFactory loggerFactory, IMapper mapper, ICalculationRepository calculation)
    {
        Context = context;
        Logger = loggerFactory.CreateLogger(GetType().Name);
        LoggerFactory = loggerFactory;
        Mapper = mapper;
        Calculation = calculation;
    }
    
    public DAL Context { get; }
    public ILogger Logger { get; }
    public ILoggerFactory LoggerFactory { get; }
    public IMapper Mapper { get; }
    public ICalculationRepository Calculation { get; }
}