// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// ReSharper disable UnusedMember.Global

namespace Sokol.Graphics
{
    /// <summary>
    ///     Defines the types of data a <see cref="Buffer" /> can contain.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <see cref="BufferType" /> is blittable to the C `sg_buffer_type` enum found in `sokol_gfx`.
    ///     </para>
    /// </remarks>
    public enum BufferType
    {
        /// <summary>
        ///     This value is reserved for the default initialization of structures. The default
        ///     <see cref="BufferType" /> is <see cref="VertexBuffer" />.
        /// </summary>
        Default = 0,

        /// <summary>
        ///     The <see cref="Buffer" /> contains vertex data.
        /// </summary>
        VertexBuffer = 1,

        /// <summary>
        ///     The <see cref="Buffer" /> contains index data.
        /// </summary>
        IndexBuffer = 2
    }
}
