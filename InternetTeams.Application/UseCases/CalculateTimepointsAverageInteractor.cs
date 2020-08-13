using InternetTeams.Application.Interfaces;
using InternetTeams.Application.Models;
using InternetTeams.Domain.Entities;
using InternetTeams.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTeams.Application.UseCases
{
    public class CalculateTimepointsAverageInteractor : ICalculateTimepointsAverageInteractor
    {
        private readonly IDomainValueRepository _domainValueRepository;
        private readonly ICommonService _commonService;

        public CalculateTimepointsAverageInteractor(
            IDomainValueRepository domainValueRepository,
            ICommonService commonService)
        {
            _domainValueRepository = domainValueRepository;
            _commonService = commonService;
        }

        //Create an implementation to calculate the average of the numeric values, 
        //grouped by timepoint, for a given domain name (collection name).
        public async Task<List<TimepointAverage>> Handle(CalculateTimepointsAverageRequest input)
        {
            var collacationName = await _commonService.ValidateCollectionsName(input.CollactionName);
            var timepointAverageList = await _domainValueRepository.GetTimepointAverage(collacationName);

            return timepointAverageList.OrderBy(x => x.Timepoint).ToList();
        }
    }
}
