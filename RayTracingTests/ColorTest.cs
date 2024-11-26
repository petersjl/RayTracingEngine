using RayColors;

namespace RayTracingTests;

[TestFixture]
public class ColorTest
{
    private const double epsilon = 1e-5;

    [Test]
    public void ShouldBeCreatedWithConstructor()
    {
        var color = new RayColor(-0.5, 0.4, 1.7);
        Assert.That(color.Red, Is.EqualTo(-0.5));
        Assert.That(color.Green, Is.EqualTo(0.4));
        Assert.That(color.Blue, Is.EqualTo(1.7));
    }

    [Test]
    public void ShouldAddColors()
    {
        var c1 = new RayColor(0.9, 0.6, 0.75);
        var c2 = new RayColor(0.7, 0.1, 0.25);
        var c3 = c1 + c2;

        Assert.That(c3.Red, Is.EqualTo(1.6));
        Assert.That(c3.Green, Is.EqualTo(0.7));
        Assert.That(c3.Blue, Is.EqualTo(1.0));
    }

    [Test]
    public void ShouldMultiplyColors()
    {
        var c1 = new RayColor(1, 0.2, 0.4);
        var c2 = new RayColor(0.9, 1, 0.1);
        var c3 = c1 * c2;

        Assert.That(c3.Red, Is.EqualTo(0.9).Within(epsilon));
        Assert.That(c3.Green, Is.EqualTo(0.2).Within(epsilon));
        Assert.That(c3.Blue, Is.EqualTo(0.04).Within(epsilon));
    }
}