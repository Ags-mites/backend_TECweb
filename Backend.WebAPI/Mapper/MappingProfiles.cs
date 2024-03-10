using AutoMapper;
using Backend.DTOs;
using Backend.DTOs.Account;
using Backend.DTOs.Worker;
using Backend.DTOs.ClientsFac;
using Backend.DTOs.ReasonAdmission;
using Backend.DTOs.AuditAM;
using Backend.DTOs.MR_ACTIVIDAD;
using Backend.DTOs.AccountType;
using Backend.DTOs.PayrollDetail;
using Backend.DTOs.PayrollHeader;
using Backend.Entities;

namespace Backend.WebAPI.Mapper
{
    public class MappingProfiles: Profile
    {
        public  MappingProfiles()
        {
            //Contabilidad
            CreateMap<AccountToCreateDTO, Account>();
            CreateMap<AccountToEditDTO,Account>();
            CreateMap<Account, AccountToListDTO>()
                .ForMember(dest => dest.AccountTypeName, opt 
                => opt.MapFrom(src => src.AccountType.Name));
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
            CreateMap<PayrollDetailToCreateDTO, PayrollDetail>();
            CreateMap<PayrollDetailToEditDTO, PayrollDetail>();
            CreateMap<PayrollDetail, PayrollDetailToListDTO>();
            CreateMap<PayrollHeaderToCreateDTO, PayrollHeader>();
            CreateMap<PayrollHeaderToEditDTO, PayrollHeader>();
            CreateMap<PayrollHeader, PayrollHeaderToListDTO>();
            CreateMap<AuditAMToCreateDTO, AuditAM>();
            CreateMap<AuditAM, AuditAMToCreateDTO>();
            CreateMap<MR_ACTIVIDADToCreateDTO, MR_ACTIVIDAD>();
            CreateMap<MR_ACTIVIDAD, MR_ACTIVIDADToCreateDTO>();

            //facturation
            CreateMap<ClientsFacToCreateDTO, ClientsFac>();
            CreateMap<ClientsFacToEditDTO,ClientsFac>();
            CreateMap<ClientsFac, ClientsFacToListDTO>();
        }
    }
}