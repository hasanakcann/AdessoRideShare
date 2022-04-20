using AdessoRideShare.Core.Entity;
using Newtonsoft.Json;

namespace AdessoRideShare.Data
{
    public class Data
    {
        public List<User> Users { get; set; }
        public List<TravelPlan> TravelPlans { get; set; }
        public List<Contract> Contracts { get; set; }

        private static readonly string _dataFilePath = Path.Combine(Environment.CurrentDirectory, "data.json");
        private static Data _instance;

        private Data()
        {
            Users = new List<User>();
            TravelPlans = new List<TravelPlan>();
            Contracts = new List<Contract>();
        }

        private static Data LoadData()
        {
            if (!File.Exists(_dataFilePath))
                File.Create(_dataFilePath).Dispose();
            var fileContent = File.ReadAllText(_dataFilePath);
            if (string.IsNullOrEmpty(fileContent))
            {
                var newData = new Data();
                File.WriteAllText(_dataFilePath, JsonConvert.SerializeObject(newData));
                return newData;
            }
            var data = JsonConvert.DeserializeObject<Data>(File.ReadAllText(_dataFilePath));

            return data;
        }

        public static Data Instance
        {
            get
            {
                if (_instance == null)
                    _instance = LoadData();
                return _instance;
            }
        }

        public static void Save()
        {
            File.WriteAllText(_dataFilePath, JsonConvert.SerializeObject(_instance));
        }
    }
}