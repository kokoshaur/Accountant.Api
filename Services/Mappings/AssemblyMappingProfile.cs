using AutoMapper;
using System.Reflection;

namespace Services.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly)
        {
            var type = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach(var t in type)
            {
                var ins = Activator.CreateInstance(t);
                var method = t.GetMethod("Mapping");
                method?.Invoke(ins, new object[] { this });
            }
        }
    }
}
