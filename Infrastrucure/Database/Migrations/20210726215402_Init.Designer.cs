﻿// <auto-generated />
using System;
using Infrastructure.Database.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PersonReferenceContext))]
    [Migration("20210726215402_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tbilisi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Batumi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Telavi"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Gender", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            GenderName = "Male"
                        },
                        new
                        {
                            Id = (byte)2,
                            GenderName = "Female"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.Property<bool>("IsDefault")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayName = "Georgian",
                            IsDefault = true,
                            LanguageCode = "Ka"
                        },
                        new
                        {
                            Id = 2,
                            DisplayName = "English",
                            IsDefault = false,
                            LanguageCode = "En"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte?>("GenderId")
                        .HasColumnType("tinyint");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("GenderId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Domain.Entities.PersonRelatedPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("RelatedPersonId")
                        .HasColumnType("int");

                    b.Property<int?>("RelatedPersonTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("RelatedPersonId");

                    b.HasIndex("RelatedPersonTypeId");

                    b.ToTable("RelatedPersones");
                });

            modelBuilder.Entity("Domain.Entities.RelatedPersonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("RelatedPersonTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Mother"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Father"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Brother"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Sister"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Translation", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasMaxLength(48)
                        .HasColumnType("nvarchar(48)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.HasKey("Id");

                    b.ToTable("Translations");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Key = "Model.Invalid.PersonalNumber",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "არა ვალიდური პირადი ნომერი!"
                        },
                        new
                        {
                            Id = (byte)2,
                            Key = "Model.Invalid.PersonalNumber",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Invalid personal number!"
                        },
                        new
                        {
                            Id = (byte)3,
                            Key = "Model.Invalid.FirstName",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "არა ვალიდური სახელი!"
                        },
                        new
                        {
                            Id = (byte)4,
                            Key = "Model.Invalid.FirstName",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Invalid First Name!"
                        },
                        new
                        {
                            Id = (byte)5,
                            Key = "Model.Invalid.FirstName",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "არა ვალიდური გვარი!"
                        },
                        new
                        {
                            Id = (byte)6,
                            Key = "Model.Invalid.LastName",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Invalid Last Name!"
                        },
                        new
                        {
                            Id = (byte)7,
                            Key = "Model.Invalid.PhoneNumber",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "არა ვალიდური ტელეფონის ნომერი!"
                        },
                        new
                        {
                            Id = (byte)8,
                            Key = "Model.Invalid.PhoneNumber",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Invalid phone number!"
                        },
                        new
                        {
                            Id = (byte)9,
                            Key = "Model.Invalid.Age",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "არა ვალიდური ასაკი!"
                        },
                        new
                        {
                            Id = (byte)10,
                            Key = "Model.Invalid.Age",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Invalid Age!"
                        },
                        new
                        {
                            Id = (byte)11,
                            Key = "Model.Invalid.CityId",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "არა ვალიდური ქალაქის იდენთიფიკატორი!"
                        },
                        new
                        {
                            Id = (byte)12,
                            Key = "Model.Invalid.CityId",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Invalid City identifier!"
                        },
                        new
                        {
                            Id = (byte)13,
                            Key = "City.ByThisId.NotExist",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "ამ Id -ით ქალაქი არ არსებობს!"
                        },
                        new
                        {
                            Id = (byte)14,
                            Key = "City.ByThisId.NotExist",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "City not exist on this Id!"
                        },
                        new
                        {
                            Id = (byte)15,
                            Key = "RelatedPerson.ByThisId.NotExist",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "ამ Id -ით დაკავშირებული პირი არ არსებობს!"
                        },
                        new
                        {
                            Id = (byte)16,
                            Key = "RelatedPerson.ByThisId.NotExist",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Related person by this Id not exist!"
                        },
                        new
                        {
                            Id = (byte)17,
                            Key = "RelatedPerson.ByThisType.NotExist",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "ამ Type-ით დაკავშირებული პირი არ არსებობს!"
                        },
                        new
                        {
                            Id = (byte)18,
                            Key = "RelatedPerson.ByThisType.NotExist",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Related person by this Type not exist!"
                        },
                        new
                        {
                            Id = (byte)19,
                            Key = "Gender.ByThisName.NotExist",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "სქესი ამ სახელით არ არსებობს!"
                        },
                        new
                        {
                            Id = (byte)20,
                            Key = "Gender.ByThisName.NotExist",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Gender by this name not exist!"
                        },
                        new
                        {
                            Id = (byte)21,
                            Key = "Model.Invalid.PersonId",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "არა ვალიდური PersonId!"
                        },
                        new
                        {
                            Id = (byte)22,
                            Key = "Model.Invalid.PersonId",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Invalid PersonId!"
                        },
                        new
                        {
                            Id = (byte)23,
                            Key = "Model.Invalid.RelatedPersonId",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "არა ვალიდური RelatedPersonId!"
                        },
                        new
                        {
                            Id = (byte)24,
                            Key = "Model.Invalid.RelatedPersonId",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Invalid RelatedPersonId!"
                        },
                        new
                        {
                            Id = (byte)25,
                            Key = "Model.Invalid.RelatedPersonType",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "არა ვალიდური RelatedPersonType!"
                        },
                        new
                        {
                            Id = (byte)26,
                            Key = "Model.Invalid.RelatedPersonType",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Invalid RelatedPersonType!"
                        },
                        new
                        {
                            Id = (byte)27,
                            Key = "Person.ByThisId.NotExist",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "ამ Id -ით ადამიანი არ არსებობს!"
                        },
                        new
                        {
                            Id = (byte)28,
                            Key = "Person.ByThisId.NotExist",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Person by this Id not exist!"
                        },
                        new
                        {
                            Id = (byte)29,
                            Key = "Model.Invalid.GenderName",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "არა ვალიდური სქესის დასახელება!"
                        },
                        new
                        {
                            Id = (byte)30,
                            Key = "Model.Invalid.GenderName",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Invalid Gender Name!"
                        },
                        new
                        {
                            Id = (byte)31,
                            Key = "Gender.ByThisName.NotExist",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "ამ სახელის სქესი ბაზაში არ არის!"
                        },
                        new
                        {
                            Id = (byte)32,
                            Key = "Gender.ByThisName.NotExist",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Gender by this name not exist in db!"
                        },
                        new
                        {
                            Id = (byte)33,
                            Key = "Model.Invalid.File",
                            LanguageCode = "Ka",
                            LanguageId = 1,
                            LanguageName = "Georgian",
                            Value = "არა ვალიდური სურათი!"
                        },
                        new
                        {
                            Id = (byte)34,
                            Key = "Model.Invalid.File",
                            LanguageCode = "En",
                            LanguageId = 2,
                            LanguageName = "English",
                            Value = "Invalid Gender Image!"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.HasOne("Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Domain.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.Navigation("City");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Domain.Entities.PersonRelatedPerson", b =>
                {
                    b.HasOne("Domain.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("Domain.Entities.Person", "RelatedPerson")
                        .WithMany()
                        .HasForeignKey("RelatedPersonId");

                    b.HasOne("Domain.Entities.RelatedPersonType", "RelatedPersonType")
                        .WithMany()
                        .HasForeignKey("RelatedPersonTypeId");

                    b.Navigation("Person");

                    b.Navigation("RelatedPerson");

                    b.Navigation("RelatedPersonType");
                });
#pragma warning restore 612, 618
        }
    }
}