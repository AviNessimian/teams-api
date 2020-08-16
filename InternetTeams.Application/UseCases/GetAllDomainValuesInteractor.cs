using InternetTeams.Application.Interfaces;
using InternetTeams.Application.Models;
using InternetTeams.Domain.Bases;
using InternetTeams.Domain.Contracts;
using InternetTeams.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTeams.Application.UseCases
{
    internal class GetAllDomainValuesInteractor : IGetAllDomainValuesInteractor
    {
        private readonly IDomainValueRepository _domainValueRepository;

        public GetAllDomainValuesInteractor(IDomainValueRepository domainValueRepository)
        {
            _domainValueRepository = domainValueRepository;
        }

        // Create an implementation to retrieve a list of all domains (collection names).
        public async Task<List<DomainValue>> Handle(Input<GetAllDomainValuesRequest> input, CancellationToken cancellationToken = default)
        {
            var output = new List<DomainValue>();

            foreach (var collectionName in await _domainValueRepository.GetDomainValueCollectionsNames(cancellationToken))
            {
                var domainValues = await _domainValueRepository.Get(collectionName, new Input<PagingInput>(input.Data), null, cancellationToken);
                output.AddRange(domainValues);
            }

            return output;
        }
    }
}
