using System;

namespace RayTracerWinForms.Core;

/// <summary>
/// Triângulo com interseção via Möller–Trumbore.
/// Normal "flat" (geométrica) pré-calculada.
/// </summary>
public class Triangle : Shape
{
    public Vec3 V0 { get; }
    public Vec3 V1 { get; }
    public Vec3 V2 { get; }

    private readonly Vec3 _e1;
    private readonly Vec3 _e2;
    private readonly Vec3 _normal;

    public Triangle(Vec3 v0, Vec3 v1, Vec3 v2, Material material)
    {
        V0 = v0;
        V1 = v1;
        V2 = v2;
        Material = material;

        _e1 = V1 - V0;
        _e2 = V2 - V0;
        _normal = _e1.Cross(_e2).Normalize();
    }

    public override Hit? Intersect(Ray ray, double tMin, double tMax)
    {
        const double EPS = 1e-8;

        Vec3 T = ray.Origin - V0;
        Vec3 P = ray.Direction.Cross(_e2);
        double det = _e1.Dot(P);

        // Raio paralelo ao plano do triângulo
        if (Math.Abs(det) < EPS) return null;

        double invDet = 1.0 / det;

        // Coordenada baricêntrica u
        double u = T.Dot(P) * invDet;
        if (u < 0 || u > 1) return null;

        // Coordenada baricêntrica v
        Vec3 Q = T.Cross(_e1);
        double v = ray.Direction.Dot(Q) * invDet;
        if (v < 0 || u + v > 1) return null;

        // Distância t
        double t = _e2.Dot(Q) * invDet;
        if (t < tMin || t > tMax) return null;

        Vec3 p = ray.At(t);

        // Normal sempre contra o raio (double-sided)
        Vec3 n = _normal;
        if (n.Dot(ray.Direction) > 0) n = -n;

        return new Hit(t, p, n, Material);
    }
}