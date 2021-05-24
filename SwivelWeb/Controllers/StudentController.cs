using Microsoft.AspNetCore.Mvc;
using SwivelWeb.Infrastructure.Interfaces;
using SwivelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelWeb.Controllers
{
    [Route("v1/api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService service;

        public StudentController(IStudentService service)
        {
            this.service = service;
        }


        [HttpPut]
        public async Task<bool> Add(Student data)
        {
            return await service.Add(data);
        }

        [HttpPut("AddCourse")]
        public async Task<bool> AddCourse(int courseId, int studentId)
        {
            return await service.AddCourse(courseId, studentId);
        }

        [HttpDelete("DeleteCourse")]
        public async Task<bool> DeleteCourse(int courseId, int studentId)
        {
            return await service.DeleteCourse(courseId, studentId);
        }

        [HttpGet("GetStudent/{email}")]
        public async Task<Student> GetStudent(string email)
        {
            return await service.Get(email);
        }

        [HttpGet("GetWithCourses/{email}")]
        public async Task<Student> GetWithCourses(string email)
        {
            return await service.GetWithCourses(email);
        }

        [HttpGet("GetCourses/{email}")]
        public async Task<IEnumerable<Course>> GetCourses(string email)
        {
            return await service.GetCourses(email);
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetAll()
        {
            return await service.GetAll();
        }


        [HttpPatch]
        public async Task<bool> Update(Student data)
        {
            return await service.Update(data);
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await service.Delete(id);
        }
    }
}
