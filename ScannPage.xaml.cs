namespace UzAutoProduction;

public partial class ScannPage : ContentPage
{
	public ScannPage()
	{
		InitializeComponent();

        barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
        {
            Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
            AutoRotate = true,
            Multiple = true,
        };
    }

    private async void OnBarcodeDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {

        var result = e.Results.FirstOrDefault();


        if (result is null)
        {
            return;
        }

        await Dispatcher.DispatchAsync(new Action(async () =>
        {
            await DisplayAlert("Barcode Detected", result.Value.ToString(), "OK");
        }));

    }
}