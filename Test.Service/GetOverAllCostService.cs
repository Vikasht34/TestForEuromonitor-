using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.Repositories.Interface;

namespace Test.Service
{
    public class GetOverAllCostService : IGetOverAllCostService
    {
        private readonly IGetOverAllCostRepository _getOverAllCostRepository;

        public GetOverAllCostService(IGetOverAllCostRepository getOverAllCostRepository)
        {
            _getOverAllCostRepository = getOverAllCostRepository;
        }
        public decimal GetTotalCost(int distance, int stair, int custType)
        {
            return _getOverAllCostRepository.GetTotalCost(distance, stair, custType);
        }
    }
}
