using AutoMapper;
using PhoneBook.Web.Models;

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
