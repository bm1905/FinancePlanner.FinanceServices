using AutoMapper;
using FinancePlanner.FinanceServices.Domain.Entities;
using FinancePlanner.Shared.Models.Common;
using FinancePlanner.Shared.Models.FinanceServices;

namespace FinancePlanner.FinanceServices.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BiWeeklyHoursAndRateDto, BiWeeklyHoursAndRate>().ReverseMap();
        CreateMap<PreTaxDeductionDto, PreTaxDeduction>().ReverseMap();
        CreateMap<PostTaxDeductionDto, PostTaxDeduction>().ReverseMap();
        CreateMap<TaxInformationDto, TaxInformation>().ReverseMap();
        CreateMap<TaxableWageInformationDto, TaxableWageInformation>().ReverseMap();
        CreateMap<TaxWithheldInformationDto, TaxWithheldInformation>().ReverseMap();
        CreateMap<PayInformationRequest, PayInformation>();
        CreateMap<PayInformation, PayInformationResponse>();
        CreateMap<IncomeInformationRequest, IncomeInformation>();
        CreateMap<IncomeInformation, IncomeInformationResponse>();
    }
}