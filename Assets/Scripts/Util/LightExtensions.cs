using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine.Rendering.Universal;

namespace Rope.Util
{
    public static class LightExtensions
    {
        public static TweenerCore<float, float, FloatOptions> DOIntensity(
            this Light2D target,
            float endValue,
            float duration)
        {
            var t = DOTween.To(() => target.intensity, x => target.intensity = x, endValue, duration);
            t.SetTarget(target);
            return t;
        }
    }
}