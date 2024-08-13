using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WeatherAppNew.Models;


//create a view component that displays weather details of a single city; and invoke the same in "Index" view in foreach loop while reading city details.

//Apply background color for each box, based on the following categories of temperature value. Write essential code in view component, to determine the apppriate css class to apply background color.

//  Fahrenheit is less than 44 = blue background color
//  Fahrenheit is between 44 and 74 = blue background color
//  Fahrenheit is greater than 74 = blue background color

//Previously Code was in _CityPartial.cshtml as below
//    @* @model CityWeather

//@{
//    //local function: get css class based on ranges of fahrenheit value as instructed in the requirement
//    string GetCssClassByFahrenheit(int TemperatureFahrenheit)
//    {
//        return TemperatureFahrenheit switch
//        {
//            (< 44) => "blue-back",
//            (>= 44) and (< 75) => "green-back",
//            (>= 75) => "orange-back"
//        };
//    }
//}

//< div class= "box cursor-pointer w-30 @GetCssClassByFahrenheit(Model.TemperatureFahrenheit)" >
//    < div class= "flex-borderless" >
//        < div class= "w-50" >
//            < h2 > @Model.CityName </ h2 >
//            < h4 class= "text-dark-grey" > @Model.DateAndTime.ToString("hh:mm tt") </ h4 >
//            < a href = "~/weather/@Model.CityUniqueCode" class= "margin-top" > Details </ a >
//        </ div >
//        < div class= "w-50 border-left" >
//            < h1 class= "margin-left" > @Model.TemperatureFahrenheit < sup class= "text-grey" > &#8457</sup></h1>
//        </ div >
//    </ div >

//</ div >

namespace WeatherAppNew.ViewComponents
{
    public class CityViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CityWeather city)
        {
            ViewBag.CityCssClass = GetCssClassByFahrenheit(city.TemperatureFahrenheit);
            return View(city);
        }

        //private method: get css class based on ranges of fahrenheit value as instructed in the requirement
        //it encapsulates the internal logic
        private string GetCssClassByFahrenheit(int TemperatureFahrenheit)
        {
            return TemperatureFahrenheit switch
            {
                (< 44) => "blue-back",
                (>= 44) and (< 75) => "green-back",
                (>= 75) => "orange-back"
            };
        }
    }
}
