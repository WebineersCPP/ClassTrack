using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Services
{
    public class GeoCoordsService
    {
        // This private IConfigRoot variable uses config.json to access its properties
        // Why do we include this? Because in config.json we are storing a BingKey 
        // (which is used to access our Bing app and use its api)
        // Depending if you need extra config keys, you may or may not need to include this
        private IConfigurationRoot _config;

        public GeoCoordsService(IConfigurationRoot config)
        {
            // Why can we inject this IConfigurationRoot as an input param to this constructor?
            // Because we have specified it in Startup.cs (this is one of the first classes called when app starts)
            // Check ConfigureServices() and services.AddSingleton(_config);
            // added as a singleton, now it can be injected in constructors to be used within that class
            _config = config;
        }

        public async Task<GeoCoordsResult> GetCoordsAsync(string name)
        {
            // Now, this is a method whose goal is to receive an input string location
            // and output an object with its Latitude and Longitude properties filled out using the Bing API
            // BING API: https://www.microsoft.com/maps/create-a-bing-maps-key.aspx

            // The following code just makes sure to retrieve the appropriate data
            // Research how you can use other apis or libraries to obtain your data

            // Initializing a Services/GeoCoordsResult.cs object
            // This is just to store data nicely, you can create your own objects
            var result = new GeoCoordsResult()
            {
                Success = false,
                Message = "Failed to get coordinates"
            };

            // Here we are using our IConfigurationRoot to access our respective key
            var apiKey = _config["Keys:BingKey"];
            var encodedName = WebUtility.UrlEncode(name);
            var url = $"http://dev.virtualearth.net/REST/v1/Locations?q={encodedName}&key={apiKey}";


            var client = new HttpClient();

            // For some reason, this is giving a 401 Unauthorized error.
            // Regardless, if this were to succeeded, a result (on obj with Latitude and Longitude
            // retrieved from Bing API) would be obtained
            // This is an example of a Service
            // our goal: to create our own services using other parties / libraries APIs 
            var json = await client.GetStringAsync(url);

            // Read out the results
            // Fragile, might need to change if the Bing API changes
            var results = JObject.Parse(json);
            var resources = results["resourceSets"][0]["resources"];
            if (!resources.HasValues)
            {
                result.Message = $"Could not find '{name}' as a location";
            }
            else
            {
                var confidence = (string)resources[0]["confidence"];
                if (confidence != "High")
                {
                    result.Message = $"Could not find a confident match for '{name}' as a location";
                }
                else
                {
                    var coords = resources[0]["geocodePoints"][0]["coordinates"];
                    result.Latitude = (double)coords[0];
                    result.Longitude = (double)coords[1];
                    result.Success = true;
                    result.Message = "Success";
                }
            }

            // If everything works correctly, our desired result can be returned
            // in this case, what is returned is an object with two properties that have been
            // initialized with Bing API (Latitude and Longitude)
            return result;
        }
    }
}
