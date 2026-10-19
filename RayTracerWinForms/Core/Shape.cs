namespace RayTracerWinForms.Core;

/// <summary>
/// Classe base para todas as primitivas geométricas.
/// </summary>
public abstract class Shape
{
    public Material Material { get; set; } = new();

    /// <summary>
    /// Testa interseção com o raio no intervalo (tMin, tMax).
    /// Retorna null se não houver hit válido.
    /// </summary>
    public abstract Hit? Intersect(Ray ray, double tMin, double tMax);
}