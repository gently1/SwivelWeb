using SwivelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelWeb.Infrastructure.Interfaces
{
    public interface ITeacherService
    {
        Task<bool> Add(Teacher vm);
        Task<bool> AddCourse(int courseId, int teacherId);
        Task<bool> DeleteCourse(int courseId, int teacherId);
        Task<Teacher> Get(string email);
        Task<Teacher> GetWithCourses(string email);
        Task<IEnumerable<Teacher>> GetAll();
        Task<IEnumerable<Course>> GetCourses(string email);
        Task<bool> Update(Teacher data);
        Task<bool> Delete(int id);

    }
}
