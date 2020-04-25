// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Sokol.Graphics
{
    /// <summary>
    ///     Describes specific configuration of how a source color generated by a <see cref="Shader" />
    ///     (called a fragment) is blended with and written to it's mapped destination (either the frame buffer or a
    ///     render target <see cref="Image" />).
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <see cref="ColorFormat" /> property must be specified. This property is used to specify what
    ///         <see cref="PixelFormat" /> is written to the color attachments belonging to the active
    ///         <see cref="Pass" /> when blending is performed.
    ///     </para>
    ///     <para>
    ///         Blend operations determine how a source fragment is combined with a destination value in a
    ///         color attachment to determine the pixel value to be written. The following properties define whether
    ///         and how blending is performed:
    ///          <list type="bullet">
    ///             <item>
    ///                 <description>
    ///                     The <see cref="IsEnabled" /> property enables color blending. Default is <c>false</c>.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <description>
    ///                     The <see cref="ColorWriteMask" /> property identifies which color components are blended.
    ///                     The default value is <see cref="PipelineBlendColorMask.Rgba" />, which allows all color
    ///                     components to be blended.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <description>
    ///                     The <see cref="SourceFactorRgb" />, <see cref="SourceFactorAlpha" />,
    ///                     <see cref="DestinationFactorRgb" />, and <see cref="DestinationFactorAlpha" /> properties
    ///                     assign the source and destination blend factors. The default value for
    ///                     <see cref="SourceFactorRgb" /> and <see cref="SourceFactorAlpha" /> is
    ///                     <see cref="PipelineBlendFactor.One" />. The default value for
    ///                     <see cref="DestinationFactorRgb" /> and <see cref="DestinationFactorAlpha" /> is
    ///                     <see cref="PipelineBlendFactor.Zero" />.
    ///                 </description>
    ///             </item>
    ///         </list>
    ///     </para>
    ///     <para>
    ///         <see cref="PipelineBlendState" /> is blittable to the C `sg_blend_state` struct found in `sokol_gfx`.
    ///     </para>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = 60, Pack = 4)]
    public struct PipelineBlendState
    {
        /// <summary>
        ///     A <see cref="bool" /> value indicating whether blending is enabled. Default is <c>false</c>.
        /// </summary>
        [FieldOffset(0)]
        public BlittableBoolean IsEnabled;

        /// <summary>
        ///     The <see cref="PipelineBlendFactor" /> used with the source color to calculate the red, green, blue
        ///     components of the blended output color.
        /// </summary>
        [FieldOffset(4)]
        public PipelineBlendFactor SourceFactorRgb;

        /// <summary>
        ///     The <see cref="PipelineBlendFactor" /> used with the destination color to calculate the red, green,
        ///     blue components of the blended output color.
        /// </summary>
        [FieldOffset(8)]
        public PipelineBlendFactor DestinationFactorRgb;

        /// <summary>
        ///     The <see cref="PipelineBlendOperation" /> used to calculate the red, green, blue
        ///     components of the blended output color.
        /// </summary>
        [FieldOffset(12)]
        public PipelineBlendOperation OperationRgb;

        /// <summary>
        ///     The <see cref="PipelineBlendFactor" /> used with the source color to calculate the alpha component of
        ///     the blended output color.
        /// </summary>
        [FieldOffset(16)]
        public PipelineBlendFactor SourceFactorAlpha;

        /// <summary>
        ///     The <see cref="PipelineBlendFactor" /> used with the destination color to calculate the alpha component
        ///     of the blended output color.
        /// </summary>
        [FieldOffset(20)]
        public PipelineBlendFactor DestinationFactorAlpha;

        /// <summary>
        ///     The <see cref="PipelineBlendOperation" /> used to calculate the alpha component of the blended output
        ///     color.
        /// </summary>
        [FieldOffset(24)]
        public PipelineBlendOperation OperationAlpha;

        /// <summary>
        ///     The <see cref="PipelineBlendColorMask" />.
        /// </summary>
        [FieldOffset(28)]
        public PipelineBlendColorMask ColorWriteMask;

        /// <summary>
        ///     The number of color attachments.
        /// </summary>
        [FieldOffset(32)]
        public int ColorAttachmentCount;

        /// <summary>
        ///     The color <see cref="PixelFormat" /> of the color attachments. Must be specified.
        /// </summary>
        [FieldOffset(36)]
        public PixelFormat ColorFormat;

        /// <summary>
        ///     The depth <see cref="PixelFormat" /> of the depth attachment.
        /// </summary>
        [FieldOffset(40)]
        public PixelFormat DepthFormat;

        /// <summary>
        ///     The color used with <see cref="PipelineBlendFactor.BlendColor" />,
        ///     <see cref="PipelineBlendFactor.OneMinusBlendColor" />, <see cref="PipelineBlendFactor.BlendAlpha" />,
        ///     and <see cref="PipelineBlendFactor.OneMinusBlendAlpha" />.
        /// </summary>
        [FieldOffset(44)]
        public Rgba32F BlendColor;
    }
}
