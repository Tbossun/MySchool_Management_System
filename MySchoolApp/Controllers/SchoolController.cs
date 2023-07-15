using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MySchool.Core.Interface;
using MySchool.Models.Entities;
using MySchool.Models.DTOs.REQUEST;

namespace MySchoolApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SchoolController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetSchools()
        {

            List<School> schools = _unitOfWork.SchoolRepository.GetAll().ToList();
            return Ok(schools);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSchool([FromBody] SchoolCreateDto newSchool)
        {
            School school = _mapper.Map<School>(newSchool);
            _unitOfWork.SchoolRepository.Add(school);
            _unitOfWork.Save();
            return Ok("School created successfully");
        }


        [HttpGet("{id}", Name = "GetSchool")]
        [Authorize(Roles = "Regular")]
        public IActionResult GetSchoolById(int id)
        {
            School school = _unitOfWork.SchoolRepository.Get(u => u.Id == id);
            if (school == null)
                return NotFound();

            return Ok(school);
        }


        [HttpDelete()]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteSchoolById(int id)
        {
            var SchoolTodelete = _unitOfWork.SchoolRepository.Get(u => u.Id == id);
            if (SchoolTodelete == null)
                return NotFound();
            _unitOfWork.SchoolRepository.Remove(SchoolTodelete);
            _unitOfWork.Save();
            return NoContent();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateSchoolById(int id, [FromBody] SchoolUpdateDto schoolUpdateDto)
        {
            var existingSchool = _unitOfWork.SchoolRepository.Get(u => u.Id == id);
            if (existingSchool == null)
                return BadRequest($"School with id = {id} not found");
            _mapper.Map(schoolUpdateDto, existingSchool);
            _unitOfWork.SchoolRepository.Update(existingSchool);
            _unitOfWork.Save();
            return Ok("School updated successfully");
        }

    }
}
