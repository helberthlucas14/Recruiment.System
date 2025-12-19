using Recruitment.System.Domain.Entity;
using Recruitment.System.Domain.SeedWork;
using Recruitment.System.Domain.SeedWork.SearchableRepository;

namespace Recruitment.System.Domain.Repository
{
    public interface IJobVacancyRepository : 
     IGenericRepository<JobVacancy>,
     ISearchableRepository<JobVacancy>
    {

    }
}
