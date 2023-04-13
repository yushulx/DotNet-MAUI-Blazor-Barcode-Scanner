using Microsoft.AspNetCore.Components.WebView;

#if ANDROID
using BarcodeScanner.Platforms.Android;
#endif

namespace BarcodeScanner;

public partial class WebContentPage : ContentPage
{
	public WebContentPage()
	{
		InitializeComponent();
        //webView.BlazorWebViewInitialized += WebView_BlazorWebViewInitialized;
        webView.BlazorWebViewInitializing += WebView_BlazorWebViewInitializing;
    }

    private void WebView_BlazorWebViewInitializing(object sender, BlazorWebViewInitializingEventArgs e)
    {
#if IOS || MACCATALYST                   
            e.Configuration.AllowsInlineMediaPlayback = true;
            e.Configuration.MediaTypesRequiringUserActionForPlayback = WebKit.WKAudiovisualMediaTypes.None;
#endif
    }

    private void WebView_BlazorWebViewInitialized(object sender, Microsoft.AspNetCore.Components.WebView.BlazorWebViewInitializedEventArgs e)
    {
#if ANDROID
        e.WebView.Settings.JavaScriptEnabled = true;
        e.WebView.Settings.AllowFileAccess = true;
        e.WebView.SetWebChromeClient(new MyWebChromeClient(e.WebView.Context));
#endif
    }
}