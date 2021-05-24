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
    public class TeacherService : ITeacherService
    {
        private readonly IGenericRepository<Teacher> repository;
        private readonly IGenericRepository<TeacherCourse> courseRepo;

        public TeacherService(IGenericRepository<Teacher> repository, IGenericRepository<TeacherCourse> courseRepo)
        {
            this.repository = repository;
            this.courseRepo = courseRepo;
        }
        public async Task<bool> Add(Teacher vm)
        {
            repository.Insert(vm);
            var result = await repository.Save();
            return result > 0;
        }

        public async Task<bool> AddCourse(int courseId, int teacherId)
        {
            var totalCourses = await courseRepo.GetQueryable(x => x.TeacherId == teacherId).CountAsync();
            if (totalCourses == 3)
                return false;
            var data = new TeacherCourse { CourseId = courseId, TeacherId = teacherId };
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

        public async Task<bool> DeleteCourse(int courseId, int teacherId)
        {
            await courseRepo.Delete(x => x.CourseId == courseId && x.TeacherId == teacherId);
            var result = await courseRepo.Save();
            return result > 0;
        }

        public async Task<Teacher> Get(string email)
        {
            return await repository.GetSingle(x => x.Email.Equals(email));
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            return await repository.GetQueryable().ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCourses(string email)
        {
            return (await repository.GetSingle(x => x.Email.Equals(email), "Courses"))?.Courses?.Select(x => x.Course);
        }

        public async Task<Teacher> GetWithCourses(string email)
        {
            return await repository.GetSingle(x => x.Email.Equals(email), includeProperties: "Courses");
        }

        public async Task<bool> Update(Teacher data)
        {
            repository.Update(data);
            var result = await repository.Save();
            return result > 0;
        }
    }
}
