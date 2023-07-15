using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySchool.Core.Interface;
using MySchool.Models.DTOs.REQUEST;
using MySchool.Models.Entities;

namespace MySchoolApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubjectController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSubjects()
        {
            List<Subject> subjects = _unitOfWork.SubjectRepository.GetAll().ToList();
            return Ok(subjects);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSubject([FromBody] CreateSubjectDto newSubject)
        {
            var subject = _mapper.Map<Subject>(newSubject);
            _unitOfWork.SubjectRepository.Add(subject);
            _unitOfWork.Save();
            return Ok("Subject Added successfully");
        }

        [HttpGet("{id}", Name = "GetSubjectById")]
        public IActionResult GetSubjectById(int id)
        {
            var Subject = _unitOfWork.SubjectRepository.Get(u => u.SubjectID == id);
            if (Subject == null)
                return NotFound();
            return Ok(Subject);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            var SubjectToDelete = _unitOfWork.SubjectRepository.Get(u => u.SubjectID == id);
            if (SubjectToDelete == null)
                return NotFound();
            _unitOfWork.SubjectRepository.Remove(SubjectToDelete);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubjectById(int id, [FromBody] UpdateSubjectDto updateSubject)
        {
            var existingSubject = _unitOfWork.SubjectRepository.Get(u => u.SubjectID == id);
            if (existingSubject == null)
                return BadRequest($"Subject with id = {id} not found");
            _mapper.Map(updateSubject, existingSubject);
            _unitOfWork.SubjectRepository.Update(existingSubject);
            _unitOfWork.Save();
            return Ok("Subject updated successfully");
        }
    }
}
