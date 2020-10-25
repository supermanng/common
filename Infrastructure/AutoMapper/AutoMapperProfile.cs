using System.Reflection;
using AutoMapper;

namespace Etechnosoft.Common.Infrastructure.AutoMapper
{
    public abstract class AutoMapperProfile : Profile
    {

        protected AutoMapperProfile(Assembly assembly)
        {
            LoadConverters();
            LoadStandardMappings(assembly);
            LoadCustomMappings(assembly);
        }

        private void LoadConverters()
        {

        }

        private void LoadStandardMappings(Assembly assembly)
        {
            var mapsFrom = MapperProfileHelper.LoadStandardMappings(assembly);

            foreach (var map in mapsFrom)
            {
                CreateMap(map.Source, map.Destination).ReverseMap();
            }
        }

        private void LoadCustomMappings(Assembly assembly)
        {
            var mapsFrom = MapperProfileHelper.LoadCustomMappings(assembly);

            foreach (var map in mapsFrom)
            {
                map.CreateMappings(this);
            }
        }
    }
}
