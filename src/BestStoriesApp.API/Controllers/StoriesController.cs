using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using Asp.Versioning;
using BestStoriesApp.Core.Domain.ValueObjects;
using BestStoriesApp.Core.Port.IStoryQueryService;
using Microsoft.AspNetCore.Http;

namespace BestStoriesApp.API.Controllers
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [FormatFilter]
    public class StoriesController : ControllerBase
    {
        private readonly ILogger<StoriesController> _logger;
        private readonly IStoryQueryService _storyQueryService;

        public StoriesController(ILogger<StoriesController> logger, IStoryQueryService storyQueryService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _storyQueryService = storyQueryService ?? throw new ArgumentNullException(nameof(storyQueryService));
        }

        [HttpGet(".{format?}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
