using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace NarojayBlog.Webapi.Helper
{
    //实现批量映射model
    public static class AutoMapperExtension
    {
        public static void AddMappings(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(
                configure => configure.AddProfile(new MappingProfile())
            );

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }


}
