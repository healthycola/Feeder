using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Feeder.Model
{
    class NPRModel : IModelBase
    {
        static string Url = "http://api.npr.org/";
        static string Parameters = "query?id=1001&fields=title%2Cteaser%2Caudio&output=JSON&apiKey=MDIzNDM4NzA4MDE0NTkwNTA3NDVmM2FhMA000";
        HttpClient _client;

        public NPRModel()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(Url);

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        void IModelBase.Initialize()
        {
        }

        void IModelBase.GetNItems(int n, Action<IEnumerable<FeedItem>, Exception> callback)
        {

        }

        async void IModelBase.GetItems(Action<IEnumerable<FeedItem>, Exception> callback)
        {
            HttpResponseMessage response = await _client.GetAsync(Parameters);

            List<FeedItem> feedItems = new List<FeedItem>();
            Exception ex = null;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = await response.Content.ReadAsStringAsync();

                JsonValue x = JsonValue.Parse(dataObjects);
                JsonObject obj = JsonObject.Parse(dataObjects);
                var teasers = ExtractTeasersFromJsonObject(obj);

                foreach (var teaser in teasers)
                {
                    FeedItem feedItem = new FeedItem();
                    feedItem.Headline = teaser;

                    feedItems.Add(feedItem);
                }
            }
            else
            {
                ex = new Exception(String.Format("NPR response was unsuccessful. Status code %s", response.StatusCode.ToString()));
            }

            callback(feedItems, ex);
        }

        private string[] ExtractTeasersFromJsonObject(JsonObject obj)
        {
            string[] output = null;
            if (obj.ContainsKey("list"))
            {
                var list = obj.GetNamedObject("list");

                if (list.ContainsKey("story"))
                {
                    var stories = list.GetNamedArray("story");

                    output = new string[stories.Count];
                    int i = 0;
                    foreach (var story in stories)
                    {
                        if (story.GetObject().ContainsKey("teaser"))
                        {
                            var teaser = story.GetObject().GetNamedObject("teaser");
                            if (teaser.ContainsKey("$text"))
                            {
                                output[i] = teaser.GetNamedString("$text");
                            }
                        }

                        i++;
                    }
                }
            }

            return output;
        }
    }
}
