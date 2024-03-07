using DG.Tweening;
using UnityEngine;

namespace Rope.Services.Collectables
{
    public class StarAnimation : MonoBehaviour
    {
        [SerializeField] private Collectable _collectable;

        private void OnEnable()
        {
            _collectable.Collected += OnCollected;
        }

        private void OnDisable()
        {
            _collectable.Collected -= OnCollected;
        }

        private void OnCollected()
        {
            DOTween.Sequence()
                .Join(transform.DOMoveY(0.25f, 1f).SetRelative(true).SetEase(Ease.OutSine))
                .Join(transform.DORotate(Vector3.up * 360f * 5f, 1f).SetRelative(true).SetEase(Ease.OutSine))
                .Append(transform.DOScale(Vector3.one * 1.25f, 0.25f).SetEase(Ease.InBack))
                .Append(transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InSine).SetDelay(0.2f))
                .OnComplete(() => Destroy(gameObject));
        }
    }
}