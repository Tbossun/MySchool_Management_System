using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySchool.Core.Interface;
using MySchool.Models.DTOs.REQUEST;
using MySchool.Models.Entities;

namespace MySchoolApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetStudents()
        {
            List<Student> students = _unitOfWork.StudentRepository.GetAll().ToList();
            if (students == null || students.Count == 0)
                return NotFound();
            return Ok(students);
        }


        [HttpPost]
        public async Task<IActionResult> AddNewStudent([FromBody] StudentCreateDto newStudent)
        {
            if (ModelState.IsValid)
            {
                Student student = _mapper.Map<Student>(newStudent);
                _unitOfWork.StudentRepository.Add(student);
                _unitOfWork.Save();
            }

            return Ok("Student created successfully");
        }

        [HttpGet("{id}", Name = "GetStudent")]
        // [Authorize(Roles = "Admin")]
        public IActionResult GetStudentById(int id)
        {
            Student student = _unitOfWork.StudentRepository.Get(u => u.ID == id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }


        [HttpDelete()]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteStudentById(int id)
        {
            var StudentTodelete = _unitOfWork.StudentRepository.Get(u => u.ID == id);
            if (StudentTodelete == null)
                return NotFound();
            _unitOfWork.StudentRepository.Remove(StudentTodelete);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudentById(int id, [FromBody] StudentUpdateDto studentUpdateDto)
        {
            var existingStudent = _unitOfWork.StudentRepository.Get(u => u.ID == id);
            if (existingStudent == null)
                return BadRequest($"School with id = {id} not found");
            _mapper.Map(studentUpdateDto, existingStudent);
            _unitOfWork.StudentRepository.Update(existingStudent);
            _unitOfWork.Save();
            return Ok("Student updated successfully");
        }
    }
}
