using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BestStoriesApp.Infrastructure.HackerNewsHttpItemFinderAdapter
{
    public class HttpClientStub
    {
        private const string _itemsJson =
            "[{\"by\":\"dhouston\",\"descendants\":71,\"id\":8863,\"kids\":[8952,9224,8917,8884],\"score\":111,\"time\":1174714200,\"title\":\"werweqrewfsdfdfdsf\",\"type\":\"story\",\"url\":\"http://www.getdropbox.com/u/2/screencast.html\"},{\"by\":\"foobar\",\"descendants\":81,\"id\":9976,\"kids\":[8952],\"score\":10,\"time\":1175714200,\"title\":\"dsfrsaefdasfadsf\",\"type\":\"story\",\"url\":\"http://www.foobar.com/u/5/screencast.html\"},{\"by\":\"barfoo\",\"descendants\":91,\"id\":12456,\"kids\":[],\"score\":234,\"time\":1179714200,\"title\":\"2343466756783453455435\",\"type\":\"story\",\"url\":\"http://www.barfoo.com/u/2/screencast.html\"},{\"by\":\"foll\",\"descendants\":101,\"id\":67878,\"kids\":[],\"score\":1900,\"time\":1195714200,\"title\":\"4534534534tdsfdsvfcdsfdsf34r543\",\"type\":\"story\",\"url\":\"http://www.fool.com/u/2/screencast.html\"}]";

        private readonly IEnumerable<ItemDto> _items;

        public HttpClientStub()
        {
            //var serializeOptions = new JsonSerializerOptions()
            //{
            //    PropertyNameCaseInsensitive = true,
            //};

            //_items = JsonSerializer.Deserialize<List<ItemDto>>(_itemsJson, serializeOptions);

            _items = JsonSerializer.Deserialize<List<ItemDto>>(_itemsJson);
        }

        public async IAsyncEnumerable<int> GetBestStoriesItemIds()
        {
            foreach (var id in _items.Where(item => item.Id.HasValue).Select(item => item.Id.Value))
            {
                yield return await Task.FromResult(id);
            }
        }

        public async Task<ItemDto> GetStoryItemById(int id)
        {
            var storyItem = _items.Where(item => item.Id.HasValue).Single(item => item.Id == id);

            return await Task.FromResult(storyItem);
        }
    }
}