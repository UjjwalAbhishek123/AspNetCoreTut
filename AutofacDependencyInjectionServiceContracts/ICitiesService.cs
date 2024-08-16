namespace AutofacDependencyInjectionServiceContracts
{
    public interface ICitiesService
    {
        //For example of Service lifetime
        //create GUID property for object creation everytime
        Guid ServiceInstanceId { get; }

        //write the method which you are going to plan to create in the service
        List<string> GetCities();
    }
}
