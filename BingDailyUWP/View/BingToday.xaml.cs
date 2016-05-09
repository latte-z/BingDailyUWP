using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using BingDailyUWP.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BingDailyUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BingToday : Page
    {
        private readonly JsonHelper _jsonHelper;
        public BingToday()
        {
            this.InitializeComponent();
            _jsonHelper = new JsonHelper("1920", "1080");
        }
        
        private async void GetImage_OnClick(object sender, RoutedEventArgs e)
        {
            var response = await _jsonHelper.GetJsonTask();
            var tempPm = _jsonHelper.TransJson(response);
            Image.Source = new BitmapImage(new Uri(tempPm.PictureUrl));
        }
    }
}
