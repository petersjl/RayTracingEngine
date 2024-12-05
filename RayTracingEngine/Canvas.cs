using RayColors;

namespace Drawspace;

public class Canvas
{
    private readonly RayColor[,] _pixelMap;

    public Canvas(int height, int width)
    {
        Height = height;
        Width = width;

        _pixelMap = new RayColor[height, width];
        for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
            _pixelMap[i, j] = new RayColor(0, 0, 0);
    }

    public int Height { get; }
    public int Width { get; }

    public RayColor this[int row, int col] => _pixelMap[row, col];

    public IEnumerable<RayColor> PixelStream
    {
        get
        {
            foreach (var color in _pixelMap) yield return color;
        }
    }

    public Canvas Write(int row, int col, RayColor color)
    {
        _pixelMap[row, col] = color;
        return this;
    }
}