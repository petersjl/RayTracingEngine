// See https://aka.ms/new-console-template for more information

using Drawspace;
using RayColors;
using RayTuples;

namespace RayTracingEngine;

internal class App
{
    private static void Main(string[] args)
    {
        var c = new Canvas(30, 40);

        var p = new Projectile(new RayPoint(0, 0, 0), new RayVector(1, 1, 0).Normalize().toVector());
        var e = new Environment(new RayVector(0, -0.1, 0), new RayVector(-0.01, 0, 0));
        var red = new RayColor(1, 0, 0);

        while (p.Position.X >= 0 && p.Position.X < 40 && p.Position.Y >= 0 && p.Position.Y < 30)
        {
            c.Write(29 - (int)Math.Floor(p.Position.Y), (int)Math.Floor(p.Position.X), red);
            p = Tick(p, e);
        }

        CanvasFileHandler.WriteToFile(c, "./output.ppm");
    }

    private static Projectile Tick(Projectile p, Environment e)
    {
        var pos = p.Position + p.Velocity;
        var vel = p.Velocity + e.Gravity + e.Wind;
        return new Projectile(pos.toPoint(), vel.toVector());
    }

    private class Projectile(RayPoint position, RayVector velocity)
    {
        public RayPoint Position { get; } = position;
        public RayVector Velocity { get; } = velocity;
    }

    private class Environment(RayVector gravity, RayVector wind)
    {
        public RayVector Gravity { get; } = gravity;
        public RayVector Wind { get; } = wind;
    }
}