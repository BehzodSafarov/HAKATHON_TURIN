using ZXing.Net.Maui;
using ZXing;
using ZXing.Net.Maui.Readers;
using UzAutoProduction.Services;
using Android.Locations;

namespace UzAutoProduction;

public partial class MainPage : ContentPage
{
    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;

    public MainPage()
	{
		InitializeComponent();
    }


   private async void GoToScann(object sender, EventArgs e)
	{
       await Shell.Current.GoToAsync("scannpage");
    }

    private async void OnClickGoogleMup(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("googlemup");
    }

    private async void OnClickTakeLocation(object sender, EventArgs e)
    {
        var location = await GetCurrentLocation();

        if (location != null) 
        {
            await Dispatcher.DispatchAsync(new Action(async () =>
            {
                await DisplayAlert("Location detekted", location, "OK");
            }));
        }
        else
        {
            return;
        }
    }


    public async Task<string> GetCurrentLocation()
    {
        try
        {
            _isCheckingLocation = true;

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Microsoft.Maui.Devices.Sensors.Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
                return($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        }
        catch (Exception ex)
        {
            // Unable to get location
        }
        finally
        {
            _isCheckingLocation = false;
        }

        return null;
    }

    public void CancelRequest()
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }


}

