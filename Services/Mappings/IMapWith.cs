using AutoMapper;

namespace Services.Mappings
{
    internal interface IMapWith<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
