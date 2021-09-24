using AutoMapper;
using Project.Application.Dtos.AccountDtos;
using Project.Core.Entities;

namespace Project.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Account, AccountSelectingDto>();
            CreateMap<AccountAddingDto, Account>();
        }
    }
}
 