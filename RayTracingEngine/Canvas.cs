using RayColors;

namespace RayTracingEngine;

public class Canvas
{
    private readonly RayColor[][] _pixelMap;

    public Canvas(int height, int width)
    {
        Height = height;
        Width = width;

        _pixelMap = new RayColor[height][];
        for (var i = 0; i < height; i++)
        {
            var line = new RayColor[width];
            for (var j = 0; j < width; j++) line[j] = new RayColor(0, 0, 0);
            _pixelMap[i] = line;
        }
    }

    public int Height { get; }
    public int Width { get; }

    public RayColor[] this[int i] => _pixelMap[i];

    public IEnumerable<RayColor> PixelStream
    {
        get
        {
            return _pixelMap.SelectMany(line =>
                line.Select(pixel => pixel)
            );
        }
    }

    public void Write(int row, int col, RayColor color)
    {
        _pixelMap[row][col] = color;
    }
}