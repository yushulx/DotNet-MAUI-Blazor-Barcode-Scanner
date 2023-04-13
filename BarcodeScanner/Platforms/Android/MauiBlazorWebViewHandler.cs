using Microsoft.AspNetCore.Components.WebView.Maui;

namespace BarcodeScanner.Platforms.Android
{
    // https://stackoverflow.com/questions/70229906/blazor-maui-camera-and-microphone-android-permissions
    public class MauiBlazorWebViewHandler : BlazorWebViewHandler
    {

        protected override global::Android.Webkit.WebView CreatePlatformView()
        {
            var view = base.CreatePlatformView();
            view.SetWebChromeClient(new MyWebChromeClient(this.Context));
            return view;
        }
    }

    
}
