using UnityEngine;

namespace Views
{
    public class ConveyorBelt : MonoBehaviour
    {
        private float scrollSpeed = 0.1f;
        private MeshRenderer _renderer;
        private static readonly int _mainTex = Shader.PropertyToID("_MainTex");

        void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        void Update()
        {
            float offset = Time.time * scrollSpeed;
            _renderer.material.SetTextureOffset(_mainTex, new Vector2(offset, 0));
        }
    }
}