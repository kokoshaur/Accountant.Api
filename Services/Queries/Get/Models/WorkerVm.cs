using AutoMapper;
using Models;
using Services.Mappings;

namespace Services.Queries.Get.Models
{
    public class WorkerVm : IMapWith<Worker>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public string StructureUnit { get; set; }
        public uint Salary { get; set; }
        public POST Post { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime JoinToTeam { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<Worker, WorkerVm>()
                .ForMember(v => v.Id, opt => opt.MapFrom(n => n.Id))
                .ForMember(v => v.Name, opt => opt.MapFrom(n => n.Name))
                .ForMember(v => v.Surname, opt => opt.MapFrom(n => n.Surname))
                .ForMember(v => v.Patronymic, opt => opt.MapFrom(n => n.Patronymic))
                .ForMember(v => v.StructureUnit, opt => opt.MapFrom(n => n.StructureUnit))
                .ForMember(v => v.Salary, opt => opt.MapFrom(n => n.Salary))
                .ForMember(v => v.Post, opt => opt.MapFrom(n => n.Post))
                .ForMember(v => v.BirthDate, opt => opt.MapFrom(n => n.BirthDate))
                .ForMember(v => v.JoinToTeam, opt => opt.MapFrom(n => n.JoinToTeam));
    }
}
