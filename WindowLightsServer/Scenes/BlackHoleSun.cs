using System;
using ImageMagick;
using WindowLightsServer.Utils;

namespace WindowLightsServer.Scenes {
  public class BlackHoleSunConfiguration {
    public int MaxNumParticles = 20;
    public double BlackHoleRadius = 2.5;
    public double ParticleSpawnMaxSpeed = 5;
    public double ParticleSpawnMinSpeed = 3;
    public double SpawnChance = 0.5;
    public double DeleteThreshold = 0.1;
  }

  struct BlackHoleParticle {
    public Vector2D Position = new Vector2D();
    public Vector2D Velocity = new Vector2D();
  }

  public class BlackHoleSun: WindowScene {
    BlackHoleSunConfiguration _configuration;

    public BlackHoleSun(BlackHoleSunConfiguration configuration) {
      _configuration = configuration;
    }

    public override void RenderNextFrame(MagickImage image) {
      Random rand = new Random();
      byte[] randomColor = new byte[3];
      rand.NextBytes(randomColor);
      Console.WriteLine(randomColor[0] + ", " + randomColor[1] + ", " + randomColor[2]);
      new Drawables()
        .FillColor(MagickColor.FromRgb(randomColor[0], randomColor[1], randomColor[2]))
          .Rectangle(0, 0, image.Width, image.Height)
          .Draw(image);
      Console.WriteLine("COLOR 2 IS " + image.GetPixels().GetPixel(0, 0).ToColor().ToString());
    }

    private void InitParticle(BlackHoleParticle particle) {

    }

    private void StepParticle(BlackHoleParticle particle) {

    }
  }
}
