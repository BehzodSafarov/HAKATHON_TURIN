using Microsoft.Maui.Controls;

namespace UzAutoProduction
{
    public partial class GoogleMup : ContentPage
    {
        public GoogleMup()
        {
            InitializeComponent();  // Initialize the content page
            ReachDestination();  // Call the method to reach the destination when the page is loaded
        }

        private async void ReachDestination()
        {
            // Coordinates for the desired destination
            var destinationLatitude = 41;  // Example: Los Angeles, CA
            var destinationLongitude = 68;

            // URL to open Google Maps with walking directions
            var url = $"https://www.google.com/maps/dir/?api=1&destination={destinationLatitude},{destinationLongitude}&travelmode=walking";

            await Launcher.OpenAsync(url);  // Open Google Maps with walking directions
        }
    }
}
