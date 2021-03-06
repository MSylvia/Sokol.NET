// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// ReSharper disable UnusedMember.Global

namespace Sokol.Graphics
{
    // ReSharper disable once CommentTypo
    /// <summary>
    ///     Defines the types of 3D topology primitives which are used by a <see cref="Pipeline" /> to fetch vertex data
    ///     from a vertex <see cref="Buffer" /> for rasterization.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         When choosing which <see cref="PipelineVertexPrimitiveType" /> to use, consider the memory size of each
    ///         vertex, whether indexing is used or not (see <see cref="PipelineVertexIndexType" />), and the
    ///         resulting bandwidth used to send the data to the GPU. <see cref="LineStrip" /> and
    ///         <see cref="TriangleStrip" /> are more efficient in terms of memory usage but often are just as fast and
    ///         sometimes even slower than <see cref="Lines" /> and <see cref="Triangles" /> when indexing is used. This
    ///         is because modern GPUs have pre and post vertex caches for indexed vertex data.
    ///     </para>
    ///     <para>
    ///         <see cref="PipelineVertexPrimitiveType" /> is blittable to the C `sg_primitivetype` enum found in
    ///         `sokol_gfx`.
    ///     </para>
    /// </remarks>
    public enum PipelineVertexPrimitiveType
    {
        /// <summary>
        ///     This value is reserved for the default initialization of structures. The default
        ///     <see cref="PipelineVertexPrimitiveType" /> is <see cref="Triangles" />.
        /// </summary>
        Default,

        /// <summary>
        ///     Rasterize a point at each vertex.
        /// </summary>
        Points,

        /// <summary>
        ///     Rasterize a line between each separate pair of vertices. If there are an odd number of vertices,
        ///     the last vertex is ignored. The result is a series of unconnected lines. However, two or more lines
        ///     can appear connected if they share a vertex which is close enough together.
        /// </summary>
        Lines,

        /// <summary>
        ///     Rasterize a line between each pair of adjacent vertices. The result is a series of connected lines also
        ///     known as a polyline.
        /// </summary>
        LineStrip,

        /// <summary>
        ///     Rasterize a triangle between each separate pair of vertices. If the number of vertices is not a multiple
        ///     of three, either one or two vertices is ignored. The result is a series of unconnected triangles.
        ///     However, two or more triangles can appear connected if they share at least two vertices which are close
        ///     enough together.
        /// </summary>
        Triangles,

        /// <summary>
        ///     Rasterize a triangle for every three adjacent vertices. The result is a series of connected triangles
        ///     also known as a polygon.
        /// </summary>
        TriangleStrip
    }
}
