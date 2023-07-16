using DG.Tweening;
using UnityEngine;

namespace Views
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraController _camera;

        public void Move(Vector3 position, Vector3 rotation)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(_camera.transform.DOMove(position, 1.0f));
            sequence.Join(_camera.transform.DORotate(rotation, 1.0f));

            sequence.Play();
        }
    }
}