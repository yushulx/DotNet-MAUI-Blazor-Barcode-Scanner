using Android.Content;
using Android.Webkit;

namespace BarcodeScanner.Platforms.Android
{
    public class MyWebChromeClient : WebChromeClient
    {
        private MainActivity _activity;


        public MyWebChromeClient(Context context)
        {
            _activity = context as MainActivity;
        }

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

        public override bool OnShowFileChooser(global::Android.Webkit.WebView webView, IValueCallback filePathCallback, FileChooserParams fileChooserParams)
        {
            base.OnShowFileChooser(webView, filePathCallback, fileChooserParams);
            return _activity.ChooseFile(filePathCallback, fileChooserParams.CreateIntent(), fileChooserParams.Title);
        }


    }
}
