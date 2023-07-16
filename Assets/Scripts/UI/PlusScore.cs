using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class PlusScore : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        public void Move()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOMove(Vector3.up, 1.5f));
            sequence.Join(_canvasGroup.DOFade(0.0f, 1.5f));
            sequence.OnComplete(() => Destroy(gameObject));

            sequence.Play();
        }
    }
}