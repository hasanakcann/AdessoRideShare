using AdessoRideShare.Core.Business;
using AdessoRideShare.Core.Entity;
using AdessoRideShare.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace AdessoRideShare.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravelPlanController : ControllerBase
    {
        private readonly ITravelPlanBusiness _travelPlanBusiness;
        public TravelPlanController(ITravelPlanBusiness travelPlanBusiness)
        {
            _travelPlanBusiness = travelPlanBusiness;
        }

        [HttpGet]
        public ResponseModel<List<TravelPlan>> Index(string from, string to)
        {
            return _travelPlanBusiness.GetAllTravelPlans(from, to);
        }

        [HttpPost]
        [Route("Create")]
        public ResponseModel<bool> Create([FromBody] TravelPlan travelPlan)
        {
            return _travelPlanBusiness.CreateTravelPlan(travelPlan);
        }

        [HttpPost]
        [Route("Publish")]
        public ResponseModel<bool> Publish([FromBody] TravelPlan travelPlan, bool isActive)
        {
            return _travelPlanBusiness.PublishTravelPlan(travelPlan, isActive);
        }

        [HttpPost]
        [Route("Request")]
        public ResponseModel<bool> Request([FromBody] TravelPlan travelPlan, int userId)
        {
            return _travelPlanBusiness.RequestToTravelPlan(travelPlan, userId);
        }
    }
}