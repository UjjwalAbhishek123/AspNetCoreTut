namespace DepnInjcService1
{
    //Goal -> at the time of loading the View, we have to displaya list of Cities that are retrieved from business logic
    public class CitiesService
    {
        //Adding code to send data to controller
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
