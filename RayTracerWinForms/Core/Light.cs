namespace RayTracerWinForms.Core;

/// <summary>
/// Fonte de luz pontual com intensidade RGB.
/// </summary>
public class Light
{
    public Vec3 Position { get; set; }
    public Vec3 Intensity { get; set; }

    public Light(Vec3 position, Vec3 intensity)
    {
        Position = position;
        Intensity = intensity;
    }
}