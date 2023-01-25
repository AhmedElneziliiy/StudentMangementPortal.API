using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMangementPortal.API.Domain.Models;
using StudentMangementPortal.API.Repository;

namespace StudentMangementPortal.API.Controllers
{
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public GendersController(IStudentRepository studentRepository,IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genders = await _studentRepository.GetGendersAsync();
            if (genders is null||!genders.Any())
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<GenderDto>>(genders));
        }
    }
}
