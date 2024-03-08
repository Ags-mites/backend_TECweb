using AutoMapper;
using Backend.DTOs;
using Backend.DTOs.Account;
using Backend.DTOs.Worker;
using Backend.DTOs.ClientsFac;
using Backend.DTOs.ReasonAdmission;
using Backend.DTOs.AccountType;
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
            CreateMap<AccountTypeToCreateDTO, AccountType>();
            CreateMap<AccountTypeToEditDTO,AccountType>();
            CreateMap<AccountType, AccountTypeToListDTO>();

            //Nomina
            CreateMap<WorkerToCreateDTO, Workers>();
            CreateMap<WorkerToEditDTO,Workers>();
            CreateMap<Workers, WorkerToListDTO>();
            CreateMap<ReasonAdmissionToCreateDTO, ReasonAdmission>();
            CreateMap<ReasonAdmissionToEditDTO, ReasonAdmission>();
            CreateMap<ReasonAdmission, ReasonAdmissionToListDTO>();


            //facturation
            CreateMap<ClientsFacToCreateDTO, ClientsFac>();
            CreateMap<ClientsFacToEditDTO,ClientsFac>();
            CreateMap<ClientsFac, ClientsFacToListDTO>();
        }
    }
}