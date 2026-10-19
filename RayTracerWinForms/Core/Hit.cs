namespace RayTracerWinForms.Core;

/// <summary>
/// Resultado de uma interseção raio-objeto.
/// </summary>
public struct Hit
{
    public double T;
    public Vec3 Point;
    public Vec3 Normal;
    public Material Material;

    public Hit(double t, Vec3 point, Vec3 normal, Material material)
    {
        T = t;
        Point = point;
        Normal = normal;
        Material = material;
    }
}