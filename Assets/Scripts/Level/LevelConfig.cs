using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public Vector3 playerSpawnPosition;
        public Vector3 conveyorSpawnPosition;
        public Vector3 foodSpawnPosition;
        public Vector3 cameraVictoryPosition;
        public Vector3 cameraVictoryRotation;
        public float foodDespawnDistance;
        public float foodSpeed;
        public float foodSpawnDistance;
        public int maxTaskCount;
        public List<Sprite> foodSprites;
    }
}