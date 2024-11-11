namespace RayTracingTests;

public class TupleTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestTuple1()
    {
        var a = new RayTuple(4.3, -4.2, 3.1, 1.0);

        Assert.That(a.X, Is.EqualTo(4.3));
        Assert.That(a.Y, Is.EqualTo(-4.2));
        Assert.That(a.Z, Is.EqualTo(3.1));
        Assert.That(a.W, Is.EqualTo(1.0));
        Assert.That(a.IsPoint, Is.True);
        Assert.That(a.IsVector, Is.False);
    }

    [Test]
    public void TestTuple2()
    {
        var a = new RayTuple(4.3, -4.2, 3.1, 0.0);

        Assert.That(a.X, Is.EqualTo(4.3));
        Assert.That(a.Y, Is.EqualTo(-4.2));
        Assert.That(a.Z, Is.EqualTo(3.1));
        Assert.That(a.W, Is.EqualTo(0.0));
        Assert.That(a.IsPoint, Is.False);
        Assert.That(a.IsVector, Is.True);
    }

    [Test]
    public void TestPoint()
    {
        var p = new RayPoint(4.3, -4.2, 3.1);

        Assert.That(p.X, Is.EqualTo(4.3));
        Assert.That(p.Y, Is.EqualTo(-4.2));
        Assert.That(p.Z, Is.EqualTo(3.1));
        Assert.That(p.W, Is.EqualTo(1.0));
        Assert.That(p.IsPoint, Is.True);
        Assert.That(p.IsVector, Is.False);
    }

    [Test]
    public void TestVector()
    {
        var v = new RayVector(4.3, -4.2, 3.1);

        Assert.That(v.X, Is.EqualTo(4.3));
        Assert.That(v.Y, Is.EqualTo(-4.2));
        Assert.That(v.Z, Is.EqualTo(3.1));
        Assert.That(v.W, Is.EqualTo(0.0));
        Assert.That(v.IsPoint, Is.False);
        Assert.That(v.IsVector, Is.True);
    }

    [Test]
    public void TestTupleAddition()
    {
        var t1 = new RayTuple(4.3, -4.2, 3.1, 0.0);
        var t2 = new RayTuple(4.3, -4.2, 3.1, 0.0);
        var t3 = t1 + t2;

        Assert.That(t3.X, Is.EqualTo(8.6));
        Assert.That(t3.Y, Is.EqualTo(-8.4));
        Assert.That(t3.Z, Is.EqualTo(6.2));
        Assert.That(t3.W, Is.EqualTo(0.0));
        Assert.That(t3.IsPoint, Is.False);
        Assert.That(t3.IsVector, Is.True);
    }
    
    [Test]
    public void TestPointSubtraction()
    {
        var t1 = new RayPoint(4.3, -4.2, 3.1);
        var t2 = new RayPoint(4.3, -4.2, 3.1);
        var t3 = t1 - t2;

        Assert.That(t3.X, Is.EqualTo(0.0));
        Assert.That(t3.Y, Is.EqualTo(0.0));
        Assert.That(t3.Z, Is.EqualTo(0.0));
        Assert.That(t3.W, Is.EqualTo(0.0));
        Assert.That(t3.IsPoint, Is.False);
        Assert.That(t3.IsVector, Is.True);
    }
    
    [Test]
    public void TestTupleNegation()
    {
        var t1 = new RayTuple(4.3, -4.2, 3.1, 1.0);
        var t2 = -t1;

        Assert.That(t2.X, Is.EqualTo(-4.3));
        Assert.That(t2.Y, Is.EqualTo(4.2));
        Assert.That(t2.Z, Is.EqualTo(-3.1));
        Assert.That(t2.W, Is.EqualTo(-1.0));
        Assert.That(t2.IsPoint, Is.False);
        Assert.That(t2.IsVector, Is.False);
    }
}

public class RayVector(double x, double y, double z) : RayTuple(x, y, z, 0.0);

public class RayPoint(double x, double y, double z) : RayTuple(x, y, z, 1.0);

public class RayTuple(double x, double y, double z, double w)
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;
    public double Z { get; set; } = z;
    public double W { get; set; } = w;

    public bool IsPoint => W.Equals(1.0);
    public bool IsVector => W.Equals(0.0);

    public static RayTuple operator +(RayTuple a, RayTuple b)
    {
        return new RayTuple(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    }

    public static RayTuple operator -(RayTuple a, RayTuple b)
    {
        return new RayTuple(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    }

    public static RayTuple operator -(RayTuple a)
    {
        return new RayTuple(-a.X, -a.Y, -a.Z, -a.W);
    }
}