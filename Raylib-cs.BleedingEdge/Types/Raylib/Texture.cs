using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Texture, tex data stored in GPU memory (VRAM)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Texture
{
    /// <summary>
    /// OpenGL texture id
    /// </summary>
    public uint Id;

    /// <summary>
    /// Texture base width
    /// </summary>
    public int Width;

    /// <summary>
    /// Texture base height
    /// </summary>
    public int Height;

    /// <summary>
    /// Mipmap levels, 1 by default
    /// </summary>
    public int Mipmaps;

    /// <summary>
    /// Data format
    /// </summary>
    public PixelFormat Format;
}