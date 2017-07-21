﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class TexImage2DMultisample : TexStorageBase
    {
        private uint samples;
        private uint internalFormat;
        private uint width;
        private uint height;
        private bool fixedSampleLocations;

        private static readonly GLDelegates.void_uint_uint_uint_uint_uint_bool glTexImage2DMultisample;
        static TexImage2DMultisample()
        {
            glTexImage2DMultisample = GL.Instance.GetDelegateFor("glTexImage2DMultisample", GLDelegates.typeof_void_uint_uint_uint_uint_uint_bool) as GLDelegates.void_uint_uint_uint_uint_uint_bool;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="internalFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fixedSampleLocations"></param>
        public TexImage2DMultisample(uint samples, uint internalFormat, uint width, uint height, bool fixedSampleLocations)
        {
            this.samples = samples;
            this.internalFormat = internalFormat;
            this.width = width;
            this.height = height;
            this.fixedSampleLocations = fixedSampleLocations;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            glTexImage2DMultisample(GL.GL_TEXTURE_2D_MULTISAMPLE, samples, internalFormat, width, height, fixedSampleLocations);
        }

    }
}