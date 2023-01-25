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

        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            return await _context.Students
                .Include(a => a.Gender).Include(s => s.Address).FirstOrDefaultAsync(s => s.Id == studentId);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students.Include(a=>a.Gender).Include(s=>s.Address).ToListAsync();
        }
    }
}
