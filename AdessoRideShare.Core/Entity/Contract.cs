namespace AdessoRideShare.Core.Entity
{
    /// <summary>
    /// Sürücü - Yolcu Anlaşma Entity
    /// </summary>
    public class Contract
    {
        public TravelPlan TravelPlan { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}