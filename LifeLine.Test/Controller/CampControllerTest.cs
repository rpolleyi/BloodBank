using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLine.Infrastructure.Service;
using LifeLine.Web.Controllers;
using Moq;
using Xunit;
using LifeLine.Core.Models;
using System.Web.Mvc;
using LifeLine.Web.ViewModel;
using LifeLine.Web.Utilities;

namespace LifeLine.Test.Controller
{
    public class CampControllerTest
    {
        #region Private Fields       
        private Mock<ICampService> _mockCampService = new Mock<ICampService>();
        private CampController _controller;
        private List<Camp> campList;
        #endregion

        #region Constructor
        public CampControllerTest()
        {
            _controller = new CampController(_mockCampService.Object);
            campList = new List<Camp>()
            {
                new Camp(){Id = Guid.NewGuid(),Name = "Test1",When = "01/01/2016",Where = "SM"},
                new Camp(){Id = Guid.NewGuid(),Name = "Test2",When = "01/01/2016",Where = "SM"},
                new Camp(){Id = Guid.NewGuid(),Name = "Test3",When = "01/01/2016",Where = "SM"}
            };
        }
        #endregion

        #region Test Methods
        /// <summary>
        /// Verifying the count of camps returned by the service is same as returned by the controller
        /// </summary>
        [Fact]
        public void Should_Return_All_Camp_List()
        {            
            //Arrange
            _mockCampService.Setup(i => i.GetAll()).Returns(campList);

            //Act
            var controllerCampList = ((ViewResult)_controller.Index()).Model as List<CampVM>; ;

            //Assert
            Assert.Equal(campList.Count(), controllerCampList.Count());
        }

        /// <summary>
        /// Verifying if a camp object is getting created successfully or not
        /// </summary>
        [Fact]
        public void Should_Create_Valid_Camp()
        {
            //Arrange
            var camp = new Camp() { Name = "Test Blood Drive",Where="venice" , When="02/28/2016" };
            CampVM campVM = Automap.MapModelToViewModel<Camp,CampVM>(camp);

            //Act
            var result = (RedirectToRouteResult)_controller.Create(campVM);

            //Assert
            _mockCampService.Verify(m => m.Add(It.IsAny<Camp>()), Times.Once);
            Assert.Equal("index", result.RouteValues["action"]);

        }

        /// <summary>
        /// verifying the create method for a invalid camp object
        /// </summary>
        [Fact]
        public void Should_Not_Create_Invalid_Camp()
        {
            //Arrange
            var camp = new Camp() { Name = "", Where = "venice", When = "02/28/2016" };
            CampVM campVM = Automap.MapModelToViewModel<Camp,CampVM>(camp);
            _controller.ModelState.AddModelError("Error", "Name is required");

            //Act
            var result = (ViewResult)_controller.Create(campVM);

            //Assert
            _mockCampService.Verify(m => m.Add(camp), Times.Never);
            Assert.Equal("", result.ViewName);
        }

        /// <summary>
        /// Test to get Camp detail by ID which should not be null
        /// </summary>
        [Fact]
        public void Should_Get_Camp_ByID()
        {
            // ARRANGE
            //Creating a dummy camp object with specific Guid for this test method
            var camp = new Camp()
            {
                Id = new Guid("12AE8070-4B10-4618-A1AD-53CD4748C8D1"),
                Name = "Test Camp 1",
                Where = "venice",
                When = "02/28/2016"
            };
            //Specifiy a setup on the Camp service mocked type for a call to a returning method
            _mockCampService.Setup(s => s.FindById(new Guid("12AE8070-4B10-4618-A1AD-53CD4748C8D1"))).Returns(camp);

            //ACT
            //Verifying if the mock controller is also returing the same camp object from the detail call
            var result = _controller.Details(new Guid("12AE8070-4B10-4618-A1AD-53CD4748C8D1"));


            //ASSERT
            Assert.NotNull(result);
        }       
        #endregion
    }
}
