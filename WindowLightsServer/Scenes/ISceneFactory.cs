using System;
namespace WindowLightsServer.Scenes {
  public interface ISceneFactory {
    WindowScene GetScene(SceneId sceneId);
  }
}
