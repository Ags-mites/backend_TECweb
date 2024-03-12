using AutoMapper;
using Backend.DTOs;
using Backend.DTOs.Account;
using Backend.DTOs.ClientsFac;
using Backend.DTOs.CiudadEntrFac;
using Backend.DTOs.SilcActividad;
using Backend.DTOs.FacturacionCliente;
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
            //simple page 2
            CreateMap<CiudadEntrFacToCreateDTO, CiudadEntrFac>();
            CreateMap<CiudadEntrFac, CiudadEntrFacToListDTO>();
            //practice
            CreateMap<SilcActividadToCreateDTO, SilcActividad>();
            CreateMap<SilcActividad, SilcActividadToListDTO>();
            //page complicada
            CreateMap<FacturacionClienteToCreateDTO, FacturacionCliente>();
            CreateMap<FacturacionClienteToEditDTO,FacturacionCliente>();
            CreateMap<FacturacionCliente, FacturacionClienteToListDTO>();

        }
    }
}