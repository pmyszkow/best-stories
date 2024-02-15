using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BestStoriesApp.Core.Domain.ValueObjects;
using BestStoriesApp.Core.Port.IItemFinder;
using BestStoriesApp.Infrastructure.HackerNewsHttpItemFinderAdapter;
using Moq;
using NUnit.Framework;

namespace BestStoriesApp.IntTests.Infrastructure.HackerNewsHttpItemFinderAdapter
{
    [TestFixture]
    public class ItemFinderAdapterTests
    {
        private readonly ReadOnlyDictionary<int, ItemDto> _storyItemDtosDict = new(
            new Dictionary<int, ItemDto>
            {
                [8863] = new()
                {
                    By = "dhouston",
                    Descendants = 71,
                    Id = 8863,
                    Kids = new List<int>
                    {
                        8952,
                        9224,
                        8917,
                        8884
                    },
                    Score = 111,
                    Time = 1174714200,
                    Title = "FooBarTitle 1",
                    Type = "story",
                    Url = "http://www.getdropbox.com/u/2/screencast.html"
                },
                [9976] = new()
                {
                    By = "foobar",
                    Descendants = 81,
                    Id = 9976,
                    Kids = new List<int>
                    {
                        8952
                    },
                    Score = 10,
                    Time = 1175714200,
                    Title = "FooBarTitle 2",
                    Type = "story",
                    Url = "http://www.foobar.com/u/5/screencast.html"
                },
                [12456] = new()
                {
                    By = "barfoo",
                    Descendants = 91,
                    Id = 12456,
                    Kids = new List<int>(),
                    Score = 234,
                    Time = 1179714200,
                    Title = "FooBarTitle 3",
                    Type = "story",
                    Url = "http://www.barfoo.com/u/2/screencast.html"
                },
                [67878] = new()
                {
                    By = "fool",
                    Descendants = 101,
                    Id = 67878,
                    Kids = new List<int>(),
                    Score = 1900,
                    Time = 1195714200,
                    Title = "FooBarTitle 4",
                    Type = "story",
                    Url = "http://www.fool.com/u/2/screencast.html"
                }
            });

        private Mock<IHackerNewsHttpClient> _httpClientStub;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _httpClientStub = new Mock<IHackerNewsHttpClient>(MockBehavior.Strict);

            _httpClientStub.Setup(mock => mock.GetStoryItemById(8863)).ReturnsAsync(_storyItemDtosDict[8863]);
            _httpClientStub.Setup(mock => mock.GetStoryItemById(9976)).ReturnsAsync(_storyItemDtosDict[9976]);
            _httpClientStub.Setup(mock => mock.GetStoryItemById(12456)).ReturnsAsync(_storyItemDtosDict[12456]);
            _httpClientStub.Setup(mock => mock.GetStoryItemById(67878)).ReturnsAsync(_storyItemDtosDict[67878]);

            _httpClientStub.Setup(mock => mock.GetBestStoriesItemIds()).Returns(_storyItemDtosDict.Keys.ToAsyncEnumerable());
        }

        [Test]
        public void GetTopBestStoryItemsReturnsTopStoryItemDposOrderedByScoreDescending()
        {
            var itemFinder = new ItemFinderAdapter(_httpClientStub.Object);

            var top = Count.FromInt(2);

            var expectedItemIdsInOrder = _storyItemDtosDict.Values.OrderByDescending(item => item.Score)
                .Take(top.Value)
                .Select(item => ItemId.FromInt(item.Id.Value));

            var actualItemIdsInOrder = itemFinder.GetTopBestStoryItems(top).ToEnumerable().Select(item => item.Id);

            CollectionAssert.AreEqual(expectedItemIdsInOrder, actualItemIdsInOrder);
        }

        [Test]
        public async Task GetStoryItemByIdReturnsStoryItemDpoForQueriedItemId()
        {
            var itemFinder = new ItemFinderAdapter(_httpClientStub.Object);

            var itemId = ItemId.FromInt(12456);

            var dto = _storyItemDtosDict[itemId.Value];
            var expectedDpo = StoryItemDpo.Create(dto.By,
                dto.Descendants,
                dto.Id,
                dto.Kids,
                dto.Score,
                dto.Time,
                dto.Title,
                dto.Type,
                dto.Url);

            var actualDpo = await itemFinder.GetStoryItemById(itemId);

            Assert.AreEqual(expectedDpo.By, actualDpo.By);
            Assert.AreEqual(expectedDpo.Descendants, actualDpo.Descendants);
            Assert.AreEqual(expectedDpo.Id, actualDpo.Id);
            CollectionAssert.AreEqual(expectedDpo.Kids, actualDpo.Kids);
            Assert.AreEqual(expectedDpo.Score, actualDpo.Score);
            Assert.AreEqual(expectedDpo.Time, actualDpo.Time);
            Assert.AreEqual(expectedDpo.Title, actualDpo.Title);
            Assert.AreEqual(expectedDpo.Type, actualDpo.Type);
            Assert.AreEqual(expectedDpo.Url, actualDpo.Url);
        }
    }
}