using SwivelWeb.Infrastructure.Interfaces;
using SwivelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelWeb.Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        public Task<bool> Add(Student vm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddCourse(int courseId, int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourse(int courseId, int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<Student> Get(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetCourses(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetWithCourses(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Student data)
        {
            throw new NotImplementedException();
        }
    }
}
