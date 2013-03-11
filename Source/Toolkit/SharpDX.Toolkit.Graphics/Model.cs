﻿// Copyright (c) 2010-2012 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.IO;

namespace SharpDX.Toolkit.Graphics
{
    public delegate Texture ModelMaterialTextureLoaderDelegate(string name);

    public class Model : Component
    {
        public MaterialCollection Materials;

        public ModelBoneCollection Bones;

        //// DISABLE_SKINNED_BONES
        //public ModelBoneCollection SkinnedBones;

        public ModelMeshCollection Meshes;

        public PropertyCollection Properties;

        public virtual Model Clone()
        {
            var model = (Model)MemberwiseClone();
            throw new NotImplementedException();
        }

        public static Model Load(GraphicsDevice graphicsDevice, Stream stream, ModelMaterialTextureLoaderDelegate textureLoader)
        {
            using (var serializer = new ModelReader(graphicsDevice, stream, textureLoader))
            {
                return serializer.ReadModel();
            }
        }
    }
}