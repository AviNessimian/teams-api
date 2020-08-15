using InternetTeams.Application.Interfaces;
using InternetTeams.Domain.Contracts;
using InternetTeams.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTeams.Application.Services
{
    internal class CommonService : ICommonService
    {
        private readonly IDomainValueRepository _domainValueRepository;

        public CommonService(IDomainValueRepository domainValueRepository)
        {
            _domainValueRepository = domainValueRepository;
        }

        public async Task<List<string>> GetDomainNames(CancellationToken cancellationToken = default)
        {
            var domains = await _domainValueRepository.GetDomainValueCollectionsNames();

            var listOfDomainNames = domains.ToList();
             listOfDomainNames.Sort();

            return listOfDomainNames;
        }


        public async Task<string> ValidateCollectionsName(string collactionName, CancellationToken cancellationToken = default)
        {
            var collectionsNames = await _domainValueRepository.GetDomainValueCollectionsNames(cancellationToken);

            var collacationName = collectionsNames.FirstOrDefault(x => x.ToLower() == collactionName.ToLower());
            if (collacationName == null)
            {
                throw new NotFoundException($"{collactionName} collaction not found");
            }

            return collacationName;
        }

    }
}
