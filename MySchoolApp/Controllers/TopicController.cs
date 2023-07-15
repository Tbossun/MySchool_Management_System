using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySchool.Core.Interface;
using MySchool.Models.DTOs.REQUEST;
using MySchool.Models.Entities;

namespace MySchoolApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TopicController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTopics()
        {
            List<Topic> topics = _unitOfWork.TopicRepository.GetAll().ToList();
            return Ok(topics);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTopic([FromBody] CreateTopicDto newTopic)
        {
            var topic = _mapper.Map<Topic>(newTopic);
            _unitOfWork.TopicRepository.Add(topic);
            _unitOfWork.Save();
            return Ok("Topic Added successfully");
        }

        [HttpGet("{id}", Name = "GetTopicById")]
        public IActionResult GetTopicById(int id)
        {
            var topic = _unitOfWork.TopicRepository.Get(u => u.Id == id);
            if (topic == null)
                return NotFound();
            return Ok(topic);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTopic(int id)
        {
            var TopicToDelete = _unitOfWork.TopicRepository.Get(u => u.Id == id);
            if (TopicToDelete == null)
                return NotFound();
            _unitOfWork.TopicRepository.Remove(TopicToDelete);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTopicById(int id, [FromBody] UpdateTopicDto updateTopic)
        {
            var existingTopic = _unitOfWork.TopicRepository.Get(u => u.Id == id);
            if (existingTopic == null)
                return BadRequest($"Subject with id = {id} not found");
            _mapper.Map(updateTopic, existingTopic);
            _unitOfWork.TopicRepository.Update(existingTopic);
            _unitOfWork.Save();
            return Ok("Topic updated successfully");
        }
    }
}
