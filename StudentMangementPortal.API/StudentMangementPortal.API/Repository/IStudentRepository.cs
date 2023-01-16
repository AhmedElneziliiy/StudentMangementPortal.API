using StudentMangementPortal.API.Data.Models;

namespace StudentMangementPortal.API.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
    }
}
