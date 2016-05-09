using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BingDailyUWP.View.Setting
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Setting : Page
    {
        private static int _preIndex;
        public Setting()
        {
            this.InitializeComponent();
        }

        private void SettingPivot_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (_preIndex)
            {
                case 0:
                    GeneralTb.Foreground = new SolidColorBrush(Color.FromArgb(255, 128, 128, 128));
                    break;
                case 1:
                    AboutTb.Foreground = new SolidColorBrush(Color.FromArgb(255, 128, 128, 128));
                    break;
            }
            var pivot = sender as Pivot;
            if (pivot != null) _preIndex = pivot.SelectedIndex;

            var o = sender as Pivot;
            if (o != null)
                switch (o.SelectedIndex)
                {
                    case 0:
                        GeneralTb.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                        break;
                    case 1:
                        AboutTb.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                        break;
                }
        }

        private void General_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            SettingPivot.SelectedIndex = 0;
        }

        private void About_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            SettingPivot.SelectedIndex = 1;
        }
    }
}
