using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.Repositories.Interface;
using Test.DataEntity.BaseCode;

namespace Test.DataAccess.Repositories
{
    public class GetOverAllCostRepository : IGetOverAllCostRepository
    {
        private readonly ITestDataModel _testDataModel;

        public GetOverAllCostRepository(ITestDataModel testDataModel)
        {
            _testDataModel = testDataModel;
        }
        
       public decimal GetTotalCost(int distance, int stair, int custType)
       {
           return _testDataModel.GetDataModelAsDbContext().GetOverAllCost(distance, stair, custType).FirstOrDefault()
               .Value;
       }
    }
}
