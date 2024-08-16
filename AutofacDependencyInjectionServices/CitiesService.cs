using AutofacDependencyInjectionServiceContracts;

namespace AutofacDependencyInjectionService
{
    public class CitiesService : ICitiesService, IDisposable
    {
        private List<string> _cities;

        private Guid _serviceInstanceId;
        public Guid ServiceInstanceId
        {
            get
            {
                return _serviceInstanceId;
            }
        }

        //initializing the property in constructor
        public CitiesService()
        {
            //if there are 3 objects in the city service gets created, for each object a new GUID gets created through this code

            _serviceInstanceId = Guid.NewGuid();
            _cities = new List<string>()
            {
                "London", "Paris", "Tokyo", "New York", "Rome"
            };

            //TO DO: Add logic to open database connection
        }

        //create Methods to Send/receive data i.e. send data to controller
        public List<string> GetCities()
        {
            return _cities;
        }

        public void Dispose()
        {
            //TO DO: add logic to close db connection
        }
    }
}
