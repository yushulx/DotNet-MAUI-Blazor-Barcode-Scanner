# .NET MAUI Blazor Barcode Scanner
This repository contains a .NET MAUI (Multi-platform App UI) Blazor application that allows users to scan barcodes using their device's camera. The application uses the [Dynamsoft JavaScript Barcode SDK](https://www.npmjs.com/package/dynamsoft-javascript-barcode) to decode 1D and 2D barcodes.

## Supported Platforms
- Windows
- macOS
- Android
- iOS

To run the application on your web browser, please visit [https://github.com/yushulx/blazor-barcode-qrcode-reader-scanner](https://github.com/yushulx/blazor-barcode-qrcode-reader-scanner). 

**Known Issue**

`WKWebView` does not support `getUserMedia()` on macOS.

![.NET MAUI blazor barcode scanner software](https://www.dynamsoft.com/codepool/img/2023/04/maui-macos-webview-camera-error.png)

## Prerequisites

- Obtain a [30-day trial license](https://www.dynamsoft.com/customer/license/trialLicense/?product=dcv&package=cross-platform).

## How to Use
1. Set the license key in `wwwroot/jsInterop.js`:
    ```js
    Dynamsoft.DBR.BarcodeReader.license = "DLS2eyJoYW5kc2hha2VDb2RlIjoiMjAwMDAxLTE2NDk4Mjk3OTI2MzUiLCJvcmdhbml6YXRpb25JRCI6IjIwMDAwMSIsInNlc3Npb25QYXNzd29yZCI6IndTcGR6Vm05WDJrcEQ5YUoifQ==";
    ```
2. Launch the application.
    
    ![.NET MAUI blazor barcode scanner software](https://www.dynamsoft.com/codepool/img/2023/04/dotnet-maui-blazor-barcode-scanner.png)
