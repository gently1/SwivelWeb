using Microsoft.EntityFrameworkCore;
using SwivelWeb.Data.Repository.Interfaces;
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
        private readonly IGenericRepository<Course> repository;

        public CourseService(IGenericRepository<Course> repository)
        {
            this.repository = repository;
        }
        public async Task<bool> Add(Course vm)
        {
            repository.Insert(vm);
            var result = await repository.Save();
            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            await repository.Delete(x => x.Id == id);
            var result = await repository.Save();
            return result > 0;
        }

        public async Task<Course> Get(string code)
        {
            return await repository.GetSingle(x => x.Code.Equals(code));
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await repository.GetQueryable().ToListAsync();
        }

        public async Task<Course> GetWithAll(string code)
        {
            return await repository.GetSingle(x => x.Code.Equals(code), includeProperties: "Students,Teachers");
        }

        public async Task<Course> GetWithStudents(string code)
        {
            return await repository.GetSingle(x => x.Code.Equals(code), includeProperties: "Students");
        }

        public async Task<Course> GetWithTeachers(string code)
        {
            return await repository.GetSingle(x => x.Code.Equals(code), includeProperties: "Teachers");
        }

        public async Task<bool> Update(Course data)
        {
            repository.Update(data);
            var result = await repository.Save();
            return result > 0;
        }
    }
}
