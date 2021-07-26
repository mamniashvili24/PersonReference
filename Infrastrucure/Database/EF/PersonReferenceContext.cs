using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.EF
{
    public class PersonReferenceContext : DbContext
    {
        #region [ Constructor(s) ]

        public PersonReferenceContext(DbContextOptions<PersonReferenceContext> options) : base(options) { }

        #endregion

        #region [ Public Field(s) ]

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Translation> Translations { get; set; }
        public virtual DbSet<PersonRelatedPerson> RelatedPersones { get; set; }
        public virtual DbSet<RelatedPersonType> RelatedPersonTypes { get; set; }

        #endregion

        #region [ Protected Method(s) ]

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RelatedPersonType();
            modelBuilder.Translation();
            modelBuilder.Language();
            modelBuilder.Person();
            modelBuilder.Gender();
            modelBuilder.City();

            modelBuilder.InsertRelatedPersonType();
            modelBuilder.InsertTranslations();
            modelBuilder.InsertLanguages();
            modelBuilder.InsertGenders();
            modelBuilder.InsertCities();
            modelBuilder.Translation();
        }

        #endregion
    }
}