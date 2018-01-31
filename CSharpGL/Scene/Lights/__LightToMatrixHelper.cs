﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static class __LightToMatrixHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="light"></param>
        /// <returns></returns>
        public static mat4 GetProjectionMatrix(this LightBase light)
        {
            if (light is PointLight)
            {
                return GetProjectionMatrix(light as PointLight);
            }
            else if (light is DirectionalLight)
            {
                return GetProjectionMatrix(light as DirectionalLight);
            }
            else if (light is SpotLight)
            {
                return GetProjectionMatrix(light as SpotLight);
            }
            else
            {
                throw new System.Exception(string.Format("Not expected light type:[{0}].", light.GetType()));
            }
        }

        private static mat4 GetProjectionMatrix(this PointLight light)
        {

            throw new NotImplementedException();
        }

        private static mat4 GetProjectionMatrix(this DirectionalLight light)
        {
            // TODO: try this one.
            //var viewport = new int[4];
            //GL.Instance.GetIntegerv(GL.GL_VIEWPORT, viewport);
            //int width = viewport[2], height = viewport[3];
            //mat4 projection = glm.ortho(-width / 2.0f, width / 2.0f, -height / 2.0f, height / 2.0f);
            const int length = 10;
            mat4 projection = glm.ortho(-length, length, -length, length, -length, 0);//length * length);
            return projection;
        }

        private static mat4 GetProjectionMatrix(this SpotLight light)
        {
            var angle = Math.Acos(light.CutOff) * 2; // in radians
            const float aspectRatio = 1.0f;

            // TODO: how to get a precise projection?
            mat4 projection = glm.perspective((float)angle, aspectRatio, 0.1f, 500);

            return projection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="light"></param>
        /// <returns></returns>
        public static mat4 GetViewMatrix(this LightBase light)
        {
            if (light is PointLight)
            {
                return GetViewMatrix(light as PointLight);
            }
            else if (light is DirectionalLight)
            {
                return GetViewMatrix(light as DirectionalLight);
            }
            else if (light is SpotLight)
            {
                return GetViewMatrix(light as SpotLight);
            }
            else
            {
                throw new System.Exception(string.Format("Not expected light type:[{0}].", light.GetType()));
            }
        }

        private static mat4 GetViewMatrix(this PointLight light)
        {

            throw new NotImplementedException();
        }

        private static mat4 GetViewMatrix(this DirectionalLight light)
        {
            // TODO: try this one.
            vec3 up = new vec3(0, 1, 0);
            mat4 view = glm.lookAt(new vec3(), -(light.Direction.normalize()), up);
            return view;
        }

        private static mat4 GetViewMatrix(this SpotLight light)
        {
            vec3 direction = (light.Position - light.Target).normalize();
            vec3 up = new vec3(0, 1, 0);
            vec3 diff = direction - up;
            if (diff.length() < 0.01f) { up = new vec3(1, 1, 1); }

            mat4 view = glm.lookAt(light.Position, light.Target, up);

            return view;
        }

    }
}