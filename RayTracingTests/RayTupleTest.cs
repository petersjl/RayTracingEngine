namespace RayTracingTests;

public class TupleTests
{
    private const double epsilon = 1e-5;
    
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
    
    [Test]
    public void TestScalarMultiplication()
    {
        var t1 = new RayTuple(4.3, -4.2, 3.1, 1.0);
        var t2 = t1 * 3.5;

        Assert.That(t2.X, Is.EqualTo(15.05).Within(epsilon));
        Assert.That(t2.Y, Is.EqualTo(-14.7).Within(epsilon));
        Assert.That(t2.Z, Is.EqualTo(10.85).Within(epsilon));
        Assert.That(t2.W, Is.EqualTo(3.5).Within(epsilon));
    }
    
    [Test]
    public void TestFractionalMultiplication()
    {
        var t1 = new RayTuple(4.3, -4.2, 3.1, 1.0);
        var t2 = t1 * 0.5;

        Assert.That(t2.X, Is.EqualTo(2.15).Within(epsilon));
        Assert.That(t2.Y, Is.EqualTo(-2.1).Within(epsilon));
        Assert.That(t2.Z, Is.EqualTo(1.55).Within(epsilon));
        Assert.That(t2.W, Is.EqualTo(0.5).Within(epsilon));
    }
    
    [Test]
    [TestCase(1,0,0,0,1)]
    [TestCase(0,1,0,0,1)]
    [TestCase(0,0,1,0,1)]
    [TestCase(1,2,3,0, 3.741657)] //sqrt(14)
    [TestCase(-1,-2,-3,0,3.741657)]
    public void TestVectorMagnitude(double x, double y, double z, double w, double magnitude)
    {
        var t1 = new RayVector(x, y, z);
        var mag = t1.Magnitude;

        Assert.That(mag, Is.EqualTo(magnitude).Within(epsilon));
    }

    [Test]
    [TestCase(4,0,0,1,0,0)]
    [TestCase(1,2,3,0.26726,0.53452,0.80178)]
    public void TestVectorNormalization(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        var t1 = new RayVector(x1, y1, z1);
        var t2 = t1.Normalize();
        
        Assert.That(t2.X, Is.EqualTo(x2).Within(epsilon));
        Assert.That(t2.Y, Is.EqualTo(y2).Within(epsilon));
        Assert.That(t2.Z, Is.EqualTo(z2).Within(epsilon));
        Assert.That(t2.Magnitude, Is.EqualTo(1.0).Within(epsilon));
    }

    [Test]
    public void TestVectorDotProduct()
    {
        var t1 = new RayVector(1,2,3);
        var t2 = new RayVector(2,3,4);

        double dotProduct = t1.DotProduct(t2);

        Assert.That(dotProduct, Is.EqualTo(20));
    }
    
    [Test]
    public void TestVectorCrossProduct()
    {
        var a = new RayVector(1,2,3);
        var b = new RayVector(2,3,4);

        RayVector crossProductAB = a.CrossProduct(b);
        RayVector crossProductBA = b.CrossProduct(a);

        RayVector expectedAB = new RayVector(-1,2,-1);
        RayVector expectedBA = new RayVector(1,-2,1);
        Assert.That(crossProductAB, Is.EqualTo(expectedAB));
        Assert.That(crossProductBA, Is.EqualTo(expectedBA));
    }
}

public class RayVector(double x, double y, double z) : RayTuple(x, y, z, 0.0)
{
    public static RayVector CrossProduct(RayVector a, RayVector b)
    {
        return new RayVector(
            a.Y * b.Z - a.Z * b.Y,
            a.Z * b.X - a.X * b.Z,
            a.X * b.Y - a.Y * b.X
        );
    }

    public RayVector CrossProduct(RayVector a)
    {
        return RayVector.CrossProduct(this, a);
    }

}

public class RayPoint(double x, double y, double z) : RayTuple(x, y, z, 1.0);

public class RayTuple(double x, double y, double z, double w)
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;
    public double Z { get; set; } = z;
    public double W { get; set; } = w;

    public bool IsPoint => W.Equals(1.0);
    public bool IsVector => W.Equals(0.0);
    public double Magnitude => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2) + Math.Pow(W, 2));

    public bool Equals(RayTuple other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((RayTuple)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z, W);
    }

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

    public static RayTuple operator *(RayTuple a, double b)
    {
        return new RayTuple(a.X * b, a.Y * b, a.Z * b, a.W * b);
    }

    public static double DotProduct(RayTuple a, RayTuple b)
    {
        return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z) + (a.W * b.W);
    }

    public RayTuple Normalize()
    {
        var mag = this.Magnitude;
        return new RayTuple(this.X / mag, this.Y / mag, this.Z / mag, this.W / mag);
    }

    public double DotProduct(RayTuple a)
    {
        return RayTuple.DotProduct(this, a);
    }
}