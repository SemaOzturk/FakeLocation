using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FakeApplication.DTO.ApplicationEntities;
using FakeLocation.Application.Services.Interfaces;
using FakeLocation.Shared.UIModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FakeLocation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly ILogger<TagController> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configurationRoot;

        public TagController(ITagService tagService, ILogger<TagController> logger, IMapper mapper, IConfiguration configurationRoot)
        {
            _tagService = tagService;
            _logger = logger;
            _mapper = mapper;
            _configurationRoot = configurationRoot;
        }

        [HttpGet]
        public IEnumerable<TagReadModel> Get(bool includeDeactive)
        {
            var tags = _tagService.GetAll(includeDeactive);
            return _mapper.Map<IEnumerable<TagReadModel>>(tags);
        }

        [HttpPost("register/multiple")]
        public IActionResult RegisterMultiple(IEnumerable<TagCreateModel> models)
        {
            return Ok(_tagService.UpsertMany(_mapper.Map<IEnumerable<Tag>>(models).ToArray()));
        }
        [HttpPost("register")]
        public IActionResult Register(TagCreateModel model)
        {
            return Ok(_tagService.UpsertMany(_mapper.Map<Tag>(model)));
        }
    }
}