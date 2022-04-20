using AdessoRideShare.Core.Entity;
using AdessoRideShare.Core.Model;

namespace AdessoRideShare.Core.Business
{
    public interface IUserBusiness
    {
        /// <summary>
        /// Kullanıcı oluşturur
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        ResponseModel<bool> Create(User user);

        /// <summary>
        /// Tüm kullanıcıları listeler
        /// </summary>
        /// <returns></returns>
        ResponseModel<List<User>> GetAll();
    }
}