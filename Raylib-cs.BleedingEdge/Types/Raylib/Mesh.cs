using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Mesh, vertex data and vao/vbo
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Mesh(int vertexCount, int triangleCount)
{
    /// <summary>
    /// Default <see cref="VboID"/> index for <see cref="Vertices"/>
    /// </summary>
    public const int VertexBufferPositions = 0;
    
    /// <summary>
    /// Default <see cref="VboID"/> index for <see cref="TexCoords"/>
    /// </summary>
    public const int VertexBufferTexCoords = 1;
    
    /// <summary>
    /// Default <see cref="VboID"/> index for <see cref="Normals"/>
    /// </summary>
    public const int VertexBufferNormals = 2;
    
    /// <summary>
    /// Default <see cref="VboID"/> index for <see cref="Colors"/>
    /// </summary>
    public const int VertexBufferColors = 3;
    
    /// <summary>
    /// Default <see cref="VboID"/> index for <see cref="Tangents"/>
    /// </summary>
    public const int VertexBufferTangents = 4;
    
    /// <summary>
    /// Default <see cref="VboID"/> index for <see cref="TexCoords2"/>
    /// </summary>
    public const int VertexBufferTexCoords2 = 5;
    
    /// <summary>
    /// Default <see cref="VboID"/> index for <see cref="Indices"/>
    /// </summary>
    public const int VertexBufferIndices = 6;
    
    /// <summary>
    /// Number of vertices stored in arrays
    /// </summary>
    public int VertexCount = vertexCount;

    /// <summary>
    /// Number of triangles stored (indexed or not)
    /// </summary>
    public int TriangleCount = triangleCount;

    /// <summary>
    /// Vertex position (XYZ - 3 components per vertex) (shader-location = 0)
    /// </summary>
    public float* Vertices;

    /// <summary>
    /// Vertex texture coordinates (UV - 2 components per vertex) (shader-location = 1)
    /// </summary>
    public float* TexCoords;

    /// <summary>
    /// Vertex texture second coordinates (UV - 2 components per vertex) (shader-location = 5)
    /// </summary>
    public float* TexCoords2;

    /// <summary>
    /// Vertex normals (XYZ - 3 components per vertex) (shader-location = 2)
    /// </summary>
    public float* Normals;

    /// <summary>
    /// Vertex tangents (XYZW - 4 components per vertex) (shader-location = 4)
    /// </summary>
    public float* Tangents;

    /// <summary>
    /// Vertex colors (RGBA - 4 components per vertex) (shader-location = 3)
    /// </summary>
    public byte* Colors;

    /// <summary>
    /// Vertex indices (in case vertex data comes indexed)
    /// </summary>
    public ushort* Indices;

    /// <summary>
    /// Animated vertex positions (after bones transformations)
    /// </summary>
    public float* AnimVertices;

    /// <summary>
    /// Animated normals (after bones transformations)
    /// </summary>
    public float* AnimNormals;

    /// <summary>
    /// Vertex bone ids, max 255 bone ids, up to 4 bones influence by vertex (skinning)
    /// </summary>
    public byte* BoneIDs;

    /// <summary>
    /// Vertex bone weight, up to 4 bones influence by vertex (skinning)
    /// </summary>
    public float* BoneWeights;

    /// <summary>
    /// OpenGL Vertex Array Object id
    /// </summary>
    public uint VaoID;

    /// <summary>
    /// OpenGL Vertex Buffer Objects id (default vertex data)
    /// </summary>
    public uint* VboID;

    /// <summary>
    /// Allocates <see cref="Vertices"/>
    /// </summary>
    public void AllocVertices()
    {
        Vertices = BleedingEdge.Raylib.MemAlloc<float>((uint)(3 * VertexCount));
    }

    /// <summary>
    /// Get <see cref="Vertices"/> as <see cref="Span{T}"/> with specified type
    /// </summary>
    public Span<T> VerticesAs<T>()
        where T : unmanaged
    {
        return new Span<T>(Vertices, 3 * VertexCount * sizeof(float) / sizeof(T));
    }
    
    /// <summary>
    /// Allocates <see cref="TexCoords"/>
    /// </summary>
    public void AllocTexCoords()
    {
        TexCoords = BleedingEdge.Raylib.MemAlloc<float>((uint)(2 * VertexCount));
    }

    /// <summary>
    /// Get <see cref="TexCoords"/> as <see cref="Span{T}"/> with specified type
    /// </summary>
    public Span<T> TexCoordsAs<T>()
        where T : unmanaged
    {
        return new Span<T>(TexCoords, 2 * VertexCount * sizeof(float) / sizeof(T));
    }
    
    /// <summary>
    /// Allocate <see cref="TexCoords2"/>
    /// </summary>
    public void AllocTexCoords2()
    {
        TexCoords2 = BleedingEdge.Raylib.MemAlloc<float>((uint)(2 * VertexCount));
    }

    /// <summary>
    /// Get <see cref="TexCoords2"/> as <see cref="Span{T}"/> with specified type
    /// </summary>
    public Span<T> TexCoordsAs2<T>()
        where T : unmanaged
    {
        return new Span<T>(TexCoords2, 2 * VertexCount * sizeof(float) / sizeof(T));
    }
    
    /// <summary>
    /// Allocate <see cref="Normals"/>
    /// </summary>
    public void AllocNormals()
    {
        Normals = BleedingEdge.Raylib.MemAlloc<float>((uint)(3 * VertexCount));
    }

    /// <summary>
    /// Get <see cref="Normals"/> as <see cref="Span{T}"/> with specified type
    /// </summary>
    public Span<T> NormalsAs<T>()
        where T : unmanaged
    {
        return new Span<T>(Normals, 3 * VertexCount * sizeof(float) / sizeof(T));
    }
    
    /// <summary>
    /// Allocate <see cref="Tangents"/>
    /// </summary>
    public void AllocTangents()
    {
        Tangents = BleedingEdge.Raylib.MemAlloc<float>((uint)(4 * VertexCount));
    }

    /// <summary>
    /// Get <see cref="Tangents"/> as <see cref="Span{T}"/> with specified type
    /// </summary>
    public Span<T> TangentsAs<T>()
        where T : unmanaged
    {
        return new Span<T>(Tangents, 4 * VertexCount * sizeof(float) / sizeof(T));
    }
    
    /// <summary>
    /// Allocate <see cref="Colors"/>
    /// </summary>
    public void AllocColors()
    {
        Colors = BleedingEdge.Raylib.MemAlloc<byte>((uint)(4 * VertexCount));
    }
    
    /// <summary>
    /// Get <see cref="Colors"/> as <see cref="Span{T}"/> with specified type
    /// </summary>
    public Span<T> ColorsAs<T>()
        where T : unmanaged
    {
        return new Span<T>(TexCoords, 4 * VertexCount * sizeof(byte) / sizeof(T));
    }
    
    /// <summary>
    /// Allocate <see cref="Indices"/>
    /// </summary>
    public void AllocIndices()
    {
        Indices = BleedingEdge.Raylib.MemAlloc<ushort>((uint)(3 * TriangleCount));
    }
    
    /// <summary>
    /// Get <see cref="Indices"/> as <see cref="Span{T}"/> with specified type
    /// </summary>
    public Span<T> IndicesAs<T>()
        where T : unmanaged
    {
        return new Span<T>(Indices, 3 * TriangleCount * sizeof(ushort) / sizeof(T));
    }
}