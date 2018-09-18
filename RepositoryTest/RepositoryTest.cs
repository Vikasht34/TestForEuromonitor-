using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Test.DataAccess.Repositories;
using Test.DataAccess.Repositories.Interface;
using Test.DataEntity;
using Test.DataEntity.BaseCode;

namespace RepositoryTest
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void GetOverAllCost()
        {
            //Arrange
            IGetOverAllCostRepository repository = GetOverAllCostRepos();
            
            //Act

            Decimal overAllCost = repository.GetTotalCost(10, 4, 1);

            //Assert
            Assert.AreEqual(1048, overAllCost);

        }

        private IGetOverAllCostRepository GetOverAllCostRepos()
        {
            IEnumerable<CustomerVarientCost> customerVarientCosts = GetCustomerVarientCosts();
            IEnumerable<DistanceVarientBaseCost> distanceVarientBaseCosts = GetDistanceVarientsCost();
            IEnumerable<StairsVarientBaseCost> stairsVarientBaseCosts = GetStairsVarientCost();
            Mock<DbSet<CustomerVarientCost>> customerVarientCostDbSet = MockDbSetFactory.CreateMockDbSetWithObjects(customerVarientCosts);
            Mock<DbSet<DistanceVarientBaseCost>> distanceVarientBaseCostsDbSet = MockDbSetFactory.CreateMockDbSetWithObjects(distanceVarientBaseCosts);
            Mock<DbSet<StairsVarientBaseCost>> stairsVarientBaseCostsDbSet = MockDbSetFactory.CreateMockDbSetWithObjects(stairsVarientBaseCosts);
            Mock<ITestDataModel> testDataModel = new Mock<ITestDataModel>();
            testDataModel.Setup(m => m.CustomerVarientCosts).Returns(customerVarientCostDbSet.Object);
            testDataModel.Setup(m => m.DistanceVarientBaseCosts).Returns(distanceVarientBaseCostsDbSet.Object);
            testDataModel.Setup(m => m.StairsVarientBaseCosts).Returns(stairsVarientBaseCostsDbSet.Object);
            return new GetOverAllCostRepository(testDataModel.Object);
        }

        private IEnumerable<StairsVarientBaseCost> GetStairsVarientCost()
        {
            return new List<StairsVarientBaseCost>
            {
                new StairsVarientBaseCost
                {
                    Id = 1,
                    MaxStair = 5,
                    MinStair = 1,
                    OverAllCost = 1048

                }
            };
        }

        private IEnumerable<DistanceVarientBaseCost> GetDistanceVarientsCost()
        {
           return new List<DistanceVarientBaseCost>
           {
               new DistanceVarientBaseCost
               {
                   Id = 1,
                   MinDist = 10,
                   OverAllCost = 1048
               }
           };
        }

        private IEnumerable<CustomerVarientCost> GetCustomerVarientCosts()
        {
            return  new List<CustomerVarientCost>
            {
                new CustomerVarientCost
                {
                    Id = 1,
                    OverAllCost = 800
                }
            };
        }
    }
}
