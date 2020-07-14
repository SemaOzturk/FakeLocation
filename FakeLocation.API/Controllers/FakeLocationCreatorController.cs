using FakeLocation.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FakeLocation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FakeLocationCreatorController : ControllerBase
    {
        private readonly IFakeLocationCreatorService _fakeLocationCreatorService;

        public FakeLocationCreatorController(IFakeLocationCreatorService fakeLocationCreatorService)
        {
            _fakeLocationCreatorService = fakeLocationCreatorService;
        }

        [HttpGet("generation/start")]
        public IActionResult StartGeneration(string host = "192.168.1.72", int port = 7115, double errorMargin = .1d, double errorOverDistanceMultiplier = 0)
        {
            _fakeLocationCreatorService.StartGenerating(host, port, errorMargin, errorOverDistanceMultiplier);
            return Ok();
        }

        [HttpGet("generation/stop")]
        public IActionResult StopGeneration()
        {
            _fakeLocationCreatorService.StopGenerating();
            return Ok();
        }

        [HttpGet("generation/status")]
        public IActionResult GenerationStatus()
        {
            return Ok(_fakeLocationCreatorService.IsGenerating);
        }
    }
}