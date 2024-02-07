using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestStoriesApp.Core.Domain.ValueObjects;
using BestStoriesApp.Core.Port.IStoryQueryService;

namespace BestStoriesApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly ILogger<StoriesController> _logger;
        private readonly IStoryQueryService _storyQueryService;

        public StoriesController(ILogger<StoriesController> logger, IStoryQueryService storyQueryService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _storyQueryService = storyQueryService ?? throw new ArgumentNullException(nameof(storyQueryService));
        }

        [HttpGet]
        public async IAsyncEnumerable<StoryDto> Get([FromQuery] int top)
        {
            await foreach(var storyDpo in _storyQueryService.GetTopBestStories(Count.FromInt(top)))
            {
                yield return new StoryDto
                {
                    Title = storyDpo.Title.Value,
                    Uri = storyDpo.Uri.Value,
                    PostedBy = storyDpo.Uri.Value,
                    Time = storyDpo.Time.ToString(),
                    Score = storyDpo.Score.Value,
                    CommentCount = storyDpo.CommentCount.Value
                };
            }
        }
    }
}
