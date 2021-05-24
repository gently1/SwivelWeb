using Moq;
using NUnit.Framework;
using SwivelWeb.Data.Repository.Interfaces;
using SwivelWeb.Models;
using SwivelWeb.UnitTests.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelWeb.UnitTests.Services
{
    public class CourseServiceTest
    {
        private readonly DataSetup db = new DataSetup();
        private readonly Mock<IGenericRepository<Course>> repository = new Mock<IGenericRepository<Course>>();

        [SetUp]
        public void Setup()
        {
            repository.Setup(x => x.GetByID(It.IsAny<int>()).Result)
             .Returns((int i) => db.Context.Courses.Single(bo => bo.Id == i));

        }

    }
}
