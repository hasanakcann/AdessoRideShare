using AdessoRideShare.Core.Business;
using AdessoRideShare.Core.Entity;
using AdessoRideShare.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace AdessoRideShare.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        public ResponseModel<List<User>> Index()
        {
            return _userBusiness.GetAll();
        }

        [HttpPost]
        [Route("Create")]
        public ResponseModel<bool> Create([FromBody] User user)
        {
            return _userBusiness.Create(user);
        }
    }
}