using Feeder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feeder.ViewModel
{
    class FeedDetailsViewModel : BaseViewModel
    {
        public const string FeedDetailPropertyName = "FeedDetail";

        public FeedItem _feedItem;
        public FeedItem FeedDetail
        {
            get
            {
                return _feedItem;
            }
            set
            {
                _feedItem = value;
                RaisePropertyChanged(FeedDetailPropertyName);
            }
        }

        public FeedDetailsViewModel(FeedItem item)
        {
            FeedDetail = item;
        }

        public void SetItem(FeedItem item)
        {
            FeedDetail = item;
        }
    }
}
