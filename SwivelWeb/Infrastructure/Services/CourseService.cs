using SwivelWeb.Infrastructure.Interfaces;
using SwivelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelWeb.Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        public Task<bool> Add(Course vm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> Get(string code)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetWithAll(string code)
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetWithStudents(string code)
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetWithTeachers(string code)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Course data)
        {
            throw new NotImplementedException();
        }
    }
}
