using System;
using ImageMagick;

namespace WindowLightsServer.Scenes {
  public class EmptyScene: WindowScene {

    public EmptyScene() {
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
  }
}
