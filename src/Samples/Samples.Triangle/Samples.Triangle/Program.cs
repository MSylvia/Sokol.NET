﻿// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Sokol.App;

namespace Samples.Triangle
{
    internal static class Program
    {
        private static void Main()
        {
            var descriptor = default(AppDescriptor);
            descriptor.WindowTitle = "Triangle";
            var app = new TriangleApplication(descriptor);
            app.Run();
        }
    }
}
