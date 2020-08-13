using System.Collections.Generic;
using System.Threading.Tasks;
using InternetTeams.Application.Models;
using InternetTeams.Domain.Entities;

namespace InternetTeams.Application.Interfaces
{
    public interface IGetAllDomainValuesInteractor
    {
        Task<List<DomainValue>> Handle(GetAllDomainValuesRequest input);
    }
}