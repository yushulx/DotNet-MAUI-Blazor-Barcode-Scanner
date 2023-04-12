using Microsoft.AspNetCore.Components.WebView.Maui;

#if ANDROID
//using BarcodeScanner.Platforms.Android.Handlers;
using Android.Webkit;
#endif

#if IOS || MACCATALYST
using WebKit;
using Foundation;
using System.Drawing;
using UIKit;
#endif

namespace BarcodeScanner;

public static class MauiProgram
{
#if ANDROID
    public class MauiBlazorWebViewHandler : BlazorWebViewHandler
    {

        protected override global::Android.Webkit.WebView CreatePlatformView()
        {
            var view = base.CreatePlatformView();

            view.SetWebChromeClient(new MyWebChromeClient());

            return view;
        }
    }

    internal class MyWebChromeClient : WebChromeClient
    {
        public override void OnPermissionRequest(PermissionRequest request)
        {
            try
            {
                string[] requests = new string[] { PermissionRequest.ResourceVideoCapture };
                request.Grant(requests);
                base.OnPermissionRequest(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
#endif

#if IOS || MACCATALYST
    public class MauiBlazorWebViewHandler : BlazorWebViewHandler
    {

        protected override WKWebView CreatePlatformView()
        {
            var view = base.CreatePlatformView();

            var config = view.Configuration;
            config.AllowsInlineMediaPlayback = true;

            return view;
        }
    }
#endif

    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			}).ConfigureMauiHandlers(handlers =>
            {
#if ANDROID || IOS || MACCATALYST
            handlers.AddHandler<BlazorWebView, MauiBlazorWebViewHandler>();
#endif
});



        builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		return builder.Build();
	}
}
