using Application.Repositories.Project.Command;
using Application.Repositories.Project.DTOs;
using Application.Repositories.Project.Query;
using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/projectxs")]
    public class ProjectController : ControllerBase
    {
        private readonly IQueryProjectRepository _queryProjectRepository;
        private readonly ICommandProjectRepository _commandProjectRepository;
        private readonly IMapper _mapper;

        public ProjectController(IQueryProjectRepository queryRepository, ICommandProjectRepository commandRepository, IMapper mapper)
        {
            _queryProjectRepository = queryRepository;
            _commandProjectRepository = commandRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
            => Ok(_mapper.Map<IEnumerable<ProjectDetailsDTO>>(_queryProjectRepository.GetAllProjects()));

        [HttpGet("/api/companies/{Id}/projects")]
        public IActionResult GetByCompanyId(int Id)
        {
            var result = _queryProjectRepository.GetByCompanyId(Id);
            return Ok(_mapper.Map<IEnumerable<ProjectDetailsDTO>>(result));
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Project project = _queryProjectRepository.GetProject(Id);

            if (project == null)
                return NotFound($"Project (ID: {Id}) Not Found.");

            return Ok(_mapper.Map<ProjectDetailsDTO>(project));
        }


        [HttpPost]
        public IActionResult Post(ProjectReadDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Project Details");
                           
            var result = _commandProjectRepository.Add(_mapper.Map<Project>(model));
            _commandProjectRepository.SaveChanges();

            return Ok(result);
        }


        [HttpPut("{Id}")]
        public ActionResult<ProjectDetailsDTO> Put(int Id, ProjectReadDTO projectReadDTO)
        {
            var model = _queryProjectRepository.GetProject(Id);
            if (model == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest("Invalid Details");
            _mapper.Map(projectReadDTO, model); // Map will also update

            var newProject = _commandProjectRepository.Update(model);
            _commandProjectRepository.SaveChanges();


            return Ok(_mapper.Map<ProjectDetailsDTO>(newProject));

        }


        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            var model = _queryProjectRepository.GetProject(Id);
            if (model == null)
                return NotFound();

            Project deleted = _commandProjectRepository.Delete(model);
            _commandProjectRepository.SaveChanges();

            return Ok(_mapper.Map<ProjectDetailsDTO>(deleted));
        }

    }
}
