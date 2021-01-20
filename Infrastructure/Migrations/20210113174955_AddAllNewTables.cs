using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddAllNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BirthCountry",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CAEDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CAElisten",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CAEread",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CAEspeak",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CAEwrite",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ConvertedGrade",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EducationCountry",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EducationLevel",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstLanguage",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GMATDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GMATQuantitative",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GMATQuantitativeRank",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GMATTotal",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GMATTotalRank",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GMATVerbal",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GMATVerbalRank",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GMATWriting",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GMATWritingRank",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GREDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GREQuantitative",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GREQuantitativeRank",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GREVerbal",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GREVerbalRank",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GREWriting",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GREWritingRank",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GradeAverage",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GradingSchemeID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "HasPermit",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IELTSDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IELTSTRFNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IELTSlisten",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IELTSread",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IELTSspeak",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IELTSwrite",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsGraduated",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "POBox",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Postal",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RefusedVisa",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TOEFLDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TOEFLlisten",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TOEFLread",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TOEFLspeak",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TOEFLwrite",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserNoticeMessage",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "YesMoreInfo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "hasApplication",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "isProfileStarted",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CAEAccepted",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "CAEAvg",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "CAElisten",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "CAEread",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "CAEspeak",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "CAEwrite",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "IELTSAccepted",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "IELTSAvg",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "IsCollege",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "IsEnglishInstitute",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "IsHighSchool",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "IsUniversity",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "StudyPermit",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "TOEFLAccepted",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "TOEFLSum",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "TOEFLlisten",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "TOEFLread",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "TOEFLspeak",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "TOEFLwrite",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "SchoolRequests");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Campuses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Campuses");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Campuses");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Campuses");

            migrationBuilder.DropColumn(
                name: "Longtitude",
                table: "Campuses");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "AmericanRepresented",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "BankAddress",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "CanadianRepresented",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "InstagramAt",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "InstitutionNumber",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "InstitutionRepresenting",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "LinkedinUrl",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "MinimumStudentRefer",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "MinimumStudentSend",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "OrganizationBelong",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "OthersRepresented",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "ProvidedService",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "RecruitStartTime",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "ReferenceEmail",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "ReferenceInstitution",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "ReferenceName",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "ReferencePhone",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "ReferenceWebsite",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "ReferralStaffID",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "SkypeId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "SwiftCode",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "TransitNumber",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "TwitterAt",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "WhatsAppId",
                table: "Agents");

            migrationBuilder.RenameColumn(
                name: "AgentID",
                table: "Students",
                newName: "AgentId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Schools",
                newName: "SchoolName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Campuses",
                newName: "CampusName");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Schools",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Schools",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PGWP",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "SchoolRequests",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Campuses",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Campuses",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "Agents",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Agents",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Agents",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "MainSourceStudent",
                table: "Agents",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "Agents",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Agents",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Agents",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Agents",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Group = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Path = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradingSchemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradingSchemeName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinScale = table.Column<int>(type: "int", nullable: true),
                    MaxScale = table.Column<int>(type: "int", nullable: true),
                    Step = table.Column<int>(type: "int", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    LetterGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradingSchemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PandaDocTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PandaDocTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PandaDocTemplates_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolPaymentAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    AccountType = table.Column<byte>(type: "tinyint", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    AccountClientId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ApplicationServiceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    TuitionServiceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    AccountVendorCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolPaymentAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolPaymentAccounts_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Ext = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Notify = table.Column<bool>(type: "bit", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolUsers_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreTemplate = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolDocuments_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    ProgramCategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    LeadProgramId = table.Column<int>(type: "int", nullable: true),
                    EATemplateId = table.Column<int>(type: "int", nullable: true),
                    AdditionalDocumentId = table.Column<int>(type: "int", nullable: true),
                    ProgramName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ProgramLevel = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProgramLength = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programs_PandaDocTemplates_AdditionalDocumentId",
                        column: x => x.AdditionalDocumentId,
                        principalTable: "PandaDocTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Programs_PandaDocTemplates_EATemplateId",
                        column: x => x.EATemplateId,
                        principalTable: "PandaDocTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Programs_ProgramCategories_ProgramCategoryId",
                        column: x => x.ProgramCategoryId,
                        principalTable: "ProgramCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programs_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampusPrograms",
                columns: table => new
                {
                    CampusId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    DomTuition = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    IntlTuition = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    StartDates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampusPrograms", x => new { x.CampusId, x.ProgramId });
                    table.ForeignKey(
                        name: "FK_CampusPrograms_Campuses_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CampusPrograms_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SchoolID = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    CampusId = table.Column<int>(type: "int", nullable: false),
                    GradingSchemeId = table.Column<int>(type: "int", nullable: false),
                    ApplicationFee = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TuitionFee = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    DashboardStep = table.Column<byte>(type: "tinyint", nullable: true),
                    Process = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    StudentCode = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IELTSTRFNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    IsProfileCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsGraduated = table.Column<bool>(type: "bit", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthCountry = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    City = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    FirstLanguage = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    GradeAverage = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    EducationLevel = table.Column<int>(type: "int", nullable: false),
                    EducationCountry = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ConvertedGrade = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    UserNoticeMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAttended = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentApplications_Campuses_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentApplications_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentApplications_Schools_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "Schools",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentApplications_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentApplicationId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    RequirePandaDoc = table.Column<bool>(type: "bit", nullable: false),
                    PandaDocId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DocumentKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationDocuments_StudentApplications_StudentApplicationId",
                        column: x => x.StudentApplicationId,
                        principalTable: "StudentApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_StudentApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "StudentApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationDocumentFiles",
                columns: table => new
                {
                    ApplicationDocumentId = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDocumentFiles", x => new { x.ApplicationDocumentId, x.FileId });
                    table.ForeignKey(
                        name: "FK_ApplicationDocumentFiles_ApplicationDocuments_ApplicationDocumentId",
                        column: x => x.ApplicationDocumentId,
                        principalTable: "ApplicationDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationDocumentFiles_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PandaDocDocuments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Process = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    StudentShareInfo_Recipient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentShareInfo_SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentShareLinkExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentShareLink = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ADOAShareInfo_Recipient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADOAShareInfo_SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADOAShareLinkExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ADOAShareLink = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileId = table.Column<long>(type: "bigint", nullable: true),
                    ApplicationDocumentId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PandaDocDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PandaDocDocuments_ApplicationDocuments_ApplicationDocumentId",
                        column: x => x.ApplicationDocumentId,
                        principalTable: "ApplicationDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PandaDocDocuments_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_AgentId",
                table: "Students",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDocumentFiles_FileId",
                table: "ApplicationDocumentFiles",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDocuments_StudentApplicationId",
                table: "ApplicationDocuments",
                column: "StudentApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_CampusPrograms_ProgramId",
                table: "CampusPrograms",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_PandaDocDocuments_ApplicationDocumentId",
                table: "PandaDocDocuments",
                column: "ApplicationDocumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PandaDocDocuments_FileId",
                table: "PandaDocDocuments",
                column: "FileId",
                unique: true,
                filter: "[FileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PandaDocTemplates_SchoolId",
                table: "PandaDocTemplates",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ApplicationId",
                table: "Payments",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_StudentId",
                table: "Payments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_AdditionalDocumentId",
                table: "Programs",
                column: "AdditionalDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_EATemplateId",
                table: "Programs",
                column: "EATemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_ProgramCategoryId",
                table: "Programs",
                column: "ProgramCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_SchoolId",
                table: "Programs",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolDocuments_DocumentId",
                table: "SchoolDocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolDocuments_SchoolId",
                table: "SchoolDocuments",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPaymentAccounts_SchoolId",
                table: "SchoolPaymentAccounts",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolUsers_SchoolId",
                table: "SchoolUsers",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentApplications_CampusId",
                table: "StudentApplications",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentApplications_ProgramId",
                table: "StudentApplications",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentApplications_SchoolID",
                table: "StudentApplications",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentApplications_StudentId",
                table: "StudentApplications",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Agents_AgentId",
                table: "Students",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Agents_AgentId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ApplicationDocumentFiles");

            migrationBuilder.DropTable(
                name: "CampusPrograms");

            migrationBuilder.DropTable(
                name: "GradingSchemes");

            migrationBuilder.DropTable(
                name: "PandaDocDocuments");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "SchoolDocuments");

            migrationBuilder.DropTable(
                name: "SchoolPaymentAccounts");

            migrationBuilder.DropTable(
                name: "SchoolUsers");

            migrationBuilder.DropTable(
                name: "StandardGrades");

            migrationBuilder.DropTable(
                name: "ApplicationDocuments");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "StudentApplications");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "PandaDocTemplates");

            migrationBuilder.DropTable(
                name: "ProgramCategories");

            migrationBuilder.DropIndex(
                name: "IX_Students_AgentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "PGWP",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "SchoolRequests");

            migrationBuilder.RenameColumn(
                name: "AgentId",
                table: "Students",
                newName: "AgentID");

            migrationBuilder.RenameColumn(
                name: "SchoolName",
                table: "Schools",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CampusName",
                table: "Campuses",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<int>(
                name: "AgentID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApartmentNumber",
                table: "Students",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthCountry",
                table: "Students",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CAEDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CAElisten",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CAEread",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CAEspeak",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CAEwrite",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Students",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConvertedGrade",
                table: "Students",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryID",
                table: "Students",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationCountry",
                table: "Students",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EducationLevel",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstLanguage",
                table: "Students",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GMATDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GMATQuantitative",
                table: "Students",
                type: "decimal(7,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GMATQuantitativeRank",
                table: "Students",
                type: "decimal(7,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GMATTotal",
                table: "Students",
                type: "decimal(7,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GMATTotalRank",
                table: "Students",
                type: "decimal(7,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GMATVerbal",
                table: "Students",
                type: "decimal(7,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GMATVerbalRank",
                table: "Students",
                type: "decimal(7,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GMATWriting",
                table: "Students",
                type: "decimal(7,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GMATWritingRank",
                table: "Students",
                type: "decimal(7,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GREDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GREQuantitative",
                table: "Students",
                type: "decimal(7,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GREQuantitativeRank",
                table: "Students",
                type: "decimal(7,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GREVerbal",
                table: "Students",
                type: "decimal(7,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GREVerbalRank",
                table: "Students",
                type: "decimal(7,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GREWriting",
                table: "Students",
                type: "decimal(7,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GREWritingRank",
                table: "Students",
                type: "decimal(7,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Students",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GradeAverage",
                table: "Students",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradingSchemeID",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HasPermit",
                table: "Students",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IELTSDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IELTSTRFNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IELTSlisten",
                table: "Students",
                type: "decimal(2,1)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IELTSread",
                table: "Students",
                type: "decimal(2,1)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IELTSspeak",
                table: "Students",
                type: "decimal(2,1)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IELTSwrite",
                table: "Students",
                type: "decimal(2,1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGraduated",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "Students",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "POBox",
                table: "Students",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "Students",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Postal",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Students",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefusedVisa",
                table: "Students",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetNumber",
                table: "Students",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TOEFLDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TOEFLlisten",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TOEFLread",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TOEFLspeak",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TOEFLwrite",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNoticeMessage",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YesMoreInfo",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "hasApplication",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isProfileStarted",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CAEAccepted",
                table: "Schools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CAEAvg",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CAElisten",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CAEread",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CAEspeak",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CAEwrite",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CountryID",
                table: "Schools",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IELTSAccepted",
                table: "Schools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "IELTSAvg",
                table: "Schools",
                type: "decimal(2,1)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsCollege",
                table: "Schools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnglishInstitute",
                table: "Schools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHighSchool",
                table: "Schools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUniversity",
                table: "Schools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StudyPermit",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "TOEFLAccepted",
                table: "Schools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TOEFLSum",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TOEFLlisten",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TOEFLread",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TOEFLspeak",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TOEFLwrite",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CountryID",
                table: "SchoolRequests",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Campuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Campuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Campuses",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Campuses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Campuses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Campuses",
                type: "decimal(9,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longtitude",
                table: "Campuses",
                type: "decimal(9,6)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "Agents",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Agents",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Agents",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MainSourceStudent",
                table: "Agents",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "Agents",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Agents",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Agents",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Agents",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Agents",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AmericanRepresented",
                table: "Agents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BankAddress",
                table: "Agents",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Agents",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanadianRepresented",
                table: "Agents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Agents",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramAt",
                table: "Agents",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstitutionNumber",
                table: "Agents",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstitutionRepresenting",
                table: "Agents",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedinUrl",
                table: "Agents",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinimumStudentRefer",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinimumStudentSend",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationBelong",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OthersRepresented",
                table: "Agents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProvidedService",
                table: "Agents",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RecruitStartTime",
                table: "Agents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceEmail",
                table: "Agents",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceInstitution",
                table: "Agents",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceName",
                table: "Agents",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferencePhone",
                table: "Agents",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceWebsite",
                table: "Agents",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReferralStaffID",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkypeId",
                table: "Agents",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SwiftCode",
                table: "Agents",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransitNumber",
                table: "Agents",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterAt",
                table: "Agents",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhatsAppId",
                table: "Agents",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);
        }
    }
}
