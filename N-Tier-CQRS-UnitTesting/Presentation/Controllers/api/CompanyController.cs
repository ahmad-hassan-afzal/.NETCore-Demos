using Application.Repositories.Company.Command;
using Application.Repositories.Company.DTOs;
using Application.Repositories.Company.Query;
using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {

        private readonly ICommandCompanyRepository _commandRepository;
        private readonly IQueryCompanyRepository _queryRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICommandCompanyRepository commandRepository, IQueryCompanyRepository queryRepository, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
            => Ok(_mapper.Map<IEnumerable<CompanyDetailsDTO>>(_queryRepository.GetAllCompanies()));


        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Company company = _queryRepository.GetCompany(Id);

            if (company == null)
                return NotFound($"Company (ID: {Id}) Not Found.");

            return Ok(_mapper.Map<CompanyDetailsDTO>(company));
        }


        [HttpPost]
        public IActionResult Post(CompanyReadDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Company Details");
                           
            _commandRepository.Add(_mapper.Map<Company>(model));
            _commandRepository.SaveChanges();

            return Ok(model);
        }


        [HttpPut("{Id}")]
        public ActionResult<CompanyDetailsDTO> Put(int Id, CompanyReadDTO companyReadDTO)
        {
            Company model = _queryRepository.GetCompany(Id);
            if (model == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest("Invalid Company Details");

            _mapper.Map(companyReadDTO, model); // Map is goiing to update compant details

            var newCompany = _commandRepository.Update(model);
            _commandRepository.SaveChanges();


            return Ok(_mapper.Map<CompanyDetailsDTO>(newCompany));

        }


        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            var model = _queryRepository.GetCompany(Id);
            if (model == null)
                return NotFound();

            var deleted = _commandRepository.Delete(model);
            _commandRepository.SaveChanges();

            return Ok(_mapper.Map<CompanyDetailsDTO>(deleted));
        }

    }
}
