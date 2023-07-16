using UnityEngine;

namespace UI
{
    public class ScoreSpawner : MonoBehaviour
    {
        [SerializeField] private PlusScore _plusScorePrefab;
        
        public static ScoreSpawner Instance { get; private set; }
        
        private void Awake()
        {
            Instance = this;
        }
        
        public void SpawnScore()
        {
            var plusScore = Instantiate(_plusScorePrefab, transform);
            plusScore.Move();
        }
    }
}