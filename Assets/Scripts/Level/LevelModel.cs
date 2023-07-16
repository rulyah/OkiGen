using System;
using System.Collections.Generic;
using Views;

namespace Level
{
    public class LevelModel
    {
        public List<Food> foods = new();
        public int taskFoodId;
        public int taskFoodCount;
        public Food currentFood;
        
        public event Action<int> onCountChange;

        public void SetTask(int id, int count)
        {
            taskFoodId = id;
            taskFoodCount = count;
        }

        public void ChangeTaskCount()
        {
            taskFoodCount--;
            onCountChange?.Invoke(taskFoodCount);
        }
    }
}