using AutoMapper;
using FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Commands;
using FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Queries;
using FinancePlanner.FinanceServices.Domain.Entities;
using FinancePlanner.FinanceServices.Infrastructure.Repositories;
using FinancePlanner.Shared.Models.Exceptions;
using FinancePlanner.Shared.Models.FinanceServices;

namespace FinancePlanner.FinanceServices.Application.Services.IncomeInformationServices;

public class IncomeInformationService : IIncomeInformationService
{
    private readonly IIncomeInformationRepository _incomeInformationRepository;
    private readonly IMapper _mapper;

    public IncomeInformationService(IIncomeInformationRepository incomeInformationRepository, IMapper mapper)
    {
        _incomeInformationRepository = incomeInformationRepository;
        _mapper = mapper;
    }

    public async Task<SaveIncomeInformationCommandResponse> Save(IncomeInformationRequest request, string? userId, int? incomeId)
    {
        SaveIncomeInformationCommandResponse response = new();
        if (userId != null && incomeId != null)
        {
            IncomeInformation? oldData = await _incomeInformationRepository.GetOne(userId, (int)incomeId);
            if (oldData == null)
            {
                throw new NotFoundException($"Record not found for user id: {userId} and income information id: {incomeId}");
            }
            IncomeInformation newData = _mapper.Map<IncomeInformation>(request);
            newData.IncomeInformationId = oldData.IncomeInformationId;
            newData.TaxableWageInformation.TaxableWageInformationId = oldData.TaxableWageInformation.TaxableWageInformationId;
            newData.TaxWithheldInformation.TaxWithheldInformationId = oldData.TaxWithheldInformation.TaxWithheldInformationId;
            bool updateResponse = await _incomeInformationRepository.Update(newData);
            if (!updateResponse)
            {
                throw new NotUpdatedException($"Record not updated for user id: {userId} and income information id: {incomeId}");
            }
            response.IncomeInformationResponse = _mapper.Map<IncomeInformationResponse>(newData);
            return response;
        }
        IncomeInformation incomeInformation = _mapper.Map<IncomeInformation>(request);
        bool saveResponse = await _incomeInformationRepository.Save(incomeInformation);
        if (!saveResponse)
        {
            throw new NotUpdatedException($"Record not updated for user id: {userId} and income information id: {incomeId}");
        }
        response.IncomeInformationResponse = _mapper.Map<IncomeInformationResponse>(incomeInformation);
        return response;
    }

    public async Task<GetIncomeInformationQueryResponse> Get(string userId, int? incomeId)
    {
        List<IncomeInformationResponse> incomeInformationResponses = new();

        if (incomeId != null)
        {
            IncomeInformation? incomeInformation = await _incomeInformationRepository.GetOne(userId, (int)incomeId);
            if (incomeInformation == null) return new GetIncomeInformationQueryResponse();
            IncomeInformationResponse incomeInformationResponse = _mapper.Map<IncomeInformationResponse>(incomeInformation);
            incomeInformationResponses.Add(incomeInformationResponse);
            return new GetIncomeInformationQueryResponse { IncomeInformation = incomeInformationResponses };
        }

        List<IncomeInformation>? incomeInformationList = await _incomeInformationRepository.GetAll(userId);
        if (incomeInformationList == null) return new GetIncomeInformationQueryResponse();
        foreach (IncomeInformation incomeInformation in incomeInformationList)
        {
            IncomeInformationResponse incomeInformationResponse = _mapper.Map<IncomeInformationResponse>(incomeInformation);
            incomeInformationResponses.Add(incomeInformationResponse);
        }
        return new GetIncomeInformationQueryResponse { IncomeInformation = incomeInformationResponses };
    }

    public async Task<DeleteIncomeInformationCommandResponse> Delete(string userId, int incomeId)
    {
        bool response = await _incomeInformationRepository.DeleteOne(userId, incomeId);
        return new DeleteIncomeInformationCommandResponse { IsSuccessful = response };
    }
}