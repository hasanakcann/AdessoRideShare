using AdessoRideShare.Core.Business;
using AdessoRideShare.Core.Entity;
using AdessoRideShare.Core.Model;

namespace AdessoRideShare.Business
{
    public class UserBusiness : IUserBusiness
    {
        public ResponseModel<bool> Create(User user)
        {
            Data.Data.Instance.Users.Add(user);

            Data.Data.Save();

            return new ResponseModel<bool> { Result = true };
        }

        public ResponseModel<List<User>> GetAll()
        {
            return new ResponseModel<List<User>> { Result = Data.Data.Instance.Users };
        }
    }
}