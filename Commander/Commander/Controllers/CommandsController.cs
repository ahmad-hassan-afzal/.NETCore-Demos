using AutoMapper;
using Commander.Data;
using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepository repository, IMapper mapper)
        {
            _commandRepository = repository;
            _mapper = mapper;
        }

        // GET: api/Commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commands = _commandRepository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commands));
        }

        // GET: api/Commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            var command = _commandRepository.GetCommandById(id);

            if(command == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CommandReadDTO>(command));
        }

        // GET: api/Commands
        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDTO)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDTO);
            _commandRepository.CreateCommand(commandModel);

            var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDTO.Id }, commandReadDTO);
        }

        // PUT: api/Commands/{id}
        [HttpPut("{id}")]
        public ActionResult<CommandReadDTO> UpdateCommand(int Id, CommandUpdateDTO commandUpdateDTO)
        {
            var model = _commandRepository.GetCommandById(Id);
            if(model == null)
            {
                return NotFound();
            }
            
            _mapper.Map(commandUpdateDTO, model);

            _commandRepository.UpdateCommand(model);

            return NoContent();
            //return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDTO.Id }, commandReadDTO);
        }

        // PATCH: api/Commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCommand(int Id, JsonPatchDocument<CommandUpdateDTO> patch)
        {
            var model = _commandRepository.GetCommandById(Id);
            if (model == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDTO>(model);

            patch.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            
            _mapper.Map(commandToPatch, model);

            _commandRepository.UpdateCommand(model);

            return NoContent();
        }

        // DELETE: api/Commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int Id)
        {
            var model = _commandRepository.GetCommandById(Id);
            if (model == null)
            {
                return NotFound();
            }

            _commandRepository.DeleteCommand(model);

            return NoContent();
        }
    }
}
