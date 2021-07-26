using Domain.Entities;
using System.Threading.Tasks;
using Infrastructure.Database.Repository.Abstractions;

namespace Infrastructure.Database.UnitOfWork.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<City> CityRepository { get;  }
        IRepository<Gender> GenderRepository { get;  }
        IRepository<Person> PersonRepository { get;  }
        IRepository<Language> LanguageRepository { get; }
        IRepository<Translation> TranslationRepository { get; }
        IRepository<PersonRelatedPerson> RelatedPersonRepository { get; }
        IRepository<RelatedPersonType> RelatedPersonTypeRepository { get; }
        Task<int> SaveChangesAsync();
    }
}