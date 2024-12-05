using Drawspace;
using RayColors;

namespace RayTracingTests;

public class CanvasFileHandlerTests
{
    [Test]
    public void CreatePPMHeader()
    {
        var canvas = new Canvas(3, 5);
        var fileContent = CanvasFileHandler.toPPM(canvas);

        var expectedContent = "P3\n5 3\n255\n";
        Assert.That(fileContent, Does.StartWith(expectedContent));
    }

    [Test]
    public void CreatesPixelValues()
    {
        var canvas = new Canvas(3, 5);
        var c1 = new RayColor(1.5, 0, 0);
        var c2 = new RayColor(0, 0.5, 0);
        var c3 = new RayColor(-0.5, 0, 1);
        canvas.Write(0, 0, c1)
            .Write(1, 2, c2)
            .Write(2, 4, c3);

        var fileContent = CanvasFileHandler.toPPM(canvas);

        var expectedContent =
            "255 0 0 0 0 0 0 0 0 0 0 0 0 0 0\n" +
            "0 0 0 0 0 0 0 128 0 0 0 0 0 0 0\n" +
            "0 0 0 0 0 0 0 0 0 0 0 0 0 0 255\n";

        Assert.That(fileContent, Does.EndWith(expectedContent));
    }

    [Test]
    public void CreatesManyPixelValues()
    {
        var canvas = new Canvas(2, 10);
        var c1 = new RayColor(1, 0.8, 0.6);
        for (var row = 0; row < canvas.Height; row++)
        for (var col = 0; col < canvas.Width; col++)
            canvas.Write(row, col, c1);

        var fileContent = CanvasFileHandler.toPPM(canvas);

        var expectedContent =
            "255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204 153\n" +
            "255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204 153\n";

        Assert.That(fileContent, Does.EndWith(expectedContent));
    }

    [Test]
    public void EndsWithNewLine()
    {
        var canvas = new Canvas(3, 5);
        var fileContent = CanvasFileHandler.toPPM(canvas);

        Assert.That(fileContent, Does.EndWith("\n"));
    }
}