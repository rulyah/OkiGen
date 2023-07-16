using Level;
using UnityEngine;
using Utils.ProcessTool;

namespace Processes
{
    public class SpawnFoodProcess : Process
    {
        private Core _core;
        
        public SpawnFoodProcess(Core core) : base(core)
        {
            _core = core;
        }

        public void SpawnFood()
        {
            var randomFoodId = Random.Range(0, _core.factory.foods.Count);
            var food = _core.factory.foods[randomFoodId].Produce();
            food.transform.position = _core.config.foodSpawnPosition;
            food.SetSpeed(_core.config.foodSpeed);
            _core.model.foods.Add(food);
        }
        
        protected override void OnUpdate()
        {
            if (_core.model.foods.Count == 0) SpawnFood();
            
            var distance = Vector3.Distance(_core.model.foods[^1].transform.position, _core.config.foodSpawnPosition);
            if (distance >= _core.config.foodSpawnDistance)
            {
                SpawnFood();
            }
        }
    }
}