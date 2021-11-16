using Application.Repositories.Project.Command;
using Application.Repositories.Project.Query;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Controllers;
using Xunit;

namespace Test.ControllersTests
{
    public class ProjectControllerTests 
    {

        private readonly IQueryProjectRepository _queryRepository;
        private readonly ICommandProjectRepository _commandRepository;
        private readonly IMapper _mapper;
        private readonly ProjectController _controller;

        public ProjectControllerTests()
        {
            _queryRepository = new Mock<IQueryProjectRepository>().Object;
            _commandRepository = new Mock<ICommandProjectRepository>().Object;
            _mapper = new Mock<IMapper>().Object;

            _controller = new ProjectController(_queryRepository, _commandRepository, _mapper);
        }

        [Fact]
        [Trait("Category", "Project-Controller")]
        public void Get_ReturnsAllProjects()
        {
            IActionResult result = _controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }

    }
}
