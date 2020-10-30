using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Web.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BB_Collaborate_Recording_Player_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            URL_Field.GotFocus += URL_Field_GotFocus;
        }

        private async void onGoClick(object sender, TappedRoutedEventArgs e)
        {
            String url = URL_Field.Text;
            if (url.StartsWith("https://"))
            {
                // TODO: Start Stream
                Uri uri = new Uri(url);
                HttpClient client = new HttpClient();
                HttpRandomAccessStream stream = await HttpRandomAccessStream.CreateAsync(client, uri);

                Video_Player.SetSource(stream, "video/mp4");
                Video_Player.PlaybackRate = 1.5;
                Video_Player.Play();
            }
        }

        private void URLFieldOnClick(object sender, TappedRoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            textBox.SelectAll();
            textBox.Focus(FocusState.Keyboard);
        }

        private void URL_Field_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            textBox.SelectAll();
            textBox.Focus(FocusState.Keyboard);
        }
    }
    // TODO: Comment the Code
}
