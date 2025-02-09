using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// RenderTexture, fbo for texture rendering
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct RenderTexture
{
    /// <summary>
    /// OpenGL framebuffer object id
    /// </summary>
    public uint Id;

    /// <summary>
    /// Color buffer attachment texture
    /// </summary>
    public Texture Texture;

    /// <summary>
    /// Depth buffer attachment texture
    /// </summary>
    public Texture Depth;
}