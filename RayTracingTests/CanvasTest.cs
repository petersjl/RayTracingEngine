using RayColors;
using RayTracingEngine;

namespace RayTracingTests;

public class CanvasTest
{
    private readonly RayColor black = new(0, 0, 0);

    [Test]
    public void CreateCanvas()
    {
        var c = new Canvas(10, 20);

        Assert.That(c.Height, Is.EqualTo(10));
        Assert.That(c.Width, Is.EqualTo(20));
        var count = 0;
        foreach (var pixel in c.PixelStream)
        {
            count++;
            Assert.That(pixel, Is.EqualTo(black));
        }

        Assert.That(count, Is.EqualTo(200));
    }

    [Test]
    public void WriteToCanvas()
    {
        var canvas = new Canvas(10, 20);
        var red = new RayColor(1, 0, 0);

        canvas.Write(2, 3, red);

        Assert.That(canvas[2, 3], Is.EqualTo(red));
    }
}