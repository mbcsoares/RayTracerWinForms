using System;

namespace RayTracerWinForms.Core;

/// <summary>
/// Esfera: |P - C|² = r².
/// Interseção resolvida por equação quadrática na forma "half-b".
/// </summary>
public class Sphere : Shape
{
    public Vec3 Center { get; set; }
    public double Radius { get; set; }

    public Sphere(Vec3 center, double radius, Material material)
    {
        Center = center;
        Radius = radius;
        Material = material;
    }

    public override Hit? Intersect(Ray ray, double tMin, double tMax)
    {
        // oc = O - C
        Vec3 oc = ray.Origin - Center;

        // Equação: t² + 2b·t + c = 0, com b = oc·D, c = oc·oc - r²
        double b = oc.Dot(ray.Direction);
        double c = oc.Dot(oc) - Radius * Radius;

        // Discriminante da forma half-b: Δ' = b² - c
        double disc = b * b - c;
        if (disc < 0) return null;

        double sqrtD = Math.Sqrt(disc);
        double t1 = -b - sqrtD;
        double t2 = -b + sqrtD;

        // Escolha da menor raiz positiva dentro de (tMin, tMax)
        double t = t1;
        if (t < tMin) t = t2;
        if (t < tMin || t > tMax) return null;

        Vec3 p = ray.At(t);
        Vec3 n = (p - Center).Normalize();

        return new Hit(t, p, n, Material);
    }
}