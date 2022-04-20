using AdessoRideShare.Core.Entity;
using AdessoRideShare.Core.Model;

namespace AdessoRideShare.Core.Business
{
    public interface ITravelPlanBusiness
    {
        /// <summary>
        /// Sisteme seyahat planını Nereden, Nereye, Tarih ve Açıklama, Koltuk Sayısı bilgileri ile ekler.
        /// </summary>
        /// <param name="travelPlan"></param>
        ResponseModel<bool> CreateTravelPlan(TravelPlan travelPlan);

        /// <summary>
        /// Tanımladığı seyahat planını yayına alabilir ve yayından kaldırabiir
        /// </summary>
        /// <param name="travelPlan"></param>
        /// <param name="isActive"></param>
        ResponseModel<bool> PublishTravelPlan(TravelPlan travelPlan, bool isActive);

        /// <summary>
        /// Sistemdeki yayında olan seyahat planlarını Nereden ve Nereye bilgileri ile aratır
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        ResponseModel<List<TravelPlan>> GetAllTravelPlans(string from, string to);

        /// <summary>
        /// Yayında olan seyehat planlarına "Koltuk Sayısı" dolana kadar katılım isteği gönderir
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        ResponseModel<bool> RequestToTravelPlan(TravelPlan travelPlan, int userId);
    }
}