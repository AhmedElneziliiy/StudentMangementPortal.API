using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMangementPortal.API.Domain.Models;
using StudentMangementPortal.API.Repository;

namespace StudentMangementPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;   
        public StudentsController(IStudentRepository studentRepository,IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper=mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetStudents()
        {
            var students =await _studentRepository.GetStudentsAsync();
            
            return Ok(_mapper.Map<List<StudentDto>>(students));
        }
    }
}
