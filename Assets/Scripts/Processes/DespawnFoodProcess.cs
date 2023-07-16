using Level;
using UnityEngine;
using Utils.ProcessTool;
using Views;

namespace Processes
{
    public class DespawnFoodProcess : Process
    {
        private Core _core;
        
        public DespawnFoodProcess(Core core) : base(core)
        {
            _core = core;
        }

        public void DespawnFood(Food food)
        {
            _core.model.foods.Remove(food);
            food.SetSpeed(0.0f);
            _core.factory.foods[food.id].Release(food);
        }

        protected override void OnUpdate()
        {
            var distance = Vector3.Distance(_core.model.foods[0].transform.position, _core.config.foodSpawnPosition);
            if (distance >= _core.config.foodDespawnDistance)
            {
                DespawnFood(_core.model.foods[0]);
            }
        }
    }
}