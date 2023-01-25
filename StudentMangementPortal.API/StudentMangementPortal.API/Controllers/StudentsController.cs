using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMangementPortal.API.Data.Models;
using StudentMangementPortal.API.Domain.Models;
using StudentMangementPortal.API.Repository;

namespace StudentMangementPortal.API.Controllers
{
   
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
       [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetStudentsAsync();

            return Ok(_mapper.Map<List<StudentDto>>(students));
        }
        

        [HttpGet]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            // Fetch Student Details
            var student = await _studentRepository.GetStudentAsync(studentId);

            // Return Student
            if (student == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentDto>(student));

        }
    }
}
