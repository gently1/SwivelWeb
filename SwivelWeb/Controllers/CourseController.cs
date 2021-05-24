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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService service;

        public CourseController(ICourseService service)
        {
            this.service = service;
        }

        [HttpPut]
        public async Task<bool> Add(Course data)
        {
            return await service.Add(data);
        }

        [HttpGet("GetCourse/{code}")]
        public async Task<Course> GetCourse(string code)
        {
            return await service.Get(code);
        }

        [HttpGet("GetWithStudents/{code}")]
        public async Task<Course> GetWithStudents(string code)
        {
            return await service.GetWithStudents(code);
        }

        [HttpGet("GetWithTeachers/{code}")]
        public async Task<Course> GetWithTeachers(string code)
        {
            return await service.GetWithTeachers(code);
        }

        [HttpGet("GetWithAll/{code}")]
        public async Task<Course> GetWithAll(string code)
        {
            return await service.GetWithAll(code);
        }

        [HttpGet]
        public async Task<IEnumerable<Course>> GetAll()
        {
            return await service.GetAll();
        }


        [HttpPatch]
        public async Task<bool> Update(Course data)
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
