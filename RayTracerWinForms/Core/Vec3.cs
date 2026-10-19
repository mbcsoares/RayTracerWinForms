using System;

namespace RayTracerWinForms.Core;

/// <summary>
/// Vetor 3D com operações de álgebra vetorial.
/// Usado como ponto, direção, cor (RGB) e normal.
/// </summary>
public struct Vec3
{
    public double X, Y, Z;

    public Vec3(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    // ---------- Operadores ----------
    public static Vec3 operator +(Vec3 a, Vec3 b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    public static Vec3 operator -(Vec3 a, Vec3 b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    public static Vec3 operator -(Vec3 a) => new(-a.X, -a.Y, -a.Z);
    public static Vec3 operator *(Vec3 a, double s) => new(a.X * s, a.Y * s, a.Z * s);
    public static Vec3 operator *(double s, Vec3 a) => a * s;
    public static Vec3 operator /(Vec3 a, double s) => new(a.X / s, a.Y / s, a.Z / s);

    /// <summary>Produto componente a componente (usado para cores).</summary>
    public static Vec3 operator *(Vec3 a, Vec3 b) => new(a.X * b.X, a.Y * b.Y, a.Z * b.Z);

    // ---------- Produtos e comprimento ----------
    public double Dot(Vec3 b) => X * b.X + Y * b.Y + Z * b.Z;

    public Vec3 Cross(Vec3 b) => new(
        Y * b.Z - Z * b.Y,
        Z * b.X - X * b.Z,
        X * b.Y - Y * b.X);

    public double LengthSq => X * X + Y * Y + Z * Z;
    public double Length => Math.Sqrt(LengthSq);
    public Vec3 Normalize() => this / Length;

    // ---------- Constantes úteis ----------
    public static Vec3 Zero => new(0, 0, 0);
    public static Vec3 One => new(1, 1, 1);

    public override string ToString() => $"({X:F3}, {Y:F3}, {Z:F3})";
}