using DependencyInjection2ServiceContracts;

namespace DependencyInjection2Service
{
    public class CitiesService : ICitiesService
    {
        private List<string> _cities;

        //initializing the property in constructor
        public CitiesService()
        {
            _cities = new List<string>()
            {
                "London", "Paris", "Tokyo", "New York", "Rome"
            };
        }

        //create Methods to Send/receive data i.e. send data to controller
        public List<string> GetCities()
        {
            return _cities;
        }
    }
}
