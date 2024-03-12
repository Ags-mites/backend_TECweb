using AutoMapper;
using Backend.DTOs;
using Backend.DTOs.Account;
using Backend.DTOs.Worker;
using Backend.DTOs.ClientsFac;
using Backend.DTOs.CobradorCuentasCobrar;
using Backend.DTOs.FormaDePagoCXC;
using Backend.DTOs.JabdActividad;
using Backend.DTOs.CabeceraCXC;
using Backend.DTOs.CiudadEntrFac;
using Backend.DTOs.SilcActividad;
using Backend.DTOs.FacturacionCliente;
using Backend.DTOs.ReasonAdmission;
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
            CreateMap<AccountTypeToCreateDTO, AccountType>();
            CreateMap<AccountTypeToEditDTO,AccountType>();
            CreateMap<AccountType, AccountTypeToListDTO>();
            CreateMap<MovementToCreateDTO, Movement>();
            CreateMap<MovementToEditDTO,Movement>();
            CreateMap<Movement, MovementToListDTO>();
            CreateMap<VoucherToCreateDTO, Voucher>();
            CreateMap<VoucherToEditDTO,Voucher>();
            CreateMap<Voucher, VoucherToListDTO>();
            CreateMap<VoucherTypeToCreateDTO, VoucherType>();
            CreateMap<VoucherTypeToEditDTO,VoucherType>();
            CreateMap<VoucherType, VoucherTypeToListDTO>();

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