using RayTuples;

namespace RayColors;

public class RayColor : RayTuple
{
    public RayColor(double red, double green, double blue) : this(new RayTuple(red, green, blue, 0.0))
    {
    }

    private RayColor(RayTuple tuple) : base(tuple.X, tuple.Y, tuple.Z, tuple.W)
    {
    }

    public double Red => X;
    public double Green => Y;
    public double Blue => Z;

    public static RayColor operator +(RayColor left, RayColor right)
    {
        return new RayColor((RayTuple)left + right);
    }

    public static RayColor operator *(RayColor left, RayColor right)
    {
        return new RayColor(
            left.Red * right.Red,
            left.Green * right.Green,
            left.Blue * right.Blue
        );
    }
}