using AA.Bancs.Applications.DTO;
using AA.Bancs.Domain.Entity;
using AutoMapper;

namespace AA.Bancs.Transversal.Mapp
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            //mapeo de reverso
            CreateMap<Clients, ClientsDto>().ReverseMap();

        }
    }
}