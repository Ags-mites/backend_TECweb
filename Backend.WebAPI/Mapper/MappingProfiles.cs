using AutoMapper;
using Backend.DTOs;
using Backend.DTOs.Account;
using Backend.DTOs.Worker;
using Backend.DTOs.Cities;
using Backend.DTOs.Client;
using Backend.DTOs.Reason;
using Backend.DTOs.AccountType;
using Backend.DTOs.PayrollDetail;
using Backend.DTOs.PayrollHeader;
using Backend.DTOs.Movements;
using Backend.Entities;
using Backend.DTOs.Invoice;
using Backend.DTOs.InvoiceDetail;
using Backend.DTOs.EntryHeader;
using Backend.DTOs.EntryDetail;


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
            CreateMap<MovementToCreateDTO, Movement>();
            CreateMap<MovementToEditDTO,Movement>();
            CreateMap<Movement, MovementToListDTO>();

            CreateMap<EntryHeaderToCreateDTO, EntryHeader>();
            CreateMap<EntryHeaderToEditDTO, EntryHeader>();
            CreateMap<EntryHeader, EntryHeaderToListDTO>()
                .ForMember(dest => dest.EntryDetails, 
                opt => opt.MapFrom(src => src.EntryDetails));

            CreateMap<EntryDetailToCreateDTO, EntryDetail>();
            CreateMap<EntryDetailToEditDTO, EntryDetail>();
            CreateMap<EntryDetail, EntryDetailToListDTO>()
                .ForMember(dest => dest.AccountName, 
                opt => opt.MapFrom(src => src.Account.Name));

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

            //facturation
            CreateMap<CitiesToCreateDTO, Cities>();
            CreateMap<CitiesToEditDTO, Cities>();
            CreateMap<Cities, CitiesToListDTO>();

            CreateMap<ClientsToCreateDTO, Clients>();
            CreateMap<ClientsToEditDTO,Clients>();
            CreateMap<Clients, ClientsToListDTO>();

            CreateMap<InvoiceToCreateDTO, Invoice>();
            CreateMap<InvoiceToEditDTO, Invoice>();
            CreateMap<Invoice, InvoiceToListDTO>();

            CreateMap<InvoiceDetailToCreateDTO, InvoiceDetail>();
            CreateMap<InvoiceDetailToEditDTO, InvoiceDetail>();
            CreateMap<InvoiceDetail, InvoiceDetailToListDTO>();


            CreateMap<Account, AccountToListDTO>()
            .ForMember(dto => dto.AccountTypeName, opt => opt.MapFrom(src => src.AccountType.Name));

        }
    }
}