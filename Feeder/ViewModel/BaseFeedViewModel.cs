using Feeder.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feeder.ViewModel
{
    class BaseFeedViewModel : BaseViewModel
    {
        public const string FeedsPropertyName = "Feeds";

        public ObservableCollection<FeedItem> _feeds;
        public ObservableCollection<FeedItem> Feeds
        {
            get
            {
                return _feeds;
            }
            set
            {
                _feeds = value;
                RaisePropertyChanged(FeedsPropertyName);
            }
        }
    }
}
