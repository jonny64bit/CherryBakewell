using AutoMapper;
using CherryBakewell.Database.Models;
using CherryBakewell.Web.Models;

namespace CherryBakewell.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddCalculation, Calculation>();
        }
    }
}
