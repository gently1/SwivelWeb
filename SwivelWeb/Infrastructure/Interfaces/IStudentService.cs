using SwivelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelWeb.Infrastructure.Interfaces
{
    public interface IStudentService
    {

        Task<bool> Add(Student vm);
        Task<bool> AddCourse(int courseId, int studentId);
        Task<bool> DeleteCourse(int courseId, int studentId);
        Task<Student> Get(string email);
        Task<Student> GetWithCourses(string email);
        Task<IEnumerable<Student>> GetAll();
        Task<IEnumerable<Course>> GetCourses(string email);
        Task<bool> Update(Student data);
        Task<bool> Delete(int id);
    }
}
