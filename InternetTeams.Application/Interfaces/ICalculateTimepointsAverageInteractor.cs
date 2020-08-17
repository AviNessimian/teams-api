using InternetTeams.Application.Models;
using InternetTeams.Application.Bases;
using InternetTeams.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTeams.Application.Interfaces
{
    public interface ICalculateTimepointsAverageInteractor
    {
        Task<List<TimepointAverage>> Handle(Input<CalculateTimepointsAverageRequest> input, CancellationToken cancellationToken = default);
    }
}