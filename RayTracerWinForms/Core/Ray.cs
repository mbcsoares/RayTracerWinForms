namespace RayTracerWinForms.Core;

/// <summary>
/// Raio paramétrico: P(t) = Origin + t * Direction.
/// Convenção: Direction SEMPRE normalizada (t é distância real).
/// </summary>
public struct Ray
{
    public Vec3 Origin;
    public Vec3 Direction;

    public Ray(Vec3 origin, Vec3 direction)
    {
        Origin = origin;
        Direction = direction;
    }

    public Vec3 At(double t) => Origin + Direction * t;

    public override string ToString() => $"O={Origin}, D={Direction}";
}