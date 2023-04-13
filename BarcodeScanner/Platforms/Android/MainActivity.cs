using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Webkit;
using static Android.Webkit.WebChromeClient;
using System.Diagnostics;

namespace BarcodeScanner;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    private IValueCallback _filePathCallback;
    private int _requestCode = 100;

    //protected override void OnCreate(Bundle savedInstanceState)
    //{
    //    base.OnCreate(savedInstanceState);

    //    Platform.Init(this, savedInstanceState);
    //    ActivityCompat.RequestPermissions(this, new[] { Manifest.Permission.Camera }, 0);
    //}

    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
        if (_requestCode == requestCode)
        {
            if (_filePathCallback == null)
                return;

            Java.Lang.Object result = FileChooserParams.ParseResult((int)resultCode, data);
            _filePathCallback.OnReceiveValue(result);
        }
    }

    public bool ChooseFile(IValueCallback filePathCallback, Intent intent, string title)
    {
        _filePathCallback = filePathCallback;

        StartActivityForResult(Intent.CreateChooser(intent, title), _requestCode);

        return true;
    }
}
