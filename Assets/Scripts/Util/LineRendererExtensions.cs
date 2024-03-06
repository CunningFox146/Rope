using UnityEngine;

namespace Rope.Util
{
    public static class LineRendererExtensions
    {
        public static void Reset(this LineRenderer lineRenderer)
        {
            lineRenderer.positionCount = 0;
        }
    }
}