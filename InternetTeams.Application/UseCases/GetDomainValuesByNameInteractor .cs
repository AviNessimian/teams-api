using InternetTeams.Application.Interfaces;
using InternetTeams.Application.Models;
using InternetTeams.Domain.Contracts;
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
        public async Task<GetDomainValuesByNameResponse> Handle(GetDomainValuesByNameRequest input, CancellationToken cancellationToken)
        {
            var collacationName = await _commonService.ValidateCollectionsName(input.CollactionName);

            var domainValueList = await _domainValueRepository.Get(collacationName, input.PageSize, input.Page);

            var count = await _domainValueRepository.Count(collacationName);

            return new GetDomainValuesByNameResponse(count, domainValueList.ToList());
        }


    }
}
