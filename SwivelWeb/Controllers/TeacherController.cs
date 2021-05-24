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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService service;

        public TeacherController(ITeacherService service)
        {
            this.service = service;
        }


        [HttpPut]
        public async Task<bool> Add(Teacher data)
        {
            return await service.Add(data);
        }

        [HttpPut("AddCourse")]
        public async Task<bool> AddCourse(int courseId, int teacherId)
        {
            return await service.AddCourse(courseId, teacherId);
        }

        [HttpDelete("DeleteCourse")]
        public async Task<bool> DeleteCourse(int courseId, int teacherId)
        {
            return await service.DeleteCourse(courseId, teacherId);
        }

        [HttpGet("GetTeacher/{email}")]
        public async Task<Teacher> GetTeacher(string email)
        {
            return await service.Get(email);
        }

        [HttpGet("GetWithCourses/{email}")]
        public async Task<Teacher> GetWithCourses(string email)
        {
            return await service.GetWithCourses(email);
        }

        [HttpGet("GetCourses/{email}")]
        public async Task<IEnumerable<Course>> GetCourses(string email)
        {
            return await service.GetCourses(email);
        }

        [HttpGet]
        public async Task<IEnumerable<Teacher>> GetAll()
        {
            return await service.GetAll();
        }


        [HttpPatch]
        public async Task<bool> Update(Teacher data)
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
