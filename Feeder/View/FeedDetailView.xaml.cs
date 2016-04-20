using Feeder.Model;
using Feeder.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Feeder.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FeedDetailView : Page
    {
        FeedDetailsViewModel _feedDetailsViewModel;
        public FeedDetailView()
        {
            this.InitializeComponent();
            _feedDetailsViewModel = new FeedDetailsViewModel(null);
            this.ItemDetail.DataContext = _feedDetailsViewModel;
        }

        private void OnBackButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var feed = e.Parameter as FeedItem;
            _feedDetailsViewModel.SetItem(feed);
            //this.DataContext = _feedDetailsViewModel.ItemDetail;
        }
    }
}
