using System;
using System.Threading.Tasks;

namespace RayTracerWinForms.Core;

/// <summary>
/// Loop de renderização paralelo.
/// Retorna buffer de cores [altura, largura].
/// </summary>
public class Renderer
{
    public Scene Scene { get; set; } = new();
    public Camera Camera { get; set; } = null!;

    private const double EPS = 1e-4;
    private const int MaxDepth = 5;

    public Vec3[,] Render(int samplesPerPixel = 1)
    {
        int w = Camera.Width;
        int h = Camera.Height;
        var buffer = new Vec3[h, w];
        var rnd = new Random(42);

        Parallel.For(0, h, j =>
        {
            for (int i = 0; i < w; i++)
            {
                Vec3 accum = Vec3.Zero;
                for (int s = 0; s < samplesPerPixel; s++)
                {
                    double jx = samplesPerPixel == 1 ? 0.5 : rnd.NextDouble();
                    double jy = samplesPerPixel == 1 ? 0.5 : rnd.NextDouble();

                    Ray ray = Camera.GetRay(i, j, jx, jy);
                    accum += Trace(ray, 0);
                }
                buffer[j, i] = accum / samplesPerPixel;
            }
        });

        return buffer;
    }

    private Vec3 Trace(Ray ray, int depth)
    {
        var hit = Scene.Trace(ray, EPS, double.PositiveInfinity);
        if (!hit.HasValue)
            return new Vec3(0.02, 0.02, 0.05);  // fundo escuro

        Vec3 viewDir = (-ray.Direction).Normalize();
        Vec3 color = Shader.ShadePhong(hit.Value, viewDir, Scene);

        // Reflexão recursiva (opcional)
        Material m = hit.Value.Material;
        if (m.Reflectivity > 0 && depth < MaxDepth)
        {
            Vec3 N = hit.Value.Normal;
            Vec3 R = (ray.Direction - N * (2.0 * ray.Direction.Dot(N))).Normalize();
            Ray refl = new(hit.Value.Point + N * EPS, R);

            Vec3 reflColor = Trace(refl, depth + 1);
            color += reflColor * m.Reflectivity;
        }

        // Clamp para [0,1]
        return new Vec3(
            Math.Clamp(color.X, 0.0, 1.0),
            Math.Clamp(color.Y, 0.0, 1.0),
            Math.Clamp(color.Z, 0.0, 1.0));
    }
}