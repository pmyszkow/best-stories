using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using BestStoriesApp.Infrastructure.HackerNewsHttpItemFinderAdapter;
using NUnit.Framework;

namespace BestStoriesApp.IntTests.Infrastructure.HackerNewsHttpItemFinderAdapter
{
    [TestFixture]
    public class HackerNewsHttpClientTests
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/"),
        };

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", MediaTypeNames.Application.Json);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "HackerNewsHttpClient");
        }

        [Test]
        public void GetBestStoriesItemIdsReturnsIntEnumerable()
        {
            var client = new HackerNewsHttpClient(_httpClient);

            var result = client.GetBestStoriesItemIds().ToEnumerable().ToList();

            if (!result.Any())
                Assert.Inconclusive();

            CollectionAssert.AllItemsAreNotNull(result);
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(int));
        }

        [Test]
        public void GetStoryItemByIdReturnsItemDto()
        {
            var client = new HackerNewsHttpClient(_httpClient);

            var result = client.GetStoryItemById(39369653).GetAwaiter().GetResult();

            if (result == null)
                Assert.Inconclusive();

            Assert.IsInstanceOf<string>(result.By);
            Assert.IsInstanceOf<int>(result.Descendants);
            Assert.IsInstanceOf<int>(result.Id);
            Assert.IsNotNull(result.Id);
            Assert.IsInstanceOf<List<int>>(result.Kids);
            Assert.IsInstanceOf<int>(result.Score);
            Assert.IsInstanceOf<int>(result.Time);
            Assert.IsInstanceOf<string>(result.Title);
            Assert.IsInstanceOf<string>(result.Type);
            Assert.IsInstanceOf<string>(result.Url);
        }
    }
}