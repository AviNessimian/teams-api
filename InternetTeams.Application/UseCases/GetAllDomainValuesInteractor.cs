using InternetTeams.Application.Interfaces;
using InternetTeams.Application.Models;
using InternetTeams.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTeams.Application.UseCases
{
    public class GetAllDomainValuesInteractor : IGetAllDomainValuesInteractor
    {
        private readonly IDomainValueRepository _domainValueRepository;

        public GetAllDomainValuesInteractor(IDomainValueRepository domainValueRepository)
        {
            _domainValueRepository = domainValueRepository;
        }

        // Create an implementation to retrieve a list of all domains (collection names).
        public async Task<List<DomainValue>> Handle(GetAllDomainValuesRequest input, CancellationToken cancellationToken = default)
        {
            var allDomainValues = new List<DomainValue>();

            foreach (var collectionName in await _domainValueRepository.GetDomainValueCollectionsNames(cancellationToken))
            {
                var domainValues = await _domainValueRepository.Get(collectionName, input.PageSize, input.Page, null, cancellationToken);
                allDomainValues.AddRange(domainValues);
            }

            return allDomainValues;
        }

    }

}
