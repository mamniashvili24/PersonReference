using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.EF
{
    public static class FluentConfiguration
    {
        public static void RelatedPersonType(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<RelatedPersonType>()
                .Property(p => p.Type)
                .HasMaxLength(500)
                .IsRequired();
        }
        public static void Translation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Translation>(entity =>
            {
                entity.Property(m => m.Key)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(m => m.Value)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(m => m.LanguageCode)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(m => m.LanguageName)
                    .IsRequired()
                    .HasMaxLength(48);
            });
        }
        public static void Language(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(m => m.DisplayName)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(64);

                entity.Property(m => m.LanguageCode)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(32);

                entity.Property(m => m.IsDefault)
                    .IsRequired()
                    .HasDefaultValue(false);
            });
        }
        public static void Person(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(p => p.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(p => p.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(p => p.PhoneNumber)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(p => p.PersonalNumber)
                    .HasMaxLength(11)
                    .IsRequired();

                entity.Property(p => p.Birthday)
                    .IsRequired();
            });
        }
        public static void Gender(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Gender>()
                .Property(p => p.GenderName)
                .HasMaxLength(250)
                .IsRequired();
        }
        public static void City(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<City>()
                .Property(p => p.Name)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}