using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StudentMangementPortal.API.Data.Models;

namespace StudentMangementPortal.API.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentId);
        Task<List<Gender>> GetGendersAsync();
        Task<bool> Exists(Guid studentId);
        Task<Student> UpdateStudentAsync(Guid id, Student request);
        Task<Student> DeleteStudent(Guid studentId);
        Task<Student> AddStudent(Student request);
        Task<bool>UpdateProfileImage(Guid studentId, string profileImageUrl);
    }
}
