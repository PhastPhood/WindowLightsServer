using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ImageMagick;
using Microsoft.Extensions.Options;
using WindowLightsServer.Model;
using WindowLightsServer.Scenes;

namespace WindowLightsServer.Services {
  public class RenderingService: IRenderingService {
    private WindowScene _currentScene;

    private ISceneFactory _sceneFactory;
    private MagickImage _nextFrame;
    private MagickImage _bufferFrame;

    private int _windowWidth;
    private int _windowHeight;

    private MemoryStream _memoryStream;

    public RenderingService(
        ISceneFactory sceneFactory,
        IOptions<WindowLightsSettings> settingsOptions) {
      _sceneFactory = sceneFactory;
      _memoryStream = new MemoryStream();
      var settings = settingsOptions.Value;

      _windowWidth = settings.WindowWidth;
      _windowHeight = settings.WindowHeight;
      _nextFrame = new MagickImage(MagickColors.Black, _windowWidth, _windowHeight);
      _bufferFrame = new MagickImage(MagickColors.Black, _windowWidth, _windowHeight);
      _nextFrame.Format = MagickFormat.Png;
      _bufferFrame.Format = MagickFormat.Png;

      SceneId sceneId;
      Enum.TryParse<SceneId>(settings.StartingScene, out sceneId);
      _currentScene = _sceneFactory.GetScene(sceneId);
    }

    public void WriteNextFrame(MemoryStream memoryStream) {
      _nextFrame.Write(memoryStream);

      var writtenFrame = _nextFrame;
      _nextFrame = _bufferFrame;
      _bufferFrame = writtenFrame;
      Task.Run(() => _currentScene.RenderNextFrame(_bufferFrame));
    }
  }
}
