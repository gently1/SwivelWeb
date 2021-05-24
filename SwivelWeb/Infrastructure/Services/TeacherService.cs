using SwivelWeb.Infrastructure.Interfaces;
using SwivelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelWeb.Infrastructure.Services
{
    public class TeacherService : ITeacherService
    {
        public Task<bool> Add(Teacher vm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddCourse(int courseId, int teacherId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourse(int courseId, int teacherId)
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> Get(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Teacher>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetCourses(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> GetWithCourses(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Teacher data)
        {
            throw new NotImplementedException();
        }
    }
}
