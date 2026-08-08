using AutoMapper;
using System.Reflection;
using Microsoft.Extensions.Logging.Abstractions;

namespace AUTOCENTER.Service.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IMapper RegisterAutoMapper()
        {
            var autoMapperConfig = new MapperConfiguration(cfg => {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            }, NullLoggerFactory.Instance);

            var mapper = autoMapperConfig.CreateMapper();
            return mapper;
        }
    }
}