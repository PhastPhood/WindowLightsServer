using System;
namespace WindowLightsServer.Scenes {
  public class SceneFactory: ISceneFactory {
    public WindowScene GetScene(SceneId sceneId) {
      switch (sceneId) {
        case SceneId.BLACK_HOLE_SUN:
          return new BlackHoleSun(new BlackHoleSunConfiguration());
        default:
          return new EmptyScene();
      }
    }
  }
}
