using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WindowLightsServer.Model;
using WindowLightsServer.Services;

namespace WindowLightsServer.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class SceneController : ControllerBase {
    IRenderingService _renderingService;

    public SceneController(
        IRenderingService renderingService) {
      _renderingService = renderingService;
    }

    [HttpGet("nextframe")]
    public ActionResult Get() {
      using (var memoryStream = new MemoryStream()) {
        _renderingService.WriteNextFrame(memoryStream);
        return File(memoryStream.ToArray(), "image/png");
      }
    }
  }
}
