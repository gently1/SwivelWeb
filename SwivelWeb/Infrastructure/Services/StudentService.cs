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
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> repository;
        private readonly IGenericRepository<StudentCourse> courseRepo;

        public StudentService(IGenericRepository<Student> repository, IGenericRepository<StudentCourse> courseRepo)
        {
            this.repository = repository;
            this.courseRepo = courseRepo;
        }
        public async Task<bool> Add(Student vm)
        {
            repository.Insert(vm);
            var result = await repository.Save();
            return result > 0;
        }

        public async Task<bool> AddCourse(int courseId, int studentId)
        {
            var data = new StudentCourse { CourseId = courseId, StudentId = studentId };
            courseRepo.Insert(data);
            var result = await courseRepo.Save();
            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            await repository.Delete(x => x.Id == id);
            var result = await repository.Save();
            return result > 0;
        }

        public async Task<bool> DeleteCourse(int courseId, int studentId)
        {
            await courseRepo.Delete(x => x.CourseId == courseId && x.StudentId == studentId);
            var result = await courseRepo.Save();
            return result > 0;
        }

        public async Task<Student> Get(string email)
        {
            return await repository.GetSingle(x => x.Email.Equals(email));
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await repository.GetQueryable().ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCourses(string email)
        {
            return (await repository.GetSingle(x => x.Email.Equals(email), "Courses"))?.Courses?.Select(x => x.Course);
        }

        public async Task<Student> GetWithCourses(string email)
        {
            return await repository.GetSingle(x => x.Email.Equals(email), includeProperties: "Courses");
        }

        public async Task<bool> Update(Student data)
        {
            repository.Update(data);
            var result = await repository.Save();
            return result > 0;
        }
    }
}
