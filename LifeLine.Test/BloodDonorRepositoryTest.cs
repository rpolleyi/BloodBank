using LifeLine.Infrastructure;
using System.Linq;
using NUnit.Framework;
using StructureMap;
using System.Web.Mvc;
using LifeLine.Core.Models;
using LifeLine.Test.Service;
using LifeLine.Web.Controllers;
using System.Collections.Generic;

namespace LifeLine.Test
{  
    public class BloodDonorRepositoryTest
    {
        //BloodDonorRepository repo; 
        [SetUp]
        public void TestSetUp()      
        {
            BloodDonorInitalizeDb db = new BloodDonorInitalizeDb();
            System.Data.Entity.Database.SetInitializer(db);
            //repo = new BloodDonorRepository();
        }

        //[Test]
        //public void assert_container_is_valid()
        //{
        //    var container = new Container(x => {
        //        x.ForConcreteType<BloodDonorRepository>()
        //            .Configure.Transient();
        //    });
            
        //    container.AssertConfigurationIsValid();
        //}

        [Test]
        public void IndexGetsAllProducts()
        {
            //Arrange 
            //var fakeDonorRepository = new FakeDonorRepository();
            //var productsController = new DonorController(fakeDonorRepository);

            ////Act
            //var result = productsController.Index() as ViewResult;

            ////Assert
            //var model = result.Model as List<Donor>;
            //Assert.AreEqual(2, model.Count);
        }
    }
}
