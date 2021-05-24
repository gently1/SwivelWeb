using Moq;
using NUnit.Framework;
using SwivelWeb.Data.Repository.Interfaces;
using SwivelWeb.Data.Repository.Services;
using SwivelWeb.Models;
using SwivelWeb.UnitTests.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelWeb.UnitTests.Services
{
    [TestFixture]
    public class CourseServiceTest
    {
        private readonly DataSetup db = new DataSetup();
        private Mock<GenericRepository<Course>> repository;

        [SetUp]
        public void Setup()
        {
            repository = new Mock<GenericRepository<Course>>(db.Context);

            repository.Setup(x => x.GetByID(It.IsAny<int>()).Result)
             .Returns((int i) => db.Context.Courses.Single(bo => bo.Id == i));

        }

        [Test]
        public void Repository_Insert()
        {
            repository.Object.Insert(new Course { Id = 4, Code = "PET451", Name = "Petroleum Exploration" });
            
        }

    }
}
