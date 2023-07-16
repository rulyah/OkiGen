using UnityEngine;

namespace Views
{
    public class ConveyorCylinder : MonoBehaviour
    {
        private float _rotationSpeed = 50f;

        void Update()
        {
            transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
        }
    }
}