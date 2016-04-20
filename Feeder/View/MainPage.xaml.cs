using Feeder.Model;
using Feeder.View;
using Feeder.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Feeder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        BaseFeedListViewModel viewModel = null;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NPRButtonClick(object sender, RoutedEventArgs e)
        {
            viewModel = new NPRListViewModel();
            MainGrid.DataContext = viewModel;
        }

        private void RSSButtonClick(object sender, RoutedEventArgs e)
        {
            viewModel = new RSSListViewModel();
            MainGrid.DataContext = viewModel;
        }

        private void StartCortanaTalk(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddNewFeed(object sender, TappedRoutedEventArgs e)
        {
        }

        private void ItemDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (FeedList.SelectedIndex >= 0 && viewModel.Feeds.Count > FeedList.SelectedIndex)
            {
                Frame.Navigate(typeof(FeedDetailView), viewModel.Feeds[FeedList.SelectedIndex]);
            }
        }
    }
}
