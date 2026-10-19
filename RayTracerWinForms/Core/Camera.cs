using System;

namespace RayTracerWinForms.Core;

/// <summary>
/// Câmera pinhole com FOV ajustável e resolução configurável.
/// Gera raios primários a partir do plano de imagem.
/// </summary>
public class Camera
{
    public Vec3 Eye { get; }
    public Vec3 LookAt { get; }
    public Vec3 Up { get; }
    public double FovDegrees { get; }
    public int Width { get; }
    public int Height { get; }

    private Vec3 _right, _up, _forward;
    private double _halfW, _halfH;
    private readonly double _d = 1.0;  // distância do plano de imagem

    public Camera(Vec3 eye, Vec3 lookAt, Vec3 up, double fovDegrees, int width, int height)
    {
        Eye = eye;
        LookAt = lookAt;
        Up = up;
        FovDegrees = fovDegrees;
        Width = width;
        Height = height;
        BuildBasis();
    }

    private void BuildBasis()
    {
        // w = direção "para trás" (da cena para a câmera)
        _forward = (Eye - LookAt).Normalize();

        // u' = direita (up × w), normalizada
        _right = Up.Cross(_forward).Normalize();

        // v = cima (w × u')
        _up = _forward.Cross(_right);

        // Dimensões do plano de imagem
        double halfFovRad = FovDegrees * Math.PI / 360.0;
        _halfH = Math.Tan(halfFovRad) * _d;
        _halfW = _halfH * (double)Width / Height;
    }

    /// <summary>
    /// Gera o raio primário do pixel (i, j).
    /// jx, jy em [0,1) permitem jitter para anti-aliasing (0.5 = centro do pixel).
    /// </summary>
    public Ray GetRay(int i, int j, double jx = 0.5, double jy = 0.5)
    {
        // Coordenadas no plano de imagem, em [-halfW, halfW] × [-halfH, halfH]
        double sx = (2.0 * (i + jx) / Width - 1.0) * _halfW;
        double sy = (1.0 - 2.0 * (j + jy) / Height) * _halfH;

        // Direção no espaço do mundo
        Vec3 dir = (sx * _right + sy * _up - _d * _forward).Normalize();
        return new Ray(Eye, dir);
    }
}