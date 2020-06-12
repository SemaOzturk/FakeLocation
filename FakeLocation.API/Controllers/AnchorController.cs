﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FakeApplication.DTO.ApplicationEntities;
using FakeLocation.Application.Services;
using FakeLocation.Shared.UIModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FakeLocation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnchorController : ControllerBase
    {
        private readonly ILogger<AnchorController> _logger;
        private readonly IAnchorService _anchorService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configurationRoot;

        public AnchorController(ILogger<AnchorController> logger, IAnchorService anchorService, IMapper mapper, IConfiguration configurationRoot)
        {
            _logger = logger;
            _anchorService = anchorService;
            _mapper = mapper;
            _configurationRoot = configurationRoot;
            var defaultAnchors = _configurationRoot.GetSection("DefaultAnchors").Get<Anchor[]>();
            _anchorService.Set(defaultAnchors);
        }

        [HttpGet]
        public IEnumerable<AnchorReadModel> Get()
        {
            return _mapper.Map<IEnumerable<AnchorReadModel>>(_anchorService.GetAll());
        }

        [HttpPost]
        public IActionResult Add([FromBody] AnchorCreateModel anchorCreateModel)
        {
            try
            {
                if (_anchorService.Add(_mapper.Map<Anchor>(anchorCreateModel)))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Same Id already in use");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}