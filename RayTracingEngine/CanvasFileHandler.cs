using System.Text;
using RayColors;

namespace Drawspace;

public static class CanvasFileHandler
{
    public static string toPPM(Canvas canvas)
    {
        var builder = new StringBuilder();
        builder.Append("P3\n")
            .Append($"{canvas.Width} {canvas.Height}\n")
            .Append("255\n");
        for (var row = 0; row < canvas.Height; row++)
        {
            var pixels = new List<string>();
            for (var col = 0; col < canvas.Width; col++) pixels.Add(GetBitString(canvas[row, col]));
            builder.Append(string.Join(" ", pixels));
            builder.Append('\n');
        }

        return builder.ToString();
    }

    private static string GetBitString(RayColor color)
    {
        var red = Convert.ToUInt16(Math.Clamp(color.Red, 0, 1) * 255);
        var green = Convert.ToUInt16(Math.Clamp(color.Green, 0, 1) * 255);
        var blue = Convert.ToUInt16(Math.Clamp(color.Blue, 0, 1) * 255);
        return $"{red} {green} {blue}";
    }

    public static void WriteToFile(Canvas canvas, string filename)
    {
        var contents = toPPM(canvas);
        using var file = new StreamWriter(filename);
        file.Write(contents);
    }
}