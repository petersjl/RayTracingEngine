namespace RayTuples;

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
        return a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;
    }

    public RayTuple Normalize()
    {
        var mag = Magnitude;
        return new RayTuple(X / mag, Y / mag, Z / mag, W / mag);
    }

    public double DotProduct(RayTuple a)
    {
        return DotProduct(this, a);
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
        return CrossProduct(this, a);
    }
}

public class RayPoint(double x, double y, double z) : RayTuple(x, y, z, 1.0);