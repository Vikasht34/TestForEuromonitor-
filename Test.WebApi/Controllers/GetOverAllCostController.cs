using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.Service;

namespace Test.WebApi.Controllers
{
    public class GetOverAllCostController : ApiController
    {
        private readonly IGetOverAllCostService _getOverAllCostService;
        public GetOverAllCostController(IGetOverAllCostService getOverAllCostService)
        {
            _getOverAllCostService = getOverAllCostService;
        }

        [HttpGet]
        [Route("api/GetOverAllCost")]
        public HttpResponseMessage GetOverAllCost(int distance, int stair, int custType)
        {

            decimal cost = _getOverAllCostService.GetTotalCost(distance, stair, custType);

            return Request.CreateResponse(HttpStatusCode.OK, cost);
        }
    }
}
