using AutoMapper;
using WSApplication.DTO;
using WSApplications.DTO;
using WSDomain.Entity;

namespace WSTransversal.Mapp
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Clients, ClientsDto>().ReverseMap();
            CreateMap<Accounts, AccountsDto>().ReverseMap();
        }
    }
}