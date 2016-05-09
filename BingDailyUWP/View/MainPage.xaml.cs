using System;
using System.ServiceModel.Channels;
using Windows.Data.Xml.Dom;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using BingDailyUWP.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BingDailyUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static int _preIndex;

        public MainPage()
        {
            this.InitializeComponent();
            ApplyColorToTitleBar();
        }

        void ApplyColorToTitleBar()
        {
            var view = ApplicationView.GetForCurrentView();

            // active 
            view.TitleBar.BackgroundColor = Color.FromArgb(255, 0, 130, 114);
            view.TitleBar.ForegroundColor = Colors.White;

            // inactive
            view.TitleBar.InactiveBackgroundColor = Color.FromArgb(255, 0, 130, 114);
            view.TitleBar.InactiveForegroundColor = Colors.LightGray;

            // button
            view.TitleBar.ButtonBackgroundColor = Color.FromArgb(255, 0, 130, 114);
            view.TitleBar.ButtonForegroundColor = Colors.White;

            view.TitleBar.ButtonHoverBackgroundColor = Color.FromArgb(255, 0, 130, 114);
            view.TitleBar.ButtonHoverForegroundColor = Colors.White;

            view.TitleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 0, 130, 114);
            view.TitleBar.ButtonPressedForegroundColor = Colors.White;

            view.TitleBar.ButtonInactiveBackgroundColor = Color.FromArgb(255, 0, 130, 114);
            view.TitleBar.ButtonInactiveForegroundColor = Colors.White;
        }

        private void Favorite_OnClick(object sender, RoutedEventArgs e)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            // provide text
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode("收藏完毕"));
            // provide image
            XmlNodeList toastImageAttributes = toastXml.GetElementsByTagName("image");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("src", $"ms-appx:///Assets/StoreLogo.png");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "logo");
            // duration
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            var xmlElement = (XmlElement)toastNode;
            xmlElement?.SetAttribute("duration", "short");
            // audio
            XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", $"ms-winsoundevent:Notification.Reminder");
            toastNode?.AppendChild(audio);
            // send toast
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        private void Today_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            MainPivot.SelectedIndex = 0;
            Refresh.Visibility = Visibility.Visible;
        }

        private void Favorite_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            MainPivot.SelectedIndex = 1;
            Refresh.Visibility = Visibility.Collapsed;
        }

        private void Setting_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            MainPivot.SelectedIndex = 2;
            Refresh.Visibility = Visibility.Collapsed;
        }

        private void MainPivot_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (_preIndex)
            {
                case 0:
                    TodayTb.Foreground = new SolidColorBrush(Color.FromArgb(255, 128, 128, 128));
                    TodayBottom.Background = new SolidColorBrush(Color.FromArgb(0, 0 ,130, 114));
                    break;
                case 1:
                    FavoriteTb.Foreground = new SolidColorBrush(Color.FromArgb(255, 128, 128, 128));
                    FavoriteBottom.Background = new SolidColorBrush(Color.FromArgb(0, 0, 130, 114));
                    break;
                case 2:
                    SettingTb.Foreground = new SolidColorBrush(Color.FromArgb(255, 128, 128, 128));
                    break;
            }
            var pivot = sender as Pivot;
            if (pivot != null) _preIndex = pivot.SelectedIndex;

            var o = sender as Pivot;
            if (o != null)
                switch (o.SelectedIndex)
                {
                    case 0:
                        TodayTb.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                        TodayBottom.Background = new SolidColorBrush(Color.FromArgb(255, 0, 130, 114));
                        break;
                    case 1:
                        FavoriteTb.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                        FavoriteBottom.Background = new SolidColorBrush(Color.FromArgb(255, 0, 130, 114));
                        break;
                    case 2:
                        SettingTb.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                        break;
                }
        }
    }
}
