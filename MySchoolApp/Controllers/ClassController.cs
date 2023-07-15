using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySchool.Core.Interface;
using MySchool.Models.DTOs.REQUEST;
using MySchool.Models.Entities;

namespace MySchoolApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetClasses()
        {
            List<Class> classes = _unitOfWork.ClassRepository.GetAll().ToList();
            return Ok(classes);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewClass([FromBody] CreateClassDto newClass)
        {
            var classToAdd = _mapper.Map<Class>(newClass);
            _unitOfWork.ClassRepository.Add(classToAdd);
            _unitOfWork.Save();
            return Ok("Class Added successfully");
        }

        [HttpGet("{id}", Name = "GetClassById")]
        public IActionResult GetClassById(int id)
        {
            var classReturned = _unitOfWork.ClassRepository.Get(u => u.Id == id);
            if (classReturned == null)
                return NotFound();
            return Ok(classReturned);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClass(int id)
        {
            var ClassToDelete = _unitOfWork.ClassRepository.Get(u => u.Id == id);
            if (ClassToDelete == null)
                return NotFound();
            _unitOfWork.ClassRepository.Remove(ClassToDelete);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClassById(int id, [FromBody] UpdateClassDto updateClass)
        {
            var existingClass = _unitOfWork.ClassRepository.Get(u => u.Id == id);
            if (existingClass == null)
                return BadRequest($"Class with id = {id} not found");
            _mapper.Map(updateClass, existingClass);
            _unitOfWork.ClassRepository.Update(existingClass);
            _unitOfWork.Save();
            return Ok("Class updated successfully");
        }
    }
}
