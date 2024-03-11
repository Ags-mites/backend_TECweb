using AutoMapper;
using Backend.DTOs;
using Backend.DTOs.Account;
using Backend.DTOs.ClientsFac;
using Backend.DTOs.CobradorCuentasCobrar;
using Backend.DTOs.FormaDePagoCXC;
using Backend.DTOs.JabdActividad;
using Backend.DTOs.CabeceraCXC;
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
            //CXC
            CreateMap<CobradorCuentasCobrarToCreateDTO, CobradorCuentasCobrar>();
            CreateMap<CobradorCuentasCobrarToEditDTO,CobradorCuentasCobrar>();
            CreateMap<CobradorCuentasCobrar, CobradorCuentasCobrarToListDTO>();
            
            CreateMap<FormaDePagoCXCToCreateDTO, FormaDePagoCXC>();
            CreateMap<FormaDePagoCXCToEditDTO,FormaDePagoCXC>();
            CreateMap<FormaDePagoCXC, FormaDePagoCXCToListDTO>();
            //JabdActividad
            CreateMap<JabdActividadToCreateDTO, JabdActividad>();
            CreateMap<JabdActividad, JabdActividadToListDTO>();        
            //Cabecera
            CreateMap<CabeceraCXCToCreateDTO, CabeceraCXC>();
            CreateMap<CabeceraCXCToEditDTO,CabeceraCXC>();
            CreateMap<CabeceraCXC, CabeceraCXCToListDTO>();        

        }
    }
}