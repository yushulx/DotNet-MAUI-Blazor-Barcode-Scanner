using Android.Webkit;
using Microsoft.AspNetCore.Components.WebView.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://stackoverflow.com/questions/70229906/blazor-maui-camera-and-microphone-android-permissions
namespace BarcodeScanner.Platforms.Android.Handlers
{
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
                request.Grant(request.GetResources());
                base.OnPermissionRequest(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
