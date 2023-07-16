using UnityEngine;
using Utils.FactoryTool;

namespace Views
{
    public class Food : PoolableMonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private SphereCollider _collider;
        
        public int id;
        private float _speed;

        public void SetSpeed( float speed)
        {
            _speed = speed;
        }
        
        public void IsUsePhysics(bool isOn)
        {
            _rigidbody.useGravity = isOn;
            _collider.enabled = isOn;
            _rigidbody.isKinematic = !isOn;
            
            if (!isOn)
            {
                _rigidbody.velocity = Vector3.zero;
            }
        }
        
        private void Update()
        {
            if(_speed <= 0.0f) return;
            transform.position += Vector3.right * (_speed * Time.deltaTime);
        }
    }
}