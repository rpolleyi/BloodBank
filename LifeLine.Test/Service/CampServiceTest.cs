using LifeLine.Core.Interfaces;
using LifeLine.Core.Models;
using LifeLine.Infrastructure;
using LifeLine.Infrastructure.Service;
using LifeLine.Web.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LifeLine.Test.Service
{
    public class CampServiceTest
    {
        private ICampService _mockCampService;
        private Mock<ICampRepository> _mockCampRepository;
        Mock<DbSet<Camp>> _mockSetCamps;
        IQueryable<Camp> campList;

        public CampServiceTest()
        {
            campList = new List<Camp>()
            {
                new Camp(){Id = Guid.NewGuid(),Name = "Test1",When = "01/01/2016",Where = "SM"},
                new Camp(){Id = Guid.NewGuid(),Name = "Test2",When = "01/01/2016",Where = "SM"},
                new Camp(){Id = Guid.NewGuid(),Name = "Test3",When = "01/01/2016",Where = "SM"}
            }.AsQueryable();

            _mockSetCamps = CreateMockSet(campList);

            _mockCampRepository = new Mock<ICampRepository>();
            _mockCampService = new CampService(_mockCampRepository.Object);           
        }

        private static Mock<DbSet<T>> CreateMockSet<T>(IQueryable<T> data) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();

            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }
        
        /// <summary>
        /// Verifying if a camp object is getting created successfully or not by the service
        /// </summary>
        [Fact]
        public void Create_valid_Camp_From_Service()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            Camp camp = new Camp() { Id = Id, Name = "test drive 1", When = "03/01/2016", Where = "Pasadena, CA" };

            _mockSetCamps.Setup(m => m.Add(camp)).Returns((Camp e) =>
            {
                e.Id = Id;
                return e;
            });

            //Act
            _mockCampService.Add(camp);

            //Assert
            Assert.Equal(Id, camp.Id);
            _mockCampRepository.Verify(m => m.Add(camp), Times.Once());

        }
    }
}
