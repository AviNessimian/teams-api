using InternetTeams.Application.Models;
using InternetTeams.Domain.Bases;
using InternetTeams.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTeams.Application.Interfaces
{
    public interface IGetAllDomainValuesInteractor
    {
        Task<List<DomainValue>> Handle(Input<GetAllDomainValuesRequest> input, CancellationToken cancellationToken = default);
    }
}