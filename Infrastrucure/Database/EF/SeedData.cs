using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.EF
{
    public static class SeedData
    {
        public static void InsertRelatedPersonType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RelatedPersonType>().HasData(
                new RelatedPersonType
                {
                    Id = 1,
                    Type = "Mother"
                },
                new RelatedPersonType
                {
                    Id = 2,
                    Type = "Father"
                },
                new RelatedPersonType
                {
                    Id = 3,
                    Type = "Brother"
                },
                new RelatedPersonType
                {
                    Id = 4,
                    Type = "Sister"
                });
        }
        public static void InsertTranslations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Translation>().HasData(
                new Translation
                {
                    Id = 1,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "Model.Invalid.PersonalNumber",
                    Value = "არა ვალიდური პირადი ნომერი!"
                },
                new Translation
                {
                    Id = 2,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "Model.Invalid.PersonalNumber",
                    Value = "Invalid personal number!"
                },
                new Translation
                {
                    Id = 3,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "Model.Invalid.FirstName",
                    Value = "არა ვალიდური სახელი!"
                },
                new Translation
                {
                    Id = 4,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "Model.Invalid.FirstName",
                    Value = "Invalid First Name!"
                },
                new Translation
                {
                    Id = 5,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "Model.Invalid.FirstName",
                    Value = "არა ვალიდური გვარი!"
                },
                new Translation
                {
                    Id = 6,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "Model.Invalid.LastName",
                    Value = "Invalid Last Name!"
                },
                new Translation
                {
                    Id = 7,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "Model.Invalid.PhoneNumber",
                    Value = "არა ვალიდური ტელეფონის ნომერი!"
                },
                new Translation
                {
                    Id = 8,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "Model.Invalid.PhoneNumber",
                    Value = "Invalid phone number!"
                },
                new Translation
                {
                    Id = 9,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "Model.Invalid.Age",
                    Value = "არა ვალიდური ასაკი!"
                },
                new Translation
                {
                    Id = 10,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "Model.Invalid.Age",
                    Value = "Invalid Age!"
                },
                new Translation
                {
                    Id = 11,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "Model.Invalid.CityId",
                    Value = "არა ვალიდური ქალაქის იდენთიფიკატორი!"
                },
                new Translation
                {
                    Id = 12,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "Model.Invalid.CityId",
                    Value = "Invalid City identifier!"
                },
                new Translation
                {
                    Id = 13,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "City.ByThisId.NotExist",
                    Value = "ამ Id -ით ქალაქი არ არსებობს!"
                },
                new Translation
                {
                    Id = 14,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "City.ByThisId.NotExist",
                    Value = "City not exist on this Id!"
                },
                new Translation
                {
                    Id = 15,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "RelatedPerson.ByThisId.NotExist",
                    Value = "ამ Id -ით დაკავშირებული პირი არ არსებობს!"
                },
                new Translation
                {
                    Id = 16,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "RelatedPerson.ByThisId.NotExist",
                    Value = "Related person by this Id not exist!"
                },
                new Translation
                {
                    Id = 17,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "RelatedPerson.ByThisType.NotExist",
                    Value = "ამ Type-ით დაკავშირებული პირი არ არსებობს!"
                },
                new Translation
                {
                    Id = 18,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "RelatedPerson.ByThisType.NotExist",
                    Value = "Related person by this Type not exist!"
                },
                new Translation
                {
                    Id = 19,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "Gender.ByThisName.NotExist",
                    Value = "სქესი ამ სახელით არ არსებობს!"
                },
                new Translation
                {
                    Id = 20,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "Gender.ByThisName.NotExist",
                    Value = "Gender by this name not exist!"
                },
                new Translation
                {
                    Id = 21,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "Model.Invalid.PersonId",
                    Value = "არა ვალიდური PersonId!"
                },
                new Translation
                {
                    Id = 22,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "Model.Invalid.PersonId",
                    Value = "Invalid PersonId!"
                },
                new Translation
                {
                    Id = 23,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "Model.Invalid.RelatedPersonId",
                    Value = "არა ვალიდური RelatedPersonId!"
                },
                new Translation
                {
                    Id = 24,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "Model.Invalid.RelatedPersonId",
                    Value = "Invalid RelatedPersonId!"
                },
                new Translation
                {
                    Id = 25,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "Model.Invalid.RelatedPersonType",
                    Value = "არა ვალიდური RelatedPersonType!"
                },
                new Translation
                {
                    Id = 26,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "Model.Invalid.RelatedPersonType",
                    Value = "Invalid RelatedPersonType!"
                },
                new Translation
                {
                    Id = 27,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "Person.ByThisId.NotExist",
                    Value = "ამ Id -ით ადამიანი არ არსებობს!"
                },
                new Translation
                {
                    Id = 28,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "Person.ByThisId.NotExist",
                    Value = "Person by this Id not exist!"
                },
                new Translation
                {
                    Id = 29,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "Model.Invalid.GenderName",
                    Value = "არა ვალიდური სქესის დასახელება!"
                },
                new Translation
                {
                    Id = 30,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "Model.Invalid.GenderName",
                    Value = "Invalid Gender Name!"
                },
                new Translation
                {
                    Id = 31,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "Gender.ByThisName.NotExist",
                    Value = "ამ სახელის სქესი ბაზაში არ არის!"
                },
                new Translation
                {
                    Id = 32,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "Gender.ByThisName.NotExist",
                    Value = "Gender by this name not exist in db!"
                },
                new Translation
                {
                    Id = 33,
                    LanguageId = 1,
                    LanguageCode = "Ka",
                    LanguageName = "Georgian",
                    Key = "Model.Invalid.File",
                    Value = "არა ვალიდური სურათი!"
                },
                new Translation
                {
                    Id = 34,
                    LanguageId = 2,
                    LanguageCode = "En",
                    LanguageName = "English",
                    Key = "Model.Invalid.File",
                    Value = "Invalid Gender Image!"
                });
        }
        public static void InsertLanguages(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    Id = 1,
                    DisplayName = "Georgian",
                    LanguageCode = "Ka",
                    IsDefault = true,
                },
                new Language
                {
                    Id = 2,
                    DisplayName = "English",
                    LanguageCode = "En",
                    IsDefault = false,
                });
        }
        public static void InsertGenders(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(
                new Gender
                {
                    Id = 1,
                    GenderName = "Male"
                },
                new Gender
                {
                    Id = 2,
                    GenderName = "Female"
                });
        }
        public static void InsertCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "Tbilisi"
                },
                new City
                {
                    Id = 2,
                    Name = "Batumi"
                },
                new City
                {
                    Id = 3,
                    Name = "Telavi"
                });
        }
    }
}