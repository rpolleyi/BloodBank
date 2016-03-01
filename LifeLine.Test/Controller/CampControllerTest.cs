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
        private Mock<ICampService> _mockCampService = new Mock<ICampService>();
        private CampController _controller;
        private List<Camp> campList;

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


        #region Create Test Methods
        /// <summary>
        /// Verifying the count of camps returned by the service is same as returned by the controller
        /// </summary>
        [Fact]
        public void Get_Return_All_Camp_List()
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
        public void Create_Camp_Valid()
        {
            //Arrange
            var camp = new Camp() { Name = "Test Blood Drive",Where="venice" , When="02/28/2016" };
            CampVM campVM = Automap.MapModelToViewModel<Camp,CampVM>(camp);

            //Act
            var result = (RedirectToRouteResult)_controller.Create(campVM);

            //Assert
            _mockCampService.Verify(m => m.Add(It.IsAny<Camp>()), Times.Once);
            Assert.Equal("Index", result.RouteValues["action"]);

        }

        /// <summary>
        /// verifying the create method for a invalid camp object
        /// </summary>
        [Fact]
        public void Invalid_Asset_Create()
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
        
        #endregion
    }
}
