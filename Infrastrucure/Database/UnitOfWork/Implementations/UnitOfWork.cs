using Domain.Entities;
using System.Threading.Tasks;
using Infrastructure.Database.EF;
using Infrastructure.Database.Repository.Abstractions;
using Infrastructure.Database.UnitOfWork.Abstractions;

namespace Infrastructure.Database.UnitOfWork.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        #region [ Constructor(s) ]

        public UnitOfWork(PersonReferenceContext context
            , IRepository<City> cityRepository
            , IRepository<Gender> genderRepository
            , IRepository<Person> personRepository
            , IRepository<Language> languageRepository
            , IRepository<Translation> translationyRepository
            , IRepository<PersonRelatedPerson> relatedPersonRepository
            , IRepository<RelatedPersonType> relatedPersonTypeRepository)
        {
            _context = context;
            _cityRepository = cityRepository;
            _genderRepository = genderRepository;
            _personRepository = personRepository;
            _languageRepository = languageRepository;
            _translationyRepository = translationyRepository;
            _relatedPersonRepository = relatedPersonRepository;
            _relatedPersonTypeRepository = relatedPersonTypeRepository;
        }

        #endregion

        #region [ Public Field(s) ]

        public IRepository<City> CityRepository => _cityRepository;

        public IRepository<Gender> GenderRepository => _genderRepository;

        public IRepository<Person> PersonRepository => _personRepository;

        public IRepository<Language> LanguageRepository => _languageRepository;

        public IRepository<Translation> TranslationRepository => _translationyRepository;

        public IRepository<PersonRelatedPerson> RelatedPersonRepository => _relatedPersonRepository;

        public IRepository<RelatedPersonType> RelatedPersonTypeRepository => _relatedPersonTypeRepository;

        #endregion

        #region [ Public Method(s) ]

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region [ Private Field(s) ]

        private readonly PersonReferenceContext _context;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Gender> _genderRepository;
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Language> _languageRepository;
        private readonly IRepository<Translation> _translationyRepository;
        private readonly IRepository<PersonRelatedPerson> _relatedPersonRepository;
        private readonly IRepository<RelatedPersonType> _relatedPersonTypeRepository;

        #endregion
    }
}