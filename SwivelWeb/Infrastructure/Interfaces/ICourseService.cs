using SwivelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelWeb.Infrastructure.Interfaces
{
    public interface ICourseService
    {
        Task<bool> Add(Course vm);
        Task<Course> Get(string code);
        Task<Course> GetWithStudents(string code);
        Task<Course> GetWithTeachers(string code);
        Task<Course> GetWithAll(string code);
        Task<IEnumerable<Course>> GetAll();
        Task<bool> Update(Course data);
        Task<bool> Delete(int id);
    }
}
