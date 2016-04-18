using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feeder.Model
{
    interface IModelBase
    {
        void Initialize();

        void GetItems(Action<IEnumerable<FeedItem>, Exception> callback);

        void GetNItems(int n, Action<IEnumerable<FeedItem>, Exception> callback);
    }
}
