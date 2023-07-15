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
    public class TeacherController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetTeachers()
        {
            List<Teacher> teachers = _unitOfWork.TeacherRepository.GetAll().ToList();
            if (teachers == null)
                return NotFound();
            return Ok(teachers);
        }


        [HttpPost]
        public async Task<IActionResult> AddNewTeacher([FromBody] TeacherCreateDto newTeacher)
        {
            /* if (newTeacher == null)
                 return BadRequest();*/
            Teacher teacher = _mapper.Map<Teacher>(newTeacher);
            _unitOfWork.TeacherRepository.Add(teacher);
            _unitOfWork.Save();
            return Ok("Teacher created successfully");
        }


        [HttpGet("{id}", Name = "GetTeacher")]
        // [Authorize(Roles = "Admin")]
        public IActionResult GetTeacherById(int id)
        {
            if (id == 0)
            {
                //return BadRequest();
                throw new Exception("Wrong id entered");
            }
            Teacher teacher = _unitOfWork.TeacherRepository.Get(u => u.ID == id);
            if (teacher == null)
                return NotFound();

            return Ok(teacher);
        }


        [HttpDelete()]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteTeacherById(int id)
        {
            var teacherTodelete = _unitOfWork.TeacherRepository.Get(u => u.ID == id);
            if (teacherTodelete == null)
                return NotFound();
            _unitOfWork.TeacherRepository.Remove(teacherTodelete);
            _unitOfWork.Save();
            return NoContent();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateTeacherById(int id, [FromBody] TeacherUpdateDto teacherUpdateDto)
        {
            var existingteacher = _unitOfWork.TeacherRepository.Get(u => u.ID == id);
            if (existingteacher == null)
                return BadRequest($"Teacher with id = {id} not found");
            _mapper.Map(teacherUpdateDto, existingteacher);
            _unitOfWork.TeacherRepository.Update(existingteacher);
            _unitOfWork.Save();
            return Ok("Teacher updated successfully");
        }
    }
}

