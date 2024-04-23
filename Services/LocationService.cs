using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UzAutoProduction.Services
{
public class LocationService
{
    public async Task<Location?> GetCurrentLocationAsync()
    {
        try
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
            var location = await Geolocation.GetLocationAsync(request);

            if (location != null)
            {
                return location; // Return the location object with latitude and longitude
            }

            return null; // If location is unavailable
        }
        catch (FeatureNotSupportedException) // Device doesn't support geolocation
        {
            Console.WriteLine("Geolocation is not supported on this device.");
            return null;
        }
        catch (PermissionException) // Permission not granted
        {
            Console.WriteLine("Geolocation permission denied.");
            return null;
        }
        catch (Exception ex) // Handle other exceptions
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }
}
}
