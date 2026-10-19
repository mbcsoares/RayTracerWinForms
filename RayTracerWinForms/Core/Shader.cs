using System;

namespace RayTracerWinForms.Core;

/// <summary>
/// Modelo de Refletância de Phong:
/// I = Ka·Ia + Σ_luz [ Kd·Il·max(0, N·L) + Ks·Il·max(0, R·V)^n ]
/// </summary>
public static class Shader
{
    public static Vec3 ShadePhong(Hit hit, Vec3 viewDir, Scene scene)
    {
        Material m = hit.Material;
        Vec3 N = hit.Normal;

        // Termo ambiente
        Vec3 color = m.Color * (m.Ka * scene.Ambient);

        foreach (var light in scene.Lights)
        {
            Vec3 L = (light.Position - hit.Point).Normalize();
            double ndotl = N.Dot(L);

            // Luz atrás da superfície — ignora
            if (ndotl <= 0) continue;

            // Sombra — ignora contribuição direta
            if (scene.InShadow(hit.Point, light.Position)) continue;

            // Componente difusa (Lambert)
            Vec3 diffuse = m.Color * (m.Kd * ndotl) * light.Intensity;

            // Componente especular (Phong)
            Vec3 R = (N * (2.0 * ndotl) - L).Normalize();
            double rdotv = R.Dot(viewDir);

            Vec3 specular = Vec3.Zero;
            if (rdotv > 0)
            {
                double factor = Math.Pow(rdotv, m.Shininess);
                specular = new Vec3(1, 1, 1) * (m.Ks * factor) * light.Intensity;
            }

            color += diffuse + specular;
        }

        return color;
    }
}