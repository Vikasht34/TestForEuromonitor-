using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataEntity.BaseCode
{
    public class TestDataModelFactory : ITestModelFactory
    {
        public ITestDataModel CreateTestDataModel()
        {
            return new TestDataModel();
        }
    }
}
