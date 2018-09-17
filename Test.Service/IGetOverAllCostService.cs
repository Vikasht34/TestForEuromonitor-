using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Service
{
   public interface IGetOverAllCostService
   {
       decimal GetTotalCost(int distance, int stair, int custType);
   }
}
