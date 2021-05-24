using Microsoft.EntityFrameworkCore;
using SwivelWeb.Data;
using SwivelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelWeb.UnitTests.Setup
{
    public class DataSetup : IDisposable
    {
        public AppDbContext Context { get; private set; }

        public DataSetup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("SwivelTestDb")
                .Options;

            Context = new AppDbContext(options);

            Context.Courses.Add(new Course { Id = 1, Code = "COE201", Name = "Introduction to Communications Engineering" });
            Context.Courses.Add(new Course { Id = 2, Code = "EEE101", Name = "Introduction to Electrical Engineering" });
            Context.Courses.Add(new Course { Id = 3, Code = "FST101", Name = "Introduction to Food Science" });
            Context.Courses.Add(new Course { Id = 3, Code = "TST204", Name = "Test Flight Simulation" });

            Context.Teachers.Add(new Teacher { Id = 1, FirstName = "Eduardo", LastName = "Alvarez", Email = "eadv@gmail.com" });
            Context.Teachers.Add(new Teacher { Id = 2, FirstName = "Lord", LastName = "Mallam", Email = "lordy@gmail.com" });

            Context.Students.Add(new Student { Id = 1, FirstName = "Eno", LastName = "Robin", Email = "enny@yahoo.com", Phone = "080223456789" });
            Context.Students.Add(new Student { Id = 1, FirstName = "Bina", LastName = "Osas", Email = "binos@yahoo.com", Phone = "080123433940" });


            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
