using DG.Tweening;
using UnityEngine;

namespace Rope.UI
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        private RectTransform Transform => (RectTransform)transform;
        
        public virtual void Show()
        {
            var startPos = Transform.anchoredPosition;
            _canvasGroup.alpha = 0f;
            Transform.anchoredPosition += Vector2.up * 250f;

            gameObject.SetActive(true);
            DOTween.Sequence()
                .Join(Transform.DOAnchorPos(startPos, 1.5f).SetEase(Ease.OutSine))
                .Join(_canvasGroup.DOFade(1f, 1.5f).SetEase(Ease.OutSine));
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}