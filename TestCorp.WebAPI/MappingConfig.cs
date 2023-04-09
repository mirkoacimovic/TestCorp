using AutoMapper;
using TestCorp.Domain.Models;
using TestCorp.WebAPI.Models;

namespace TestCorp.WebAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var configuration = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeDTO>()
                 .ReverseMap();

            });
            return configuration;
        }

    }
}
