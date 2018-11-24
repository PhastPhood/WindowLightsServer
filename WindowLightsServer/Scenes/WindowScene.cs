using System;
using ImageMagick;

namespace WindowLightsServer.Scenes {
  public abstract class WindowScene {
    private int _sceneWidth;
    private int _sceneHeight;

    public virtual void OnSceneStart() {}
    public virtual void OnSceneEnd() {}
    public virtual void RenderNextFrame(MagickImage image) {}

    public void SetSceneDimensions(int sceneWidth, int sceneHeight) {
      _sceneWidth = sceneWidth;
      _sceneHeight = sceneHeight;
    }
  }
}
