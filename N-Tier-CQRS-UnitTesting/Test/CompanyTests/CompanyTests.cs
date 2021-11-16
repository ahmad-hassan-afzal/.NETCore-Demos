using Xunit;
using Core;
using Application.Repositories.Company.Command;
using Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Test.CompanyTests
{
    [Collection("Company")]
    public class CompanyTest : BaseTest
    {

        private readonly ICommandCompanyRepository _commandRepository;
        private readonly CommandContext _context;

        private int _companyId = SeedData.CompanyId;

        public CompanyTest(Fixture fixture):base(fixture)
        {
            _commandRepository = Services.GetService<ICommandCompanyRepository>();
            _context = Services.GetService<CommandContext>();
        }

        [Theory]
        [InlineData("Company1","websiurehdj","numlock")]
        [InlineData("Company2","websiu","numlock")]
        [InlineData("Company3","websiuj","numlock")]
        [Trait("Category", "Company")]
        public void Add_GivenCompany_ReturnsCompany(string name, string website, string phone)
        {

            var model = new Company
            {
                Name = name,
                Website = website,
                Phone = phone
            };

            Company result = _commandRepository.Add(model);
            _commandRepository.SaveChanges();

            Company expected = _context.Company.FirstOrDefault( x => x.Id == result.Id);

            result.Should().NotBeNull();
            result.Name.Should().BeEquivalentTo(expected.Name);
            result.Website.Should().BeEquivalentTo(expected.Website);
            result.Phone.Should().BeEquivalentTo(expected.Phone);

        }

        [Theory]
        [InlineData("Company1", "websiurehdj", "numlock")]
        [InlineData("Company3", "websiuj", "numlock")]
        [Trait("Category", "Company")]
        public void Update_GivenCompany_ReturnsCompany(string name, string website, string phone)
        {
            _context.ChangeTracker.Clear();

            var model = new Company()
            {
                Id = _companyId,
                Name = name,
                Website = website,
                Phone = phone
            };

            Company result = _commandRepository.Update(model);
            _commandRepository.SaveChanges();

            Company expected = _context.Company.FirstOrDefault(x => x.Id == result.Id);

            result.Should().NotBeNull();
            result.Name.Should().BeEquivalentTo(expected.Name);
            result.Website.Should().BeEquivalentTo(expected.Website);
            result.Phone.Should().BeEquivalentTo(expected.Phone);

        }


        [Theory]
        [InlineData(4, "Company4", "company4.com", "85347893")]
        [Trait("Category", "Company")]
        public void Delete_GivenCompany_ReturnsCompany(int id, string name, string website, string phone)
        {

            var model = new Company()
            {
                Id = id,
                Name = name,
                Website = website,
                Phone = phone
            };

            // First add data 
            _context.Company.Add(model);

            // Then delete  
            _context.Company.Remove(model);
            _context.SaveChanges();

            // Then check if its deleted
            var expexted = _context.Company.FirstOrDefault(x => x.Id == id);

            expexted.Should().BeNull();
        }
    }
}
