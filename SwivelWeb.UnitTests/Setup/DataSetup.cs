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
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
