using Feeder.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Feeder.ViewModel
{
    class RSSViewModel : BaseFeedViewModel
    {
        public void RSSFeeds()
        {
            IModelBase model = new NPRModel();
            model.GetItems(async (feedItems, error) =>
            {
                if (error != null)
                {
                    var messageDialog = new MessageDialog("Hello Windows Store App.");
                    messageDialog.Commands.Add(new UICommand(
                        "OK", null));
                    messageDialog.CancelCommandIndex = 0;
                    // Show MessageDialog
                    await messageDialog.ShowAsync();
                }
                else
                {
                    Feeds = new ObservableCollection<FeedItem>(feedItems);
                }
            });
        }

        public void PopulateDesigner()
        {
            Feeds = new ObservableCollection<FeedItem>();

            for (var i = 0; i < 15; i++)
            {
                var feedItem = new FeedItem
                {
                    Headline = "This is an amazing headline " + i + " which also overflows! Isn't that cool! Yes it is. Woohoo! Amazing! This is really cool. It works in Blend too.",
                    Story = "Story " + i
                };

                Feeds.Add(feedItem);
            }
        }

        public RSSViewModel()
        {
            PopulateDesigner();
        }
    }
}
