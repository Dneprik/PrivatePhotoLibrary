using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XLabs.Platform.Services.Media;

namespace PrivatePhotoLibrary.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            DependencyService.Register<MediaPicker>();

            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
