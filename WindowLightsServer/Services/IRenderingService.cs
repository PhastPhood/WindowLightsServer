using System;
using System.IO;
using ImageMagick;
using WindowLightsServer.Model;

namespace WindowLightsServer.Services {
  public interface IRenderingService {
    void WriteNextFrame(MemoryStream memoryStream);
  }
}
