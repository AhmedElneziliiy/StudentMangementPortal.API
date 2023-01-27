using Microsoft.EntityFrameworkCore;
using StudentMangementPortal.API.Data.Models;

namespace StudentMangementPortal.API.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;
        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<Student> AddStudent(Student request)
        {
            var student = await _context.Students.AddAsync(request);
            await _context.SaveChangesAsync();
            return student.Entity;
        }

        public async Task<Student> DeleteStudent(Guid studentId)
        {
            var student = await GetStudentAsync(studentId);
            if (student is not null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return student;
            }
            return null;

        }

        public async Task<bool> Exists(Guid studentId)
        {
            return await _context.Students.AnyAsync(s => s.Id == studentId);
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            return await _context.Students
                .Include(a => a.Gender).Include(s => s.Address).FirstOrDefaultAsync(s => s.Id == studentId);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students.Include(a => a.Gender).Include(s => s.Address).ToListAsync();
        }

        public async Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl)
        {
            var student=await GetStudentAsync(studentId);
            if (student is not null)
            {
                student.ProfileImageUrl = profileImageUrl;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Student> UpdateStudentAsync(Guid id, Student request)
        {
            var student = await GetStudentAsync(id);
            if (student is not null)
            {
                student.FirstName = request.FirstName;
                student.LastName = request.LastName;
                student.DateOfBirth = request.DateOfBirth;
                student.Email = request.Email;
                student.Mobile = request.Mobile;
                student.GenderId = request.GenderId;
                student.Address.PhysicalAddress = request.Address.PhysicalAddress;
                student.Address.PostalAddress = request.Address.PostalAddress;

                await _context.SaveChangesAsync();
                return student;
            }
            return null;
        }
    }
}
