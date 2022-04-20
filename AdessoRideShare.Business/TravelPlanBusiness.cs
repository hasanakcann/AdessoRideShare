using AdessoRideShare.Core.Business;
using AdessoRideShare.Core.Entity;
using AdessoRideShare.Core.Model;

namespace AdessoRideShare.Business
{
    public class TravelPlanBusiness : ITravelPlanBusiness
    {
        public ResponseModel<bool> CreateTravelPlan(TravelPlan travelPlan)
        {
            Data.Data.Instance.TravelPlans.Add(travelPlan);

            Data.Data.Save();

            return new ResponseModel<bool> { Result = true };
        }

        public ResponseModel<List<TravelPlan>> GetAllTravelPlans(string from, string to)
        {
            var list = Data.Data.Instance.TravelPlans.Where(x => x.From == from && x.To == to).ToList();
            return new ResponseModel<List<TravelPlan>> { Result = list };
        }

        public ResponseModel<bool> PublishTravelPlan(TravelPlan travelPlan, bool isActive)
        {
            Data.Data.Instance.TravelPlans.Find(x => x.Id == travelPlan.Id).IsActive = isActive;

            Data.Data.Save();

            return new ResponseModel<bool> { Result = true };
        }

        public ResponseModel<bool> RequestToTravelPlan(TravelPlan travelPlan, int userId)
        {
            int passengerCount = Data.Data.Instance.Contracts.Count(x => x.TravelPlan.Id == travelPlan.Id);
            if (passengerCount == travelPlan.SeatCapacity)
            {
                return new ResponseModel<bool> { Result = false, Message = "Yolcu kapasitesi doldu!" };
            }
            User user = Data.Data.Instance.Users.Find(x => x.Id == userId);
            Data.Data.Instance.Contracts.Add(new Contract
            {
                User = user,
                TravelPlan = travelPlan,
                Description = travelPlan.Description,
                IsActive = true
            });

            Data.Data.Save();

            return new ResponseModel<bool> { Result = true };
        }
    }
}