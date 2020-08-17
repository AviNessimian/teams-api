using InternetTeams.Application.Interfaces;
using InternetTeams.Application.Models;
using InternetTeams.Application.Bases;
using InternetTeams.Application.Contracts;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTeams.Application.UseCases
{
    internal class GetDomainValuesByNameInteractor : IGetDomainValuesByNameInteractor
    {
        private readonly IDomainValueRepository _domainValueRepository;
        private readonly ICommonService _commonService;

        public GetDomainValuesByNameInteractor(IDomainValueRepository domainValueRepository,
            ICommonService commonService)
        {
            _domainValueRepository = domainValueRepository;
            _commonService = commonService;
        }


        // Create an implementation to retrieve the documents of a domain by domain name (collection name). 
        public async Task<GetDomainValuesByNameResponse> Handle(Input<GetDomainValuesByNameRequest> input, CancellationToken cancellationToken)
        {
            var collacationName = await _commonService.ValidateCollectionsName(input.Data.CollactionName);

            var domainValueList = await _domainValueRepository.Get(collacationName, Input<PagingInput>.Set(input.Data), null, cancellationToken);

            var count = await _domainValueRepository.Count(collacationName);

            return new GetDomainValuesByNameResponse(count, domainValueList.ToList());
        }
    }
}