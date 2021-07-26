using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    GenderName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelatedPersonTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedPersonTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    LanguageName = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<byte>(type: "tinyint", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelatedPersones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    RelatedPersonId = table.Column<int>(type: "int", nullable: true),
                    RelatedPersonTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedPersones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedPersones_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelatedPersones_Persons_RelatedPersonId",
                        column: x => x.RelatedPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelatedPersones_RelatedPersonTypes_RelatedPersonTypeId",
                        column: x => x.RelatedPersonTypeId,
                        principalTable: "RelatedPersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tbilisi" },
                    { 2, "Batumi" },
                    { 3, "Telavi" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderName" },
                values: new object[,]
                {
                    { (byte)1, "Male" },
                    { (byte)2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "DisplayName", "IsDefault", "LanguageCode" },
                values: new object[] { 1, "Georgian", true, "Ka" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "DisplayName", "LanguageCode" },
                values: new object[] { 2, "English", "En" });

            migrationBuilder.InsertData(
                table: "RelatedPersonTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 4, "Sister" },
                    { 3, "Brother" },
                    { 2, "Father" },
                    { 1, "Mother" }
                });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "Key", "LanguageCode", "LanguageId", "LanguageName", "Value" },
                values: new object[,]
                {
                    { (byte)19, "Gender.ByThisName.NotExist", "Ka", 1, "Georgian", "სქესი ამ სახელით არ არსებობს!" },
                    { (byte)20, "Gender.ByThisName.NotExist", "En", 2, "English", "Gender by this name not exist!" },
                    { (byte)21, "Model.Invalid.PersonId", "Ka", 1, "Georgian", "არა ვალიდური PersonId!" },
                    { (byte)22, "Model.Invalid.PersonId", "En", 2, "English", "Invalid PersonId!" },
                    { (byte)23, "Model.Invalid.RelatedPersonId", "Ka", 1, "Georgian", "არა ვალიდური RelatedPersonId!" },
                    { (byte)24, "Model.Invalid.RelatedPersonId", "En", 2, "English", "Invalid RelatedPersonId!" },
                    { (byte)25, "Model.Invalid.RelatedPersonType", "Ka", 1, "Georgian", "არა ვალიდური RelatedPersonType!" },
                    { (byte)30, "Model.Invalid.GenderName", "En", 2, "English", "Invalid Gender Name!" },
                    { (byte)27, "Person.ByThisId.NotExist", "Ka", 1, "Georgian", "ამ Id -ით ადამიანი არ არსებობს!" },
                    { (byte)28, "Person.ByThisId.NotExist", "En", 2, "English", "Person by this Id not exist!" },
                    { (byte)29, "Model.Invalid.GenderName", "Ka", 1, "Georgian", "არა ვალიდური სქესის დასახელება!" },
                    { (byte)18, "RelatedPerson.ByThisType.NotExist", "En", 2, "English", "Related person by this Type not exist!" },
                    { (byte)31, "Gender.ByThisName.NotExist", "Ka", 1, "Georgian", "ამ სახელის სქესი ბაზაში არ არის!" },
                    { (byte)32, "Gender.ByThisName.NotExist", "En", 2, "English", "Gender by this name not exist in db!" },
                    { (byte)26, "Model.Invalid.RelatedPersonType", "En", 2, "English", "Invalid RelatedPersonType!" },
                    { (byte)17, "RelatedPerson.ByThisType.NotExist", "Ka", 1, "Georgian", "ამ Type-ით დაკავშირებული პირი არ არსებობს!" },
                    { (byte)12, "Model.Invalid.CityId", "En", 2, "English", "Invalid City identifier!" },
                    { (byte)15, "RelatedPerson.ByThisId.NotExist", "Ka", 1, "Georgian", "ამ Id -ით დაკავშირებული პირი არ არსებობს!" },
                    { (byte)1, "Model.Invalid.PersonalNumber", "Ka", 1, "Georgian", "არა ვალიდური პირადი ნომერი!" },
                    { (byte)2, "Model.Invalid.PersonalNumber", "En", 2, "English", "Invalid personal number!" },
                    { (byte)3, "Model.Invalid.FirstName", "Ka", 1, "Georgian", "არა ვალიდური სახელი!" },
                    { (byte)4, "Model.Invalid.FirstName", "En", 2, "English", "Invalid First Name!" },
                    { (byte)5, "Model.Invalid.FirstName", "Ka", 1, "Georgian", "არა ვალიდური გვარი!" },
                    { (byte)6, "Model.Invalid.LastName", "En", 2, "English", "Invalid Last Name!" },
                    { (byte)16, "RelatedPerson.ByThisId.NotExist", "En", 2, "English", "Related person by this Id not exist!" },
                    { (byte)7, "Model.Invalid.PhoneNumber", "Ka", 1, "Georgian", "არა ვალიდური ტელეფონის ნომერი!" },
                    { (byte)9, "Model.Invalid.Age", "Ka", 1, "Georgian", "არა ვალიდური ასაკი!" },
                    { (byte)10, "Model.Invalid.Age", "En", 2, "English", "Invalid Age!" },
                    { (byte)11, "Model.Invalid.CityId", "Ka", 1, "Georgian", "არა ვალიდური ქალაქის იდენთიფიკატორი!" },
                    { (byte)33, "Model.Invalid.File", "Ka", 1, "Georgian", "არა ვალიდური სურათი!" },
                    { (byte)13, "City.ByThisId.NotExist", "Ka", 1, "Georgian", "ამ Id -ით ქალაქი არ არსებობს!" }
                });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "Key", "LanguageCode", "LanguageId", "LanguageName", "Value" },
                values: new object[] { (byte)14, "City.ByThisId.NotExist", "En", 2, "English", "City not exist on this Id!" });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "Key", "LanguageCode", "LanguageId", "LanguageName", "Value" },
                values: new object[] { (byte)8, "Model.Invalid.PhoneNumber", "En", 2, "English", "Invalid phone number!" });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "Key", "LanguageCode", "LanguageId", "LanguageName", "Value" },
                values: new object[] { (byte)34, "Model.Invalid.File", "En", 2, "English", "Invalid Gender Image!" });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityId",
                table: "Persons",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_GenderId",
                table: "Persons",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersones_PersonId",
                table: "RelatedPersones",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersones_RelatedPersonId",
                table: "RelatedPersones",
                column: "RelatedPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersones_RelatedPersonTypeId",
                table: "RelatedPersones",
                column: "RelatedPersonTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "RelatedPersones");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "RelatedPersonTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}