// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Sokol.App;
using Sokol.Graphics;
using Native = Sokol.App.Native;

namespace Samples.ArrayTex
{
    internal static class Program
    {
        /*private static void Main()
        {
            var descriptor = default(AppDescriptor);
            descriptor.WindowTitle = "Array Texture";
            var app = new ArrayTexApplication(descriptor);
            app.Run();
        }*/

        public static void Main(string[] args)
        {
            var backend = GraphicsBackend.Direct3D11;
            var width = 64;
            var height = 64;
            var layers = 2;

            Native.LoadApi(backend);

            App.CreateResources += () =>
            {
                Span<Rgba8U> data = stackalloc Rgba8U[width * height];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = default;
                }

                var imageDescriptor = new ImageDescriptor
                {
                    Type = ImageType.Texture2D,
                    Width = width,
                    Height = height,
                    Format = PixelFormat.RGBA8,
                    MinificationFilter = ImageFilter.Nearest,
                    MagnificationFilter = ImageFilter.Nearest,
                    Usage = ResourceUsage.Dynamic,
                };

                var image = GraphicsDevice.CreateImage(ref imageDescriptor);
                image.Update(data);
            };

            App.Run();
        }
    }
}
