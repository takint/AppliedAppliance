using Application.Agents.Queries;
using Application.Campuses.Queries;
using Application.CampusesPrograms.Queries;
using Application.Common.Mappings;
using Application.Documents.Queries;
using Application.ProgramCategories.Queries;
using Application.Programs.Queries;
using Application.SchoolDocuments.Queries;
using Application.Schools.Queries;
using Application.Students.Queries;
using AutoMapper;
using Domain.Entities;
using NUnit.Framework;
using System;
using System.Runtime.Serialization;

namespace Application.UnitTests.Mapping
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Test]
        [TestCase(typeof(School), typeof(SchoolDto))]
        [TestCase(typeof(SchoolDto), typeof(School))]
        [TestCase(typeof(Campus), typeof(CampusDto))]
        [TestCase(typeof(CampusDto), typeof(Campus))]
        [TestCase(typeof(Program), typeof(ProgramDto))]
        [TestCase(typeof(ProgramDto), typeof(Program))]
        [TestCase(typeof(Student), typeof(StudentDto))]
        [TestCase(typeof(StudentDto), typeof(Student))]
        [TestCase(typeof(AgentDto), typeof(Agent))]
        [TestCase(typeof(ProgramCategory), typeof(ProgramCategoryDto))]
        [TestCase(typeof(ProgramCategoryDto), typeof(ProgramCategory))]
        [TestCase(typeof(CampusProgram), typeof(CampusProgramDto))]
        [TestCase(typeof(CampusProgramDto), typeof(CampusProgram))]
        [TestCase(typeof(Document), typeof(DocumentDto))]
        [TestCase(typeof(DocumentDto), typeof(Document))]
        [TestCase(typeof(SchoolDocument), typeof(SchoolDocumentDto))]
        [TestCase(typeof(SchoolDocumentDto), typeof(SchoolDocument))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = GetInstanceOf(source);
            _mapper.Map(instance, source, destination);
        }

        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type);

            // Type without parameterless constructor
            return FormatterServices.GetUninitializedObject(type);
        }
    }
}