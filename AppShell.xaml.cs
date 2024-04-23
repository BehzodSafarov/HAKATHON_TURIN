namespace UzAutoProduction;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("scannpage", typeof(ScannPage));
        Routing.RegisterRoute("googlemup", typeof(GoogleMup));
    }
}
