using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IImageRepository _imageRepository;

        public StudentsController( IStudentRepository studentRepository, IMapper mapper, IImageRepository imageRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        [HttpGet]
       [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetStudentsAsync();

            return Ok(_mapper.Map<List<StudentDto>>(students));
        }
        

        [HttpGet]
        [Route("[controller]/{studentId:guid}"),ActionName("GetStudentAsync")]
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

        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody]UpdateStudentRequest request)
        {
            if(await _studentRepository.Exists(studentId))
            {
                //
               var updatedStudent= await _studentRepository.UpdateStudentAsync(studentId,_mapper.Map<Student>(request));
                if (updatedStudent is not null)
                    return Ok(_mapper.Map<StudentDto>(updatedStudent));
            }
              
            return NotFound();
            
        }

        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if (await _studentRepository.Exists(studentId))
            {
                var student=await _studentRepository.DeleteStudent(studentId);
                return Ok(_mapper.Map<StudentDto>(student));
            }
            return NotFound();
        }
       
        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudentRequest request)
        {
            

            var student = await _studentRepository.AddStudent(_mapper.Map<Student>(request));

            return CreatedAtAction(nameof(GetStudentAsync), new { studentId = student.Id },
                _mapper.Map<StudentDto>(student));
        }

        [HttpPost]
        [Route("[controller]/{studentId:guid}/upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] Guid studentId,IFormFile profileImage)
        {
            if (await _studentRepository.Exists(studentId))
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);

                var path = await _imageRepository.Upload(profileImage, fileName);    

                if(await _studentRepository.UpdateProfileImage(studentId, path))
                    return Ok(path);

                return StatusCode(StatusCodes.Status500InternalServerError,"Error while uploading (Image)");
            }
            return NotFound();
        }
    }
}
