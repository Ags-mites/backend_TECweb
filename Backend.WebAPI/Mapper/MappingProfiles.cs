using AutoMapper;
using Backend.DTOs;
using Backend.DTOs.Account;
using Backend.DTOs.ClientsFac;
using Backend.Entities;

namespace Backend.WebAPI.Mapper
{
    public class MappingProfiles: Profile
    {
        public  MappingProfiles()
        {
            CreateMap<AccountToCreateDTO, Account>();
            CreateMap<AccountToEditDTO,Account>();
            CreateMap<Account, AccountToListDTO>();
            //facturation
            CreateMap<ClientsFacToCreateDTO, ClientsFac>();
            CreateMap<ClientsFacToEditDTO,ClientsFac>();
            CreateMap<ClientsFac, ClientsFacToListDTO>();
        }
    }
}