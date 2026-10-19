namespace RayTracerWinForms.Core;

/// <summary>
/// Propriedades do material para o Modelo de Phong.
/// Ka, Kd, Ks em [0,1]; Shininess >= 1; Reflectivity em [0,1].
/// </summary>
public class Material
{
    public Vec3 Color { get; set; } = new(0.8, 0.8, 0.8);

    public double Ka { get; set; } = 0.1;   // ambiente
    public double Kd { get; set; } = 0.7;   // difuso
    public double Ks { get; set; } = 0.5;   // especular
    public double Shininess { get; set; } = 50;  // expoente n

    public double Reflectivity { get; set; } = 0.0;  // 0 = opaco, 1 = espelho
}