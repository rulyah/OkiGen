using System.Collections.Generic;
using UnityEngine;
using Utils.FactoryTool;
using Views;

namespace Services.Factory
{
    public class FactoryService : MonoBehaviour
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private List<Food> _foodPrefabs;
        [SerializeField] private Conveyor _conveyorPrefab;
        public Factory<Player> player { get; private set; }
        public List<Factory<Food>> foods { get; private set; }
        public Factory<Conveyor> conveyor { get; private set; }

        private void Awake()
        {
            player = new Factory<Player>(_playerPrefab, 1);
            conveyor = new Factory<Conveyor>(_conveyorPrefab, 1);
            foods = new List<Factory<Food>>(_foodPrefabs.Count);

            for (var i = 0; i < _foodPrefabs.Count; i++)
            {
                var food = new Factory<Food>(_foodPrefabs[i], 50);
                foods.Add(food);
            }
        }

        private void OnDestroy()
        {
            player.Dispose();
            conveyor.Dispose();
            
            foreach (var food in foods)
            {
                food.Dispose();
            }
        }
    }
}