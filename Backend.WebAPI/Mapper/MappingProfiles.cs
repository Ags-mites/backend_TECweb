using AutoMapper;
using Backend.DTOs;
using Backend.DTOs.Account;
using Backend.DTOs.Worker;
using Backend.DTOs.ClientsFac;
using Backend.DTOs.CiudadEntrFac;
using Backend.DTOs.FacturacionCliente;
using Backend.DTOs.Reason;
using Backend.DTOs.AuditAM;
using Backend.DTOs.MR_ACTIVIDAD;
using Backend.DTOs.AccountType;
using Backend.DTOs.PayrollDetail;
using Backend.DTOs.PayrollHeader;
using Backend.DTOs.Movements;
using Backend.DTOs.Voucher;
using Backend.DTOs.VoucherType;
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
            
            CreateMap<Account, AccountToListDTO>()
            .ForMember(dto => dto.AccountTypeName, opt 
            => opt.MapFrom(src => src.AccountType.Name));

            CreateMap<AccountTypeToCreateDTO, AccountType>();
            CreateMap<AccountTypeToEditDTO,AccountType>();
            CreateMap<AccountType, AccountTypeToListDTO>();
            

            
            //Nomina
            CreateMap<WorkerToCreateDTO, Workers>();
            CreateMap<WorkerToEditDTO,Workers>();
            CreateMap<Workers, WorkerToListDTO>();
            CreateMap<ReasonToCreateDTO, Reasons>();
            CreateMap<ReasonToEditDTO, Reasons>();
            CreateMap<Reasons, ReasonToListDTO>();
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
                    
            //simple page 2
            CreateMap<CiudadEntrFacToCreateDTO, CiudadEntrFac>();
            CreateMap<CiudadEntrFac, CiudadEntrFacToListDTO>();
            //page complicada
            CreateMap<FacturacionClienteToCreateDTO, FacturacionCliente>();
            CreateMap<FacturacionClienteToEditDTO,FacturacionCliente>();
            CreateMap<FacturacionCliente, FacturacionClienteToListDTO>();

            CreateMap<Account, AccountToListDTO>()
            .ForMember(dto => dto.AccountTypeName, opt => opt.MapFrom(src => src.AccountType.Name));

        }
    }
}