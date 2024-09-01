using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CustomHtmlHelpersExample.Models
{
    //creating Static class for CustomHTMLHelpers
    public static class CustomHTMLHelper
    {
        //creating Extension method for IHtmlHelper, it will add "Image" helper to generate an <img> tag
        public static IHtmlContent Image(this IHtmlHelper htmlHelper, string src, string alt, object? htmlAttributes = null)
        {
            //create new <img> using "TagBuilder" class that will generate well-formed HTML tags
            var imgTag = new TagBuilder("img");

            //add the 'src' attribute to <img> tag with the value passed in the src parameter.
            imgTag.Attributes.Add("src", src);

            //add the 'alt' attribute to <img> tag with the value passed in the alt parameter.
            imgTag.Attributes.Add("alt", alt);

            //check if there are any additional HTML attributes like class, style etc., passed in 'htmlAttributes' parameter.
            if(htmlAttributes != null)
            {
                //convert anonymous object htmlAttributes into dictionary of key-value pairs that represent HTML attributes
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

                //merge additional attribute into <img> tag
                imgTag.MergeAttributes(attributes);
            }

            return imgTag;
        }
    }
}
