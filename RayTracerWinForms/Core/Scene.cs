using System.Collections.Generic;

namespace RayTracerWinForms.Core;

/// <summary>
/// Cena: coleção de objetos + luzes + luz ambiente global.
/// </summary>
public class Scene
{
    public List<Shape> Shapes { get; } = new();
    public List<Light> Lights { get; } = new();
    public Vec3 Ambient { get; set; } = new(0.05, 0.05, 0.05);

    /// <summary>
    /// Retorna o hit mais próximo ao longo do raio, dentro de (tMin, tMax).
    /// </summary>
    public Hit? Trace(Ray ray, double tMin, double tMax)
    {
        Hit? closest = null;
        double closestT = tMax;

        foreach (var shape in Shapes)
        {
            var h = shape.Intersect(ray, tMin, closestT);
            if (h.HasValue && h.Value.T < closestT)
            {
                closest = h;
                closestT = h.Value.T;
            }
        }
        return closest;
    }

    /// <summary>
    /// Testa se o ponto está na sombra em relação à posição da luz.
    /// </summary>
    public bool InShadow(Vec3 point, Vec3 lightPos, double eps = 1e-3)
    {
        Vec3 dir = lightPos - point;
        double dist = dir.Length;
        if (dist < eps) return false;

        Vec3 dirNorm = dir / dist;
        Ray shadowRay = new(point + dirNorm * eps, dirNorm);

        // Se algo for atingido antes da luz, está na sombra
        var h = Trace(shadowRay, eps, dist - eps);
        return h.HasValue;
    }
}