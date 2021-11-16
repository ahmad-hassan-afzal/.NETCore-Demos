using Xunit;
using Core;
using Test.ProjectTests.TestData;
using Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using System.Linq;
using Application.Repositories.Project.Command;
using Application.Repositories.Project.Query;
using System.Collections.Generic;

namespace Test.ProjectTests
{
    [Collection("Project")]
    public class ProjectTest : BaseTest
    {

        private readonly CommandContext _context;
        private readonly ICommandProjectRepository _commandRepository;
        private readonly IQueryProjectRepository _queryRepository;

        private int _projectId = SeedData.ProjectId;

        public ProjectTest(Fixture fixture) : base(fixture)
        {
            _commandRepository = Services.GetService<ICommandProjectRepository>();
            _queryRepository = Services.GetService<IQueryProjectRepository>();
            _context = Services.GetService<CommandContext>();
        }

        [Theory]
        [InlineData("Project1", "websiurehdj", "dekldsnfslsDKF")]
        [InlineData("Project2", "siurehdj", "fslsDKFasdd")]
        [Trait("Category", "Project")]
        public void Add_GivenProject_ReturnsProject(string name, string code, string description)
        {

            var model = new Project
            {
                Name = name,
                Code = code,
                Description = description
            };

            Project result = _commandRepository.Add(model);
            _commandRepository.SaveChanges();

            Project expected = _context.Projects.FirstOrDefault(x => x.Id == result.Id);

            result.Should().NotBeNull();
            result.Name.Should().BeEquivalentTo(expected.Name);
            result.Code.Should().BeEquivalentTo(expected.Code);
            result.Description.Should().BeEquivalentTo(expected.Description);
            

        }


        [Theory]
        [InlineData("Project1", "websiurehdj", "numlock")]
        [InlineData("Project3", "websiuj", "numlock")]
        [Trait("Category", "Project")]
        public void Update_GivenProject_ReturnsProject(string name, string code, string description)
        {
            _context.ChangeTracker.Clear();

            var model = new Project()
            {
                Id = _projectId,
                Name = name,
                Code = code,
                Description = description
            };

            Project result = _commandRepository.Update(model);
            _commandRepository.SaveChanges();

            Project expected = _context.Projects.FirstOrDefault(x => x.Id == result.Id);

            result.Should().NotBeNull();
            result.Name.Should().BeEquivalentTo(expected.Name);
            result.Code.Should().BeEquivalentTo(expected.Code);
            result.Description.Should().BeEquivalentTo(expected.Description);

        }


        [Theory]
        [InlineData(4, "Project4", "project4", "85347893")]
        [Trait("Category", "Project")]
        public void Delete_GivenProject_ReturnsProject(int id, string name, string code, string description)
        {

            var model = new Project()
            {
                Id = id,
                Name = name,
                Code = code,
                Description = description
            };

            // First add data 
            _context.Projects.Add(model);

            // Then delete  
            _context.Projects.Remove(model);
            _context.SaveChanges();

            // Then check if its deleted
            var expexted = _context.Projects.FirstOrDefault(x => x.Id == id);

            expexted.Should().BeNull();
        }

        [Theory]
        [InlineData(15)]
        [Trait("Category", "Project")]
        public void GetProjectsByCompanyId_GivenCompanyId_ReturnsAllProjects(int comapnyId)
        {

            _context.Projects.Add(
                new Project
                {
                    Id = 23,
                    Name = "asjdnkas",
                    Description = "jashdjklas",
                    Code = "2232",
                    CompanyId = comapnyId
                }
            );

            _context.SaveChanges();

            var result = _queryRepository.GetByCompanyId(comapnyId);

            result.Should().NotBeNull();
            result.Should().ContainItemsAssignableTo<Project>();

        }

        #region Misc-Tests [Theory-Examples]
        // These Test-Cases are just for Demo Purpose for passing data using [InlineData()]

        [Theory]
        [Trait("Category", "Misc")]
        [InlineData(1, true)]
        [InlineData(15, true)]
        [InlineData(22, false)]
        [InlineData(1234, false)]
        public void IsOdd_TestsEvenOdd(int input, bool expected)
        {
            var result = input % 2 == 1;
            Assert.Equal(expected, result);
        }


        //  -- Data From DataSharer Class
        [Theory]
        [Trait("Category", "Misc")]
        [MemberData(memberName: nameof(IsOddDataShare.IsEvenOddData), MemberType = typeof(IsOddDataShare))]
        public void IsOdd_TestsEvenOdd_UsingDataShare(int input, bool expected)
        {
            var result = input % 2 == 1;
            Assert.Equal(expected, result);
        }


        // -- Data From External Source (i.e. Text File)
        [Theory]
        [Trait("Category", "Misc")]
        [MemberData(memberName: nameof(IsOddDataShare.IsEvenOddExternalData), MemberType = typeof(IsOddDataShare))]
        public void IsOdd_TestsEvenOdd_UsingExternalDataShare(int input, bool expected)
        {
            var result = input % 2 == 1;
            Assert.Equal(expected, result);
        }


        // -- Data From Custom Attribute 
        [Theory]
        [Trait("Category", "Misc")]
        [IsOddData]
        public void IsOdd_TestsEvenOdd_UsingCustomAttribute(int input, bool expected)
        {
            var result = input % 2 == 1;
            Assert.Equal(expected, result);
        }
        #endregion

    }
}
